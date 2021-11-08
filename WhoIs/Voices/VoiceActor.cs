using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EliteJournalReader;

namespace WhoIs
{
    public enum ENUM_ED_EVENT_DATA_INDEXES
    {
        ED_EVENT_DATA_AFMUREPAIRS,
        ED_EVENT_DATA_APPLIED_TO_SQUADRON,
        ED_EVENT_DATA_APPROACH_BODY,
        ED_EVENT_DATA_APPROACH_SETTLEMENT,
        ED_EVENT_DATA_ASTEROID_CRACKED,
        ED_EVENT_DATA_BACKPACK_MATERIALS,
        ED_EVENT_DATA_BOOK_DROPSHIP,
        ED_EVENT_DATA_BOOK_TAXI,
        ED_EVENT_DATA_BOUNTY,
        ED_EVENT_DATA_BUY_AMMO,
        ED_EVENT_DATA_BUY_DRONES,
        ED_EVENT_DATA_BUY_EXPLORATION_DATA,
        ED_EVENT_DATA_BUY_MICRO_RESOURCES,
        ED_EVENT_DATA_BUY_SUIT,
        ED_EVENT_DATA_BUY_TRADE_DATA,
        ED_EVENT_DATA_BUY_WEAPON,
        ED_EVENT_DATA_CANCEL_DROPSHIP,
        ED_EVENT_DATA_CANCEL_TAXI,
        ED_EVENT_DATA_CAP_SHIP_BOND,
        ED_EVENT_DATA_CARGO_DEPOT,
        ED_EVENT_DATA_CARGO,
        ED_EVENT_DATA_CARGO_TRANSFER,
        ED_EVENT_DATA_CARRIER_BANK_TRANSFER,
        ED_EVENT_DATA_CARRIER_BUY,
        ED_EVENT_DATA_CARRIER_CANCEL_DECOMMISSION,
        ED_EVENT_DATA_CARRIER_CREW_SERVICES,
        ED_EVENT_DATA_CARRIER_DECOMMISSION,
        ED_EVENT_DATA_CARRIER_DEPOSIT_FUEL,
        ED_EVENT_DATA_CARRIER_DOCKING_PERMISSION,
        ED_EVENT_DATA_CARRIER_FINANCE,
        ED_EVENT_DATA_CARRIER_JUMP_CANCELLED,
        ED_EVENT_DATA_CARRIER_JUMP,
        ED_EVENT_DATA_CARRIER_JUMP_REQUEST,
        ED_EVENT_DATA_CARRIER_MODULE_PACK,
        ED_EVENT_DATA_CARRIER_NAME_CHANGED,
        ED_EVENT_DATA_CARRIER_SHIP_PACK,
        ED_EVENT_DATA_CARRIER_STATS,
        ED_EVENT_DATA_CARRIER_TRADE_ORDER,
        ED_EVENT_DATA_CHANGE_CREW_ROLE,
        ED_EVENT_DATA_CLEAR_SAVED_GAME,
        ED_EVENT_DATA_COCKPIT_BREACHED,
        ED_EVENT_DATA_CODEX_ENTRY,
        ED_EVENT_DATA_COLLECT_CARGO,
        ED_EVENT_DATA_COLLECT_ITEMS,
        ED_EVENT_DATA_COMMANDER,
        ED_EVENT_DATA_COMMIT_CRIME,
        ED_EVENT_DATA_COMMUNITY_GOAL_DISCARD,
        ED_EVENT_DATA_COMMUNITY_GOAL,
        ED_EVENT_DATA_COMMUNITY_GOAL_JOIN,
        ED_EVENT_DATA_COMMUNITY_GOAL_REWARD,
        ED_EVENT_DATA_CONTINUED,
        ED_EVENT_DATA_CREATE_SUIT_LOADOUT,
        ED_EVENT_DATA_CREW_ASSIGN,
        ED_EVENT_DATA_CREW_FIRE,
        ED_EVENT_DATA_CREW_HIRE,
        ED_EVENT_DATA_CREW_LAUNCH_FIGHTER,
        ED_EVENT_DATA_CREW_MEMBER_JOINS,
        ED_EVENT_DATA_CREW_MEMBER_QUITS,
        ED_EVENT_DATA_CREW_MEMBER_ROLE_CHANGE,
        ED_EVENT_DATA_CRIME_VICTIM,
        ED_EVENT_DATA_DATALINK_SCAN,
        ED_EVENT_DATA_DATALINK_VOUCHER,
        ED_EVENT_DATA_DATA_SCANNED,
        ED_EVENT_DATA_DELETE_SUIT_LOADOUT,
        ED_EVENT_DATA_DIED,
        ED_EVENT_DATA_DISBANDED_SQUADRON,
        ED_EVENT_DATA_DISCOVERY_SCAN,
        ED_EVENT_DATA_DISEMBARK,
        ED_EVENT_DATA_DOCKED,
        ED_EVENT_DATA_DOCK_FIGHTER,
        ED_EVENT_DATA_DOCKING_CANCELLED,
        ED_EVENT_DATA_DOCKING_DENIED,
        ED_EVENT_DATA_DOCKING_GRANTED,
        ED_EVENT_DATA_DOCKING_REQUESTED,
        ED_EVENT_DATA_DOCKING_TIMEOUT,
        ED_EVENT_DATA_DOCK_SRV,
        ED_EVENT_DATA_DROP_ITEMS,
        ED_EVENT_DATA_DROP_SHIP_DEPLOY,
        ED_EVENT_DATA_EJECT_CARGO,
        ED_EVENT_DATA_EMBARK,
        ED_EVENT_DATA_END_CREW_SESSION,
        ED_EVENT_DATA_ENGINEER_CONTRIBUTION,
        ED_EVENT_DATA_ENGINEER_CRAFT,
        ED_EVENT_DATA_ENGINEER_LEGACY_CONVERT,
        ED_EVENT_DATA_ENGINEER_PROGRESS,
        ED_EVENT_DATA_ESCAPE_INTERDICTION,
        ED_EVENT_DATA_FACTION_KILL_BOND,
        ED_EVENT_DATA_FETCH_REMOTE_MODULE,
        ED_EVENT_DATA_FIGHTER_DESTROYED,
        ED_EVENT_DATA_FIGHTER_REBUILT,
        ED_EVENT_DATA_FILEHEADER,
        ED_EVENT_DATA_FRIENDS,
        ED_EVENT_DATA_FSD_JUMP,
        ED_EVENT_DATA_FSD_TARGET,
        ED_EVENT_DATA_FSS_ALL_BODIES_FOUND,
        ED_EVENT_DATA_FSS_DISCOVERY_SCAN,
        ED_EVENT_DATA_FSS_SIGNAL_DISCOVERED,
        ED_EVENT_DATA_FUEL_SCOOP,
        ED_EVENT_DATA_HEAT_DAMAGE,
        ED_EVENT_DATA_HEAT_WARNING,
        ED_EVENT_DATA_HULL_DAMAGE,
        ED_EVENT_DATA_INTERDICTED,
        ED_EVENT_DATA_INTERDICTION,
        ED_EVENT_DATA_INVITED_TO_SQUADRON,
        ED_EVENT_DATA_MAGIC_MAU_IS_LIVE_EVENT,
        ED_EVENT_DATA_JET_CONE_BOOST,
        ED_EVENT_DATA_JET_CONE_DAMAGE,
        ED_EVENT_DATA_JOIN_A_CREW,
        ED_EVENT_DATA_JOINED_SQUADRON,
        ED_EVENT_DATA_KICK_CREW_MEMBER,
        ED_EVENT_DATA_KICKED_FROM_SQUADRON,
        ED_EVENT_DATA_LAUNCH_DRONE,
        ED_EVENT_DATA_LAUNCH_FIGHTER,
        ED_EVENT_DATA_LAUNCH_SRV,
        ED_EVENT_DATA_LEAVE_BODY,
        ED_EVENT_DATA_LEFT_SQUADRON,
        ED_EVENT_DATA_LIFTOFF,
        ED_EVENT_DATA_LOAD_GAME,
        ED_EVENT_DATA_LOADOUT_EQUIP_MODULE,
        ED_EVENT_DATA_LOADOUT,
        ED_EVENT_DATA_LOADOUT_REMOVE_MODULE,
        ED_EVENT_DATA_LOCATION,
        ED_EVENT_DATA_MARKET_BUY,
        ED_EVENT_DATA_MARKET,
        ED_EVENT_DATA_MARKET_REFINED,
        ED_EVENT_DATA_MARKET_SELL,
        ED_EVENT_DATA_MASS_MODULE_STORE,
        ED_EVENT_DATA_MATERIAL_COLLECTED,
        ED_EVENT_DATA_MATERIAL_DISCARDED,
        ED_EVENT_DATA_MATERIAL_DISCOVERED,
        ED_EVENT_DATA_MATERIALS,
        ED_EVENT_DATA_MATERIAL_TRADE,
        ED_EVENT_DATA_MINING_REFINED,
        ED_EVENT_DATA_MISSION_ABANDONED,
        ED_EVENT_DATA_MISSION_ACCEPTED,
        ED_EVENT_DATA_MISSION_COMPLETED,
        ED_EVENT_DATA_MISSION_FAILED,
        ED_EVENT_DATA_MISSION_REDIRECTED,
        ED_EVENT_DATA_MISSIONS,
        ED_EVENT_DATA_MODULE_BUY,
        ED_EVENT_DATA_MODULE_INFO,
        ED_EVENT_DATA_MODULE_RETRIEVE,
        ED_EVENT_DATA_MODULE_SELL,
        ED_EVENT_DATA_MODULE_SELL_REMOTE,
        ED_EVENT_DATA_MODULES_INFO,
        ED_EVENT_DATA_MODULE_STORE,
        ED_EVENT_DATA_MODULE_SWAP,
        ED_EVENT_DATA_MULTI_SELL_EXPLORATION_DATA,
        ED_EVENT_DATA_MUSIC,
        ED_EVENT_DATA_NAV_BEACON_SCAN,
        ED_EVENT_DATA_NAV_ROUTE,
        ED_EVENT_DATA_NEW_COMMANDER,
        ED_EVENT_DATA_NPC_CREW_PAID_WAGE,
        ED_EVENT_DATA_NPC_CREW_RANK,
        ED_EVENT_DATA_OUTFITTING,
        ED_EVENT_DATA_PASSENGERS,
        ED_EVENT_DATA_PAY_BOUNTIES,
        ED_EVENT_DATA_PAY_FINES,
        ED_EVENT_DATA_PAY_LEGACY_FINES,
        ED_EVENT_DATA_POWERPLAY_COLLECT,
        ED_EVENT_DATA_POWERPLAY_DEFECT,
        ED_EVENT_DATA_POWERPLAY_DELIVER,
        ED_EVENT_DATA_POWERPLAY,
        ED_EVENT_DATA_POWERPLAY_FAST_TRACK,
        ED_EVENT_DATA_POWERPLAY_JOIN,
        ED_EVENT_DATA_POWERPLAY_LEAVE,
        ED_EVENT_DATA_POWERPLAY_SALARY,
        ED_EVENT_DATA_POWERPLAY_VOTE,
        ED_EVENT_DATA_POWERPLAY_VOUCHER,
        ED_EVENT_DATA_PROGRESS,
        ED_EVENT_DATA_PROMOTION,
        ED_EVENT_DATA_PROSPECTED_ASTEROID,
        ED_EVENT_DATA_PVP_KILL,
        ED_EVENT_DATA_QUIT_A_CREW,
        ED_EVENT_DATA_RANK,
        ED_EVENT_DATA_REBOOT_REPAIR,
        ED_EVENT_DATA_RECEIVE_TEXT,
        ED_EVENT_DATA_REDEEM_VOUCHER,
        ED_EVENT_DATA_REFUEL_ALL,
        ED_EVENT_DATA_REFUEL_PARTIAL,
        ED_EVENT_DATA_RENAME_SUIT_LOADOUT,
        ED_EVENT_DATA_REPAIR_ALL,
        ED_EVENT_DATA_REPAIR_DRONE,
        ED_EVENT_DATA_REPAIR,
        ED_EVENT_DATA_REPUTATION,
        ED_EVENT_DATA_RESERVOIR_REPLENISHED,
        ED_EVENT_DATA_RESTOCK_VEHICLE,
        ED_EVENT_DATA_RESURRECT,
        ED_EVENT_DATA_ROUTE,
        ED_EVENT_DATA_SAA_SCAN_COMPLETE,
        ED_EVENT_DATA_SAA_SIGNALS_FOUND,
        ED_EVENT_DATA_SCAN,
        ED_EVENT_DATA_SCANNED,
        ED_EVENT_DATA_SCAN_ORGANIC,
        ED_EVENT_DATA_SCIENTIFIC_RESEARCH,
        ED_EVENT_DATA_SCREENSHOT,
        ED_EVENT_DATA_SEARCH_AND_RESCUE,
        ED_EVENT_DATA_SELF_DESTRUCT,
        ED_EVENT_DATA_SELL_DRONES,
        ED_EVENT_DATA_SELL_EXPLORATION_DATA,
        ED_EVENT_DATA_SELL_MICRO_RESOURCES,
        ED_EVENT_DATA_SELL_ORGANIC_DATA,
        ED_EVENT_DATA_SELL_SHIP_ON_REBUY,
        ED_EVENT_DATA_SELL_SUIT,
        ED_EVENT_DATA_SELL_WEAPON,
        ED_EVENT_DATA_SEND_TEXT,
        ED_EVENT_DATA_SET_USER_SHIP_NAME,
        ED_EVENT_DATA_SHARED_BOOKMARK_TO_SQUADRON,
        ED_EVENT_DATA_SHIELD_STATE,
        ED_EVENT_DATA_SHIP_LOCKER,
        ED_EVENT_DATA_SHIP_LOCKER_MATERIALS,
        ED_EVENT_DATA_SHIP_TARGETED,
        ED_EVENT_DATA_SHIPYARD_BUY,
        ED_EVENT_DATA_SHIPYARD,
        ED_EVENT_DATA_SHIPYARD_NEW,
        ED_EVENT_DATA_SHIPYARD_SELL,
        ED_EVENT_DATA_SHIPYARD_SWAP,
        ED_EVENT_DATA_SHIPYARD_TRANSFER,
        ED_EVENT_DATA_SHUTDOWN,
        ED_EVENT_DATA_SQUADRON_CREATED,
        ED_EVENT_DATA_SQUADRON_DEMOTION,
        ED_EVENT_DATA_SQUADRON_PROMOTION,
        ED_EVENT_DATA_SQUADRON_STARTUP,
        ED_EVENT_DATA_SRV_DESTROYED,
        ED_EVENT_DATA_START_JUMP,
        ED_EVENT_DATA_STATISTICS,
        ED_EVENT_DATA_STORED_MODULES,
        ED_EVENT_DATA_STORED_SHIPS,
        ED_EVENT_DATA_SUPERCRUISE_ENTRY,
        ED_EVENT_DATA_SUPERCRUISE_EXIT,
        ED_EVENT_DATA_SWITCH_SUIT_LOADOUT,
        ED_EVENT_DATA_SYNTHESIS,
        ED_EVENT_DATA_SYSTEMS_SHUTDOWN,
        ED_EVENT_DATA_TECHNOLOGY_BROKER,
        ED_EVENT_DATA_TOUCHDOWN,
        ED_EVENT_DATA_TRADE_MICRO_RESOURCES,
        ED_EVENT_DATA_TRANSFER_MICRO_RESOURCES,
        ED_EVENT_DATA_UNDER_ATTACK,
        ED_EVENT_DATA_UNDOCKED,
        ED_EVENT_DATA_UPGRADE_SUIT,
        ED_EVENT_DATA_UPGRADE_WEAPON,
        ED_EVENT_DATA_USE_CONSUMABLE,
        ED_EVENT_DATA_USS_DROP,
        ED_EVENT_DATA_VEHICLE_SWITCH,
        ED_EVENT_DATA_WING_ADD,
        ED_EVENT_DATA_WING_JOIN,
        ED_EVENT_DATA_WING_LEAVE,
        ED_EVENT_DATA_WON_A_TROPHY_FOR_SQUADRON,
    }
    
