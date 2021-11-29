using Microsoft.Win32;
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
        /// <summary>
        /// Перечисление типов записей в базе данных
        /// </summary>
        public enum ENUM_DB_DATA_TYPE
        {
            PANEL_GRID_VIEW_PILOTS_WIPE,        // Список пилотов WIPE
            PANEL_GRID_VIEW_PILOTS_SPEAR,       // Список пилотов Spears
            PANEL_GRID_VIEW_PILOTS_FRIEND,      // Список доверенных пилотов эскадры
            PANEL_GRID_VIEW_PILOTS_GUEST,       // Список пилотов-гостей эскадры
            PANEL_GRID_VIEW_PILOTS_ENEMY,       // Список враждебных эскадре пилотов
            PANEL_GRID_VIEW_PILOTS_WORST_ENEMY, // Список враждебных пилотов (KoS-лист эскадры)
            PANEL_GRID_VIEW_PILOTS_LOGOFF_CLOG, // Список пилотов-логоферов/клоггеров
            PANEL_GRID_VIEW_PILOTS_CHEATER,     // Список пилотов-читеров
            PANEL_GRID_VIEW_PILOTS_OTHER,       // Дополнительный список пилотов

            PANEL_GRID_VIEW_SQUAD_ALLIED,       // Список эскадр-союзников
            PANEL_GRID_VIEW_SQUAD_IMPERIAL,     // Список эскадр-имперцев
            PANEL_GRID_VIEW_SQUAD_SUSPICIOUS,   // Список подозрительных эскадр
            PANEL_GRID_VIEW_SQUAD_FEDERAL,      // Список эскадр-федералов
            PANEL_GRID_VIEW_SQUAD_ENEMY,        // Список враждебных эскадр (KoS-лист эскадры)
        }

        /// <summary>
        /// Возвращает описание перечисления типа записи в базе данных
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string DBDataTypeDescription(int index)
        {
            ENUM_DB_DATA_TYPE n = (ENUM_DB_DATA_TYPE)index;
            switch(n)
            {
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_WIPE          : return "Список пилотов WIPE";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_SPEAR         : return "Список пилотов Spears";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_FRIEND        : return "Список доверенных пилотов эскадры";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_GUEST         : return "Список пилотов-гостей эскадры";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_ENEMY         : return "Список враждебных эскадре пилотов";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_WORST_ENEMY   : return "Список враждебных пилотов (KoS-лист эскадры)";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_LOGOFF_CLOG   : return "Список пилотов-логоферов/клоггеров";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_CHEATER       : return "Список пилотов-читеров";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_OTHER         : return "Дополнительный список пилотов";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_ALLIED         : return "Список эскадр-союзников";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_IMPERIAL       : return "Список эскадр-имперцев";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_SUSPICIOUS     : return "Список подозрительных эскадр";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_FEDERAL        : return "Список эскадр-федералов";
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_ENEMY          : return "Список враждебных эскадр (KoS-лист эскадры)";
                default: return "Unknown";
            }
        }

        /// <summary>
        /// Возвращает тип данных в базе по индексу перечисления
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ENUM_DB_DATA_TYPE DBDataType(int index)
        {
            int total = Enum.GetNames(typeof(ENUM_DB_DATA_TYPE)).Length;
            int n = index < 0 ? 0 : index > total-1 ? total-1 : index;
            switch(n)
            {
                case 0:  return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_WIPE;
                case 1:  return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_SPEAR;
                case 2:  return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_FRIEND;
                case 3:  return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_GUEST;
                case 4:  return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_ENEMY;
                case 5:  return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_WORST_ENEMY;
                case 6:  return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_LOGOFF_CLOG;
                case 7:  return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_CHEATER;
                case 8:  return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_OTHER;
                case 9:  return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_ALLIED;
                case 10: return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_IMPERIAL;
                case 11: return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_SUSPICIOUS;
                case 12: return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_FEDERAL;
                case 13: return ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_ENEMY;
                default: return(ENUM_DB_DATA_TYPE)(-1);
            }
        }

        /// <summary>
        /// Возвращает индекс типа данных в перечислении ENUM_DB_DATA_TYPE
        /// </summary>
        /// <param name="db_data_type"></param>
        /// <returns></returns>
        public static int DBDataIndex(ENUM_DB_DATA_TYPE db_data_type)
        {
            switch(db_data_type)
            {
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_WIPE          : return 0;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_SPEAR         : return 1;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_FRIEND        : return 2;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_GUEST         : return 3;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_ENEMY         : return 4;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_WORST_ENEMY   : return 5;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_LOGOFF_CLOG   : return 6;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_CHEATER       : return 7;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_OTHER         : return 8;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_ALLIED         : return 9;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_IMPERIAL       : return 10;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_SUSPICIOUS     : return 11;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_FEDERAL        : return 12;
                case ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_SQUAD_ENEMY          : return 13;
                default: return -1;
            }
        }

        /// <summary>
        /// Класс - панель с таблицей из базы данных и текстовой меткой с описанием таблицы
        /// </summary>
        class PanelDataGridView : Panel
        {
            private DataGridView gridView = new DataGridView();
            private Label label = new Label();
            ENUM_DB_DATA_TYPE data_type;
            private bool wait_for_slide;

            public PanelDataGridView(int coord_x, int coord_y, int width, int height, int grid_location_shift_y, ENUM_DB_DATA_TYPE db_data_type)
            {
                wait_for_slide = false;
                this.data_type = db_data_type;
                this.Controls.Add(this.gridView);
                this.Controls.Add(this.label);
                this.Location = new Point(coord_x, coord_y);
                this.Width = width;
                this.Height = height;
                this.gridView.Location = new Point(0, grid_location_shift_y);
                this.gridView.Width = width;
                this.gridView.Height = height - this.gridView.Location.Y;
                this.InitializeDataGridView();
                this.InitializeLabel(DBDataTypeDescription(DBDataIndex(this.data_type)));
                this.Hide();
            }

            /// <summary>
            /// Инициализация таблицы
            /// </summary>
            private void InitializeDataGridView()
            {
                // Инициализация основных свойств DataGridView
                this.gridView.Dock = DockStyle.Bottom;
                this.gridView.BorderStyle = BorderStyle.None;
                this.gridView.BackgroundColor = Color.FromArgb(64, 68, 75);
                this.gridView.ForeColor = Color.FromArgb(171, 171, 171);
                this.gridView.Font = new Font("Microsoft Sans Serif", 8.25f);

                // Установка значений свойств только для чтения и ограничения интерактивности
                this.gridView.AllowUserToAddRows = false;
                this.gridView.AllowUserToDeleteRows = false;
                this.gridView.AllowUserToOrderColumns = true;
                this.gridView.ReadOnly = true;
                this.gridView.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
                this.gridView.MultiSelect = false;
                this.gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.gridView.AllowUserToResizeColumns = false;
                this.gridView.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                this.gridView.AllowUserToResizeRows = false;
                this.gridView.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                // Установка цвета фона выделения для всех ячеек
                this.gridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 68, 60);
                this.gridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(191, 171, 171);

                // Значение RowHeadersDefaultCellStyle.SelectionBackColor по умолчанию
                // не переопределяет DataGridView.DefaultCellStyle.SelectionBackColor
                this.gridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

                // Установка цвета фона для всех строк и для чередующихся строк.
                // Значение для чередующихся строк переопределяет значение для всех строк.
                this.gridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(66, 70, 77);
                this.gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(66, 70, 87);

                // Установка стилей заголовков строк и столбцов
                this.gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(181, 181, 181);
                this.gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(47, 49, 54);
                this.gridView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(47, 49, 54);

                // Присоединение обработчика события CellFormatting
                this.gridView.CellFormatting += new
                    DataGridViewCellFormattingEventHandler(DataGridViewCellFormatting);
            }

            // Обработчик события CellFormatting
            // В примере: Изменяет цвет переднего плана ячеек в столбце «Рейтинг» в зависимости от количества очков рейтинга
            private void DataGridViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                //if(e.ColumnIndex == this.gridView.Columns["Rating"].Index && e.Value != null)
                //{
                //    switch(e.Value.ToString().Length)
                //    {
                //        case 1:
                //        e.CellStyle.SelectionForeColor = Color.Red;
                //        e.CellStyle.ForeColor = Color.Red;
                //        break;
                //        case 2:
                //        e.CellStyle.SelectionForeColor = Color.Yellow;
                //        e.CellStyle.ForeColor = Color.Yellow;
                //        break;
                //        case 3:
                //        e.CellStyle.SelectionForeColor = Color.Green;
                //        e.CellStyle.ForeColor = Color.Green;
                //        break;
                //        case 4:
                //        e.CellStyle.SelectionForeColor = Color.Blue;
                //        e.CellStyle.ForeColor = Color.Blue;
                //        break;
                //    }
                //}
            }

            /// <summary>
            /// Инициализация текстовой метки
            /// </summary>
            private void InitializeLabel(string description)
            {
                this.label.AutoSize = true;
                this.label.Location = new Point(4, 8);
                this.label.Text = description;
                this.label.ForeColor = Color.FromArgb(171, 171, 171);
                this.label.Font = new Font("Arial", 9, FontStyle.Bold);
            }

            /// <summary>
            /// Возвращает таблицу
            /// </summary>
            /// <returns></returns>
            public DataGridView GetDataGridView() { return this.gridView; }

            /// <summary>
            /// Возвращает описание панели
            /// </summary>
            /// <returns></returns>
            public string Description() { return this.label.Text; }

            /// <summary>
            /// Возвращает тип данных таблицы
            /// </summary>
            /// <returns></returns>
            public ENUM_DB_DATA_TYPE GetDataGridViewDataType() { return this.data_type; }

            /// <summary>
            /// Показывает панель
            /// </summary>
            /// <param name="grid_db_data_type"></param>
            /// <param name="panel_parent"></param>
            /// <param name="slowdown"></param>
            public async void SlideIn(int slowdown)
            {
                this.Show();
                while(!this.wait_for_slide && this.Location.X > 0)
                {
                    this.wait_for_slide = true;
                    await Task.Delay(1);
                    this.Location = new Point(this.Location.X -
                        (Math.Abs(this.Location.X) / slowdown > 0 ?
                         Math.Abs(this.Location.X) / slowdown : 1), this.Location.Y);
                    this.wait_for_slide = false;
                }
                if(this.Location.X != 0)
                    this.Location = new Point(0, this.Location.Y);
            }

            /// <summary>
            /// Скрывает панель
            /// </summary>
            /// <param name="grid_db_data_type"></param>
            /// <param name="panel_parent"></param>
            /// <param name="slowdown"></param>
            public async void SlideOut(int slowdown)
            {
                while(!this.wait_for_slide && this.Location.X < this.Parent.Width)
                {
                    this.wait_for_slide = true;
                    await Task.Delay(1);
                    this.Location = new Point(this.Location.X +
                        ((this.Parent.Width - Math.Abs(this.Location.X)) / slowdown > 0 ?
                         (this.Parent.Width - Math.Abs(this.Location.X)) / slowdown : 1), this.Location.Y);
                    this.wait_for_slide = false;
                }
                if(this.Location.X != this.Parent.Width)
                    this.Location = new Point(this.Parent.Width, this.Location.Y);
                this.Hide();
            }
        }

        /// <summary>
        /// Класс содержит коллекцию панелей с таблицами базы данных
        /// </summary>
        class PanelDataGridViewCollection
        {
            private readonly int total = Enum.GetNames(typeof(ENUM_DB_DATA_TYPE)).Length;
            private List<PanelDataGridView> list = new List<PanelDataGridView>();
            
            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="panel_parent"></param>
            /// <param name="coord_x"></param>
            /// <param name="coord_y"></param>
            /// <param name="width"></param>
            /// <param name="height"></param>
            public PanelDataGridViewCollection(Panel panel_parent, int coord_x, int coord_y, int width, int height)
            {
                for(int i = 0; i < total; i++)
                {
                    PanelDataGridView panel = new PanelDataGridView(coord_x, coord_y, width, height, 30, DBDataType(i));
                    panel_parent.Controls.Add(panel);
                    panel.Parent = panel_parent;
                    this.list.Add(panel);
                }
            }

            /// <summary>
            /// Возвращает список панелей
            /// </summary>
            /// <returns></returns>
            public List<PanelDataGridView> GetPanelsList()  { return this.list; }
            
            /// <summary>
            /// Возвращает панель по индексу в списке
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public PanelDataGridView GetPanel(int index)
            { 
                return this.list.ElementAt(index<0 ? 0 : index > this.list.Count-1 ? this.list.Count-1 : index); 
            }

            /// <summary>
            /// Возвращает панель по константе перечисления типов данных
            /// </summary>
            /// <param name="data_grid_type"></param>
            /// <returns></returns>
            public PanelDataGridView GetPanel(ENUM_DB_DATA_TYPE data_grid_type) { return GetPanel(((int)data_grid_type)); }

            /// <summary>
            /// Возвращает таблицу панели по индексу панели
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public DataGridView GetDataGridView(int index) { return this.GetPanel(index).GetDataGridView(); }

            /// <summary>
            /// Возвращает описание панели по индексу
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public string PanelDescription(int index) { return this.GetPanel(index).Description(); }

            /// <summary>
            /// Возвращает тип данных в панели по индексу
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public ENUM_DB_DATA_TYPE PanelDBDataType(int index) { return DBDataType(index); }
        }
        
        // Объявляем объект-коллекцию панелей с данными БД в DataGridView
        PanelDataGridViewCollection DBPanels = null;
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

            // Создание коллекции панелей с таблицами (Объект DBPanels)
            #region
            DBPanels = new PanelDataGridViewCollection(panelControlsFormData, 
                                                       panelControlsFormData.Width, 
                                                       0,
                                                       panelControlsFormData.Width,
                                                       panelControlsFormData.Height);

            ControlView.Normal(labelStatusFormData, "");
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
                e.Graphics.DrawRectangle(new Pen(color1, 2), 1, 1, this.Width-2, this.Height-2);
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

        // Внешний вид и поведение текстовой метки
        public static class ControlView
        {
            public static void Normal(Label lbl, string text = "")
            {
                lbl.ForeColor = Color.FromArgb(171, 171, 171);
                lbl.MouseLeave += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
                lbl.MouseEnter += (s, a) => { lbl.ForeColor = Color.FromArgb(201, 201, 201); };
                lbl.MouseDown += (s, a) => { lbl.ForeColor = Color.FromArgb(221, 221, 221); };
                lbl.MouseUp += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
                lbl.Text = text != "" ? text : lbl.Text;
            }
            public static void Warning(Label lbl, string text = "")
            {
                lbl.ForeColor = Color.FromArgb(230, 36, 55);
                lbl.MouseLeave += (s, a) => { lbl.ForeColor = Color.FromArgb(230, 36, 55); };
                lbl.MouseEnter += (s, a) => { lbl.ForeColor = Color.FromArgb(240, 46, 65); };
                lbl.MouseDown += (s, a) => { lbl.ForeColor = Color.FromArgb(250, 56, 75); };
                lbl.MouseUp += (s, a) => { lbl.ForeColor = Color.FromArgb(230, 36, 55); };
                lbl.Text = text != "" ? text : lbl.Text;
            }
        }

        // Щелчок по кнопке "Эскадры"
        private void ButtonSquadrons_Click(object sender, EventArgs e)
        {
            HidePanelsGridAll();
        }

        // Щелчок по кнопке "Пилоты"
        private void ButtonPilots_Click(object sender, EventArgs e)
        {
            DBPanels.GetPanel(ENUM_DB_DATA_TYPE.PANEL_GRID_VIEW_PILOTS_WIPE).SlideIn(5);
        }

        /// <summary>
        /// Скрывает все панели с таблицами
        /// </summary>
        private void HidePanelsGridAll()
        {
            foreach(PanelDataGridView panel in DBPanels.GetPanelsList())
                panel.SlideOut(8);
        }

        // Загрузка формы
        private void FormData_Load(object sender, EventArgs e)
        {
            this.SettingsLoad();
        }
        // Закрытие формы
        private void FormData_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.SettingsSave();
        }

        // Запись параметров формы в реестр
        void SettingsSave()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                RegKey.SetValue("FormDataLocationX", Location.X, RegistryValueKind.DWord);
                RegKey.SetValue("FormDataLocationY", Location.Y, RegistryValueKind.DWord);
            }
        }
        // Загрузка параметров формы из реестра
        void SettingsLoad()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                int x = Convert.ToInt32(RegKey.GetValue("FormDataLocationX", 100));
                int y = Convert.ToInt32(RegKey.GetValue("FormDataLocationY", 100));
                this.Location = new Point(x, y);
            }
        }
    }
}
