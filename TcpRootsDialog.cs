using System;
using System.Windows.Forms;

namespace Metec.MVBDClient
{
    /// <summary>Dialog for Tcp rootings</summary>
    public partial class TcpRootsDialog : Form
    {
        /// <summary>Shows the dialog</summary>
        public static void Show (MVBDConnection con)
        {
            TcpRootsDialog dlg = new TcpRootsDialog();
            dlg._con = con;
            dlg.ShowDialog();
        }

        protected  MVBDConnection _con;


        /// <summary>Constructor</summary>
        private TcpRootsDialog()
        {
            InitializeComponent();
        }



        /// <summary>Load</summary>
        private void FormTcpRoots_Load(object sender, EventArgs e)
        {
            // Get all roots from the MVBD
            btnGetTcpRoots_Click(null,null);



            bool[,,] tcpRoots = _con.TcpRoots;

            int cmdCount = tcpRoots.GetLength(0);   // 5
            int idCount  = tcpRoots.GetLength(1);   // 16




            // DataGridView
            dgv.RowHeadersVisible = true;



            // Create Columns (out):
            dgv.Columns.Clear();

            for(int o = 0; o < idCount; o++)
            {
                DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                column.ValueType  = typeof(bool);
                column.HeaderText = String.Format("{0}", o);
                column.Width      = 30;

                dgv.Columns.Add(column);
            }

            // Create Rows (int):
            dgv.Rows.Clear();

            for(int i = 0; i < idCount; i++)
            {
                dgv.Rows.Add();

                dgv.Rows[i].HeaderCell.Value = String.Format("{0}", i);             // 1
            }



            // Commands
            cboCommands.Items.Clear();
            for(int cmd = 0; cmd < cmdCount; cmd++)
            {
                cboCommands.Items.Add( String.Format("{0}", cmd) );
            }

            if (cboCommands.Items.Count != 0)
            {
                cboCommands.SelectedIndex = 0;  // --> SelectedIndexChanged --> Fill dgv
            }



        }


        /// <summary>Get TcpRoots (32)</summary>
        private void btnGetTcpRoots_Click(object sender, EventArgs e)
        {
            _con.SendGetTcpRoots();
            //cboCommands_SelectedIndexChanged(null,null);
        }

        /// <summary>Set TcpRoots (33)</summary>
        private void btnSetTcpRoots_Click(object sender, EventArgs e)
        {
            _con.SendSetTcpRoots();
        }

        private void chkSendImmediate_CheckedChanged(object sender, EventArgs e)
        {
        }






        /// <summary>ComboBox Command changed (Pins,Keys,Fingers,...)</summary>
        private void cboCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool[,,] tcpRoots = _con.TcpRoots;

            int cmd      = cboCommands.SelectedIndex;    // 0,1,2,3,4
            int idCount  = tcpRoots.GetLength(1);   // 16

            _isLocked = true;   // no CellValueChanged now

            for(int i = 0; i < idCount; i++)
            {
                for(int o = 0; o < idCount; o++)
                {
                    dgv[o,i].Value = tcpRoots[ cmd, i,o ];  // column = out, row = in
                }
            }

            dgv.RefreshEdit();

            _isLocked = false;
        }

        protected bool _isLocked;


        /// <summary>Change a value in the rootings</summary>
        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ( _isLocked     == true )  return; // -->
            if ( e.ColumnIndex == -1   )  return; // --> RowHeader
            if ( e.RowIndex    == -1   )  return; // --> ColumnHeader

            int cmd     = cboCommands.SelectedIndex;    // 0,1,2,3,4
            int  i      = e.RowIndex;                   // in = row
            int  o      = e.ColumnIndex;                // out = column
            bool value  = (bool)dgv[o,i].Value;         // column = out, row = in

            _con.TcpRoots[cmd,i,o] = value;             // Write in array



            if ( chkSendImmediate.Checked == true )
            {
                _con.SendSetTcpRootsValue(cmd,i,o,value);
            }

        }


        /// <summary>Commit immediately. For example when a Checkbox is changed. Else you have to leave the row</summary>
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);   // --> CellValueChanged
        }





    }
}