    public class VoiceActorsCollection
    {
        private List<VoiceActor> list_actors = null;
        private Panel PanelParent = null;
        public VoiceActorsCollection(Panel panelParent)
        {
            this.list_actors = new List<VoiceActor>();
            this.list_actors.Sort();
            this.PanelParent = panelParent;
            this.AddNewActor(this.list_actors.Count, "Алёна", "Alena");
            this.AddNewActor(this.list_actors.Count, "Филипп", "Filipp");
            this.list_actors.ElementAt(0).Used = true;
        }

        /// <summary>
        /// Возвращает список ассистентов
        /// </summary>
        /// <returns></returns>
        public List<VoiceActor> List() { return this.list_actors; }
        /// <summary>
        /// Возвращает количество ассистентов
        /// </summary>
        /// <returns></returns>
        public int Count() { return this.list_actors.Count; }
        /// <summary>
        /// Добавляет нового ассистента как ранее созданный объект VoiceActor
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        public bool AddNewActor(VoiceActor actor)
        {
            foreach(VoiceActor vactor in this.list_actors)
                if(vactor.Name.Display == actor.Name.Display || vactor.Name.Program == actor.Name.Program)
                    return false;
            actor.ID = this.list_actors.Count;
            actor.PrevID(this.list_actors.Count - 1);
            this.list_actors.Add(actor);
            return true;
        }
        /// <summary>
        /// Добавляет нового ассистента по указанному имени (отображаемому русскому и программному англ.)
        /// </summary>
        /// <param name="actor_name"></param>
        /// <param name="actor_program_name"></param>
        /// <returns></returns>
        public bool AddNewActor(int actorID, string actor_name, string actor_program_name)
        {
            VoiceActor actor = new VoiceActor(actorID, actor_name, actor_program_name, this.PanelParent);
            foreach(VoiceActor vactor in this.list_actors)
                if(vactor.Name.Display == actor_name || vactor.Name.Program == actor_program_name)
                    return false;
            actor.ID = actorID;
            actor.PrevID(actorID - 1);
            this.list_actors.Add(actor);
            return true;
        }

