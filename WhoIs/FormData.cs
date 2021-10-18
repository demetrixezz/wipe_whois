using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoIs
{
    public partial class FormData : FormBase
    {
        class DataPanel
        {
            private Panel panel = new Panel();
            private DataGridView gridView = new DataGridView();
            public  int LocationX;
            public  int LocationY;
            private int W;
            private int H;
            DataPanel(int coord_x, int coord_y, int width, int height)
            {
                this.LocationX = coord_x;
                this.LocationY = coord_y;
                this.W = width;
                this.H = height;

            }
        }

        public FormData()
        {
            InitializeComponent();

            // Построение внешнего вида формы
            #region
            // Устанавливаем контролам формы (в заголовке) свойства перемещения
            new List<Control> { panelFormDataHead, labelPanelDataHeader }.ForEach(x =>
            {
                x.MouseDown += (s, e) =>
                {
                    x.Capture = false;
                    Capture = false;
                    Message m = Message.Create(Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
                    base.WndProc(ref m);
                };
            });

            // Рисуем фон формы
            #region
            Color clr1 = Color.FromArgb(32, 34, 37);
            Color clr2 = Color.FromArgb(54, 57, 63);
            Color clr3 = Color.FromArgb(54, 57, 63);
            Color clr4 = Color.FromArgb(54, 57, 63);
            FormPaint(clr1, clr2, clr3, clr4);
            #endregion
            // Обработка нажатий кнопок в заголовке формы
            #region
            buttonPanelDataClose.Click += (s, e) => Close();
            buttonPanelDataClose.MouseEnter += (s, e) => buttonPanelDataClose.BackgroundImage = Properties.Resources.CrossCloseOver;
            buttonPanelDataClose.MouseDown += (s, e) => buttonPanelDataClose.BackgroundImage = Properties.Resources.CrossCloseDown;
            buttonPanelDataClose.MouseLeave += (s, e) => buttonPanelDataClose.BackgroundImage = Properties.Resources.CrossClose;
            #endregion

            // Обработка событий мышки для всех текстовых меток панели главной формы (panelFormMain)
            foreach(Label lbl in panelFormData.Controls.OfType<Label>())
            {
                lbl.MouseLeave += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
                lbl.MouseEnter += (s, a) => { lbl.ForeColor = Color.FromArgb(201, 201, 201); };
                lbl.MouseDown += (s, a) => { lbl.ForeColor = Color.FromArgb(221, 221, 221); };
                lbl.MouseUp += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
            }

            #endregion
        }

        // Закрашивает форму
        public void FormPaint(Color color1, Color color2, Color color3, Color color4)
        {
            void OnPaintEventHandler(object s, PaintEventArgs e)
            {
                if(ClientRectangle == Rectangle.Empty)
                    return;
                var lgb = new LinearGradientBrush(ClientRectangle, Color.Empty, Color.Empty, 90);
                var cblend = new ColorBlend { Colors = new[] { color1, color1, color2, color3 }, Positions = new[] { 0, 0.06f, 0.065f, 1} };

                lgb.InterpolationColors = cblend;
                e.Graphics.FillRectangle(lgb, ClientRectangle);
            }
            Paint -= OnPaintEventHandler;
            Paint += OnPaintEventHandler;
            Invalidate();
        }

        // Нажатие на кнопку закрытия формы
        private void ButtonPanelDataClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
