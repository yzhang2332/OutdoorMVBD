using System;
using System.Windows.Forms;

using Metec.MVBDClient;

namespace MVBDClientReflection
{
    public partial class FormReflection : Form
    {
        protected MVBDConnection    con;
        protected Timer             tmrStatus;

        public FormReflection()
        {
            InitializeComponent();

            con = new MVBDConnection(this);

            tmrStatus = new Timer();
            tmrStatus.Interval = 300;
            tmrStatus.Tick += TmrStatus_Tick;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tmrStatus.Start();
        }

        private void TmrStatus_Tick(object sender, EventArgs e)
        {
            // Status;
            string status;

            if ( con.IsConnected() == true )
            {
                status = String.Format("Connected at {0}, Width={1}, Height={2}, Position={3}",  con.LocalEndPoint, con.PinCountX, con.PinCountY, con.WorkingPosition);
            }
            else
            {
                status = "Not connected";
            }

            if ( status != lblStatus.Text ) lblStatus.Text = status;
        }






        private void btnStartReflection_Click(object sender, EventArgs e)
        {
            MVBDMemberInfo mi = new MVBDMemberInfo();
            mi.Name       = "Program";
            mi.Value      = MVBDPtr.Program;
            mi.ReturnType = typeof(MVBDPtr);

            TreeNode node = new TreeNode();
            node.Tag = mi;

            tv.Nodes.Clear();
            tv.Nodes.Add(node);

            node.Nodes.Add("...");
            //node.Expand();

            //tv_AfterExpand (tv, new TreeViewEventArgs(node) );
        }

 


        private void tv_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode        tn = e.Node;
            MVBDMemberInfo  mi = (MVBDMemberInfo)tn.Tag;
            MVBDPtr         pt = mi.Value as MVBDPtr;
            if ( pt == null )   return; // -->


            MVBDMemberInfo[] members = con.SendGetReflection( pt.Value );

            if ( members != null )
            {
                TreeNodeCollection nodes = tn.Nodes;
                nodes.Clear();

                for(int i = 0; i < members.Length; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = members[i];
                    nodes.Add ( node );

                    if ( members[i].ReturnType == typeof(MVBDPtr) )
                    {
                        node.Nodes.Add("...");
                    }
                }

                //if (tn2.IsExpanded) tn2.Collapse();   else tn2.Expand();
            }
        }
    }








}