        /// <summary>
        /// Возвращает объект ассистента по индексу
        /// Если индекс меньше нуля - возвращает первого ассистента
        /// Если индекс больше общего количества - возвращает последнего
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public VoiceActor Actor(int index) 
        {
            return this.list_actors.ElementAt(index < 0 ? 0 : index > this.Count() - 1 ? this.Count() - 1 : index); 
        }
        /// <summary>
        /// Возвращает текущего установленного ассистента
        /// </summary>
        /// <returns></returns>
        public VoiceActor CurrentUsedActor()
        {
            foreach(VoiceActor actor in this.list_actors)
                if(actor.Used)
                    return actor;
            return null;
        }
        /// <summary>
        /// Возвращает ассистента по его отображаемому имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public VoiceActor ActorByDisplayName(string name)
        {
            foreach(VoiceActor actor in this.list_actors)
                if(actor.Name.Display == name)
                    return actor;
            return null;
        }
        /// <summary>
        /// Возвращает ассистента по его программному имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public VoiceActor ActorByProgramName(string name)
        {
            foreach(VoiceActor actor in this.list_actors)
                if(actor.Name.Program == name)
                    return actor;
            return null;
        }
    }
    
    /// <summary>
    /// Структура имён ассистента
    /// </summary>
    public struct ActorNames
    {
        public string  Display; // Отображаемое имя (рус)
        public string  Program; // Программное имя (англ)
    }
    /// <summary>
    /// Класс "Голосовой ассистент"
    /// </summary>
    public class VoiceActor
    {
        public  delegate void ActorHandler(string program_name, bool state);
        public  event       ActorHandler Notify;
        public  ActorNames  Name;
        public  bool        Used = false;
        public  int         ID = -1;
        private int         id_prev = -1;
        private string      sounds_data_path = "";
        private Panel       PanelParent = null;
        private SplitContainer Panel = null;
        private Label       Header = null;
        private Button      ButtonListen = null;
        private RadioButton ButtonSetActor = null;
        
