using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteJournalReader;
using static EliteJournalReader.Events.AfmuRepairsEvent;
using static EliteJournalReader.Events.AppliedToSquadronEvent;
using static EliteJournalReader.Events.ApproachBodyEvent;
using static EliteJournalReader.Events.ApproachSettlementEvent;
using static EliteJournalReader.Events.AsteroidCrackedEvent;
using static EliteJournalReader.Events.BackpackMaterialsEvent;
using static EliteJournalReader.Events.BookDropshipEvent;
using static EliteJournalReader.Events.BookTaxiEvent;
using static EliteJournalReader.Events.BountyEvent;
using static EliteJournalReader.Events.BountyEvent.BountyEventArgs;
using static EliteJournalReader.Events.BuyAmmoEvent;
using static EliteJournalReader.Events.BuyDronesEvent;
using static EliteJournalReader.Events.BuyExplorationDataEvent;
using static EliteJournalReader.Events.BuyMicroResourcesEvent;
using static EliteJournalReader.Events.BuySuitEvent;
using static EliteJournalReader.Events.BuyTradeDataEvent;
using static EliteJournalReader.Events.BuyWeaponEvent;
using static EliteJournalReader.Events.CancelDropshipEvent;
using static EliteJournalReader.Events.CancelTaxiEvent;
using static EliteJournalReader.Events.CapShipBondEvent;
using static EliteJournalReader.Events.CargoDepotEvent;
using static EliteJournalReader.Events.CargoEvent;
using static EliteJournalReader.Events.CarrierBankTransferEvent;
using static EliteJournalReader.Events.CarrierBuyEvent;
using static EliteJournalReader.Events.CarrierCancelDecommissionEvent;
using static EliteJournalReader.Events.CarrierCrewServicesEvent;
using static EliteJournalReader.Events.CarrierDecommissionEvent;
using static EliteJournalReader.Events.CarrierDepositFuelEvent;
using static EliteJournalReader.Events.CarrierDockingPermissionEvent;
using static EliteJournalReader.Events.CarrierFinanceEvent;
using static EliteJournalReader.Events.CarrierJumpCancelledEvent;
using static EliteJournalReader.Events.CarrierJumpEvent;
using static EliteJournalReader.Events.CarrierJumpRequestEvent;
using static EliteJournalReader.Events.CarrierModulePackEvent;
using static EliteJournalReader.Events.CarrierNameChangedEvent;
using static EliteJournalReader.Events.CarrierShipPackEvent;
using static EliteJournalReader.Events.CarrierStatsEvent;
using static EliteJournalReader.Events.CarrierTradeOrderEvent;
using static EliteJournalReader.Events.ChangeCrewRoleEvent;
using static EliteJournalReader.Events.ClearSavedGameEvent;
using static EliteJournalReader.Events.CockpitBreachedEvent;
using static EliteJournalReader.Events.CodexEntryEvent;
using static EliteJournalReader.Events.CollectCargoEvent;
using static EliteJournalReader.Events.CollectItemsEvent;
using static EliteJournalReader.Events.CommanderEvent;
using static EliteJournalReader.Events.CommitCrimeEvent;
using static EliteJournalReader.Events.CommunityGoalDiscardEvent;
using static EliteJournalReader.Events.CommunityGoalEvent;
using static EliteJournalReader.Events.CommunityGoalEvent.CommunityGoalEventArgs;
using static EliteJournalReader.Events.CommunityGoalJoinEvent;
using static EliteJournalReader.Events.CommunityGoalRewardEvent;
using static EliteJournalReader.Events.ContinuedEvent;
using static EliteJournalReader.Events.CreateSuitLoadoutEvent;
using static EliteJournalReader.Events.CrewAssignEvent;
using static EliteJournalReader.Events.CrewFireEvent;
using static EliteJournalReader.Events.CrewHireEvent;
using static EliteJournalReader.Events.CrewLaunchFighterEvent;
using static EliteJournalReader.Events.CrewMemberJoinsEvent;
using static EliteJournalReader.Events.CrewMemberQuitsEvent;
using static EliteJournalReader.Events.CrewMemberRoleChangeEvent;
using static EliteJournalReader.Events.CrimeVictimEvent;
using static EliteJournalReader.Events.DatalinkScanEvent;
using static EliteJournalReader.Events.DatalinkVoucherEvent;
using static EliteJournalReader.Events.DataScannedEvent;
using static EliteJournalReader.Events.DeleteSuitLoadoutEvent;
using static EliteJournalReader.Events.DiedEvent;
using static EliteJournalReader.Events.DiedEvent.DiedEventArgs;
using static EliteJournalReader.Events.DisbandedSquadronEvent;
using static EliteJournalReader.Events.DiscoveryScanEvent;
using static EliteJournalReader.Events.DisembarkEvent;
using static EliteJournalReader.Events.DockedEvent;
using static EliteJournalReader.Events.DockFighterEvent;
using static EliteJournalReader.Events.DockingCancelledEvent;
using static EliteJournalReader.Events.DockingDeniedEvent;
using static EliteJournalReader.Events.DockingGrantedEvent;
using static EliteJournalReader.Events.DockingRequestedEvent;
using static EliteJournalReader.Events.DockingTimeoutEvent;
using static EliteJournalReader.Events.DockSRVEvent;
using static EliteJournalReader.Events.DropItemsEvent;
using static EliteJournalReader.Events.DropShipDeployEvent;
using static EliteJournalReader.Events.EjectCargoEvent;
using static EliteJournalReader.Events.EmbarkEvent;
using static EliteJournalReader.Events.EndCrewSessionEvent;
using static EliteJournalReader.Events.EngineerContributionEvent;
using static EliteJournalReader.Events.EngineerCraftEvent;
using static EliteJournalReader.Events.EngineerLegacyConvertEvent;
using static EliteJournalReader.Events.EngineerProgressEvent;
using static EliteJournalReader.Events.EscapeInterdictionEvent;
using static EliteJournalReader.Events.FactionKillBondEvent;
using static EliteJournalReader.Events.FetchRemoteModuleEvent;
using static EliteJournalReader.Events.FighterDestroyedEvent;
using static EliteJournalReader.Events.FighterRebuiltEvent;
using static EliteJournalReader.Events.FileheaderEvent;
using static EliteJournalReader.Events.FriendsEvent;
using static EliteJournalReader.Events.FSDJumpEvent;
using static EliteJournalReader.Events.FSDTargetEvent;
using static EliteJournalReader.Events.FSSAllBodiesFoundEvent;
using static EliteJournalReader.Events.FSSDiscoveryScanEvent;
using static EliteJournalReader.Events.FSSSignalDiscoveredEvent;
using static EliteJournalReader.Events.FuelScoopEvent;
using static EliteJournalReader.Events.HeatDamageEvent;
using static EliteJournalReader.Events.HeatWarningEvent;
using static EliteJournalReader.Events.HullDamageEvent;
using static EliteJournalReader.Events.InterdictedEvent;
using static EliteJournalReader.Events.InterdictionEvent;
using static EliteJournalReader.Events.InvitedToSquadronEvent;
using static EliteJournalReader.Events.IsLiveEvent;
using static EliteJournalReader.Events.JetConeBoostEvent;
using static EliteJournalReader.Events.JetConeDamageEvent;
using static EliteJournalReader.Events.JoinACrewEvent;
using static EliteJournalReader.Events.JoinedSquadronEvent;
using static EliteJournalReader.Events.KickCrewMemberEvent;
using static EliteJournalReader.Events.KickedFromSquadronEvent;
using static EliteJournalReader.Events.LaunchDroneEvent;
using static EliteJournalReader.Events.LaunchFighterEvent;
using static EliteJournalReader.Events.LaunchSRVEvent;
using static EliteJournalReader.Events.LeaveBodyEvent;
using static EliteJournalReader.Events.LeftSquadronEvent;
using static EliteJournalReader.Events.LiftoffEvent;
using static EliteJournalReader.Events.LoadGameEvent;
using static EliteJournalReader.Events.LoadoutEquipModuleEvent;
using static EliteJournalReader.Events.LoadoutEvent;
using static EliteJournalReader.Events.LoadoutRemoveModuleEvent;
using static EliteJournalReader.Events.LocationEvent;
using static EliteJournalReader.Events.MarketBuyEvent;
using static EliteJournalReader.Events.MarketEvent;
using static EliteJournalReader.Events.MarketRefinedEvent;
using static EliteJournalReader.Events.MarketSellEvent;
using static EliteJournalReader.Events.MassModuleStoreEvent;
using static EliteJournalReader.Events.MaterialCollectedEvent;
using static EliteJournalReader.Events.MaterialDiscardedEvent;
using static EliteJournalReader.Events.MaterialDiscoveredEvent;
using static EliteJournalReader.Events.MaterialsEvent;
using static EliteJournalReader.Events.MaterialTradeEvent;
using static EliteJournalReader.Events.MiningRefinedEvent;
using static EliteJournalReader.Events.MissionAbandonedEvent;
using static EliteJournalReader.Events.MissionAcceptedEvent;
using static EliteJournalReader.Events.MissionCompletedEvent;
using static EliteJournalReader.Events.MissionFailedEvent;
using static EliteJournalReader.Events.MissionRedirectedEvent;
using static EliteJournalReader.Events.MissionsEvent;
using static EliteJournalReader.Events.ModuleBuyEvent;
using static EliteJournalReader.Events.ModuleInfoEvent;
using static EliteJournalReader.Events.ModuleRetrieveEvent;
using static EliteJournalReader.Events.ModuleSellEvent;
using static EliteJournalReader.Events.ModuleSellRemoteEvent;
using static EliteJournalReader.Events.ModulesInfoEvent;
using static EliteJournalReader.Events.ModuleStoreEvent;
using static EliteJournalReader.Events.ModuleSwapEvent;
using static EliteJournalReader.Events.MultiSellExplorationDataEvent;
using static EliteJournalReader.Events.MusicEvent;
using static EliteJournalReader.Events.NavBeaconScanEvent;
using static EliteJournalReader.Events.NavRouteEvent;
using static EliteJournalReader.Events.NewCommanderEvent;
using static EliteJournalReader.Events.NpcCrewPaidWageEvent;
using static EliteJournalReader.Events.NpcCrewRankEvent;
using static EliteJournalReader.Events.OutfittingEvent;
using static EliteJournalReader.Events.PassengersEvent;
using static EliteJournalReader.Events.PayBountiesEvent;
using static EliteJournalReader.Events.PayFinesEvent;
using static EliteJournalReader.Events.PayLegacyFinesEvent;
using static EliteJournalReader.Events.PowerplayCollectEvent;
using static EliteJournalReader.Events.PowerplayDefectEvent;
using static EliteJournalReader.Events.PowerplayDeliverEvent;
using static EliteJournalReader.Events.PowerplayEvent;
using static EliteJournalReader.Events.PowerplayFastTrackEvent;
using static EliteJournalReader.Events.PowerplayJoinEvent;
using static EliteJournalReader.Events.PowerplayLeaveEvent;
using static EliteJournalReader.Events.PowerplaySalaryEvent;
using static EliteJournalReader.Events.PowerplayVoteEvent;
using static EliteJournalReader.Events.PowerplayVoucherEvent;
using static EliteJournalReader.Events.ProgressEvent;
using static EliteJournalReader.Events.PromotionEvent;
using static EliteJournalReader.Events.ProspectedAsteroidEvent;
using static EliteJournalReader.Events.PVPKillEvent;
using static EliteJournalReader.Events.QuitACrewEvent;
using static EliteJournalReader.Events.RankEvent;
using static EliteJournalReader.Events.RebootRepairEvent;
using static EliteJournalReader.Events.ReceiveTextEvent;
using static EliteJournalReader.Events.RedeemVoucherEvent;
using static EliteJournalReader.Events.RefuelAllEvent;
using static EliteJournalReader.Events.RefuelPartialEvent;
using static EliteJournalReader.Events.RenameSuitLoadoutEvent;
using static EliteJournalReader.Events.RepairAllEvent;
using static EliteJournalReader.Events.RepairDroneEvent;
using static EliteJournalReader.Events.RepairEvent;
using static EliteJournalReader.Events.ReputationEvent;
using static EliteJournalReader.Events.ReservoirReplenishedEvent;
using static EliteJournalReader.Events.RestockVehicleEvent;
using static EliteJournalReader.Events.ResurrectEvent;
using static EliteJournalReader.Events.RouteEvent;
using static EliteJournalReader.Events.SAAScanCompleteEvent;
using static EliteJournalReader.Events.SAASignalsFoundEvent;
using static EliteJournalReader.Events.ScanEvent;
using static EliteJournalReader.Events.ScannedEvent;
using static EliteJournalReader.Events.ScanOrganicEvent;
using static EliteJournalReader.Events.ScientificResearchEvent;
using static EliteJournalReader.Events.ScreenshotEvent;
using static EliteJournalReader.Events.SearchAndRescueEvent;
using static EliteJournalReader.Events.SelfDestructEvent;
using static EliteJournalReader.Events.SellDronesEvent;
using static EliteJournalReader.Events.SellExplorationDataEvent;
using static EliteJournalReader.Events.SellMicroResourcesEvent;
using static EliteJournalReader.Events.SellOrganicDataEvent;
using static EliteJournalReader.Events.SellShipOnRebuyEvent;
using static EliteJournalReader.Events.SellSuitEvent;
using static EliteJournalReader.Events.SellWeaponEvent;
using static EliteJournalReader.Events.SendTextEvent;
using static EliteJournalReader.Events.SetUserShipNameEvent;
using static EliteJournalReader.Events.SharedBookmarkToSquadronEvent;
using static EliteJournalReader.Events.ShieldStateEvent;
using static EliteJournalReader.Events.ShipLockerEvent;
using static EliteJournalReader.Events.ShipLockerMaterialsEvent;
using static EliteJournalReader.Events.ShipTargetedEvent;
using static EliteJournalReader.Events.ShipyardBuyEvent;
using static EliteJournalReader.Events.ShipyardEvent;
using static EliteJournalReader.Events.ShipyardNewEvent;
using static EliteJournalReader.Events.ShipyardSellEvent;
using static EliteJournalReader.Events.ShipyardSwapEvent;
using static EliteJournalReader.Events.ShipyardTransferEvent;
using static EliteJournalReader.Events.ShutdownEvent;
using static EliteJournalReader.Events.SquadronCreatedEvent;
using static EliteJournalReader.Events.SquadronDemotionEvent;
using static EliteJournalReader.Events.SquadronPromotionEvent;
using static EliteJournalReader.Events.SquadronStartupEvent;
using static EliteJournalReader.Events.SRVDestroyedEvent;
using static EliteJournalReader.Events.StartJumpEvent;
using static EliteJournalReader.Events.StatisticsEvent;
using static EliteJournalReader.Events.StoredModulesEvent;
using static EliteJournalReader.Events.StoredShipsEvent;
using static EliteJournalReader.Events.SupercruiseEntryEvent;
using static EliteJournalReader.Events.SupercruiseExitEvent;
using static EliteJournalReader.Events.SwitchSuitLoadoutEvent;
using static EliteJournalReader.Events.SynthesisEvent;
using static EliteJournalReader.Events.SystemsShutdownEvent;
using static EliteJournalReader.Events.TechnologyBrokerEvent;
using static EliteJournalReader.Events.TouchdownEvent;
using static EliteJournalReader.Events.TradeMicroResourcesEvent;
using static EliteJournalReader.Events.TransferMicroResourcesEvent;
using static EliteJournalReader.Events.UnderAttackEvent;
using static EliteJournalReader.Events.UndockedEvent;
using static EliteJournalReader.Events.UpgradeSuitEvent;
using static EliteJournalReader.Events.UpgradeWeaponEvent;
using static EliteJournalReader.Events.UseConsumableEvent;
using static EliteJournalReader.Events.USSDropEvent;
using static EliteJournalReader.Events.VehicleSwitchEvent;
using static EliteJournalReader.Events.WingAddEvent;
using static EliteJournalReader.Events.WingJoinEvent;
using static EliteJournalReader.Events.WingLeaveEvent;
using static EliteJournalReader.Events.WonATrophyForSquadronEvent;

namespace WhoIs
{
    public class edEvent
    {
        public string EventName { get; set; } = "";
        public VoiceActor Actor { get; }
        public edEvent(VoiceActor Actor) => this.Actor = Actor;
    }

