using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TradeViewer
{
    public partial class CustomTabControl : TabControl
    {
        public CustomTabControl()
        {
            InitializeComponent();
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.Padding = new System.Drawing.Point(22, 4);
        }

        public CustomTabControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private Color nonactive_color1 = Color.LightGreen;
        private Color nonactive_color2 = Color.DarkBlue;
        private Color active_color1 = Color.Yellow;
        private Color active_color2 = Color.DarkOrange;
        public Color forecolor = Color.Navy;
        private int color1Transparent = 150;
        private int color2Transparent = 150;
        private int angle = 90;
        private Color closebuttoncolor = Color.Red;
        private const int TCM_ADJUSTRECT = 0x1328;

        protected override void WndProc(ref Message m)
        {
            //Hide the tab headers at run-time
            if (m.Msg == TCM_ADJUSTRECT)
            {
                RECT rect = (RECT)(m.GetLParam(typeof(RECT)));
                rect.Left = this.Left - this.Margin.Left;
                rect.Right = this.Right + this.Margin.Right;

                rect.Top = this.Top - this.Margin.Top;
                rect.Bottom = this.Bottom + this.Margin.Bottom;
                Marshal.StructureToPtr(rect, m.LParam, true);
                //m.Result = (IntPtr)1;
                //return;
            }
            //else
            // call the base class implementation
            base.WndProc(ref m);
        }

        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        //Create Properties to read values
        public Color ActiveTabStartColor
        {
            get { return active_color1; }
            set { active_color1 = value; Invalidate(); }
        }


        public Color ActiveTabEndColor
        {
            get { return active_color2; }
            set { active_color2 = value; Invalidate(); }
        }


        public Color NonActiveTabStartColor
        {
            get { return nonactive_color1; }
            set { nonactive_color1 = value; Invalidate(); }
        }


        public Color NonActiveTabEndColor
        {
            get { return nonactive_color2; }
            set { nonactive_color2 = value; Invalidate(); }
        }


        public int Transparent1
        {
            get { return color1Transparent; }
            set
            {
                color1Transparent = value;
                if (color1Transparent > 255)
                {
                    color1Transparent = 255;
                    Invalidate();
                }
                else
                    Invalidate();
            }
        }


        public int Transparent2
        {
            get { return color2Transparent; }
            set
            {
                color2Transparent = value;
                if (color2Transparent > 255)
                {
                    color2Transparent = 255;
                    Invalidate();
                }
                else
                    Invalidate();
            }
        }


        public int GradientAngle
        {
            get { return angle; }
            set { angle = value; Invalidate(); }
        }


        public Color TextColor
        {
            get { return forecolor; }
            set { forecolor = value; Invalidate(); }
        }

        public Color CloseButtonColor
        {
            get { return closebuttoncolor; }
            set { closebuttoncolor = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }


        //method for drawing tab items 
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            int maxX = 0;
            for (int i = 0; i < this.TabCount; i++)
            {
                Rectangle temp = GetTabRect(i);
                if (maxX < temp.X + temp.Width)
                    maxX = temp.X + temp.Width;
            }

            Rectangle rect = new Rectangle(maxX, 0, 2000, 26);
            using (SolidBrush br = new SolidBrush(Color.FromArgb(29, 29, 29)))
            {
                e.Graphics.FillRectangle(br, rect);
            }

            Rectangle rc = GetTabRect(e.Index);

            //if tab is selected
            if (this.SelectedTab == this.TabPages[e.Index])
            {
                Color c1 = Color.FromArgb(color1Transparent, active_color1);
                Color c2 = Color.FromArgb(color2Transparent, active_color2);
                using (LinearGradientBrush br = new LinearGradientBrush(rc, c1, c2, angle))
                {
                    e.Graphics.FillRectangle(br, rc);
                }
            }
            else
            {
                Color c1 = Color.FromArgb(color1Transparent, nonactive_color1);
                Color c2 = Color.FromArgb(color2Transparent, nonactive_color2);

                using (SolidBrush br = new SolidBrush(Color.FromArgb(29, 29, 29)))
                {
                    rc.Y -= 10;
                    rc.Height += 10;
                    e.Graphics.FillRectangle(br, rc);
                }


            }

            this.TabPages[e.Index].BorderStyle = BorderStyle.FixedSingle;
            this.TabPages[e.Index].ForeColor = SystemColors.ControlText;

            //draw close button on tabs

            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-5, -4);
            e.Graphics.DrawString(this.TabPages[e.Index].Text, this.Font, new SolidBrush(forecolor), paddedBounds);

            e.DrawFocusRectangle();
        }


        //action for when mouse click on close button
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }
    }
}