        /// <summary>
        /// Конструктор без параметров.
        /// После создания объекта требуется установить отображаемое и программное имя,
        /// флаг использования, идентификаторы этого и предыдущего ассистента,
        /// а также дополнить путь к папке хранения звуковых файлов, и указать родительскую панель.
        /// </summary>
        public VoiceActor()
        {
            this.Name.Display = "";
            this.Name.Program = "";
            this.Used = false;
            this.ID = -1;
            this.id_prev = -1;
            this.sounds_data_path = Application.StartupPath + "\\Sounds\\";
        }
        /// <summary>
        /// Параметрический конструктор. 
        /// После создания объекта требуется установить флаг использования, идентификаторы этого и предыдущего ассистента.
        /// </summary>
        /// <param name="actor_name"></param>
        /// <param name="actor_program_name"></param>
        /// <param name="panelParent"></param>
        public VoiceActor(string actor_name, string actor_program_name, Panel panelParent)
        {
            this.Name.Display = actor_name;
            this.Name.Program = actor_program_name;
            this.Used = false;
            this.ID = -1;
            this.id_prev = -1;
            this.sounds_data_path = $"{Application.StartupPath}\\Sounds\\{actor_program_name}";
            this.PanelParent = panelParent;
        }
        /// <summary>
        /// Параметрический конструктор.
        /// После создания объекта требуется установить флаг использования, идентификаторы этого и предыдущего ассистента.
        /// </summary>
        /// <param name="actor_name"></param>
        /// <param name="folder_name"></param>
        /// <param name="actor_program_name"></param>
        /// <param name="panelParent"></param>
        public VoiceActor(string actor_name, string folder_name, string actor_program_name, Panel panelParent)
        {
            this.Name.Display = actor_name;
            this.Name.Program = actor_program_name;
            this.Used = false;
            this.ID = -1;
            this.id_prev = -1;
            this.sounds_data_path = $"{Application.StartupPath}\\Sounds\\{actor_program_name}";
            this.PanelParent = panelParent;
        }
        /// <summary>
        /// Параметрический конструктор.
        /// Все параметры и свойства задаются автоматически.
        /// </summary>
        /// <param name="actorID"></param>
        /// <param name="actor_name"></param>
        /// <param name="actor_program_name"></param>
        /// <param name="panelParent"></param>
        public VoiceActor(int actorID, string actor_name, string actor_program_name, Panel panelParent)
        {
            this.Name.Display = actor_name;
            this.Name.Program = actor_program_name;
            this.Used = false;
            this.ID = actorID;
            this.id_prev = actorID - 1;
            this.sounds_data_path = $"{Application.StartupPath}\\Sounds\\{actor_program_name}";
            this.PanelParent = panelParent;
            this.CreateControlPanel();
        }
        /// <summary>
        /// Создаёт панель управления
        /// </summary>
        /// <returns></returns>
        public bool CreateControlPanel()
        {
            if(PanelParent == null)
                return false;
            this.Panel = new SplitContainer();
            this.InitControlPanel();
            this.Header = new Label();
            this.InitHeader();
            this.ButtonListen = new Button();
            this.InitButtonListen();
            this.ButtonSetActor = new RadioButton();
            this.InitButtonSetActor();

            this.Panel.Show();
            this.Header.Show();
            this.ButtonListen.Show();
            this.ButtonSetActor.Show();
            return true;
        }
        /// <summary>
        /// Инициализация свойств панели управления
        /// </summary>
        private void InitControlPanel()
        {
            if(this.Panel == null)
                return;
            this.PanelParent.Controls.Add(this.Panel);
            this.Panel.Width = this.Panel.Parent.Width - 18;
            this.Panel.Height = 59;
            this.Panel.IsSplitterFixed = true;
            this.Panel.SplitterDistance = 217;
            this.Panel.SplitterWidth = 3;
            this.Panel.Location = new Point(10, (8 + this.ID * this.Panel.Height) + (this.ID == 0 ? 0 : 4));
            this.Panel.BackColor = Color.FromArgb(47, 49, 54);
            this.Panel.BorderStyle = BorderStyle.FixedSingle;
            this.Panel.ForeColor = Color.FromArgb(171, 171, 171);
            this.Panel.Panel1.BackColor = Color.FromArgb(47, 49, 54);
            this.Panel.Panel1.ForeColor = Color.FromArgb(171, 171, 171);
            this.Panel.Panel2.BackColor = Color.FromArgb(47, 49, 54);
            this.Panel.Panel2.ForeColor = Color.FromArgb(171, 171, 171);
        }
        /// <summary>
        /// Инициализация свойств заголовка панели управления (имя ассистента)
        /// </summary>
        private void InitHeader()
        {
            if(this.Header == null)
                return;
            this.Panel.Panel1.Controls.Add(this.Header);
            this.Header.Text = this.Description();
            this.Header.Location = new Point(5, 5);
            this.Header.Width = 113;
            this.Header.Height = 13;
            this.Header.AutoSize = true;
            this.Header.BackColor = Color.FromArgb(47, 49, 54);
            this.Header.ForeColor = Color.FromArgb(171, 171, 171);
            this.Header.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
        }
        /// <summary>
        /// Инициализация свойств кнопки "Прослушать" голос ассистента
        /// </summary>
        private void InitButtonListen()
        {
            if(this.ButtonListen == null)
                return;
            this.Panel.Panel1.Controls.Add(this.ButtonListen);
            this.ButtonListen.BackColor = Color.FromArgb(57, 59, 64);
            this.ButtonListen.ForeColor = Color.FromArgb(171, 171, 171);
            this.ButtonListen.Location = new Point(5, 24);
            this.ButtonListen.Width = 100;
            this.ButtonListen.Height = 26;
            this.ButtonListen.Text = "Прослушать";
            this.ButtonListen.TextAlign = ContentAlignment.MiddleCenter;
            this.ButtonListen.FlatStyle = FlatStyle.Flat;
            this.ButtonListen.FlatAppearance.BorderColor = Color.FromArgb(57, 59, 64);
            this.ButtonListen.FlatAppearance.BorderSize = 0;
            this.ButtonListen.FlatAppearance.MouseDownBackColor = Color.FromArgb(77, 79, 94);
            this.ButtonListen.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 69, 74);