    /// <summary>
    /// Событие AfmuRepairs
    /// Когда происходит: при ремонте модулей с помощью блока автоматического полевого ремонта(AFMU) 
    /// Параметры:
    /// • Module: имя ремонтируемого модуля.
    /// • FullyRepaired: флаг "Полностью отремонтировано" (да/нет)
    /// • Health: Здоровье модуля (значение с плавающей точкой 0,0..1,0)
    /// Если в AFMU закончатся боеприпасы, возможно, модуль не будет полностью отремонтирован.
    /// </summary>
    public class edEventAfmuRepairs : edEvent
    {
        AfmuRepairsEventArgs eArgs=null;
        public edEventAfmuRepairs(AfmuRepairsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие AppliedToSquadron
    /// Запрос в эскадру
    /// Параметры:
    /// • SquadronName - название эскадры
    /// </summary>
    public class edEventAppliedToSquadron : edEvent
    {
        AppliedToSquadronEventArgs eArgs=null;
        public edEventAppliedToSquadron(AppliedToSquadronEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ApproachBody
    /// Когда происходит: в суперкруизе и расстояние от планеты падает до зоны орбитального круиза. 
    /// Параметры:
    /// • StarSystem - название звёздной системы
    /// • SystemAddress - координаты звёздной системы
    /// • Тело - название небесного тела
    /// • BodyID - идентификатор небесного тела
    /// </summary>
    public class edEventApproachBody : edEvent
    {
        ApproachBodyEventArgs eArgs=null;
        public edEventApproachBody(ApproachBodyEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ApproachSettlement
    /// Когда происходит: при приближении к планетарному поселению
    /// Параметры:
    /// • Name - название поселения
    /// • MarketID - идентификатор рынка
    /// • Latitude - широта
    /// • Longitude - долгота
    /// • SystemAddress - системный адрес
    /// • BodyName - название небесного тела
    /// • BodyID - идентификатор небесного тела
    /// </summary>
    public class edEventApproachSettlement : edEvent
    {
        ApproachSettlementEventArgs eArgs=null;
        public edEventApproachSettlement(ApproachSettlementEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие AsteroidCracked
    /// Когда происходит: когда игрок разбил астероид "Motherlode" для добычи полезных ископаемых.
    /// Параметры:
    /// • Body: название ближайшего небесного тела
    /// </summary>
    public class edEventAsteroidCracked : edEvent
    {
        AsteroidCrackedEventArgs eArgs=null;
        public edEventAsteroidCracked(AsteroidCrackedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие BackpackMaterials
    /// Материалы для рюкзака
    /// • Items: список предметов
    /// • Components: список компонентов
    /// • Consumables: список расходных материалов
    /// • Data: список данных
    /// </summary>
    public class edEventBackpackMaterials : edEvent
    {
        BackpackMaterialsEventArgs eArgs=null;
        public edEventBackpackMaterials(BackpackMaterialsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие BookDropship
    /// Заказ челнока
    /// Параметры:
    /// • Cost: расходы
    /// • DestinationSystem: система назначения
    /// • DestinationLocation: место назначения
    /// </summary>
    public class edEventBookDropship : edEvent
    {
        BookDropshipEventArgs eArgs=null;
        public edEventBookDropship(BookDropshipEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие BookTaxi
    /// Заказ такси
    /// Параметры:
    /// • Cost: расходы
    /// • DestinationSystem: система назначения
    /// • DestinationLocation: место назначения
    /// </summary>
    public class edEventBookTaxi : edEvent
    {
        BookTaxiEventArgs eArgs=null;
        public edEventBookTaxi(BookTaxiEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Bounty
    /// Когда происходит: игрок получает награду за убийство
    /// Параметры:
    /// • Target: имя цели
    /// • Награды: массив названий фракций и значений наград, так как цель может иметь несколько наград, выплачиваемых разными фракциями.
    /// • VictimFaction: фракция жертвы
    /// • TotalReward: общая награда
    /// • SharedWithOthers: если кредит за убийство делится с другими игроками, в нем участвует количество других игроков.
    /// </summary>
    public class edEventBounty : edEvent
    {
        BountyEventArgs eArgs=null;
        public edEventBounty(BountyEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие BuyAmmo
    /// Когда происходит: при покупке боеприпасов.
    /// Параметры:
    /// • Cost: Расходы
    /// </summary>
    public class edEventBuyAmmo : edEvent
    {
        BuyAmmoEventArgs eArgs=null;
        public edEventBuyAmmo(BuyAmmoEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие BuyDrones
    /// Когда происходит: при покупке дронов
    /// Параметры:
    /// • Type:	Тип дронов
    /// • Count: Количество
    /// • BuyPrice: Стоимость одного
    /// • TotalCost: Общая стоимость
    /// </summary>
    public class edEventBuyDrones : edEvent
    {
        BuyDronesEventArgs eArgs=null;
        public edEventBuyDrones(BuyDronesEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие BuyExplorationData
    /// Когда происходит: при покупке системных данных через карту галактики
    /// Параметры:
    /// • System: Система, для которой покупаются данные
    /// • Cost: Расходы на покупку
    /// </summary>
    public class edEventBuyExplorationData : edEvent
    {
        BuyExplorationDataEventArgs eArgs=null;
        public edEventBuyExplorationData(BuyExplorationDataEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие BuyMicroResources
    /// Покупка микроресурсов
    /// фигзнает что это
    /// • Name: наименование
    /// • Category: категория
    /// • Count: количество
    /// • Price: цена
    /// • MarketID: идентификатор рынка
    /// </summary>
    public class edEventBuyMicroResources : edEvent
    {
        BuyMicroResourcesEventArgs eArgs=null;
        public edEventBuyMicroResources(BuyMicroResourcesEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие BuySuit
    /// Покупка костюма
    /// Параметры:
    /// • Name: Наименование
    /// • Price: Цена
    /// • SuitID: Идентификатор костюма
    /// • SuitMods: Массив модификаций
    /// </summary>
    public class edEventBuySuit : edEvent
    {
        BuySuitEventArgs eArgs=null;
        public edEventBuySuit(BuySuitEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие BuyTradeData
    /// Когда происходит: при покупке торговых данных на карте галактики
    /// Параметры:
    /// • System: запрошена звездная система
    /// • Cost: стоимость данных
    /// </summary>
    public class edEventBuyTradeData : edEvent
    {
        BuyTradeDataEventArgs eArgs=null;
        public edEventBuyTradeData(BuyTradeDataEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие BuyWeapon
    /// Покупка вооружения
    /// Параметры:
    /// • Name: Наименование
    /// • Price: Цена
    /// • SuitModuleID: Идентификатор модуля костюма
    /// • Class: класс вооружения
    /// • WeaponMods: Массив модификаций
    /// </summary>
    public class edEventBuyWeapon : edEvent
    {
        BuyWeaponEventArgs eArgs=null;
        public edEventBuyWeapon(BuyWeaponEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CancelDropship
    /// Отмена заказа челнока
    /// Параметры:
    /// • Refund: Возвращено денег
    /// </summary>
    public class edEventCancelDropship : edEvent
    {
        CancelDropshipEventArgs eArgs=null;
        public edEventCancelDropship(CancelDropshipEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CancelTaxi
    /// Отмена заказа такси
    /// Параметры:
    /// • Refund: Возвращено денег
    /// </summary>
    public class edEventCancelTaxi : edEvent
    {
        CancelTaxiEventArgs eArgs=null;
        public edEventCancelTaxi(CancelTaxiEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CapShipBond
    /// Когда происходит: Игрок был вознагражден за бой на мегашипе
    /// Параметры:
    /// • Reward: размер награды
    /// • AwardingFaction: Награждающая фракция
    /// • VictimFaction: Фракция-жертва
    /// </summary>
    public class edEventCapShipBond : edEvent
    {
        CapShipBondEventArgs eArgs=null;
        public edEventCapShipBond(CapShipBondEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CargoDepot
    /// Когда происходит: при сборе или доставке груза для миссии крыла, или если член крыла обновляет прогресс
    /// Параметры:
    /// • MissionID: Идентификатор миссии
    /// • UpdateType: Тип обновления: Значение одно из: «Collect», «Deliver», «WingUpdate»
    /// • CargoType: Тип груза
    /// • Count: Количество
    /// • StartMarketID: Идентификатор начального рынка
    /// • EndMarketID: Идентификатор конечного рынка
    /// • ItemsCollected: Собранные предметы
    /// • ItemsDelivered: Доставленные предметы
    /// • TotalItemsToDeliver: Всего предметов для доставки
    /// • Progress: Прогресс: (float)
    /// Значение «Прогресс» на самом деле представляет незавершенный прогресс для товаров в пути: 
    /// (Собранные предметы - Доставленные предметы) / Общее количество предметов для доставки.
    /// </summary>
    public class edEventCargoDepot : edEvent
    {
        CargoDepotEventArgs eArgs=null;
        public edEventCargoDepot(CargoDepotEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Cargo
    /// Когда происходит: при запуске, при загрузке из главного меню
    /// Параметры:
    /// • Count: Количество
    /// • Vessel: Корабль (?)
    /// • Inventory: массив грузов, с именем и количеством для каждого
    /// </summary>
    public class edEventCargo : edEvent
    {
        CargoEventArgs eArgs=null;
        public edEventCargo(CargoEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CargoTransfer
    /// Перевозка груза
    /// • Transfers: массив грузов, с типом, количеством и направлением для каждого
    /// </summary>
    public class edEventCargoTransfer : edEvent
    {
        CargoEventArgs eArgs=null;
        public edEventCargoTransfer(CargoEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierBankTransfer
    /// Перевод при помощи банка карабля-носителя
    /// • CarrierID: Идентификатор корабля-носителя
    /// • Deposit: Депозит
    /// • PlayerBalance: Баланс игрока
    /// • CarrierBalance: Баланс корабля-носителя
    /// </summary>
    public class edEventCarrierBankTransfer : edEvent
    {
        CarrierBankTransferEventArgs eArgs=null;
        public edEventCarrierBankTransfer(CarrierBankTransferEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierBuy
    /// Когда происходит: Игрок купил авианосец
    /// Параметры:
    /// • BoughtAtmarket: Идентификатор маркета
    /// • CarrierID: Идентификатор корабля-носителя
    /// • Location: название звездной системы.
    /// • Price: Цена
    /// • Variant: ???
    /// • Callsign: Позывной (???)
    /// </summary>
    public class edEventCarrierBuy : edEvent
    {
        CarrierBuyEventArgs eArgs=null;
        public edEventCarrierBuy(CarrierBuyEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierCancelDecommission
    /// Отмена вывода корабля-носителя из эксплуатации
    /// Параметры:
    /// • CarrierID: Идентификатор корабля-носителя
    /// </summary>
    public class edEventCarrierCancelDecommission : edEvent
    {
        CarrierCancelDecommissionEventArgs eArgs=null;
        public edEventCarrierCancelDecommission(CarrierCancelDecommissionEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierCrewServices
    /// Услуги экипажа корабля-носителя
    /// Параметры:
    /// • CarrierID: Идентификатор корабля-носителя
    /// • Operation: операция
    /// • CrewRole: роль члена экипажа
    /// • CrewName: имя члена экипажа
    /// </summary>
    public class edEventCarrierCrewServices : edEvent
    {
        CarrierCrewServicesEventArgs eArgs=null;
        public edEventCarrierCrewServices(CarrierCrewServicesEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierDecommission
    /// Списание корабля-носителя
    /// Параметры:
    /// • CarrierID: Идентификатор корабля-носителя
    /// • ScrapRefund: возврат денег
    /// • ScrapTime: время (???)
    /// </summary>
    public class edEventCarrierDecommission : edEvent
    {
        CarrierDecommissionEventArgs eArgs=null;
        public edEventCarrierDecommission(CarrierDecommissionEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierDepositFuel
    /// Загрузка топлива в корабль-носитель
    /// • CarrierID: Идентификатор корабля-носителя
    /// • Amount: ???
    /// • Total: ???
    /// </summary>
    public class edEventCarrierDepositFuel : edEvent
    {
        CarrierDepositFuelEventArgs eArgs=null;
        public edEventCarrierDepositFuel(CarrierDepositFuelEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierDockingPermission
    /// Разрешение на стыковку с кораблём-носителем
    /// • CarrierID: Идентификатор корабля-носителя
    /// • DockingAccess: Доступ к док-станции
    /// • AllowNotorious: Разрешение для имеющих ноторити
    /// </summary>
    public class edEventCarrierDockingPermission : edEvent
    {
        CarrierDockingPermissionEventArgs eArgs=null;
        public edEventCarrierDockingPermission(CarrierDockingPermissionEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierFinance
    /// Финансы корабля-носителя
    /// • CarrierID: Идентификатор корабля-носителя
    /// • TaxRate: процентная ставка
    /// • CarrierBalance: баланс корабля-носителя
    /// • ReserveBalance: зарезервированные средства
    /// • AvailableBalance: доступные средства
    /// • ReservePercent: процент зарезервированных средств
    /// </summary>
    public class edEventCarrierFinance : edEvent
    {
        CarrierFinanceEventArgs eArgs=null;
        public edEventCarrierFinance(CarrierFinanceEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierJumpCancelled
    /// Отмена прыжка корабля-носителя
    /// • CarrierID: Идентификатор корабля-носителя
    /// </summary>
    public class edEventCarrierJumpCancelled : edEvent
    {
        CarrierJumpCancelledEventArgs eArgs=null;
        public edEventCarrierJumpCancelled(CarrierJumpCancelledEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierJump
    /// Когда происходит: при запуске или при воскрешении на станции
    /// Параметры:
    /// • StarSystem: название звездной системы
    /// • StarPos: положение звезды в виде массива Json [x, y, z] в световых годах
    /// • Body: имя тела звезды
    /// • BodyType: тип небесного тела
    /// • DistFromStarLS: дистанция до звезды в св.сек. (если рядом с главной звездой)
    /// • Docked: Пристыковано: true (если пристыковано)
    /// • Latitude: Широта(если на поверхности)
    /// • Longitude: Долгота(если на поверхности)
    /// • StationName: название станции (если пристыкован)
    /// • StationType: тип станции (если пристыкован)
    /// • MarketID: идентификатор рынка
    /// • SystemFaction: фракция, управляющая звездной системой:
    ///     o Имя
    ///     o Состояние
    /// • Фракция: фракция, управляющая звездной системой
    /// • FactionState: состояние фракции
    /// • SystemAllegiance: принадлежность системы
    /// • SystemEconomy: экономика системы
    /// • SystemSecondEconomy: вторичная эканомика системы
    /// • SystemGovernment: правительство системы
    /// • SystemSecurity: состояние безопасности системы
    /// • Wanted: розыск (true = да)
    /// • Factions: массив с информацией о местных второстепенных фракциях (аналогично FSDJump)
    /// • Conflicts: массив с информацией о локальных конфликтах (аналог FSDJump)
    /// Если игрок назначен Силой в Powerplay, а звездная система участвует в Powerplay,
    /// • Powers: массив json с именами любых держав, оспаривающих систему, или именем контролирующей державы.
    /// • PowerplayState: состояние системы - одно из («InPrepareRadius», «Prepared», «Exploited», 
    ///                                                 «Contested», «Controlled», «Turmoil», «HomeSystem»)
    /// </summary>
    public class edEventCarrierJump : edEvent
    {
        CarrierJumpEventArgs eArgs=null;
        public edEventCarrierJump(CarrierJumpEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierJumpRequest
    /// Запрос на прыжок корабля-носителя
    /// • CarrierID: идентификатор корабля-носителя
    /// • SystemName: имя системы назначения
    /// • SystemID: идентификатор системы назначения
    /// • Body: небесное тело назначения
    /// • BodyID: идентификатор небесного тела
    /// </summary>
    public class edEventCarrierJumpRequest : edEvent
    {
        CarrierJumpRequestEventArgs eArgs=null;
        public edEventCarrierJumpRequest(CarrierJumpRequestEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierModulePack
    /// Покупка/продажа пакетов модулей корабля-носителя
    /// • CarrierID: идентификатор корабля-носителя
    /// • Operation: операция
    /// • PackTheme: тема пакета
    /// • PackTier: уровень пакета
    /// • Cost: затрачено средств
    /// • Refund: возвращено средств
    /// </summary>
    public class edEventCarrierModulePack : edEvent
    {
        CarrierModulePackEventArgs eArgs=null;
        public edEventCarrierModulePack(CarrierModulePackEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierNameChanged
    /// Смена названия корабля-носителя
    /// • CarrierID: идентификатор корабля-носителя
    /// • Callsign: позывной
    /// • Name: имя
    /// </summary>
    public class edEventCarrierNameChanged : edEvent
    {
        CarrierNameChangedEventArgs eArgs=null;
        public edEventCarrierNameChanged(CarrierNameChangedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierShipPack
    /// Покупка/продажа пакетов кораблей корабля-носителя
    /// • CarrierID: идентификатор корабля-носителя
    /// • Operation: операция
    /// • PackTheme: тема пакета
    /// • PackTier: уровень пакета
    /// • Cost: затрачено средств
    /// • Refund: возвращено средств
    /// </summary>
    public class edEventCarrierShipPack : edEvent
    {
        CarrierShipPackEventArgs eArgs=null;
        public edEventCarrierShipPack(CarrierShipPackEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierStats
    /// Когда происходит: Когда владелец открывает управление кораблём-носителем
    /// • CarrierID: идентификатор рынка корабля-носителя
    /// • Callsign: Позывной
    /// • Name: Имя
    /// • DockingAccess: Доступ к стыковке: all/none/friends/squadron/squadronfriends
    /// • AllowNotorious: Доступ к стыковке нарушителям: bool
    /// • FuelLevel: Уровень топлива
    /// • JumpRangeCurr: Текущий диапазон прыжка
    /// • JumpRangeMax: Максимальный диапазон прыжка
    /// • PendingDecommission: Ожидание списания
    /// • SpaceUsage: Использовано пространства { TotalCapacity, Crew, Cargo, CargoSpaceReserved, ShipPacks, ModulePacks, FreeSpace
    ///
    /// • Finance: Срадства { CarrierBalance, ReserveBalance, AvailableBalance, ReservePercent, TaxRate }
    /// • Crew: Экипаж [{ CrewRole, Activated, Enabled, CrewName },...]
    /// • ShipPacks: Наборы кораблей [{ PackTheme, packTier },...]
    /// • ModulePacks: Наборы модулей[{PackTheme, packTier },...]
    /// </summary>
    public class edEventCarrierStats : edEvent
    {
        CarrierStatsEventArgs eArgs=null;
        public edEventCarrierStats(CarrierStatsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CarrierTradeOrder
    /// Торговля на корабле-носителе
    /// • CarrierID: идентификатор рынка корабля-носителя
    /// • BlackMarket: чёрный рынок (да/нет)
    /// • Commodity: товар
    /// • PurchaseOrder: заказ на покупку
    /// • SaleOrder: заказ на продажу
    /// • CancelTrade: отмена операции
    /// • Price: цена
    /// </summary>
    public class edEventCarrierTradeOrder : edEvent
    {
        CarrierTradeOrderEventArgs eArgs=null;
        public edEventCarrierTradeOrder(CarrierTradeOrderEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ChangeCrewRole
    /// Изменение роли в команде
    /// • Role: Роль { Unknown, Idle, FireCon, FighterCon }
    /// </summary>
    public class edEventChangeCrewRole : edEvent
    {
        ChangeCrewRoleEventArgs eArgs=null;
        public edEventChangeCrewRole(ChangeCrewRoleEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ClearSavedGame
    /// Сброс сохранения игры
    /// • Name: Имя командира
    /// </summary>
    public class edEventClearSavedGame : edEvent
    {
        ClearSavedGameEventArgs eArgs=null;
        public edEventClearSavedGame(ClearSavedGameEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CockpitBreached
    /// Когда происходит: когда пробит фонарь кабины
    /// </summary>
    public class edEventCockpitBreached : edEvent
    {
        CockpitBreachedEventArgs eArgs=null;
        public edEventCockpitBreached(CockpitBreachedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CodexEntry
    /// Когда происходит: когда новое открытие добавляется в Кодекс
    /// Параметры:
    /// • EntryID: идентификационный номер.
    /// • Name: Название
    /// • SubCategory: Подкатегория
    /// • Category: Категория
    /// • Region: Регион
    /// • System: Система
    /// • SystemAddress: Алрес системы
    /// • NearestDestination: Ближайший пункт назначения
    /// • IsNewEntry: Новая запись (да/нет)
    /// • NewTraitsDiscovered: Обнаружены новые особенности (да/нет)
    /// • Traits: Черты [массив строк]
    /// 
    /// Поля IsNewEntry и NewTraitsDiscovered являются необязательными в зависимости от результатов сканирования.
    /// а поле «Traits» доступно только для записей с разблокированными чертами.
    /// </summary>
    public class edEventCodexEntry : edEvent
    {
        CodexEntryEventArgs eArgs=null;
        public edEventCodexEntry(CodexEntryEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CollectCargo
    /// Когда происходит: при подборе груза в космосе или на поверхности планеты
    /// Параметры:
    /// • Type: груз
    /// • Stolen: украдено (да/нет)
    /// • MissionID: идентификатор миссии
    /// </summary>
    public class edEventCollectCargo : edEvent
    {
        CollectCargoEventArgs eArgs=null;
        public edEventCollectCargo(CollectCargoEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CollectItems
    /// Когда происходит: при подборе предметов
    /// Параметры:
    /// • Name: наименование
    /// • Type: груз
    /// • OwnerID: идентификатор владельца
    /// • Count: количество
    /// • Stolen: украдено (да/нет)
    /// </summary>
    public class edEventCollectItems : edEvent
    {
        CollectItemsEventArgs eArgs=null;
        public edEventCollectItems(CollectItemsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Commander
    /// Когда происходит: в начале процесса загрузки игры
    /// Параметры:
    /// • Name: имя командира
    /// • FID: идентификатор игрока
    /// </summary>
    public class edEventCommander : edEvent
    {
        CommanderEventArgs eArgs=null;
        public edEventCommander(CommanderEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CommitCrime
    /// Когда происходит: когда против игрока зафиксировано преступление
    /// Параметры:
    /// • CrimeType: тип преступления
    /// • Faction: фракция
    /// Необязательные параметры (в зависимости от преступления)
    /// • Victim: жертва
    /// • Fine: штраф
    /// • Bounty: награда
    /// </summary>
    public class edEventCommitCrime : edEvent
    {
        CommitCrimeEventArgs eArgs=null;
        public edEventCommitCrime(CommitCrimeEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CommunityGoalDiscard
    /// Когда происходит: при отказе от цели сообщества
    /// Параметры:
    /// • CGID: идентификатор цели сообщества
    /// • Name: имя
    /// • System: система
    /// </summary>
    public class edEventCommunityGoalDiscard : edEvent
    {
        CommunityGoalDiscardEventArgs eArgs=null;
        public edEventCommunityGoalDiscard(CommunityGoalDiscardEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CommunityGoal
    /// Когда происходит: при проверке статуса цели сообщества
    /// • CurrentGoals: массив с записями для каждой CG, содержащий:
    ///     • CGID: уникальный идентификационный номер для этого CG
    ///     • Title: описание CG
    ///     • SystemName: система
    ///     • MarketName: рынок
    ///     • Expiry: срок действия (время и дата)
    ///     • IsComplete: флаг завершения (да/нет)
    ///     • CurrentTotal: текущие очки
    ///     • PlayerContribution: вклад игрока
    ///     • NumContributors: всего участвующих
    ///     • PlayerPercentileBand: процентный вклад игрока
    ///     
    ///     Если цель сообщества построена с фиксированным высшим рангом (т.е. Максимальное вознаграждение для 10 лучших игроков)
    ///     • TopRankSize: размер высшего ранга
    ///     • PlayerInTopRank: игрок в Топ? (да/нет)
    /// 
    ///     Если цель сообщества достигла первого уровня
    ///     • TierReached: достигнут уровень
    ///     • Bonus: бонус
    /// </summary>
    public class edEventCommunityGoal : edEvent
    {
        CommunityGoalEventArgs eArgs=null;
        public edEventCommunityGoal(CommunityGoalEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CommunityGoalJoin
    /// Когда происходит: когда игрок присоединяется к цели сообщества
    /// Параметры:
    /// • CGID: идентификатор цели сообщества
    /// • Name: имя
    /// • System: система
    /// </summary>
    public class edEventCommunityGoalJoin : edEvent
    {
        CommunityGoalJoinEventArgs eArgs=null;
        public edEventCommunityGoalJoin(CommunityGoalJoinEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CommunityGoalReward
    /// Когда происходит: при получении награды за цель сообщества
    /// Параметры:
    /// • CGID: идентификатор цели сообщества
    /// • Name: имя
    /// • System: система
    /// • Reward: награда
    /// </summary>
    public class edEventCommunityGoalReward : edEvent
    {
        CommunityGoalRewardEventArgs eArgs=null;
        public edEventCommunityGoalReward(CommunityGoalRewardEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Continued
    /// Когда происходит: если файл журнала вырастает до 500 тыс. строк,
    /// записывается это событие, закрывается файл и запускается новый
    /// Параметры:
    /// • Part: номер следующей части
    /// </summary>
    public class edEventContinued : edEvent
    {
        ContinuedEventArgs eArgs=null;
        public edEventContinued(ContinuedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CreateSuitLoadout
    /// Когда происходит: при создании экипировки костюма
    /// Параметры:
    /// • SuitID: идентификатор костюма
    /// • SuitName: имя костюма
    /// • LoadoutID: идентификатор экипировки
    /// • Modules: список модулей
    /// • SuitMods: массив модификаций
    /// </summary>
    public class edEventCreateSuitLoadout : edEvent
    {
        CreateSuitLoadoutEventArgs eArgs=null;
        public edEventCreateSuitLoadout(CreateSuitLoadoutEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CrewAssign
    /// Когда происходит: при изменении роли члена экапажа
    /// Параметры:
    /// • Name: имя
    /// • CrewID: идентификатор
    /// • Role: роль
    /// </summary>
    public class edEventCrewAssign : edEvent
    {
        CrewAssignEventArgs eArgs=null;
        public edEventCrewAssign(CrewAssignEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CrewFire
    /// Когда происходит: при увольнении члена экипажа
    /// Параметры:
    /// • Name: имя
    /// • CrewID: идентификатор
    /// </summary>
    public class edEventCrewFire : edEvent
    {
        CrewFireEventArgs eArgs=null;
        public edEventCrewFire(CrewFireEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CrewHire
    /// Когда происходит: при найме нового члена экипажа
    /// Параметры:
    /// • CrewID: идентификатор
    /// • Name: имя
    /// • Faction: фракция
    /// • Cost: зарплата
    /// • CombatRank: боевой ранг
    /// </summary>
    public class edEventCrewHire : edEvent
    {
        CrewHireEventArgs eArgs=null;
        public edEventCrewHire(CrewHireEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CrewLaunchFighter
    /// Когда происходит: в многопользовательской команде, в журнале игрока за штурвалом, когда член экипажа запускает истребитель
    /// Параметры:
    /// • Crew: имя члена экипажа в истребителе
    /// • CrewID: идентификатор (???)
    /// • ID: идентификатор (???)
    /// </summary>
    public class edEventCrewLaunchFighter : edEvent
    {
        CrewLaunchFighterEventArgs eArgs=null;
        public edEventCrewLaunchFighter(CrewLaunchFighterEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CrewMemberJoins
    /// Когда происходит: когда другой игрок присоединяется к команде корабля
    /// Параметры:
    /// • Crew: имя присоединившегося пилота
    /// • CrewID: идентификатор
    /// </summary>
    public class edEventCrewMemberJoins : edEvent
    {
        CrewMemberJoinsEventArgs eArgs=null;
        public edEventCrewMemberJoins(CrewMemberJoinsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CrewMemberQuits
    /// Когда происходит: когда другой игрок покидает команду корабля
    /// Параметры:
    /// • Crew: имя ушедшего пилота
    /// • CrewID: идентификатор
    /// </summary>
    public class edEventCrewMemberQuits : edEvent
    {
        CrewMemberQuitsEventArgs eArgs=null;
        public edEventCrewMemberQuits(CrewMemberQuitsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CrewMemberRoleChange
    /// Когда происходит: когда другой игрок меняет роль в команде корабля
    /// Параметры:
    /// • Crew: имя пилота
    /// • CrewID: идентификатор
    /// • Role: выбранная роль
    /// </summary>
    public class edEventCrewMemberRoleChange : edEvent
    {
        CrewMemberRoleChangeEventArgs eArgs=null;
        public edEventCrewMemberRoleChange(CrewMemberRoleChangeEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие CrimeVictim
    /// Когда происходит: когда против игрока зафиксировано преступление (жертва преступления)
    /// Параметры:
    /// • Offender: преступник
    /// • CrimeType: тип преступления
    /// Необязательные параметры (в зависимости от преступления)
    /// • Fine: штраф
    /// • Bounty: Награда
    /// </summary>
    public class edEventCrimeVictim : edEvent
    {
        CrimeVictimEventArgs eArgs=null;
        public edEventCrimeVictim(CrimeVictimEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DatalinkScan
    /// Когда происходит: при сканировании канала передачи данных
    /// Параметры:
    /// • Message: полученное при сканировании сообщение
    /// </summary>
    public class edEventDatalinkScan : edEvent
    {
        DatalinkScanEventArgs eArgs=null;
        public edEventDatalinkScan(DatalinkScanEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DatalinkVoucher
    /// Когда происходит: при сканировании канала передачи данных за вознаграждение
    /// Параметры:
    /// • Reward: награда
    /// • VictimFaction: целевая фракция
    /// • PayeeFaction: фракция-заказчик
    /// </summary>
    public class edEventDatalinkVoucher : edEvent
    {
        DatalinkVoucherEventArgs eArgs=null;
        public edEventDatalinkVoucher(DatalinkVoucherEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DataScanned
    /// Когда происходит: при сканировании канала передачи данных
    /// Параметры:
    /// • Type: тип
    /// </summary>
    public class edEventDataScanned : edEvent
    {
        DataScannedEventArgs eArgs=null;
        public edEventDataScanned(DataScannedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DeleteSuitLoadout
    /// Когда происходит: при снятии экипировки с костюма
    /// Параметры:
    /// • SuitID: идентификатор костюма
    /// • SuitName: наименование костюма
    /// • LoadoutID: идентификатор экипировки
    /// • LoadoutName: наименование экипировки
    /// </summary>
    public class edEventDeleteSuitLoadout : edEvent
    {
        DeleteSuitLoadoutEventArgs eArgs=null;
        public edEventDeleteSuitLoadout(DeleteSuitLoadoutEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Died
    /// Когда происходит: игрок был убит
    /// Параметры:
    /// • KillerName: имя игрока
    /// • KillerShip: корабль
    /// • KillerRank: боевой ранг
    /// Все данные содержатся в массиве Killers
    /// </summary>
    public class edEventDied : edEvent
    {
        DiedEventArgs eArgs=null;
        public edEventDied(DiedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DisbandedSquadron
    /// Когда происходит: при расформировании эскадры
    /// Параметры:
    /// • SquadronName: эскадра
    /// </summary>
    public class edEventDisbandedSquadron : edEvent
    {
        DisbandedSquadronEventArgs eArgs=null;
        public edEventDisbandedSquadron(DisbandedSquadronEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DiscoveryScan
    /// Когда происходит: При использовании сканера обнаружения 
    /// новые обнаруженные тела отображаются в информационном окне кабины.
    /// Обратите внимание, что вы можете получить два или три из них подряд, 
    /// когда некоторые тела обнаруживаются автоматическим пассивным сканированием, 
    /// прежде чем активное сканирование будет завершено.
    /// Параметры:
    /// • SystemAddress: координаты системы
    /// • Bodies: количество обнаруженных небесных тел
    /// </summary>
    public class edEventDiscoveryScan : edEvent
    {
        DiscoveryScanEventArgs eArgs=null;
        public edEventDiscoveryScan(DiscoveryScanEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Disembark
    /// Когда происходит: при высадке из корабля
    /// Параметры:
    /// • SRV: высадка на SRV (да/нет)
    /// • Taxi: такси (да/нет)
    /// • Multicrew: в команде корабля (да/нет)
    /// • ID: идентификатор (чего?)
    /// • StarSystem: название системы
    /// • SystemAddress: координаты системы
    /// • Body: небесное тело
    /// • BodyID: идентификатор небесного тела
    /// • OnStation: на станции? (да/нет)
    /// • StationName: название станции
    /// • StationType: тип станции
    /// • MarketID: идентификатор рынка
    /// </summary>
    public class edEventDisembark : edEvent
    {
        DisembarkEventArgs eArgs=null;
        public edEventDisembark(DisembarkEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Docked
    /// Когда происходит: при стыковке с посадочной площадкой космической станции, аутпоста или наземного поселения
    /// Параметры:
    /// • StarSystem: система
    /// • StationName: наименование станции
    /// • SystemAddress: координаты системы
    /// • MarketID: идентификатор рынка
    /// • StationType: тип станции
    /// • CockpitBreach: разбит фонарь кабины? (да/нет)
    /// • StationAllegiance: подданство станции
    /// • StationEconomy: экономика станции
    /// • StationGovernment: правительство станции
    /// • DistFromStarLS: диствнция от звезды в св.сек.
    /// • Wanted: в розыске? (да/нет)
    /// • ActiveFine: есть активные штрафы (да/нет)
    /// • StationFaction: правящая фракция станции
    /// • LandingPads: посадочные площадки
    /// • StationServices: станционные сервисы
    /// • StationEconomies: экономики фракций станции
    /// 
    /// Протокол «анонимной стыковки» вступает в силу, 
    /// если пилот либо разыскивается (т. е. имеет местную награду), 
    /// либо имеет неоплаченные штрафы
    /// </summary>
    public class edEventDocked : edEvent
    {
        DockedEventArgs eArgs=null;
        public edEventDocked(DockedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DockFighter
    /// Когда происходит: при стыковке файтера с базой
    /// Параметры:
    /// • ID: идентификатор (???)
    /// </summary>
    public class edEventDockFighter : edEvent
    {
        DockFighterEventArgs eArgs=null;
        public edEventDockFighter(DockFighterEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DockingCancelled
    /// Когда происходит: когда игрок отменяет запрос на стыковку
    /// Параметры:
    /// • StationName: имя станции
    /// • StationType: тип станции
    /// • MarketID: идентификатор рынка
    /// </summary>
    public class edEventDockingCancelled : edEvent
    {
        DockingCancelledEventArgs eArgs=null;
        public edEventDockingCancelled(DockingCancelledEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DockingDenied
    /// Когда происходит: когда станция отклоняет запрос на стыковку
    /// Параметры:
    /// • StationName: имя станции
    /// • StationType: тип станции
    /// • MarketID: идентификатор рынка
    /// • Reason: причины отказа { Unknown, NoSpace, TooLarge, Hostile, Offences, Distance, ActiveFighter, NoReason }
    /// </summary>
    public class edEventDockingDenied : edEvent
    {
        DockingDeniedEventArgs eArgs=null;
        public edEventDockingDenied(DockingDeniedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DockingGranted
    /// Когда происходит: когда станция разрешает стыковку
    /// Параметры:
    /// • StationName: имя станции
    /// • StationType: тип станции
    /// • MarketID: идентификатор рынка
    /// • LandingPad: номер посадочной площадки
    /// </summary>
    public class edEventDockingGranted : edEvent
    {
        DockingGrantedEventArgs eArgs=null;
        public edEventDockingGranted(DockingGrantedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DockingRequested
    /// Когда происходит: когда игрок запрашивает стыковку на станции
    /// Параметры:
    /// • StationName: имя станции
    /// • StationType: тип станции
    /// • MarketID: идентификатор рынка
    /// • LandingPads: посадочные площадки { Small, Medium, Large } (количество?)
    /// </summary>
    public class edEventDockingRequested : edEvent
    {
        DockingRequestedEventArgs eArgs=null;
        public edEventDockingRequested(DockingRequestedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DockingTimeout
    /// Когда происходит: когда время запроса на стыковку истекло
    /// Параметры:
    /// • StationName: имя станции
    /// • StationType: тип станции
    /// • MarketID: идентификатор рынка
    /// </summary>
    public class edEventDockingTimeout : edEvent
    {
        DockingTimeoutEventArgs eArgs=null;
        public edEventDockingTimeout(DockingTimeoutEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DockSRV
    /// Когда происходит: при стыковке SRV с кораблем
    /// Параметры:
    /// • ID: идентификатор (???)
    /// </summary>
    public class edEventDockSRV : edEvent
    {
        DockSRVEventArgs eArgs=null;
        public edEventDockSRV(DockSRVEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DropItems
    /// Когда происходит: при выбрасывании предметов
    /// Параметры:
    /// • Name: наименование
    /// • Type: тип
    /// • OwnerID: идентификатор владельца
    /// • MissionID: идентификатор миссии
    /// • Count: количество
    /// </summary>
    public class edEventDropItems : edEvent
    {
        DropItemsEventArgs eArgs=null;
        public edEventDropItems(DropItemsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие DropShipDeploy
    /// Когда происходит: Развертывание DropShip
    /// Параметры:
    /// • StarSystem: система
    /// • SystemAddress: координаты системы
    /// • Body: небесное тело
    /// • BodyID: идентификатор небесного тела
    /// • OnStation: на станции? (да/нет)
    /// • OnPlanet: на планете? (да/нет)
    /// </summary>
    public class edEventDropShipDeploy : edEvent
    {
        DropShipDeployEventArgs eArgs=null;
        public edEventDropShipDeploy(DropShipDeployEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие EjectCargo
    /// Когда происходит: при подборе груза
    /// Параметры:
    /// • Type: тип
    /// • Count: количество
    /// • Abandoned: заброшенный
    /// • PowerplayOrigin: источник ПП
    /// • MissionID: идентификатор миссии
    /// </summary>
    public class edEventEjectCargo : edEvent
    {
        EjectCargoEventArgs eArgs=null;
        public edEventEjectCargo(EjectCargoEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Embark
    /// Когда происходит: посадка на корабль, SRV, такси
    /// Параметры:
    /// • SRV: SRV? (да/нет)
    /// • Taxi: такси? (да/нет)
    /// • Multicrew: многопользовательская игра? (да/нет)
    /// • ID: идентификатор (чего?)
    /// • StarSystem: система
    /// • SystemAddress: координаты системы
    /// • Body: небесное тело
    /// • BodyID: идентификатор небесного тела
    /// • OnStation: на станции? (да/нет)
    /// • OnPlanet: на планете? (да/нет)
    /// • StationName: имя станции
    /// • StationType: тип станции
    /// • MarketID: идентификатор рынка
    /// </summary>
    public class edEventEmbark : edEvent
    {
        EmbarkEventArgs eArgs=null;
        public edEventEmbark(EmbarkEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие EndCrewSession
    /// Когда происходит: Когда другой игрок покидает команду корабля
    /// Параметры:
    /// • OnCrime: true, если игрок автоматически исключается за совершение преступления в законном сеансе
    /// </summary>
    public class edEventEndCrewSession : edEvent
    {
        EndCrewSessionEventArgs eArgs=null;
        public edEventEndCrewSession(EndCrewSessionEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие EngineerContribution
    /// Когда происходит: при предложении предметов наличными или вознаграждениями инженеру для получения доступа
    /// Параметры:
    /// • Engineer: имя инженера
    /// • EngineerID: идентификатор
    /// • Type: тип вклада (commodity, materials, credits, bond, bounty)
    /// • Commodity: товар
    /// • Material: материал
    /// • Faction: для bond или bounty
    /// • Quantity: сумма, предложенная в этот раз
    /// • TotalQuantity: общая сумма пожертвований
    /// </summary>
    public class edEventEngineerContribution : edEvent
    {
        EngineerContributionEventArgs eArgs=null;
        public edEventEngineerContribution(EngineerContributionEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие EngineerCraft
    /// Когда происходит: при запросе улучшений инженера
    /// Параметры:
    /// • Engineer: имя инженера
    /// • EngineerID: идентификатор
    /// • BlueprintName: название чертежа
    /// • BlueprintID: идентификатор чертежа
    /// • Level: уровень
    /// • Quality: качество
    /// • ApplyExperimentalEffect: экспериментальный эффект
    /// • Ingredients: Объект JSON с названиями и необходимыми количествами материалов
    /// • Modifiers: модификации
    /// </summary>
    public class edEventEngineerCraft : edEvent
    {
        EngineerCraftEventArgs eArgs=null;
        public edEventEngineerCraft(EngineerCraftEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие EngineerLegacyConvert
    /// Когда происходит: при преобразовании заинженеренного до версии 2.4 модуля
    /// Создается при преобразовании или предварительном просмотре преобразования устаревшего модуля в новую систему.
    /// Из-за характера изменений, внесенных в 2.5, модули, созданные в старой системе, несовместимы с новой системой инженеринга, 
    /// поэтому игроки не смогут инженерить с ними.
    /// Тем не менее, игрокам будет предоставлена ​​возможность преобразовать свои устаревшие модули в новый формат с оговоркой,
    /// что преобразованные модули будут на уровень рецепта ниже, чем они были до преобразования.
    /// Запись журнала EngineerLegacyConvert создается при преобразовании рецепта или просто при предварительном просмотре преобразования,
    /// поэтому некоторые из сторонних разработчиков могут создавать инструменты, чтобы показать,
    /// разницу экипировки корабля до и после преобразования их модулей.
    /// Сама запись такая же, как запись EngineerCraft, за вычетом данных об ингредиентах 
    /// (поскольку для преобразования не требуются материалы), и плюс логическое значение IsPreview, 
    /// указывающее, была ли эта запись создана в результате преобразования или только из предварительного просмотра.
    /// Параметры:
    /// • Engineer: имя инженера
    /// • EngineerID: идентификатор
    /// • Blueprint: название чертежа
    /// • BlueprintID: идентификатор чертежа
    /// • Level: уровень
    /// • Quality: качество
    /// • IsPreview: запись создана в результате преобразования старого инженеринга модуля или только предварительного просмотра (да/нет)
    /// • Modifiers: модификации
    /// </summary>
    public class edEventEngineerLegacyConvert : edEvent
    {
        EngineerLegacyConvertEventArgs eArgs=null;
        public edEventEngineerLegacyConvert(EngineerLegacyConvertEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие EngineerProgress
    /// Когда происходит: когда игрок увеличивает уровень доступа к инженеру
    /// Параметры:
    /// • Engineer: имя инженера
    /// • EngineerID: идентификатор
    /// • Rank: достигнутый ранг (когда разблокирован)
    /// • Progress: стадия прогресса (Invited/Acquainted/Unlocked/Barred)
    /// • Engineers: массив инженеров (???)
    /// </summary>
    public class edEventEngineerProgress : edEvent
    {
        EngineerProgressEventArgs eArgs=null;
        public edEventEngineerProgress(EngineerProgressEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие EscapeInterdiction
    /// Когда происходит: когда игрок уходит от перехвата
    /// Параметры:
    /// • Interdictor: имя перехватывающего пилота
    /// • IsPlayer: перехватывающий - игрок? (да/нет)
    /// </summary>
    public class edEventEscapeInterdiction : edEvent
    {
        EscapeInterdictionEventArgs eArgs=null;
        public edEventEscapeInterdiction(EscapeInterdictionEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие FactionKillBond
    /// Когда происходит: Игрок награждается за участие в зоне боевых действий
    /// Параметры:
    /// • AwardingFaction: победившая фракция
    /// • VictimFaction: проигравшая фракция
    /// • Reward: награда
    /// </summary>
    public class edEventFactionKillBond : edEvent
    {
        FactionKillBondEventArgs eArgs=null;
        public edEventFactionKillBond(FactionKillBondEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие FetchRemoteModule
    /// Когда происходит: при запросе доставки модуля из хранилища на станцию
    /// Параметры:
    /// • StorageSlot: слот хранения
    /// • Ship: корабль
    /// • ShipID: идентификатор корабля
    /// • StoredItem: хранимый элемент
    /// • ServerId: идентификатор сервера
    /// • TransferCost: стоимость доставки
    /// • TransferTime: вреия доставки в секундах
    /// </summary>
    public class edEventFetchRemoteModule : edEvent
    {
        FetchRemoteModuleEventArgs eArgs=null;
        public edEventFetchRemoteModule(FetchRemoteModuleEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие FighterDestroyed
    /// Когда происходит: при уничтожении корабельного истребителя
    /// Параметры:
    /// • ID: идентификатор
    /// </summary>
    public class edEventFighterDestroyed : edEvent
    {
        FighterDestroyedEventArgs eArgs=null;
        public edEventFighterDestroyed(FighterDestroyedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие FighterRebuilt
    /// Когда происходит: когда истребитель корабля восстанавливается в ангаре
    /// Параметры:
    /// • Loadout: экипировка
    /// • ID: идентификатор
    /// </summary>
    public class edEventFighterRebuilt : edEvent
    {
        FighterRebuiltEventArgs eArgs=null;
        public edEventFighterRebuilt(FighterRebuiltEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Fileheader
    /// Когда происходит: при загрузке игры
    /// Параметры:
    /// • GameVersion: версия игры
    /// • Build: билд игры
    /// • Language: язык
    /// • Part: часть журнала (более 500К строк открывается новый с новым номером)
    /// </summary>
    public class edEventFileheader : edEvent
    {
        FileheaderEventArgs eArgs=null;
        public edEventFileheader(FileheaderEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Friends
    /// Когда происходит: при получении информации об изменении статуса друга
    /// Параметры:
    /// • Name: имя командира
    /// • Status: статус (Requested, Declined, Added, Lost, Offline, Online)
    /// </summary>
    public class edEventFriends : edEvent
    {
        FriendsEventArgs eArgs=null;
        public edEventFriends(FriendsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие FSDJump
    /// Когда происходит: при прыжке из одной звездной системы в другую
    /// Параметры:
    /// • StarSystem: название звездной системы назначения
    /// • SystemAddress: 
    /// • StarPos: положение звезды в виде массива Json [x, y, z] в световых годах
    /// • Body: имя звезды
    /// • JumpDist: расстояние прыжка
    /// • FuelUsed: 
    /// • FuelLevel: 
    /// • BoostUsed: использовалось ли ускорение FSD
    /// • SystemFaction: контролирующея систему фракция
    /// • SystemAllegiance: 
    /// • SystemEconomy: 
    /// • SystemSecondEconomy: 
    /// • SystemGovernment: 
    /// • SystemSecurity: 
    /// • Population: 
    /// • Wanted: 
    /// • PowerplayState: 
    /// • Powers: 
    /// • Factions: массив информации о местных второстепенных фракциях
    ///     • Name: 
    ///     • FactionState: 
    ///     • Government: 
    ///     • Influence: 
    ///     • Happiness: 
    ///     • MyReputation: 
    ///     • PendingStates: array(if any) with State name and Trend value
    ///     • RecovingStates: array(if any)with State name and Trend value
    ///     • ActiveStates: array with State names (Note active states do not have a Trend value)
    ///     • SquadronFaction:true (if player is in squadron aligned to this faction)
    ///     • HappiestSystem:true (if player squadron faction, and this is happiest system)
    ///     • HomeSystem:true(if player squadron faction, and this is home system)
    /// • Conflicts: массив информации о локальных конфликтах (если есть)
    ///     • WarType: 
    ///     • Status: 
    ///     • Faction1: { Name, Stake, WonDays } 
    ///     • Faction2: { Name, Stake, WonDays }
    /// Если игрок назначен Силой в Powerplay, а звездная система участвует в Powerplay
    /// • Powers: 
    /// • PowerplayState: 
    /// </summary>
    public class edEventFSDJump : edEvent
    {
        FSDJumpEventArgs eArgs=null;
        public edEventFSDJump(FSDJumpEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие FSDTarget
    /// Когда происходит: при выборе звездной системы для перехода.
    /// Обратите внимание: при следовании по маршруту с несколькими прыжками 
    /// это обычно появляется для следующей звезды во время прыжка, 
    /// то есть после «StartJump», но до «FSDJump».
    /// Параметры:
    /// • StarSystem: 
    /// • SystemAddress: 
    /// • Name: 
    /// • RemainingJumpsInRoute: оставшиеся прыжки в маршруте
    /// • StarClass: класс звезды
    /// </summary>
    public class edEventFSDTarget : edEvent
    {
        FSDTargetEventArgs eArgs=null;
        public edEventFSDTarget(FSDTargetEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие FSSAllBodiesFound
    /// Когда происходит: Когда FSS-сканирование системы завершено и найдены все тела
    /// Параметры:
    /// • BodyCount: количество небесных тел в системе
    /// • NonBodyCount: количество обнаруженных сигналов, не связанных с телом
    /// </summary>
    public class edEventFSSAllBodiesFound : edEvent
    {
        FSSAllBodiesFoundEventArgs eArgs=null;
        public edEventFSSAllBodiesFound(FSSAllBodiesFoundEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие FSSDiscoveryScan
    /// Когда происходит: при выполнении полного сканирования системы («гудок»)
    /// Параметры:
    /// • Progress: (значение в диапазоне 0–1, показывающее, насколько полно была просканирована система)
    /// • BodyCount: количество небесных тел в системе
    /// • NonBodyCount: количество обнаруженных сигналов, не связанных с телом
    /// </summary>
    public class edEventFSSDiscoveryScan : edEvent
    {
        FSSDiscoveryScanEventArgs eArgs=null;
        public edEventFSSDiscoveryScan(FSSDiscoveryScanEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие FSSSignalDiscovered
    /// Когда происходит: при обнаружении сигналов при FSS-сканирования системы
    /// Параметры:
    /// • SignalName: имя сигнала
    /// • SpawningState: 
    /// • SpawningFaction: 
    /// • TimeRemaining: оставшееся время
    /// • IsStation: это станция? (да/нет)
    /// • ThreatLevel: уровень опасности
    /// • SystemAddress: 
    /// • USSType: 
    /// </summary>
    public class edEventFSSSignalDiscovered : edEvent
    {
        FSSSignalDiscoveredEventArgs eArgs=null;
        public edEventFSSSignalDiscovered(FSSSignalDiscoveredEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие FuelScoop
    /// Когда происходит: при заправке от звезды
    /// Параметры:
    /// • Scooped: количество собранных тонн топлива
    /// • Total: общий уровень топлива после заправки
    /// </summary>
    public class edEventFuelScoop : edEvent
    {
        FuelScoopEventArgs eArgs=null;
        public edEventFuelScoop(FuelScoopEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие HeatDamage
    /// Когда происходит: при получении повреждений из-за перегрева
    /// Параметры: нет
    /// </summary>
    public class edEventHeatDamage : edEvent
    {
        HeatDamageEventArgs eArgs=null;
        public edEventHeatDamage(HeatDamageEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие HeatWarning
    /// Когда происходит: игрок получает усиление тепловой сигнатуры от игрока или NPC
    /// Параметры: нет
    /// </summary>
    public class edEventHeatWarning : edEvent
    {
        HeatWarningEventArgs eArgs=null;
        public edEventHeatWarning(HeatWarningEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие HullDamage
    /// Когда происходит: игрок получил повреждение корпуса от игрока или NPC
    /// Параметры:
    /// • Health: Целостность
    /// • PlayerPilot: игрок? (да/нет)
    /// • Fighter: файтер? (да/нет)
    /// </summary>
    public class edEventHullDamage : edEvent
    {
        HullDamageEventArgs eArgs=null;
        public edEventHullDamage(HullDamageEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Interdicted
    /// Когда происходит: игрок был перехвачен игроком или NPC
    /// Параметры:
    /// • Submitted: 
    /// • Interdictor: имя перехватившего
    /// • IsPlayer: игрок? (да/нет)
    /// • CombatRank: боевой ранг
    /// • Faction: фракция для NPC
    /// • Power: ПП для NPC
    /// </summary>
    public class edEventInterdicted : edEvent
    {
        InterdictedEventArgs eArgs=null;
        public edEventInterdicted(InterdictedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Interdiction
    /// Когда происходит: игрок перехватил или пытался перехватить другого игрока или NPC
    /// Параметры:
    /// • Success: успешно? (да/нет)
    /// • Interdicted: имя перехватываемого пилота
    /// • IsPlayer: игрок? (да/нет)
    /// • CombatRank: боевой ранг
    /// • Faction: фракция для NPC
    /// • Power: ПП для NPC
    /// </summary>
    public class edEventInterdiction : edEvent
    {
        InterdictionEventArgs eArgs=null;
        public edEventInterdiction(InterdictionEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие InvitedToSquadron
    /// Когда происходит: получено приглашение в эскадру
    /// Параметры:
    /// • SquadronName: имя эскадры
    /// </summary>
    public class edEventInvitedToSquadron : edEvent
    {
        InvitedToSquadronEventArgs eArgs=null;
        public edEventInvitedToSquadron(InvitedToSquadronEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MagicMau.IsLiveEvent
    /// Когда происходит: ну когда-то... ваще хрень непонятная "Живое мероприятие"
    /// Параметры: нету
    /// </summary>
    public class edEventMagicMauIsLiveEvent : edEvent
    {
        IsLiveEventArgs eArgs=null;
        public edEventMagicMauIsLiveEvent(IsLiveEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие JetConeBoost
    /// Когда происходит: при перегрузке FSD в джете белого карлика или нейтронной звезды
    /// Параметры:
    /// • BoostValue: размер полученного ускорения
    /// </summary>
    public class edEventJetConeBoost : edEvent
    {
        JetConeBoostEventArgs eArgs=null;
        public edEventJetConeBoost(JetConeBoostEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие JetConeDamage
    /// Когда происходит: проход в джете белого карлика или нейтронной звезды вызвал повреждение модуля
    /// Параметры:
    /// • Module: название модуля, получившего повреждения
    /// </summary>
    public class edEventJetConeDamage : edEvent
    {
        JetConeDamageEventArgs eArgs=null;
        public edEventJetConeDamage(JetConeDamageEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие JoinACrew
    /// Когда происходит: когда игрок присоединяется к команде корабля другого игрока
    /// Параметры:
    /// • Captain: имя командира, в команду которого присоединился игрок
    /// </summary>
    public class edEventJoinACrew : edEvent
    {
        JoinACrewEventArgs eArgs=null;
        public edEventJoinACrew(JoinACrewEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие JoinedSquadron
    /// Когда происходит: когда игрок присоединяется к эскадре
    /// Параметры:
    /// • SquadronName: имя эскадры
    /// </summary>
    public class edEventJoinedSquadron : edEvent
    {
        JoinedSquadronEventArgs eArgs=null;
        public edEventJoinedSquadron(JoinedSquadronEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие KickCrewMember
    /// Когда происходит: когда игрок заставляет другого игрока покинуть команду своего корабля
    /// Параметры:
    /// • Crew: имя пилота
    /// • OnCrime: true, если игрок автоматически исключается за совершение преступления в законном сеансе
    /// </summary>
    public class edEventKickCrewMember : edEvent
    {
        KickCrewMemberEventArgs eArgs=null;
        public edEventKickCrewMember(KickCrewMemberEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие KickedFromSquadron
    /// Когда происходит: Выкинут из эскадрильи
    /// Параметры:
    /// • SquadronName: эскадра
    /// </summary>
    public class edEventKickedFromSquadron : edEvent
    {
        KickedFromSquadronEventArgs eArgs=null;
        public edEventKickedFromSquadron(KickedFromSquadronEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие LaunchDrone
    /// Когда происходит: при использовании любого типа дрона
    /// Параметры:
    /// • Type: тип дрона ("Hatchbreaker", "FuelTransfer", "Collection", "Prospector", "Repair", "Research", "Decontamination")
    /// </summary>
    public class edEventLaunchDrone : edEvent
    {
        LaunchDroneEventArgs eArgs=null;
        public edEventLaunchDrone(LaunchDroneEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие LaunchFighter
    /// Когда происходит: при запуске истребителя
    /// Параметры:
    /// • Loadout: экипировка
    /// • PlayerControlled: контролирует ли игрок истребитель с момента запуска (да/нет)
    /// • ID: 
    /// </summary>
    public class edEventLaunchFighter : edEvent
    {
        LaunchFighterEventArgs eArgs=null;
        public edEventLaunchFighter(LaunchFighterEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие LaunchSRV
    /// Когда происходит: вывод SRV с корабля на поверхность планеты
    /// Параметры:
    /// • Loadout: экипировка
    /// • ID: 
    /// </summary>
    public class edEventLaunchSRV : edEvent
    {
        LaunchSRVEventArgs eArgs=null;
        public edEventLaunchSRV(LaunchSRVEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие LeaveBody
    /// Когда происходит: при взлёте с планеты и увеличении расстояния выше высоты орбитального круиза
    /// Параметры:
    /// • StarSystem: система
    /// • SystemAddress: координаты
    /// • Body: небесное тело
    /// • BodyID: идентификатор небесного тела
    /// </summary>
    public class edEventLeaveBody : edEvent
    {
        LeaveBodyEventArgs eArgs=null;
        public edEventLeaveBody(LeaveBodyEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие LeftSquadron
    /// Когда происходит: когда игрок покидает эскадру
    /// Параметры:
    /// • SquadronName: эскадра
    /// </summary>
    public class edEventLeftSquadron : edEvent
    {
        LeftSquadronEventArgs eArgs=null;
        public edEventLeftSquadron(LeftSquadronEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Liftoff
    /// Когда происходит: при взлете с поверхности планеты
    /// Параметры:
    /// • Latitude: широта
    /// • Longitude: долгота
    /// • NearestDestination: ближайшее место назначения
    /// • PlayerControlled: false, если корабль отпущен, когда игрок находится в SRV (ного?), true, если взлетает игрок
    /// </summary>
    public class edEventLiftoff : edEvent
    {
        LiftoffEventArgs eArgs=null;
        public edEventLiftoff(LiftoffEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие LoadGame
    /// Когда происходит: при запуске, при загрузке из главного меню в игру
    /// Параметры:
    /// • Commander: имя командира
    /// • FID: 
    /// • Horizons: горизонты? (да/нет)
    /// • Ship: тип текущего корабля
    /// • ShipID: идентификатор корабля
    /// • StartLanded: только если корабль приземлён
    /// • StartDead: запуск в убиенном состоянии
    /// • GameMode: режим игры (Open, Solo, Group)
    /// • Group: имя группы
    /// • Credits: текущий баланс кредитов
    /// • Loan: текущий заём
    /// • ShipName: заданное игроком имя корабля
    /// • ShipIdent: заданный игроком идентификатор корабля
    /// • FuelLevel: уровень топлива
    /// • FuelCapacity: размер основного бака
    /// • Language: 
    /// • GameVersion: 
    /// • Build: 
    /// </summary>
    public class edEventLoadGame : edEvent
    {
        LoadGameEventArgs eArgs=null;
        public edEventLoadGame(LoadGameEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие LoadoutEquipModule
    /// Когда происходит: при установке модуля снаряжения
    /// Параметры:
    /// • SuitID: идентификатор костюма
    /// • SuitName: наименование костюма
    /// • LoadoutID: идентификатор экипировки
    /// • LoadoutName: наименование экипировки
    /// • ModuleName: наименование модуля
    /// • SuitModuleID: идентификатор модуля костюма
    /// • Class: класс
    /// • WeaponMods: модификация оружия
    /// </summary>
    public class edEventLoadoutEquipModule : edEvent
    {
        LoadoutEquipModuleEventArgs eArgs=null;
        public edEventLoadoutEquipModule(LoadoutEquipModuleEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Loadout
    /// Когда происходит: при запуске, при загрузке из главного меню или при смене корабля, 
    /// или после смены корабля в снаряжении, или при стыковке SRV обратно в корабль-базу
    /// Параметры:
    /// • Ship: тип текущего корабля
    /// • ShipID: идентификационный номер корабля (показывает, на каком из кораблей находится игрок)
    /// • ShipName: имя корабля, назначенное игроком
    /// • ShipIdent: индентификатор корабля, назначенный игроком
    /// • HullValue: объём корпуса (может не всегда присутствовать)
    /// • ModulesValue: объём модулей (может не всегда присутствовать)
    /// • HullHealth: целостность корпуса
    /// • UnladenMass: Масса корпуса и модулей без учета топлива и груза
    /// • FuelCapacity: объём бака { Main: , Reserve: }
    /// • CargoCapacity: объём грузовых отсеков
    /// • MaxJumpRange: максимальный доступный прыжок (при нулевом грузе и достаточном количестве топлива на 1 прыжок)
    /// • Rebuy: 
    /// • Hot: розыск
    /// • Modules: там куча всего. Проще поглядеть F12 на LoadoutEventArgs
    /// </summary>
    public class edEventLoadout : edEvent
    {
        LoadoutEventArgs eArgs=null;
        public edEventLoadout(LoadoutEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие LoadoutRemoveModule
    /// Когда происходит: 
    /// Параметры:
    /// • SuitID: 
    /// • SuitName: 
    /// • LoadoutID: 
    /// • LoadoutName: 
    /// • ModuleName: 
    /// • SuitModuleID: 
    /// • Class: 
    /// • WeaponMods: 
    /// </summary>
    public class edEventLoadoutRemoveModule : edEvent
    {
        LoadoutRemoveModuleEventArgs eArgs=null;
        public edEventLoadoutRemoveModule(LoadoutRemoveModuleEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Location
    /// Когда происходит: при запуске игры или при воскрешении на станции
    /// Параметры:
    /// • StarSystem: название звездной системы
    /// • SystemAddress: 
    /// • StarPos: положение звезды в виде массива Json [x, y, z] в световых годах
    /// • Body: имя звезды
    /// • BodyID: 
    /// • BodyType: 
    /// • Docked: 
    /// • Latitude: 
    /// • Longitude: 
    /// • StationName: 
    /// • StationType: 
    /// • MarketID: 
    /// • StationFaction: 
    /// • StationGovernment: 
    /// • StationAllegiance: 
    /// • StationServices: 
    /// • StationEconomies: 
    /// • SystemFaction: 
    /// • SystemAllegiance: 
    /// • SystemEconomy: 
    /// • SystemSecondEconomy: 
    /// • SystemGovernment: 
    /// • SystemSecurity: 
    /// • Wanted: 
    /// • Population: 
    /// • Powers: 
    /// • PowerplayState: 
    /// • Factions: 
    /// • Conflicts: 
    /// </summary>
    public class edEventLocation : edEvent
    {
        LocationEventArgs eArgs=null;
        public edEventLocation(LocationEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MarketBuy
    /// Когда происходит: при покупке товара на станции
    /// Параметры:
    /// • MarketID: 
    /// • Type: 
    /// • Count: 
    /// • BuyPrice: 
    /// • TotalCost: 
    /// </summary>
    public class edEventMarketBuy : edEvent
    {
        MarketBuyEventArgs eArgs=null;
        public edEventMarketBuy(MarketBuyEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Market
    /// Когда происходит: при входе на товарный рынок на станции.
    /// В ту же папку, что и журнал, записывается отдельный файл market.json, содержащий полную информацию о рыночных ценах.
    /// Параметры:
    /// • StationName: 
    /// • MarketID: 
    /// • StarSystem: 
    /// Подробности по F12 на MarketEventArgs
    /// </summary>
    public class edEventMarket : edEvent
    {
        MarketEventArgs eArgs=null;
        public edEventMarket(MarketEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MarketRefined
    /// Когда происходит: когда руда перерабатывается в единицу груза
    /// Параметры:
    /// • Type: тип груза
    /// </summary>
    public class edEventMarketRefined : edEvent
    {
        MarketRefinedEventArgs eArgs=null;
        public edEventMarketRefined(MarketRefinedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MarketSell
    /// Когда происходит: при продаже товаров на рынке
    /// Параметры:
    /// • MarketID: 
    /// • Type: тип груза
    /// • Count: количество единиц
    /// • SellPrice: цена за единицу
    /// • TotalSale: общая стоимость продажи
    /// • AvgPricePaid: средняя уплаченная цена
    /// • IllegalGoods: являются ли товары здесь незаконными
    /// • StolenGoods: были ли украдены товары
    /// • BlackMarket: продано ли на черном рынке
    /// </summary>
    public class edEventMarketSell : edEvent
    {
        MarketSellEventArgs eArgs=null;
        public edEventMarketSell(MarketSellEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MassModuleStore
    /// Когда происходит: при помещении нескольких модулей в хранилище
    /// Параметры:
    /// • Ship: 
    /// • ShipID: 
    /// • Items: Массив записей:
    ///     • Slot: 
    ///     • Name: 
    ///     • EngineerModifications: 
    ///     • Level: 
    ///     • Quality: 
    ///     • Hot: 
    /// </summary>
    public class edEventMassModuleStore : edEvent
    {
        MassModuleStoreEventArgs eArgs=null;
        public edEventMassModuleStore(MassModuleStoreEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MaterialCollected
    /// Когда происходит: всякий раз, когда собираются материалы
    /// Параметры:
    /// • Category: тип материала (Raw/Encoded/Manufactured)
    /// • Name: название материала
    /// • Count: количество
    /// </summary>
    public class edEventMaterialCollected : edEvent
    {
        MaterialCollectedEventArgs eArgs=null;
        public edEventMaterialCollected(MaterialCollectedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MaterialDiscarded
    /// Когда происходит: всякий раз, когда выбрасываются материалы
    /// Параметры:
    /// • Category: тип материала (Raw/Encoded/Manufactured)
    /// • Name: название материала
    /// • Count: количество
    /// </summary>
    public class edEventMaterialDiscarded : edEvent
    {
        MaterialDiscardedEventArgs eArgs=null;
        public edEventMaterialDiscarded(MaterialDiscardedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MaterialDiscovered
    /// Когда происходит: при обнаружении нового материала
    /// Параметры:
    /// • Category: тип материала (Raw/Encoded/Manufactured)
    /// • Name: название материала
    /// • DiscoveryNumber: 
    /// 
    /// </summary>
    public class edEventMaterialDiscovered : edEvent
    {
        MaterialDiscoveredEventArgs eArgs=null;
        public edEventMaterialDiscovered(MaterialDiscoveredEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Materials
    /// Когда происходит: 
    /// Параметры:
    /// • Raw: 
    /// • Manufactured: 
    /// • Encoded: 
    /// </summary>
    public class edEventMaterials : edEvent
    {
        MaterialsEventArgs eArgs=null;
        public edEventMaterials(MaterialsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MaterialTrade
    /// Когда происходит: при обмене материалами в контакте с торговцем материалами
    /// Параметры:
    /// • MarketID: 
    /// • TraderType: 
    /// • Paid: 
    ///     • Material: 
    ///     • Category: 
    ///     • Quantity: 
    /// • Received: 
    ///     • Material: 
    ///     • Category: 
    ///     • Quantity: 
    /// </summary>
    public class edEventMaterialTrade : edEvent
    {
        MaterialTradeEventArgs eArgs=null;
        public edEventMaterialTrade(MaterialTradeEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MiningRefined
    /// Когда происходит: при добыче материала
    /// Параметры:
    /// • Type: тип груза
    /// </summary>
    public class edEventMiningRefined : edEvent
    {
        MiningRefinedEventArgs eArgs=null;
        public edEventMiningRefined(MiningRefinedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MissionAbandoned
    /// Когда происходит: когда миссия была заброшена
    /// Параметры:
    /// • Name: название миссии
    /// • MissionID: 
    /// • Fine: штраф
    /// </summary>
    public class edEventMissionAbandoned : edEvent
    {
        MissionAbandonedEventArgs eArgs=null;
        public edEventMissionAbandoned(MissionAbandonedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MissionAccepted
    /// Когда происходит: при запуске миссии
    /// Параметры:
    /// • MissionID: 
    /// • Name: название миссии
    /// • Faction: фракция-заказчик
    /// • Influence: Воздействие на влияние (None/Low/Med/High)
    /// • Reputation: Воздействие на репутацию (None/Low/Med/High)
    /// • Reward: ожидаемое денежное вознаграждение
    /// • Wing: миссия крыла
    /// Дополнительные параметры (в зависимости от типа миссии)
    /// • Commodity: вид товара
    /// • Count: необходимое количество / для доставки
    /// • Target: название цели
    /// • TargetType: тип цели
    /// • TargetFaction: фракция цели
    /// • KillCount: 
    /// • Expiry: 
    /// • DestinationSystem: 
    /// • DestinationStation: 
    /// • PassengerCount: 
    /// • PassengerVIPs: 
    /// • PassengerWanted: 
    /// • PassengerType: 
    /// • Donation: 
    /// • Donated: 
    /// </summary>
    public class edEventMissionAccepted : edEvent
    {
        MissionAcceptedEventArgs eArgs=null;
        public edEventMissionAccepted(MissionAcceptedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MissionCompleted
    /// Когда происходит: когда миссия завершена
    /// Параметры:
    /// • Faction: 
    /// • Name: 
    /// • MissionID: 
    /// • Commodity: 
    /// • Count: 
    /// • Target: 
    /// • TargetType: 
    /// • TargetFaction: 
    /// • Reward: 
    /// • Donation: 
    /// • Donated: 
    /// • PermitsAwarded: 
    /// • CommodityReward: 
    /// • MaterialReward: 
    /// • FactionEffects: 
    /// </summary>
    public class edEventMissionCompleted : edEvent
    {
        MissionCompletedEventArgs eArgs=null;
        public edEventMissionCompleted(MissionCompletedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MissionFailed
    /// Когда происходит: когда миссия провалена
    /// Параметры:
    /// • Name: имя миссии
    /// • MissionID: 
    /// • Fine: штраф
    /// </summary>
    public class edEventMissionFailed : edEvent
    {
        MissionFailedEventArgs eArgs=null;
        public edEventMissionFailed(MissionFailedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MissionRedirected
    /// Когда происходит: когда миссия обновляется с новым пунктом назначения
    /// Параметры:
    /// • MissionID: 
    /// • MissionName: 
    /// • NewDestinationStation: 
    /// • OldDestinationStation: 
    /// • NewDestinationSystem: 
    /// • OldDestinationSystem: 
    /// </summary>
    public class edEventMissionRedirected : edEvent
    {
        MissionRedirectedEventArgs eArgs=null;
        public edEventMissionRedirected(MissionRedirectedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Missions
    /// Когда происходит: при запуске
    /// Параметры:
    /// • Active: 
    /// • Failed: 
    /// • Complete: 
    /// Каждый объект содержит:
    /// • MissionID: 
    /// • Name: 
    /// • PassengerMission: 
    /// • Expires: срок истечения (оставшееся время в секундах)
    /// </summary>
    public class edEventMissions : edEvent
    {
        MissionsEventArgs eArgs=null;
        public edEventMissions(MissionsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ModuleBuy
    /// Когда происходит: при покупке модуля в снаряжение
    /// Параметры:
    /// • MarketID: 
    /// • Slot: слот снаряжения
    /// • BuyItem: покупаемый модуль
    /// • BuyPrice: уплаченная цена
    /// • Ship: корабль игрока
    /// • ShipID: 
    /// При замене существующего модуля:
    /// • SellItem: проданный модуль
    /// • SellPrice: цена продажи
    /// </summary>
    public class edEventModuleBuy : edEvent
    {
        ModuleBuyEventArgs eArgs=null;
        public edEventModuleBuy(ModuleBuyEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ModuleInfo
    /// Когда происходит: 
    /// Параметры: нет
    /// </summary>
    public class edEventModuleInfo : edEvent
    {
        ModuleInfoEventArgs eArgs=null;
        public edEventModuleInfo(ModuleInfoEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ModuleRetrieve
    /// Когда происходит: при установке ранее сохраненного в хранилище модуля
    /// Параметры:
    /// • MarketID: 
    /// • Slot: 
    /// • Ship: 
    /// • ShipID: 
    /// • RetrievedItem: 
    /// • EngineerModifications: название чертежа модификации (если есть)
    /// • Level: 
    /// • Quality: 
    /// • Hot: 
    /// • SwapOutItem: убранный в хранилище модуль (если слот не был пустым)
    /// • Cost: 
    /// </summary>
    public class edEventModuleRetrieve : edEvent
    {
        ModuleRetrieveEventArgs eArgs=null;
        public edEventModuleRetrieve(ModuleRetrieveEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ModuleSell
    /// Когда происходит: при продаже модуля
    /// Параметры:
    /// • MarketID: 
    /// • Slot: 
    /// • SellItem: 
    /// • SellPrice: 
    /// • Ship: 
    /// • ShipID: 
    /// </summary>
    public class edEventModuleSell : edEvent
    {
        ModuleSellEventArgs eArgs=null;
        public edEventModuleSell(ModuleSellEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ModuleSellRemote
    /// Когда происходит: при удалённой продаже модуля
    /// Параметры:
    /// • StorageSlot: 
    /// • SellItem: 
    /// • SellPrice: 
    /// • Ship: 
    /// • ShipID: 
    /// • ServerId: 
    /// </summary>
    public class edEventModuleSellRemote : edEvent
    {
        ModuleSellRemoteEventArgs eArgs=null;
        public edEventModuleSellRemote(ModuleSellRemoteEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ModulesInfo
    /// Когда происходит: при просмотре информационной панели модулей RHS в кабине, если данные изменились.
    /// Это также записывает файл ModulesInfo.json вместе с журналом, перечисляя модули в том же порядке, в котором они отображаются.
    /// Параметры: нету
    /// </summary>
    public class edEventModulesInfo : edEvent
    {
        ModulesInfoEventArgs eArgs=null;
        public edEventModulesInfo(ModulesInfoEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ModuleStore
    /// Когда происходит: при получении ранее сохраненного модуля
    /// Параметры:
    /// • MarketID: 
    /// • Slot: 
    /// • Ship: 
    /// • ShipID: 
    /// • StoredItem: 
    /// • EngineerModifications: название чертежа модификации (если есть)
    /// • Level: 
    /// • Quality: 
    /// • Hot: 
    /// • ReplacementItem: заменённый модуль
    /// • Cost: 
    /// </summary>
    public class edEventModuleStore : edEvent
    {
        ModuleStoreEventArgs eArgs=null;
        public edEventModuleStore(ModuleStoreEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ModuleSwap
    /// Когда происходит: при перемещении модуля в другой слот на корабле
    /// Параметры:
    /// • MarketID: 
    /// • FromSlot: 
    /// • ToSlot: 
    /// • FromItem: 
    /// • ToItem: 
    /// • Ship: 
    /// • ShipID: 
    /// </summary>
    public class edEventModuleSwap : edEvent
    {
        ModuleSwapEventArgs eArgs=null;
        public edEventModuleSwap(ModuleSwapEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие MultiSellExplorationData
    /// Когда происходит: при продаже геоданных в Картографии
    /// Параметры:
    /// • Systems: JSON-массив имен систем
    /// • Discovered: JSON-массив обнаруженных тел
    /// • BaseValue: ценность систем
    /// • Bonus: бонус за первые открытия
    /// • TotalEarnings: общее количество полученных кредитов (включая, например, 200% бонус при 5-м ранге у Li Yong Rui)
    /// </summary>
    public class edEventMultiSellExplorationData : edEvent
    {
        MultiSellExplorationDataEventArgs eArgs=null;
        public edEventMultiSellExplorationData(MultiSellExplorationDataEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Music
    /// Когда происходит: когда меняется режим игровой музыки
    /// Параметры:
    /// • MusicTrack: название трека
    /// Возможные названия треков:
    /// NoTrack, MainMenu, CQCMenu, SystemMap, GalaxyMap, GalacticPowers, CQC, 
    /// DestinationFromHyperspace, DestinationFromSupercruise, Supercruise, 
    /// Combat_Unknown, Unknown_Encounter, CapitalShip, CombatLargeDogFight, 
    /// Combat_Dogfight, Combat_SRV, Unknown_Settlement, DockingComputer, 
    /// Starport, Unknown_Exploration, Exploration
    /// Примечание. В будущем могут использоваться другие названия музыкальных треков.
    /// </summary>
    public class edEventMusic : edEvent
    {
        MusicEventArgs eArgs=null;
        public edEventMusic(MusicEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие NavBeaconScan
    /// Когда происходит: при сканировании навигационного маяка, до того, как данные сканирования всех тел в системе будут записаны в журнал
    /// Параметры:
    /// • NumBodies: количество небесных тел
    /// • SystemAddress: 
    /// </summary>
    public class edEventNavBeaconScan : edEvent
    {
        NavBeaconScanEventArgs eArgs=null;
        public edEventNavBeaconScan(NavBeaconScanEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие NavRoute
    /// Когда происходит: точка маршрута
    /// Параметры:
    /// • StarSystem: система
    /// • SystemAddress: адрес
    /// • StarPos: координаты X, Y, Z
    /// • StarClass: класс звезды
    /// </summary>
    public class edEventNavRoute : edEvent
    {
        NavRouteEventArgs eArgs=null;
        public edEventNavRoute(NavRouteEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие NewCommander
    /// Когда происходит: Создание нового командира
    /// Параметры:
    /// • Name: (новое) имя командира
    /// • Package: выбранный стартовый пакет
    /// </summary>
    public class edEventNewCommander : edEvent
    {
        NewCommanderEventArgs eArgs=null;
        public edEventNewCommander(NewCommanderEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие NpcCrewPaidWage
    /// Когда происходит: когда экипаж получает заработную плату
    /// Параметры:
    /// • NpcCrewId: 
    /// • Amount: 
    /// </summary>
    public class edEventNpcCrewPaidWage : edEvent
    {
        NpcCrewPaidWageEventArgs eArgs=null;
        public edEventNpcCrewPaidWage(NpcCrewPaidWageEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие NpcCrewRank
    /// Когда происходит: при повышении боевого звания члена экипажа.
    /// Параметры:
    /// • NpcCrewId: 
    /// • RankCombat: 
    /// </summary>
    public class edEventNpcCrewRank : edEvent
    {
        NpcCrewRankEventArgs eArgs=null;
        public edEventNpcCrewRank(NpcCrewRankEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Outfitting
    /// Когда происходит: при доступе к меню экипировки
    /// Полный прайс-лист на запчасти записан в отдельный файл Outfitting.json.
    /// Параметры:
    /// • StationName: 
    /// • MarketID: 
    /// • StarSystem: 
    /// Отдельный файл также содержит
    /// • Items: массив объектов
    ///     • id: 
    ///     • Name: 
    ///     • BuyPrice: 
    /// </summary>
    public class edEventOutfitting : edEvent
    {
        OutfittingEventArgs eArgs=null;
        public edEventOutfitting(OutfittingEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Passengers
    /// Когда происходит: ???
    /// Параметры:
    /// • Manifest: массив записей о пассажирах:
    ///     • MissionID: 
    ///     • Type: 
    ///     • VIP: 
    ///     • Wanted: 
    ///     • Count: 
    /// </summary>
    public class edEventPassengers : edEvent
    {
        PassengersEventArgs eArgs=null;
        public edEventPassengers(PassengersEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PayBounties
    /// Когда происходит: при выплате наград
    /// Параметры:
    /// • Amount: общая выплаченная сумма, включая комиссию брокера
    /// • BrokerPercentage: комиссия брокера (при оплате через брокера)
    /// • Faction: 
    /// • ShipID: 
    /// </summary>
    public class edEventPayBounties : edEvent
    {
        PayBountiesEventArgs eArgs=null;
        public edEventPayBounties(PayBountiesEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PayFines
    /// Когда происходит: при уплате штрафов
    /// Параметры:
    /// • Amount: общая выплаченная сумма, включая комиссию брокера
    /// • BrokerPercentage: комиссия брокера (при оплате через брокера)
    /// • AllFines: все штрафы? (да/нет)
    /// • Faction: (при оплате штрафов отдельной фракции)
    /// • ShipID: 
    /// </summary>
    public class edEventPayFines : edEvent
    {
        PayFinesEventArgs eArgs=null;
        public edEventPayFines(PayFinesEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PayLegacyFines
    /// Когда происходит: при уплате унаследованных штрафов
    /// Параметры:
    /// • Amount: общая выплаченная сумма, включая комиссию брокера
    /// • BrokerPercentage: комиссия брокера (при оплате через брокера)
    /// </summary>
    public class edEventPayLegacyFines : edEvent
    {
        PayLegacyFinesEventArgs eArgs=null;
        public edEventPayLegacyFines(PayLegacyFinesEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PowerplayCollect
    /// Когда происходит: при сборе товаров powerplay для доставки
    /// Параметры:
    /// • Power: имя силы
    /// • Type: тип товара
    /// • Count: количество единиц
    /// </summary>
    public class edEventPowerplayCollect : edEvent
    {
        PowerplayCollectEventArgs eArgs=null;
        public edEventPowerplayCollect(PowerplayCollectEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PowerplayDefect
    /// Когда происходит: когда игрок переходит от одной силы к другой
    /// Параметры:
    /// • FromPower: имя силы, от которой ушёл
    /// • ToPower: имя силы, в которую пришёл
    /// </summary>
    public class edEventPowerplayDefect : edEvent
    {
        PowerplayDefectEventArgs eArgs=null;
        public edEventPowerplayDefect(PowerplayDefectEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PowerplayDeliver
    /// Когда происходит: при доставке товаров powerplay
    /// Параметры:
    /// • Power: имя силы
    /// • Type: тип товара
    /// • Count: количество единиц
    /// </summary>
    public class edEventPowerplayDeliver : edEvent
    {
        PowerplayDeliverEventArgs eArgs=null;
        public edEventPowerplayDeliver(PowerplayDeliverEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Powerplay
    /// Когда происходит: при запуске, если игрок присягнул ПП-силе
    /// Параметры:
    /// • Power: имя силы
    /// • Rank: ранг
    /// • Merits: набранные очки
    /// • Votes: количество голосов
    /// • TimePledged: время нахождения в силе (в секундах)
    /// </summary>
    public class edEventPowerplay : edEvent
    {
        PowerplayEventArgs eArgs=null;
        public edEventPowerplay(PowerplayEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PowerplayFastTrack
    /// Когда происходит: при оплате ускоренного получения товаров
    /// Параметры:
    /// • Power: имя силы
    /// • Cost: расходы
    /// </summary>
    public class edEventPowerplayFastTrack : edEvent
    {
        PowerplayFastTrackEventArgs eArgs=null;
        public edEventPowerplayFastTrack(PowerplayFastTrackEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PowerplayJoin
    /// Когда происходит: при присоединении к ПП-силе
    /// Параметры:
    /// • Power: имя силы
    /// </summary>
    public class edEventPowerplayJoin : edEvent
    {
        PowerplayJoinEventArgs eArgs=null;
        public edEventPowerplayJoin(PowerplayJoinEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PowerplayLeave
    /// Когда происходит: при выходе из ПП-силы
    /// Параметры:
    /// • Power: имя силы
    /// </summary>
    public class edEventPowerplayLeave : edEvent
    {
        PowerplayLeaveEventArgs eArgs=null;
        public edEventPowerplayLeave(PowerplayLeaveEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PowerplaySalary
    /// Когда происходит: при получении зарплаты от ПП-силы
    /// Параметры:
    /// • Power: имя силы
    /// • Amount: количество
    /// </summary>
    public class edEventPowerplaySalary : edEvent
    {
        PowerplaySalaryEventArgs eArgs=null;
        public edEventPowerplaySalary(PowerplaySalaryEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PowerplayVote
    /// Когда происходит: при голосовании за расширение системы
    /// Параметры:
    /// • Power: имя силы
    /// • Votes: голосов
    /// • System: система
    /// </summary>
    public class edEventPowerplayVote : edEvent
    {
        PowerplayVoteEventArgs eArgs=null;
        public edEventPowerplayVote(PowerplayVoteEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PowerplayVoucher
    /// Когда происходит: при получении оплаты за бой в режиме powerplay
    /// Параметры:
    /// • Power: имя силы
    /// • Systems: массив названий систем
    /// </summary>
    public class edEventPowerplayVoucher : edEvent
    {
        PowerplayVoucherEventArgs eArgs=null;
        public edEventPowerplayVoucher(PowerplayVoucherEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Progress
    /// Когда происходит: при запуске
    /// Параметры:
    /// • Combat: процент перехода к следующему боевому рангу
    /// • Trade: процент перехода к следующему торговому рангу
    /// • Explore: процент перехода к следующему исследовательскому рангу
    /// • Empire: процент перехода к следующему рангу Империи
    /// • Federation: процент перехода к следующему рангу Федерации
    /// • CQC: процент перехода к следующему рангу CQC
    /// </summary>
    public class edEventProgress : edEvent
    {
        ProgressEventArgs eArgs=null;
        public edEventProgress(ProgressEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Promotion
    /// Когда происходит: когда рейтинг игрока повышается
    /// Параметры:
    /// • Combat: новый боевой ранг
    /// • Trade: новый торговый ранг
    /// • Explore: новый исследовательский ранг
    /// • CQC: новый ранг CQC
    /// </summary>
    public class edEventPromotion : edEvent
    {
        PromotionEventArgs eArgs=null;
        public edEventPromotion(PromotionEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ProspectedAsteroid
    /// Когда происходит: при разведке астероида
    /// Параметры:
    /// • Materials: массив компонентов астероида
    /// • Content: 
    /// • MotherlodeMaterial: 
    /// • Percentage: 
    /// </summary>
    public class edEventProspectedAsteroid : edEvent
    {
        ProspectedAsteroidEventArgs eArgs=null;
        public edEventProspectedAsteroid(ProspectedAsteroidEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие PVPKill
    /// Когда происходит: когда этот игрок убил другого игрока
    /// Параметры:
    /// • Victim: имя жертвы
    /// • CombatRank: ранг жертвы в диапазоне 0–8
    /// </summary>
    public class edEventPVPKill : edEvent
    {
        PVPKillEventArgs eArgs=null;
        public edEventPVPKill(PVPKillEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие QuitACrew
    /// Когда происходит: Когда вы покидаете команду корабля другого игрока
    /// Параметры:
    /// • Captain: Имя командира рулевого
    /// </summary>
    public class edEventQuitACrew : edEvent
    {
        QuitACrewEventArgs eArgs=null;
        public edEventQuitACrew(QuitACrewEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Rank
    /// Когда происходит: при запуске
    /// Параметры:
    /// • Combat: рейтинг по шкале 0-8
    /// • Trade: рейтинг по шкале 0-8
    /// • Explore: рейтинг по шкале 0-8
    /// • Empire: воинское звание Империи
    /// • Federation: воинское звание Федерации
    /// • CQC: рейтинг по шкале 0-8
    /// Ранги:
    ///     • Боевой:               0='Harmless', 1='Mostly Harmless', 2='Novice', 3='Competent', 4='Expert',
    ///                             5='Master', 6='Dangerous', 7='Deadly', 8='Elite’
    ///                             
    ///     • Торговый:             0='Penniless', 1='Mostly Pennliess', 2='Peddler', 3='Dealer', 4='Merchant', 
    ///                             5='Broker', 6='Entrepreneur', 7='Tycoon', 8='Elite'
    ///                             
    ///     • Исследовательский:    0='Aimless', 1='Mostly Aimless', 2='Scout', 3='Surveyor', 4='Explorer', 
    ///                             5='Pathfinder', 6='Ranger', 7='Pioneer', 8='Elite'
    ///                             
    ///     • Федерация:            0='None', 1='Recruit', 2='Cadet', 3='Midshipman', 4='Petty Officer', 
    ///                             5='Chief Petty Officer', 6='Warrant Officer', 7='Ensign', 8='Lieutenant', 
    ///                             9='Lt. Commander', 10='Post Commander', 11= 'Post Captain', 12= 'Rear Admiral',
    ///                             13='Vice Admiral', 14=’Admiral’
    ///                             
    ///     • Имеприя:              0='None', 1='Outsider', 2='Serf', 3='Master', 4='Squire', 5='Knight', 6='Lord', 
    ///                             7='Baron',  8='Viscount ', 9=’Count', 10= 'Earl', 11='Marquis' 
    ///                             12='Duke', 13='Prince', 14=’King’
    ///                             
    ///     • CQC:                  0=’Helpless’, 1=’Mostly Helpless’, 2=’Amateur’, 3=’Semi Professional’, 4=’Professional’,
    ///                             5=’Champion’, 6=’Hero’, 7=’Legend’, 8=’Elite’
    /// </summary>
    public class edEventRank : edEvent
    {
        RankEventArgs eArgs=null;
        public edEventRank(RankEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие RebootRepair
    /// Когда происходит: когда используется функция «восстановление / перезагрузка»
    /// Параметры:
    /// • Modules: JSON-массив имен отремонтированных модулей
    /// </summary>
    public class edEventRebootRepair : edEvent
    {
        RebootRepairEventArgs eArgs=null;
        public edEventRebootRepair(RebootRepairEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ReceiveText
    /// Когда происходит: когда получено текстовое сообщение от другого игрока
    /// Параметры:
    /// • From: от (имя)
    /// • Message: сообщение
    /// • Channel: канал
    /// </summary>
    public class edEventReceiveText : edEvent
    {
        ReceiveTextEventArgs eArgs=null;
        public edEventReceiveText(ReceiveTextEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие RedeemVoucher
    /// Когда происходит: при требовании выплаты боевых наград и облигаций
    /// Параметры:
    /// • Type: 
    /// • Amount: 
    /// • Faction: 
    /// • BrokerPercentage: 
    /// • Factions: массив
    /// </summary>
    public class edEventRedeemVoucher : edEvent
    {
        RedeemVoucherEventArgs eArgs=null;
        public edEventRedeemVoucher(RedeemVoucherEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие RefuelAll
    /// Когда происходит: при заправке (полный бак)
    /// Параметры:
    /// • Cost: стоимость топлива
    /// • Amount: закуплено тонн топлива
    /// </summary>
    public class edEventRefuelAll : edEvent
    {
        RefuelAllEventArgs eArgs=null;
        public edEventRefuelAll(RefuelAllEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие RefuelPartial
    /// Когда происходит: при заправке (10%)
    /// Параметры:
    /// • Cost: стоимость топлива
    /// • Amount: закуплено тонн топлива
    /// </summary>
    public class edEventRefuelPartial : edEvent
    {
        RefuelPartialEventArgs eArgs=null;
        public edEventRefuelPartial(RefuelPartialEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие RenameSuitLoadout
    /// Когда происходит: при переименовании экипировки костюма
    /// Параметры:
    /// • SuitID: 
    /// • SuitName: 
    /// • LoadoutID: 
    /// • LoadoutName: 
    /// </summary>
    public class edEventRenameSuitLoadout : edEvent
    {
        RenameSuitLoadoutEventArgs eArgs=null;
        public edEventRenameSuitLoadout(RenameSuitLoadoutEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие RepairAll
    /// Когда происходит: при полной починке
    /// Параметры:
    /// • Cost: стоимость починки
    /// </summary>
    public class edEventRepairAll : edEvent
    {
        RepairAllEventArgs eArgs=null;
        public edEventRepairAll(RepairAllEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие RepairDrone
    /// Когда происходит: когда корабль игрока отремонтирован ремонтным дроном
    /// Параметры:
    /// • HullRepaired: корпус
    /// • CockpitRepaired: фонарь
    /// • CorrosionRepaired: коррозия
    /// Каждый из пунктов представляет собой число, обозначающее количество отремонтированных повреждений
    /// </summary>
    public class edEventRepairDrone : edEvent
    {
        RepairDroneEventArgs eArgs=null;
        public edEventRepairDrone(RepairDroneEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Repair
    /// Когда происходит: при ремонте корабля
    /// Параметры:
    /// • Item: все, износ, корпус, окраска или название модуля
    /// • Items: массив модулей
    /// • Cost: стоимость ремонта
    /// </summary>
    public class edEventRepair : edEvent
    {
        RepairEventArgs eArgs=null;
        public edEventRepair(RepairEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Reputation
    /// Когда происходит: при запуске (после ранга и прогресса)
    /// отображает репутацию игрока в сверхдержавах (по шкале -100 .. + 100).
    /// Параметры:
    /// • Empire: 
    /// • Federation: 
    /// • Independent: 
    /// • Alliance: 
    /// Градации:
    /// • -100.. -90: враждебный
    /// • -90.. -35: недружественный
    /// • -35..+ 4: нейтральный
    /// • +4..+35: приветливый
    /// • +35..+90: дружественный
    /// • +90..+100: союзный
    /// </summary>
    public class edEventReputation : edEvent
    {
        ReputationEventArgs eArgs=null;
        public edEventReputation(ReputationEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ReservoirReplenished
    /// Когда происходит: при пополнении топливного резервуара из основного бака
    /// Параметры:
    /// • FuelMain: 
    /// • FuelReservoir: 
    /// </summary>
    public class edEventReservoirReplenished : edEvent
    {
        ReservoirReplenishedEventArgs eArgs=null;
        public edEventReservoirReplenished(ReservoirReplenishedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие RestockVehicle
    /// Когда происходит: при покупке SRV или Fighter
    /// Параметры:
    /// • Type: тип приобретаемой техники (модель SRV или Fighter)
    /// • Loadout: 
    /// • Cost: стоимость покупки
    /// • Count: количество купленной техники
    /// </summary>
    public class edEventRestockVehicle : edEvent
    {
        RestockVehicleEventArgs eArgs=null;
        public edEventRestockVehicle(RestockVehicleEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Resurrect
    /// Когда происходит: когда игрок перезагружается после смерти
    /// Параметры:
    /// • Option: вариант, выбранный на экране повторной покупки по страховке
    /// • Cost: заплаченная цена
    /// • Bankrupt: объявил ли командир банкротство (да/нет)
    /// </summary>
    public class edEventResurrect : edEvent
    {
        ResurrectEventArgs eArgs=null;
        public edEventResurrect(ResurrectEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Route
    /// Когда происходит: При построении маршрута с несколькими звездами,
    ///                   файл Route.json записывается в том же каталоге, 
    ///                   что и журнал, со списком звезд на этом маршруте.
    /// Параметры:
    /// • Route: список точек маршрута (List<RouteElement>)
    /// 
    /// Пример:
    /// { "timestamp":"2020-04-27T08:02:52Z", "event":"Route", "Route":[ 
    /// { "StarSystem":1733120004818, "StarPos":[-19.75000,41.78125,-3.18750], "StarClass":"K" }, 
    /// { "StarSystem":5068732704169, "StarPos":[-15.25000,39.53125,-2.25000], "StarClass":"M" }
    ///  ] }
    /// 
    /// Это может быть изменено в окончательной версии 3.7, 
    /// чтобы использовать имя тега «SystemAddress» 
    /// вместо «StarSystem» для большей согласованности.
    /// </summary>
    public class edEventRoute : edEvent
    {
        RouteEventArgs eArgs=null;
        public edEventRoute(RouteEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SAAScanComplete
    /// Когда происходит: после использования сканера «Анализ площади поверхности» (SAA)
    /// Параметры:
    /// • SystemAddress: 
    /// • BodyName: 
    /// • BodyID: 
    /// • ProbesUsed: количество использованных зондов
    /// • EfficiencyTarget: эффективность
    /// </summary>
    public class edEventSAAScanComplete : edEvent
    {
        SAAScanCompleteEventArgs eArgs=null;
        public edEventSAAScanComplete(SAAScanCompleteEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SAASignalsFound
    /// Когда происходит: при использовании сканера SAA на планете или кольцах
    /// Параметры:
    /// • SystemAddress: 
    /// • BodyName: 
    /// • BodyID: 
    /// • Signals: массив сигналов:
    ///     • Type
    ///     • Count
    /// </summary>
    public class edEventSAASignalsFound : edEvent
    {
        SAASignalsFoundEventArgs eArgs=null;
        public edEventSAASignalsFound(SAASignalsFoundEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Scan
    /// Когда происходит: детальное сканирование звезды, планеты или спутника
    /// Параметры:
    /// • дохренища, см.здесь: F12 по ScanEventArgs
    /// </summary>
    public class edEventScan : edEvent
    {
        ScanEventArgs eArgs=null;
        public edEventScan(ScanEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Scanned
    /// Когда происходит: когда корабль игрока просканирован
    /// (обратите внимание, что индикация «Обнаружено сканирование» находится в начале сканирования, 
    /// это же событие записывается в конце успешного сканирования)
    /// Параметры:
    /// • ScanType: Cargo, Crime, Cabin, Data or Unknown
    /// </summary>
    public class edEventScanned : edEvent
    {
        ScannedEventArgs eArgs=null;
        public edEventScanned(ScannedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ScanOrganic
    /// Когда происходит: при сканировании органики
    /// Параметры:
    /// • ScanType: 
    /// • Genus: род
    /// • Species: разновидность
    /// • SystemAddress: 
    /// • Body: 
    /// </summary>
    public class edEventScanOrganic : edEvent
    {
        ScanOrganicEventArgs eArgs=null;
        public edEventScanOrganic(ScanOrganicEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ScientificResearch
    /// Когда происходит: при предоставлении материалов для "исследовательской" цели сообщества
    /// Параметры:
    /// • MarketID: 
    /// • Name: наименование материала
    /// • Category: категория
    /// • Count: количество
    /// </summary>
    public class edEventScientificResearch : edEvent
    {
        ScientificResearchEventArgs eArgs=null;
        public edEventScientificResearch(ScientificResearchEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Screenshot
    /// Когда происходит: при сохранении снимка экрана
    /// Параметры:
    /// • Filename: имя файла скриншота
    /// • Width: ширина в пикселях
    /// • Height: высота в пикселях
    /// • System: текущая звездная система
    /// • Body: имя ближайшего небесного тела
    /// • Latitude: Широта и долгота будут включены, если вы находитесь на планете или в полете на малой высоте.
    /// • Longitude: 
    /// • Altitude: 
    /// • Heading: заголовок (???)
    /// </summary>
    public class edEventScreenshot : edEvent
    {
        ScreenshotEventArgs eArgs=null;
        public edEventScreenshot(ScreenshotEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SearchAndRescue
    /// Когда происходит: когда на станции игрок сдаёт предметы по контакту "поиск и спасение"
    /// Параметры:
    /// • MarketID: 
    /// • Name: наименование материала
    /// • Count: количество
    /// • Reward: награда
    /// </summary>
    public class edEventSearchAndRescue : edEvent
    {
        SearchAndRescueEventArgs eArgs=null;
        public edEventSearchAndRescue(SearchAndRescueEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SelfDestruct
    /// Когда происходит: когда используется функция «самоуничтожение»
    /// Параметры: Нет
    /// </summary>
    public class edEventSelfDestruct : edEvent
    {
        SelfDestructEventArgs eArgs=null;
        public edEventSelfDestruct(SelfDestructEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SellDrones
    /// Когда происходит: при продаже ненужных дронов обратно на рынок
    /// Параметры:
    /// • Type: 
    /// • Count: 
    /// • SellPrice: 
    /// • TotalSale: 
    /// </summary>
    public class edEventSellDrones : edEvent
    {
        SellDronesEventArgs eArgs=null;
        public edEventSellDrones(SellDronesEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SellExplorationData
    /// Когда происходит: при продаже геоданных в Картографике
    /// Параметры:
    /// • Systems: JSON-массив имен систем
    /// • Discovered: JSON-массив обнаруженных тел
    /// • BaseValue: ценность систем
    /// • Bonus: бонус за первые открытия
    /// • TotalEarnings: общее количество полученных кредитов (включая, например, 200% бонус при 5-м ранге у Li Yong Rui)
    /// </summary>
    public class edEventSellExplorationData : edEvent
    {
        SellExplorationDataEventArgs eArgs=null;
        public edEventSellExplorationData(SellExplorationDataEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SellMicroResources
    /// Когда происходит: при продаже геоданных в Картографике
    /// Параметры:
    /// • MicroResources: список микроресурсов (List<MicroResource>)
    /// • Price: цена
    /// • MarketID: 
    /// </summary>
    public class edEventSellMicroResources : edEvent
    {
        SellMicroResourcesEventArgs eArgs=null;
        public edEventSellMicroResources(SellMicroResourcesEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SellOrganicData
    /// Когда происходит: при продаже данных органики
    /// Параметры:
    /// • MarketID: 
    /// • BioData: список данных органики (List<BioData>)
    /// </summary>
    public class edEventSellOrganicData : edEvent
    {
        SellOrganicDataEventArgs eArgs=null;
        public edEventSellOrganicData(SellOrganicDataEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SellShipOnRebuy
    /// Когда происходит: При продаже сохраненного корабля для сбора средств на экране страхования / повторной покупки
    /// Параметры:
    /// • ShipType: 
    /// • SellShipID: 
    /// • ShipPrice: 
    /// • System: 
    /// </summary>
    public class edEventSellShipOnRebuy : edEvent
    {
        SellShipOnRebuyEventArgs eArgs=null;
        public edEventSellShipOnRebuy(SellShipOnRebuyEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SellSuit
    /// Когда происходит: При продаже костюма
    /// Параметры:
    /// • Name: наименование
    /// • Price: цена
    /// • SuitID: идентификатор
    /// • SuitMods: массив модификаций
    /// </summary>
    public class edEventSellSuit : edEvent
    {
        SellSuitEventArgs eArgs=null;
        public edEventSellSuit(SellSuitEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SellWeapon
    /// Когда происходит: При продаже костюма
    /// Параметры:
    /// • Name: наименование
    /// • Price: цена
    /// • SuitModuleID: идентификатор
    /// • Class: класс
    /// • WeaponMods: массив модификаций
    /// </summary>
    public class edEventSellWeapon : edEvent
    {
        SellWeaponEventArgs eArgs=null;
        public edEventSellWeapon(SellWeaponEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SendText
    /// Когда происходит: когда текстовое сообщение отправлено другому игроку
    /// Параметры:
    /// • To: кому
    /// • Message: сообщение
    /// • Channel: канал
    /// </summary>
    public class edEventSendText : edEvent
    {
        SendTextEventArgs eArgs=null;
        public edEventSendText(SendTextEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SetUserShipName
    /// Когда происходит: при присвоении названия кораблю в корабельных сервисах космопорта
    /// Параметры:
    /// • Ship: Модель корабля (например, CobraMkIII)
    /// • ShipID: идентификационный номер корабля игрока
    /// • UserShipName: выбранное имя
    /// • UserShipId: выбранный идентификатор
    /// </summary>
    public class edEventSetUserShipName : edEvent
    {
        SetUserShipNameEventArgs eArgs=null;
        public edEventSetUserShipName(SetUserShipNameEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SharedBookmarkToSquadron
    /// Когда происходит: когда игрок делится закладкой с эскадрой
    /// Параметры:
    /// • SquadronName: эскадра
    /// </summary>
    public class edEventSharedBookmarkToSquadron : edEvent
    {
        SharedBookmarkToSquadronEventArgs eArgs=null;
        public edEventSharedBookmarkToSquadron(SharedBookmarkToSquadronEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ShieldState
    /// Когда происходит: когда щиты отключены в бою или перезаряжаются
    /// Параметры:
    /// • ShieldsUp: 0 при отключении, 1 при восстановлении
    /// </summary>
    public class edEventShieldState : edEvent
    {
        ShieldStateEventArgs eArgs=null;
        public edEventShieldState(ShieldStateEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ShipLocker
    /// Когда происходит: Корабельный шкафчик
    /// Параметры: Нету. Вообще пустое событие - может не сделанное?
    /// </summary>
    public class edEventShipLocker : edEvent
    {
        ShipLockerEventArgs eArgs=null;
        public edEventShipLocker(ShipLockerEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ShipLockerMaterials
    /// Когда происходит: при запуске перечисляет содержимое судового хранилища
    /// Параметры:
    /// • Items: список предметов (List<Item>)
    /// • Components: список компонентов (List<Item>)
    /// • Consumables: список расходных материалов (List<Item>)
    /// • Data: список данных (List<Item>)
    /// </summary>
    public class edEventShipLockerMaterials : edEvent
    {
        ShipLockerMaterialsEventArgs eArgs=null;
        public edEventShipLockerMaterials(ShipLockerMaterialsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ShipTargeted
    /// Когда происходит: когда текущий игрок выбирает новую цель
    /// Количество записываемых данных зависит от степени сканирования целевого корабля.
    /// Параметры:
    /// • TargetLocked: Если цель зафиксирована:
    ///     • Ship: имя корабля
    ///     • ScanStage: стадия сканирования
    /// Если стадия сканирования > = 1
    ///     • PilotName: 
    ///     • PilotRank: 
    /// Если стадия сканирования > = 2
    ///     • ShieldHealth: 
    ///     • HullHealth: 
    /// Если стадия сканирования > = 3
    ///     • Faction: 
    ///     • LegalStatus: 
    ///     • Bounty: 
    ///     • SubSystem: 
    ///     • SubSystemHealth: 
    ///     • Power: 
    /// </summary>
    public class edEventShipTargeted : edEvent
    {
        ShipTargetedEventArgs eArgs=null;
        public edEventShipTargeted(ShipTargetedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ShipyardBuy
    /// Когда происходит: при покупке нового корабля на верфи
    /// Параметры:
    /// • MarketID: 
    /// • ShipType: купленный корабль
    /// • ShipPrice: стоимость покупки
    /// • StoreOldShip: (если прошлый корабль отправлен на склад) тип сохранённого корабля
    /// • StoreShipId: 
    /// • SellOldShip: (при продаже прошлого корабля) тип проданного корабля
    /// • SellShipId: 
    /// • SellPrice: (при продаже прошлого корабля) цена продажи корабля
    /// </summary>
    public class edEventShipyardBuy : edEvent
    {
        ShipyardBuyEventArgs eArgs=null;
        public edEventShipyardBuy(ShipyardBuyEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Shipyard
    /// Когда происходит: при входе на верфь на станции
    /// Параметры:
    /// • MarketID: 
    /// • StationName: 
    /// • StarSystem: 
    /// Полный прайс-лист записывается в отдельный файл в той же папке, что и журнал, Shipyard.json.
    /// • Pricelist: массив объектов:
    ///     • ShipType: 
    ///     • ShipPrice: 
    /// </summary>
    public class edEventShipyard : edEvent
    {
        ShipyardEventArgs eArgs=null;
        public edEventShipyard(ShipyardEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ShipyardNew
    /// Когда происходит: после покупки нового корабля
    /// Параметры:
    /// • MarketID: 
    /// • ShipType: 
    /// • NewShipID: 
    /// </summary>
    public class edEventShipyardNew : edEvent
    {
        ShipyardNewEventArgs eArgs=null;
        public edEventShipyardNew(ShipyardNewEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ShipyardSell
    /// Когда происходит: при продаже судна, хранящегося на верфи
    /// Параметры:
    /// • MarketID: 
    /// • ShipType: тип продаваемого корабля
    /// • SellShipID: 
    /// • ShipPrice: цена продажи
    /// • System: (если корабль находится в другой системе) название системы
    /// </summary>
    public class edEventShipyardSell : edEvent
    {
        ShipyardSellEventArgs eArgs=null;
        public edEventShipyardSell(ShipyardSellEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ShipyardSwap
    /// Когда происходит: при переключении на другой корабль, уже хранящийся на этой станции
    /// Параметры:
    /// • MarketID: 
    /// • ShipType: тип нового корабля
    /// • ShipID: 
    /// • StoreOldShip: (при отправке на хранение старого корабля) тип хранимого корабля
    /// • StoreShipId: 
    /// • SellOldShip: (при продаже старого корабля) тип продаваемого корабля
    /// • SellShipId: 
    /// • SellPrice: цена продажи
    /// </summary>
    public class edEventShipyardSwap : edEvent
    {
        ShipyardSwapEventArgs eArgs=null;
        public edEventShipyardSwap(ShipyardSwapEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие ShipyardTransfer
    /// Когда происходит: при запросе корабля с другой станции для перевозки на эту станцию
    /// Параметры:
    /// • MarketID: 
    /// • ShipType: тип корабля
    /// • ShipID: 
    /// • System: где это
    /// • Distance: как далеко
    /// • TransferPrice: стоимость доставки
    /// • TransferTime: время доставки в секундах
    /// </summary>
    public class edEventShipyardTransfer : edEvent
    {
        ShipyardTransferEventArgs eArgs=null;
        public edEventShipyardTransfer(ShipyardTransferEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Shutdown
    /// Когда происходит: при чистом завершении игры
    /// Параметры: нет
    /// </summary>
    public class edEventShutdown : edEvent
    {
        ShutdownEventArgs eArgs=null;
        public edEventShutdown(ShutdownEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SquadronCreated
    /// Когда происходит: при создании эскадры
    /// Параметры:
    /// • SquadronName: эскадра
    /// </summary>
    public class edEventSquadronCreated : edEvent
    {
        SquadronCreatedEventArgs eArgs=null;
        public edEventSquadronCreated(SquadronCreatedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SquadronDemotion
    /// Когда происходит: при понижении ранга в эскадре
    /// Параметры:
    /// • SquadronName: эскадра
    /// • OldRank: прошлый ранг
    /// • NewRank: новый ранг
    /// </summary>
    public class edEventSquadronDemotion : edEvent
    {
        SquadronDemotionEventArgs eArgs=null;
        public edEventSquadronDemotion(SquadronDemotionEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SquadronPromotion
    /// Когда происходит: при повышении ранга в эскадре
    /// Параметры:
    /// • SquadronName: эскадра
    /// • OldRank: прошлый ранг
    /// • NewRank: новый ранг
    /// </summary>
    public class edEventSquadronPromotion : edEvent
    {
        SquadronPromotionEventArgs eArgs=null;
        public edEventSquadronPromotion(SquadronPromotionEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SquadronStartup
    /// Когда происходит: при запуске игры для определения эскадры игрока
    /// Параметры:
    /// • SquadronName: эскадра
    /// • CurrentRank: текущий ранг
    /// </summary>
    public class edEventSquadronStartup : edEvent
    {
        SquadronStartupEventArgs eArgs=null;
        public edEventSquadronStartup(SquadronStartupEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SRVDestroyed
    /// Когда происходит: когда SRV игрока уничтожается
    /// Параметры:
    /// • ID: 
    /// </summary>
    public class edEventSRVDestroyed : edEvent
    {
        SRVDestroyedEventArgs eArgs=null;
        public edEventSRVDestroyed(SRVDestroyedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие StartJump
    /// Когда происходит: в начале прыжка в гиперпространстве или суперкруизе (начало обратного отсчета)
    /// Параметры:
    /// • JumpType: "Hyperspace" или "Supercruise"
    /// • StarClass: тип звезды (только для прыжка в гиперпространство)
    /// • StarSystem: название системы назначения (для гиперпространственного прыжка)
    /// • SystemAddress: 
    /// </summary>
    public class edEventStartJump : edEvent
    {
        StartJumpEventArgs eArgs=null;
        public edEventStartJump(StartJumpEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Statistics
    /// Когда происходит: при запуске
    /// Содержит информацию, отображаемую на панели статистики в правой части кабины.
    /// Параметры: https://elite-journal.readthedocs.io/en/latest/Startup/#statistics
    /// F12 на StatisticsEventArgs
    /// </summary>
    public class edEventStatistics : edEvent
    {
        StatisticsEventArgs eArgs=null;
        public edEventStatistics(StatisticsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие StoredModules
    /// Когда происходит: при первом посещении Экипировки и изменении набора хранимых модулей
    /// Параметры:
    /// • MarketID: текущий рынок
    /// • Items: (массив объектов)
    ///     • Name: 
    ///     • StarSystem: 
    ///     • StationName: 
    ///     • MarketID: где хранится модуль
    ///     • StorageSlot: 
    ///     • TransferCost: 
    ///     • TransferTime: 
    ///     • EngineerModifications: (название рецепта)
    ///     • Level: 
    ///     • Quality: 
    ///     • ExperimentalEffect: 
    ///     • BuyPrice: 
    ///     • InTransit: 
    ///     • Hot: 
    /// «EngineerModifications», «Level» и «Quality» отображаются только для спроектированного модуля.
    /// Значение InTransit появляется(со значением true) только в том случае, если модуль передается. 
    /// В этом случае система, рынок, стоимость перевода и время передачи не записываются.
    /// </summary>
    public class edEventStoredModules : edEvent
    {
        StoredModulesEventArgs eArgs=null;
        public edEventStoredModules(StoredModulesEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие StoredShips
    /// Когда происходит: при посещении верфи
    /// Параметры: https://elite-journal.readthedocs.io/en/latest/Station%20Services/#storedships
    /// F12 по StoredShipsEventArgs
    /// </summary>
    public class edEventStoredShips : edEvent
    {
        StoredShipsEventArgs eArgs=null;
        public edEventStoredShips(StoredShipsEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SupercruiseEntry
    /// Когда происходит: вход в суперкруиз из нормального космоса
    /// Параметры:
    /// • SystemAddress: текущий рынок
    /// • StarSystem: система
    /// </summary>
    public class edEventSupercruiseEntry : edEvent
    {
        SupercruiseEntryEventArgs eArgs=null;
        public edEventSupercruiseEntry(SupercruiseEntryEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SupercruiseExit
    /// Когда происходит: выпадение из суперкруиза в нормальный космос
    /// Параметры:
    /// • SystemAddress: 
    /// • Starsystem: система
    /// • Body: ближайшее небесное тело
    /// • BodyID: 
    /// • BodyType: 
    /// </summary>
    public class edEventSupercruiseExit : edEvent
    {
        SupercruiseExitEventArgs eArgs=null;
        public edEventSupercruiseExit(SupercruiseExitEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SwitchSuitLoadout
    /// Когда происходит: когда игрок выбирает другой летный костюм из шкафчика корабля.
    /// Параметры:
    /// • SuitID: 
    /// • SuitName: 
    /// • SuitMods: массив модификаций
    /// • LoadoutID: 
    /// • LoadoutName: 
    /// • Modules: список модулей (List<SuitModule>)
    ///     • SlotName: 
    ///     • SuitModuleID: 
    ///     • ModuleName: 
    ///     • Class: 
    ///     • WeaponMods: 
    /// </summary>
    public class edEventSwitchSuitLoadout : edEvent
    {
        SwitchSuitLoadoutEventArgs eArgs=null;
        public edEventSwitchSuitLoadout(SwitchSuitLoadoutEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Synthesis
    /// Когда происходит: когда используется синтез для ремонта или перевооружения
    /// Параметры:
    /// • Name: чертёж синтеза
    /// • Materials: Объект JSON со списком использованных материалов и количества
    /// </summary>
    public class edEventSynthesis : edEvent
    {
        SynthesisEventArgs eArgs=null;
        public edEventSynthesis(SynthesisEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие SystemsShutdown
    /// Когда происходит: при чистом завершении игры
    /// Параметры: нет
    /// </summary>
    public class edEventSystemsShutdown : edEvent
    {
        SystemsShutdownEventArgs eArgs=null;
        public edEventSystemsShutdown(SystemsShutdownEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие TechnologyBroker
    /// Когда происходит: при использовании техноброкера для разблокировки новых приобретаемых технологий
    /// Параметры:
    /// • BrokerType: 
    /// • MarketID: 
    /// • ItemUnlocked: 
    /// • Commodities: массив сырьевых товаров
    /// • Materials: массив материалов
    /// </summary>
    public class edEventTechnologyBroker : edEvent
    {
        TechnologyBrokerEventArgs eArgs=null;
        public edEventTechnologyBroker(TechnologyBrokerEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Touchdown
    /// Когда происходит: приземление на поверхность планеты
    /// Параметры:
    /// • Latitude: 
    /// • Longitude: 
    /// • NearestDestination: 
    /// • PlayerControlled: (bool) false, если корабль был отозван из SRV, true, если приземляется игрок
    /// </summary>
    public class edEventTouchdown : edEvent
    {
        TouchdownEventArgs eArgs=null;
        public edEventTouchdown(TouchdownEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие TradeMicroResources
    /// Когда происходит: когда игрок обменивает принадлежащие ему микроресурсы для получения микроресурсов другого типа
    /// Параметры:
    /// • Offered: список объектов (List<MicroResource>)
    /// • Received: название полученного ресурса
    /// • Category: 
    /// • Count: количество полученного ресурса
    /// • MarketID: 
    /// </summary>
    public class edEventTradeMicroResources : edEvent
    {
        TradeMicroResourcesEventArgs eArgs=null;
        public edEventTradeMicroResources(TradeMicroResourcesEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие TransferMicroResources
    /// Когда происходит: при переносе предметов из рюкзака в шкафчик корабля
    /// Параметры:
    /// • Transfers: список объектов (List<MicroResource>)
    ///     • Name: название ресурса
    ///     • Category: категория ресурса
    ///     • Count: количество ресурса
    ///     • Direction: направление переноса
    /// </summary>
    public class edEventTransferMicroResources : edEvent
    {
        TransferMicroResourcesEventArgs eArgs=null;
        public edEventTransferMicroResources(TransferMicroResourcesEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие UnderAttack
    /// Когда происходит: под обстрелом (одновременно с голосовым сообщением "Под атакой")
    /// Параметры:
    /// • Target: (Fighter/Mothership/You)
    /// </summary>
    public class edEventUnderAttack : edEvent
    {
        UnderAttackEventArgs eArgs=null;
        public edEventUnderAttack(UnderAttackEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие Undocked
    /// Когда происходит: взлет с посадочной площадки на станции, аутпосте или поселении
    /// Параметры:
    /// • StationName: имя станции
    /// • StationType: тип станции
    /// • MarketID: 
    /// </summary>
    public class edEventUndocked : edEvent
    {
        UndockedEventArgs eArgs=null;
        public edEventUndocked(UndockedEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие UpgradeSuit
    /// Когда происходит: когда игрок обновляет свой летный костюм
    /// Параметры:
    /// • Name: 
    /// • SuitID: 
    /// • Class: 
    /// • Cost: 
    /// </summary>
    public class edEventUpgradeSuit : edEvent
    {
        UpgradeSuitEventArgs eArgs=null;
        public edEventUpgradeSuit(UpgradeSuitEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие UpgradeWeapon
    /// Когда происходит: когда игрок обновляет ручное оружие
    /// Параметры:
    /// • Name: 
    /// • SuitID: 
    /// • Class: 
    /// • Cost: 
    /// </summary>
    public class edEventUpgradeWeapon : edEvent
    {
        UpgradeWeaponEventArgs eArgs=null;
        public edEventUpgradeWeapon(UpgradeWeaponEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие UseConsumable
    /// Когда происходит: при использовании предмета из инвентаря игрока (рюкзака)
    /// Параметры:
    /// • Name: 
    /// • Type: 
    /// </summary>
    public class edEventUseConsumable : edEvent
    {
        UseConsumableEventArgs eArgs=null;
        public edEventUseConsumable(UseConsumableEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие USSDrop
    /// Когда происходит: при выходе из Supercruise на USS
    /// Параметры:
    /// • USSType: описание USS
    /// • USSThreat: уровень угрозы
    /// </summary>
    public class edEventUSSDrop : edEvent
    {
        USSDropEventArgs eArgs=null;
        public edEventUSSDrop(USSDropEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие VehicleSwitch
    /// Когда происходит: при переключении управления между основным кораблем и истребителем
    /// Параметры:
    /// • To: (Mothership/Fighter)
    /// </summary>
    public class edEventVehicleSwitch : edEvent
    {
        VehicleSwitchEventArgs eArgs=null;
        public edEventVehicleSwitch(VehicleSwitchEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие WingAdd
    /// Когда происходит: когда другой игрок присоединяется к крылу
    /// Параметры:
    /// • Name: имя присоединившегося игрока
    /// </summary>
    public class edEventWingAdd : edEvent
    {
        WingAddEventArgs eArgs=null;
        public edEventWingAdd(WingAddEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие WingJoin
    /// Когда происходит: когда этот игрок присоединяется к крылу
    /// Параметры:
    /// • Others: Массив JSON с именами других игроков, уже находящихся в крыле
    /// </summary>
    public class edEventWingJoin : edEvent
    {
        WingJoinEventArgs eArgs=null;
        public edEventWingJoin(WingJoinEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие WingLeave
    /// Когда происходит: когда этот игрок присоединяется к крылу
    /// Параметры: нет
    /// </summary>
    public class edEventWingLeave : edEvent
    {
        WingLeaveEventArgs eArgs=null;
        public edEventWingLeave(WingLeaveEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }

    /// <summary>
    /// Событие WonATrophyForSquadron
    /// Когда происходит: когда Выиграл трофей для эскадрильи (сомнительно, но пусть)
    /// Параметры:
    /// • SquadronName: имя эскадры
    /// </summary>
    public class edEventWonATrophyForSquadron : edEvent
    {
        WonATrophyForSquadronEventArgs eArgs=null;
        public edEventWonATrophyForSquadron(WonATrophyForSquadronEventArgs e, VoiceActor CurrentVoiceActor) : base(CurrentVoiceActor)
        {
            this.EventName = this.GetType().Name.Substring(7);
            this.eArgs = e;
        }
        public void Process() { }
    }
}
