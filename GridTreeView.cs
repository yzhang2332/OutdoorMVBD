using System;
using System.Drawing;
using System.Windows.Forms;

using Metec.MVBDClient;

namespace MVBDClientReflection
{
    public class GridTreeView : TreeView
    {

        public GridTreeView()
        {
            BorderStyle         = BorderStyle.FixedSingle;
            DrawMode            = TreeViewDrawMode.OwnerDrawText;
            FullRowSelect       = true;
            HideSelection       = false;
            Indent              = 10;
            ItemHeight          = 20;
            ShowLines           = false;
            ShowNodeToolTips    = true;
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);

            if (e.Node.IsVisible == false)  return; // -->

            TreeNode  tn    = e.Node;
            Font      font  = Font;
            Brush     brush = new SolidBrush( ForeColor );
            Pen       pen   = new Pen       ( Color.LightGray );
            Graphics  g     = e.Graphics;
            Rectangle rect  = e.Bounds;

            int x       = rect.Left;
            int top     = rect.Top;
            int bottom  = rect.Bottom;



            bool isSelected = ( (e.State & TreeNodeStates.Selected) != 0);
            bool isFocused  = ( (e.State & TreeNodeStates.Focused ) != 0);

            if (isSelected && isFocused)
            {
                brush = new SolidBrush(SystemColors.HighlightText);
            }

            MVBDMemberInfo  mi = tn.Tag as MVBDMemberInfo;
            if (mi == null)
            {
                g.DrawString(tn.Text, font,brush,    x+3, top+3);
                return; // -->
            }


            string txtName;
            string txtWert;
            string txtTyp;

            Brush  brWert = brush;

            if ( mi.ExceptionMessage != null )
            {
                txtName = mi.Name;
                txtWert = mi.ExceptionMessage;
                brWert  = Brushes.Red;
                txtTyp  = mi.ReturnType.Name;
            }

            else if ( mi.ReturnType == typeof(MVBDPtr) )
            {
                txtName = mi.Name;

                if ( mi.Value == null )
                {
                    txtWert = "null";
                }
                else
                {
                    MVBDPtr ptr = (MVBDPtr)mi.Value;
                    txtWert = String.Format("{0}", mi.TypeName );
                }

                txtTyp = String.Format("{0}", mi.ReturnType.FullName );
            }
            else
            {
                txtName = mi.Name;
                if ( mi.Value == null ) txtWert = "null"; else txtWert = String.Format("{0}", mi.Value);
                txtTyp = mi.ReturnType.Name;
            }


            // 1. Name
            g.DrawString( txtName, font,brush,    x+3, top+3);

            // 2. Wert
            int x1 = 300;
            g.DrawLine  (pen,   x1, top,   x1, bottom);
            g.DrawString( txtWert, font,brWert,   x1+3, top+3);

            // 3. Typ
            int x2 = 600;
            g.DrawLine  (pen,   x2, top,   x2, bottom);
            g.DrawString( txtTyp, font,brush,   x2+3, top+3);




            // Horizontale Linie
            g.DrawLine(pen, 0, bottom-1, ClientRectangle.Right, bottom-1);
        }





    }
}