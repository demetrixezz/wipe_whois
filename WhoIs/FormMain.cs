using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
//========================================================= добавляем юзинги 
using EliteJournalReader;
using EliteJournalReader.Events;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using CSCore;
using CSCore.SoundIn;
using CSCore.CoreAudioAPI;
using CSCore.Streams;
using CSCore.Streams.Effects;
using CSCore.SoundOut;
using CSCore.Codecs.WAV;

namespace WhoIs
{
    public partial class FormMain : FormBase
    {
        // Флаг успешной авторизации
        bool   Authorized;
        // PathToLogs - путь к папке логов программы
        string path;
        string PathToLogs => path ?? (path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Saved Games\Frontier Developments\Elite Dangerous\");

        // Экземпляры вотчера событий, игрока и голосового ассистента
        JournalWatcher          edWatcher = null;
        edPlayer                Player = null;
        VoiceActorsCollection   VoiceActors = null;
        
        public FormMain()
        {
            InitializeComponent();
            // Проверка уже запущенного экземпляра программы и выход если это второй
            if(!InstanceChecker.TakeMemory())
            {
                // интересно, как развернуть окно, если программа в трее?
                Process[] processes = Process.GetProcessesByName("WhoIs");
                if(processes.Length > 0)
                {
                    //MessageBox.Show("Length: "+processes.Length.ToString());
                }
                this.Close();
            }

            // Построение внешнего вида формы
            #region
            // Устанавливаем контролам формы (в заголовке) свойства перемещения
            new List<Control> { panelHeader, panelLogoWIPE, labelHeader }.ForEach(x =>
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
            buttonClose.Click += (s, e) => Close();
            buttonClose.MouseEnter += (s, e) => buttonClose.BackgroundImage = Properties.Resources.CrossCloseOver;
            buttonClose.MouseDown += (s, e) => buttonClose.BackgroundImage = Properties.Resources.CrossCloseDown;
            buttonClose.MouseLeave += (s, e) => buttonClose.BackgroundImage = Properties.Resources.CrossClose;

            buttonToTray.Click += (s, e) => { };
            buttonToTray.MouseEnter += (s, e) => buttonToTray.BackgroundImage = Properties.Resources.ToTrayOver;
            buttonToTray.MouseDown += (s, e) => buttonToTray.BackgroundImage = Properties.Resources.ToTrayDown;
            buttonToTray.MouseLeave += (s, e) => buttonToTray.BackgroundImage = Properties.Resources.ToTray;
            // Обработка событий мышки для всех текстовых меток панели главной формы (panelFormMain)
            foreach(Label lbl in panelFormMain.Controls.OfType<Label>())
            {
                lbl.MouseLeave += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
                lbl.MouseEnter += (s, a) => { lbl.ForeColor = Color.FromArgb(201, 201, 201); };
                lbl.MouseDown += (s, a) => { lbl.ForeColor = Color.FromArgb(221, 221, 221); };
                lbl.MouseUp += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
            }
            #endregion

            // Цвет контекстного меню и определение нового рендера
            #region
            contextMenuStrip.BackColor = Color.FromArgb(54, 57, 63);
            contextMenuStrip.ForeColor = Color.FromArgb(171, 171, 171);
            contextMenuStrip.Renderer = new CMSRenderer();
            #endregion
            #endregion

            // Панели авторизации, информации и настроек - координаты за пределами формы
            #region
            panelMenuAutorize.Location = new Point(panelMenuLeft.Location.X - panelMenuAutorize.Width, panelMenuLeft.Location.Y + 37);
            panelMenuAutorize.Hide();
            panelMenuInfoDB.Location = new Point(panelMenuLeft.Location.X - panelMenuInfoDB.Width, panelMenuLeft.Location.Y + 37);
            panelMenuInfoDB.Hide();
            panelMenuLeftPanelButtonSettings.Location = new Point(-panelMenuLeftPanelButtonSettings.Width, panelMenuLeftPanelButtonSettings.Location.Y);
            panelMenuLeftPanelButtonSettings.Hide();
            panelChoiceVoiceActor.Location = new Point(panelDataRight.Width, panelChoiceVoiceActor.Location.Y);
            panelChoiceVoiceActor.Hide();
            #endregion

            // Устанавливаем реакции на мышку контролам панелей авторизации и информации
            #region
            new List<Control> { panelLogin, labelLogin, textBoxLogin }.ForEach(x =>
            {
                x.MouseEnter += (s, e) => { labelLoginDescription.Text = "Логин должен совпадать с игровым"; };
            });
            new List<Control> { panelPass, labelPass, textBoxPass }.ForEach(x =>
            {
                x.MouseEnter += (s, e) => { labelLoginDescription.Text = "Пароль для входа в программу"; };
            });
            new List<Control> { buttonLogin, buttonInfoAdmin, buttonCheckRegistryData }.ForEach(x =>
            {
                x.MouseEnter += (s, e) => { labelLoginDescription.Text = "Данные будут проверены на сервере"; };
            });
            new List<Control> { panelLogin, labelLogin, textBoxLogin, panelPass, labelPass, textBoxPass, buttonLogin }.ForEach(x =>
            {
                x.MouseLeave += (s, e) => { labelLoginDescription.Text = ""; };
            });
            #endregion

            label2.Text = "";

            // Создаём коллекцию стандартных голосовых ассистентов
            VoiceActors = new VoiceActorsCollection();
            // Загружаем настройки программы из реестра
            SettingsLoad();
            // Создаём экземпляр класса игрока
            this.Player = new edPlayer();
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Инициализация вотчера ED-событий
            this.InitWatcher();
            // Авторизация в программе и базе данных
            this.Authorized = Authorization();
            this.WaitHistoryDone();
        }

        /// <summary>
        /// Инициализация вотчера ED-событий 
        /// </summary>
        private void InitWatcher()
        {
            // указываем вотчеру на папку с логами и подписываемся на его события
            this.edWatcher = new JournalWatcher(PathToLogs);
            this.edWatcher.Changed += Watcher_Changed;

            // Обработчики событий вотчера ED-событий 
            #region
            this.edWatcher.GetEvent<AfmuRepairsEvent>()?.AddHandler((s, e) => {
                new edEventAfmuRepairs(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<AppliedToSquadronEvent>()?.AddHandler((s, e) => {
                new edEventAppliedToSquadron(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ApproachBodyEvent>()?.AddHandler((s, e) => {
                new edEventApproachBody(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ApproachSettlementEvent>()?.AddHandler((s, e) => {
                new edEventApproachSettlement(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<AsteroidCrackedEvent>()?.AddHandler((s, e) => {
                new edEventAsteroidCracked(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<BackpackMaterialsEvent>()?.AddHandler((s, e) => {
                new edEventBackpackMaterials(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<BookDropshipEvent>()?.AddHandler((s, e) => {
                new edEventBookDropship(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<BookTaxiEvent>()?.AddHandler((s, e) => {
                new edEventBookTaxi(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<BountyEvent>()?.AddHandler((s, e) => {
                new edEventBounty(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<BuyAmmoEvent>()?.AddHandler((s, e) => {
                new edEventBuyAmmo(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<BuyDronesEvent>()?.AddHandler((s, e) => {
                new edEventBuyDrones(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<BuyExplorationDataEvent>()?.AddHandler((s, e) => {
                new edEventBuyExplorationData(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<BuyMicroResourcesEvent>()?.AddHandler((s, e) => {
                new edEventBuyMicroResources(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<BuySuitEvent>()?.AddHandler((s, e) => {
                new edEventBuySuit(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<BuyTradeDataEvent>()?.AddHandler((s, e) => {
                new edEventBuyTradeData(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<BuyWeaponEvent>()?.AddHandler((s, e) => {
                new edEventBuyWeapon(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CancelDropshipEvent>()?.AddHandler((s, e) => {
                new edEventCancelDropship(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CancelTaxiEvent>()?.AddHandler((s, e) => {
                new edEventCancelTaxi(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CapShipBondEvent>()?.AddHandler((s, e) => {
                new edEventCapShipBond(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CargoDepotEvent>()?.AddHandler((s, e) => {
                new edEventCargoDepot(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CargoEvent>()?.AddHandler((s, e) => {
                new edEventCargo(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CargoTransferEvent>()?.AddHandler((s, e) => {
                new edEventCargoTransfer(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierBankTransferEvent>()?.AddHandler((s, e) => {
                new edEventCarrierBankTransfer(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierBuyEvent>()?.AddHandler((s, e) => {
                new edEventCarrierBuy(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierCancelDecommissionEvent>()?.AddHandler((s, e) => {
                new edEventCarrierCancelDecommission(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierCrewServicesEvent>()?.AddHandler((s, e) => {
                new edEventCarrierCrewServices(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierDecommissionEvent>()?.AddHandler((s, e) => {
                new edEventCarrierDecommission(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierDepositFuelEvent>()?.AddHandler((s, e) => {
                new edEventCarrierDepositFuel(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierDockingPermissionEvent>()?.AddHandler((s, e) => {
                new edEventCarrierDockingPermission(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierFinanceEvent>()?.AddHandler((s, e) => {
                new edEventCarrierFinance(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierJumpCancelledEvent>()?.AddHandler((s, e) => {
                new edEventCarrierJumpCancelled(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierJumpEvent>()?.AddHandler((s, e) => {
                new edEventCarrierJump(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierJumpRequestEvent>()?.AddHandler((s, e) => {
                new edEventCarrierJumpRequest(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierModulePackEvent>()?.AddHandler((s, e) => {
                new edEventCarrierModulePack(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierNameChangedEvent>()?.AddHandler((s, e) => {
                new edEventCarrierNameChanged(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierShipPackEvent>()?.AddHandler((s, e) => {
                new edEventCarrierShipPack(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierStatsEvent>()?.AddHandler((s, e) => {
                new edEventCarrierStats(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CarrierTradeOrderEvent>()?.AddHandler((s, e) => {
                new edEventCarrierTradeOrder(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ChangeCrewRoleEvent>()?.AddHandler((s, e) => {
                new edEventChangeCrewRole(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ClearSavedGameEvent>()?.AddHandler((s, e) => {
                new edEventClearSavedGame(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CockpitBreachedEvent>()?.AddHandler((s, e) => {
                new edEventCockpitBreached(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CodexEntryEvent>()?.AddHandler((s, e) => {
                new edEventCodexEntry(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CollectCargoEvent>()?.AddHandler((s, e) => {
                new edEventCollectCargo(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CollectItemsEvent>()?.AddHandler((s, e) => {
                new edEventCollectItems(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CommanderEvent>()?.AddHandler((s, e) => {
                new edEventCommander(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CommitCrimeEvent>()?.AddHandler((s, e) => {
                new edEventCommitCrime(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CommunityGoalDiscardEvent>()?.AddHandler((s, e) => {
                new edEventCommunityGoalDiscard(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CommunityGoalEvent>()?.AddHandler((s, e) => {
                new edEventCommunityGoal(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CommunityGoalJoinEvent>()?.AddHandler((s, e) => {
                new edEventCommunityGoalJoin(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CommunityGoalRewardEvent>()?.AddHandler((s, e) => {
                new edEventCommunityGoalReward(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ContinuedEvent>()?.AddHandler((s, e) => {
                new edEventContinued(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CreateSuitLoadoutEvent>()?.AddHandler((s, e) => {
                new edEventCreateSuitLoadout(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CrewAssignEvent>()?.AddHandler((s, e) => {
                new edEventCrewAssign(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CrewFireEvent>()?.AddHandler((s, e) => {
                new edEventCrewFire(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CrewHireEvent>()?.AddHandler((s, e) => {
                new edEventCrewHire(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CrewLaunchFighterEvent>()?.AddHandler((s, e) => {
                new edEventCrewLaunchFighter(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CrewMemberJoinsEvent>()?.AddHandler((s, e) => {
                new edEventCrewMemberJoins(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CrewMemberQuitsEvent>()?.AddHandler((s, e) => {
                new edEventCrewMemberQuits(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CrewMemberRoleChangeEvent>()?.AddHandler((s, e) => {
                new edEventCrewMemberRoleChange(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<CrimeVictimEvent>()?.AddHandler((s, e) => {
                new edEventCrimeVictim(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DatalinkScanEvent>()?.AddHandler((s, e) => {
                new edEventDatalinkScan(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DatalinkVoucherEvent>()?.AddHandler((s, e) => {
                new edEventDatalinkVoucher(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DataScannedEvent>()?.AddHandler((s, e) => {
                new edEventDataScanned(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DeleteSuitLoadoutEvent>()?.AddHandler((s, e) => {
                new edEventDeleteSuitLoadout(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DiedEvent>()?.AddHandler((s, e) => {
                new edEventDied(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DisbandedSquadronEvent>()?.AddHandler((s, e) => {
                new edEventDisbandedSquadron(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DiscoveryScanEvent>()?.AddHandler((s, e) => {
                new edEventDiscoveryScan(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DisembarkEvent>()?.AddHandler((s, e) => {
                new edEventDisembark(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DockedEvent>()?.AddHandler((s, e) => {
                new edEventDocked(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DockFighterEvent>()?.AddHandler((s, e) => {
                new edEventDockFighter(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DockingCancelledEvent>()?.AddHandler((s, e) => {
                new edEventDockingCancelled(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DockingDeniedEvent>()?.AddHandler((s, e) => {
                new edEventDockingDenied(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DockingGrantedEvent>()?.AddHandler((s, e) => {
                new edEventDockingGranted(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DockingRequestedEvent>()?.AddHandler((s, e) => {
                new edEventDockingRequested(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DockingTimeoutEvent>()?.AddHandler((s, e) => {
                new edEventDockingTimeout(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DockSRVEvent>()?.AddHandler((s, e) => {
                new edEventDockSRV(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DropItemsEvent>()?.AddHandler((s, e) => {
                new edEventDropItems(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<DropShipDeployEvent>()?.AddHandler((s, e) => {
                new edEventDropShipDeploy(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<EjectCargoEvent>()?.AddHandler((s, e) => {
                new edEventEjectCargo(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<EmbarkEvent>()?.AddHandler((s, e) => {
                new edEventEmbark(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<EndCrewSessionEvent>()?.AddHandler((s, e) => {
                new edEventEndCrewSession(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<EngineerContributionEvent>()?.AddHandler((s, e) => {
                new edEventEngineerContribution(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<EngineerCraftEvent>()?.AddHandler((s, e) => {
                new edEventEngineerCraft(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<EngineerLegacyConvertEvent>()?.AddHandler((s, e) => {
                new edEventEngineerLegacyConvert(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<EngineerProgressEvent>()?.AddHandler((s, e) => {
                new edEventEngineerProgress(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<EscapeInterdictionEvent>()?.AddHandler((s, e) => {
                new edEventEscapeInterdiction(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FactionKillBondEvent>()?.AddHandler((s, e) => {
                new edEventFactionKillBond(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FetchRemoteModuleEvent>()?.AddHandler((s, e) => {
                new edEventFetchRemoteModule(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FighterDestroyedEvent>()?.AddHandler((s, e) => {
                new edEventFighterDestroyed(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FighterRebuiltEvent>()?.AddHandler((s, e) => {
                new edEventFighterRebuilt(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FileheaderEvent>()?.AddHandler((s, e) => {
                new edEventFileheader(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FriendsEvent>()?.AddHandler((s, e) => {
                new edEventFriends(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FSDJumpEvent>()?.AddHandler((s, e) => {
                new edEventFSDJump(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FSDTargetEvent>()?.AddHandler((s, e) => {
                new edEventFSDTarget(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FSSAllBodiesFoundEvent>()?.AddHandler((s, e) => {
                new edEventFSSAllBodiesFound(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FSSDiscoveryScanEvent>()?.AddHandler((s, e) => {
                new edEventFSSDiscoveryScan(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FSSSignalDiscoveredEvent>()?.AddHandler((s, e) => {
                new edEventFSSSignalDiscovered(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<FuelScoopEvent>()?.AddHandler((s, e) => {
                new edEventFuelScoop(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<HeatDamageEvent>()?.AddHandler((s, e) => {
                new edEventHeatDamage(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<HeatWarningEvent>()?.AddHandler((s, e) => {
                new edEventHeatWarning(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<HullDamageEvent>()?.AddHandler((s, e) => {
                new edEventHullDamage(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<InterdictedEvent>()?.AddHandler((s, e) => {
                new edEventInterdicted(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<InterdictionEvent>()?.AddHandler((s, e) => {
                new edEventInterdiction(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<InvitedToSquadronEvent>()?.AddHandler((s, e) => {
                new edEventInvitedToSquadron(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<JetConeBoostEvent>()?.AddHandler((s, e) => {
                new edEventJetConeBoost(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<JetConeDamageEvent>()?.AddHandler((s, e) => {
                new edEventJetConeDamage(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<JoinACrewEvent>()?.AddHandler((s, e) => {
                new edEventJoinACrew(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<JoinedSquadronEvent>()?.AddHandler((s, e) => {
                new edEventJoinedSquadron(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<KickCrewMemberEvent>()?.AddHandler((s, e) => {
                new edEventKickCrewMember(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<KickedFromSquadronEvent>()?.AddHandler((s, e) => {
                new edEventKickedFromSquadron(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<LaunchDroneEvent>()?.AddHandler((s, e) => {
                new edEventLaunchDrone(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<LaunchFighterEvent>()?.AddHandler((s, e) => {
                new edEventLaunchFighter(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<LaunchSRVEvent>()?.AddHandler((s, e) => {
                new edEventLaunchSRV(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<LeaveBodyEvent>()?.AddHandler((s, e) => {
                new edEventLeaveBody(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<LeftSquadronEvent>()?.AddHandler((s, e) => {
                new edEventLeftSquadron(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<LiftoffEvent>()?.AddHandler((s, e) => {
                new edEventLiftoff(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<LoadGameEvent>()?.AddHandler((s, e) => {
                new edEventLoadGame(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<LoadoutEquipModuleEvent>()?.AddHandler((s, e) => {
                new edEventLoadoutEquipModule(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<LoadoutEvent>()?.AddHandler((s, e) => {
                new edEventLoadout(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<LoadoutRemoveModuleEvent>()?.AddHandler((s, e) => {
                new edEventLoadoutRemoveModule(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<LocationEvent>()?.AddHandler((s, e) => {
                new edEventLocation(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MarketBuyEvent>()?.AddHandler((s, e) => {
                new edEventMarketBuy(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MarketEvent>()?.AddHandler((s, e) => {
                new edEventMarket(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MarketRefinedEvent>()?.AddHandler((s, e) => {
                new edEventMarketRefined(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MarketSellEvent>()?.AddHandler((s, e) => {
                new edEventMarketSell(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MassModuleStoreEvent>()?.AddHandler((s, e) => {
                new edEventMassModuleStore(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MaterialCollectedEvent>()?.AddHandler((s, e) => {
                new edEventMaterialCollected(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MaterialDiscardedEvent>()?.AddHandler((s, e) => {
                new edEventMaterialDiscarded(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MaterialDiscoveredEvent>()?.AddHandler((s, e) => {
                new edEventMaterialDiscovered(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MaterialsEvent>()?.AddHandler((s, e) => {
                new edEventMaterials(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MaterialTradeEvent>()?.AddHandler((s, e) => {
                new edEventMaterialTrade(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MiningRefinedEvent>()?.AddHandler((s, e) => {
                new edEventMiningRefined(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MissionAbandonedEvent>()?.AddHandler((s, e) => {
                new edEventMissionAbandoned(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MissionAcceptedEvent>()?.AddHandler((s, e) => {
                new edEventMissionAccepted(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MissionCompletedEvent>()?.AddHandler((s, e) => {
                new edEventMissionCompleted(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MissionFailedEvent>()?.AddHandler((s, e) => {
                new edEventMissionFailed(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MissionRedirectedEvent>()?.AddHandler((s, e) => {
                new edEventMissionRedirected(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MissionsEvent>()?.AddHandler((s, e) => {
                new edEventMissions(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ModuleBuyEvent>()?.AddHandler((s, e) => {
                new edEventModuleBuy(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ModuleInfoEvent>()?.AddHandler((s, e) => {
                new edEventModuleInfo(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ModuleRetrieveEvent>()?.AddHandler((s, e) => {
                new edEventModuleRetrieve(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ModuleSellEvent>()?.AddHandler((s, e) => {
                new edEventModuleSell(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ModuleSellRemoteEvent>()?.AddHandler((s, e) => {
                new edEventModuleSellRemote(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ModulesInfoEvent>()?.AddHandler((s, e) => {
                new edEventModulesInfo(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ModuleStoreEvent>()?.AddHandler((s, e) => {
                new edEventModuleStore(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ModuleSwapEvent>()?.AddHandler((s, e) => {
                new edEventModuleSwap(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MultiSellExplorationDataEvent>()?.AddHandler((s, e) => {
                new edEventMultiSellExplorationData(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<MusicEvent>()?.AddHandler((s, e) => {
                new edEventMusic(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<NavBeaconScanEvent>()?.AddHandler((s, e) => {
                new edEventNavBeaconScan(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<NavRouteEvent>()?.AddHandler((s, e) => {
                new edEventNavRoute(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<NewCommanderEvent>()?.AddHandler((s, e) => {
                new edEventNewCommander(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<NpcCrewPaidWageEvent>()?.AddHandler((s, e) => {
                new edEventNpcCrewPaidWage(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<NpcCrewRankEvent>()?.AddHandler((s, e) => {
                new edEventNpcCrewRank(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<OutfittingEvent>()?.AddHandler((s, e) => {
                new edEventOutfitting(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PassengersEvent>()?.AddHandler((s, e) => {
                new edEventPassengers(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PayBountiesEvent>()?.AddHandler((s, e) => {
                new edEventPayBounties(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PayFinesEvent>()?.AddHandler((s, e) => {
                new edEventPayFines(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PayLegacyFinesEvent>()?.AddHandler((s, e) => {
                new edEventPayLegacyFines(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PowerplayCollectEvent>()?.AddHandler((s, e) => {
                new edEventPowerplayCollect(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PowerplayDefectEvent>()?.AddHandler((s, e) => {
                new edEventPowerplayDefect(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PowerplayDeliverEvent>()?.AddHandler((s, e) => {
                new edEventPowerplayDeliver(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PowerplayEvent>()?.AddHandler((s, e) => {
                new edEventPowerplay(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PowerplayFastTrackEvent>()?.AddHandler((s, e) => {
                new edEventPowerplayFastTrack(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PowerplayJoinEvent>()?.AddHandler((s, e) => {
                new edEventPowerplayJoin(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PowerplayLeaveEvent>()?.AddHandler((s, e) => {
                new edEventPowerplayLeave(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PowerplaySalaryEvent>()?.AddHandler((s, e) => {
                new edEventPowerplaySalary(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PowerplayVoteEvent>()?.AddHandler((s, e) => {
                new edEventPowerplayVote(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PowerplayVoucherEvent>()?.AddHandler((s, e) => {
                new edEventPowerplayVoucher(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ProgressEvent>()?.AddHandler((s, e) => {
                new edEventProgress(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PromotionEvent>()?.AddHandler((s, e) => {
                new edEventPromotion(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ProspectedAsteroidEvent>()?.AddHandler((s, e) => {
                new edEventProspectedAsteroid(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<PVPKillEvent>()?.AddHandler((s, e) => {
                new edEventPVPKill(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<QuitACrewEvent>()?.AddHandler((s, e) => {
                new edEventQuitACrew(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<RankEvent>()?.AddHandler((s, e) => {
                new edEventRank(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<RebootRepairEvent>()?.AddHandler((s, e) => {
                new edEventRebootRepair(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ReceiveTextEvent>()?.AddHandler((s, e) => {
                new edEventReceiveText(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<RedeemVoucherEvent>()?.AddHandler((s, e) => {
                new edEventRedeemVoucher(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<RefuelAllEvent>()?.AddHandler((s, e) => {
                new edEventRefuelAll(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<RefuelPartialEvent>()?.AddHandler((s, e) => {
                new edEventRefuelPartial(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<RenameSuitLoadoutEvent>()?.AddHandler((s, e) => {
                new edEventRenameSuitLoadout(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<RepairAllEvent>()?.AddHandler((s, e) => {
                new edEventRepairAll(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<RepairDroneEvent>()?.AddHandler((s, e) => {
                new edEventRepairDrone(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<RepairEvent>()?.AddHandler((s, e) => {
                new edEventRepair(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ReputationEvent>()?.AddHandler((s, e) => {
                new edEventReputation(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ReservoirReplenishedEvent>()?.AddHandler((s, e) => {
                new edEventReservoirReplenished(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<RestockVehicleEvent>()?.AddHandler((s, e) => {
                new edEventRestockVehicle(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ResurrectEvent>()?.AddHandler((s, e) => {
                new edEventResurrect(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<RouteEvent>()?.AddHandler((s, e) => {
                new edEventRoute(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SAAScanCompleteEvent>()?.AddHandler((s, e) => {
                new edEventSAAScanComplete(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SAASignalsFoundEvent>()?.AddHandler((s, e) => {
                new edEventSAASignalsFound(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ScanEvent>()?.AddHandler((s, e) => {
                new edEventScan(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ScannedEvent>()?.AddHandler((s, e) => {
                new edEventScanned(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ScanOrganicEvent>()?.AddHandler((s, e) => {
                new edEventScanOrganic(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ScientificResearchEvent>()?.AddHandler((s, e) => {
                new edEventScientificResearch(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ScreenshotEvent>()?.AddHandler((s, e) => {
                new edEventScreenshot(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SearchAndRescueEvent>()?.AddHandler((s, e) => {
                new edEventSearchAndRescue(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SelfDestructEvent>()?.AddHandler((s, e) => {
                new edEventSelfDestruct(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SellDronesEvent>()?.AddHandler((s, e) => {
                new edEventSellDrones(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SellExplorationDataEvent>()?.AddHandler((s, e) => {
                new edEventSellExplorationData(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SellMicroResourcesEvent>()?.AddHandler((s, e) => {
                new edEventSellMicroResources(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SellOrganicDataEvent>()?.AddHandler((s, e) => {
                new edEventSellOrganicData(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SellShipOnRebuyEvent>()?.AddHandler((s, e) => {
                new edEventSellShipOnRebuy(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SellSuitEvent>()?.AddHandler((s, e) => {
                new edEventSellSuit(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SellWeaponEvent>()?.AddHandler((s, e) => {
                new edEventSellWeapon(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SendTextEvent>()?.AddHandler((s, e) => {
                new edEventSendText(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SetUserShipNameEvent>()?.AddHandler((s, e) => {
                new edEventSetUserShipName(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SharedBookmarkToSquadronEvent>()?.AddHandler((s, e) => {
                new edEventSharedBookmarkToSquadron(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ShieldStateEvent>()?.AddHandler((s, e) => {
                new edEventShieldState(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ShipLockerEvent>()?.AddHandler((s, e) => {
                new edEventShipLocker(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ShipLockerMaterialsEvent>()?.AddHandler((s, e) => {
                new edEventShipLockerMaterials(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ShipTargetedEvent>()?.AddHandler((s, e) => {
                new edEventShipTargeted(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ShipyardBuyEvent>()?.AddHandler((s, e) => {
                new edEventShipyardBuy(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ShipyardEvent>()?.AddHandler((s, e) => {
                new edEventShipyard(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ShipyardNewEvent>()?.AddHandler((s, e) => {
                new edEventShipyardNew(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ShipyardSellEvent>()?.AddHandler((s, e) => {
                new edEventShipyardSell(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ShipyardSwapEvent>()?.AddHandler((s, e) => {
                new edEventShipyardSwap(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ShipyardTransferEvent>()?.AddHandler((s, e) => {
                new edEventShipyardTransfer(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<ShutdownEvent>()?.AddHandler((s, e) => {
                new edEventShutdown(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SquadronCreatedEvent>()?.AddHandler((s, e) => {
                new edEventSquadronCreated(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SquadronDemotionEvent>()?.AddHandler((s, e) => {
                new edEventSquadronDemotion(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SquadronPromotionEvent>()?.AddHandler((s, e) => {
                new edEventSquadronPromotion(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SquadronStartupEvent>()?.AddHandler((s, e) => {
                new edEventSquadronStartup(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SRVDestroyedEvent>()?.AddHandler((s, e) => {
                new edEventSRVDestroyed(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<StartJumpEvent>()?.AddHandler((s, e) => {
                new edEventStartJump(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<StatisticsEvent>()?.AddHandler((s, e) => {
                new edEventStatistics(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<StoredModulesEvent>()?.AddHandler((s, e) => {
                new edEventStoredModules(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<StoredShipsEvent>()?.AddHandler((s, e) => {
                new edEventStoredShips(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SupercruiseEntryEvent>()?.AddHandler((s, e) => {
                new edEventSupercruiseEntry(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SupercruiseExitEvent>()?.AddHandler((s, e) => {
                new edEventSupercruiseExit(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SwitchSuitLoadoutEvent>()?.AddHandler((s, e) => {
                new edEventSwitchSuitLoadout(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SynthesisEvent>()?.AddHandler((s, e) => {
                new edEventSynthesis(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<SystemsShutdownEvent>()?.AddHandler((s, e) => {
                new edEventSystemsShutdown(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<TechnologyBrokerEvent>()?.AddHandler((s, e) => {
                new edEventTechnologyBroker(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<TouchdownEvent>()?.AddHandler((s, e) => {
                new edEventTouchdown(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<TradeMicroResourcesEvent>()?.AddHandler((s, e) => {
                new edEventTradeMicroResources(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<TransferMicroResourcesEvent>()?.AddHandler((s, e) => {
                new edEventTransferMicroResources(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<UnderAttackEvent>()?.AddHandler((s, e) => {
                new edEventUnderAttack(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<UndockedEvent>()?.AddHandler((s, e) => {
                new edEventUndocked(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<UpgradeSuitEvent>()?.AddHandler((s, e) => {
                new edEventUpgradeSuit(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<UpgradeWeaponEvent>()?.AddHandler((s, e) => {
                new edEventUpgradeWeapon(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<UseConsumableEvent>()?.AddHandler((s, e) => {
                new edEventUseConsumable(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<USSDropEvent>()?.AddHandler((s, e) => {
                new edEventUSSDrop(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<VehicleSwitchEvent>()?.AddHandler((s, e) => {
                new edEventVehicleSwitch(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<WingAddEvent>()?.AddHandler((s, e) => {
                new edEventWingAdd(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<WingJoinEvent>()?.AddHandler((s, e) => {
                new edEventWingJoin(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<WingLeaveEvent>()?.AddHandler((s, e) => {
                new edEventWingLeave(e, VoiceActors.CurrentUsedActor()).Process();
            });
            this.edWatcher.GetEvent<WonATrophyForSquadronEvent>()?.AddHandler((s, e) => {
                new edEventWonATrophyForSquadron(e, VoiceActors.CurrentUsedActor()).Process();
            });
            #endregion

            // стартуем вотчер ED-событий
            this.edWatcher.StartWatching();
        }

        /// <summary>
        /// Ожидание сигнала о завершении чтения и сохранения лог-файлов в список
        /// </summary>
        async public void WaitHistoryDone()
        {
            await Task.Run(async ()=>
            {
                while(!Player.HistoryCompleted)
                    await Task.Delay(500);
            });
            Player.HistoryCompleted = true;
            List<JournalHistoryEvent> list = Player.EventsList();
            foreach(JournalHistoryEvent evn in list)
            {
                //listBox1.Items.Add(evn.Description()/*+" File: "+evn.FileName()*/);
            }
        }

        // Метод обработки пилотов-игроков
        private void CheckPilot(string pilotName) 
        {
            
        }

        // Обработчик изменения лог-файла - факт произошедшего абстрактного события
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик закрытия программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //выключаем читалку логов и записываем параметры в реестр
            this.edWatcher.StopWatching();
            if(this.WindowState != FormWindowState.Minimized)
                SettingsSave();
            InstanceChecker.ReleaseMemory();
        }

        /// <summary>
        /// Запись параметров программы в реестр
        /// </summary>
        void SettingsSave()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                // Путь к папке логов и последние координаты окна программы
                RegKey.SetValue("LogFolderPath", PathToLogs, RegistryValueKind.String);
                RegKey.SetValue("FormLocationX", Location.X, RegistryValueKind.DWord);
                RegKey.SetValue("FormLocationY", Location.Y, RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// Загрузка параметров предыдущего запуска программы
        /// </summary>
        void SettingsLoad()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                int x = Convert.ToInt32(RegKey.GetValue("FormLocationX", 100));
                int y = Convert.ToInt32(RegKey.GetValue("FormLocationY", 100));
                this.Location = new Point(x, y);
            }
        }

        /// <summary>
        /// Сворачивание в трей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonToTray_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                NotifyIcon.Visible = true;
                NotifyIcon.ShowBalloonTip(1000);
            }
            else if(this.WindowState == FormWindowState.Normal)
            {
                NotifyIcon.Visible = false;
            }
        }

        /// <summary>
        /// Двойной клик по значку в трее (разворачиваем из трея)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            NotifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        // Контекстное меню программы в трее - пункт меню "Просмотреть списки"
        private void ToolStripMenuItemViewLists_Click(object sender, EventArgs e)
        {
            if(!Application.OpenForms.OfType<FormData>().Any())
                new FormData().Show();
        }

        // Контекстное меню программы в трее - пункт меню "Справка"
        private void ToolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            
        }

        // Контекстное меню программы в трее - пункт меню "О программе"
        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {

        }

        // Контекстное меню программы в трее - пункт меню "Закрыть"
        private void ToolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Возвращает последний файл в папке логов игры по фильтру ("*log" == лог-файл)
        public FileInfo GetLatestJournalFile(string searchPattern)
            {
            DirectoryInfo LogDirectory = new DirectoryInfo(PathToLogs);
            return LogDirectory.GetFiles(searchPattern).OrderByDescending(f => f.LastWriteTime).First();
            }

        // Закрашивает форму
        public void FormPaint(Color color1, Color color2, Color color3, Color color4)
        {
            void OnPaintEventHandler(object s, PaintEventArgs e)
            {
                if(ClientRectangle == Rectangle.Empty)
                    return;
                var lgb = new LinearGradientBrush(ClientRectangle, Color.Empty, Color.Empty, 90);
                var cblend = new ColorBlend { Colors = new[] { color1, color1, color2, color3 }, Positions = new[] { 0, 0.07f, 0.075f, 1} };

                lgb.InterpolationColors = cblend;
                e.Graphics.FillRectangle(lgb, ClientRectangle);
            }
            Paint -= OnPaintEventHandler;
            Paint += OnPaintEventHandler;
            Invalidate();
        }

        // Новый рендерер контекстного меню
        class CMSRenderer : ToolStripProfessionalRenderer
        {
            public CMSRenderer() : base(new CMSColors()) { }
        }
        class CMSColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(64, 67, 73);
            public override Color MenuItemBorder => Color.FromArgb(56, 59, 65);
        }

        // Внешний вид и поведение текстовой метки
        public static class ControlView
        {
            public static void Normal(Label lbl, string text="")
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
    
        // Клик по кнопке "Войти в программу"
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            RegistryData.SaveRegistrationData(textBoxLogin.Text, textBoxPass.Text);
            Authorization();
        }

        // Клик по кнопке "Проверить"
        private void ButtonCheckRegistryData_Click(object sender, EventArgs e)
        {
            // Скрываем информационную панель базы данных
            if(panelMenuInfoDB.Location.X >= panelMenuLeft.Location.X)
                HidePanel(panelMenuInfoDB, 8);
            // Показываем панель авторизации
            if(panelMenuAutorize.Location.X < panelMenuLeft.Location.X)
                ShowPanel(panelMenuAutorize, 4);
            ControlView.Warning(labelStatus, "Требуется авторизация!");
        }

        // Клик по кнопке "Сообщить"
        private void ButtonInfoAdmin_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.com/channels/742092065705558046/763418573879246849");
        }

        /// <summary>
        /// Клик по кнопке "Настройки" левого меню формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMenuLeftSettings_Click(object sender, EventArgs e)
        {
            if(panelMenuLeftPanelButtonSettings.Location.X < 0)
                SlidePanel(panelMenuLeftPanelButtonSettings, 4, 0, ENUM_SLIDE_MODE.SLIDE_MODE_RIGHT, ENUM_VISIBLE_CONTROL.VISIBLE_BEFORE);
            else
                SlidePanel(panelMenuLeftPanelButtonSettings, 8, -panelMenuLeftPanelButtonSettings.Width, ENUM_SLIDE_MODE.SLIDE_MODE_LEFT, ENUM_VISIBLE_CONTROL.UNVISIBLE_AFTER);
        }

        private void ButtonPanelMenuLeftPanelButtonSettingsActors_Click(object sender, EventArgs e)
        {
            if(panelChoiceVoiceActor.Location.X > 0)
                SlidePanel(panelChoiceVoiceActor, 4, 0, ENUM_SLIDE_MODE.SLIDE_MODE_LEFT, ENUM_VISIBLE_CONTROL.VISIBLE_BEFORE);
            else
                SlidePanel(panelChoiceVoiceActor, 8, panelDataRight.Width, ENUM_SLIDE_MODE.SLIDE_MODE_RIGHT, ENUM_VISIBLE_CONTROL.UNVISIBLE_AFTER);
        }

        // Авторизация в программе
        private bool Authorization()
        {
            // Загружаем рагистрационные данные из реестра и вписываем их в поля ввода
            RegistryData.LoadRegistrationData();
            textBoxLogin.Text = RegistryData.Login();
            textBoxPass.Text = RegistryData.Password();
            // Кнопка входа неактивна пока не введены данные в поля
            SetButtonLoginState();
            // Если нет логина или пароля в реестре -
            if(RegistryData.Login()=="" || RegistryData.Password() == "" || RegistryData.Login() == null || RegistryData.Password() == null)
            {
                // Делаем неактивными кнопки администрирования и просмотра данных ДБ и смещаем панель с кнопками вниз
                buttonMenuLeftAdministrations.Enabled = false;
                buttonMenuLeftViewDatas.Enabled = false;
                SlidePanel(panelMenuLeftPanelButtons, 8, panelMenuAutorize.Location.Y + panelMenuAutorize.Height, ENUM_SLIDE_MODE.SLIDE_MODE_DOWN,ENUM_VISIBLE_CONTROL.VISIBLE_CONTROL_DISABLE);
                // Выводим панель заполнения формы регистрации
                if(panelMenuAutorize.Location.X < panelMenuLeft.Location.X)
                    ShowPanel(panelMenuAutorize, 4);
                ControlView.Warning(labelStatus, "Требуется авторизация!");
                this.Authorized = false;
                if(textBoxLogin.Text == "")
                {
                    textBoxLogin.Focus();
                    textBoxLogin.SelectionStart = textBoxLogin.Text.Length;
                }
                else if(textBoxPass.Text == "")
                {
                    textBoxPass.Focus();
                    textBoxPass.SelectionStart = textBoxPass.Text.Length;
                }
                return false;
            }
            // Если в реестре есть логин и пароль -
            // проверим их по базе данных
            else
            {
                // Если нет связи с базой
                if(!RegistryData.CheckConnectionOnDB())
                {
                    // Делаем неактивными кнопки администрирования и просмотра данных ДБ и смещаем панель с кнопками вниз
                    buttonMenuLeftAdministrations.Enabled = false;
                    buttonMenuLeftViewDatas.Enabled = false;
                    SlidePanel(panelMenuLeftPanelButtons, 8, panelMenuAutorize.Location.Y + panelMenuAutorize.Height, ENUM_SLIDE_MODE.SLIDE_MODE_DOWN,ENUM_VISIBLE_CONTROL.VISIBLE_CONTROL_DISABLE);
                    // Выводим панель заполнения формы регистрации
                    if(panelMenuAutorize.Location.X < panelMenuLeft.Location.X)
                        ShowPanel(panelMenuAutorize, 4);
                    ControlView.Warning(labelStatus, "Нет связи с базой данных");
                    this.Authorized = false;
                    return false;
                }
                // Если логина или пароля нет в базе, или они не совпадают с базой
                if(!RegistryData.CheckLoginInDB() || !RegistryData.CheckPasswordInDB())
                {
                    // Делаем неактивными кнопки администрирования и просмотра данных ДБ и смещаем панель с кнопками вниз
                    buttonMenuLeftAdministrations.Enabled = false;
                    buttonMenuLeftViewDatas.Enabled = false;
                    SlidePanel(panelMenuLeftPanelButtons, 8, panelMenuAutorize.Location.Y + panelMenuAutorize.Height, ENUM_SLIDE_MODE.SLIDE_MODE_DOWN,ENUM_VISIBLE_CONTROL.VISIBLE_CONTROL_DISABLE);
                    // Скрываем панель авторизации
                    if(panelMenuAutorize.Location.X >= panelMenuLeft.Location.X)
                        HidePanel(panelMenuAutorize, 8);
                    // Показываем информационную панель базы данных
                    if(panelMenuInfoDB.Location.X < panelMenuLeft.Location.X)
                        ShowPanel(panelMenuInfoDB, 4);
                    ControlView.Warning(labelStatus);
                    labelStatus.Text = 
                        !RegistryData.CheckLoginInDB() ? $"Пилот {RegistryData.Login()} отсутствует в базе данных" :
                        $"Не правильный пароль для {RegistryData.Login()}";
                    this.Authorized = false;
                    return false;
                }
                // Если логин и пароль совпадают с базой данных -
                // скрываем все панели и продолжаем работу с программой
                else
                {
                    if(panelMenuInfoDB.Location.X >= panelMenuLeft.Location.X)
                        HidePanel(panelMenuInfoDB, 8);
                    if(panelMenuAutorize.Location.X >= panelMenuLeft.Location.X)
                        HidePanel(panelMenuAutorize, 8);
                    ControlView.Normal(labelStatus, $"Авторизовано для \"{RegistryData.Login()}\"");
                    this.Authorized = true;
                    this.Player.PilotCurrent = RegistryData.Login();
                    this.Player.History(PathToLogs);
                    this.Player.IsAdmin = RegistryData.CheckIsAdmin();
                    // Делаем активными кнопки администрирования и просмотра данных ДБ и смещаем панель с кнопками вверх
                    buttonMenuLeftAdministrations.Enabled = Player.IsAdmin ? true : false;
                    buttonMenuLeftViewDatas.Enabled = true;
                    SlidePanel(panelMenuLeftPanelButtons, 8, 0, ENUM_SLIDE_MODE.SLIDE_MODE_UP,ENUM_VISIBLE_CONTROL.VISIBLE_CONTROL_DISABLE);
                    return true;
                }
            }
        }

        /// <summary>
        /// Перечисление направлений смещения панелей
        /// </summary>
        enum ENUM_SLIDE_MODE
        {
            SLIDE_MODE_UP,
            SLIDE_MODE_DOWN,
            SLIDE_MODE_LEFT,
            SLIDE_MODE_RIGHT,
        }

        /// <summary>
        /// Перечисление флагов, указывающих на момент скрытия/отображения панели
        /// </summary>
        enum ENUM_VISIBLE_CONTROL
        {
            VISIBLE_CONTROL_DISABLE,
            VISIBLE_BEFORE,
            VISIBLE_AFTER,
            UNVISIBLE_BEFORE,
            UNVISIBLE_AFTER,
        }

        /// <summary>
        /// Смещает панель в указанное положение в заданном направлении
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="slowdown"></param>
        /// <param name="destination"></param>
        /// <param name="slide_mode"></param>
        private async void SlidePanel(Panel panel, int slowdown, int destination, ENUM_SLIDE_MODE slide_mode, ENUM_VISIBLE_CONTROL visible_control)
        {
            switch(slide_mode)
            {
                case ENUM_SLIDE_MODE.SLIDE_MODE_UP:
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_BEFORE)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_BEFORE)
                    panel.Hide();
                while(panel.Location.Y > destination)
                {
                    await Task.Delay(1);
                    panel.Location = new Point(panel.Location.X, panel.Location.Y -
                        (Math.Abs(panel.Location.Y - destination) / slowdown > 0 ?
                         Math.Abs(panel.Location.Y - destination) / slowdown : 1));
                }
                if(panel.Location.Y != destination)
                    panel.Location = new Point(panel.Location.X, destination);
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_AFTER)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_AFTER)
                    panel.Hide();
                break;
                
                case ENUM_SLIDE_MODE.SLIDE_MODE_DOWN:
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_BEFORE)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_BEFORE)
                    panel.Hide();
                while(panel.Location.Y < destination)
                {
                    await Task.Delay(1);
                    panel.Location = new Point(panel.Location.X, panel.Location.Y +
                        (Math.Abs(destination - panel.Location.Y) / slowdown > 0 ?
                         Math.Abs(destination - panel.Location.Y) / slowdown : 1));
                }
                if(panel.Location.Y != destination)
                    panel.Location = new Point(panel.Location.X, destination);
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_AFTER)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_AFTER)
                    panel.Hide();
                break;

                case ENUM_SLIDE_MODE.SLIDE_MODE_LEFT:
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_BEFORE)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_BEFORE)
                    panel.Hide();
                while(panel.Location.X >= destination)
                {
                    await Task.Delay(1);
                    panel.Location = new Point(panel.Location.X -
                        ((Math.Abs(panel.Location.X - destination)) / slowdown > 0 ?
                         (Math.Abs(panel.Location.X - destination)) / slowdown : 1), panel.Location.Y);
                }
                if(panel.Location.X != destination)
                    panel.Location = new Point(destination, panel.Location.Y);
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_AFTER)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_AFTER)
                    panel.Hide();
                break;

                case ENUM_SLIDE_MODE.SLIDE_MODE_RIGHT:
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_BEFORE)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_BEFORE)
                    panel.Hide();
                while(panel.Location.X < destination)
                {
                    await Task.Delay(1);
                    panel.Location = new Point(panel.Location.X +
                        (Math.Abs(destination - panel.Location.X) / slowdown > 0 ?
                         Math.Abs(destination - panel.Location.X) / slowdown : 1), panel.Location.Y);
                }
                if(panel.Location.X != destination)
                    panel.Location = new Point(destination, panel.Location.Y);
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_AFTER)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_AFTER)
                    panel.Hide();
                break;

                default:
                break;
            }
        }

        // Показывает панель
        private async void ShowPanel(Panel panel, int slowdown)
        {
            if(panel.Location.X < panel.Parent.Location.X)
                panel.Show();
            while(panel.Location.X < panel.Parent.Location.X)
            {
                await Task.Delay(1);
                panel.Location = new Point(panel.Location.X + 
                    (Math.Abs(panel.Location.X) / slowdown > 0 ? 
                     Math.Abs(panel.Location.X) / slowdown : 1), panel.Location.Y);
            }
            if(panel.Location.X != panel.Parent.Location.X)
                panel.Location = new Point(panel.Parent.Location.X, panel.Location.Y);
        }

        // Скрывает панель
        private async void HidePanel(Panel panel, int slowdown)
        {
            while(panel.Location.X >= panel.Parent.Location.X - panel.Width)
            {
                await Task.Delay(1);
                panel.Location = new Point(panel.Location.X -
                    ((panel.Width - Math.Abs(panel.Location.X)) / slowdown > 0 ? 
                     (panel.Width - Math.Abs(panel.Location.X)) / slowdown : 1), panel.Location.Y);
            }
            if(panel.Location.X != panel.Parent.Location.X - panel.Width)
                panel.Location = new Point(panel.Parent.Location.X - panel.Width, panel.Location.Y);
            panel.Hide();
        }

        // Состояние кнопки входа в зависимости от состояния полей ввода логина и пароля
        #region
        private void SetButtonLoginState()
        {
            buttonLogin.Enabled = (textBoxLogin.Text.Length > 2 && textBoxPass.Text.Length > 3 ? true : false);
        }
        private void TextBoxLogin_TextChanged(object sender, EventArgs e)
        {
            SetButtonLoginState();
        }
        private void TextBoxPass_TextChanged(object sender, EventArgs e)
        {
            SetButtonLoginState();
        }
        #endregion

        /// <summary>
        /// Щелчок по кнопке "Данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMenuLeftViewDatas_Click(object sender, EventArgs e)
        {
            if(!Application.OpenForms.OfType<FormData>().Any())
                new FormData().Show();
        }

        // Для упаковки звуков
        private void button1_Click(object sender, EventArgs e)
        {
            string text="";
            foreach(VoiceActor actor in VoiceActors.List())
            {
                text += actor.Name.Display + " " + actor.Name.Program + "\n";
            }
            MessageBox.Show(text + "\n");
       }

        private void Button3_Click(object sender, EventArgs e)
        {
            //string fileContent = string.Empty;
            //string filePath = string.Empty;
            //using(OpenFileDialog ofd = new OpenFileDialog())
            //{
            //    ofd.InitialDirectory = @"C:\Users\artme\OneDrive\Рабочий стол\Для Whois\Звуки";
            //    ofd.Filter = "wav-файлы (*.wav)|*.wav|Все файлы (*.*)|*.*";
            //    ofd.FilterIndex = 1;
            //    ofd.RestoreDirectory = true;
            //    if(ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        filePath = ofd.FileName;
            //        MessageBox.Show(filePath);
            //    }
            //}
        }
    }
}