            this.ButtonListen.Click += (s, e) =>
            {
                MessageBox.Show("Путь к папке звуков:\n" + this.sounds_data_path);
            };
        }
        /// <summary>
        /// Инициализация свойств кнопки "Установить" ассистента
        /// </summary>
        private void InitButtonSetActor()
        {
            if(this.ButtonSetActor == null)
                return;
            this.Panel.Panel1.Controls.Add(this.ButtonSetActor);
            this.ButtonSetActor.Appearance = Appearance.Button;
            this.ButtonSetActor.BackColor = Color.FromArgb(57, 59, 64);
            this.ButtonSetActor.ForeColor = Color.FromArgb(171, 171, 171);
            this.ButtonSetActor.Location = new Point(110, 24);
            this.ButtonSetActor.Width = 100;
            this.ButtonSetActor.Height = 26;
            this.ButtonSetActor.Text = "Установить";
            this.ButtonSetActor.TextAlign = ContentAlignment.MiddleCenter;
            this.ButtonSetActor.FlatStyle = FlatStyle.Flat;
            this.ButtonSetActor.FlatAppearance.BorderColor = Color.FromArgb(57, 59, 64);
            this.ButtonSetActor.FlatAppearance.BorderSize = 0;
            this.ButtonSetActor.FlatAppearance.CheckedBackColor = Color.FromArgb(57, 109, 64);
            this.ButtonSetActor.FlatAppearance.MouseDownBackColor = (!this.ButtonSetActor.Checked ? Color.FromArgb(77, 79, 94) : Color.FromArgb(77, 129, 84));
            this.ButtonSetActor.FlatAppearance.MouseOverBackColor = (!this.ButtonSetActor.Checked ? Color.FromArgb(67, 69, 74) : Color.FromArgb(67, 119, 74));
            this.ButtonSetActor.AutoCheck = false;

            /// <summary>
            /// Обработчик клика по кнопке
            /// </summary>
            this.ButtonSetActor.Click += (s, e) =>
            {
                this.ButtonSetActor.Checked = !this.ButtonSetActor.Checked;
                if(this.ButtonSetActor.Checked)
                {
                    this.SetON();
                    Notify?.Invoke(this.Name.Program, true);
                }
                else
                {
                    this.SetOFF();
                    Notify?.Invoke(this.Name.Program, false);
                }
            };

        }
        /// <summary>
        /// Установка состояния ассистента "Установлен" и свойств кнопки в этом состоянии
        /// </summary>
        public void SetON()
        {
            this.ButtonSetActor.FlatAppearance.MouseDownBackColor = Color.FromArgb(77, 129, 84);
            this.ButtonSetActor.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 119, 74);
            this.ButtonSetActor.Text = "Установлен";
            this.Used = true;
        }
        /// <summary>
        /// Установка состояния ассистента "Установить" и свойств кнопки в этом состоянии
        /// </summary>
        public void SetOFF()
        {
            this.ButtonSetActor.FlatAppearance.MouseDownBackColor = Color.FromArgb(77, 79, 94);
            this.ButtonSetActor.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 69, 74);
            this.ButtonSetActor.Text = "Установить";
            this.Used = false;
        }

        public void PrevID(int id)  { this.id_prev = id;                                }
        public int  PrevID()        { return this.id_prev;                              }
        public string Description() { return $"Ассистент: {this.Name.Display}";         }
        public int  PanelTop()      { return this.Panel.Location.Y;                     }
        public int  PanelBottom()   { return this.Panel.Location.Y + this.Panel.Height; }
        
        /// <summary>
        /// Создаёт сжатый gz-файл из wav-файла и сохраняет его в папку звуков ассистента
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="game_event"></param>
        private void CreateGZSound(string file_path, string event_name)
        {
            string gzName = GetEventFileName(event_name);
            using(FileStream fileIn = File.OpenRead($@"{file_path}.wav"))
            using(FileStream fileOut = File.Create($@"{this.sounds_data_path}\{this.GetEventFileName(event_name)}.gz"))
            using(GZipStream gz = new GZipStream(fileOut, CompressionLevel.Optimal))
                fileIn.CopyTo(gz);
        }

        // Проигрывает одиночный звуковой файл
        protected void Play(string event_name) 
        {
            using(MemoryStream fileOut = new MemoryStream(Properties.Resources.Alena_about))
            using(GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                new SoundPlayer(gz).Play();

            //var obj = Properties.Resources.ResourceManager.GetObject(GetEventFileName(event_name));
            //using(MemoryStream fileOut = new MemoryStream(Properties.Resources.Alena_about))
            //using(GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
            //    new SoundPlayer(gz).Play();
        }
        
        //value = Properties.Resources.ResourceManager.GetObject(GetResourceFileName(event_name, actor));
        private string GetEventFileName(string event_name)
        {
            string fileNameFormat = "{0}_{1}.gz";
            string fileName = string.Format(fileNameFormat, this.Name.Program, event_name);
            return fileName;
        }
    }
}

