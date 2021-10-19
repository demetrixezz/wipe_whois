using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace WhoIs
{
    class ButtonRounded : Button
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr RoundButton(int leftRect, int topRect, int rightRect, int bottomRect, int widthEllipse, int heightEllipse);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            IntPtr ptr = RoundButton(0,0,Width,Height,12,12);
            Region = Region.FromHrgn(ptr);
        }
    }
}
