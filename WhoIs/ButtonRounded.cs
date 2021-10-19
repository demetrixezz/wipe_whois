using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace WhoIs
{
    class ButtonRounded : Button
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr RoundButton(int leftRect, int topRect, int rightRect, int bottomRect, int widthEllipse, int heightEllipse);
        
        [DisplayName("RoundedWidth")]
        [DefaultValue(10)]
        public int RoundedWidth { get; set; }
        
        [DisplayName("RoundedHeight")]
        [DefaultValue(10)]
        public int RoundedHeight { get; set; }
        
        private StringFormat sf = new StringFormat();
        public ButtonRounded()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint         | 
                          ControlStyles.OptimizedDoubleBuffer        | 
                          ControlStyles.ResizeRedraw                 | 
                          ControlStyles.SupportsTransparentBackColor | 
                          ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
            this.Size = new Size(100, 30);
            this.BackColor = Color.FromArgb(102, 102, 102);
            this.ForeColor = Color.White;
            this.sf.Alignment = StringAlignment.Center;
            this.sf.LineAlignment = StringAlignment.Center;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            IntPtr ptr = RoundButton(0,0,this.Width,this.Height,this.RoundedWidth,this.RoundedHeight);
            this.Region = Region.FromHrgn(ptr);
        }
    }
}