//Программа эскадрильи Вайп для оповещения пилотов о встреченных в космосе игроках. 
//Оповещает голосом об эскадре в которой состоит пилот и о сам+ом игроке, корабль которого находится в прицеле - 
//друг, враг, спир, зашкварщик или другой Бр+абен. Списки эскадр и пилотов, дружественных и враждебных 
//заносятся в базу данных администрацией эскадры Вайп, что исключает случайные или сомнительные убийства.


/*
"Послушник"
-----------------
TYPHOON) (Лёня)
+Vorobei+ (Валера)
-AgenT777- (Александр)
STALKER111 [Влад]
=BY=SNICKERS (Александр)
D.Lager
Abclex(Александр)
Aexxon (Антон)
Air 78 RUS (Кирилл)
Andrew Rais (Андрей)
Holmrand(Кирилл)
C4sssOWNER (Глебик)
Doping Net (Дмитрий)
CrazerAvrorA (Артем)
DeVOral(Николай)
Dias_Flack |Роман|
CMDR Dijerica (Арсений)
AbsturzDream
FighterJet (Андрей)
The_FuRiz (Саша)
Glebec (Глеб)
Gr2y82(Сергей)
SunstrikeFX (Андрей)
Kazerman (Коля)
Kotabuki (Влад)
Oleze(Олег)
Laegolasse
Rey Lynx (Андрей)
x_MAKCiM_x (Макс)
MemoRex_BLR
MotSarT (Руслан)
N.K.B.D
Sagittarius RUS (Кирилл)
Nimrad (Алексей)
Parus majer  Андрей Синица
Perfect_Sinner (грешный Андрій)
Poetiq (Толя)
sHaLoPaY (Влад)
Sonar/Jerkbait
SLA74
CMDR SOCRAT99 (Дмитрий)
Sanchez174(Саня)
Shtanishki (Миша)
Black_Angel(Иван)
Untraceab1e (Паша Трэйс)
VicPeTiv
VoDLight (Виталий)
Megalag(Андрей)
YadrenBaton (Ден)
[S]kY[N]ET  [Дмитрий]
DeH4uK (Денис)
digital_den_b (Дионисий)
Gvok (Юра)
Lerou_Game(Ильнар)
Mavir (Николай)
kucher9985(Anton)
m666rs(alex)
rohrick (Игорь)
syxapuk(Михаил)
XXEL (Ростислав)
KuiryoOne(Никита)
MallarWand (Артур)
Scrimer (Max)
MazzikKamazzik (Владимир)
[WIPE]Noldral(Ченан)


"Монах"
-----------------
-=Voyageur=-
9flyx[flyx]
Dementey (Дмитрий)
Asumaru
Cpt. Spirt (Иван)
DIKAPb(Александр)
DKey
DKey (Денис)
Evgenich (Женя)
F_E_N_I_K_S ( Сергей )
Faust-V (Виталий)
Grossgraf (Денис)
Jason Hill (Димон)
Jhonny K (Женя)
KAMA3OTXODOB(Михаил)
Kerastr (Миша)
Lagologo69 (Юрий)
Master ZenLee (Сергей UTC+7)
Michael Beryl
OptimYs (Валера)
PaToom (Паша)
Phantom Es0I
Призрак21 (Илья)
Rroman (Роман)
SPECTERsis (Ягайло)
SenzZzo
Serendypty (Илья)
Shevve(Саня)
SkyOne
Longade Horizon (Ярослав)
Thargoid
Ulairi (Саня)
Vadhrnt (Вадим)
AlexSever (Александр)
DiVits (Виктор)
Vladzimor(Владимир)
Vladyslav
Volkodav SR (Роман)
Warvolf (Вольфыч)
Westshot (Сергей)
Whisper00(Орест)
-WHITE-_(Антон)
dimmen
kirpichnikov_m
Konstantin Zalupa (Сергей)
Tankict_Zapasa (Игорь)
Vikarych (Дмитрий)
Михалыч1966
Михалыч1966 (Михаил)
𝐻𝑒𝓁𝓁𝓌𝑜𝓇𝓀𝑒𝓇(Лёха)

"Пастырь"
-----------------
DarkOui (Алексей)
DeQSer (святой Андрий)
Vlajni (Алексей)
E1St0rm (Денис)
Elite Tiger-UA (Виталик)
Kirtim (Василий) [WIPE]
Kosevich (Олег)
Luchezarny(Михаил)
Khetag Terrible (Хетаг)
Seasle (Саня/Шурик)
Vintir (Винтир)
Demetrixezz (Dimitris)
Aileen Leith (Илья)
eNmaXx (Max)
gromozeka 78
ISIN (Гоша)
kasaria (Алексей)
pahastik(Пахастик)
ruxa(Руслан)
𝕱𝖊𝖘𝖙𝖔𝖗 (святой Даний)
𝖆𝖗𝖙𝖊𝖒𝖜𝖆𝖞𝖓𝖊𝖘

"Аббат"
-----------------
AlexIE13 (Игорь)
DragoNext (Стас)
Satorio(Димас)
MadAbbe (Артем)
chechinskiy (Михаил)

"Архиепископ"
-----------------
Wild Priest (псевдоним = W|ld Priest)


*/
