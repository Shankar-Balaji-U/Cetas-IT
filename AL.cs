namespace Microsoft.Dynamics.Nav.BusinessApplication
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Dynamics.Nav.Common.Language;
    using Microsoft.Dynamics.Nav.EventSubscription;
    using Microsoft.Dynamics.Nav.Runtime;
    using Microsoft.Dynamics.Nav.Runtime.Extensions;
    using Microsoft.Dynamics.Nav.Runtime.Report;
    using Microsoft.Dynamics.Nav.Types;
    using Microsoft.Dynamics.Nav.Types.Exceptions;
    using Microsoft.Dynamics.Nav.Types.Metadata;

    [NavCodeunitOptions(NavCodeunitOptions.EventManualBinding, 0, CodeunitSubType.Normal, true)]
    public sealed class Codeunit10012739 : NavCodeunit
    {
        [NavName("__LogLevel")]
        private int __LogLevel = default(int);
        [NavName("__DeepTracePanelControlEntities")]
        private bool __DeepTracePanelControlEntities = default(bool);
        [NavName("__DeepTracePanelRowColumnEntities")]
        private bool __DeepTracePanelRowColumnEntities = default(bool);
        [NavName("__DeepTracePanelEntities")]
        private bool __DeepTracePanelEntities = default(bool);
        [NavName("__DeepTraceMenuButtonEntities")]
        private bool __DeepTraceMenuButtonEntities = default(bool);
        [NavName("_dualDisp")]
        private bool _dualDisp = default(bool);
        [NavName("POSUTILS")]
        private NavCodeunitHandle pOSUTILS;
        [NavName("_Const")]
        private NavOption _Const = NavOption.Create(NCLEnumMetadata.Create(10012738), 0);
        [NavName("_Initialized")]
        private bool _Initialized = default(bool);
        [NavName("_ActiveController")]
        private NavInterfaceHandle _ActiveController;
        [NavName("_ControllerInitialized")]
        private bool _ControllerInitialized = default(bool);
        [NavName("_InstanceID")]
        private int _InstanceID = default(int);
        [NavName("_InterfaceProfileID")]
        private NavText _InterfaceProfileID = NavText.Default(0);
        [NavName("_StoreInterfaceProfileID")]
        private NavText _StoreInterfaceProfileID = NavText.Default(0);
        [NavName("_MenuProfileID")]
        private NavText _MenuProfileID = NavText.Default(0);
        [NavName("_StoreMenuProfileID")]
        private NavText _StoreMenuProfileID = NavText.Default(0);
        [NavName("_StyleProfileID")]
        private NavText _StyleProfileID = NavText.Default(0);
        [NavName("_StoreStyleProfileID")]
        private NavText _StoreStyleProfileID = NavText.Default(0);
        [NavName("_FontIdsFilter")]
        private NavText _FontIdsFilter = NavText.Default(0);
        [NavName("_SkinIdsFilter")]
        private NavText _SkinIdsFilter = NavText.Default(0);
        [NavName("_ColorIdsFilter")]
        private NavText _ColorIdsFilter = NavText.Default(0);
        [NavName("_SkipDefaultResources")]
        private bool _SkipDefaultResources = default(bool);
        [NavName("_ActiveLanguage")]
        private NavText _ActiveLanguage = NavText.Default(0);
        [NavName("_NO_STD_PANELS")]
        private bool _NO_STD_PANELS = default(bool);
        [NavName("_TmpLineIndexer")]
        private int _TmpLineIndexer = default(int);
        [NavName("Context")]
        private NavCodeunitHandle context;
        [NavName("ContextTags")]
        private NavDictionary<NavText, NavText> contextTags = NavDictionary<NavText, NavText>.Default;
        [NavName("ModifiedContext")]
        private NavJsonObject modifiedContext;
        [NavName("_contextExpressions")]
        private NavDictionary<NavText, NavText> _contextExpressions = NavDictionary<NavText, NavText>.Default;
        [NavName("_ignoreModifications")]
        private bool _ignoreModifications = default(bool);
        [NavName("_lastModifiedContext")]
        private NavDictionary<NavText, NavText> _lastModifiedContext = NavDictionary<NavText, NavText>.Default;
        [NavName("_CONTROLS")]
        private INavRecordHandle _CONTROLS;
        [NavName("_TAGGED_CONTROLS")]
        private INavRecordHandle _TAGGED_CONTROLS;
        [NavName("_SHARED")]
        private INavRecordHandle _SHARED;
        [NavName("ZoomDatasetJSON")]
        private NavDictionary<NavText, NavText> zoomDatasetJSON = NavDictionary<NavText, NavText>.Default;
        [NavName("MenuSelectedButton")]
        private NavDictionary<NavText, int> menuSelectedButton = NavDictionary<NavText, int>.Default;
        [NavName("MenuModifications")]
        private NavDictionary<NavText, NavList<int>> menuModifications = NavDictionary<NavText, NavList<int>>.Default;
        [NavName("ButtonPadMenuList")]
        private NavDictionary<NavText, NavList<NavText>> buttonPadMenuList = NavDictionary<NavText, NavList<NavText>>.Default;
        [NavName("PanelNeedsControlRefresh")]
        private NavList<NavText> panelNeedsControlRefresh = NavList<NavText>.Default;
        [NavName("ModalPanelStack")]
        private NavCodeunitHandle modalPanelStack;
        [NavName("PanelStack")]
        private NavCodeunitHandle panelStack;
        [NavName("PanelCloseDenied")]
        private bool panelCloseDenied = default(bool);
        [NavName("_lastOpenPanel")]
        private NavText _lastOpenPanel = NavText.Default(0);
        [NavName("LoadedMenusTemp")]
        private INavRecordHandle loadedMenusTemp;
        [NavName("LoadedPanelsTemp")]
        private INavRecordHandle loadedPanelsTemp;
        [NavName("LoadedControlsTemp")]
        private INavRecordHandle loadedControlsTemp;
        [NavName("_POS")]
        private INavRecordHandle _POS;
        [NavName("_MenuEntities")]
        private INavRecordHandle _MenuEntities;
        [NavName("_MenuButtonEntities")]
        private INavRecordHandle _MenuButtonEntities;
        [NavName("_TranslatedMenuButtons")]
        private NavList<NavRecordId> _TranslatedMenuButtons = NavList<NavRecordId>.Default;
        [NavName("_BlockedMenuButtons")]
        private NavList<NavRecordId> _BlockedMenuButtons = NavList<NavRecordId>.Default;
        [NavName("_PanelEntities")]
        private INavRecordHandle _PanelEntities;
        [NavName("_PanelRowColumnEntities")]
        private INavRecordHandle _PanelRowColumnEntities;
        [NavName("_PanelControlEntities")]
        private INavRecordHandle _PanelControlEntities;
        [NavName("_InputEntities")]
        private INavRecordHandle _InputEntities;
        [NavName("_ButtonPadEntities")]
        private INavRecordHandle _ButtonPadEntities;
        [NavName("_DataGridEntities")]
        private INavRecordHandle _DataGridEntities;
        [NavName("_RecordZoomEntities")]
        private INavRecordHandle _RecordZoomEntities;
        [NavName("_BrowserEntities")]
        private INavRecordHandle _BrowserEntities;
        [NavName("_MediaEntities")]
        private INavRecordHandle _MediaEntities;
        [NavName("PanelClosedEventRegister")]
        private NavCodeunitHandle panelClosedEventRegister;
        [NavName("PanelOpenedEventRegister")]
        private NavDictionary<NavText, bool> panelOpenedEventRegister = NavDictionary<NavText, bool>.Default;
        [NavName("Javascripts")]
        private NavJsonArray javascripts;
        [NavName("Commands")]
        private NavJsonArray commands;
        [NavName("PendingPOSData")]
        private NavList<NavText> pendingPOSData = NavList<NavText>.Default;
        [NavName("PendingDataSets")]
        private NavJsonObject pendingDataSets;
        [NavName("PendingJsonRequests")]
        private NavList<NavText> pendingJsonRequests = NavList<NavText>.Default;
        [NavName("PendingImages")]
        private NavJsonObject pendingImages;
        [NavName("SentImages")]
        private NavJsonObject sentImages;
        [NavName("PendingPlaylists")]
        private NavJsonObject pendingPlaylists;
        [NavName("SentPlaylists")]
        private NavJsonObject sentPlaylists;
        [NavName("StyleProfilePending")]
        private bool styleProfilePending = default(bool);
        [NavName("ContextMenusPending")]
        private bool contextMenusPending = default(bool);
        [NavName("KeyCommandsPending")]
        private bool keyCommandsPending = default(bool);
        [NavName("LanguagePending")]
        private bool languagePending = default(bool);
        [NavName("ShowDualDisplayPending")]
        private bool showDualDisplayPending = default(bool);
        [NavName("gActiveDataGrid")]
        private NavText gActiveDataGrid = NavText.Default(0);
        [NavName("gActiveInput")]
        private NavText gActiveInput = NavText.Default(0);
        [NavName("gActiveZoom")]
        private NavText gActiveZoom = NavText.Default(0);
        [NavName("_standardPanelsLoaded")]
        private bool _standardPanelsLoaded = default(bool);
        [NavName("CurrShowPanelModal")]
        private NavText currShowPanelModal = NavText.Default(0);
        [NavName("PendingShowPanelOnModalPanelClose")]
        private NavDictionary<NavText, NavText> pendingShowPanelOnModalPanelClose = NavDictionary<NavText, NavText>.Default;
        [NavName("CurrDataTag")]
        private NavText currDataTag = NavText.Default(0);
        protected override void OnClear()
        {
            this.__LogLevel = default(int);
            this.__DeepTracePanelControlEntities = default(bool);
            this.__DeepTracePanelRowColumnEntities = default(bool);
            this.__DeepTracePanelEntities = default(bool);
            this.__DeepTraceMenuButtonEntities = default(bool);
            this._dualDisp = default(bool);
            this.pOSUTILS.Clear();
            this._Const = NavOption.Create(NCLEnumMetadata.Create(10012738), 0);
            this._Initialized = default(bool);
            this._ActiveController.Clear();
            this._ControllerInitialized = default(bool);
            this._InstanceID = default(int);
            this._InterfaceProfileID = NavText.Default(0);
            this._StoreInterfaceProfileID = NavText.Default(0);
            this._MenuProfileID = NavText.Default(0);
            this._StoreMenuProfileID = NavText.Default(0);
            this._StyleProfileID = NavText.Default(0);
            this._StoreStyleProfileID = NavText.Default(0);
            this._FontIdsFilter = NavText.Default(0);
            this._SkinIdsFilter = NavText.Default(0);
            this._ColorIdsFilter = NavText.Default(0);
            this._SkipDefaultResources = default(bool);
            this._ActiveLanguage = NavText.Default(0);
            this._NO_STD_PANELS = default(bool);
            this._TmpLineIndexer = default(int);
            this.context.Clear();
            this.contextTags = NavDictionary<NavText, NavText>.Default;
            this.modifiedContext = NavJsonObject.Default;
            this._contextExpressions = NavDictionary<NavText, NavText>.Default;
            this._ignoreModifications = default(bool);
            this._lastModifiedContext = NavDictionary<NavText, NavText>.Default;
            this._CONTROLS.Clear();
            this._TAGGED_CONTROLS.Clear();
            this._SHARED.Clear();
            this.zoomDatasetJSON = NavDictionary<NavText, NavText>.Default;
            this.menuSelectedButton = NavDictionary<NavText, int>.Default;
            this.menuModifications = NavDictionary<NavText, NavList<int>>.Default;
            this.buttonPadMenuList = NavDictionary<NavText, NavList<NavText>>.Default;
            this.panelNeedsControlRefresh = NavList<NavText>.Default;
            this.modalPanelStack.Clear();
            this.panelStack.Clear();
            this.panelCloseDenied = default(bool);
            this._lastOpenPanel = NavText.Default(0);
            this.loadedMenusTemp.Clear();
            this.loadedPanelsTemp.Clear();
            this.loadedControlsTemp.Clear();
            this._POS.Clear();
            this._MenuEntities.Clear();
            this._MenuButtonEntities.Clear();
            this._TranslatedMenuButtons = NavList<NavRecordId>.Default;
            this._BlockedMenuButtons = NavList<NavRecordId>.Default;
            this._PanelEntities.Clear();
            this._PanelRowColumnEntities.Clear();
            this._PanelControlEntities.Clear();
            this._InputEntities.Clear();
            this._ButtonPadEntities.Clear();
            this._DataGridEntities.Clear();
            this._RecordZoomEntities.Clear();
            this._BrowserEntities.Clear();
            this._MediaEntities.Clear();
            this.panelClosedEventRegister.Clear();
            this.panelOpenedEventRegister = NavDictionary<NavText, bool>.Default;
            this.javascripts = NavJsonArray.Default;
            this.commands = NavJsonArray.Default;
            this.pendingPOSData = NavList<NavText>.Default;
            this.pendingDataSets = NavJsonObject.Default;
            this.pendingJsonRequests = NavList<NavText>.Default;
            this.pendingImages = NavJsonObject.Default;
            this.sentImages = NavJsonObject.Default;
            this.pendingPlaylists = NavJsonObject.Default;
            this.sentPlaylists = NavJsonObject.Default;
            this.styleProfilePending = default(bool);
            this.contextMenusPending = default(bool);
            this.keyCommandsPending = default(bool);
            this.languagePending = default(bool);
            this.showDualDisplayPending = default(bool);
            this.gActiveDataGrid = NavText.Default(0);
            this.gActiveInput = NavText.Default(0);
            this.gActiveZoom = NavText.Default(0);
            this._standardPanelsLoaded = default(bool);
            this.currShowPanelModal = NavText.Default(0);
            this.pendingShowPanelOnModalPanelClose = NavDictionary<NavText, NavText>.Default;
            this.currDataTag = NavText.Default(0);
        }

        public Codeunit10012739(ITreeObject parent) : base(parent, 10012739)
        {
            this.InitializeComponent();
        }

        void InitializeComponent()
        {
            this.pOSUTILS = new NavCodeunitHandle(this, 10012737);
            this._ActiveController = new NavInterfaceHandle(this);
            this.context = new NavCodeunitHandle(this, 10012722);
            this.contextTags = NavDictionary<NavText, NavText>.Default;
            this.modifiedContext = NavJsonObject.Default;
            this._contextExpressions = NavDictionary<NavText, NavText>.Default;
            this._lastModifiedContext = NavDictionary<NavText, NavText>.Default;
            this._CONTROLS = new NavRecordHandle(this, 99001760, false, SecurityFiltering.Validated);
            this._TAGGED_CONTROLS = new NavRecordHandle(this, 99001760, false, SecurityFiltering.Validated);
            this._SHARED = new NavRecordHandle(this, 99008963, false, SecurityFiltering.Validated);
            this.zoomDatasetJSON = NavDictionary<NavText, NavText>.Default;
            this.menuSelectedButton = NavDictionary<NavText, int>.Default;
            this.menuModifications = NavDictionary<NavText, NavList<int>>.Default;
            this.buttonPadMenuList = NavDictionary<NavText, NavList<NavText>>.Default;
            this.panelNeedsControlRefresh = NavList<NavText>.Default;
            this.modalPanelStack = new NavCodeunitHandle(this, 10037085);
            this.panelStack = new NavCodeunitHandle(this, 10012738);
            this.loadedMenusTemp = new NavRecordHandle(this, 99008880, true, SecurityFiltering.Validated);
            this.loadedPanelsTemp = new NavRecordHandle(this, 99008880, true, SecurityFiltering.Validated);
            this.loadedControlsTemp = new NavRecordHandle(this, 99001760, true, SecurityFiltering.Validated);
            this._POS = new NavRecordHandle(this, 99008882, true, SecurityFiltering.Validated);
            this._MenuEntities = new NavRecordHandle(this, 99009053, true, SecurityFiltering.Validated);
            this._MenuButtonEntities = new NavRecordHandle(this, 99009054, true, SecurityFiltering.Validated);
            this._TranslatedMenuButtons = NavList<NavRecordId>.Default;
            this._BlockedMenuButtons = NavList<NavRecordId>.Default;
            this._PanelEntities = new NavRecordHandle(this, 99008880, true, SecurityFiltering.Validated);
            this._PanelRowColumnEntities = new NavRecordHandle(this, 99008873, true, SecurityFiltering.Validated);
            this._PanelControlEntities = new NavRecordHandle(this, 99008874, true, SecurityFiltering.Validated);
            this._InputEntities = new NavRecordHandle(this, 99008877, true, SecurityFiltering.Validated);
            this._ButtonPadEntities = new NavRecordHandle(this, 99008875, true, SecurityFiltering.Validated);
            this._DataGridEntities = new NavRecordHandle(this, 99008876, true, SecurityFiltering.Validated);
            this._RecordZoomEntities = new NavRecordHandle(this, 99008878, true, SecurityFiltering.Validated);
            this._BrowserEntities = new NavRecordHandle(this, 99008879, true, SecurityFiltering.Validated);
            this._MediaEntities = new NavRecordHandle(this, 99008958, true, SecurityFiltering.Validated);
            this.panelClosedEventRegister = new NavCodeunitHandle(this, 10012738);
            this.panelOpenedEventRegister = NavDictionary<NavText, bool>.Default;
            this.javascripts = NavJsonArray.Default;
            this.commands = NavJsonArray.Default;
            this.pendingPOSData = NavList<NavText>.Default;
            this.pendingDataSets = NavJsonObject.Default;
            this.pendingJsonRequests = NavList<NavText>.Default;
            this.pendingImages = NavJsonObject.Default;
            this.sentImages = NavJsonObject.Default;
            this.pendingPlaylists = NavJsonObject.Default;
            this.sentPlaylists = NavJsonObject.Default;
            this.pendingShowPanelOnModalPanelClose = NavDictionary<NavText, NavText>.Default;
        }

        public override string ObjectName => "LSC POS Control Library";

        protected override object OnInvoke(int memberId, object[] args)
        {
            switch (memberId)
            {
                case 600763662:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetContext", 1, args.Length));
                    GetContext(ALCompiler.ObjectToExactNavCodeunitHandle(args[0]));
                    break;
                case 1773288141:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ClearContext", 0, args.Length));
                    ClearContext();
                    break;
                case -1870184611:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ClearModifiedContext", 0, args.Length));
                    ClearModifiedContext();
                    break;
                case 758486046:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetModifiedContext", 0, args.Length));
                    return GetModifiedContext();
                    break;
                case 663556336:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetLastModifiedContext", 1, args.Length));
                    GetLastModifiedContext((ByRef<NavDictionary<NavText, NavText>>)ALCompiler.SafeCastCheck<ByRef<NavDictionary<NavText, NavText>>>(args[0]));
                    break;
                case -1041547779:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UpdateTagExpressions", 1, args.Length));
                    UpdateTagExpressions((ByRef<NavDictionary<NavText, NavText>>)ALCompiler.SafeCastCheck<ByRef<NavDictionary<NavText, NavText>>>(args[0]));
                    break;
                case 1114993508:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UpdateContext", 3, args.Length));
                    UpdateContext((ByRef<NavDictionary<NavText, NavText>>)ALCompiler.SafeCastCheck<ByRef<NavDictionary<NavText, NavText>>>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case 1392435367:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetValue", 2, args.Length));
                    return SetValue(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case -711940861:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetValue_711940861", 3, args.Length));
                    return SetValue_711940861(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]));
                    break;
                case -1221286396:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetValue", 1, args.Length));
                    return GetValue(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 1936110688:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ClearByTag", 1, args.Length));
                    return ClearByTag(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -1730720718:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetInitialized", 1, args.Length));
                    SetInitialized((bool)ALCompiler.ObjectToBoolean(args[0]));
                    break;
                case -2010798666:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetInitialized", 0, args.Length));
                    return GetInitialized();
                    break;
                case 1040166710:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ResumePanelControls", 1, args.Length));
                    ResumePanelControls(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 2117440312:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetMenu", 1, args.Length));
                    return GetMenu(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -1801133691:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetPanel", 1, args.Length));
                    return GetPanel(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -1269956108:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetInput", 2, args.Length));
                    return GetInput(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactINavRecordHandle(args[1]));
                    break;
                case -512041359:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetButtonPad", 1, args.Length));
                    return GetButtonPad(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -1028722889:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetDataGrid", 2, args.Length));
                    return GetDataGrid(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactINavRecordHandle(args[1]));
                    break;
                case 384141761:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetRecordZoom", 2, args.Length));
                    return GetRecordZoom(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactINavRecordHandle(args[1]));
                    break;
                case -1759405989:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetBrowser", 2, args.Length));
                    return GetBrowser(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactINavRecordHandle(args[1]));
                    break;
                case -1923119507:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetMedia", 2, args.Length));
                    return GetMedia(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactINavRecordHandle(args[1]));
                    break;
                case 2119864146:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetControlJSON", 3, args.Length));
                    GetControlJSON(ALCompiler.ObjectToExactNavValue<NavOption>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), ALCompiler.ObjectToExactNavCodeunitHandle(args[2]));
                    break;
                case 670881381:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetControlJSON_670881381", 4, args.Length));
                    GetControlJSON_670881381(ALCompiler.ObjectToExactNavValue<NavOption>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), ALCompiler.ObjectToExactNavCodeunitHandle(args[2]), (bool)ALCompiler.ObjectToBoolean(args[3]));
                    break;
                case -668445662:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetMenuButtonJSON", 2, args.Length));
                    return GetMenuButtonJSON(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavCodeunitHandle(args[1]));
                    break;
                case -1266558873:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetMenuButtonJSON_1266558873", 3, args.Length));
                    return GetMenuButtonJSON_1266558873(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavCodeunitHandle(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case 747471512:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("InitControl", 2, args.Length));
                    InitControl(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavInterfaceHandle>(args[1]));
                    break;
                case -1883444758:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("InitControl_1883444758", 1, args.Length));
                    InitControl_1883444758(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 1645083635:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetLogLevel", 1, args.Length));
                    SetLogLevel((int)ALCompiler.ObjectToInt32(args[0]));
                    break;
                case -1763699926:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("NoStandardPanels", 1, args.Length));
                    NoStandardPanels((bool)ALCompiler.ObjectToBoolean(args[0]));
                    break;
                case 1867638575:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("PreProcessEvent", 1, args.Length));
                    return PreProcessEvent(ALCompiler.ObjectToExactNavCodeunitHandle(args[0]));
                    break;
                case 972933181:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetMenuModifiedButtonValues", 2, args.Length));
                    return GetMenuModifiedButtonValues(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case 334793796:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetMenuModifiedButtons", 1, args.Length));
                    return GetMenuModifiedButtons(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 338824207:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ClearMenuModifications", 1, args.Length));
                    ClearMenuModifications(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 1280628581:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetIdleTimerInterval", 1, args.Length));
                    SetIdleTimerInterval((int)ALCompiler.ObjectToInt32(args[0]));
                    break;
                case 1078924071:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetInputOptionString", 2, args.Length));
                    SetInputOptionString(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case 2050328345:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetButtonHighlighted", 3, args.Length));
                    SetButtonHighlighted(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case -1144439413:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetButtonEnabled", 3, args.Length));
                    SetButtonEnabled(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case -1436137779:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetButtonCaption", 4, args.Length));
                    SetButtonCaption(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToExactNavValue<NavOption>(args[2]), ALCompiler.ObjectToExactNavValue<NavText>(args[3]));
                    break;
                case -1999077560:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetButtonCommand", 3, args.Length));
                    SetButtonCommand(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]));
                    break;
                case 184570004:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetButtonCaption", 3, args.Length));
                    return GetButtonCaption(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToExactNavValue<NavOption>(args[2]));
                    break;
                case -586531772:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetButtonFont", 4, args.Length));
                    SetButtonFont(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToExactNavValue<NavOption>(args[2]), ALCompiler.ObjectToExactNavValue<NavText>(args[3]));
                    break;
                case -959976847:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetButtonSkin", 3, args.Length));
                    SetButtonSkin(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]));
                    break;
                case 857619957:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("AddJsonRequest", 2, args.Length));
                    AddJsonRequest(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case 1545030233:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UpdatePOSData", 2, args.Length));
                    UpdatePOSData((ByRef<NavRecordRef>)ALCompiler.SafeCastCheck<ByRef<NavRecordRef>>(args[0]), (bool)ALCompiler.ObjectToBoolean(args[1]));
                    break;
                case -469435878:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UpdatePOSData1", 3, args.Length));
                    UpdatePOSData1((int)ALCompiler.ObjectToInt32(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]));
                    break;
                case 2119086763:
                    if (args.Length != 5)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UpdatePOSData2", 5, args.Length));
                    UpdatePOSData2((int)ALCompiler.ObjectToInt32(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]), (int)ALCompiler.ObjectToInt32(args[3]), ALCompiler.ObjectToExactNavValue<NavText>(args[4]));
                    break;
                case -934659077:
                    if (args.Length != 7)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UpdatePOSData3", 7, args.Length));
                    UpdatePOSData3((int)ALCompiler.ObjectToInt32(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]), (int)ALCompiler.ObjectToInt32(args[3]), ALCompiler.ObjectToExactNavValue<NavText>(args[4]), (int)ALCompiler.ObjectToInt32(args[5]), ALCompiler.ObjectToExactNavValue<NavText>(args[6]));
                    break;
                case -197186925:
                    if (args.Length != 9)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UpdatePOSData4", 9, args.Length));
                    UpdatePOSData4((int)ALCompiler.ObjectToInt32(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]), (int)ALCompiler.ObjectToInt32(args[3]), ALCompiler.ObjectToExactNavValue<NavText>(args[4]), (int)ALCompiler.ObjectToInt32(args[5]), ALCompiler.ObjectToExactNavValue<NavText>(args[6]), (int)ALCompiler.ObjectToInt32(args[7]), ALCompiler.ObjectToExactNavValue<NavText>(args[8]));
                    break;
                case 1319767854:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetDataTag", 1, args.Length));
                    SetDataTag(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 1660707436:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RemovePOSDataByTag", 1, args.Length));
                    return RemovePOSDataByTag(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 1111124075:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("PosIsActive", 0, args.Length));
                    return PosIsActive();
                    break;
                case -1644946629:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshPanel", 1, args.Length));
                    RefreshPanel(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 1838628398:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshControl", 3, args.Length));
                    RefreshControl(ALCompiler.ObjectToExactNavValue<NavOption>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case -617729402:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshControl_617729402", 4, args.Length));
                    RefreshControl_617729402(ALCompiler.ObjectToExactNavValue<NavOption>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]), (bool)ALCompiler.ObjectToBoolean(args[3]));
                    break;
                case 1736536040:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RemoveControlEntities", 2, args.Length));
                    RemoveControlEntities(ALCompiler.ObjectToExactNavValue<NavOption>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case -377786894:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ShowPanel", 1, args.Length));
                    ShowPanel(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -1811840056:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ShowPanelModal", 2, args.Length));
                    ShowPanelModal(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case -1883873996:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ShowPanelModal_1883873996", 4, args.Length));
                    ShowPanelModal_1883873996(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (int)ALCompiler.ObjectToInt32(args[2]), ALCompiler.ObjectToExactNavValue<NavText>(args[3]));
                    break;
                case -1149855453:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("HidePanel", 2, args.Length));
                    HidePanel(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (bool)ALCompiler.ObjectToBoolean(args[1]));
                    break;
                case 1527642583:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("HideActivePanel", 1, args.Length));
                    return HideActivePanel((bool)ALCompiler.ObjectToBoolean(args[0]));
                    break;
                case -297268737:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ActivePanelID", 0, args.Length));
                    return ActivePanelID();
                    break;
                case -1371721810:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ActivePanelID_1371721810", 1, args.Length));
                    return ActivePanelID_1371721810((ByRef<NavText>)ALCompiler.SafeCastCheck<ByRef<NavText>>(args[0]));
                    break;
                case 1595898284:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("CreatePanel", 3, args.Length));
                    CreatePanel(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (int)ALCompiler.ObjectToInt32(args[2]));
                    break;
                case 321882841:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetPanelRowHeight", 4, args.Length));
                    SetPanelRowHeight(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToInt32(args[2]), (int)ALCompiler.ObjectToInt32(args[3]));
                    break;
                case -1891276771:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetPanelColumnWidth", 4, args.Length));
                    SetPanelColumnWidth(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToInt32(args[2]), (int)ALCompiler.ObjectToInt32(args[3]));
                    break;
                case 1128159546:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetPanelColumns", 2, args.Length));
                    SetPanelColumns(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case -813361756:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetPanelRows", 2, args.Length));
                    SetPanelRows(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case -1203650873:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("CreateButtonPad", 2, args.Length));
                    CreateButtonPad(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case 1455556540:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("CreateMenu", 4, args.Length));
                    CreateMenu(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (int)ALCompiler.ObjectToInt32(args[2]), (int)ALCompiler.ObjectToInt32(args[3]));
                    break;
                case -1813021575:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("CreateInput", 1, args.Length));
                    CreateInput(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -1497993980:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UploadPosPanelRec", 1, args.Length));
                    UploadPosPanelRec(ALCompiler.ObjectToExactINavRecordHandle(args[0]));
                    break;
                case 520468517:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UploadPosPanelRowColumnsRec", 1, args.Length));
                    UploadPosPanelRowColumnsRec(ALCompiler.ObjectToExactINavRecordHandle(args[0]));
                    break;
                case -1072134520:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UploadPosPanelControlsRec", 2, args.Length));
                    UploadPosPanelControlsRec(ALCompiler.ObjectToExactINavRecordHandle(args[0]), (bool)ALCompiler.ObjectToBoolean(args[1]));
                    break;
                case -1778858761:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UploadMenuHeaderRec", 1, args.Length));
                    UploadMenuHeaderRec(ALCompiler.ObjectToExactINavRecordHandle(args[0]));
                    break;
                case 949820061:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UploadMenuLineRec", 1, args.Length));
                    UploadMenuLineRec(ALCompiler.ObjectToExactINavRecordHandle(args[0]));
                    break;
                case 1697532027:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshMenu", 1, args.Length));
                    RefreshMenu(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -1500321386:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshMenu_1500321386", 2, args.Length));
                    RefreshMenu_1500321386(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (bool)ALCompiler.ObjectToBoolean(args[1]));
                    break;
                case -993781415:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshMenuButtons", 1, args.Length));
                    RefreshMenuButtons(ALCompiler.ObjectToExactINavRecordHandle(args[0]));
                    break;
                case 528276133:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("HideExtraButtons", 3, args.Length));
                    HideExtraButtons(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), (int)ALCompiler.ObjectToInt32(args[2]));
                    break;
                case -1622512140:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshMenuButton", 2, args.Length));
                    RefreshMenuButton(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case 267048875:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshMenuButton_267048875", 3, args.Length));
                    RefreshMenuButton_267048875(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case 1722283205:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("DeleteMenuButton", 3, args.Length));
                    DeleteMenuButton(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case -656596980:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ShowMenu", 2, args.Length));
                    ShowMenu(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavCode>(args[1]));
                    break;
                case -1077737328:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("StackMenu", 2, args.Length));
                    StackMenu(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavCode>(args[1]));
                    break;
                case 1361759889:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("StackMenu_1361759889", 3, args.Length));
                    StackMenu_1361759889(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavCode>(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case 554975115:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetButtonPadMenu", 1, args.Length));
                    return GetButtonPadMenu(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case -186771115:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetButtonPadMenuList", 1, args.Length));
                    return GetButtonPadMenuList(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case -1992903705:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("PopMenu", 1, args.Length));
                    return PopMenu(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case -1508347324:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RemoveMenu", 2, args.Length));
                    return RemoveMenu(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavCode>(args[1]));
                    break;
                case 326346580:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetMenuVisible", 2, args.Length));
                    SetMenuVisible(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (bool)ALCompiler.ObjectToBoolean(args[1]));
                    break;
                case -1628810055:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetMenuVisible_1628810055", 3, args.Length));
                    SetMenuVisible_1628810055(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (bool)ALCompiler.ObjectToBoolean(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case -594963758:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetMenuButtonSpacing", 2, args.Length));
                    SetMenuButtonSpacing(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case 609288950:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("PopupMenu", 1, args.Length));
                    PopupMenu(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -126275962:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("PopupMenu_126275962", 3, args.Length));
                    PopupMenu_126275962(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (int)ALCompiler.ObjectToInt32(args[2]));
                    break;
                case 1594117119:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetActiveInput", 1, args.Length));
                    SetActiveInput(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -1467130609:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetActiveInput", 0, args.Length));
                    return GetActiveInput();
                    break;
                case -494435084:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetInputEnabled", 2, args.Length));
                    SetInputEnabled(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (bool)ALCompiler.ObjectToBoolean(args[1]));
                    break;
                case 1717809131:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetInputText", 2, args.Length));
                    SetInputText(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case -1985547946:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetInputText", 1, args.Length));
                    return GetInputText(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -2042309878:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetInputPasswordChar", 2, args.Length));
                    SetInputPasswordChar(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case -1739087392:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetInputPrompt", 2, args.Length));
                    SetInputPrompt(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case 1115174055:
                    if (args.Length != 5)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetInputEnterPressedCommand", 5, args.Length));
                    SetInputEnterPressedCommand(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]), ALCompiler.ObjectToExactNavValue<NavText>(args[3]), ALCompiler.ObjectToExactNavValue<NavText>(args[4]));
                    break;
                case 1330138212:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetInputPromptWidth", 2, args.Length));
                    SetInputPromptWidth(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case -1047461207:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetInputMaxLength", 2, args.Length));
                    SetInputMaxLength(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case -1975704078:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ActivateInput", 1, args.Length));
                    ActivateInput(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -1727542824:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshInputControl", 1, args.Length));
                    RefreshInputControl(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case -733130942:
                    if (args.Length != 7)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ShowControl", 7, args.Length));
                    ShowControl(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (int)ALCompiler.ObjectToInt32(args[2]), (int)ALCompiler.ObjectToInt32(args[3]), (int)ALCompiler.ObjectToInt32(args[4]), ALCompiler.ObjectToExactNavValue<NavOption>(args[5]), ALCompiler.ObjectToExactNavValue<NavText>(args[6]));
                    break;
                case -918336590:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("HideControl", 1, args.Length));
                    HideControl(ALCompiler.ObjectToExactINavRecordHandle(args[0]));
                    break;
                case -888901552:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("HideControl_888901552", 2, args.Length));
                    HideControl_888901552(ALCompiler.ObjectToExactNavValue<NavOption>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case 880088188:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetPosImage", 3, args.Length));
                    SetPosImage(ALCompiler.ObjectToExactNavValue<NavOption>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]));
                    break;
                case 1833924619:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetPosImage", 2, args.Length));
                    return GetPosImage(ALCompiler.ObjectToExactNavValue<NavOption>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case -1475021588:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetPosImageUrl", 3, args.Length));
                    return SetPosImageUrl(ALCompiler.ObjectToExactNavValue<NavOption>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]));
                    break;
                case 1184793874:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetControlPosition", 1, args.Length));
                    SetControlPosition(ALCompiler.ObjectToExactINavRecordHandle(args[0]));
                    break;
                case 1520947238:
                    if (args.Length != 7)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetControlPosition_1520947238", 7, args.Length));
                    SetControlPosition_1520947238(ALCompiler.ObjectToExactNavValue<NavOption>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]), (int)ALCompiler.ObjectToInt32(args[3]), (int)ALCompiler.ObjectToInt32(args[4]), (int)ALCompiler.ObjectToInt32(args[5]), (int)ALCompiler.ObjectToInt32(args[6]));
                    break;
                case 358062519:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetDataGridCurrentColumnIndex", 1, args.Length));
                    return GetDataGridCurrentColumnIndex(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 2063763793:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetDataGridCurrentRowIndex", 1, args.Length));
                    return GetDataGridCurrentRowIndex(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 748090293:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetDataGridMarkedRecords", 3, args.Length));
                    GetDataGridMarkedRecords(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (ByRef<NavJsonArray>)ALCompiler.SafeCastCheck<ByRef<NavJsonArray>>(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case -703752843:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetDataGridMarkedRecord", 3, args.Length));
                    return GetDataGridMarkedRecord(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case -410523668:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetDataGridMarkedRecordCount", 1, args.Length));
                    return GetDataGridMarkedRecordCount(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 736155664:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetDataGridMarkedRecords", 2, args.Length));
                    SetDataGridMarkedRecords(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavJsonArray>(args[1]));
                    break;
                case -86947684:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ClearMarkedRecords", 1, args.Length));
                    ClearMarkedRecords(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case -346089654:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshDataGrid", 1, args.Length));
                    RefreshDataGrid(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 1062296984:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ShowDataTable", 2, args.Length));
                    ShowDataTable(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavCode>(args[1]));
                    break;
                case -1870183314:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("InitGridDataSet", 3, args.Length));
                    InitGridDataSet(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), ALCompiler.ObjectToExactNavValue<NavJsonObject>(args[2]));
                    break;
                case -1692269582:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("AddGridDataSet", 4, args.Length));
                    AddGridDataSet(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), ALCompiler.ObjectToExactNavValue<NavJsonObject>(args[2]), (int)ALCompiler.ObjectToInt32(args[3]));
                    break;
                case -1771868078:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetGridDataTableID", 1, args.Length));
                    return GetGridDataTableID(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case -240251716:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetActiveDataGrid", 1, args.Length));
                    SetActiveDataGrid(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 2043546529:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetActiveDataGrid", 0, args.Length));
                    return GetActiveDataGrid();
                    break;
                case 23642758:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetLookupAssistValue", 1, args.Length));
                    SetLookupAssistValue(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -1188390463:
                    if (args.Length != 5)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("PopupGridData", 5, args.Length));
                    PopupGridData(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavJsonObject>(args[1]), ALCompiler.ObjectToExactNavValue<NavCode>(args[2]), (int)ALCompiler.ObjectToInt32(args[3]), (bool)ALCompiler.ObjectToBoolean(args[4]));
                    break;
                case -1720717819:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("HidePopupGrid", 0, args.Length));
                    HidePopupGrid();
                    break;
                case -896451774:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetActiveZoom", 1, args.Length));
                    SetActiveZoom(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 1971048403:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetActiveZoom", 0, args.Length));
                    return GetActiveZoom();
                    break;
                case -160281107:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ShowRecordZoomJSON", 3, args.Length));
                    ShowRecordZoomJSON(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavCode>(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case -2042407339:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetRecordZoomDataXML", 1, args.Length));
                    return GetRecordZoomDataXML(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 904469264:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshZoomControl", 2, args.Length));
                    RefreshZoomControl(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavCode>(args[1]));
                    break;
                case -1727550791:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GoToNextRow", 1, args.Length));
                    GoToNextRow(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 195449750:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GoToPreviousRow", 1, args.Length));
                    GoToPreviousRow(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 1574670381:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GoToRow", 2, args.Length));
                    GoToRow(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case -1548454713:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GoToRow_1548454713", 3, args.Length));
                    GoToRow_1548454713(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (bool)ALCompiler.ObjectToBoolean(args[2]));
                    break;
                case 1941480616:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetDataGridActiveRecord", 2, args.Length));
                    SetDataGridActiveRecord(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case -1101006532:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetDataGridActiveRecord", 1, args.Length));
                    return GetDataGridActiveRecord(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 1945150601:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetDataGridActiveRecord_1945150601", 2, args.Length));
                    SetDataGridActiveRecord_1945150601(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavRecordId>(args[1]));
                    break;
                case 1083521742:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetInputType", 2, args.Length));
                    SetInputType(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToInt32(args[1]));
                    break;
                case -473009837:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetPosCtrlActiveInteraceProfile", 2, args.Length));
                    SetPosCtrlActiveInteraceProfile(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case -2021536941:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetPosCtrlActiveMenuProfile", 2, args.Length));
                    SetPosCtrlActiveMenuProfile(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case 61703294:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetStyleProfileFilters", 4, args.Length));
                    SetStyleProfileFilters(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]), (bool)ALCompiler.ObjectToBoolean(args[3]));
                    break;
                case -255122583:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetPosCtrlActiveStyle", 2, args.Length));
                    SetPosCtrlActiveStyle(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case 2079651057:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshStyleProfile", 0, args.Length));
                    RefreshStyleProfile();
                    break;
                case -1292026512:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshMenuProfile", 0, args.Length));
                    RefreshMenuProfile();
                    break;
                case -1960114225:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RefreshInterfaceProfile", 0, args.Length));
                    RefreshInterfaceProfile();
                    break;
                case -1198954231:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("DenyPanelClose", 0, args.Length));
                    DenyPanelClose();
                    break;
                case -419809427:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SelectGridColumn", 3, args.Length));
                    SelectGridColumn(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToInt32(args[2]));
                    break;
                case 370991525:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetGridSelectedColumn", 1, args.Length));
                    return GetGridSelectedColumn(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 216377196:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetGridSelectedColumn", 2, args.Length));
                    SetGridSelectedColumn(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case -580348916:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("RegisterPanelClosedEvent", 1, args.Length));
                    RegisterPanelClosedEvent(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 1067467051:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ResetDataGrid", 1, args.Length));
                    ResetDataGrid(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 377842909:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("Play", 1, args.Length));
                    Play(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 1199016765:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("PlayURL", 2, args.Length));
                    PlayURL(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case -556047278:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("Playlist", 2, args.Length));
                    Playlist(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavCode>(args[1]));
                    break;
                case -1185411703:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("AddToPlaylist", 2, args.Length));
                    AddToPlaylist(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case -895896274:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ClearPlaylist", 1, args.Length));
                    ClearPlaylist(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case -1826597639:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("Pause", 1, args.Length));
                    Pause(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 1137738475:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("Stop", 1, args.Length));
                    Stop(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 872094116:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("Next", 1, args.Length));
                    Next(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case -2129759905:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("Previous", 1, args.Length));
                    Previous(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 1048526931:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("Navigate", 2, args.Length));
                    Navigate(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case 473330946:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("Refresh", 1, args.Length));
                    Refresh(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 1716864790:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetPosDesignMode", 1, args.Length));
                    SetPosDesignMode((bool)ALCompiler.ObjectToBoolean(args[0]));
                    break;
                case 522608884:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetMenuDesignMode", 2, args.Length));
                    SetMenuDesignMode(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (bool)ALCompiler.ObjectToBoolean(args[1]));
                    break;
                case -1396412752:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetMenuLayoutStyle", 2, args.Length));
                    SetMenuLayoutStyle(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case -1069284296:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetMenuDragDropEnabled", 2, args.Length));
                    SetMenuDragDropEnabled(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (bool)ALCompiler.ObjectToBoolean(args[1]));
                    break;
                case 565192747:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetMenuBackgroundImage", 2, args.Length));
                    SetMenuBackgroundImage(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case 1125768672:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetSelectedButton", 2, args.Length));
                    SetSelectedButton(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case 559295265:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetSelectedButton", 1, args.Length));
                    return GetSelectedButton(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case 1073743772:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("JoinButtons", 3, args.Length));
                    JoinButtons(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (int)ALCompiler.ObjectToInt32(args[2]));
                    break;
                case -1491088661:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("DisJoinButtons", 3, args.Length));
                    DisJoinButtons(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (int)ALCompiler.ObjectToInt32(args[2]));
                    break;
                case 1103139611:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("IgnorePostCommand", 0, args.Length));
                    IgnorePostCommand();
                    break;
                case -190457558:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UpdateButtonSkin", 4, args.Length));
                    UpdateButtonSkin(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), ALCompiler.ObjectToExactINavRecordHandle(args[2]), ALCompiler.ObjectToExactNavValue<NavText>(args[3]));
                    break;
                case -1302451986:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SignalInputValidationError", 1, args.Length));
                    SignalInputValidationError(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case 1694892829:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetAutoLogoffTimeout", 1, args.Length));
                    SetAutoLogoffTimeout((int)ALCompiler.ObjectToInt32(args[0]));
                    break;
                case -1920769693:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("AddJavaScript", 1, args.Length));
                    AddJavaScript(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -563196171:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetPendingDataSets", 0, args.Length));
                    return GetPendingDataSets();
                    break;
                case -1655552905:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ClearPendingDataSets", 0, args.Length));
                    ClearPendingDataSets();
                    break;
                case -23237112:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetPendingRequests", 0, args.Length));
                    return GetPendingRequests();
                    break;
                case 881284016:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ClearPendingRequests", 0, args.Length));
                    ClearPendingRequests();
                    break;
                case 2141802178:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("AddPendingImage", 2, args.Length));
                    return AddPendingImage(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavJsonObject>(args[1]));
                    break;
                case 1342903854:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetPendingImages", 0, args.Length));
                    return GetPendingImages();
                    break;
                case -338626221:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ClearPendingImages", 0, args.Length));
                    ClearPendingImages();
                    break;
                case -997706454:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("AddPendingPlaylist", 2, args.Length));
                    AddPendingPlaylist(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavJsonArray>(args[1]));
                    break;
                case 1087796489:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetPendingPlaylists", 0, args.Length));
                    return GetPendingPlaylists();
                    break;
                case -826100241:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ClearPendingPlaylists", 0, args.Length));
                    ClearPendingPlaylists();
                    break;
                case 1518517134:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ClearImageCache", 1, args.Length));
                    return ClearImageCache((bool)ALCompiler.ObjectToBoolean(args[0]));
                    break;
                case -1846812199:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("BeforeUpdatePosAddin", 0, args.Length));
                    BeforeUpdatePosAddin();
                    break;
                case 480197483:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetModifiedControlsJSON", 0, args.Length));
                    return GetModifiedControlsJSON();
                    break;
                case -760945027:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetLanguage", 1, args.Length));
                    SetLanguage(ALCompiler.ObjectToExactNavValue<NavCode>(args[0]));
                    break;
                case -1274942724:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("UpdateMenuPermissions", 0, args.Length));
                    UpdateMenuPermissions();
                    break;
                case 1317268069:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetSelectedDate", 0, args.Length));
                    return GetSelectedDate();
                    break;
                case 1768324170:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetSelectedDate", 1, args.Length));
                    SetSelectedDate(ALCompiler.ObjectToExactNavValue<NavDateTime>(args[0]));
                    break;
                case 459504990:
                    if (args.Length != 4)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("PostEvent", 4, args.Length));
                    PostEvent(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]), ALCompiler.ObjectToExactNavValue<NavText>(args[2]), ALCompiler.ObjectToExactNavValue<NavText>(args[3]));
                    break;
                case -999906039:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SendPOSCommandEvent", 2, args.Length));
                    SendPOSCommandEvent(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), ALCompiler.ObjectToExactNavValue<NavText>(args[1]));
                    break;
                case 1640313108:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SignalNotImplemented", 1, args.Length));
                    SignalNotImplemented(ALCompiler.ObjectToExactNavValue<NavText>(args[0]));
                    break;
                case -544852330:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("LoadPosContextMenus", 0, args.Length));
                    LoadPosContextMenus();
                    break;
                case -692348430:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("LoadKeyCommands", 0, args.Length));
                    LoadKeyCommands();
                    break;
                case -748473358:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("LoadStandardPanels", 0, args.Length));
                    LoadStandardPanels();
                    break;
                case -315216445:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("CloseWindow", 0, args.Length));
                    CloseWindow();
                    break;
                case 2054812490:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("IsDualDisplay", 0, args.Length));
                    return IsDualDisplay();
                    break;
                case -2108379994:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ShowDualDisplay", 1, args.Length));
                    ShowDualDisplay((int)ALCompiler.ObjectToInt32(args[0]));
                    break;
                case -1818073535:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("SetDisplayNo", 1, args.Length));
                    SetDisplayNo((int)ALCompiler.ObjectToInt32(args[0]));
                    break;
                case 333473206:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetDisplayNo", 0, args.Length));
                    return GetDisplayNo();
                    break;
                case -508129505:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ProcessEvent", 1, args.Length));
                    return ProcessEvent(ALCompiler.ObjectToExactNavCodeunitHandle(args[0]));
                    break;
                case -773455029:
                    if (args.Length != 2)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("ShowTooltip", 2, args.Length));
                    ShowTooltip(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]));
                    break;
                case 1882405785:
                    if (args.Length != 1)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("GetSystemAppInfo", 1, args.Length));
                    GetSystemAppInfo(ALCompiler.ObjectToExactNavValue<NavJsonObject>(args[0]));
                    break;
                case -120667136:
                    if (args.Length != 3)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("PosMessageBanner", 3, args.Length));
                    PosMessageBanner(ALCompiler.ObjectToExactNavValue<NavText>(args[0]), (int)ALCompiler.ObjectToInt32(args[1]), (int)ALCompiler.ObjectToInt32(args[2]));
                    break;
                case -154410610:
                    if (args.Length != 0)
                        NavRuntimeHelpers.CompilationError(new NavNCLInvalidNumberOfArgumentsException("EnableDualDisplayMirroring", 0, args.Length));
                    EnableDualDisplayMirroring();
                    break;
                default:
                    NavRuntimeHelpers.CompilationError(Lang.WrongReference, memberId, 10012739);
                    break;
            }

            return null;
        }

        public static Codeunit10012739 __Construct(ITreeObject parent)
        {
            return new Codeunit10012739(parent);
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2435568077")]
        public void ActivateInput(NavText pControlID)
        {
            using (ActivateInput_Scope__1975704078 \u03b2scope = new ActivateInput_Scope__1975704078(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("ActivateInput")]
        [SignatureSpan(823877317153456155L)]
        [SourceSpans(824440254222106649L, 824721733493850178L, 825003191290757155L, 825284661972566024L)]
        private sealed class ActivateInput_Scope__1975704078 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            protected override uint RawScopeId { get => ActivateInput_Scope__1975704078.\u03b1scopeId; set => ActivateInput_Scope__1975704078.\u03b1scopeId = value; }

            internal ActivateInput_Scope__1975704078(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ActivateInput(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SetActiveInput(this.pControlID);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 876755216")]
        public NavText ActivePanelID_1371721810(ByRef<NavText> pPayload)
        {
            using (ActivePanelID_Scope__1371721810 \u03b2scope = new ActivePanelID_Scope__1371721810(this, pPayload))
            {
                \u03b2scope.Run();
                return \u03b2scope.panelID;
            }
        }

        [NavName("ActivePanelID")]
        [SignatureSpan(641763007179259931L)]
        [SourceSpans(642325931363008535L, 642607419224686628L, 642888898496430133L, 643451861334884387L, 643733340606627885L, 644014776928698376L)]
        private sealed class ActivePanelID_Scope__1371721810 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPayload")]
            public ByRef<NavText> pPayload;
            [ReturnValue("panelID")]
            [NavName("panelID")]
            public NavText panelID = NavText.Default(0);
            protected override uint RawScopeId { get => ActivePanelID_Scope__1371721810.\u03b1scopeId; set => ActivePanelID_Scope__1371721810.\u03b1scopeId = value; }

            internal ActivePanelID_Scope__1371721810(Codeunit10012739 \u03b2parent, ByRef<NavText> pPayload) : base(\u03b2parent)
            {
                this.pPayload = pPayload;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.pPayload.Value = new NavText("");
                if (CStmtHit(1) & (((int)ALCompiler.ObjectToInt32(base.Parent.modalPanelStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                {
                    StmtHit(2);
                    this.panelID = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.modalPanelStack.Target.Invoke(-856648329, new object[] { this.pPayload }));
                }
                else if (CStmtHit(3) & (((int)ALCompiler.ObjectToInt32(base.Parent.panelStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                {
                    StmtHit(4);
                    this.panelID = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.panelStack.Target.Invoke(918080733, Array.Empty<object>()));
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2477273042")]
        public NavText ActivePanelID()
        {
            using (ActivePanelID_Scope__297268737 \u03b2scope = new ActivePanelID_Scope__297268737(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.panelID;
            }
        }

        [NavName("ActivePanelID")]
        [SignatureSpan(639229732388274203L)]
        [SourceSpans(639792669456924708L, 640074148728668205L, 640637111567122467L, 640918590838865965L, 641200027160936456L)]
        private sealed class ActivePanelID_Scope__297268737 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue("panelID")]
            [NavName("panelID")]
            public NavText panelID = NavText.Default(0);
            protected override uint RawScopeId { get => ActivePanelID_Scope__297268737.\u03b1scopeId; set => ActivePanelID_Scope__297268737.\u03b1scopeId = value; }

            internal ActivePanelID_Scope__297268737(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (((int)ALCompiler.ObjectToInt32(base.Parent.modalPanelStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                {
                    StmtHit(1);
                    this.panelID = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.modalPanelStack.Target.Invoke(918080733, Array.Empty<object>()));
                }
                else if (CStmtHit(2) & (((int)ALCompiler.ObjectToInt32(base.Parent.panelStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                {
                    StmtHit(3);
                    this.panelID = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.panelStack.Target.Invoke(918080733, Array.Empty<object>()));
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4028517197")]
        public void AddGridDataSet(NavCode pControlID, NavText pDataTableID, NavJsonObject pDataJson, int pStartPageNo)
        {
            using (AddGridDataSet_Scope__1692269582 \u03b2scope = new AddGridDataSet_Scope__1692269582(this, pControlID, pDataTableID, pDataJson, pStartPageNo))
                \u03b2scope.Run();
        }

        [NavName("AddGridDataSet")]
        [SignatureSpan(908319810186313756L)]
        [SourceSpans(909727172185292825L, 910008651457036397L, 910290122138845209L, 910571601410588708L, 911134547069173788L, 911416026340917280L, 911978976294469715L, 912541909068152975L, 913104871906607159L, 913386364063252528L, 913667856219897885L, 914512285445193800L, 914793760421969973L, 916201096651145259L, 916482575922888747L, 917045508696571951L, 917326979378380808L)]
        private sealed class AddGridDataSet_Scope__1692269582 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pDataTableID")]
            public NavText pDataTableID;
            [NavName("pDataJson")]
            public NavJsonObject pDataJson;
            [NavName("pStartPageNo")]
            public int pStartPageNo;
            [NavName("dataID")]
            public NavText dataID = NavText.Default(0);
            [NavName("jt")]
            public NavJsonToken jt;
            protected override uint RawScopeId { get => AddGridDataSet_Scope__1692269582.\u03b1scopeId; set => AddGridDataSet_Scope__1692269582.\u03b1scopeId = value; }

            internal AddGridDataSet_Scope__1692269582(Codeunit10012739 \u03b2parent, NavCode pControlID, NavText pDataTableID, NavJsonObject pDataJson, int pStartPageNo) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pDataTableID = pDataTableID.ModifyLength(0);
                this.pDataJson = pDataJson;
                this.pStartPageNo = pStartPageNo;
                this.jt = NavJsonToken.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("AddGridDataSet(%1, %2, JSON, %3)", this.pControlID, this.pDataTableID, ALCompiler.ToNavValue(this.pStartPageNo))));
                }

                if (CStmtHit(2) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(3);
                    base.Parent.LogDeepTrace(this.pDataJson);
                }

                if (CStmtHit(4) & (this.pStartPageNo == -1))
                {
                    StmtHit(5);
                    this.dataID = new NavText(this.pControlID);
                }
                else
                {
                    StmtHit(6);
                    this.dataID = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.pControlID), this.pStartPageNo }));
                }

                StmtHit(7);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(5)), this.pDataTableID });
                if (CStmtHit(8) & (this.pControlID == NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 7)))))
                {
                    if (CStmtHit(9) & (this.pDataJson.ALGet(DataError.TrapError, "GoToRowIndex", new ByRef<NavJsonToken>(() => this.jt, setValue => this.jt = setValue))))
                        if (CStmtHit(10) & (this.jt.ALIsValue))
                        {
                            StmtHit(11);
                            base.Parent.GoToRow_1548454713(this.pControlID, this.jt.ALAsValue().ALAsInteger(), true);
                            StmtHit(12);
                            base.Parent.UpdateSelectedJournalLine(false);
                        }
                }

                if (CStmtHit(13) & (base.Parent.pendingDataSets.ALContains(this.dataID)))
                {
                    StmtHit(14);
                    base.Parent.pendingDataSets.ALRemove(this.dataID);
                }

                StmtHit(15);
                base.Parent.pendingDataSets.ALAdd(DataError.ThrowError, this.dataID, this.pDataJson);
            }
        }

        private void AddHiddenInput()
        {
            using (AddHiddenInput_Scope__949846135 \u03b2scope = new AddHiddenInput_Scope__949846135(this))
                \u03b2scope.Run();
        }

        [NavName("AddHiddenInput")]
        [SignatureSpan(323133359238414370L)]
        [SourceSpans(324540695467589657L, 324822174739333159L, 325385107513016349L, 325666582489792547L, 325948057466568787L, 326229532443344928L, 326511003125153800L)]
        private sealed class AddHiddenInput_Scope__949846135 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("inputID")]
            public static readonly NavTextConstant inputID = new NavTextConstant(new int[] { 1033 }, new string[] { "HIDDENINPUT" }, null, null);
            [NavName("panelID")]
            public static readonly NavTextConstant panelID = new NavTextConstant(new int[] { 1033 }, new string[] { "##HIDDENINPCONTAINER" }, null, null);
            protected override uint RawScopeId { get => AddHiddenInput_Scope__949846135.\u03b1scopeId; set => AddHiddenInput_Scope__949846135.\u03b1scopeId = value; }

            internal AddHiddenInput_Scope__949846135(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("AddHiddenInput"));
                }

                StmtHit(2);
                base.Parent.CreateInput(new NavText(inputID));
                StmtHit(3);
                base.Parent.CreatePanel(new NavText(panelID), 1, 1);
                StmtHit(4);
                base.Parent.ShowControl(new NavText(panelID), 1, 1, 1, 1, NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), new NavText(inputID));
                StmtHit(5);
                base.Parent.SetActiveInput(new NavText(inputID));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3495893381")]
        public void AddJavaScript(NavText script)
        {
            using (AddJavaScript_Scope__1920769693 \u03b2scope = new AddJavaScript_Scope__1920769693(this, script))
                \u03b2scope.Run();
        }

        [NavName("AddJavaScript")]
        [SignatureSpan(1087900845369524251L)]
        [SourceSpans(1088463769553272864L, 1088745240235081736L)]
        private sealed class AddJavaScript_Scope__1920769693 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("script")]
            public NavText script;
            protected override uint RawScopeId { get => AddJavaScript_Scope__1920769693.\u03b1scopeId; set => AddJavaScript_Scope__1920769693.\u03b1scopeId = value; }

            internal AddJavaScript_Scope__1920769693(Codeunit10012739 \u03b2parent, NavText script) : base(\u03b2parent)
            {
                this.script = script.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.javascripts.ALAdd(this.script);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2085994737")]
        public void AddJsonRequest(NavText elID, NavText jsonTxt)
        {
            using (AddJsonRequest_Scope_857619957 \u03b2scope = new AddJsonRequest_Scope_857619957(this, elID, jsonTxt))
                \u03b2scope.Run();
        }

        [NavName("AddJsonRequest")]
        [SignatureSpan(498492282654883877L)]
        [SourceSpans(499618118137479206L, 499899593114255416L, 500181068091031606L, 500462543067807778L, 501025493021360186L, 501588442974912536L, 501869913656721416L)]
        private sealed class AddJsonRequest_Scope_857619957 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("elID")]
            public NavText elID;
            [NavName("jsonTxt")]
            public NavText jsonTxt;
            [NavName("JSONUtil")]
            public NavCodeunitHandle jSONUtil;
            protected override uint RawScopeId { get => AddJsonRequest_Scope_857619957.\u03b1scopeId; set => AddJsonRequest_Scope_857619957.\u03b1scopeId = value; }

            internal AddJsonRequest_Scope_857619957(Codeunit10012739 \u03b2parent, NavText elID, NavText jsonTxt) : base(\u03b2parent)
            {
                this.elID = elID.ModifyLength(0);
                this.jsonTxt = jsonTxt.ModifyLength(0);
                this.jSONUtil = new NavCodeunitHandle(this, 1234);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.jSONUtil.Target.Invoke(-473954417, new object[] { new NavText("") });
                StmtHit(1);
                this.jSONUtil.Target.Invoke(-1675069947, new object[] { new NavText("ElementId"), ALCompiler.NavValueToVariant(this, this.elID) });
                StmtHit(2);
                this.jSONUtil.Target.Invoke(-1675069947, new object[] { new NavText("Json"), ALCompiler.NavValueToVariant(this, this.jsonTxt) });
                StmtHit(3);
                this.jSONUtil.Target.Invoke(2090071347, Array.Empty<object>());
                StmtHit(4);
                base.Parent.pendingJsonRequests.ALAdd(ALCompiler.ObjectToExactNavValue<NavText>(this.jSONUtil.Target.Invoke(1959899813, Array.Empty<object>())));
                StmtHit(5);
                this.jSONUtil.ClearReference();
            }
        }

        private void AddJsonRequest_870727125(NavText elID, NavRecordRef pRecRef)
        {
            using (AddJsonRequest_Scope_870727125 \u03b2scope = new AddJsonRequest_Scope_870727125(this, elID, pRecRef))
                \u03b2scope.Run();
        }

        [NavName("AddJsonRequest")]
        [SignatureSpan(502432919444848674L)]
        [SourceSpans(503840255674023964L, 504403227102412846L, 504684702079189042L, 504966177055965250L, 505247652032741417L, 505529127009517610L, 505810601986293823L, 506092076963069984L, 506373560529780770L, 506654988261916680L)]
        private sealed class AddJsonRequest_Scope_870727125 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("elID")]
            public NavText elID;
            [NavName("pRecRef")]
            public NavRecordRef pRecRef;
            [NavName("JSONUtil")]
            public NavCodeunitHandle jSONUtil;
            protected override uint RawScopeId { get => AddJsonRequest_Scope_870727125.\u03b1scopeId; set => AddJsonRequest_Scope_870727125.\u03b1scopeId = value; }

            internal AddJsonRequest_Scope_870727125(Codeunit10012739 \u03b2parent, NavText elID, NavRecordRef pRecRef) : base(\u03b2parent)
            {
                this.elID = elID.ModifyLength(0);
                this.pRecRef = pRecRef.ALByValue(this);
                this.jSONUtil = new NavCodeunitHandle(this, 1234);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.pRecRef.ALFind(DataError.TrapError, "-")))
                    do
                    {
                        StmtHit(1);
                        this.jSONUtil.Target.Invoke(-473954417, new object[] { new NavText("") });
                        StmtHit(2);
                        this.jSONUtil.Target.Invoke(83439927, new object[] { new NavText("Table") });
                        StmtHit(3);
                        base.Parent.pOSUTILS.Target.Invoke(-417084632, new object[] { new NavText(""), new ByRef<NavRecordRef>(() => this.pRecRef, setValue => this.pRecRef.ALAssign(setValue)), this.jSONUtil });
                        StmtHit(4);
                        this.jSONUtil.Target.Invoke(1034695779, Array.Empty<object>());
                        StmtHit(5);
                        this.jSONUtil.Target.Invoke(2090071347, Array.Empty<object>());
                        StmtHit(6);
                        base.Parent.AddJsonRequest(this.elID, ALCompiler.ObjectToExactNavValue<NavText>(this.jSONUtil.Target.Invoke(1959899813, Array.Empty<object>())));
                        StmtHit(7);
                        this.jSONUtil.ClearReference();
                    }
                    while (!(CStmtHit(8) & (this.pRecRef.ALNext() == 0)));
            }
        }

        private void AddMenuModifications(NavText pMenuID, int pButtonNo)
        {
            using (AddMenuModifications_Scope_408711262 \u03b2scope = new AddMenuModifications_Scope_408711262(this, pMenuID, pButtonNo))
                \u03b2scope.Run();
        }

        [NavName("AddMenuModifications")]
        [SignatureSpan(369013780452933672L)]
        [SourceSpans(370139641705332789L, 370421120977076253L, 370702595953852462L, 370984070930628625L, 371547003704311852L, 371828491565989924L, 372109970837733405L, 372391424339673096L)]
        private sealed class AddMenuModifications_Scope_408711262 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pButtonNo")]
            public int pButtonNo;
            [NavName("l")]
            public NavList<int> l = NavList<int>.Default;
            protected override uint RawScopeId { get => AddMenuModifications_Scope_408711262.\u03b1scopeId; set => AddMenuModifications_Scope_408711262.\u03b1scopeId = value; }

            internal AddMenuModifications_Scope_408711262(Codeunit10012739 \u03b2parent, NavText pMenuID, int pButtonNo) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pButtonNo = pButtonNo;
                this.l = NavList<int>.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!base.Parent.menuModifications.ALContainsKey(this.pMenuID)))
                {
                    StmtHit(1);
                    this.l.ALAdd(this.pButtonNo);
                    StmtHit(2);
                    base.Parent.menuModifications.ALAdd(DataError.ThrowError, this.pMenuID, this.l);
                    StmtHit(3);
                    return;
                }

                StmtHit(4);
                this.l = base.Parent.menuModifications.ALGet(this.pMenuID);
                if (CStmtHit(5) & (!this.l.ALContains(this.pButtonNo)))
                {
                    StmtHit(6);
                    this.l.ALAdd(this.pButtonNo);
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3264050846")]
        public NavText AddPendingImage(NavText imgCode, NavJsonObject imgObj)
        {
            using (AddPendingImage_Scope_2141802178 \u03b2scope = new AddPendingImage_Scope_2141802178(this, imgCode, imgObj))
            {
                \u03b2scope.Run();
                return \u03b2scope.oldUrl;
            }
        }

        [NavName("AddPendingImage")]
        [SignatureSpan(1094937719788929053L)]
        [SourceSpans(1096345081787908136L, 1096626573944553515L, 1096908053216297006L, 1097189506718236695L, 1097470998874882084L, 1097752478146625582L, 1098033948828434462L, 1098315428100177949L, 1098878356578893870L, 1099159835850637359L, 1099441289352577032L)]
        private sealed class AddPendingImage_Scope_2141802178 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("imgCode")]
            public NavText imgCode;
            [NavName("imgObj")]
            public NavJsonObject imgObj;
            [ReturnValue("oldUrl")]
            [NavName("oldUrl")]
            public NavText oldUrl = NavText.Default(0);
            [NavName("newUrl")]
            public NavText newUrl = NavText.Default(0);
            [NavName("jTok")]
            public NavJsonToken jTok;
            protected override uint RawScopeId { get => AddPendingImage_Scope_2141802178.\u03b1scopeId; set => AddPendingImage_Scope_2141802178.\u03b1scopeId = value; }

            internal AddPendingImage_Scope_2141802178(Codeunit10012739 \u03b2parent, NavText imgCode, NavJsonObject imgObj) : base(\u03b2parent)
            {
                this.imgCode = imgCode.ModifyLength(0);
                this.imgObj = imgObj;
                this.jTok = NavJsonToken.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.sentImages.ALGet(DataError.TrapError, this.imgCode, new ByRef<NavJsonToken>(() => this.jTok, setValue => this.jTok = setValue))))
                    if (CStmtHit(1) & (this.jTok.ALAsObject().ALGet(DataError.TrapError, "u", new ByRef<NavJsonToken>(() => this.jTok, setValue => this.jTok = setValue))))
                    {
                        StmtHit(2);
                        this.oldUrl = this.jTok.ALAsValue().ALAsText();
                    }

                if (CStmtHit(3) & (this.oldUrl != ""))
                {
                    if (CStmtHit(4) & (this.imgObj.ALGet(DataError.TrapError, "u", new ByRef<NavJsonToken>(() => this.jTok, setValue => this.jTok = setValue))))
                    {
                        StmtHit(5);
                        this.newUrl = this.jTok.ALAsValue().ALAsText();
                    }

                    if (CStmtHit(6) & (this.oldUrl == this.newUrl))
                    {
                        StmtHit(7);
                        this.oldUrl = this.oldUrl;
                        return;
                    }
                }

                if (CStmtHit(8) & (!base.Parent.pendingImages.ALContains(this.imgCode)))
                {
                    StmtHit(9);
                    base.Parent.pendingImages.ALAdd(DataError.ThrowError, this.imgCode, this.imgObj);
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1238816954")]
        public void AddPendingPlaylist(NavText playlistID, NavJsonArray playlistArr)
        {
            using (AddPendingPlaylist_Scope__997706454 \u03b2scope = new AddPendingPlaylist_Scope__997706454(this, playlistID, playlistArr))
                \u03b2scope.Run();
        }

        [NavName("AddPendingPlaylist")]
        [SignatureSpan(1103100494115438624L)]
        [SourceSpans(1105352281044746286L, 1105633760316489763L, 1105915235293265950L, 1106196710270042156L, 1106478211016622116L, 1106759690288365606L, 1107041182445010992L, 1107322661716754509L, 1107604102333792279L, 1107885560130699279L, 1108448505789284373L, 1108729997945929784L, 1109011477217673278L, 1109292913539743752L)]
        private sealed class AddPendingPlaylist_Scope__997706454 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("playlistID")]
            public NavText playlistID;
            [NavName("playlistArr")]
            public NavJsonArray playlistArr;
            [NavName("i")]
            public int i = default(int);
            [NavName("n")]
            public int n = default(int);
            [NavName("oldUrl")]
            public NavText oldUrl = NavText.Default(0);
            [NavName("newUrl")]
            public NavText newUrl = NavText.Default(0);
            [NavName("jTok")]
            public NavJsonToken jTok;
            [NavName("jTok2")]
            public NavJsonToken jTok2;
            [NavName("oldArr")]
            public NavJsonArray oldArr;
            [NavName("isSame")]
            public bool isSame = default(bool);
            protected override uint RawScopeId { get => AddPendingPlaylist_Scope__997706454.\u03b1scopeId; set => AddPendingPlaylist_Scope__997706454.\u03b1scopeId = value; }

            internal AddPendingPlaylist_Scope__997706454(Codeunit10012739 \u03b2parent, NavText playlistID, NavJsonArray playlistArr) : base(\u03b2parent)
            {
                this.playlistID = playlistID.ModifyLength(0);
                this.playlistArr = playlistArr;
                this.jTok = NavJsonToken.Default;
                this.jTok2 = NavJsonToken.Default;
                this.oldArr = NavJsonArray.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.sentPlaylists.ALGet(DataError.TrapError, this.playlistID, new ByRef<NavJsonToken>(() => this.jTok, setValue => this.jTok = setValue))))
                {
                    StmtHit(1);
                    this.oldArr = this.jTok.ALAsArray();
                    StmtHit(2);
                    this.n = this.oldArr.ALCount;
                    StmtHit(3);
                    this.isSame = this.n == this.playlistArr.ALCount;
                    while (CStmtHit(4) & ((this.i < this.n) & this.isSame))
                    {
                        if (CStmtHit(5) & (this.oldArr.ALGet(DataError.TrapError, this.i, new ByRef<NavJsonToken>(() => this.jTok, setValue => this.jTok = setValue))))
                            if (CStmtHit(6) & (this.playlistArr.ALGet(DataError.TrapError, this.i, new ByRef<NavJsonToken>(() => this.jTok2, setValue => this.jTok2 = setValue))))
                            {
                                StmtHit(7);
                                this.isSame = this.jTok.ALAsValue().ALAsText() == this.jTok2.ALAsValue().ALAsText();
                            }

                        StmtHit(8);
                        this.i = this.i + (1);
                    }

                    StmtHit(9);
                }

                if (CStmtHit(10) & (!this.isSame))
                    if (CStmtHit(11) & (!base.Parent.pendingPlaylists.ALContains(this.playlistID)))
                    {
                        StmtHit(12);
                        base.Parent.pendingPlaylists.ALAdd(DataError.ThrowError, this.playlistID, this.playlistArr);
                    }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 680292668")]
        public void AddToPlaylist(NavCode pControlID, NavText pURL)
        {
            using (AddToPlaylist_Scope__1185411703 \u03b2scope = new AddToPlaylist_Scope__1185411703(this, pControlID, pURL))
                \u03b2scope.Run();
        }

        [NavName("AddToPlaylist")]
        [SignatureSpan(1035827974665928731L)]
        [SourceSpans(1036390911734579225L, 1036672391006322764L, 1037235323780005972L, 1037516794461814792L)]
        private sealed class AddToPlaylist_Scope__1185411703 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pURL")]
            public NavText pURL;
            protected override uint RawScopeId { get => AddToPlaylist_Scope__1185411703.\u03b1scopeId; set => AddToPlaylist_Scope__1185411703.\u03b1scopeId = value; }

            internal AddToPlaylist_Scope__1185411703(Codeunit10012739 \u03b2parent, NavCode pControlID, NavText pURL) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pURL = pURL.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("AddToPlaylist(%1, %2)", this.pControlID, this.pURL)));
                }

                StmtHit(2);
                base.Parent.SendPOSCommandEvent(new NavText("PLAYLIST_ADD"), new NavText(ALSystemString.ALStrSubstNo("[%1]%2", this.pControlID, this.pURL)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 726213504")]
        public void BeforeUpdatePosAddin()
        {
            using (BeforeUpdatePosAddin_Scope__1846812199 \u03b2scope = new BeforeUpdatePosAddin_Scope__1846812199(this))
                \u03b2scope.Run();
        }

        [NavName("BeforeUpdatePosAddin")]
        [SignatureSpan(1120270467698786338L)]
        [SourceSpans(1121677829697765446L, 1121959308969508914L, 1122240766766415944L, 1122522241743192095L, 1122803729604870180L, 1123085208876613680L, 1123366666673520699L, 1123929629511974948L, 1124211108783718433L, 1124492583760494634L, 1125336991510954017L, 1125618462192762888L)]
        private sealed class BeforeUpdatePosAddin_Scope__1846812199 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("t")]
            public NavText t = NavText.Default(0);
            [NavName("wrapperDDPayLoad")]
            public NavText wrapperDDPayLoad = NavText.Default(0);
            protected override uint RawScopeId { get => BeforeUpdatePosAddin_Scope__1846812199.\u03b1scopeId; set => BeforeUpdatePosAddin_Scope__1846812199.\u03b1scopeId = value; }

            internal BeforeUpdatePosAddin_Scope__1846812199(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.modalPanelStack.Target.Invoke(918080733, Array.Empty<object>())) == NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 9)))))
                {
                    StmtHit(1);
                    base.Parent.modalPanelStack.Target.Invoke(-1534566709, new object[] { new ByRef<NavText>(() => this.wrapperDDPayLoad, setValue => this.wrapperDDPayLoad = setValue) });
                }

                StmtHit(2);
                base.Parent.SetMainControlValue_1893130901(new NavText(base.Parent._POS.Target.ALFieldName(42)), base.Parent.ActivePanelID());
                StmtHit(3);
                this.t = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.panelStack.Target.Invoke(918080733, Array.Empty<object>()));
                if (CStmtHit(4) & (((int)ALCompiler.ObjectToInt32(base.Parent.modalPanelStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                {
                    StmtHit(5);
                    this.t = new NavText(this.t + ("," + ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.modalPanelStack.Target.Invoke(798898786, Array.Empty<object>()))));
                }

                StmtHit(6);
                base.Parent.SetMainControlValue_1893130901(new NavText(base.Parent._POS.Target.ALFieldName(50)), this.t);
                if (CStmtHit(7) & (!base.Parent._standardPanelsLoaded))
                {
                    StmtHit(8);
                    base.Parent.LoadStandardPanels();
                    StmtHit(9);
                    base.Parent._standardPanelsLoaded = true;
                }

                StmtHit(10);
                base.Parent.currShowPanelModal = new NavText("");
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void BrowserRequest(NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008879)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound)
        {
            if (BrowserRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (BrowserRequest_Scope \u03b2scope = new BrowserRequest_Scope(this, pMainProfileID, pStoreProfileID, pControlID, pControlRec, pFound))
                \u03b2scope.RunEvent();
        }

        [NavName("BrowserRequest")]
        [SignatureSpan(202943544154980386L)]
        [SourceSpans(203506438273957896L)]
        private sealed class BrowserRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("pMainProfileID")]
            public NavText pMainProfileID;
            [NavName("pStoreProfileID")]
            public NavText pStoreProfileID;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pControlRec")]
            public INavRecordHandle pControlRec;
            [NavName("pFound")]
            public ByRef<bool> pFound;
            protected override uint RawScopeId { get => BrowserRequest_Scope.\u03b1scopeId; set => BrowserRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => BrowserRequest_Scope.\u03b3eventScope; set => BrowserRequest_Scope.\u03b3eventScope = value; }

            internal BrowserRequest_Scope(Codeunit10012739 \u03b2parent, NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008879)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound) : base(\u03b2parent)
            {
                this.pMainProfileID = pMainProfileID.ModifyLength(0);
                this.pStoreProfileID = pStoreProfileID.ModifyLength(0);
                this.pControlID = pControlID.ModifyLength(0);
                this.pControlRec = pControlRec;
                this.pFound = pFound;
            }
        }

        private NavText ButtonCaptionTypeText(NavOption caption)
        {
            using (ButtonCaptionTypeText_Scope_1331077949 \u03b2scope = new ButtonCaptionTypeText_Scope_1331077949(this, caption))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("ButtonCaptionTypeText")]
        [SignatureSpan(410672077015810089L)]
        [SourceSpans(411234988314656824L, 411516467586400317L, 411797925383307303L, 412079396065116168L)]
        private sealed class ButtonCaptionTypeText_Scope_1331077949 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("caption")]
            public NavOption caption;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => ButtonCaptionTypeText_Scope_1331077949.\u03b1scopeId; set => ButtonCaptionTypeText_Scope_1331077949.\u03b1scopeId = value; }

            internal ButtonCaptionTypeText_Scope_1331077949(Codeunit10012739 \u03b2parent, NavOption caption) : base(\u03b2parent)
            {
                this.caption = caption;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.caption == NavOption.Create(NCLEnumMetadata.Create(99008883), 0)))
                {
                    StmtHit(1);
                    this.\u03b3retVal = new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(3));
                    return;
                }

                StmtHit(2);
                this.\u03b3retVal = new NavText(NavFormatEvaluateHelper.Format(this.caption) + "Text");
                return;
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void ButtonPadRequest(NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008875)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound)
        {
            if (ButtonPadRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (ButtonPadRequest_Scope \u03b2scope = new ButtonPadRequest_Scope(this, pMainProfileID, pStoreProfileID, pControlID, pControlRec, pFound))
                \u03b2scope.RunEvent();
        }

        [NavName("ButtonPadRequest")]
        [SignatureSpan(180425546012885028L)]
        [SourceSpans(180988440131862536L)]
        private sealed class ButtonPadRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("pMainProfileID")]
            public NavText pMainProfileID;
            [NavName("pStoreProfileID")]
            public NavText pStoreProfileID;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pControlRec")]
            public INavRecordHandle pControlRec;
            [NavName("pFound")]
            public ByRef<bool> pFound;
            protected override uint RawScopeId { get => ButtonPadRequest_Scope.\u03b1scopeId; set => ButtonPadRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => ButtonPadRequest_Scope.\u03b3eventScope; set => ButtonPadRequest_Scope.\u03b3eventScope = value; }

            internal ButtonPadRequest_Scope(Codeunit10012739 \u03b2parent, NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008875)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound) : base(\u03b2parent)
            {
                this.pMainProfileID = pMainProfileID.ModifyLength(0);
                this.pStoreProfileID = pStoreProfileID.ModifyLength(0);
                this.pControlID = pControlID.ModifyLength(0);
                this.pControlRec = pControlRec;
                this.pFound = pFound;
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void ButtonPermissionRequest([NavObjectId(ObjectId = 99009054)][NavByReferenceAttribute] INavRecordHandle pMenuButtonRec, ByRef<NavList<NavRecordId>> pBlockedButtons)
        {
            if (ButtonPermissionRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (ButtonPermissionRequest_Scope \u03b2scope = new ButtonPermissionRequest_Scope(this, pMenuButtonRec, pBlockedButtons))
                \u03b2scope.RunEvent();
        }

        [NavName("ButtonPermissionRequest")]
        [SignatureSpan(1208935111153090603L)]
        [SourceSpans(1209498005272068104L)]
        private sealed class ButtonPermissionRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("pMenuButtonRec")]
            public INavRecordHandle pMenuButtonRec;
            [NavName("pBlockedButtons")]
            public ByRef<NavList<NavRecordId>> pBlockedButtons;
            protected override uint RawScopeId { get => ButtonPermissionRequest_Scope.\u03b1scopeId; set => ButtonPermissionRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => ButtonPermissionRequest_Scope.\u03b3eventScope; set => ButtonPermissionRequest_Scope.\u03b3eventScope = value; }

            internal ButtonPermissionRequest_Scope(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99009054)][NavByReferenceAttribute] INavRecordHandle pMenuButtonRec, ByRef<NavList<NavRecordId>> pBlockedButtons) : base(\u03b2parent)
            {
                this.pMenuButtonRec = pMenuButtonRec;
                this.pBlockedButtons = pBlockedButtons;
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void ButtonTranslationRequest(NavText pLanguageID, [NavObjectId(ObjectId = 99009054)][NavByReferenceAttribute] INavRecordHandle pMenuButtonRec, ByRef<NavList<NavRecordId>> pTranslatedButtons)
        {
            if (ButtonTranslationRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (ButtonTranslationRequest_Scope \u03b2scope = new ButtonTranslationRequest_Scope(this, pLanguageID, pMenuButtonRec, pTranslatedButtons))
                \u03b2scope.RunEvent();
        }

        [NavName("ButtonTranslationRequest")]
        [SignatureSpan(1207527736269209644L)]
        [SourceSpans(1208090630388187144L)]
        private sealed class ButtonTranslationRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("pLanguageID")]
            public NavText pLanguageID;
            [NavName("pMenuButtonRec")]
            public INavRecordHandle pMenuButtonRec;
            [NavName("pTranslatedButtons")]
            public ByRef<NavList<NavRecordId>> pTranslatedButtons;
            protected override uint RawScopeId { get => ButtonTranslationRequest_Scope.\u03b1scopeId; set => ButtonTranslationRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => ButtonTranslationRequest_Scope.\u03b3eventScope; set => ButtonTranslationRequest_Scope.\u03b3eventScope = value; }

            internal ButtonTranslationRequest_Scope(Codeunit10012739 \u03b2parent, NavText pLanguageID, [NavObjectId(ObjectId = 99009054)][NavByReferenceAttribute] INavRecordHandle pMenuButtonRec, ByRef<NavList<NavRecordId>> pTranslatedButtons) : base(\u03b2parent)
            {
                this.pLanguageID = pLanguageID.ModifyLength(0);
                this.pMenuButtonRec = pMenuButtonRec;
                this.pTranslatedButtons = pTranslatedButtons;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 213709981")]
        public bool ClearByTag(NavText pTag)
        {
            using (ClearByTag_Scope_1936110688 \u03b2scope = new ClearByTag_Scope_1936110688(this, pTag))
            {
                \u03b2scope.Run();
                return \u03b2scope.tagFound;
            }
        }

        [NavName("ClearByTag")]
        [SignatureSpan(74027979021680664L)]
        [SourceSpans(77124190881316884L, 77405670153060369L, 77968602926743585L, 78250077903912972L, 78531570060165156L, 78813057921843223L, 79094550078488616L, 79376029350232101L, 79938927764176907L, 80220398445985800L)]
        private sealed class ClearByTag_Scope_1936110688 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pTag")]
            public NavText pTag;
            [ReturnValue("tagFound")]
            [NavName("tagFound")]
            public bool tagFound = default(bool);
            [NavName("ks")]
            public NavList<NavText> ks = NavList<NavText>.Default;
            [NavName("k")]
            public NavText k = NavText.Default(0);
            [NavName("v")]
            public NavText v = NavText.Default(0);
            protected override uint RawScopeId { get => ClearByTag_Scope_1936110688.\u03b1scopeId; set => ClearByTag_Scope_1936110688.\u03b1scopeId = value; }

            internal ClearByTag_Scope_1936110688(Codeunit10012739 \u03b2parent, NavText pTag) : base(\u03b2parent)
            {
                this.pTag = pTag.ModifyLength(0);
                this.ks = NavList<NavText>.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.pTag == ""))
                {
                    StmtHit(1);
                    this.tagFound = this.tagFound;
                    return;
                }

                StmtHit(2);
                this.ks = base.Parent.contextTags.ALKeys;
                StmtHit(3);
                foreach (var @tmp0 in this.ks)
                {
                    this.k = @tmp0;
                    {
                        CStmtHit(4);
                        this.v = base.Parent.contextTags.ALGet(this.k);
                        if (CStmtHit(5) & (this.v == this.pTag))
                        {
                            if (CStmtHit(6) & (base.Parent.SetValue(this.k, new NavText("")) != ""))
                            {
                                StmtHit(7);
                                this.tagFound = true;
                            }
                        }
                    }
                }

                StmtHit(8);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1020202336")]
        public void ClearContext()
        {
            using (ClearContext_Scope_1773288141 \u03b2scope = new ClearContext_Scope_1773288141(this))
                \u03b2scope.Run();
        }

        [NavName("ClearContext")]
        [SignatureSpan(30399357621370906L)]
        [SourceSpans(30962294690021401L, 31243773961764901L, 31525231758671902L, 31806706735448098L, 32088181712224287L, 32369656689000490L, 32651131665776678L, 32932606642552875L, 33214077324361736L)]
        private sealed class ClearContext_Scope_1773288141 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => ClearContext_Scope_1773288141.\u03b1scopeId; set => ClearContext_Scope_1773288141.\u03b1scopeId = value; }

            internal ClearContext_Scope_1773288141(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("ClearContext"));
                }

                StmtHit(2);
                base.Parent.context.ClearReference();
                StmtHit(3);
                base.Parent.contextTags = NavDictionary<NavText, NavText>.Default;
                StmtHit(4);
                base.Parent.ClearModifiedContext();
                StmtHit(5);
                base.Parent._contextExpressions = NavDictionary<NavText, NavText>.Default;
                StmtHit(6);
                base.Parent._ignoreModifications = false;
                StmtHit(7);
                base.Parent._lastModifiedContext = NavDictionary<NavText, NavText>.Default;
            }
        }

        private void ClearControls()
        {
            using (ClearControls_Scope_56160456 \u03b2scope = new ClearControls_Scope_56160456(this))
                \u03b2scope.Run();
        }

        [NavName("ClearControls")]
        [SignatureSpan(299489461189214241L)]
        [SourceSpans(300615322441613337L, 300896801713356851L, 301459734487040029L, 302022684440592412L, 302304159417368617L, 302867109370920991L, 303148584347697187L, 303711534301249570L, 304274484254801951L, 304555959231578147L, 305118909185130529L, 305400384161906725L, 305963334115459101L, 306244809092235297L, 306526284069011494L, 306807759045787690L, 307089234022563876L, 307370708999340072L, 307933658952892444L, 308215133929668640L, 308496608906444834L, 308778083883221030L, 309341033836773407L, 309622508813549603L, 310185458767101985L, 310466933743878181L, 311029883697430560L, 311311358674206756L, 311874308627759138L, 312155783604535334L, 312718733558087711L, 313000208534863907L, 313563158488416285L, 313844633465192481L, 314407583418744870L, 314689058395521059L, 315252008349073439L, 315533483325849634L, 315814958302625825L, 316377908256178203L, 316659383232954392L, 316940858209730591L, 317503808163282984L, 317785283140059186L, 318066758116835388L, 318629708070387751L, 319192658023940129L, 319474133000716337L, 320037082954268697L, 320318553636077576L)]
        private sealed class ClearControls_Scope_56160456 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("SessionValues")]
            public NavCodeunitHandle sessionValues;
            protected override uint RawScopeId { get => ClearControls_Scope_56160456.\u03b1scopeId; set => ClearControls_Scope_56160456.\u03b1scopeId = value; }

            internal ClearControls_Scope_56160456(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
                this.sessionValues = new NavCodeunitHandle(this, 10012743);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText("ControlLib.ClearControls()"));
                }

                StmtHit(2);
                base.Parent._lastOpenPanel = new NavText("");
                StmtHit(3);
                base.Parent._CONTROLS.Target.ALDeleteAll();
                StmtHit(4);
                base.Parent._CONTROLS.Target.Invoke(1381847520, Array.Empty<object>());
                StmtHit(5);
                base.Parent._TAGGED_CONTROLS.Target.ALReset();
                StmtHit(6);
                base.Parent._TAGGED_CONTROLS.Target.ALDeleteAll();
                StmtHit(7);
                this.sessionValues.Target.Invoke(-956455984, Array.Empty<object>());
                StmtHit(8);
                base.Parent.loadedPanelsTemp.Target.ALReset();
                StmtHit(9);
                base.Parent.loadedPanelsTemp.Target.ALDeleteAll();
                StmtHit(10);
                base.Parent.loadedControlsTemp.Target.ALReset();
                StmtHit(11);
                base.Parent.loadedControlsTemp.Target.ALDeleteAll();
                StmtHit(12);
                base.Parent._PanelEntities.Target.ALReset();
                StmtHit(13);
                base.Parent._PanelEntities.Target.ALDeleteAll();
                StmtHit(14);
                base.Parent._PanelRowColumnEntities.Target.ALReset();
                StmtHit(15);
                base.Parent._PanelRowColumnEntities.Target.ALDeleteAll();
                StmtHit(16);
                base.Parent._PanelControlEntities.Target.ALReset();
                StmtHit(17);
                base.Parent._PanelControlEntities.Target.ALDeleteAll();
                StmtHit(18);
                base.Parent._MenuEntities.Target.ALReset();
                StmtHit(19);
                base.Parent._MenuEntities.Target.ALDeleteAll();
                StmtHit(20);
                base.Parent._MenuButtonEntities.Target.ALReset();
                StmtHit(21);
                base.Parent._MenuButtonEntities.Target.ALDeleteAll();
                StmtHit(22);
                base.Parent._InputEntities.Target.ALReset();
                StmtHit(23);
                base.Parent._InputEntities.Target.ALDeleteAll();
                StmtHit(24);
                base.Parent._ButtonPadEntities.Target.ALReset();
                StmtHit(25);
                base.Parent._ButtonPadEntities.Target.ALDeleteAll();
                StmtHit(26);
                base.Parent._DataGridEntities.Target.ALReset();
                StmtHit(27);
                base.Parent._DataGridEntities.Target.ALDeleteAll();
                StmtHit(28);
                base.Parent._RecordZoomEntities.Target.ALReset();
                StmtHit(29);
                base.Parent._RecordZoomEntities.Target.ALDeleteAll();
                StmtHit(30);
                base.Parent._BrowserEntities.Target.ALReset();
                StmtHit(31);
                base.Parent._BrowserEntities.Target.ALDeleteAll();
                StmtHit(32);
                base.Parent._MediaEntities.Target.ALReset();
                StmtHit(33);
                base.Parent._MediaEntities.Target.ALDeleteAll();
                StmtHit(34);
                base.Parent._TranslatedMenuButtons = NavList<NavRecordId>.Default;
                StmtHit(35);
                base.Parent._BlockedMenuButtons = NavList<NavRecordId>.Default;
                StmtHit(36);
                base.Parent.zoomDatasetJSON = NavDictionary<NavText, NavText>.Default;
                StmtHit(37);
                base.Parent.menuSelectedButton = NavDictionary<NavText, int>.Default;
                StmtHit(38);
                base.Parent.buttonPadMenuList = NavDictionary<NavText, NavList<NavText>>.Default;
                StmtHit(39);
                base.Parent.javascripts = NavJsonArray.Default;
                StmtHit(40);
                base.Parent.commands = NavJsonArray.Default;
                StmtHit(41);
                base.Parent.pendingDataSets = NavJsonObject.Default;
                StmtHit(42);
                base.Parent.panelStack.Target.Invoke(-557221328, new object[] { new NavText("PANELSTACK") });
                StmtHit(43);
                base.Parent.modalPanelStack.Target.Invoke(-557221328, new object[] { new NavText("MODALPANELSTACK") });
                StmtHit(44);
                base.Parent.panelClosedEventRegister.Target.Invoke(-557221328, new object[] { new NavText("CLOSEEVENTPANELS") });
                StmtHit(45);
                base.Parent._standardPanelsLoaded = false;
                StmtHit(46);
                base.Parent.currShowPanelModal = new NavText("");
                StmtHit(47);
                base.Parent.pendingShowPanelOnModalPanelClose = NavDictionary<NavText, NavText>.Default;
                StmtHit(48);
                base.Parent.AddHiddenInput();
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1247998564")]
        public NavJsonObject ClearImageCache(bool shouldGetCopy)
        {
            using (ClearImageCache_Scope_1518517134 \u03b2scope = new ClearImageCache_Scope_1518517134(this, shouldGetCopy))
            {
                \u03b2scope.Run();
                return \u03b2scope.jObj;
            }
        }

        [NavName("ClearImageCache")]
        [SignatureSpan(1112952156957311014L)]
        [SourceSpans(1113515055371255832L, 1113796534642999344L, 1114078009619775538L, 1114640942393458714L, 1114922417370234909L, 1115203888052043784L)]
        private sealed class ClearImageCache_Scope_1518517134 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("shouldGetCopy")]
            public bool shouldGetCopy;
            [ReturnValue("jObj")]
            [NavName("jObj")]
            public NavJsonObject jObj;
            protected override uint RawScopeId { get => ClearImageCache_Scope_1518517134.\u03b1scopeId; set => ClearImageCache_Scope_1518517134.\u03b1scopeId = value; }

            internal ClearImageCache_Scope_1518517134(Codeunit10012739 \u03b2parent, bool shouldGetCopy) : base(\u03b2parent)
            {
                this.shouldGetCopy = shouldGetCopy;
                this.jObj = NavJsonObject.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.shouldGetCopy))
                {
                    StmtHit(1);
                    this.jObj.ALAdd(DataError.ThrowError, "img", base.Parent.sentImages.ALClone());
                    StmtHit(2);
                    this.jObj.ALAdd(DataError.ThrowError, "pl", base.Parent.sentPlaylists.ALClone());
                }

                StmtHit(3);
                base.Parent.sentImages = NavJsonObject.Default;
                StmtHit(4);
                base.Parent.sentPlaylists = NavJsonObject.Default;
            }
        }

        private void ClearMarkedRecords_2109721568(NavCode pControlID, bool pSilent)
        {
            using (ClearMarkedRecords_Scope_2109721568 \u03b2scope = new ClearMarkedRecords_Scope_2109721568(this, pControlID, pSilent))
                \u03b2scope.Run();
        }

        [NavName("ClearMarkedRecords")]
        [SignatureSpan(895653462001188902L)]
        [SourceSpans(896779323253587993L, 897060802525331527L, 897623748183916562L, 897905227455660079L, 898186702432436276L, 899031110182895753L, 899594073021349906L, 899875552293093425L, 900157005795033096L)]
        private sealed class ClearMarkedRecords_Scope_2109721568 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pSilent")]
            public bool pSilent;
            [NavName("b")]
            public bool b = default(bool);
            protected override uint RawScopeId { get => ClearMarkedRecords_Scope_2109721568.\u03b1scopeId; set => ClearMarkedRecords_Scope_2109721568.\u03b1scopeId = value; }

            internal ClearMarkedRecords_Scope_2109721568(Codeunit10012739 \u03b2parent, NavCode pControlID, bool pSilent) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pSilent = pSilent;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ClearMarkedRecords(%1)", this.pControlID)));
                }

                if (CStmtHit(2) & (this.pSilent))
                {
                    StmtHit(3);
                    this.b = ((bool)ALCompiler.ObjectToBoolean(base.Parent._CONTROLS.Target.Invoke(-834379943, Array.Empty<object>())));
                    StmtHit(4);
                    base.Parent._CONTROLS.Target.Invoke(-1263557647, new object[] { true });
                }

                StmtHit(5);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1004)), new NavText("") });
                if (CStmtHit(6) & (this.pSilent))
                {
                    StmtHit(7);
                    base.Parent._CONTROLS.Target.Invoke(-1263557647, new object[] { this.b });
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3471716213")]
        public void ClearMarkedRecords(NavCode pControlID)
        {
            using (ClearMarkedRecords_Scope__86947684 \u03b2scope = new ClearMarkedRecords_Scope__86947684(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("ClearMarkedRecords")]
        [SignatureSpan(894246061347504160L)]
        [SourceSpans(894808985531252782L, 895090456213061640L)]
        private sealed class ClearMarkedRecords_Scope__86947684 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            protected override uint RawScopeId { get => ClearMarkedRecords_Scope__86947684.\u03b1scopeId; set => ClearMarkedRecords_Scope__86947684.\u03b1scopeId = value; }

            internal ClearMarkedRecords_Scope__86947684(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.ClearMarkedRecords_2109721568(this.pControlID, false);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2865446621")]
        public void ClearMenuModifications(NavText pMenuID)
        {
            using (ClearMenuModifications_Scope_338824207 \u03b2scope = new ClearMenuModifications_Scope_338824207(this, pMenuID))
                \u03b2scope.Run();
        }

        [NavName("ClearMenuModifications")]
        [SignatureSpan(382524553568387108L)]
        [SourceSpans(383087490637037617L, 383368969908781102L, 383650423410720776L)]
        private sealed class ClearMenuModifications_Scope_338824207 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            protected override uint RawScopeId { get => ClearMenuModifications_Scope_338824207.\u03b1scopeId; set => ClearMenuModifications_Scope_338824207.\u03b1scopeId = value; }

            internal ClearMenuModifications_Scope_338824207(Codeunit10012739 \u03b2parent, NavText pMenuID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.menuModifications.ALContainsKey(this.pMenuID)))
                {
                    StmtHit(1);
                    base.Parent.menuModifications.ALRemove(this.pMenuID);
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3353944468")]
        public void ClearModifiedContext()
        {
            using (ClearModifiedContext_Scope__1870184611 \u03b2scope = new ClearModifiedContext_Scope__1870184611(this))
                \u03b2scope.Run();
        }

        [NavName("ClearModifiedContext")]
        [SignatureSpan(33777057342685218L)]
        [SourceSpans(34339994411335705L, 34621473683079213L, 34902931479986214L, 35184402161795080L)]
        private sealed class ClearModifiedContext_Scope__1870184611 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => ClearModifiedContext_Scope__1870184611.\u03b1scopeId; set => ClearModifiedContext_Scope__1870184611.\u03b1scopeId = value; }

            internal ClearModifiedContext_Scope__1870184611(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("ClearModifiedContext"));
                }

                StmtHit(2);
                base.Parent.modifiedContext = NavJsonObject.Default;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1856878256")]
        public void ClearPendingDataSets()
        {
            using (ClearPendingDataSets_Scope__1655552905 \u03b2scope = new ClearPendingDataSets_Scope__1655552905(this))
                \u03b2scope.Run();
        }

        [NavName("ClearPendingDataSets")]
        [SignatureSpan(1090715595137286178L)]
        [SourceSpans(1091278519321034783L, 1091559990002843656L)]
        private sealed class ClearPendingDataSets_Scope__1655552905 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => ClearPendingDataSets_Scope__1655552905.\u03b1scopeId; set => ClearPendingDataSets_Scope__1655552905.\u03b1scopeId = value; }

            internal ClearPendingDataSets_Scope__1655552905(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.pendingDataSets = NavJsonObject.Default;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 13596322")]
        public void ClearPendingImages()
        {
            using (ClearPendingImages_Scope__338626221 \u03b2scope = new ClearPendingImages_Scope__338626221(this))
                \u03b2scope.Run();
        }

        [NavName("ClearPendingImages")]
        [SignatureSpan(1101411644254781472L)]
        [SourceSpans(1101974568438530098L, 1102256043415306269L, 1102537514097115144L)]
        private sealed class ClearPendingImages_Scope__338626221 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => ClearPendingImages_Scope__338626221.\u03b1scopeId; set => ClearPendingImages_Scope__338626221.\u03b1scopeId = value; }

            internal ClearPendingImages_Scope__338626221(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.MoveJsonValues(base.Parent.pendingImages, base.Parent.sentImages);
                StmtHit(1);
                base.Parent.pendingImages = NavJsonObject.Default;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1200696761")]
        public void ClearPendingPlaylists()
        {
            using (ClearPendingPlaylists_Scope__826100241 \u03b2scope = new ClearPendingPlaylists_Scope__826100241(this))
                \u03b2scope.Run();
        }

        [NavName("ClearPendingPlaylists")]
        [SignatureSpan(1111263268441948195L)]
        [SourceSpans(1111826192625696824L, 1112107667602472992L, 1112389138284281864L)]
        private sealed class ClearPendingPlaylists_Scope__826100241 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => ClearPendingPlaylists_Scope__826100241.\u03b1scopeId; set => ClearPendingPlaylists_Scope__826100241.\u03b1scopeId = value; }

            internal ClearPendingPlaylists_Scope__826100241(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.MoveJsonValues(base.Parent.pendingPlaylists, base.Parent.sentPlaylists);
                StmtHit(1);
                base.Parent.pendingPlaylists = NavJsonObject.Default;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1972114524")]
        public void ClearPendingRequests()
        {
            using (ClearPendingRequests_Scope_881284016 \u03b2scope = new ClearPendingRequests_Scope_881284016(this))
                \u03b2scope.Run();
        }

        [NavName("ClearPendingRequests")]
        [SignatureSpan(1093530344905048098L)]
        [SourceSpans(1094093269088796707L, 1094374739770605576L)]
        private sealed class ClearPendingRequests_Scope_881284016 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => ClearPendingRequests_Scope_881284016.\u03b1scopeId; set => ClearPendingRequests_Scope_881284016.\u03b1scopeId = value; }

            internal ClearPendingRequests_Scope_881284016(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.pendingJsonRequests = NavList<NavText>.Default;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 95104489")]
        public void ClearPlaylist(NavCode pControlID)
        {
            using (ClearPlaylist_Scope__895896274 \u03b2scope = new ClearPlaylist_Scope__895896274(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("ClearPlaylist")]
        [SignatureSpan(1038079774480138267L)]
        [SourceSpans(1038642711548788761L, 1038924190820532290L, 1039487123594215502L, 1039768594276024328L)]
        private sealed class ClearPlaylist_Scope__895896274 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            protected override uint RawScopeId { get => ClearPlaylist_Scope__895896274.\u03b1scopeId; set => ClearPlaylist_Scope__895896274.\u03b1scopeId = value; }

            internal ClearPlaylist_Scope__895896274(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ClearPlaylist(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SendPOSCommandEvent(new NavText("PLAYLIST_CLEAR"), new NavText(ALSystemString.ALStrSubstNo("[%1]", this.pControlID)));
            }
        }

        private void CloseAllDialogs()
        {
            using (CloseAllDialogs_Scope__1662400797 \u03b2scope = new CloseAllDialogs_Scope__1662400797(this))
                \u03b2scope.Run();
        }

        [NavName("CloseAllDialogs")]
        [SignatureSpan(495677520002220067L)]
        [SourceSpans(496240431301066777L, 496521910572810282L, 497084869116297255L, 497366348388040745L, 497929263981854728L)]
        private sealed class CloseAllDialogs_Scope__1662400797 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => CloseAllDialogs_Scope__1662400797.\u03b1scopeId; set => CloseAllDialogs_Scope__1662400797.\u03b1scopeId = value; }

            internal CloseAllDialogs_Scope__1662400797(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("CloseAllDialogs()"));
                }

                while (CStmtHit(2) & (((int)ALCompiler.ObjectToInt32(base.Parent.modalPanelStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                    if (CStmtHit(3) & (!base.Parent.HideActivePanel(false)))
                        break;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1879745678")]
        public void CloseWindow()
        {
            using (CloseWindow_Scope__315216445 \u03b2scope = new CloseWindow_Scope__315216445(this))
                \u03b2scope.Run();
        }

        [NavName("CloseWindow")]
        [SignatureSpan(1250311906969387033L)]
        [SourceSpans(1250874831153135665L, 1251156301834944520L)]
        private sealed class CloseWindow_Scope__315216445 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => CloseWindow_Scope__315216445.\u03b1scopeId; set => CloseWindow_Scope__315216445.\u03b1scopeId = value; }

            internal CloseWindow_Scope__315216445(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.SendPOSCommandEvent(new NavText("_CLOSE_WINDOW"), new NavText(""));
            }
        }

        private bool ContainsPanel(NavText pControlID)
        {
            using (ContainsPanel_Scope__12176236 \u03b2scope = new ContainsPanel_Scope__12176236(this, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.retVal;
            }
        }

        [NavName("ContainsPanel")]
        [SignatureSpan(553379890241339425L)]
        [SourceSpans(554505738608836647L, 554787213585612821L, 555068684267421704L)]
        private sealed class ContainsPanel_Scope__12176236 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [ReturnValue("retVal")]
            [NavName("retVal")]
            public bool retVal = default(bool);
            [NavName("lPanelRec")]
            public INavRecordHandle lPanelRec;
            protected override uint RawScopeId { get => ContainsPanel_Scope__12176236.\u03b1scopeId; set => ContainsPanel_Scope__12176236.\u03b1scopeId = value; }

            internal ContainsPanel_Scope__12176236(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.lPanelRec = new NavRecordHandle(this, 99008880, true, SecurityFiltering.Validated);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.retVal = base.Parent.GetPanel(this.pControlID);
                StmtHit(1);
                this.retVal = this.retVal;
                return;
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void ContextMenuRequest(NavText filterText, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil)
        {
            if (ContextMenuRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (ContextMenuRequest_Scope \u03b2scope = new ContextMenuRequest_Scope(this, filterText, jsonUtil))
                \u03b2scope.RunEvent();
        }

        [NavName("ContextMenuRequest")]
        [SignatureSpan(1204712986501447718L)]
        [SourceSpans(1205275880620425224L)]
        private sealed class ContextMenuRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("filterText")]
            public NavText filterText;
            [NavName("jsonUtil")]
            public NavCodeunitHandle jsonUtil;
            protected override uint RawScopeId { get => ContextMenuRequest_Scope.\u03b1scopeId; set => ContextMenuRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => ContextMenuRequest_Scope.\u03b3eventScope; set => ContextMenuRequest_Scope.\u03b3eventScope = value; }

            internal ContextMenuRequest_Scope(Codeunit10012739 \u03b2parent, NavText filterText, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil) : base(\u03b2parent)
            {
                this.filterText = filterText.ModifyLength(0);
                this.jsonUtil = jsonUtil;
            }
        }

        private bool ControlLoaded(NavOption pControlType, NavText pControlID)
        {
            using (ControlLoaded_Scope__287767883 \u03b2scope = new ControlLoaded_Scope__287767883(this, pControlType, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("ControlLoaded")]
        [SignatureSpan(97390427863908385L)]
        [SourceSpans(97953326277853217L, 98234801254629442L, 98516276231405627L, 98797751208181805L, 99079221889990664L)]
        private sealed class ControlLoaded_Scope__287767883 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            protected override uint RawScopeId { get => ControlLoaded_Scope__287767883.\u03b1scopeId; set => ControlLoaded_Scope__287767883.\u03b1scopeId = value; }

            internal ControlLoaded_Scope__287767883(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.loadedControlsTemp.Target.ALReset();
                StmtHit(1);
                base.Parent.loadedControlsTemp.Target.ALSetRangeSafe(2, NavType.Option, this.pControlType);
                StmtHit(2);
                base.Parent.loadedControlsTemp.Target.ALSetRangeSafe(4, NavType.Code, this.pControlID);
                StmtHit(3);
                this.\u03b3retVal = !base.Parent.loadedControlsTemp.Target.ALIsEmpty;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4091845662")]
        public void CreateButtonPad(NavText pControlID, NavText pDefaultMenuID)
        {
            using (CreateButtonPad_Scope__1203650873 \u03b2scope = new CreateButtonPad_Scope__1203650873(this, pControlID, pDefaultMenuID))
                \u03b2scope.Run();
        }

        [NavName("CreateButtonPad")]
        [SignatureSpan(661184780576817181L)]
        [SourceSpans(661747717645467673L, 662029196917211224L, 662592129690894368L, 662873604667670592L, 663155079644446771L, 663436554621222971L, 663718029597999156L, 663999504574775330L, 664562454528393324L, 665406892343558175L, 665688384500203580L, 665969863771947061L, 666251300094017544L)]
        private sealed class CreateButtonPad_Scope__1203650873 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pDefaultMenuID")]
            public NavText pDefaultMenuID;
            protected override uint RawScopeId { get => CreateButtonPad_Scope__1203650873.\u03b1scopeId; set => CreateButtonPad_Scope__1203650873.\u03b1scopeId = value; }

            internal CreateButtonPad_Scope__1203650873(Codeunit10012739 \u03b2parent, NavText pControlID, NavText pDefaultMenuID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pDefaultMenuID = pDefaultMenuID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("CreateButtonPad(%1, %2)", this.pControlID, this.pDefaultMenuID)));
                }

                StmtHit(2);
                base.Parent._ButtonPadEntities.Target.ALInit();
                StmtHit(3);
                base.Parent._ButtonPadEntities.Target.SetFieldValueSafe(1, NavType.Code, new NavCode(10, NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))));
                StmtHit(4);
                base.Parent._ButtonPadEntities.Target.SetFieldValueSafe(2, NavType.Code, new NavCode(20, this.pControlID));
                StmtHit(5);
                base.Parent._ButtonPadEntities.Target.SetFieldValueSafe(5, NavType.Code, new NavCode(20, this.pDefaultMenuID));
                StmtHit(6);
                base.Parent._ButtonPadEntities.Target.SetFieldValueSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(true));
                StmtHit(7);
                base.Parent._ButtonPadEntities.Target.ALInsert(DataError.ThrowError);
                StmtHit(8);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 0), this.pControlID, new NavText(base.Parent._SHARED.Target.ALFieldName(5)), NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 0).ToInt32() });
                if (CStmtHit(9) & (this.pDefaultMenuID != ""))
                    if (CStmtHit(10) & (!base.Parent.buttonPadMenuList.ALContainsKey(this.pControlID)))
                    {
                        StmtHit(11);
                        base.Parent.ShowMenu(new NavCode(20, this.pDefaultMenuID), new NavCode(20, this.pControlID));
                    }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3913985998")]
        public void CreateInput(NavText pControlID)
        {
            using (CreateInput_Scope__1813021575 \u03b2scope = new CreateInput_Scope__1813021575(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("CreateInput")]
        [SignatureSpan(677510329229836313L)]
        [SourceSpans(678073266298486809L, 678354745570230336L, 678917678343913500L, 679199153320689724L, 679480628297465903L, 679762103274242096L, 680043578251018270L, 680606528204636264L, 681169473863155720L)]
        private sealed class CreateInput_Scope__1813021575 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            protected override uint RawScopeId { get => CreateInput_Scope__1813021575.\u03b1scopeId; set => CreateInput_Scope__1813021575.\u03b1scopeId = value; }

            internal CreateInput_Scope__1813021575(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("CreateInput(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent._InputEntities.Target.ALInit();
                StmtHit(3);
                base.Parent._InputEntities.Target.SetFieldValueSafe(1, NavType.Code, new NavCode(10, NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))));
                StmtHit(4);
                base.Parent._InputEntities.Target.SetFieldValueSafe(2, NavType.Code, new NavCode(20, this.pControlID));
                StmtHit(5);
                base.Parent._InputEntities.Target.SetFieldValueSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(true));
                StmtHit(6);
                base.Parent._InputEntities.Target.ALInsert(DataError.ThrowError);
                StmtHit(7);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._SHARED.Target.ALFieldName(5)), NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1).ToInt32() });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3844321934")]
        public void CreateMenu(NavText pMenuID, int pColumns, int pRows, int pButtonSpacing)
        {
            using (CreateMenu_Scope_1455556540 \u03b2scope = new CreateMenu_Scope_1455556540(this, pMenuID, pColumns, pRows, pButtonSpacing))
                \u03b2scope.Run();
        }

        [NavName("CreateMenu")]
        [SignatureSpan(666814280112341016L)]
        [SourceSpans(667940167134543897L, 668221646406287420L, 668784579179970590L, 669066054156746819L, 669347529133522995L, 669629004110299170L, 670191954063851547L, 670473429040627771L, 670754904017403947L, 671036378994180143L, 671317853970956330L, 671599328947732516L, 671880803924508726L, 672162278901284893L, 672725228854902884L, 673569653785165860L, 673851128761942081L, 674132603738718257L, 674414078715494440L, 674977028669440012L, 675258520825692199L, 675539995802468421L, 675821470779244597L, 676102945756020782L, 676384433617698857L, 676665878529703947L, 676947349211512840L)]
        private sealed class CreateMenu_Scope_1455556540 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pColumns")]
            public int pColumns;
            [NavName("pRows")]
            public int pRows;
            [NavName("pButtonSpacing")]
            public int pButtonSpacing;
            [NavName("i")]
            public int i = default(int);
            protected override uint RawScopeId { get => CreateMenu_Scope_1455556540.\u03b1scopeId; set => CreateMenu_Scope_1455556540.\u03b1scopeId = value; }

            internal CreateMenu_Scope_1455556540(Codeunit10012739 \u03b2parent, NavText pMenuID, int pColumns, int pRows, int pButtonSpacing) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pColumns = pColumns;
                this.pRows = pRows;
                this.pButtonSpacing = pButtonSpacing;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("CreateMenu(%1)", this.pMenuID)));
                }

                StmtHit(2);
                base.Parent._MenuEntities.Target.ALReset();
                StmtHit(3);
                base.Parent._MenuEntities.Target.ALSetRangeSafe(10, NavType.Code, ALCompiler.ToNavValue(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))));
                StmtHit(4);
                base.Parent._MenuEntities.Target.ALSetRangeSafe(1, NavType.Code, this.pMenuID);
                StmtHit(5);
                base.Parent._MenuEntities.Target.ALDeleteAll();
                StmtHit(6);
                base.Parent._MenuEntities.Target.ALInit();
                StmtHit(7);
                base.Parent._MenuEntities.Target.SetFieldValueSafe(10, NavType.Code, new NavCode(20, NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))));
                StmtHit(8);
                base.Parent._MenuEntities.Target.SetFieldValueSafe(1, NavType.Code, new NavCode(20, this.pMenuID));
                StmtHit(9);
                base.Parent._MenuEntities.Target.SetFieldValueSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(true));
                StmtHit(10);
                base.Parent._MenuEntities.Target.SetFieldValueSafe(30, NavType.Integer, ALCompiler.ToNavValue(this.pColumns));
                StmtHit(11);
                base.Parent._MenuEntities.Target.SetFieldValueSafe(31, NavType.Integer, ALCompiler.ToNavValue(this.pRows));
                StmtHit(12);
                base.Parent._MenuEntities.Target.SetFieldValueSafe(300, NavType.Integer, ALCompiler.ToNavValue(this.pButtonSpacing));
                StmtHit(13);
                base.Parent._MenuEntities.Target.ALInsert(DataError.ThrowError);
                StmtHit(14);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), this.pMenuID, new NavText(base.Parent._SHARED.Target.ALFieldName(5)), NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7).ToInt32() });
                StmtHit(15);
                base.Parent._MenuButtonEntities.Target.ALReset();
                StmtHit(16);
                base.Parent._MenuButtonEntities.Target.SetFieldValueSafe(10, NavType.Code, new NavCode(20, NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))));
                StmtHit(17);
                base.Parent._MenuButtonEntities.Target.SetFieldValueSafe(1, NavType.Code, new NavCode(20, this.pMenuID));
                StmtHit(18);
                base.Parent._MenuButtonEntities.Target.ALDeleteAll();
                this.i = 1;
                StmtHit(19);
                int @tmp0 = this.pRows * this.pColumns;
                for (; this.i <= @tmp0;)
                {
                    {
                        CStmtHit(20);
                        base.Parent._MenuButtonEntities.Target.ALInit();
                        StmtHit(21);
                        base.Parent._MenuButtonEntities.Target.SetFieldValueSafe(10, NavType.Code, new NavCode(20, NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))));
                        StmtHit(22);
                        base.Parent._MenuButtonEntities.Target.SetFieldValueSafe(1, NavType.Code, new NavCode(20, this.pMenuID));
                        StmtHit(23);
                        base.Parent._MenuButtonEntities.Target.SetFieldValueSafe(2, NavType.Integer, ALCompiler.ToNavValue(this.i));
                        if (CStmtHit(24) & (base.Parent._MenuButtonEntities.Target.ALInsert(DataError.TrapError)))
                            ;
                    }

                    if (this.i >= @tmp0)
                        break;
                    this.i = this.i + 1;
                }

                StmtHit(25);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 693790929")]
        public void CreatePanel(NavText pPanelID, int pRows, int pColumns)
        {
            using (CreatePanel_Scope_1595898284 \u03b2scope = new CreatePanel_Scope_1595898284(this, pPanelID, pRows, pColumns))
                \u03b2scope.Run();
        }

        [NavName("CreatePanel")]
        [SignatureSpan(644577756947021849L)]
        [SourceSpans(645140694015672345L, 645422173287415895L, 645985106061099036L, 646548056014651437L, 646829530991427625L, 647111005968203823L, 647392480944980016L, 647673955921756190L, 648236905875374182L, 648799851533893640L)]
        private sealed class CreatePanel_Scope_1595898284 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("pRows")]
            public int pRows;
            [NavName("pColumns")]
            public int pColumns;
            protected override uint RawScopeId { get => CreatePanel_Scope_1595898284.\u03b1scopeId; set => CreatePanel_Scope_1595898284.\u03b1scopeId = value; }

            internal CreatePanel_Scope_1595898284(Codeunit10012739 \u03b2parent, NavText pPanelID, int pRows, int pColumns) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.pRows = pRows;
                this.pColumns = pColumns;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("CreatePanel(%1, %2, %3)", this.pPanelID, ALCompiler.ToNavValue(this.pRows), ALCompiler.ToNavValue(this.pColumns))));
                }

                StmtHit(2);
                base.Parent._PanelEntities.Target.ALInit();
                StmtHit(3);
                base.Parent._PanelEntities.Target.SetFieldValueSafe(2, NavType.Code, new NavCode(25, this.pPanelID));
                StmtHit(4);
                base.Parent._PanelEntities.Target.SetFieldValueSafe(4, NavType.Integer, ALCompiler.ToNavValue(this.pRows));
                StmtHit(5);
                base.Parent._PanelEntities.Target.SetFieldValueSafe(3, NavType.Integer, ALCompiler.ToNavValue(this.pColumns));
                StmtHit(6);
                base.Parent._PanelEntities.Target.SetFieldValueSafe(1000, NavType.Boolean, ALCompiler.ToNavValue(true));
                StmtHit(7);
                base.Parent._PanelEntities.Target.ALInsert(DataError.ThrowError);
                StmtHit(8);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2), this.pPanelID, new NavText(base.Parent._SHARED.Target.ALFieldName(5)), NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2).ToInt32() });
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void DataGridRequest(NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008876)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound)
        {
            if (DataGridRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (DataGridRequest_Scope \u03b2scope = new DataGridRequest_Scope(this, pMainProfileID, pStoreProfileID, pControlID, pControlRec, pFound))
                \u03b2scope.RunEvent();
        }

        [NavName("DataGridRequest")]
        [SignatureSpan(189432745269723171L)]
        [SourceSpans(189995639388700680L)]
        private sealed class DataGridRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("pMainProfileID")]
            public NavText pMainProfileID;
            [NavName("pStoreProfileID")]
            public NavText pStoreProfileID;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pControlRec")]
            public INavRecordHandle pControlRec;
            [NavName("pFound")]
            public ByRef<bool> pFound;
            protected override uint RawScopeId { get => DataGridRequest_Scope.\u03b1scopeId; set => DataGridRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => DataGridRequest_Scope.\u03b3eventScope; set => DataGridRequest_Scope.\u03b3eventScope = value; }

            internal DataGridRequest_Scope(Codeunit10012739 \u03b2parent, NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008876)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound) : base(\u03b2parent)
            {
                this.pMainProfileID = pMainProfileID.ModifyLength(0);
                this.pStoreProfileID = pStoreProfileID.ModifyLength(0);
                this.pControlID = pControlID.ModifyLength(0);
                this.pControlRec = pControlRec;
                this.pFound = pFound;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3154978060")]
        public void DeleteMenuButton(NavCode pMenuID, int pButtonNo, bool pRefreshMenu)
        {
            using (DeleteMenuButton_Scope_1722283205 \u03b2scope = new DeleteMenuButton_Scope_1722283205(this, pMenuID, pButtonNo, pRefreshMenu))
                \u03b2scope.Run();
        }

        [NavName("DeleteMenuButton")]
        [SignatureSpan(749849398261317662L)]
        [SourceSpans(750412322445066297L, 750693797421842490L, 750975285283520554L, 751256764555264044L, 751538252416942107L, 751819731688685605L, 752382642987532296L)]
        private sealed class DeleteMenuButton_Scope_1722283205 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [NavName("pButtonNo")]
            public int pButtonNo;
            [NavName("pRefreshMenu")]
            public bool pRefreshMenu;
            protected override uint RawScopeId { get => DeleteMenuButton_Scope_1722283205.\u03b1scopeId; set => DeleteMenuButton_Scope_1722283205.\u03b1scopeId = value; }

            internal DeleteMenuButton_Scope_1722283205(Codeunit10012739 \u03b2parent, NavCode pMenuID, int pButtonNo, bool pRefreshMenu) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
                this.pButtonNo = pButtonNo;
                this.pRefreshMenu = pRefreshMenu;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent._MenuButtonEntities.Target.ALSetRangeSafe(1, NavType.Code, this.pMenuID);
                StmtHit(1);
                base.Parent._MenuButtonEntities.Target.ALSetRangeSafe(2, NavType.Integer, ALCompiler.ToNavValue(this.pButtonNo));
                if (CStmtHit(2) & (!base.Parent._MenuButtonEntities.Target.ALIsEmpty))
                {
                    StmtHit(3);
                    base.Parent._MenuButtonEntities.Target.ALDeleteAll();
                    if (CStmtHit(4) & (this.pRefreshMenu))
                    {
                        StmtHit(5);
                        base.Parent.RefreshMenu(new NavText(this.pMenuID));
                    }
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1113898120")]
        public void DenyPanelClose()
        {
            using (DenyPanelClose_Scope__1198954231 \u03b2scope = new DenyPanelClose_Scope__1198954231(this))
                \u03b2scope.Run();
        }

        [NavName("DenyPanelClose")]
        [SignatureSpan(1016406201268371484L)]
        [SourceSpans(1016969138337021977L, 1017250617608765493L, 1017813550382448673L, 1018095021064257544L)]
        private sealed class DenyPanelClose_Scope__1198954231 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => DenyPanelClose_Scope__1198954231.\u03b1scopeId; set => DenyPanelClose_Scope__1198954231.\u03b1scopeId = value; }

            internal DenyPanelClose_Scope__1198954231(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("DenyPanelClose()")));
                }

                StmtHit(2);
                base.Parent.panelCloseDenied = true;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1436590211")]
        public void DisJoinButtons(NavCode menuID, int slaveButtonNo, int masterButtonNo)
        {
            using (DisJoinButtons_Scope__1491088661 \u03b2scope = new DisJoinButtons_Scope__1491088661(this, menuID, slaveButtonNo, masterButtonNo))
                \u03b2scope.Run();
        }

        [NavName("DisJoinButtons")]
        [SignatureSpan(1073545621553938460L)]
        [SourceSpans(1074108558622588953L, 1074390037894332518L, 1074952970668081273L, 1075515916326600712L)]
        private sealed class DisJoinButtons_Scope__1491088661 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("menuID")]
            public NavCode menuID;
            [NavName("slaveButtonNo")]
            public int slaveButtonNo;
            [NavName("masterButtonNo")]
            public int masterButtonNo;
            protected override uint RawScopeId { get => DisJoinButtons_Scope__1491088661.\u03b1scopeId; set => DisJoinButtons_Scope__1491088661.\u03b1scopeId = value; }

            internal DisJoinButtons_Scope__1491088661(Codeunit10012739 \u03b2parent, NavCode menuID, int slaveButtonNo, int masterButtonNo) : base(\u03b2parent)
            {
                this.menuID = menuID.ModifyLength(20);
                this.slaveButtonNo = slaveButtonNo;
                this.masterButtonNo = masterButtonNo;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("DisJoinButtons(%1, %2, %3)", this.menuID, ALCompiler.ToNavValue(this.slaveButtonNo), ALCompiler.ToNavValue(this.masterButtonNo))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.slaveButtonNo })), new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(657)), 0 });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3886163817")]
        public void EnableDualDisplayMirroring()
        {
            using (EnableDualDisplayMirroring_Scope__154410610 \u03b2scope = new EnableDualDisplayMirroring_Scope__154410610(this))
                \u03b2scope.Run();
        }

        [NavName("EnableDualDisplayMirroring")]
        [SignatureSpan(1283244479252201512L)]
        [SourceSpans(1283807416320852043L, 1284088895592595523L, 1284370349094535176L)]
        private sealed class EnableDualDisplayMirroring_Scope__154410610 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => EnableDualDisplayMirroring_Scope__154410610.\u03b1scopeId; set => EnableDualDisplayMirroring_Scope__154410610.\u03b1scopeId = value; }

            internal EnableDualDisplayMirroring_Scope__154410610(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!((bool)ALCompiler.ObjectToBoolean(base.Parent.modalPanelStack.Target.Invoke(-309671161, new object[] { new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 9)))) })))))
                {
                    StmtHit(1);
                    base.Parent.ShowPanelModal(new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 9)))), new NavText(""));
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2437492112")]
        public NavText GetActiveDataGrid()
        {
            using (GetActiveDataGrid_Scope_2043546529 \u03b2scope = new GetActiveDataGrid_Scope_2043546529(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetActiveDataGrid")]
        [SignatureSpan(921267659118018591L)]
        [SourceSpans(921830583301767238L, 922112053983576072L)]
        private sealed class GetActiveDataGrid_Scope_2043546529 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetActiveDataGrid_Scope_2043546529.\u03b1scopeId; set => GetActiveDataGrid_Scope_2043546529.\u03b1scopeId = value; }

            internal GetActiveDataGrid_Scope_2043546529(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.GetMainControlTextValue(new NavText(base.Parent._POS.Target.ALFieldName(43)));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2057823992")]
        public NavText GetActiveInput()
        {
            using (GetActiveInput_Scope__1467130609 \u03b2scope = new GetActiveInput_Scope__1467130609(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetActiveInput")]
        [SignatureSpan(806988818546884636L)]
        [SourceSpans(807551742730633283L, 807833213412442120L)]
        private sealed class GetActiveInput_Scope__1467130609 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetActiveInput_Scope__1467130609.\u03b1scopeId; set => GetActiveInput_Scope__1467130609.\u03b1scopeId = value; }

            internal GetActiveInput_Scope__1467130609(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.GetMainControlTextValue(new NavText(base.Parent._POS.Target.ALFieldName(41)));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 906200039")]
        public NavText GetActiveZoom()
        {
            using (GetActiveZoom_Scope_1971048403 \u03b2scope = new GetActiveZoom_Scope_1971048403(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetActiveZoom")]
        [SignatureSpan(933089608142618651L)]
        [SourceSpans(933652545211269145L, 933934024483012648L, 934496957256695880L, 934778427938504712L)]
        private sealed class GetActiveZoom_Scope_1971048403 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetActiveZoom_Scope_1971048403.\u03b1scopeId; set => GetActiveZoom_Scope_1971048403.\u03b1scopeId = value; }

            internal GetActiveZoom_Scope_1971048403(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText("GetActiveZoom()"));
                }

                StmtHit(2);
                this.\u03b3retVal = base.Parent.GetMainControlTextValue(new NavText(base.Parent._POS.Target.ALFieldName(44)));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 532156362")]
        public bool GetBrowser(NavText pControlID, [NavObjectId(ObjectId = 99008879)][NavByReferenceAttribute] INavRecordHandle pControlRec)
        {
            using (GetBrowser_Scope__1759405989 \u03b2scope = new GetBrowser_Scope__1759405989(this, pControlID, pControlRec))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetBrowser")]
        [SignatureSpan(197314018849652760L)]
        [SourceSpans(198439905871855641L, 198721385143599167L, 199002855825408068L, 199284347982053453L, 199565840138698832L, 199847319410442359L, 200128807272120352L, 200410286543863843L, 200973236497416300L, 201536117731491880L, 201817592708268051L, 202099063390076936L)]
        private sealed class GetBrowser_Scope__1759405989 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pControlRec")]
            public INavRecordHandle pControlRec;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("found")]
            public bool found = default(bool);
            protected override uint RawScopeId { get => GetBrowser_Scope__1759405989.\u03b1scopeId; set => GetBrowser_Scope__1759405989.\u03b1scopeId = value; }

            internal GetBrowser_Scope__1759405989(Codeunit10012739 \u03b2parent, NavText pControlID, [NavObjectId(ObjectId = 99008879)][NavByReferenceAttribute] INavRecordHandle pControlRec) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pControlRec = pControlRec;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetBrowser(%1)", this.pControlID)));
                }

                if (CStmtHit(2) & (!base.Parent._BrowserEntities.Target.ALGet(DataError.TrapError, base.Parent._InterfaceProfileID, this.pControlID)))
                    if (CStmtHit(3) & (!base.Parent._BrowserEntities.Target.ALGet(DataError.TrapError, base.Parent._StoreInterfaceProfileID, this.pControlID)))
                        if (CStmtHit(4) & (!base.Parent._BrowserEntities.Target.ALGet(DataError.TrapError, ALCompiler.ToNavValue(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))), this.pControlID)))
                        {
                            StmtHit(5);
                            base.Parent.BrowserRequest(base.Parent._InterfaceProfileID, base.Parent._StoreInterfaceProfileID, this.pControlID, base.Parent._BrowserEntities, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                            if (CStmtHit(6) & (!this.found))
                            {
                                StmtHit(7);
                                this.\u03b3retVal = false;
                                return;
                            }
                            else
                            {
                                StmtHit(8);
                                base.Parent.RefreshControlRuntimeProperties(NavOption.Create(NCLEnumMetadata.Create(99008881), 5), this.pControlID, false);
                            }
                        }

                StmtHit(9);
                this.pControlRec.ALAssign(base.Parent._BrowserEntities);
                StmtHit(10);
                this.\u03b3retVal = true;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1295063957")]
        public NavText GetButtonCaption(NavCode menuID, int buttonNo, NavOption caption)
        {
            using (GetButtonCaption_Scope_184570004 \u03b2scope = new GetButtonCaption_Scope_184570004(this, menuID, buttonNo, caption))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetButtonCaption")]
        [SignatureSpan(423901375154487326L)]
        [SourceSpans(424464299338301543L, 425027244996821000L)]
        private sealed class GetButtonCaption_Scope_184570004 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("menuID")]
            public NavCode menuID;
            [NavName("buttonNo")]
            public int buttonNo;
            [NavName("caption")]
            public NavOption caption;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetButtonCaption_Scope_184570004.\u03b1scopeId; set => GetButtonCaption_Scope_184570004.\u03b1scopeId = value; }

            internal GetButtonCaption_Scope_184570004(Codeunit10012739 \u03b2parent, NavCode menuID, int buttonNo, NavOption caption) : base(\u03b2parent)
            {
                this.menuID = menuID.ModifyLength(20);
                this.buttonNo = buttonNo;
                this.caption = caption;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent._CONTROLS.Target.Invoke(-1790301861, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.buttonNo })), base.Parent.ButtonCaptionTypeText(this.caption) }));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 38836594")]
        public NavList<NavText> GetButtonPadMenuList(NavCode pButtonPadID)
        {
            using (GetButtonPadMenuList_Scope__186771115 \u03b2scope = new GetButtonPadMenuList_Scope__186771115(this, pButtonPadID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetButtonPadMenuList")]
        [SignatureSpan(767019371844665378L)]
        [SourceSpans(768145258866868282L, 768426738138611769L, 768989670912294962L, 769271141594103816L)]
        private sealed class GetButtonPadMenuList_Scope__186771115 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pButtonPadID")]
            public NavCode pButtonPadID;
            [ReturnValue]
            public NavList<NavText> \u03b3retVal = NavList<NavText>.Default;
            [NavName("newList")]
            public NavList<NavText> newList = NavList<NavText>.Default;
            protected override uint RawScopeId { get => GetButtonPadMenuList_Scope__186771115.\u03b1scopeId; set => GetButtonPadMenuList_Scope__186771115.\u03b1scopeId = value; }

            internal GetButtonPadMenuList_Scope__186771115(Codeunit10012739 \u03b2parent, NavCode pButtonPadID) : base(\u03b2parent)
            {
                this.pButtonPadID = pButtonPadID.ModifyLength(20);
                this.newList = NavList<NavText>.Default;
                this.\u03b3retVal = NavList<NavText>.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!base.Parent.buttonPadMenuList.ALContainsKey(new NavText(this.pButtonPadID))))
                {
                    StmtHit(1);
                    base.Parent.buttonPadMenuList.ALAdd(DataError.ThrowError, new NavText(this.pButtonPadID), this.newList);
                }

                StmtHit(2);
                this.\u03b3retVal = base.Parent.buttonPadMenuList.ALGet(new NavText(this.pButtonPadID));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4202519030")]
        public NavText GetButtonPadMenu(NavCode pButtonPadID)
        {
            using (GetButtonPadMenu_Scope_554975115 \u03b2scope = new GetButtonPadMenu_Scope_554975115(this, pButtonPadID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetButtonPadMenu")]
        [SignatureSpan(762797247193022494L)]
        [SourceSpans(763923134215225402L, 764204613486968853L, 764767546260652083L, 765330509099106331L, 765611988370849813L, 766174921144533029L, 766456391826341896L)]
        private sealed class GetButtonPadMenu_Scope_554975115 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pButtonPadID")]
            public NavCode pButtonPadID;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            [NavName("menus")]
            public NavList<NavText> menus = NavList<NavText>.Default;
            protected override uint RawScopeId { get => GetButtonPadMenu_Scope_554975115.\u03b1scopeId; set => GetButtonPadMenu_Scope_554975115.\u03b1scopeId = value; }

            internal GetButtonPadMenu_Scope_554975115(Codeunit10012739 \u03b2parent, NavCode pButtonPadID) : base(\u03b2parent)
            {
                this.pButtonPadID = pButtonPadID.ModifyLength(20);
                this.menus = NavList<NavText>.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!base.Parent.buttonPadMenuList.ALContainsKey(new NavText(this.pButtonPadID))))
                {
                    StmtHit(1);
                    this.\u03b3retVal = new NavText("");
                    return;
                }

                StmtHit(2);
                base.Parent.buttonPadMenuList.ALGet(DataError.ThrowError, new NavText(this.pButtonPadID), new ByRef<NavList<NavText>>(() => this.menus, setValue => this.menus = setValue));
                if (CStmtHit(3) & (this.menus.ALCount <= 0))
                {
                    StmtHit(4);
                    this.\u03b3retVal = new NavText("");
                    return;
                }

                StmtHit(5);
                this.\u03b3retVal = this.menus.ALGet(this.menus.ALCount);
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2423959227")]
        public bool GetButtonPad(NavText pControlID)
        {
            using (GetButtonPad_Scope__512041359 \u03b2scope = new GetButtonPad_Scope__512041359(this, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetButtonPad")]
        [SignatureSpan(174233070754005018L)]
        [SourceSpans(175358957776207897L, 175640437047951425L, 175921907729760326L, 176203399886405711L, 176484892043051090L, 176766371314794619L, 177047859176472608L, 177329338448216099L, 177892301286670401L, 178173793443315788L, 178455272715059305L, 179299594566172691L, 179581065247981576L)]
        private sealed class GetButtonPad_Scope__512041359 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("found")]
            public bool found = default(bool);
            protected override uint RawScopeId { get => GetButtonPad_Scope__512041359.\u03b1scopeId; set => GetButtonPad_Scope__512041359.\u03b1scopeId = value; }

            internal GetButtonPad_Scope__512041359(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetButtonPad(%1)", this.pControlID)));
                }

                if (CStmtHit(2) & (!base.Parent._ButtonPadEntities.Target.ALGet(DataError.TrapError, base.Parent._InterfaceProfileID, this.pControlID)))
                    if (CStmtHit(3) & (!base.Parent._ButtonPadEntities.Target.ALGet(DataError.TrapError, base.Parent._StoreInterfaceProfileID, this.pControlID)))
                        if (CStmtHit(4) & (!base.Parent._ButtonPadEntities.Target.ALGet(DataError.TrapError, ALCompiler.ToNavValue(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))), this.pControlID)))
                        {
                            StmtHit(5);
                            base.Parent.ButtonPadRequest(base.Parent._InterfaceProfileID, base.Parent._StoreInterfaceProfileID, this.pControlID, base.Parent._ButtonPadEntities, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                            if (CStmtHit(6) & (!this.found))
                            {
                                StmtHit(7);
                                this.\u03b3retVal = false;
                                return;
                            }
                            else if (CStmtHit(8) & (((NavCode)base.Parent._ButtonPadEntities.Target.GetFieldValueSafe(5, NavType.Code)) != ""))
                            {
                                if (CStmtHit(9) & (!base.Parent.buttonPadMenuList.ALContainsKey(this.pControlID)))
                                {
                                    StmtHit(10);
                                    base.Parent.ShowMenu(((NavCode)base.Parent._ButtonPadEntities.Target.GetFieldValueSafe(5, NavType.Code)), ((NavCode)base.Parent._ButtonPadEntities.Target.GetFieldValueSafe(2, NavType.Code)));
                                }
                            }
                        }

                StmtHit(11);
                this.\u03b3retVal = true;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1338165546")]
        public void GetContext([NavObjectId(ObjectId = 10012722)][NavByReferenceAttribute] NavCodeunitHandle outCtx)
        {
            using (GetContext_Scope_600763662 \u03b2scope = new GetContext_Scope_600763662(this, outCtx))
                \u03b2scope.Run();
        }

        [NavName("GetContext")]
        [SignatureSpan(28991982737489944L)]
        [SourceSpans(29554906921238554L, 29836377603047432L)]
        private sealed class GetContext_Scope_600763662 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("outCtx")]
            public NavCodeunitHandle outCtx;
            protected override uint RawScopeId { get => GetContext_Scope_600763662.\u03b1scopeId; set => GetContext_Scope_600763662.\u03b1scopeId = value; }

            internal GetContext_Scope_600763662(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 10012722)][NavByReferenceAttribute] NavCodeunitHandle outCtx) : base(\u03b2parent)
            {
                this.outCtx = outCtx;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.outCtx.ALAssign(base.Parent.context);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 501958350")]
        public void GetControlJSON(NavOption pControlType, NavText pControlID, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil)
        {
            using (GetControlJSON_Scope_2119864146 \u03b2scope = new GetControlJSON_Scope_2119864146(this, pControlType, pControlID, jsonUtil))
                \u03b2scope.Run();
        }

        [NavName("GetControlJSON")]
        [SignatureSpan(210824817734909980L)]
        [SourceSpans(211387741918658626L, 211669212600467464L)]
        private sealed class GetControlJSON_Scope_2119864146 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("JsonUtil")]
            public NavCodeunitHandle jsonUtil;
            protected override uint RawScopeId { get => GetControlJSON_Scope_2119864146.\u03b1scopeId; set => GetControlJSON_Scope_2119864146.\u03b1scopeId = value; }

            internal GetControlJSON_Scope_2119864146(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
                this.jsonUtil = jsonUtil;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.GetControlJSON_670881381(this.pControlType, this.pControlID, this.jsonUtil, false);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 63310838")]
        public void GetControlJSON_670881381(NavOption pControlType, NavText pControlID, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil, bool pGetProtoType)
        {
            using (GetControlJSON_Scope_670881381 \u03b2scope = new GetControlJSON_Scope_670881381(this, pControlType, pControlID, jsonUtil, pGetProtoType))
                \u03b2scope.Run();
        }

        [NavName("GetControlJSON")]
        [SignatureSpan(212232192618790940L)]
        [SourceSpans(217298716430958683L, 217861679269412890L, 218143171426058272L, 218424650697801749L, 218987566296006668L, 219832042761551908L, 220113530623229999L, 220395009894973477L, 220957959848525875L, 221239417645432885L, 222365330437439545L, 222646809709183016L, 222928267506090037L, 224054180298096703L, 224335659569840171L, 224617117366747192L, 225743030158753843L, 226024509430497324L, 226305984407273533L, 227150409337602115L, 228276304949739587L, 228557784221483053L, 228839242018390074L, 229965154810396733L, 230246634082140202L, 230528091879047223L, 231654004671053881L, 231935483942797352L, 232216941739704373L, 233342854531711022L, 233624333803454502L, 234187283757006897L, 234468741553913908L, 235594641461018707L, 235876116437794891L, 236157591414571033L, 237001999165030476L, 237283474141806613L, 238409352574074908L, 238690831845818422L, 238972306822594594L, 239253781799895056L, 239535273956016191L, 239816748932792385L, 240098236794470426L, 240379728951115885L, 240661208222859356L, 240942661724799042L, 241224140996542558L, 241505581613580303L, 242350006544105488L, 242631498700554303L, 242912973677330522L, 243194431474237455L, 244038839224696903L, 244883277039927314L, 245164756311670848L, 245446209813610504L)]
        private sealed class GetControlJSON_Scope_670881381 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("JsonUtil")]
            public NavCodeunitHandle jsonUtil;
            [NavName("pGetProtoType")]
            public bool pGetProtoType;
            [NavName("panelRec")]
            public INavRecordHandle panelRec;
            [NavName("inputRec")]
            public INavRecordHandle inputRec;
            [NavName("dataGridRec")]
            public INavRecordHandle dataGridRec;
            [NavName("recordZoomRec")]
            public INavRecordHandle recordZoomRec;
            [NavName("buttonPadRec")]
            public INavRecordHandle buttonPadRec;
            [NavName("browserRec")]
            public INavRecordHandle browserRec;
            [NavName("mediaRec")]
            public INavRecordHandle mediaRec;
            [NavName("menuRec")]
            public INavRecordHandle menuRec;
            [NavName("controlRecRef")]
            public NavRecordRef controlRecRef;
            [NavName("controlFieldRef")]
            public NavFieldRef controlFieldRef;
            [NavName("controlRecRef2")]
            public NavRecordRef controlRecRef2;
            [NavName("controlFieldRef2")]
            public NavFieldRef controlFieldRef2;
            [NavName("i")]
            public int i = default(int);
            [NavName("isPanel")]
            public bool isPanel = default(bool);
            protected override uint RawScopeId { get => GetControlJSON_Scope_670881381.\u03b1scopeId; set => GetControlJSON_Scope_670881381.\u03b1scopeId = value; }

            internal GetControlJSON_Scope_670881381(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil, bool pGetProtoType) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
                this.jsonUtil = jsonUtil;
                this.pGetProtoType = pGetProtoType;
                this.panelRec = new NavRecordHandle(this, 99008880, true, SecurityFiltering.Validated);
                this.inputRec = new NavRecordHandle(this, 99008877, true, SecurityFiltering.Validated);
                this.dataGridRec = new NavRecordHandle(this, 99008876, true, SecurityFiltering.Validated);
                this.recordZoomRec = new NavRecordHandle(this, 99008878, true, SecurityFiltering.Validated);
                this.buttonPadRec = new NavRecordHandle(this, 99008875, true, SecurityFiltering.Validated);
                this.browserRec = new NavRecordHandle(this, 99008879, true, SecurityFiltering.Validated);
                this.mediaRec = new NavRecordHandle(this, 99008958, true, SecurityFiltering.Validated);
                this.menuRec = new NavRecordHandle(this, 99009053, true, SecurityFiltering.Validated);
                this.controlRecRef = new NavRecordRef(this, SecurityFiltering.Validated);
                this.controlFieldRef = new NavFieldRef(this);
                this.controlRecRef2 = new NavRecordRef(this, SecurityFiltering.Validated);
                this.controlFieldRef2 = new NavFieldRef(this);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("<<<< GetControlsJSON(%1, %2)", this.pControlType, this.pControlID)));
                if (CStmtHit(1) & (this.pControlID == ""))
                    if (CStmtHit(2) & (!this.pGetProtoType))
                    {
                        StmtHit(3);
                        return;
                    }

                StmtHit(4);
                NavOption @tmp1 = this.pControlType;
                if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2)) == 0))
                {
                    {
                        StmtHit(5);
                        this.isPanel = true;
                        if (CStmtHit(6) & (!base.Parent.GetPanel(this.pControlID)))
                        {
                            StmtHit(7);
                            this.panelRec.Target.ALInit();
                        }
                        else
                        {
                            StmtHit(8);
                            this.panelRec.ALAssign(base.Parent._PanelEntities);
                        }

                        StmtHit(9);
                        this.controlRecRef.ALGetTable(this.panelRec.Target);
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1)) == 0))
                {
                    {
                        if (CStmtHit(10) & (!base.Parent.GetInput(this.pControlID, this.inputRec)))
                        {
                            StmtHit(11);
                            this.inputRec.Target.ALInit();
                        }

                        StmtHit(12);
                        this.controlRecRef.ALGetTable(this.inputRec.Target);
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3)) == 0))
                {
                    {
                        if (CStmtHit(13) & (!base.Parent.GetDataGrid(this.pControlID, this.dataGridRec)))
                        {
                            StmtHit(14);
                            this.dataGridRec.Target.ALInit();
                        }

                        StmtHit(15);
                        this.controlRecRef.ALGetTable(this.dataGridRec.Target);
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 0)) == 0))
                {
                    {
                        if (CStmtHit(16) & (!base.Parent.GetButtonPad(this.pControlID)))
                        {
                            StmtHit(17);
                            this.buttonPadRec.Target.ALInit();
                            StmtHit(18);
                            this.controlRecRef.ALGetTable(this.buttonPadRec.Target);
                        }
                        else
                        {
                            StmtHit(19);
                            this.controlRecRef.ALGetTable(base.Parent._ButtonPadEntities.Target);
                        }
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 4)) == 0))
                {
                    {
                        if (CStmtHit(20) & (!base.Parent.GetRecordZoom(this.pControlID, this.recordZoomRec)))
                        {
                            StmtHit(21);
                            this.recordZoomRec.Target.ALInit();
                        }

                        StmtHit(22);
                        this.controlRecRef.ALGetTable(this.recordZoomRec.Target);
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 5)) == 0))
                {
                    {
                        if (CStmtHit(23) & (!base.Parent.GetBrowser(this.pControlID, this.browserRec)))
                        {
                            StmtHit(24);
                            this.browserRec.Target.ALInit();
                        }

                        StmtHit(25);
                        this.controlRecRef.ALGetTable(this.browserRec.Target);
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 6)) == 0))
                {
                    {
                        if (CStmtHit(26) & (!base.Parent.GetMedia(this.pControlID, this.mediaRec)))
                        {
                            StmtHit(27);
                            this.mediaRec.Target.ALInit();
                        }

                        StmtHit(28);
                        this.controlRecRef.ALGetTable(this.mediaRec.Target);
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7)) == 0))
                {
                    {
                        if (CStmtHit(29) & (!base.Parent.GetMenu(this.pControlID)))
                        {
                            StmtHit(30);
                            this.menuRec.Target.ALInit();
                        }
                        else
                        {
                            StmtHit(31);
                            this.menuRec.ALAssign(base.Parent._MenuEntities);
                        }

                        StmtHit(32);
                        this.controlRecRef.ALGetTable(this.menuRec.Target);
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8)) == 0))
                {
                    {
                        StmtHit(33);
                        base.Parent.GetSharedControlProperties(this.pControlType, this.pControlID, this.jsonUtil);
                        StmtHit(34);
                        base.Parent.GetMenuButtonJSON_1266558873(this.pControlID, this.jsonUtil, this.pGetProtoType);
                        StmtHit(35);
                        return;
                    }

                    goto @tmp0;
                }

                {
                    {
                        StmtHit(36);
                        base.Parent.LogDebug(new NavText("Unhandled CONTROL TYPE: " + NavFormatEvaluateHelper.Format(this.pControlType)));
                        StmtHit(37);
                        return;
                    }
                }

                @tmp0:
                    ;
                if (CStmtHit(38) & (!this.pGetProtoType))
                {
                    StmtHit(39);
                    this.controlRecRef2.ALOpen(CompilationTarget.Cloud, this.controlRecRef.ALNumber);
                    StmtHit(40);
                    this.controlRecRef2.ALInit();
                    this.i = 1;
                    StmtHit(41);
                    int @tmp2 = this.controlRecRef.ALFieldCount;
                    for (; this.i <= @tmp2;)
                    {
                        {
                            CStmtHit(42);
                            this.controlFieldRef.ALAssign(this.controlRecRef.ALFieldIndex(this, this.i));
                            StmtHit(43);
                            this.controlFieldRef2.ALAssign(this.controlRecRef2.ALFieldIndex(this, this.i));
                            if (CStmtHit(44) & (this.isPanel))
                                if (CStmtHit(45) & (this.controlFieldRef.ALNumber == base.Parent._PanelEntities.Target.ALFieldNo(25)))
                                {
                                    StmtHit(46);
                                    this.controlFieldRef.ALValue = base.Parent.GetPanelKeyCommandsButtonPadID(this.pControlID);
                                }

                            if (CStmtHit(47) & (!ALCompiler.CompareNavValues(this.controlFieldRef.ALValue, this.controlFieldRef2.ALValue)))
                            {
                                StmtHit(48);
                                base.Parent.WriteFieldPropertyToJSON(new NavText(this.controlFieldRef.ALName), new ByRef<NavFieldRef>(() => this.controlFieldRef, setValue => this.controlFieldRef.ALAssign(setValue)), this.jsonUtil);
                            }
                        }

                        if (this.i >= @tmp2)
                            break;
                        this.i = this.i + 1;
                    }

                    StmtHit(49);
                }
                else
                {
                    this.i = 1;
                    StmtHit(50);
                    int @tmp3 = this.controlRecRef.ALFieldCount;
                    for (; this.i <= @tmp3;)
                    {
                        {
                            CStmtHit(51);
                            this.controlFieldRef.ALAssign(this.controlRecRef.ALFieldIndex(this, this.i));
                            StmtHit(52);
                            base.Parent.WriteFieldPropertyToJSON(new NavText(this.controlFieldRef.ALName), new ByRef<NavFieldRef>(() => this.controlFieldRef, setValue => this.controlFieldRef.ALAssign(setValue)), this.jsonUtil);
                        }

                        if (this.i >= @tmp3)
                            break;
                        this.i = this.i + 1;
                    }

                    StmtHit(53);
                }

                StmtHit(54);
                base.Parent.GetSharedControlProperties(this.pControlType, this.pControlID, this.jsonUtil);
                if (CStmtHit(55) & (this.isPanel))
                {
                    StmtHit(56);
                    base.Parent.GetPanelRowColumnJSON(new NavText(((NavCode)this.panelRec.Target.GetFieldValueSafe(2, NavType.Code))), this.jsonUtil);
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3118926034")]
        public NavText GetDataGridActiveRecord(NavCode pControlID)
        {
            using (GetDataGridActiveRecord_Scope__1101006532 \u03b2scope = new GetDataGridActiveRecord_Scope__1101006532(this, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetDataGridActiveRecord")]
        [SignatureSpan(961518580797014053L)]
        [SourceSpans(962081517865664537L, 962362997137408076L, 962925929911091336L, 963207400592900104L)]
        private sealed class GetDataGridActiveRecord_Scope__1101006532 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetDataGridActiveRecord_Scope__1101006532.\u03b1scopeId; set => GetDataGridActiveRecord_Scope__1101006532.\u03b1scopeId = value; }

            internal GetDataGridActiveRecord_Scope__1101006532(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetDataGridActiveRecord(%1)", this.pControlID)));
                }

                StmtHit(2);
                this.\u03b3retVal = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent._CONTROLS.Target.Invoke(-1790301861, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1003)) }));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2073343409")]
        public int GetDataGridCurrentColumnIndex(NavText pControlID)
        {
            using (GetDataGridCurrentColumnIndex_Scope_358062519 \u03b2scope = new GetDataGridCurrentColumnIndex_Scope_358062519(this, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetDataGridCurrentColumnIndex")]
        [SignatureSpan(871165113251856427L)]
        [SourceSpans(871728050320506905L, 872009529592250450L, 872572462365933712L, 872853933047742472L)]
        private sealed class GetDataGridCurrentColumnIndex_Scope_358062519 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [ReturnValue]
            public int \u03b3retVal = default(int);
            protected override uint RawScopeId { get => GetDataGridCurrentColumnIndex_Scope_358062519.\u03b1scopeId; set => GetDataGridCurrentColumnIndex_Scope_358062519.\u03b1scopeId = value; }

            internal GetDataGridCurrentColumnIndex_Scope_358062519(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetDataGridCurrentColumnIndex(%1)", this.pControlID)));
                }

                StmtHit(2);
                this.\u03b3retVal = ALCompiler.ToInt32(((Decimal18)ALCompiler.ObjectToDecimal(base.Parent._CONTROLS.Target.Invoke(-820668825, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), this.pControlID, new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1001)) }))));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 176800036")]
        public int GetDataGridCurrentRowIndex(NavText pControlID)
        {
            using (GetDataGridCurrentRowIndex_Scope_2063763793 \u03b2scope = new GetDataGridCurrentRowIndex_Scope_2063763793(this, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetDataGridCurrentRowIndex")]
        [SignatureSpan(873416913066065960L)]
        [SourceSpans(873979850134716441L, 874261329406459983L, 874824262180143245L, 875105732861952008L)]
        private sealed class GetDataGridCurrentRowIndex_Scope_2063763793 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [ReturnValue]
            public int \u03b3retVal = default(int);
            protected override uint RawScopeId { get => GetDataGridCurrentRowIndex_Scope_2063763793.\u03b1scopeId; set => GetDataGridCurrentRowIndex_Scope_2063763793.\u03b1scopeId = value; }

            internal GetDataGridCurrentRowIndex_Scope_2063763793(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetDataGridCurrentRowIndex(%1)", this.pControlID)));
                }

                StmtHit(2);
                this.\u03b3retVal = ALCompiler.ToInt32(((Decimal18)ALCompiler.ObjectToDecimal(base.Parent._CONTROLS.Target.Invoke(-820668825, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), this.pControlID, new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1000)) }))));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3470976016")]
        public int GetDataGridMarkedRecordCount(NavCode pControlID)
        {
            using (GetDataGridMarkedRecordCount_Scope__410523668 \u03b2scope = new GetDataGridMarkedRecordCount_Scope__410523668(this, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetDataGridMarkedRecordCount")]
        [SignatureSpan(886927711951323178L)]
        [SourceSpans(888335073950302233L, 888616553222045777L, 889179485995729040L, 889460973857406999L, 889742453129150484L, 890023910926057518L, 890305385902833704L, 890586856584642568L)]
        private sealed class GetDataGridMarkedRecordCount_Scope__410523668 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [ReturnValue]
            public int \u03b3retVal = default(int);
            [NavName("recordIDStringArray")]
            public NavJsonArray recordIDStringArray;
            [NavName("tmpText")]
            public NavText tmpText = NavText.Default(0);
            protected override uint RawScopeId { get => GetDataGridMarkedRecordCount_Scope__410523668.\u03b1scopeId; set => GetDataGridMarkedRecordCount_Scope__410523668.\u03b1scopeId = value; }

            internal GetDataGridMarkedRecordCount_Scope__410523668(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.recordIDStringArray = NavJsonArray.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetDataGridMarkedRecordCount(%1)", this.pControlID)));
                }

                StmtHit(2);
                this.tmpText = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent._CONTROLS.Target.Invoke(-1790301861, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1004)) }));
                if (CStmtHit(3) & (this.tmpText == ""))
                {
                    StmtHit(4);
                    this.\u03b3retVal = 0;
                    return;
                }

                StmtHit(5);
                this.recordIDStringArray.ALReadFrom(DataError.ThrowError, this.tmpText);
                StmtHit(6);
                this.\u03b3retVal = this.recordIDStringArray.ALCount;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1996527538")]
        public NavText GetDataGridMarkedRecord(NavCode pControlID, int pIndex, bool pRemoveMark)
        {
            using (GetDataGridMarkedRecord_Scope__703752843 \u03b2scope = new GetDataGridMarkedRecord_Scope__703752843(this, pControlID, pIndex, pRemoveMark))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetDataGridMarkedRecord")]
        [SignatureSpan(879609362555142181L)]
        [SourceSpans(881298199530897433L, 881579678802641001L, 882142611576324240L, 882424099438002199L, 882705578709745685L, 883268511483428910L, 883831474321883190L, 884112953593626645L, 884675899252211734L, 884957378523955249L, 885238853500731462L, 886083261251190824L, 886364731932999688L)]
        private sealed class GetDataGridMarkedRecord_Scope__703752843 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pIndex")]
            public int pIndex;
            [NavName("pRemoveMark")]
            public bool pRemoveMark;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            [NavName("recordIDStringArray")]
            public NavJsonArray recordIDStringArray;
            [NavName("tmpText")]
            public NavText tmpText = NavText.Default(0);
            [NavName("jToken")]
            public NavJsonToken jToken;
            protected override uint RawScopeId { get => GetDataGridMarkedRecord_Scope__703752843.\u03b1scopeId; set => GetDataGridMarkedRecord_Scope__703752843.\u03b1scopeId = value; }

            internal GetDataGridMarkedRecord_Scope__703752843(Codeunit10012739 \u03b2parent, NavCode pControlID, int pIndex, bool pRemoveMark) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pIndex = pIndex;
                this.pRemoveMark = pRemoveMark;
                this.recordIDStringArray = NavJsonArray.Default;
                this.jToken = NavJsonToken.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetDataGridMarkedRecord(%1, %2, %3)", this.pControlID, ALCompiler.ToNavValue(this.pIndex), ALCompiler.ToNavValue(this.pRemoveMark))));
                }

                StmtHit(2);
                this.tmpText = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent._CONTROLS.Target.Invoke(-1790301861, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1004)) }));
                if (CStmtHit(3) & (this.tmpText == ""))
                {
                    StmtHit(4);
                    this.\u03b3retVal = new NavText("");
                    return;
                }

                StmtHit(5);
                this.recordIDStringArray.ALReadFrom(DataError.ThrowError, this.tmpText);
                if (CStmtHit(6) & (!this.recordIDStringArray.ALGet(DataError.TrapError, this.pIndex, new ByRef<NavJsonToken>(() => this.jToken, setValue => this.jToken = setValue))))
                {
                    StmtHit(7);
                    this.\u03b3retVal = new NavText("");
                    return;
                }

                if (CStmtHit(8) & (this.pRemoveMark))
                {
                    StmtHit(9);
                    this.recordIDStringArray.ALRemoveAt(DataError.ThrowError, this.pIndex);
                    StmtHit(10);
                    base.Parent.SetDataGridMarkedRecords(this.pControlID, this.recordIDStringArray);
                }

                StmtHit(11);
                this.\u03b3retVal = this.jToken.ALAsValue().ALAsText();
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 107442366")]
        public void GetDataGridMarkedRecords(NavText pControlID, ByRef<NavJsonArray> pRecordIDStringArray, bool pRemoveMarks)
        {
            using (GetDataGridMarkedRecords_Scope_748090293 \u03b2scope = new GetDataGridMarkedRecords_Scope_748090293(this, pControlID, pRecordIDStringArray, pRemoveMarks))
                \u03b2scope.Run();
        }

        [NavName("GetDataGridMarkedRecords")]
        [SignatureSpan(875668712880275494L)]
        [SourceSpans(876794599902478361L, 877076079174221927L, 877639011947905168L, 877920486924681263L, 878483449763135511L, 878764929034879019L, 879046382536818696L)]
        private sealed class GetDataGridMarkedRecords_Scope_748090293 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pRecordIDStringArray")]
            public ByRef<NavJsonArray> pRecordIDStringArray;
            [NavName("pRemoveMarks")]
            public bool pRemoveMarks;
            [NavName("tmpText")]
            public NavText tmpText = NavText.Default(0);
            protected override uint RawScopeId { get => GetDataGridMarkedRecords_Scope_748090293.\u03b1scopeId; set => GetDataGridMarkedRecords_Scope_748090293.\u03b1scopeId = value; }

            internal GetDataGridMarkedRecords_Scope_748090293(Codeunit10012739 \u03b2parent, NavText pControlID, ByRef<NavJsonArray> pRecordIDStringArray, bool pRemoveMarks) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pRecordIDStringArray = pRecordIDStringArray;
                this.pRemoveMarks = pRemoveMarks;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetDataGridMarkedRecords(%1,[Array], %2)", this.pControlID, ALCompiler.ToNavValue(this.pRemoveMarks))));
                }

                StmtHit(2);
                this.tmpText = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent._CONTROLS.Target.Invoke(-1790301861, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), this.pControlID, new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1004)) }));
                StmtHit(3);
                this.pRecordIDStringArray.Value.ALReadFrom(DataError.ThrowError, this.tmpText);
                if (CStmtHit(4) & (this.pRemoveMarks))
                {
                    StmtHit(5);
                    base.Parent.ClearMarkedRecords(new NavCode(20, this.pControlID));
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4077968276")]
        public bool GetDataGrid(NavText pControlID, [NavObjectId(ObjectId = 99008876)][NavByReferenceAttribute] INavRecordHandle pControlRec)
        {
            using (GetDataGrid_Scope__1028722889 \u03b2scope = new GetDataGrid_Scope__1028722889(this, pControlID, pControlRec))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetDataGrid")]
        [SignatureSpan(181551420150186009L)]
        [SourceSpans(182958782149165081L, 183240261420908608L, 183521732102717509L, 183803224259362894L, 184084716416008273L, 184366195687751801L, 184647683549429792L, 184929162821173283L, 185492112774725741L, 186054994008801323L, 186336481870479468L, 186617961142222908L, 186899436118999098L, 187180911095775269L, 188025318846234665L, 188306793823010835L, 188588264504819720L)]
        private sealed class GetDataGrid_Scope__1028722889 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pControlRec")]
            public INavRecordHandle pControlRec;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("found")]
            public bool found = default(bool);
            [NavName("txt")]
            public NavText txt = NavText.Default(0);
            protected override uint RawScopeId { get => GetDataGrid_Scope__1028722889.\u03b1scopeId; set => GetDataGrid_Scope__1028722889.\u03b1scopeId = value; }

            internal GetDataGrid_Scope__1028722889(Codeunit10012739 \u03b2parent, NavText pControlID, [NavObjectId(ObjectId = 99008876)][NavByReferenceAttribute] INavRecordHandle pControlRec) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pControlRec = pControlRec;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetDataGrid(%1)", this.pControlID)));
                }

                if (CStmtHit(2) & (!base.Parent._DataGridEntities.Target.ALGet(DataError.TrapError, base.Parent._InterfaceProfileID, this.pControlID)))
                    if (CStmtHit(3) & (!base.Parent._DataGridEntities.Target.ALGet(DataError.TrapError, base.Parent._StoreInterfaceProfileID, this.pControlID)))
                        if (CStmtHit(4) & (!base.Parent._DataGridEntities.Target.ALGet(DataError.TrapError, ALCompiler.ToNavValue(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))), this.pControlID)))
                        {
                            StmtHit(5);
                            base.Parent.DataGridRequest(base.Parent._InterfaceProfileID, base.Parent._StoreInterfaceProfileID, this.pControlID, base.Parent._DataGridEntities, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                            if (CStmtHit(6) & (!this.found))
                            {
                                StmtHit(7);
                                this.\u03b3retVal = false;
                                return;
                            }
                            else
                            {
                                StmtHit(8);
                                base.Parent.RefreshControlRuntimeProperties(NavOption.Create(NCLEnumMetadata.Create(99008881), 3), this.pControlID, false);
                            }
                        }

                StmtHit(9);
                this.txt = new NavText(((NavCode)base.Parent._DataGridEntities.Target.GetFieldValueSafe(2, NavType.Code)));
                if (CStmtHit(10) & ((this.txt == NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 7)))) | (NavTextExtensions.ALStartsWith(this.txt, new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 8))))))))
                {
                    StmtHit(11);
                    base.Parent._DataGridEntities.Target.SetFieldValueSafe(570, NavType.Boolean, ALCompiler.ToNavValue(true));
                    StmtHit(12);
                    base.Parent._DataGridEntities.Target.SetFieldValueSafe(1007, NavType.Boolean, ALCompiler.ToNavValue(true));
                    StmtHit(13);
                    base.Parent._DataGridEntities.Target.ALModify(DataError.ThrowError);
                }

                StmtHit(14);
                this.pControlRec.ALAssign(base.Parent._DataGridEntities);
                StmtHit(15);
                this.\u03b3retVal = true;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3835301553")]
        public int GetDisplayNo()
        {
            using (GetDisplayNo_Scope_333473206 \u03b2scope = new GetDisplayNo_Scope_333473206(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetDisplayNo")]
        [SignatureSpan(1259319106226225178L)]
        [SourceSpans(1259882030409973828L, 1260163501091782664L)]
        private sealed class GetDisplayNo_Scope_333473206 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public int \u03b3retVal = default(int);
            protected override uint RawScopeId { get => GetDisplayNo_Scope_333473206.\u03b1scopeId; set => GetDisplayNo_Scope_333473206.\u03b1scopeId = value; }

            internal GetDisplayNo_Scope_333473206(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.GetMainControlIntValue(new NavText(base.Parent._POS.Target.ALFieldName(11)));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 469434928")]
        public NavText GetGridDataTableID(NavCode pControlID)
        {
            using (GetGridDataTableID_Scope__1771868078 \u03b2scope = new GetGridDataTableID_Scope__1771868078(this, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetGridDataTableID")]
        [SignatureSpan(917889959396704288L)]
        [SourceSpans(918452883580452999L, 918734354262261768L)]
        private sealed class GetGridDataTableID_Scope__1771868078 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetGridDataTableID_Scope__1771868078.\u03b1scopeId; set => GetGridDataTableID_Scope__1771868078.\u03b1scopeId = value; }

            internal GetGridDataTableID_Scope__1771868078(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent._CONTROLS.Target.Invoke(-1790301861, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(5)) }));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 322040105")]
        public int GetGridSelectedColumn(NavCode pControlID)
        {
            using (GetGridSelectedColumn_Scope_370991525 \u03b2scope = new GetGridSelectedColumn_Scope_370991525(this, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetGridSelectedColumn")]
        [SignatureSpan(1021191275873566755L)]
        [SourceSpans(1021754212942217241L, 1022035692213960778L, 1022598624987644044L, 1022880095669452808L)]
        private sealed class GetGridSelectedColumn_Scope_370991525 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [ReturnValue]
            public int \u03b3retVal = default(int);
            protected override uint RawScopeId { get => GetGridSelectedColumn_Scope_370991525.\u03b1scopeId; set => GetGridSelectedColumn_Scope_370991525.\u03b1scopeId = value; }

            internal GetGridSelectedColumn_Scope_370991525(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetGridSelectedColumn(%1)", this.pControlID)));
                }

                StmtHit(2);
                this.\u03b3retVal = ALCompiler.ToInt32(((Decimal18)ALCompiler.ObjectToDecimal(base.Parent._CONTROLS.Target.Invoke(-820668825, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1002)) }))));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2947978226")]
        public bool GetInitialized()
        {
            using (GetInitialized_Scope__2010798666 \u03b2scope = new GetInitialized_Scope__2010798666(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetInitialized")]
        [SignatureSpan(95983027210223644L)]
        [SourceSpans(96545951393972251L, 96827422075781128L)]
        private sealed class GetInitialized_Scope__2010798666 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            protected override uint RawScopeId { get => GetInitialized_Scope__2010798666.\u03b1scopeId; set => GetInitialized_Scope__2010798666.\u03b1scopeId = value; }

            internal GetInitialized_Scope__2010798666(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent._Initialized;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3731044727")]
        public NavText GetInputText(NavText pControlID)
        {
            using (GetInputText_Scope__1985547946 \u03b2scope = new GetInputText_Scope__1985547946(this, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetInputText")]
        [SignatureSpan(811773893152079898L)]
        [SourceSpans(812336817335828604L, 812618288017637384L)]
        private sealed class GetInputText_Scope__1985547946 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetInputText_Scope__1985547946.\u03b1scopeId; set => GetInputText_Scope__1985547946.\u03b1scopeId = value; }

            internal GetInputText_Scope__1985547946(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent._CONTROLS.Target.Invoke(-1790301861, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(4)) }));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 943632622")]
        public bool GetInput(NavText pControlID, [NavObjectId(ObjectId = 99008877)][NavByReferenceAttribute] INavRecordHandle pControlRec)
        {
            using (GetInput_Scope__1269956108 \u03b2scope = new GetInput_Scope__1269956108(this, pControlID, pControlRec))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetInput")]
        [SignatureSpan(167477671311376406L)]
        [SourceSpans(168603558333579289L, 168885037605322813L, 169166508287131714L, 169448000443777099L, 169729492600422478L, 170010971872166003L, 170292459733844000L, 170573939005587491L, 171136888959139946L, 171699770193215526L, 171981245169991699L, 172262715851800584L)]
        private sealed class GetInput_Scope__1269956108 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pControlRec")]
            public INavRecordHandle pControlRec;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("found")]
            public bool found = default(bool);
            protected override uint RawScopeId { get => GetInput_Scope__1269956108.\u03b1scopeId; set => GetInput_Scope__1269956108.\u03b1scopeId = value; }

            internal GetInput_Scope__1269956108(Codeunit10012739 \u03b2parent, NavText pControlID, [NavObjectId(ObjectId = 99008877)][NavByReferenceAttribute] INavRecordHandle pControlRec) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pControlRec = pControlRec;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetInput(%1)", this.pControlID)));
                }

                if (CStmtHit(2) & (!base.Parent._InputEntities.Target.ALGet(DataError.TrapError, base.Parent._InterfaceProfileID, this.pControlID)))
                    if (CStmtHit(3) & (!base.Parent._InputEntities.Target.ALGet(DataError.TrapError, base.Parent._StoreInterfaceProfileID, this.pControlID)))
                        if (CStmtHit(4) & (!base.Parent._InputEntities.Target.ALGet(DataError.TrapError, ALCompiler.ToNavValue(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))), this.pControlID)))
                        {
                            StmtHit(5);
                            base.Parent.InputRequest(base.Parent._InterfaceProfileID, base.Parent._StoreInterfaceProfileID, this.pControlID, base.Parent._InputEntities, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                            if (CStmtHit(6) & (!this.found))
                            {
                                StmtHit(7);
                                this.\u03b3retVal = false;
                                return;
                            }
                            else
                            {
                                StmtHit(8);
                                base.Parent.RefreshControlRuntimeProperties(NavOption.Create(NCLEnumMetadata.Create(99008881), 1), this.pControlID, false);
                            }
                        }

                StmtHit(9);
                this.pControlRec.ALAssign(base.Parent._InputEntities);
                StmtHit(10);
                this.\u03b3retVal = true;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1050510709")]
        public void GetLastModifiedContext(ByRef<NavDictionary<NavText, NavText>> ctx)
        {
            using (GetLastModifiedContext_Scope_663556336 \u03b2scope = new GetLastModifiedContext_Scope_663556336(this, ctx))
                \u03b2scope.Run();
        }

        [NavName("GetLastModifiedContext")]
        [SignatureSpan(38280656971104292L)]
        [SourceSpans(38843581154852900L, 39125051836661768L)]
        private sealed class GetLastModifiedContext_Scope_663556336 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("ctx")]
            public ByRef<NavDictionary<NavText, NavText>> ctx;
            protected override uint RawScopeId { get => GetLastModifiedContext_Scope_663556336.\u03b1scopeId; set => GetLastModifiedContext_Scope_663556336.\u03b1scopeId = value; }

            internal GetLastModifiedContext_Scope_663556336(Codeunit10012739 \u03b2parent, ByRef<NavDictionary<NavText, NavText>> ctx) : base(\u03b2parent)
            {
                this.ctx = ctx;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.ctx.Value = base.Parent._lastModifiedContext;
            }
        }

        private int GetMainControlIntValue(NavText pFieldName)
        {
            using (GetMainControlIntValue_Scope_698597692 \u03b2scope = new GetMainControlIntValue_Scope_698597692(this, pFieldName))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetMainControlIntValue")]
        [SignatureSpan(82190779117994026L)]
        [SourceSpans(82753677531938943L, 83035148213747720L)]
        private sealed class GetMainControlIntValue_Scope_698597692 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pFieldName")]
            public NavText pFieldName;
            [ReturnValue]
            public int \u03b3retVal = default(int);
            protected override uint RawScopeId { get => GetMainControlIntValue_Scope_698597692.\u03b1scopeId; set => GetMainControlIntValue_Scope_698597692.\u03b1scopeId = value; }

            internal GetMainControlIntValue_Scope_698597692(Codeunit10012739 \u03b2parent, NavText pFieldName) : base(\u03b2parent)
            {
                this.pFieldName = pFieldName.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = ALCompiler.ToInt32(((Decimal18)ALCompiler.ObjectToDecimal(base.Parent._CONTROLS.Target.Invoke(-820668825, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 98), new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 2)))), this.pFieldName }))));
                return;
            }
        }

        private NavText GetMainControlTextValue(NavText pFieldName)
        {
            using (GetMainControlTextValue_Scope_1508084784 \u03b2scope = new GetMainControlTextValue_Scope_1508084784(this, pFieldName))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetMainControlTextValue")]
        [SignatureSpan(80783404234113067L)]
        [SourceSpans(81346302648057981L, 81627773329866760L)]
        private sealed class GetMainControlTextValue_Scope_1508084784 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pFieldName")]
            public NavText pFieldName;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetMainControlTextValue_Scope_1508084784.\u03b1scopeId; set => GetMainControlTextValue_Scope_1508084784.\u03b1scopeId = value; }

            internal GetMainControlTextValue_Scope_1508084784(Codeunit10012739 \u03b2parent, NavText pFieldName) : base(\u03b2parent)
            {
                this.pFieldName = pFieldName.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent._CONTROLS.Target.Invoke(-1790301861, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 98), new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 2)))), this.pFieldName }));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 327931953")]
        public bool GetMedia(NavText pControlID, [NavObjectId(ObjectId = 99008958)][NavByReferenceAttribute] INavRecordHandle pControlRec)
        {
            using (GetMedia_Scope__1923119507 \u03b2scope = new GetMedia_Scope__1923119507(this, pControlID, pControlRec))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetMedia")]
        [SignatureSpan(204069418292281366L)]
        [SourceSpans(205195305314484249L, 205476784586227773L, 205758255268036674L, 206039747424682059L, 206321239581327438L, 206602718853070963L, 206884206714748960L, 207165685986492451L, 207728635940044906L, 208291517174120486L, 208572992150896659L, 208854462832705544L)]
        private sealed class GetMedia_Scope__1923119507 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pControlRec")]
            public INavRecordHandle pControlRec;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("found")]
            public bool found = default(bool);
            protected override uint RawScopeId { get => GetMedia_Scope__1923119507.\u03b1scopeId; set => GetMedia_Scope__1923119507.\u03b1scopeId = value; }

            internal GetMedia_Scope__1923119507(Codeunit10012739 \u03b2parent, NavText pControlID, [NavObjectId(ObjectId = 99008958)][NavByReferenceAttribute] INavRecordHandle pControlRec) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pControlRec = pControlRec;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetMedia(%1)", this.pControlID)));
                }

                if (CStmtHit(2) & (!base.Parent._MediaEntities.Target.ALGet(DataError.TrapError, base.Parent._InterfaceProfileID, this.pControlID)))
                    if (CStmtHit(3) & (!base.Parent._MediaEntities.Target.ALGet(DataError.TrapError, base.Parent._StoreInterfaceProfileID, this.pControlID)))
                        if (CStmtHit(4) & (!base.Parent._MediaEntities.Target.ALGet(DataError.TrapError, ALCompiler.ToNavValue(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))), this.pControlID)))
                        {
                            StmtHit(5);
                            base.Parent.MediaRequest(base.Parent._InterfaceProfileID, base.Parent._StoreInterfaceProfileID, this.pControlID, base.Parent._MediaEntities, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                            if (CStmtHit(6) & (!this.found))
                            {
                                StmtHit(7);
                                this.\u03b3retVal = false;
                                return;
                            }
                            else
                            {
                                StmtHit(8);
                                base.Parent.RefreshControlRuntimeProperties(NavOption.Create(NCLEnumMetadata.Create(99008881), 6), this.pControlID, false);
                            }
                        }

                StmtHit(9);
                this.pControlRec.ALAssign(base.Parent._MediaEntities);
                StmtHit(10);
                this.\u03b3retVal = true;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3222797454")]
        public NavText GetMenuButtonJSON_1266558873(NavText menuButtonID, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil, bool pGetProtoType)
        {
            using (GetMenuButtonJSON_Scope__1266558873 \u03b2scope = new GetMenuButtonJSON_Scope__1266558873(this, menuButtonID, jsonUtil, pGetProtoType))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetMenuButtonJSON")]
        [SignatureSpan(271623412718567455L)]
        [SourceSpans(275001099554979868L, 275282591711625248L, 275564070983368725L, 276126986577182788L, 276689949415637016L, 276971441572282400L, 277252920844025877L, 277815836437839897L, 278097324299518024L, 278378816456163409L, 278660308612808793L, 278941787884552237L, 279223275746230312L, 279786229994750033L, 280067704971526208L, 280349179948302401L, 280630654925078592L, 281193587698761792L, 281475062675537956L, 282319448951160854L, 282600928222904376L, 283163860996587570L, 283445335973363742L, 283726810950467596L, 284008303106785339L, 284289778083561533L, 284571265945239614L, 284852745216983130L, 285134185834020875L, 285415656515829768L)]
        private sealed class GetMenuButtonJSON_Scope__1266558873 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("MenuButtonID")]
            public NavText menuButtonID;
            [NavName("JsonUtil")]
            public NavCodeunitHandle jsonUtil;
            [NavName("pGetProtoType")]
            public bool pGetProtoType;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            [NavName("missingButtonEntity")]
            public INavRecordHandle missingButtonEntity;
            [NavName("controlRecRef")]
            public NavRecordRef controlRecRef;
            [NavName("controlRecRef2")]
            public NavRecordRef controlRecRef2;
            [NavName("controlFieldRef")]
            public NavFieldRef controlFieldRef;
            [NavName("controlFieldRef2")]
            public NavFieldRef controlFieldRef2;
            [NavName("i")]
            public int i = default(int);
            [NavName("menuID")]
            public NavText menuID = NavText.Default(0);
            [NavName("buttonNo")]
            public int buttonNo = default(int);
            [NavName("missing")]
            public bool missing = default(bool);
            protected override uint RawScopeId { get => GetMenuButtonJSON_Scope__1266558873.\u03b1scopeId; set => GetMenuButtonJSON_Scope__1266558873.\u03b1scopeId = value; }

            internal GetMenuButtonJSON_Scope__1266558873(Codeunit10012739 \u03b2parent, NavText menuButtonID, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil, bool pGetProtoType) : base(\u03b2parent)
            {
                this.menuButtonID = menuButtonID.ModifyLength(0);
                this.jsonUtil = jsonUtil;
                this.pGetProtoType = pGetProtoType;
                this.missingButtonEntity = new NavRecordHandle(this, 99009054, false, SecurityFiltering.Validated);
                this.controlRecRef = new NavRecordRef(this, SecurityFiltering.Validated);
                this.controlRecRef2 = new NavRecordRef(this, SecurityFiltering.Validated);
                this.controlFieldRef = new NavFieldRef(this);
                this.controlFieldRef2 = new NavFieldRef(this);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.menuButtonID == ""))
                    if (CStmtHit(1) & (!this.pGetProtoType))
                    {
                        StmtHit(2);
                        return;
                    }

                StmtHit(3);
                base.Parent.pOSUTILS.Target.Invoke(-2094906302, new object[] { this.menuButtonID, new ByRef<NavText>(() => this.menuID, setValue => this.menuID = setValue), new ByRef<int>(() => this.buttonNo, setValue => this.buttonNo = setValue) });
                if (CStmtHit(4) & (this.buttonNo <= 0))
                    if (CStmtHit(5) & (!this.pGetProtoType))
                    {
                        StmtHit(6);
                        return;
                    }

                StmtHit(7);
                this.missing = false;
                if (CStmtHit(8) & (!base.Parent._MenuButtonEntities.Target.ALGet(DataError.TrapError, base.Parent._MenuProfileID, this.menuID, ALCompiler.ToNavValue(this.buttonNo))))
                    if (CStmtHit(9) & (!base.Parent._MenuButtonEntities.Target.ALGet(DataError.TrapError, base.Parent._StoreMenuProfileID, this.menuID, ALCompiler.ToNavValue(this.buttonNo))))
                        if (CStmtHit(10) & (!base.Parent._MenuButtonEntities.Target.ALGet(DataError.TrapError, ALCompiler.ToNavValue(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))), this.menuID, ALCompiler.ToNavValue(this.buttonNo))))
                        {
                            StmtHit(11);
                            this.missingButtonEntity.Target.ALInit();
                            if (CStmtHit(12) & (!this.pGetProtoType))
                            {
                                StmtHit(13);
                                this.missingButtonEntity.Target.SetFieldValueSafe(10, NavType.Code, new NavCode(20, NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))));
                                StmtHit(14);
                                this.missingButtonEntity.Target.SetFieldValueSafe(1, NavType.Code, new NavCode(20, this.menuID));
                                StmtHit(15);
                                this.missingButtonEntity.Target.SetFieldValueSafe(2, NavType.Integer, ALCompiler.ToNavValue(this.buttonNo));
                                StmtHit(16);
                                this.missingButtonEntity.Target.SetFieldValueSafe(1201, NavType.Boolean, ALCompiler.ToNavValue(true));
                            }

                            StmtHit(17);
                            this.controlRecRef.ALGetTable(this.missingButtonEntity.Target);
                            StmtHit(18);
                            this.missing = true;
                        }

                if (CStmtHit(19) & (!this.missing))
                {
                    StmtHit(20);
                    this.controlRecRef.ALGetTable(base.Parent._MenuButtonEntities.Target);
                }

                StmtHit(21);
                this.controlRecRef2.ALOpen(CompilationTarget.Cloud, this.controlRecRef.ALNumber);
                StmtHit(22);
                this.controlRecRef2.ALInit();
                this.i = 1;
                StmtHit(23);
                int @tmp0 = this.controlRecRef.ALFieldCount;
                for (; this.i <= @tmp0;)
                {
                    {
                        CStmtHit(24);
                        this.controlFieldRef.ALAssign(this.controlRecRef.ALFieldIndex(this, this.i));
                        StmtHit(25);
                        this.controlFieldRef2.ALAssign(this.controlRecRef2.ALFieldIndex(this, this.i));
                        if (CStmtHit(26) & (!ALCompiler.CompareNavValues(this.controlFieldRef.ALValue, this.controlFieldRef2.ALValue)))
                        {
                            StmtHit(27);
                            base.Parent.WriteFieldPropertyToJSON(new NavText(this.controlFieldRef.ALName), new ByRef<NavFieldRef>(() => this.controlFieldRef, setValue => this.controlFieldRef.ALAssign(setValue)), this.jsonUtil);
                        }
                    }

                    if (this.i >= @tmp0)
                        break;
                    this.i = this.i + 1;
                }

                StmtHit(28);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2305203974")]
        public NavText GetMenuButtonJSON(NavText menuButtonID, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil)
        {
            using (GetMenuButtonJSON_Scope__668445662 \u03b2scope = new GetMenuButtonJSON_Scope__668445662(this, menuButtonID, jsonUtil))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetMenuButtonJSON")]
        [SignatureSpan(270216037834686495L)]
        [SourceSpans(270778962018435135L, 271060432700243976L)]
        private sealed class GetMenuButtonJSON_Scope__668445662 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("MenuButtonID")]
            public NavText menuButtonID;
            [NavName("JsonUtil")]
            public NavCodeunitHandle jsonUtil;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetMenuButtonJSON_Scope__668445662.\u03b1scopeId; set => GetMenuButtonJSON_Scope__668445662.\u03b1scopeId = value; }

            internal GetMenuButtonJSON_Scope__668445662(Codeunit10012739 \u03b2parent, NavText menuButtonID, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil) : base(\u03b2parent)
            {
                this.menuButtonID = menuButtonID.ModifyLength(0);
                this.jsonUtil = jsonUtil;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.GetMenuButtonJSON_1266558873(this.menuButtonID, this.jsonUtil, false);
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4230950815")]
        public NavList<int> GetMenuModifiedButtonValues(NavCode menuID, int buttonNo)
        {
            using (GetMenuModifiedButtonValues_Scope_972933181 \u03b2scope = new GetMenuModifiedButtonValues_Scope_972933181(this, menuID, buttonNo))
            {
                \u03b2scope.Run();
                return \u03b2scope.l;
            }
        }

        [NavName("GetMenuModifiedButtonValues")]
        [SignatureSpan(372954404357996585L)]
        [SourceSpans(374361766356975667L, 374643245628719121L, 374924703425626179L, 375206191287304218L, 375487683443949666L, 375769128355954813L, 376050616217632785L, 376332095489376298L, 376613553286283281L, 376895028263059581L, 377176516124737553L, 377457995396481066L, 377739453193388049L, 378020928170164350L, 378302416031842321L, 378583895303585835L, 378865353100492817L, 379146828077269119L, 379428315938947089L, 379709795210690604L, 379991253007597585L, 380272723689406472L)]
        private sealed class GetMenuModifiedButtonValues_Scope_972933181 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("menuID")]
            public NavCode menuID;
            [NavName("buttonNo")]
            public int buttonNo;
            [ReturnValue("l")]
            [NavName("l")]
            public NavList<int> l = NavList<int>.Default;
            [NavName("id")]
            public NavText id = NavText.Default(0);
            [NavName("i")]
            public int i = default(int);
            protected override uint RawScopeId { get => GetMenuModifiedButtonValues_Scope_972933181.\u03b1scopeId; set => GetMenuModifiedButtonValues_Scope_972933181.\u03b1scopeId = value; }

            internal GetMenuModifiedButtonValues_Scope_972933181(Codeunit10012739 \u03b2parent, NavCode menuID, int buttonNo) : base(\u03b2parent)
            {
                this.menuID = menuID.ModifyLength(20);
                this.buttonNo = buttonNo;
                this.l = NavList<int>.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.GetMenuModifiedButtons(new NavText(this.menuID)).ALCount < 1))
                {
                    StmtHit(1);
                    this.l = this.l;
                    return;
                }

                StmtHit(2);
                this.id = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.buttonNo }));
                if (CStmtHit(3) & (base.Parent.GetMenu(new NavText(this.menuID))))
                    if (CStmtHit(4) & (base.Parent._MenuButtonEntities.Target.ALGet(DataError.TrapError, ((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(10, NavType.Code)), ((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(1, NavType.Code)), ALCompiler.ToNavValue(this.buttonNo))))
                        ;
                StmtHit(5);
                this.i = ALCompiler.ToInt32(((Decimal18)ALCompiler.ObjectToDecimal(base.Parent._CONTROLS.Target.Invoke(-820668825, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), this.id, new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(653)) }))));
                if (CStmtHit(6) & (this.i <= 0))
                {
                    StmtHit(7);
                    this.i = base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(653, NavType.Integer).ToInt32();
                }

                StmtHit(8);
                this.l.ALAdd(this.i);
                StmtHit(9);
                this.i = ALCompiler.ToInt32(((Decimal18)ALCompiler.ObjectToDecimal(base.Parent._CONTROLS.Target.Invoke(-820668825, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), this.id, new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(654)) }))));
                if (CStmtHit(10) & (this.i <= 0))
                {
                    StmtHit(11);
                    this.i = base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(654, NavType.Integer).ToInt32();
                }

                StmtHit(12);
                this.l.ALAdd(this.i);
                StmtHit(13);
                this.i = ALCompiler.ToInt32(((Decimal18)ALCompiler.ObjectToDecimal(base.Parent._CONTROLS.Target.Invoke(-820668825, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), this.id, new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(655)) }))));
                if (CStmtHit(14) & (this.i <= 0))
                {
                    StmtHit(15);
                    this.i = base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(655, NavType.Integer).ToInt32();
                }

                StmtHit(16);
                this.l.ALAdd(this.i);
                StmtHit(17);
                this.i = ALCompiler.ToInt32(((Decimal18)ALCompiler.ObjectToDecimal(base.Parent._CONTROLS.Target.Invoke(-820668825, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), this.id, new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(656)) }))));
                if (CStmtHit(18) & (this.i <= 0))
                {
                    StmtHit(19);
                    this.i = base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(656, NavType.Integer).ToInt32();
                }

                StmtHit(20);
                this.l.ALAdd(this.i);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3266893987")]
        public NavList<int> GetMenuModifiedButtons(NavText pMenuID)
        {
            using (GetMenuModifiedButtons_Scope_334793796 \u03b2scope = new GetMenuModifiedButtons_Scope_334793796(this, pMenuID))
            {
                \u03b2scope.Run();
                return \u03b2scope.l;
            }
        }

        [NavName("GetMenuModifiedButtons")]
        [SignatureSpan(380835703707729956L)]
        [SourceSpans(381398640776380465L, 381680120048123952L, 381961573550063624L)]
        private sealed class GetMenuModifiedButtons_Scope_334793796 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [ReturnValue("l")]
            [NavName("l")]
            public NavList<int> l = NavList<int>.Default;
            protected override uint RawScopeId { get => GetMenuModifiedButtons_Scope_334793796.\u03b1scopeId; set => GetMenuModifiedButtons_Scope_334793796.\u03b1scopeId = value; }

            internal GetMenuModifiedButtons_Scope_334793796(Codeunit10012739 \u03b2parent, NavText pMenuID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
                this.l = NavList<int>.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.menuModifications.ALContainsKey(this.pMenuID)))
                {
                    StmtHit(1);
                    this.l = base.Parent.menuModifications.ALGet(this.pMenuID);
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 162800967")]
        public bool GetMenu(NavText pMenuID)
        {
            using (GetMenu_Scope_2117440312 \u03b2scope = new GetMenu_Scope_2117440312(this, pMenuID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetMenu")]
        [SignatureSpan(142707873355071509L)]
        [SourceSpans(143833760377274393L, 144115239649017913L, 144678185307603001L, 144959677464248386L, 145241169620893770L, 145522648892637311L, 145804136754315296L, 146085616026058787L, 146648565979611238L, 148618822097567778L, 148900297074344009L, 149181772051120201L, 149744734889574440L, 150026227046219805L, 150307706317963322L, 150589164114870330L, 151433589045198894L, 151996521818882122L, 152277996795658335L, 152840946749210643L, 153122417431019528L)]
        private sealed class GetMenu_Scope_2117440312 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("found")]
            public bool found = default(bool);
            protected override uint RawScopeId { get => GetMenu_Scope_2117440312.\u03b1scopeId; set => GetMenu_Scope_2117440312.\u03b1scopeId = value; }

            internal GetMenu_Scope_2117440312(Codeunit10012739 \u03b2parent, NavText pMenuID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetMenu(%1)", this.pMenuID)));
                }

                if (CStmtHit(2) & (!base.Parent._MenuEntities.Target.ALGet(DataError.TrapError, base.Parent._MenuProfileID, this.pMenuID)))
                    if (CStmtHit(3) & (!base.Parent._MenuEntities.Target.ALGet(DataError.TrapError, base.Parent._StoreMenuProfileID, this.pMenuID)))
                        if (CStmtHit(4) & (!base.Parent._MenuEntities.Target.ALGet(DataError.TrapError, ALCompiler.ToNavValue(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))), this.pMenuID)))
                        {
                            StmtHit(5);
                            base.Parent.MenuRequest(base.Parent._MenuProfileID, base.Parent._StoreMenuProfileID, this.pMenuID, base.Parent._MenuEntities, base.Parent._MenuButtonEntities, true, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                            if (CStmtHit(6) & (!this.found))
                            {
                                StmtHit(7);
                                this.\u03b3retVal = false;
                                return;
                            }
                            else
                            {
                                StmtHit(8);
                                base.Parent.RefreshControlRuntimeProperties(NavOption.Create(NCLEnumMetadata.Create(99008881), 7), this.pMenuID, false);
                            }
                        }

                StmtHit(9);
                base.Parent._MenuButtonEntities.Target.ALReset();
                StmtHit(10);
                base.Parent._MenuButtonEntities.Target.ALSetRangeSafe(10, NavType.Code, ((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(10, NavType.Code)));
                StmtHit(11);
                base.Parent._MenuButtonEntities.Target.ALSetRangeSafe(1, NavType.Code, ((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(1, NavType.Code)));
                if (CStmtHit(12) & (base.Parent._MenuButtonEntities.Target.ALCount == 0))
                {
                    if (CStmtHit(13) & (base.Parent.__LogLevel > 3))
                    {
                        StmtHit(14);
                        base.Parent.LogTrace(new NavText("--- EMPTY MENU (add 1 button)"));
                    }

                    StmtHit(15);
                    base.Parent.RefreshMenuButton(((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(1, NavType.Code)), 1);
                }
                else
                {
                    StmtHit(16);
                    base.Parent.RefreshMenuButtons(base.Parent._MenuEntities);
                }

                StmtHit(17);
                base.Parent.ButtonPermissionRequest(base.Parent._MenuButtonEntities, new ByRef<NavList<NavRecordId>>(() => base.Parent._BlockedMenuButtons, setValue => base.Parent._BlockedMenuButtons = setValue));
                StmtHit(18);
                base.Parent.ButtonTranslationRequest(base.Parent._ActiveLanguage, base.Parent._MenuButtonEntities, new ByRef<NavList<NavRecordId>>(() => base.Parent._TranslatedMenuButtons, setValue => base.Parent._TranslatedMenuButtons = setValue));
                StmtHit(19);
                this.\u03b3retVal = true;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1788984278")]
        public NavJsonObject GetModifiedContext()
        {
            using (GetModifiedContext_Scope_758486046 \u03b2scope = new GetModifiedContext_Scope_758486046(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetModifiedContext")]
        [SignatureSpan(35747382180118560L)]
        [SourceSpans(36873269202321433L, 37154748474064939L, 37436206270971934L, 37717676952780808L)]
        private sealed class GetModifiedContext_Scope_758486046 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public NavJsonObject \u03b3retVal;
            [NavName("tmpText")]
            public NavText tmpText = NavText.Default(0);
            protected override uint RawScopeId { get => GetModifiedContext_Scope_758486046.\u03b1scopeId; set => GetModifiedContext_Scope_758486046.\u03b1scopeId = value; }

            internal GetModifiedContext_Scope_758486046(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
                this.\u03b3retVal = NavJsonObject.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("GetModifiedContext"));
                }

                StmtHit(2);
                this.\u03b3retVal = base.Parent.modifiedContext;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3368740816")]
        public NavText GetModifiedControlsJSON()
        {
            using (GetModifiedControlsJSON_Scope_480197483 \u03b2scope = new GetModifiedControlsJSON_Scope_480197483(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetModifiedControlsJSON")]
        [SignatureSpan(1126181442211086373L)]
        [SourceSpans(1130403553977827353L, 1130685033249570880L, 1131247966023254070L, 1131810915976806454L, 1132936815883911206L, 1133499778722365470L, 1133781257994108973L, 1134062732970885161L, 1134907153606246429L, 1135188632877989932L, 1135470107854766120L, 1136314515605225513L, 1136595990582001689L, 1136877465558777966L, 1138003378350784543L, 1138566362664075297L, 1138847841935818989L, 1139129312617627711L, 1139410804774273066L, 1139973759022792748L, 1140255233999568946L, 1141099654634930244L, 1141381133906673714L, 1142507016633909313L, 1143069979472363585L, 1143351458744107093L, 1144195879379468348L, 1144477371536113710L, 1145040325784633392L, 1145321800761409590L, 1146447662013808696L, 1146729141285552186L, 1147292091239104573L, 1148417986851242135L, 1148699466122985566L, 1148980941099761745L, 1149825361735123017L, 1150106841006866504L, 1150669773781008404L, 1151232758093840482L, 1151795708047392864L, 1152358658000945255L, 1153203057161469989L, 1153765977050251294L, 1154047456321994790L, 1154610401980579883L, 1154891881252323366L, 1155454826910908448L, 1155736306182651952L, 1156017781159493694L, 1156299273316073534L, 1156580731112980517L, 1156862206089756703L, 1157706626725117981L, 1157988105996861489L, 1158269580973965328L, 1158551073130283053L, 1158832548107124799L, 1159114040263704639L, 1159395498060611625L, 1159676955857518607L, 1159958430834294821L, 1160239905811071004L, 1161084326446432286L, 1161365805718175785L, 1161647280694952089L, 1162491701330313249L, 1162773180602056748L, 1163054655578832972L, 1163336130555609162L, 1164180538306068527L, 1164462013282844714L, 1165024976121298972L, 1165306455393042471L, 1165587930369818664L, 1166432338120736780L, 1166995305253699641L, 1167276793115377703L, 1167558272387121195L, 1167839747363897388L, 1168402662957711371L, 1168684137934487582L, 1169247087888039971L, 1169810037841592342L, 1170372987795144750L, 1170935937748697126L, 1171217408430505992L)]
        private sealed class GetModifiedControlsJSON_Scope_480197483 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            [NavName("JSONUtil")]
            public NavCodeunitHandle jSONUtil;
            [NavName("CurrControlType")]
            public NavOption currControlType = NavOption.Create(NCLEnumMetadata.Create(99008881), 0);
            [NavName("CurrControlID")]
            public NavText currControlID = NavText.Default(0);
            [NavName("i")]
            public int i = default(int);
            [NavName("token")]
            public NavJsonToken token;
            [NavName("token2")]
            public NavJsonToken token2;
            [NavName("jObj")]
            public NavJsonObject jObj;
            [NavName("lTimeStamp")]
            public NavDateTime lTimeStamp = NavDateTime.Default;
            [NavName("lsdatatext")]
            public NavText lsdatatext = NavText.Default(0);
            [NavName("n")]
            public NavText n = NavText.Default(0);
            [NavName("v")]
            public NavText v = NavText.Default(0);
            [NavName("lStringBuilder")]
            public NavTextBuilder lStringBuilder = NavTextBuilder.Default;
            [NavName("l_CONTROLS")]
            public INavRecordHandle l_CONTROLS;
            protected override uint RawScopeId { get => GetModifiedControlsJSON_Scope_480197483.\u03b1scopeId; set => GetModifiedControlsJSON_Scope_480197483.\u03b1scopeId = value; }

            internal GetModifiedControlsJSON_Scope_480197483(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
                this.jSONUtil = new NavCodeunitHandle(this, 1234);
                this.token = NavJsonToken.Default;
                this.token2 = NavJsonToken.Default;
                this.jObj = NavJsonObject.Default;
                this.lStringBuilder = NavTextBuilder.Default;
                this.l_CONTROLS = new NavRecordHandle(this, 99001760, false, SecurityFiltering.Validated);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText(ALSystemString.ALStrSubstNo("<< GetModifiedControlsJSON:")));
                }

                StmtHit(2);
                this.lTimeStamp = ALCompiler.ObjectToExactNavValue<NavDateTime>(base.Parent._CONTROLS.Target.Invoke(717507646, Array.Empty<object>()));
                StmtHit(3);
                this.currControlType = NavOption.Create(this.currControlType.NavOptionMetadata, 99);
                StmtHit(4);
                this.jSONUtil.Target.Invoke(-473954417, new object[] { new NavText("") });
                if (CStmtHit(5) & (base.Parent.contextMenusPending))
                {
                    StmtHit(6);
                    base.Parent.ContextMenuRequest(new NavText(""), this.jSONUtil);
                    StmtHit(7);
                    base.Parent.contextMenusPending = false;
                }

                if (CStmtHit(8) & (base.Parent.keyCommandsPending))
                {
                    StmtHit(9);
                    base.Parent.KeyCommandRequest(new NavText(""), this.jSONUtil);
                    StmtHit(10);
                    base.Parent.keyCommandsPending = false;
                }

                StmtHit(11);
                this.l_CONTROLS.Target.ALCopy(base.Parent._CONTROLS.Target, true);
                StmtHit(12);
                this.l_CONTROLS.Target.ALReset();
                StmtHit(13);
                this.l_CONTROLS.Target.ALSetRangeSafe(50, NavType.DateTime, this.lTimeStamp, ALSystemDate.ALCreateDateTime(ALSystemDate.ALDMY2Date(31, 12, 9999), NavTime.Create(86399001U)));
                if (CStmtHit(14) & (this.l_CONTROLS.Target.ALFind(DataError.TrapError, "-")))
                    do
                    {
                        if (CStmtHit(15) & (base.Parent.__LogLevel > 3))
                        {
                            StmtHit(16);
                            base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("<< [%1] %2.%3 (%4) = %5", ((NavOption)this.l_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)), ((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code)), ((NavText)this.l_CONTROLS.Target.GetFieldValueSafe(5, NavType.Text)), ALCompiler.ToNavValue(NavFormatEvaluateHelper.Format(((NavDateTime)this.l_CONTROLS.Target.GetFieldValueSafe(50, NavType.DateTime)), 0, "<Minutes,2><Seconds,2><Second dec>")), ALCompiler.ObjectToExactNavValue<NavText>(this.l_CONTROLS.Target.Invoke(-1430120492, Array.Empty<object>())))));
                        }

                        if (CStmtHit(17) & (this.currControlType != ((NavOption)this.l_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option))))
                        {
                            if (CStmtHit(18) & (this.currControlID != ""))
                            {
                                StmtHit(19);
                                this.currControlID = new NavText("");
                                StmtHit(20);
                                this.jSONUtil.Target.Invoke(2090071347, Array.Empty<object>());
                            }

                            if (CStmtHit(21) & (this.currControlType != NavOption.Create(this.currControlType.NavOptionMetadata, 99)))
                            {
                                StmtHit(22);
                                this.jSONUtil.Target.Invoke(2090071347, Array.Empty<object>());
                            }

                            StmtHit(23);
                            this.currControlType = ((NavOption)this.l_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option));
                            if (CStmtHit(24) & (((NavOption)this.l_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).ToInt32() < 20))
                            {
                                StmtHit(25);
                                this.jSONUtil.Target.Invoke(-473954417, new object[] { new NavText(NavFormatEvaluateHelper.Format(((NavOption)this.l_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)))) });
                            }
                        }
                        else if (CStmtHit(26) & (this.currControlID != ((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))))
                        {
                            if (CStmtHit(27) & (this.currControlID != ""))
                            {
                                StmtHit(28);
                                this.currControlID = new NavText("");
                                StmtHit(29);
                                this.jSONUtil.Target.Invoke(2090071347, Array.Empty<object>());
                            }
                        }

                        if (CStmtHit(30) & (this.currControlID != ((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))))
                        {
                            StmtHit(31);
                            this.currControlID = new NavText(((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code)));
                            StmtHit(32);
                            this.jSONUtil.Target.Invoke(-473954417, new object[] { this.currControlID });
                        }

                        if (CStmtHit(33) & ((!base.Parent.ControlLoaded(((NavOption)this.l_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)), new NavText(((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))))) | (((NavText)this.l_CONTROLS.Target.GetFieldValueSafe(5, NavType.Text)) == this.l_CONTROLS.Target.ALFieldName(2))))
                        {
                            StmtHit(34);
                            base.Parent.GetControlJSON(((NavOption)this.l_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)), new NavText(((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))), this.jSONUtil);
                            StmtHit(35);
                            base.Parent.LoadControl(((NavOption)this.l_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)), new NavText(((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))));
                        }

                        if (CStmtHit(36) & ((this.currControlID == "") & (this.l_CONTROLS.Target.GetFieldValueSafe(8, NavType.Integer).ToInt32() > 0)))
                        {
                            StmtHit(37);
                            NavDialog.ALMessage(Guid.Parse("8da61efd-0002-0003-0507-0b0d1113171d"), "EMTPY CONTROLID!!: " + NavFormatEvaluateHelper.Format(this.l_CONTROLS.Target));
                        }

                        StmtHit(38);
                        int @tmp1 = this.l_CONTROLS.Target.GetFieldValueSafe(8, NavType.Integer).ToInt32();
                        if ((@tmp1 == ((int)ALCompiler.ObjectToInt32(this.l_CONTROLS.Target.Invoke(1439660248, Array.Empty<object>())))))
                        {
                            {
                                StmtHit(39);
                                this.jSONUtil.Target.Invoke(1213051198, new object[] { new NavText(((NavText)this.l_CONTROLS.Target.GetFieldValueSafe(5, NavType.Text))), ALCompiler.ToVariant(this, this.l_CONTROLS.Target.GetFieldValueSafe(12, NavType.Decimal).ToDecimal()) });
                            }

                            goto @tmp0;
                        }

                        if ((@tmp1 == ((int)ALCompiler.ObjectToInt32(this.l_CONTROLS.Target.Invoke(1015610847, Array.Empty<object>())))))
                        {
                            {
                                StmtHit(40);
                                this.jSONUtil.Target.Invoke(312227950, new object[] { new NavText(((NavText)this.l_CONTROLS.Target.GetFieldValueSafe(5, NavType.Text))), ALCompiler.ToVariant(this, this.l_CONTROLS.Target.GetFieldValueSafe(11, NavType.Boolean).ToBoolean()) });
                            }

                            goto @tmp0;
                        }

                        {
                            {
                                StmtHit(41);
                                this.jSONUtil.Target.Invoke(-1675069947, new object[] { new NavText(((NavText)this.l_CONTROLS.Target.GetFieldValueSafe(5, NavType.Text))), ALCompiler.NavValueToVariant(this, ALCompiler.ObjectToExactNavValue<NavText>(this.l_CONTROLS.Target.Invoke(-1430120492, Array.Empty<object>()))) });
                            }
                        }

                        @tmp0:
                            ;
                    }
                    while (!(CStmtHit(42) & (this.l_CONTROLS.Target.ALNext() == 0)));
                if (CStmtHit(43) & (this.currControlID != ""))
                {
                    StmtHit(44);
                    this.jSONUtil.Target.Invoke(2090071347, Array.Empty<object>());
                }

                if (CStmtHit(45) & (this.currControlType.ToInt32() < 20))
                {
                    StmtHit(46);
                    this.jSONUtil.Target.Invoke(2090071347, Array.Empty<object>());
                }

                if (CStmtHit(47) & (base.Parent.javascripts.ALCount > 0))
                {
                    StmtHit(48);
                    this.jSONUtil.Target.Invoke(83439927, new object[] { new NavText("Scripts") });
                    StmtHit(49);
                    foreach (var @tmp2 in base.Parent.javascripts)
                    {
                        this.token = @tmp2;
                        {
                            CStmtHit(50);
                            this.jSONUtil.Target.Invoke(-653028912, new object[] { ALCompiler.NavValueToVariant(this, this.token.ALAsValue().ALAsText()) });
                        }
                    }

                    StmtHit(51);
                    this.jSONUtil.Target.Invoke(1034695779, Array.Empty<object>());
                    StmtHit(52);
                    base.Parent.javascripts = NavJsonArray.Default;
                }

                if (CStmtHit(53) & (base.Parent.commands.ALCount > 0))
                {
                    StmtHit(54);
                    this.jSONUtil.Target.Invoke(83439927, new object[] { new NavText("Commands") });
                    StmtHit(55);
                    foreach (var @tmp3 in base.Parent.commands)
                    {
                        this.token = @tmp3;
                        {
                            CStmtHit(56);
                            this.jSONUtil.Target.Invoke(83439927, new object[] { new NavText("") });
                            StmtHit(57);
                            foreach (var @tmp4 in this.token.ALAsArray())
                            {
                                this.token2 = @tmp4;
                                {
                                    CStmtHit(58);
                                    this.jSONUtil.Target.Invoke(-653028912, new object[] { ALCompiler.NavValueToVariant(this, this.token2.ALAsValue().ALAsText()) });
                                }
                            }

                            StmtHit(59);
                            this.jSONUtil.Target.Invoke(1034695779, Array.Empty<object>());
                        }
                    }

                    StmtHit(60);
                    StmtHit(61);
                    this.jSONUtil.Target.Invoke(1034695779, Array.Empty<object>());
                    StmtHit(62);
                    base.Parent.commands = NavJsonArray.Default;
                }

                if (CStmtHit(63) & (base.Parent.styleProfilePending))
                {
                    StmtHit(64);
                    base.Parent.styleProfilePending = false;
                    StmtHit(65);
                    base.Parent.StyleProfileRequest(base.Parent._StyleProfileID, base.Parent._StoreStyleProfileID, base.Parent._FontIdsFilter, base.Parent._SkinIdsFilter, base.Parent._ColorIdsFilter, base.Parent._SkipDefaultResources, this.jSONUtil);
                }

                if (CStmtHit(66) & (base.Parent.showDualDisplayPending))
                {
                    StmtHit(67);
                    base.Parent.showDualDisplayPending = false;
                    StmtHit(68);
                    this.jSONUtil.Target.Invoke(312227950, new object[] { new NavText("IsDualDisplay"), ALCompiler.ToVariant(this, base.Parent.IsDualDisplay()) });
                    StmtHit(69);
                    this.jSONUtil.Target.Invoke(1213051198, new object[] { new NavText("DisplayNumber"), ALCompiler.ToVariant(this, base.Parent.GetDisplayNo()) });
                }

                StmtHit(70);
                this.lsdatatext = ALCompiler.ObjectToExactNavValue<NavText>(this.jSONUtil.Target.Invoke(1959899813, Array.Empty<object>()));
                StmtHit(71);
                this.lStringBuilder.ALAppend(DataError.ThrowError, this.lsdatatext);
                if (CStmtHit(72) & (this.lsdatatext != "{"))
                {
                    StmtHit(73);
                    this.lStringBuilder.ALAppend(DataError.ThrowError, new NavText(","));
                    StmtHit(74);
                    this.lStringBuilder.ALAppendLine(DataError.ThrowError);
                }

                this.i = 1;
                StmtHit(75);
                int @tmp5 = base.Parent.pendingPOSData.ALCount;
                for (; this.i <= @tmp5;)
                {
                    {
                        CStmtHit(76);
                        this.lStringBuilder.ALAppend(DataError.ThrowError, base.Parent.pendingPOSData.ALGet(this.i));
                        if (CStmtHit(77) & (this.i < base.Parent.pendingPOSData.ALCount))
                        {
                            CStmtHit(78);
                            this.lStringBuilder.ALAppend(DataError.ThrowError, new NavText(","));
                            CStmtHit(79);
                            this.lStringBuilder.ALAppendLine(DataError.ThrowError);
                        }
                    }

                    if (this.i >= @tmp5)
                        break;
                    this.i = this.i + 1;
                }

                StmtHit(80);
                StmtHit(81);
                base.Parent.pendingPOSData = NavList<NavText>.Default;
                StmtHit(82);
                this.lStringBuilder.ALAppend(DataError.ThrowError, new NavText("}"));
                StmtHit(83);
                base.Parent.LogEntities();
                StmtHit(84);
                base.Parent._CONTROLS.Target.Invoke(948785162, Array.Empty<object>());
                StmtHit(85);
                this.\u03b3retVal = this.lStringBuilder.ALToText();
                return;
            }
        }

        private int GetNrOfButtons([NavObjectId(ObjectId = 99009053)][NavByReferenceAttribute] INavRecordHandle pMenuEntity)
        {
            using (GetNrOfButtons_Scope_1653395011 \u03b2scope = new GetNrOfButtons_Scope_1653395011(this, pMenuEntity))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetNrOfButtons")]
        [SignatureSpan(999236253454827554L)]
        [SourceSpans(999799164753674271L, 1000080644025417762L, 1000362114707226658L, 1000643593978970149L, 1000925064660779040L, 1001206543932522531L, 1001488001729429577L, 1001769472411238408L)]
        private sealed class GetNrOfButtons_Scope_1653395011 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuEntity")]
            public INavRecordHandle pMenuEntity;
            [ReturnValue]
            public int \u03b3retVal = default(int);
            protected override uint RawScopeId { get => GetNrOfButtons_Scope_1653395011.\u03b1scopeId; set => GetNrOfButtons_Scope_1653395011.\u03b1scopeId = value; }

            internal GetNrOfButtons_Scope_1653395011(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99009053)][NavByReferenceAttribute] INavRecordHandle pMenuEntity) : base(\u03b2parent)
            {
                this.pMenuEntity = pMenuEntity;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.pMenuEntity.Target.GetFieldValueSafe(31, NavType.Integer).ToInt32() < 1))
                {
                    StmtHit(1);
                    this.pMenuEntity.Target.SetFieldValueSafe(31, NavType.Integer, ALCompiler.ToNavValue(1));
                }

                if (CStmtHit(2) & (this.pMenuEntity.Target.GetFieldValueSafe(30, NavType.Integer).ToInt32() < 1))
                {
                    StmtHit(3);
                    this.pMenuEntity.Target.SetFieldValueSafe(30, NavType.Integer, ALCompiler.ToNavValue(1));
                }

                if (CStmtHit(4) & (this.pMenuEntity.Target.GetFieldValueSafe(550, NavType.Integer).ToInt32() < 1))
                {
                    StmtHit(5);
                    this.pMenuEntity.Target.SetFieldValueSafe(550, NavType.Integer, ALCompiler.ToNavValue(1));
                }

                StmtHit(6);
                this.\u03b3retVal = this.pMenuEntity.Target.GetFieldValueSafe(31, NavType.Integer).ToInt32() * this.pMenuEntity.Target.GetFieldValueSafe(30, NavType.Integer).ToInt32() * this.pMenuEntity.Target.GetFieldValueSafe(550, NavType.Integer).ToInt32();
                return;
            }
        }

        private NavText GetPanelControlPositionText([NavObjectId(ObjectId = 99008874)][NavByReferenceAttribute] INavRecordHandle pPanelControlLine)
        {
            using (GetPanelControlPositionText_Scope_441960860 \u03b2scope = new GetPanelControlPositionText_Scope_441960860(this, pPanelControlLine))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetPanelControlPositionText")]
        [SignatureSpan(260645914394099759L)]
        [SourceSpans(261208812808044726L, 261490283489853448L)]
        private sealed class GetPanelControlPositionText_Scope_441960860 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelControlLine")]
            public INavRecordHandle pPanelControlLine;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetPanelControlPositionText_Scope_441960860.\u03b1scopeId; set => GetPanelControlPositionText_Scope_441960860.\u03b1scopeId = value; }

            internal GetPanelControlPositionText_Scope_441960860(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99008874)][NavByReferenceAttribute] INavRecordHandle pPanelControlLine) : base(\u03b2parent)
            {
                this.pPanelControlLine = pPanelControlLine;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.GetPanelControlPositionText_550393579(new NavText(((NavCode)this.pPanelControlLine.Target.GetFieldValueSafe(2, NavType.Code))), this.pPanelControlLine.Target.GetFieldValueSafe(5, NavType.Integer).ToInt32(), this.pPanelControlLine.Target.GetFieldValueSafe(4, NavType.Integer).ToInt32(), this.pPanelControlLine.Target.GetFieldValueSafe(7, NavType.Integer).ToInt32(), this.pPanelControlLine.Target.GetFieldValueSafe(6, NavType.Integer).ToInt32());
                return;
            }
        }

        private NavText GetPanelControlPositionText_550393579(NavText pPanelID, int pRow, int pCol, int pRowSpan, int pColSpan)
        {
            using (GetPanelControlPositionText_Scope_550393579 \u03b2scope = new GetPanelControlPositionText_Scope_550393579(this, pPanelID, pRow, pCol, pRowSpan, pColSpan))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetPanelControlPositionText")]
        [SignatureSpan(262053289277980719L)]
        [SourceSpans(262616200576827411L, 262897679848570902L, 263179150530379795L, 263460629802123286L, 263742087599030357L, 264023558280839176L)]
        private sealed class GetPanelControlPositionText_Scope_550393579 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("pRow")]
            public int pRow;
            [NavName("pCol")]
            public int pCol;
            [NavName("pRowSpan")]
            public int pRowSpan;
            [NavName("pColSpan")]
            public int pColSpan;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetPanelControlPositionText_Scope_550393579.\u03b1scopeId; set => GetPanelControlPositionText_Scope_550393579.\u03b1scopeId = value; }

            internal GetPanelControlPositionText_Scope_550393579(Codeunit10012739 \u03b2parent, NavText pPanelID, int pRow, int pCol, int pRowSpan, int pColSpan) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.pRow = pRow;
                this.pCol = pCol;
                this.pRowSpan = pRowSpan;
                this.pColSpan = pColSpan;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.pRow < 1))
                {
                    StmtHit(1);
                    this.pRow = 1;
                }

                if (CStmtHit(2) & (this.pCol < 1))
                {
                    StmtHit(3);
                    this.pCol = 1;
                }

                StmtHit(4);
                this.\u03b3retVal = new NavText(ALSystemString.ALStrSubstNo("%1=%2 %3 %4 %5", this.pPanelID, ALCompiler.ToNavValue(this.pRow), ALCompiler.ToNavValue(this.pCol), ALCompiler.ToNavValue(this.pRowSpan), ALCompiler.ToNavValue(this.pColSpan)));
                return;
            }
        }

        private NavText GetPanelKeyCommandsButtonPadID(NavText pPanelControlID)
        {
            using (GetPanelKeyCommandsButtonPadID_Scope__1759476131 \u03b2scope = new GetPanelKeyCommandsButtonPadID_Scope__1759476131(this, pPanelControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetPanelKeyCommandsButtonPadID")]
        [SignatureSpan(251920190114037810L)]
        [SourceSpans(252483088527982628L, 252764563504758856L, 253046038481535048L, 253327526343213096L, 253609005614956565L, 254171938388639785L, 254453413365415982L, 254734884047224840L)]
        private sealed class GetPanelKeyCommandsButtonPadID_Scope__1759476131 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelControlID")]
            public NavText pPanelControlID;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetPanelKeyCommandsButtonPadID_Scope__1759476131.\u03b1scopeId; set => GetPanelKeyCommandsButtonPadID_Scope__1759476131.\u03b1scopeId = value; }

            internal GetPanelKeyCommandsButtonPadID_Scope__1759476131(Codeunit10012739 \u03b2parent, NavText pPanelControlID) : base(\u03b2parent)
            {
                this.pPanelControlID = pPanelControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent._PanelControlEntities.Target.ALReset();
                StmtHit(1);
                base.Parent._PanelControlEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pPanelControlID);
                StmtHit(2);
                base.Parent._PanelControlEntities.Target.ALSetRangeSafe(10, NavType.Boolean, ALCompiler.ToNavValue(true));
                if (CStmtHit(3) & (base.Parent._PanelControlEntities.Target.ALIsEmpty))
                {
                    StmtHit(4);
                    this.\u03b3retVal = new NavText("");
                    return;
                }

                StmtHit(5);
                base.Parent._PanelControlEntities.Target.ALFindLast(DataError.ThrowError);
                StmtHit(6);
                this.\u03b3retVal = new NavText(((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code)));
                return;
            }
        }

        private void GetPanelRowColumnJSON(NavText pPanelControlID, [NavObjectId(ObjectId = 1234)] NavCodeunitHandle jsonUtil)
        {
            using (GetPanelRowColumnJSON_Scope__1798669760 \u03b2scope = new GetPanelRowColumnJSON_Scope__1798669760(this, pPanelControlID, jsonUtil))
                \u03b2scope.Run();
        }

        [NavName("GetPanelRowColumnJSON")]
        [SignatureSpan(246009215601737769L)]
        [SourceSpans(247135063969234995L, 247698013922787402L, 247979501784465452L, 248542473212854318L, 248823948189630546L, 249105423166406739L, 249386898143182905L, 249668373119959100L, 249949848096735284L, 250231323073511480L, 250512798050287658L, 250794281616998450L, 251075713644101665L, 251357184325910536L)]
        private sealed class GetPanelRowColumnJSON_Scope__1798669760 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelControlID")]
            public NavText pPanelControlID;
            [NavName("JsonUtil")]
            public NavCodeunitHandle jsonUtil;
            [NavName("i")]
            public int i = default(int);
            protected override uint RawScopeId { get => GetPanelRowColumnJSON_Scope__1798669760.\u03b1scopeId; set => GetPanelRowColumnJSON_Scope__1798669760.\u03b1scopeId = value; }

            internal GetPanelRowColumnJSON_Scope__1798669760(Codeunit10012739 \u03b2parent, NavText pPanelControlID, [NavObjectId(ObjectId = 1234)] NavCodeunitHandle jsonUtil) : base(\u03b2parent)
            {
                this.pPanelControlID = pPanelControlID.ModifyLength(0);
                this.jsonUtil = jsonUtil.ALByValue(this);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.jsonUtil.Target.Invoke(83439927, new object[] { new NavText("RowColumnSetup") });
                StmtHit(1);
                base.Parent._PanelRowColumnEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pPanelControlID);
                if (CStmtHit(2) & (base.Parent._PanelRowColumnEntities.Target.ALFind(DataError.TrapError, "-")))
                    do
                    {
                        StmtHit(3);
                        this.jsonUtil.Target.Invoke(-473954417, new object[] { new NavText("") });
                        StmtHit(4);
                        this.jsonUtil.Target.Invoke(1213051198, new object[] { new NavText("No"), ALCompiler.ToVariant(this, base.Parent._PanelRowColumnEntities.Target.GetFieldValueSafe(4, NavType.Integer).ToInt32()) });
                        StmtHit(5);
                        this.jsonUtil.Target.Invoke(1213051198, new object[] { new NavText("Size"), ALCompiler.ToVariant(this, base.Parent._PanelRowColumnEntities.Target.GetFieldValueSafe(6, NavType.Integer).ToInt32()) });
                        StmtHit(6);
                        this.i = ((NavOption)base.Parent._PanelRowColumnEntities.Target.GetFieldValueSafe(5, NavType.Option));
                        StmtHit(7);
                        this.jsonUtil.Target.Invoke(1213051198, new object[] { new NavText("SizeType"), ALCompiler.ToVariant(this, this.i) });
                        StmtHit(8);
                        this.i = ((NavOption)base.Parent._PanelRowColumnEntities.Target.GetFieldValueSafe(3, NavType.Option));
                        StmtHit(9);
                        this.jsonUtil.Target.Invoke(1213051198, new object[] { new NavText("Type"), ALCompiler.ToVariant(this, this.i) });
                        StmtHit(10);
                        this.jsonUtil.Target.Invoke(2090071347, Array.Empty<object>());
                    }
                    while (!(CStmtHit(11) & (base.Parent._PanelRowColumnEntities.Target.ALNext() == 0)));
                StmtHit(12);
                this.jsonUtil.Target.Invoke(1034695779, Array.Empty<object>());
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1956154582")]
        public bool GetPanel(NavText pControlID)
        {
            using (GetPanel_Scope__1801133691 \u03b2scope = new GetPanel_Scope__1801133691(this, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetPanel")]
        [SignatureSpan(156500147217104918L)]
        [SourceSpans(157626034239307801L, 157907513511051325L, 158470459169636397L, 158751938441379995L, 159033426303057944L, 159314905574801435L, 159877855528353838L, 160440818366808132L, 160722297638551613L, 161848146006048806L, 162129620982825043L, 162411095959601188L, 162692570936377425L, 165225845727363091L, 165507316409171976L)]
        private sealed class GetPanel_Scope__1801133691 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("found")]
            public bool found = default(bool);
            protected override uint RawScopeId { get => GetPanel_Scope__1801133691.\u03b1scopeId; set => GetPanel_Scope__1801133691.\u03b1scopeId = value; }

            internal GetPanel_Scope__1801133691(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetPanel(%1)", this.pControlID)));
                }

                if (CStmtHit(2) & (!base.Parent._PanelEntities.Target.ALGet(DataError.TrapError, this.pControlID)))
                {
                    StmtHit(3);
                    base.Parent.PanelRequest(base.Parent._InterfaceProfileID, base.Parent._StoreInterfaceProfileID, this.pControlID, base.Parent._PanelEntities, base.Parent._PanelRowColumnEntities, base.Parent._PanelControlEntities, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                    if (CStmtHit(4) & (!this.found))
                    {
                        StmtHit(5);
                        this.\u03b3retVal = false;
                        return;
                    }
                    else
                    {
                        StmtHit(6);
                        base.Parent._PanelEntities.Target.ALSetRecFilter();
                        if (CStmtHit(7) & (!base.Parent.panelNeedsControlRefresh.ALContains(this.pControlID)))
                        {
                            StmtHit(8);
                            base.Parent.panelNeedsControlRefresh.ALAdd(this.pControlID);
                        }
                    }
                }

                StmtHit(9);
                base.Parent._PanelRowColumnEntities.Target.ALReset();
                StmtHit(10);
                base.Parent._PanelRowColumnEntities.Target.ALSetRangeSafe(2, NavType.Code, ((NavCode)base.Parent._PanelEntities.Target.GetFieldValueSafe(2, NavType.Code)));
                StmtHit(11);
                base.Parent._PanelControlEntities.Target.ALReset();
                StmtHit(12);
                base.Parent._PanelControlEntities.Target.ALSetRangeSafe(2, NavType.Code, ((NavCode)base.Parent._PanelEntities.Target.GetFieldValueSafe(2, NavType.Code)));
                StmtHit(13);
                this.\u03b3retVal = true;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2837693656")]
        public NavJsonObject GetPendingDataSets()
        {
            using (GetPendingDataSets_Scope__563196171 \u03b2scope = new GetPendingDataSets_Scope__563196171(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetPendingDataSets")]
        [SignatureSpan(1089308220253405216L)]
        [SourceSpans(1089871144437153822L, 1090152615118962696L)]
        private sealed class GetPendingDataSets_Scope__563196171 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public NavJsonObject \u03b3retVal;
            protected override uint RawScopeId { get => GetPendingDataSets_Scope__563196171.\u03b1scopeId; set => GetPendingDataSets_Scope__563196171.\u03b1scopeId = value; }

            internal GetPendingDataSets_Scope__563196171(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
                this.\u03b3retVal = NavJsonObject.Default;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.pendingDataSets;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1195291449")]
        public NavJsonObject GetPendingImages()
        {
            using (GetPendingImages_Scope_1342903854 \u03b2scope = new GetPendingImages_Scope_1342903854(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetPendingImages")]
        [SignatureSpan(1100004269370900510L)]
        [SourceSpans(1100567193554649116L, 1100848664236457992L)]
        private sealed class GetPendingImages_Scope_1342903854 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public NavJsonObject \u03b3retVal;
            protected override uint RawScopeId { get => GetPendingImages_Scope_1342903854.\u03b1scopeId; set => GetPendingImages_Scope_1342903854.\u03b1scopeId = value; }

            internal GetPendingImages_Scope_1342903854(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
                this.\u03b3retVal = NavJsonObject.Default;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.pendingImages;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4276514589")]
        public NavJsonObject GetPendingPlaylists()
        {
            using (GetPendingPlaylists_Scope_1087796489 \u03b2scope = new GetPendingPlaylists_Scope_1087796489(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetPendingPlaylists")]
        [SignatureSpan(1109855893558067233L)]
        [SourceSpans(1110418817741815839L, 1110700288423624712L)]
        private sealed class GetPendingPlaylists_Scope_1087796489 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public NavJsonObject \u03b3retVal;
            protected override uint RawScopeId { get => GetPendingPlaylists_Scope_1087796489.\u03b1scopeId; set => GetPendingPlaylists_Scope_1087796489.\u03b1scopeId = value; }

            internal GetPendingPlaylists_Scope_1087796489(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
                this.\u03b3retVal = NavJsonObject.Default;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.pendingPlaylists;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3783973284")]
        public NavList<NavText> GetPendingRequests()
        {
            using (GetPendingRequests_Scope__23237112 \u03b2scope = new GetPendingRequests_Scope__23237112(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetPendingRequests")]
        [SignatureSpan(1092122970021167136L)]
        [SourceSpans(1092685894204915746L, 1092967364886724616L)]
        private sealed class GetPendingRequests_Scope__23237112 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public NavList<NavText> \u03b3retVal = NavList<NavText>.Default;
            protected override uint RawScopeId { get => GetPendingRequests_Scope__23237112.\u03b1scopeId; set => GetPendingRequests_Scope__23237112.\u03b1scopeId = value; }

            internal GetPendingRequests_Scope__23237112(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
                this.\u03b3retVal = NavList<NavText>.Default;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.pendingJsonRequests;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2371909292")]
        public NavText GetPosImage(NavOption pControlType, NavText pControlID)
        {
            using (GetPosImage_Scope_1833924619 \u03b2scope = new GetPosImage_Scope_1833924619(this, pControlType, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.pImgID;
            }
        }

        [NavName("GetPosImage")]
        [SignatureSpan(849491578694795298L)]
        [SourceSpans(850054464223838315L, 850335934905647112L)]
        private sealed class GetPosImage_Scope_1833924619 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [ReturnValue("pImgID")]
            [NavName("pImgID")]
            public NavText pImgID = NavText.Default(0);
            protected override uint RawScopeId { get => GetPosImage_Scope_1833924619.\u03b1scopeId; set => GetPosImage_Scope_1833924619.\u03b1scopeId = value; }

            internal GetPosImage_Scope_1833924619(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.pImgID = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent._CONTROLS.Target.Invoke(-1790301861, new object[] { this.pControlType, this.pControlID, new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(1222)) }));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3075058293")]
        public NavText GetRecordZoomDataXML(NavText pControlID)
        {
            using (GetRecordZoomDataXML_Scope__2042407339 \u03b2scope = new GetRecordZoomDataXML_Scope__2042407339(this, pControlID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetRecordZoomDataXML")]
        [SignatureSpan(941252382469128226L)]
        [SourceSpans(941815319537778713L, 942096798809522249L, 942659744468107318L, 942941223739850773L, 943504169398435865L, 943785648670179386L, 944348581443862574L, 944630052125671432L)]
        private sealed class GetRecordZoomDataXML_Scope__2042407339 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetRecordZoomDataXML_Scope__2042407339.\u03b1scopeId; set => GetRecordZoomDataXML_Scope__2042407339.\u03b1scopeId = value; }

            internal GetRecordZoomDataXML_Scope__2042407339(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetRecordZoomDataXML(%1)", this.pControlID)));
                }

                if (CStmtHit(2) & (!base.Parent.zoomDatasetJSON.ALContainsKey(this.pControlID)))
                {
                    StmtHit(3);
                    this.\u03b3retVal = new NavText("");
                    return;
                }

                if (CStmtHit(4) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(5);
                    base.Parent.LogDeepTrace_1953297028(base.Parent.zoomDatasetJSON.ALGet(this.pControlID));
                }

                StmtHit(6);
                this.\u03b3retVal = base.Parent.zoomDatasetJSON.ALGet(this.pControlID);
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1290884989")]
        public bool GetRecordZoom(NavText pControlID, [NavObjectId(ObjectId = 99008878)][NavByReferenceAttribute] INavRecordHandle pControlRec)
        {
            using (GetRecordZoom_Scope_384141761 \u03b2scope = new GetRecordZoom_Scope_384141761(this, pControlID, pControlRec))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetRecordZoom")]
        [SignatureSpan(190558619407024155L)]
        [SourceSpans(191684506429227033L, 191965985700970562L, 192247456382779463L, 192528948539424848L, 192810440696070227L, 193091919967813757L, 193373407829491744L, 193654887101235235L, 194217837054787695L, 194780718288863275L, 195062193265639443L, 195343663947448328L)]
        private sealed class GetRecordZoom_Scope_384141761 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pControlRec")]
            public INavRecordHandle pControlRec;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("found")]
            public bool found = default(bool);
            protected override uint RawScopeId { get => GetRecordZoom_Scope_384141761.\u03b1scopeId; set => GetRecordZoom_Scope_384141761.\u03b1scopeId = value; }

            internal GetRecordZoom_Scope_384141761(Codeunit10012739 \u03b2parent, NavText pControlID, [NavObjectId(ObjectId = 99008878)][NavByReferenceAttribute] INavRecordHandle pControlRec) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pControlRec = pControlRec;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetRecordZoom(%1)", this.pControlID)));
                }

                if (CStmtHit(2) & (!base.Parent._RecordZoomEntities.Target.ALGet(DataError.TrapError, base.Parent._InterfaceProfileID, this.pControlID)))
                    if (CStmtHit(3) & (!base.Parent._RecordZoomEntities.Target.ALGet(DataError.TrapError, base.Parent._StoreInterfaceProfileID, this.pControlID)))
                        if (CStmtHit(4) & (!base.Parent._RecordZoomEntities.Target.ALGet(DataError.TrapError, ALCompiler.ToNavValue(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 1)))), this.pControlID)))
                        {
                            StmtHit(5);
                            base.Parent.RecordZoomRequest(base.Parent._InterfaceProfileID, base.Parent._StoreInterfaceProfileID, this.pControlID, base.Parent._RecordZoomEntities, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                            if (CStmtHit(6) & (!this.found))
                            {
                                StmtHit(7);
                                this.\u03b3retVal = false;
                                return;
                            }
                            else
                            {
                                StmtHit(8);
                                base.Parent.RefreshControlRuntimeProperties(NavOption.Create(NCLEnumMetadata.Create(99008881), 4), this.pControlID, false);
                            }
                        }

                StmtHit(9);
                this.pControlRec.ALAssign(base.Parent._RecordZoomEntities);
                StmtHit(10);
                this.\u03b3retVal = true;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 124036282")]
        public int GetSelectedButton(NavCode pMenuID)
        {
            using (GetSelectedButton_Scope_559295265 \u03b2scope = new GetSelectedButton_Scope_559295265(this, pMenuID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetSelectedButton")]
        [SignatureSpan(1068197596995190815L)]
        [SourceSpans(1068760534063841305L, 1069042013335584835L, 1069604958994169906L, 1069886438265913394L, 1070167896062820369L, 1070449366744629256L)]
        private sealed class GetSelectedButton_Scope_559295265 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [ReturnValue]
            public int \u03b3retVal = default(int);
            protected override uint RawScopeId { get => GetSelectedButton_Scope_559295265.\u03b1scopeId; set => GetSelectedButton_Scope_559295265.\u03b1scopeId = value; }

            internal GetSelectedButton_Scope_559295265(Codeunit10012739 \u03b2parent, NavCode pMenuID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetSelectedButton(%1)", this.pMenuID)));
                }

                if (CStmtHit(2) & (base.Parent.menuSelectedButton.ALContainsKey(new NavText(this.pMenuID))))
                {
                    StmtHit(3);
                    this.\u03b3retVal = base.Parent.menuSelectedButton.ALGet(new NavText(this.pMenuID));
                    return;
                }

                StmtHit(4);
                this.\u03b3retVal = -1;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 972567641")]
        public NavDateTime GetSelectedDate()
        {
            using (GetSelectedDate_Scope_1317268069 \u03b2scope = new GetSelectedDate_Scope_1317268069(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.dt;
            }
        }

        [NavName("GetSelectedDate")]
        [SignatureSpan(1210060985290391581L)]
        [SourceSpans(1210623922359042137L, 1210905401630785558L, 1211186855132725256L)]
        private sealed class GetSelectedDate_Scope_1317268069 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue("dt")]
            [NavName("dt")]
            public NavDateTime dt = NavDateTime.Default;
            protected override uint RawScopeId { get => GetSelectedDate_Scope_1317268069.\u03b1scopeId; set => GetSelectedDate_Scope_1317268069.\u03b1scopeId = value; }

            internal GetSelectedDate_Scope_1317268069(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!ALSystemVariable.ALEvaluate(DataError.TrapError, new ByRef<NavDateTime>(() => this.dt, setValue => this.dt = setValue), base.Parent.GetMainControlTextValue(new NavText(base.Parent._POS.Target.ALFieldName(20))), 9)))
                {
                    StmtHit(1);
                    this.dt = NavDateTime.Create(0U);
                    return;
                }
            }
        }

        private void GetSharedControlProperties(NavOption pControlType, NavText pControlID, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil)
        {
            using (GetSharedControlProperties_Scope__304936115 \u03b2scope = new GetSharedControlProperties_Scope__304936115(this, pControlType, pControlID, jsonUtil))
                \u03b2scope.Run();
        }

        [NavName("GetSharedControlProperties")]
        [SignatureSpan(255297889835352110L)]
        [SourceSpans(257268163133177876L, 257549638109954094L, 257831113086730279L, 258112588063899660L, 258394080220151867L, 258675568081829964L, 258957047353573439L, 259519997307125850L, 259801437924163595L, 260082908605972488L)]
        private sealed class GetSharedControlProperties_Scope__304936115 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("JsonUtil")]
            public NavCodeunitHandle jsonUtil;
            [NavName("shared")]
            public INavRecordHandle shared;
            [NavName("controlRecRef")]
            public NavRecordRef controlRecRef;
            [NavName("controlFieldRef")]
            public NavFieldRef controlFieldRef;
            [NavName("i")]
            public int i = default(int);
            protected override uint RawScopeId { get => GetSharedControlProperties_Scope__304936115.\u03b1scopeId; set => GetSharedControlProperties_Scope__304936115.\u03b1scopeId = value; }

            internal GetSharedControlProperties_Scope__304936115(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
                this.jsonUtil = jsonUtil;
                this.shared = new NavRecordHandle(this, 99008963, false, SecurityFiltering.Validated);
                this.controlRecRef = new NavRecordRef(this, SecurityFiltering.Validated);
                this.controlFieldRef = new NavFieldRef(this);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.shared.Target.ALInit();
                StmtHit(1);
                this.shared.Target.SetFieldValueSafe(5, NavType.Option, this.pControlType);
                StmtHit(2);
                this.controlRecRef.ALGetTable(this.shared.Target);
                this.i = 1;
                StmtHit(3);
                int @tmp0 = this.controlRecRef.ALFieldCount;
                for (; this.i <= @tmp0;)
                {
                    {
                        CStmtHit(4);
                        this.controlFieldRef.ALAssign(this.controlRecRef.ALFieldIndex(this, this.i));
                        if (CStmtHit(5) & (base.Parent._CONTROLS.Target.ALGet(DataError.TrapError, this.pControlType, this.pControlID, ALCompiler.ToNavValue(this.controlFieldRef.ALName))))
                        {
                            StmtHit(6);
                            base.Parent.WriteControlPropertyToJSON(base.Parent._CONTROLS, this.jsonUtil);
                        }
                        else
                        {
                            StmtHit(7);
                            base.Parent.WriteFieldPropertyToJSON(new NavText(this.controlFieldRef.ALName), new ByRef<NavFieldRef>(() => this.controlFieldRef, setValue => this.controlFieldRef.ALAssign(setValue)), this.jsonUtil);
                        }
                    }

                    if (this.i >= @tmp0)
                        break;
                    this.i = this.i + 1;
                }

                StmtHit(8);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1200632012")]
        public void GetSystemAppInfo(NavJsonObject j)
        {
            using (GetSystemAppInfo_Scope_1882405785 \u03b2scope = new GetSystemAppInfo_Scope_1882405785(this, j))
                \u03b2scope.Run();
        }

        [NavName("GetSystemAppInfo")]
        [SignatureSpan(1266918930599182366L)]
        [SourceSpans(1268044817621385262L, 1268326296893128721L, 1268607754690035755L, 1268889229666811957L, 1269170704643588149L, 1269452192505266218L, 1269733671777009723L, 1270015125278949384L)]
        private sealed class GetSystemAppInfo_Scope_1882405785 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("j")]
            public NavJsonObject j;
            [NavName("mi")]
            public NavModuleInfo mi = NavModuleInfo.Default;
            protected override uint RawScopeId { get => GetSystemAppInfo_Scope_1882405785.\u03b1scopeId; set => GetSystemAppInfo_Scope_1882405785.\u03b1scopeId = value; }

            internal GetSystemAppInfo_Scope_1882405785(Codeunit10012739 \u03b2parent, NavJsonObject j) : base(\u03b2parent)
            {
                this.j = j;
                this.mi = NavModuleInfo.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!ALNavApp.ALGetCurrentModuleInfo(DataError.TrapError, new ByRef<NavModuleInfo>(() => this.mi, setValue => this.mi = setValue))))
                {
                    StmtHit(1);
                    return;
                }

                StmtHit(2);
                this.j.ALAdd(DataError.ThrowError, "S_ID", NavFormatEvaluateHelper.Format(ALCompiler.ToNavValue(this.mi.ALId), 0, 4));
                StmtHit(3);
                this.j.ALAdd(DataError.ThrowError, "S_PkgId", NavFormatEvaluateHelper.Format(ALCompiler.ToNavValue(this.mi.ALPackageId), 0, 4));
                StmtHit(4);
                this.j.ALAdd(DataError.ThrowError, "S_AppVersion", NavFormatEvaluateHelper.Format(this.mi.ALAppVersion));
                if (CStmtHit(5) & (this.mi.ALDataVersion != this.mi.ALAppVersion))
                {
                    StmtHit(6);
                    this.j.ALAdd(DataError.ThrowError, "S_DataVersion", NavFormatEvaluateHelper.Format(this.mi.ALDataVersion));
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1664285831")]
        public NavText GetValue(NavText pKey)
        {
            using (GetValue_Scope__1221286396 \u03b2scope = new GetValue_Scope__1221286396(this, pKey))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("GetValue")]
        [SignatureSpan(72620604137799702L)]
        [SourceSpans(73183528321548325L, 73464999003357192L)]
        private sealed class GetValue_Scope__1221286396 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pKey")]
            public NavText pKey;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => GetValue_Scope__1221286396.\u03b1scopeId; set => GetValue_Scope__1221286396.\u03b1scopeId = value; }

            internal GetValue_Scope__1221286396(Codeunit10012739 \u03b2parent, NavText pKey) : base(\u03b2parent)
            {
                this.pKey = pKey.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.context.Target.Invoke(-1221286396, new object[] { this.pKey }));
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1236491227")]
        public void GoToNextRow(NavCode pControlID)
        {
            using (GoToNextRow_Scope__1727550791 \u03b2scope = new GoToNextRow_Scope__1727550791(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("GoToNextRow")]
        [SignatureSpan(946600407027875865L)]
        [SourceSpans(947726294050078745L, 948007773321822272L, 948570706095505462L, 948852181072281637L, 949133651754090504L)]
        private sealed class GoToNextRow_Scope__1727550791 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("idx")]
            public int idx = default(int);
            protected override uint RawScopeId { get => GoToNextRow_Scope__1727550791.\u03b1scopeId; set => GoToNextRow_Scope__1727550791.\u03b1scopeId = value; }

            internal GoToNextRow_Scope__1727550791(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GoToNextRow(%1)", this.pControlID)));
                }

                StmtHit(2);
                this.idx = base.Parent.GetDataGridCurrentRowIndex(new NavText(this.pControlID));
                StmtHit(3);
                base.Parent.GoToRow(this.pControlID, this.idx + 1);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1354331570")]
        public void GoToPreviousRow(NavCode pControlID)
        {
            using (GoToPreviousRow_Scope_195449750 \u03b2scope = new GoToPreviousRow_Scope_195449750(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("GoToPreviousRow")]
        [SignatureSpan(949696631772413981L)]
        [SourceSpans(950822518794616857L, 951103998066360388L, 951666930840043574L, 951948405816819749L, 952229876498628616L)]
        private sealed class GoToPreviousRow_Scope_195449750 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("idx")]
            public int idx = default(int);
            protected override uint RawScopeId { get => GoToPreviousRow_Scope_195449750.\u03b1scopeId; set => GoToPreviousRow_Scope_195449750.\u03b1scopeId = value; }

            internal GoToPreviousRow_Scope_195449750(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GoToPreviousRow(%1)", this.pControlID)));
                }

                StmtHit(2);
                this.idx = base.Parent.GetDataGridCurrentRowIndex(new NavText(this.pControlID));
                StmtHit(3);
                base.Parent.GoToRow(this.pControlID, this.idx - 1);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 824226424")]
        public void GoToRow(NavCode pControlID, int pRowIndex)
        {
            using (GoToRow_Scope_1574670381 \u03b2scope = new GoToRow_Scope_1574670381(this, pControlID, pRowIndex))
                \u03b2scope.Run();
        }

        [NavName("GoToRow")]
        [SignatureSpan(952792856516952085L)]
        [SourceSpans(953355780700700757L, 953637255677476909L, 953918726359285768L)]
        private sealed class GoToRow_Scope_1574670381 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pRowIndex")]
            public int pRowIndex;
            protected override uint RawScopeId { get => GoToRow_Scope_1574670381.\u03b1scopeId; set => GoToRow_Scope_1574670381.\u03b1scopeId = value; }

            internal GoToRow_Scope_1574670381(Codeunit10012739 \u03b2parent, NavCode pControlID, int pRowIndex) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pRowIndex = pRowIndex;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.SendPOSCommandEvent(new NavText("_GOTOROW"), new NavText(ALSystemString.ALStrSubstNo("[%1]%2", this.pControlID, ALCompiler.ToNavValue(this.pRowIndex))));
                StmtHit(1);
                base.Parent.GoToRow_1548454713(this.pControlID, this.pRowIndex, true);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1814932271")]
        public void GoToRow_1548454713(NavCode pControlID, int pRowIndex, bool forceIgnoreModifications)
        {
            using (GoToRow_Scope__1548454713 \u03b2scope = new GoToRow_Scope__1548454713(this, pControlID, pRowIndex, forceIgnoreModifications))
                \u03b2scope.Run();
        }

        [NavName("GoToRow")]
        [SignatureSpan(954481745032314910L)]
        [SourceSpans(955607593399812121L, 955889072671555689L, 956170543353364515L, 956452022625108017L, 956733497601884210L, 957296430375567506L, 957577918237245475L, 957859397508988975L, 958140851010928648L)]
        private sealed class GoToRow_Scope__1548454713 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pRowIndex")]
            public int pRowIndex;
            [NavName("forceIgnoreModifications")]
            public bool forceIgnoreModifications;
            [NavName("b")]
            public bool b = default(bool);
            protected override uint RawScopeId { get => GoToRow_Scope__1548454713.\u03b1scopeId; set => GoToRow_Scope__1548454713.\u03b1scopeId = value; }

            internal GoToRow_Scope__1548454713(Codeunit10012739 \u03b2parent, NavCode pControlID, int pRowIndex, bool forceIgnoreModifications) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pRowIndex = pRowIndex;
                this.forceIgnoreModifications = forceIgnoreModifications;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GoToRow(%1, %2, %3)", this.pControlID, ALCompiler.ToNavValue(this.pRowIndex), ALCompiler.ToNavValue(this.forceIgnoreModifications))));
                }

                if (CStmtHit(2) & (this.forceIgnoreModifications))
                {
                    StmtHit(3);
                    this.b = ((bool)ALCompiler.ObjectToBoolean(base.Parent._CONTROLS.Target.Invoke(-834379943, Array.Empty<object>())));
                    StmtHit(4);
                    base.Parent._CONTROLS.Target.Invoke(-1263557647, new object[] { true });
                }

                StmtHit(5);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1000)), this.pRowIndex });
                if (CStmtHit(6) & (this.forceIgnoreModifications))
                {
                    StmtHit(7);
                    base.Parent._CONTROLS.Target.Invoke(-1263557647, new object[] { this.b });
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3542317113")]
        public bool HideActivePanel(bool pDialogResultOK)
        {
            using (HideActivePanel_Scope_1527642583 \u03b2scope = new HideActivePanel_Scope_1527642583(this, pDialogResultOK))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("HideActivePanel")]
        [SignatureSpan(624311558619136029L)]
        [SourceSpans(626000395594891289L, 626281874866634825L, 626844820525219876L, 627126299796963381L, 627407787658641465L, 627689266930384952L, 627970754792063011L, 628252234063806496L, 629096637519298617L, 629378116791042094L, 630222524541501481L, 630504012403179594L, 630785491674923062L, 631066949471830049L, 631348424448606281L, 631911387287060549L, 632192866558804042L, 632474341535580226L, 633037274309263383L, 633881694944624671L, 634163174216368169L, 634444662078046265L, 634726141349789747L, 635007629211467811L, 635289108483211296L, 636133499053801501L, 636414974030577697L, 636696461892255801L, 636977941163999278L, 637540873937682455L, 638385281688141844L, 638666752369950728L)]
        private sealed class HideActivePanel_Scope_1527642583 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pDialogResultOK")]
            public bool pDialogResultOK;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("panelID")]
            public NavText panelID = NavText.Default(0);
            [NavName("payload")]
            public NavText payload = NavText.Default(0);
            [NavName("wrapperDDPayLoad")]
            public NavText wrapperDDPayLoad = NavText.Default(0);
            protected override uint RawScopeId { get => HideActivePanel_Scope_1527642583.\u03b1scopeId; set => HideActivePanel_Scope_1527642583.\u03b1scopeId = value; }

            internal HideActivePanel_Scope_1527642583(Codeunit10012739 \u03b2parent, bool pDialogResultOK) : base(\u03b2parent)
            {
                this.pDialogResultOK = pDialogResultOK;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("HideActivePanel(%1)", ALCompiler.ToNavValue(this.pDialogResultOK))));
                }

                if (CStmtHit(2) & (((int)ALCompiler.ObjectToInt32(base.Parent.modalPanelStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                {
                    StmtHit(3);
                    this.panelID = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.modalPanelStack.Target.Invoke(-856648329, new object[] { new ByRef<NavText>(() => this.payload, setValue => this.payload = setValue) }));
                    if (CStmtHit(4) & (((bool)ALCompiler.ObjectToBoolean(base.Parent.panelClosedEventRegister.Target.Invoke(-309671161, new object[] { this.panelID })))))
                    {
                        StmtHit(5);
                        base.Parent.SendPanelCloseRequest(this.panelID, this.payload);
                        if (CStmtHit(6) & (base.Parent.panelCloseDenied))
                        {
                            StmtHit(7);
                            this.\u03b3retVal = false;
                            return;
                        }
                    }

                    if (CStmtHit(8) & (((bool)ALCompiler.ObjectToBoolean(base.Parent.panelClosedEventRegister.Target.Invoke(-309671161, new object[] { this.panelID })))))
                    {
                        StmtHit(9);
                        base.Parent.SendPanelClosedEvent(new NavCode(20, this.panelID));
                    }

                    StmtHit(10);
                    base.Parent.modalPanelStack.Target.Invoke(-1534566709, new object[] { new ByRef<NavText>(() => this.payload, setValue => this.payload = setValue) });
                    if (CStmtHit(11) & (ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.modalPanelStack.Target.Invoke(918080733, Array.Empty<object>())) == NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 9)))))
                    {
                        StmtHit(12);
                        base.Parent.modalPanelStack.Target.Invoke(-1534566709, new object[] { new ByRef<NavText>(() => this.wrapperDDPayLoad, setValue => this.wrapperDDPayLoad = setValue) });
                    }

                    StmtHit(13);
                    base.Parent.ResumeCurrentPanel();
                    StmtHit(14);
                    base.Parent.SendModalPanelClosedEvent(this.panelID, this.pDialogResultOK, this.payload);
                    if (CStmtHit(15) & (base.Parent.pendingShowPanelOnModalPanelClose.ALContainsKey(this.panelID)))
                    {
                        StmtHit(16);
                        base.Parent.ShowPanel(base.Parent.pendingShowPanelOnModalPanelClose.ALGet(this.panelID));
                        StmtHit(17);
                        base.Parent.pendingShowPanelOnModalPanelClose.ALRemove(this.panelID);
                    }

                    StmtHit(18);
                    this.\u03b3retVal = true;
                    return;
                }

                if (CStmtHit(19) & (((int)ALCompiler.ObjectToInt32(base.Parent.panelStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                {
                    StmtHit(20);
                    this.panelID = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.panelStack.Target.Invoke(918080733, Array.Empty<object>()));
                    if (CStmtHit(21) & (((bool)ALCompiler.ObjectToBoolean(base.Parent.panelClosedEventRegister.Target.Invoke(-309671161, new object[] { this.panelID })))))
                    {
                        StmtHit(22);
                        base.Parent.SendPanelCloseRequest(this.panelID, new NavText(""));
                        if (CStmtHit(23) & (base.Parent.panelCloseDenied))
                        {
                            StmtHit(24);
                            this.\u03b3retVal = false;
                            return;
                        }
                    }

                    StmtHit(25);
                    base.Parent.panelStack.Target.Invoke(-760389506, Array.Empty<object>());
                    StmtHit(26);
                    base.Parent.ResumeCurrentPanel();
                    if (CStmtHit(27) & (((bool)ALCompiler.ObjectToBoolean(base.Parent.panelClosedEventRegister.Target.Invoke(-309671161, new object[] { this.panelID })))))
                    {
                        StmtHit(28);
                        base.Parent.SendPanelClosedEvent(new NavCode(20, this.panelID));
                    }

                    StmtHit(29);
                    this.\u03b3retVal = true;
                    return;
                }

                StmtHit(30);
                this.\u03b3retVal = false;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2265248737")]
        public void HideControl_888901552(NavOption pControlType, NavText pControlID)
        {
            using (HideControl_Scope__888901552 \u03b2scope = new HideControl_Scope__888901552(this, pControlType, pControlID))
                \u03b2scope.Run();
        }

        [NavName("HideControl")]
        [SignatureSpan(843299090551013401L)]
        [SourceSpans(843862014734762062L, 844424977573216316L, 844706456844959849L, 845269389618643044L, 845550860300451848L)]
        private sealed class HideControl_Scope__888901552 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            protected override uint RawScopeId { get => HideControl_Scope__888901552.\u03b1scopeId; set => HideControl_Scope__888901552.\u03b1scopeId = value; }

            internal HideControl_Scope__888901552(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.LogTrace(new NavText(ALSystemString.ALStrSubstNo("HideControl %1 - %2", this.pControlType, this.pControlID)));
                if (CStmtHit(1) & (this.pControlType == NavOption.Create(NCLEnumMetadata.Create(99008881), 8)))
                {
                    StmtHit(2);
                    base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { this.pControlType, this.pControlID, new NavText(base.Parent._SHARED.Target.ALFieldName(20)), new NavText("-") });
                }

                StmtHit(3);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { this.pControlType, this.pControlID, new NavText(base.Parent._SHARED.Target.ALFieldName(20)), new NavText("") });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1567341849")]
        public void HideControl([NavObjectId(ObjectId = 99008874)][NavByReferenceAttribute] INavRecordHandle pPanelControlEntity)
        {
            using (HideControl_Scope__918336590 \u03b2scope = new HideControl_Scope__918336590(this, pPanelControlEntity))
                \u03b2scope.Run();
        }

        [NavName("HideControl")]
        [SignatureSpan(841891715667132441L)]
        [SourceSpans(842454639850881108L, 842736110532689928L)]
        private sealed class HideControl_Scope__918336590 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelControlEntity")]
            public INavRecordHandle pPanelControlEntity;
            protected override uint RawScopeId { get => HideControl_Scope__918336590.\u03b1scopeId; set => HideControl_Scope__918336590.\u03b1scopeId = value; }

            internal HideControl_Scope__918336590(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99008874)][NavByReferenceAttribute] INavRecordHandle pPanelControlEntity) : base(\u03b2parent)
            {
                this.pPanelControlEntity = pPanelControlEntity;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.HideControl_888901552(((NavOption)this.pPanelControlEntity.Target.GetFieldValueSafe(8, NavType.Option)), new NavText(((NavCode)this.pPanelControlEntity.Target.GetFieldValueSafe(9, NavType.Code))));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 761004143")]
        public void HideExtraButtons(NavText pProfileID, NavText pMenuID, int pFromButtonNo)
        {
            using (HideExtraButtons_Scope_528276133 \u03b2scope = new HideExtraButtons_Scope_528276133(this, pProfileID, pMenuID, pFromButtonNo))
                \u03b2scope.Run();
        }

        [NavName("HideExtraButtons")]
        [SignatureSpan(735212699468955678L)]
        [SourceSpans(736338586491158553L, 736620065762902117L, 737182998536585252L, 737464473513361465L, 737745948490137670L, 738027436351815720L, 738590407780204666L, 738871882756980810L, 739153366323691566L, 739434794055827464L)]
        private sealed class HideExtraButtons_Scope_528276133 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pProfileID")]
            public NavText pProfileID;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pFromButtonNo")]
            public int pFromButtonNo;
            [NavName("ctrlID")]
            public NavText ctrlID = NavText.Default(0);
            protected override uint RawScopeId { get => HideExtraButtons_Scope_528276133.\u03b1scopeId; set => HideExtraButtons_Scope_528276133.\u03b1scopeId = value; }

            internal HideExtraButtons_Scope_528276133(Codeunit10012739 \u03b2parent, NavText pProfileID, NavText pMenuID, int pFromButtonNo) : base(\u03b2parent)
            {
                this.pProfileID = pProfileID.ModifyLength(0);
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pFromButtonNo = pFromButtonNo;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText(ALSystemString.ALStrSubstNo("HideExtraButtons(%1, %2, %3)", this.pProfileID, this.pMenuID, ALCompiler.ToNavValue(this.pFromButtonNo))));
                }

                StmtHit(2);
                base.Parent._MenuButtonEntities.Target.ALReset();
                StmtHit(3);
                base.Parent._MenuButtonEntities.Target.ALSetRangeSafe(1, NavType.Code, this.pMenuID);
                StmtHit(4);
                base.Parent._MenuButtonEntities.Target.ALSetFilter(2, ">%1", ALCompiler.ToNavValue(this.pFromButtonNo));
                if (CStmtHit(5) & (base.Parent._MenuButtonEntities.Target.ALFindSet(DataError.TrapError)))
                    do
                    {
                        StmtHit(6);
                        this.ctrlID = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code))), base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(2, NavType.Integer).ToInt32() }));
                        StmtHit(7);
                        base.Parent.HideControl_888901552(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), this.ctrlID);
                    }
                    while (!(CStmtHit(8) & (base.Parent._MenuButtonEntities.Target.ALNext() == 0)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 821267902")]
        public void HidePanel(NavText pPanelID, bool pDialogResultOK)
        {
            using (HidePanel_Scope__1149855453 \u03b2scope = new HidePanel_Scope__1149855453(this, pPanelID, pDialogResultOK))
                \u03b2scope.Run();
        }

        [NavName("HidePanel")]
        [SignatureSpan(619807958990716951L)]
        [SourceSpans(620370896059367449L, 620652375331110993L, 621215320989696036L, 621496813146341424L, 621778292418084913L, 622059767394861077L, 622904170850353183L, 623185663006998569L, 623467142278742065L, 623748578600812552L)]
        private sealed class HidePanel_Scope__1149855453 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("pDialogResultOK")]
            public bool pDialogResultOK;
            protected override uint RawScopeId { get => HidePanel_Scope__1149855453.\u03b1scopeId; set => HidePanel_Scope__1149855453.\u03b1scopeId = value; }

            internal HidePanel_Scope__1149855453(Codeunit10012739 \u03b2parent, NavText pPanelID, bool pDialogResultOK) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.pDialogResultOK = pDialogResultOK;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("HidePanel(%1, %2)", this.pPanelID, ALCompiler.ToNavValue(this.pDialogResultOK))));
                }

                if (CStmtHit(2) & (((int)ALCompiler.ObjectToInt32(base.Parent.modalPanelStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                    if (CStmtHit(3) & (ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.modalPanelStack.Target.Invoke(918080733, Array.Empty<object>())) == this.pPanelID))
                    {
                        StmtHit(4);
                        base.Parent.HideActivePanel(this.pDialogResultOK);
                        StmtHit(5);
                        return;
                    }

                if (CStmtHit(6) & (((int)ALCompiler.ObjectToInt32(base.Parent.panelStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                    if (CStmtHit(7) & (ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.panelStack.Target.Invoke(918080733, Array.Empty<object>())) == this.pPanelID))
                    {
                        StmtHit(8);
                        base.Parent.HideActivePanel(this.pDialogResultOK);
                    }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3940577012")]
        public void HidePopupGrid()
        {
            using (HidePopupGrid_Scope__1720717819 \u03b2scope = new HidePopupGrid_Scope__1720717819(this))
                \u03b2scope.Run();
        }

        [NavName("HidePopupGrid")]
        [SignatureSpan(928867483490975771L)]
        [SourceSpans(929993370513178657L, 930274849784922230L, 930556303286861832L)]
        private sealed class HidePopupGrid_Scope__1720717819 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("panelID")]
            public static readonly NavTextConstant panelID = new NavTextConstant(new int[] { 1033 }, new string[] { "##POPUPGRIDCONTAINER" }, null, null);
            protected override uint RawScopeId { get => HidePopupGrid_Scope__1720717819.\u03b1scopeId; set => HidePopupGrid_Scope__1720717819.\u03b1scopeId = value; }

            internal HidePopupGrid_Scope__1720717819(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.ContainsPanel(new NavText(panelID))))
                {
                    StmtHit(1);
                    base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2), new NavText(panelID), new NavText(base.Parent._SHARED.Target.ALFieldName(20)), new NavText("") });
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 335249594")]
        public void IgnorePostCommand()
        {
            using (IgnorePostCommand_Scope_1103139611 \u03b2scope = new IgnorePostCommand_Scope_1103139611(this))
                \u03b2scope.Run();
        }

        [NavName("IgnorePostCommand")]
        [SignatureSpan(1076078896344924191L)]
        [SourceSpans(1076641833413574681L, 1076923312685318188L, 1077486245459001399L, 1077767716140810248L)]
        private sealed class IgnorePostCommand_Scope_1103139611 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => IgnorePostCommand_Scope_1103139611.\u03b1scopeId; set => IgnorePostCommand_Scope_1103139611.\u03b1scopeId = value; }

            internal IgnorePostCommand_Scope_1103139611(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText("IgnorePostCommand()"));
                }

                StmtHit(2);
                base.Parent.SendPOSCommandEvent(new NavText("_IGNORE_POSTCOMMAND"), new NavText(""));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2798949660")]
        public void InitControl(NavText pClientID, NavInterfaceHandle pControler)
        {
            using (InitControl_Scope_747471512 \u03b2scope = new InitControl_Scope_747471512(this, pClientID, pControler))
                \u03b2scope.Run();
        }

        [NavName("InitControl")]
        [SignatureSpan(285978636534153241L)]
        [SourceSpans(286541560717901864L, 286823035694678055L, 287104510671454239L, 287385981353263112L)]
        private sealed class InitControl_Scope_747471512 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pClientID")]
            public NavText pClientID;
            [NavName("pControler")]
            public NavInterfaceHandle pControler;
            protected override uint RawScopeId { get => InitControl_Scope_747471512.\u03b1scopeId; set => InitControl_Scope_747471512.\u03b1scopeId = value; }

            internal InitControl_Scope_747471512(Codeunit10012739 \u03b2parent, NavText pClientID, NavInterfaceHandle pControler) : base(\u03b2parent)
            {
                this.pClientID = pClientID.ModifyLength(10);
                this.pControler = pControler.ALByValue(this);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent._ActiveController.ALAssign(this.pControler);
                StmtHit(1);
                base.Parent._ControllerInitialized = true;
                StmtHit(2);
                base.Parent.InitControl_1883444758(this.pClientID);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3184526803")]
        public void InitControl_1883444758(NavText pMainControlID)
        {
            using (InitControl_Scope__1883444758 \u03b2scope = new InitControl_Scope__1883444758(this, pMainControlID))
                \u03b2scope.Run();
        }

        [NavName("InitControl")]
        [SignatureSpan(287948961371586585L)]
        [SourceSpans(288511898440237081L, 288793377711980638L, 289356310485663795L, 289637785462440006L, 290200735415992369L, 290482210392768563L, 290763685369544746L, 291045160346320943L, 291608110299873313L, 292171060253425700L, 292452535230201894L, 293015485183754269L, 293296960160530466L, 293578435137306654L, 293859910114082851L, 294141385090859042L, 294422860067635239L, 294704335044411421L, 294985810021187613L, 295267284997963806L, 295548759974740007L, 295830234951516190L, 296111709928292384L, 296674659881844760L, 297237609835397146L, 297519080517206024L)]
        private sealed class InitControl_Scope__1883444758 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMainControlID")]
            public NavText pMainControlID;
            protected override uint RawScopeId { get => InitControl_Scope__1883444758.\u03b1scopeId; set => InitControl_Scope__1883444758.\u03b1scopeId = value; }

            internal InitControl_Scope__1883444758(Codeunit10012739 \u03b2parent, NavText pMainControlID) : base(\u03b2parent)
            {
                this.pMainControlID = pMainControlID.ModifyLength(10);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ControlLib.InitControl: pMainControlID=%1", this.pMainControlID)));
                }

                StmtHit(2);
                base.Parent._dualDisp = (this.pMainControlID == "DualDisp");
                StmtHit(3);
                base.Parent.SetMainControlValue(new NavText(base.Parent._POS.Target.ALFieldName(10)), base.Parent._dualDisp);
                StmtHit(4);
                base.Parent.__DeepTracePanelControlEntities = false;
                StmtHit(5);
                base.Parent.__DeepTracePanelRowColumnEntities = false;
                StmtHit(6);
                base.Parent.__DeepTracePanelEntities = false;
                StmtHit(7);
                base.Parent.__DeepTraceMenuButtonEntities = false;
                StmtHit(8);
                base.Parent._TmpLineIndexer = 90000;
                StmtHit(9);
                base.Parent._InstanceID = ALSystemNumeric.ALRandom(9999);
                StmtHit(10);
                base.Parent._ignoreModifications = false;
                StmtHit(11);
                base.Parent._MenuProfileID = new NavText("");
                StmtHit(12);
                base.Parent._StoreMenuProfileID = new NavText("");
                StmtHit(13);
                base.Parent._StyleProfileID = new NavText("");
                StmtHit(14);
                base.Parent._StoreStyleProfileID = new NavText("");
                StmtHit(15);
                base.Parent._InterfaceProfileID = new NavText("");
                StmtHit(16);
                base.Parent._StoreInterfaceProfileID = new NavText("");
                StmtHit(17);
                base.Parent._FontIdsFilter = new NavText("");
                StmtHit(18);
                base.Parent._SkinIdsFilter = new NavText("");
                StmtHit(19);
                base.Parent._ColorIdsFilter = new NavText("");
                StmtHit(20);
                base.Parent._SkipDefaultResources = false;
                StmtHit(21);
                base.Parent._ActiveLanguage = new NavText("");
                StmtHit(22);
                base.Parent._NO_STD_PANELS = false;
                StmtHit(23);
                base.Parent.ClearControls();
                StmtHit(24);
                base.Parent.currDataTag = new NavText("");
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2399403457")]
        public void InitGridDataSet(NavCode pControlID, NavText pDataTableID, NavJsonObject pDataJson)
        {
            using (InitGridDataSet_Scope__1870183314 \u03b2scope = new InitGridDataSet_Scope__1870183314(this, pControlID, pDataTableID, pDataJson))
                \u03b2scope.Run();
        }

        [NavName("InitGridDataSet")]
        [SignatureSpan(905505060418551837L)]
        [SourceSpans(906067997487202329L, 906349476758945884L, 906630947440754713L, 906912426712498212L, 907475359486181440L, 907756830167990280L)]
        private sealed class InitGridDataSet_Scope__1870183314 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pDataTableID")]
            public NavText pDataTableID;
            [NavName("pDataJson")]
            public NavJsonObject pDataJson;
            protected override uint RawScopeId { get => InitGridDataSet_Scope__1870183314.\u03b1scopeId; set => InitGridDataSet_Scope__1870183314.\u03b1scopeId = value; }

            internal InitGridDataSet_Scope__1870183314(Codeunit10012739 \u03b2parent, NavCode pControlID, NavText pDataTableID, NavJsonObject pDataJson) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pDataTableID = pDataTableID.ModifyLength(0);
                this.pDataJson = pDataJson;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("InitGridDataSet(%1, %2, JSON)", this.pControlID, this.pDataTableID)));
                }

                if (CStmtHit(2) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(3);
                    base.Parent.LogDeepTrace(this.pDataJson);
                }

                StmtHit(4);
                base.Parent.AddGridDataSet(this.pControlID, this.pDataTableID, this.pDataJson, -1);
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void InputRequest(NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008877)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound)
        {
            if (InputRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (InputRequest_Scope \u03b2scope = new InputRequest_Scope(this, pMainProfileID, pStoreProfileID, pControlID, pControlRec, pFound))
                \u03b2scope.RunEvent();
        }

        [NavName("InputRequest")]
        [SignatureSpan(173107196616704032L)]
        [SourceSpans(173670090735681544L)]
        private sealed class InputRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("pMainProfileID")]
            public NavText pMainProfileID;
            [NavName("pStoreProfileID")]
            public NavText pStoreProfileID;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pControlRec")]
            public INavRecordHandle pControlRec;
            [NavName("pFound")]
            public ByRef<bool> pFound;
            protected override uint RawScopeId { get => InputRequest_Scope.\u03b1scopeId; set => InputRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => InputRequest_Scope.\u03b3eventScope; set => InputRequest_Scope.\u03b3eventScope = value; }

            internal InputRequest_Scope(Codeunit10012739 \u03b2parent, NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008877)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound) : base(\u03b2parent)
            {
                this.pMainProfileID = pMainProfileID.ModifyLength(0);
                this.pStoreProfileID = pStoreProfileID.ModifyLength(0);
                this.pControlID = pControlID.ModifyLength(0);
                this.pControlRec = pControlRec;
                this.pFound = pFound;
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void InterfaceProfileRequest(NavText mainProfileID, NavText storeProfileID, [NavObjectId(ObjectId = 99008881)][NavByReferenceAttribute] INavRecordHandle pProfileEntity)
        {
            if (InterfaceProfileRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (InterfaceProfileRequest_Scope \u03b2scope = new InterfaceProfileRequest_Scope(this, mainProfileID, storeProfileID, pProfileEntity))
                \u03b2scope.RunEvent();
        }

        [NavName("InterfaceProfileRequest")]
        [SignatureSpan(1201898236733685803L)]
        [SourceSpans(1202461130852663304L)]
        private sealed class InterfaceProfileRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("mainProfileID")]
            public NavText mainProfileID;
            [NavName("storeProfileID")]
            public NavText storeProfileID;
            [NavName("pProfileEntity")]
            public INavRecordHandle pProfileEntity;
            protected override uint RawScopeId { get => InterfaceProfileRequest_Scope.\u03b1scopeId; set => InterfaceProfileRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => InterfaceProfileRequest_Scope.\u03b3eventScope; set => InterfaceProfileRequest_Scope.\u03b3eventScope = value; }

            internal InterfaceProfileRequest_Scope(Codeunit10012739 \u03b2parent, NavText mainProfileID, NavText storeProfileID, [NavObjectId(ObjectId = 99008881)][NavByReferenceAttribute] INavRecordHandle pProfileEntity) : base(\u03b2parent)
            {
                this.mainProfileID = mainProfileID.ModifyLength(0);
                this.storeProfileID = storeProfileID.ModifyLength(0);
                this.pProfileEntity = pProfileEntity;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3874114263")]
        public bool IsDualDisplay()
        {
            using (IsDualDisplay_Scope_2054812490 \u03b2scope = new IsDualDisplay_Scope_2054812490(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("IsDualDisplay")]
        [SignatureSpan(1251719281853267995L)]
        [SourceSpans(1252282206037016600L, 1252563676718825480L)]
        private sealed class IsDualDisplay_Scope_2054812490 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            protected override uint RawScopeId { get => IsDualDisplay_Scope_2054812490.\u03b1scopeId; set => IsDualDisplay_Scope_2054812490.\u03b1scopeId = value; }

            internal IsDualDisplay_Scope_2054812490(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent._dualDisp;
                return;
            }
        }

        private NavText JavascriptStringEncode(NavText str)
        {
            using (JavascriptStringEncode_Scope_691971727 \u03b2scope = new JavascriptStringEncode_Scope_691971727(this, str))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("JavascriptStringEncode")]
        [SignatureSpan(1083678746487685162L)]
        [SourceSpans(1084241644901629990L, 1084523119878406184L, 1084804594855182354L, 1085086065536991240L)]
        private sealed class JavascriptStringEncode_Scope_691971727 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("str")]
            public NavText str;
            [ReturnValue]
            public NavText \u03b3retVal = NavText.Default(0);
            protected override uint RawScopeId { get => JavascriptStringEncode_Scope_691971727.\u03b1scopeId; set => JavascriptStringEncode_Scope_691971727.\u03b1scopeId = value; }

            internal JavascriptStringEncode_Scope_691971727(Codeunit10012739 \u03b2parent, NavText str) : base(\u03b2parent)
            {
                this.str = str.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.str = NavTextExtensions.ALReplace(this.str, new NavText("\\"), new NavText("\\\\"));
                StmtHit(1);
                this.str = NavTextExtensions.ALReplace(this.str, new NavText("'"), new NavText("\\'"));
                StmtHit(2);
                this.\u03b3retVal = this.str;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2104081809")]
        public void JoinButtons(NavCode menuID, int slaveButtonNo, int masterButtonNo)
        {
            using (JoinButtons_Scope_1073743772 \u03b2scope = new JoinButtons_Scope_1073743772(this, menuID, slaveButtonNo, masterButtonNo))
                \u03b2scope.Run();
        }

        [NavName("JoinButtons")]
        [SignatureSpan(1071012346762952729L)]
        [SourceSpans(1071575283831603225L, 1071856763103346787L, 1072419695877095558L, 1072982641535614984L)]
        private sealed class JoinButtons_Scope_1073743772 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("menuID")]
            public NavCode menuID;
            [NavName("slaveButtonNo")]
            public int slaveButtonNo;
            [NavName("masterButtonNo")]
            public int masterButtonNo;
            protected override uint RawScopeId { get => JoinButtons_Scope_1073743772.\u03b1scopeId; set => JoinButtons_Scope_1073743772.\u03b1scopeId = value; }

            internal JoinButtons_Scope_1073743772(Codeunit10012739 \u03b2parent, NavCode menuID, int slaveButtonNo, int masterButtonNo) : base(\u03b2parent)
            {
                this.menuID = menuID.ModifyLength(20);
                this.slaveButtonNo = slaveButtonNo;
                this.masterButtonNo = masterButtonNo;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("JoinButtons(%1, %2, %3)", this.menuID, ALCompiler.ToNavValue(this.slaveButtonNo), ALCompiler.ToNavValue(this.masterButtonNo))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.slaveButtonNo })), new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(657)), this.masterButtonNo });
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void KeyCommandRequest(NavText filterText, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil)
        {
            if (KeyCommandRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (KeyCommandRequest_Scope \u03b2scope = new KeyCommandRequest_Scope(this, filterText, jsonUtil))
                \u03b2scope.RunEvent();
        }

        [NavName("KeyCommandRequest")]
        [SignatureSpan(1206120361385328677L)]
        [SourceSpans(1206683255504306184L)]
        private sealed class KeyCommandRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("filterText")]
            public NavText filterText;
            [NavName("jsonUtil")]
            public NavCodeunitHandle jsonUtil;
            protected override uint RawScopeId { get => KeyCommandRequest_Scope.\u03b1scopeId; set => KeyCommandRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => KeyCommandRequest_Scope.\u03b3eventScope; set => KeyCommandRequest_Scope.\u03b3eventScope = value; }

            internal KeyCommandRequest_Scope(Codeunit10012739 \u03b2parent, NavText filterText, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil) : base(\u03b2parent)
            {
                this.filterText = filterText.ModifyLength(0);
                this.jsonUtil = jsonUtil;
            }
        }

        private void LoadControl(NavOption pControlType, NavText pControlID)
        {
            using (LoadControl_Scope_1185513907 \u03b2scope = new LoadControl_Scope_1185513907(this, pControlType, pControlID))
                \u03b2scope.Run();
        }

        [NavName("LoadControl")]
        [SignatureSpan(99642227678117919L)]
        [SourceSpans(100205126092062755L, 100486601068838944L, 100768076045615162L, 101049551022391347L, 101331038884069412L, 103864296495185928L)]
        private sealed class LoadControl_Scope_1185513907 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            protected override uint RawScopeId { get => LoadControl_Scope_1185513907.\u03b1scopeId; set => LoadControl_Scope_1185513907.\u03b1scopeId = value; }

            internal LoadControl_Scope_1185513907(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.loadedControlsTemp.Target.ALReset();
                StmtHit(1);
                base.Parent.loadedControlsTemp.Target.ALInit();
                StmtHit(2);
                base.Parent.loadedControlsTemp.Target.SetFieldValueSafe(2, NavType.Option, this.pControlType);
                StmtHit(3);
                base.Parent.loadedControlsTemp.Target.SetFieldValueSafe(4, NavType.Code, new NavCode(25, this.pControlID));
                if (CStmtHit(4) & (base.Parent.loadedControlsTemp.Target.ALInsert(DataError.TrapError)))
                    ;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 228836988")]
        public void LoadKeyCommands()
        {
            using (LoadKeyCommands_Scope__692348430 \u03b2scope = new LoadKeyCommands_Scope__692348430(this))
                \u03b2scope.Run();
        }

        [NavName("LoadKeyCommands")]
        [SignatureSpan(1242993557573206045L)]
        [SourceSpans(1243556481756954659L, 1243837952438763528L)]
        private sealed class LoadKeyCommands_Scope__692348430 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => LoadKeyCommands_Scope__692348430.\u03b1scopeId; set => LoadKeyCommands_Scope__692348430.\u03b1scopeId = value; }

            internal LoadKeyCommands_Scope__692348430(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.keyCommandsPending = true;
            }
        }

        private bool LoadMenu(NavText pMenuID)
        {
            using (LoadMenu_Scope__596991018 \u03b2scope = new LoadMenu_Scope__596991018(this, pMenuID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("LoadMenu")]
        [SignatureSpan(109493851865284636L)]
        [SourceSpans(110056763164131353L, 110338242435874861L, 110901188094459935L, 111182667366203416L, 111745600139886653L, 112027075116662845L, 112308550093439052L, 112590037955117089L, 112871495752024072L)]
        private sealed class LoadMenu_Scope__596991018 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            protected override uint RawScopeId { get => LoadMenu_Scope__596991018.\u03b1scopeId; set => LoadMenu_Scope__596991018.\u03b1scopeId = value; }

            internal LoadMenu_Scope__596991018(Codeunit10012739 \u03b2parent, NavText pMenuID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("LoadMenu: " + this.pMenuID));
                }

                if (CStmtHit(2) & (!base.Parent.GetMenu(this.pMenuID)))
                {
                    StmtHit(3);
                    this.\u03b3retVal = false;
                    return;
                }

                StmtHit(4);
                base.Parent.loadedMenusTemp.Target.SetFieldValueSafe(1010, NavType.Code, new NavCode(10, ((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(10, NavType.Code))));
                StmtHit(5);
                base.Parent.loadedMenusTemp.Target.SetFieldValueSafe(2, NavType.Code, new NavCode(25, ((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(1, NavType.Code))));
                StmtHit(6);
                base.Parent.loadedMenusTemp.Target.SetFieldValueSafe(1000, NavType.Boolean, ALCompiler.ToNavValue(base.Parent._PanelEntities.Target.GetFieldValueSafe(1000, NavType.Boolean).ToBoolean()));
                if (CStmtHit(7) & (base.Parent.loadedMenusTemp.Target.ALInsert(DataError.TrapError)))
                    ;
            }
        }

        private bool LoadPanel(NavText pPanelID)
        {
            using (LoadPanel_Scope_422473632 \u03b2scope = new LoadPanel_Scope_422473632(this, pPanelID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("LoadPanel")]
        [SignatureSpan(115404826377584669L)]
        [SourceSpans(115967737676431385L, 116249216948174895L, 116812162606759969L, 117093641878503448L, 117656574652186687L, 117938049628962879L, 118219524605739085L, 118501012467417122L, 119063949536067657L, 119626912374521917L, 119908391646265423L, 120471341599817808L, 121034274373500947L, 121315745055309832L)]
        private sealed class LoadPanel_Scope_422473632 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            protected override uint RawScopeId { get => LoadPanel_Scope_422473632.\u03b1scopeId; set => LoadPanel_Scope_422473632.\u03b1scopeId = value; }

            internal LoadPanel_Scope_422473632(Codeunit10012739 \u03b2parent, NavText pPanelID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("LoadPanel: " + this.pPanelID));
                }

                if (CStmtHit(2) & (!base.Parent.GetPanel(this.pPanelID)))
                {
                    StmtHit(3);
                    this.\u03b3retVal = false;
                    return;
                }

                StmtHit(4);
                base.Parent.loadedPanelsTemp.Target.SetFieldValueSafe(1010, NavType.Code, ((NavCode)base.Parent._PanelEntities.Target.GetFieldValueSafe(1010, NavType.Code)));
                StmtHit(5);
                base.Parent.loadedPanelsTemp.Target.SetFieldValueSafe(2, NavType.Code, ((NavCode)base.Parent._PanelEntities.Target.GetFieldValueSafe(2, NavType.Code)));
                StmtHit(6);
                base.Parent.loadedPanelsTemp.Target.SetFieldValueSafe(1000, NavType.Boolean, ALCompiler.ToNavValue(base.Parent._PanelEntities.Target.GetFieldValueSafe(1000, NavType.Boolean).ToBoolean()));
                if (CStmtHit(7) & (base.Parent.loadedPanelsTemp.Target.ALInsert(DataError.TrapError)))
                    ;
                StmtHit(8);
                base.Parent.RefreshControl(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2), this.pPanelID, false);
                if (CStmtHit(9) & (!base.Parent.panelOpenedEventRegister.ALContainsKey(this.pPanelID)))
                {
                    StmtHit(10);
                    base.Parent.panelOpenedEventRegister.ALAdd(DataError.ThrowError, this.pPanelID, base.Parent._PanelEntities.Target.GetFieldValueSafe(110, NavType.Boolean).ToBoolean());
                }
                else
                {
                    StmtHit(11);
                    base.Parent.panelOpenedEventRegister.ALSet(this.pPanelID, base.Parent._PanelEntities.Target.GetFieldValueSafe(110, NavType.Boolean).ToBoolean());
                }

                StmtHit(12);
                this.\u03b3retVal = true;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1387603353")]
        public void LoadPosContextMenus()
        {
            using (LoadPosContextMenus_Scope__544852330 \u03b2scope = new LoadPosContextMenus_Scope__544852330(this))
                \u03b2scope.Run();
        }

        [NavName("LoadPosContextMenus")]
        [SignatureSpan(1241586182689325089L)]
        [SourceSpans(1242149106873073700L, 1242430577554882568L)]
        private sealed class LoadPosContextMenus_Scope__544852330 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => LoadPosContextMenus_Scope__544852330.\u03b1scopeId; set => LoadPosContextMenus_Scope__544852330.\u03b1scopeId = value; }

            internal LoadPosContextMenus_Scope__544852330(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.contextMenusPending = true;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2852687652")]
        public void LoadStandardPanels()
        {
            using (LoadStandardPanels_Scope__748473358 \u03b2scope = new LoadStandardPanels_Scope__748473358(this))
                \u03b2scope.Run();
        }

        [NavName("LoadStandardPanels")]
        [SignatureSpan(1244400932457087008L)]
        [SourceSpans(1246934194363170841L, 1247215673634914321L, 1247778606408597561L, 1248060081385373732L, 1248341556362149923L, 1248623031338926117L, 1248904506315702309L, 1249185981292478500L, 1249467456269254687L, 1249748926951063560L)]
        private sealed class LoadStandardPanels_Scope__748473358 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("LBL_WRAPPERID")]
            public static readonly NavTextConstant lBL_WRAPPERID = new NavTextConstant(new int[] { 1033 }, new string[] { "##WRAPPER" }, null, null);
            [NavName("LBL_NUMPADID")]
            public static readonly NavTextConstant lBL_NUMPADID = new NavTextConstant(new int[] { 1033 }, new string[] { "#NUMPAD" }, null, null);
            [NavName("LBL_KEYBOARDID")]
            public static readonly NavTextConstant lBL_KEYBOARDID = new NavTextConstant(new int[] { 1033 }, new string[] { "#KEYBOARD" }, null, null);
            [NavName("LBL_CALENDARID")]
            public static readonly NavTextConstant lBL_CALENDARID = new NavTextConstant(new int[] { 1033 }, new string[] { "#CALENDAR" }, null, null);
            [NavName("LBL_TIMEOFDAY")]
            public static readonly NavTextConstant lBL_TIMEOFDAY = new NavTextConstant(new int[] { 1033 }, new string[] { "#TIMEOFDAY" }, null, null);
            [NavName("LBL_FIXED")]
            public static readonly NavTextConstant lBL_FIXED = new NavTextConstant(new int[] { 1033 }, new string[] { "FIXED" }, null, null);
            protected override uint RawScopeId { get => LoadStandardPanels_Scope__748473358.\u03b1scopeId; set => LoadStandardPanels_Scope__748473358.\u03b1scopeId = value; }

            internal LoadStandardPanels_Scope__748473358(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent._NO_STD_PANELS))
                {
                    StmtHit(1);
                    return;
                }

                StmtHit(2);
                base.Parent.RefreshPanel(new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 9)))));
                StmtHit(3);
                base.Parent.RefreshPanel(new NavText(lBL_WRAPPERID));
                StmtHit(4);
                base.Parent.RefreshPanel(new NavText(lBL_NUMPADID));
                StmtHit(5);
                base.Parent.RefreshPanel(new NavText(lBL_KEYBOARDID));
                StmtHit(6);
                base.Parent.RefreshPanel(new NavText(lBL_CALENDARID));
                StmtHit(7);
                base.Parent.RefreshPanel(new NavText(lBL_TIMEOFDAY));
                StmtHit(8);
                base.Parent.RefreshMenu(new NavText(lBL_FIXED));
            }
        }

        private void LogDebugJson(NavJsonObject json)
        {
            using (LogDebugJson_Scope__18312053 \u03b2scope = new LogDebugJson_Scope__18312053(this, json))
                \u03b2scope.Run();
        }

        [NavName("LogDebugJson")]
        [SignatureSpan(1274518780741943328L)]
        [SourceSpans(1275644629109440536L, 1275926104086216724L, 1276207574768025608L)]
        private sealed class LogDebugJson_Scope__18312053 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("json")]
            public NavJsonObject json;
            [NavName("t")]
            public NavText t = NavText.Default(0);
            protected override uint RawScopeId { get => LogDebugJson_Scope__18312053.\u03b1scopeId; set => LogDebugJson_Scope__18312053.\u03b1scopeId = value; }

            internal LogDebugJson_Scope__18312053(Codeunit10012739 \u03b2parent, NavJsonObject json) : base(\u03b2parent)
            {
                this.json = json;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.json.ALWriteTo(DataError.ThrowError, new ByRef<NavText>(() => this.t, setValue => this.t = setValue));
                StmtHit(1);
                base.Parent.LogDebug(this.t);
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void LogDebug(NavText message)
        {
            if (LogDebug_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (LogDebug_Scope \u03b2scope = new LogDebug_Scope(this, message))
                \u03b2scope.RunEvent();
        }

        [NavName("LogDebug")]
        [SignatureSpan(1286622204743319580L)]
        [SourceSpans(1287185098862297096L)]
        private sealed class LogDebug_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("message")]
            public NavText message;
            protected override uint RawScopeId { get => LogDebug_Scope.\u03b1scopeId; set => LogDebug_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => LogDebug_Scope.\u03b3eventScope; set => LogDebug_Scope.\u03b3eventScope = value; }

            internal LogDebug_Scope(Codeunit10012739 \u03b2parent, NavText message) : base(\u03b2parent)
            {
                this.message = message.ModifyLength(0);
            }
        }

        private void LogDeepTrace_1953297028(NavText message)
        {
            using (LogDeepTrace_Scope__1953297028 \u03b2scope = new LogDeepTrace_Scope__1953297028(this, message))
                \u03b2scope.Run();
        }

        [NavName("LogDeepTrace")]
        [SignatureSpan(1279022380370362400L)]
        [SourceSpans(1279585278784307235L, 1279866749466116104L)]
        private sealed class LogDeepTrace_Scope__1953297028 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("message")]
            public NavText message;
            protected override uint RawScopeId { get => LogDeepTrace_Scope__1953297028.\u03b1scopeId; set => LogDeepTrace_Scope__1953297028.\u03b1scopeId = value; }

            internal LogDeepTrace_Scope__1953297028(Codeunit10012739 \u03b2parent, NavText message) : base(\u03b2parent)
            {
                this.message = message.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.LogTrace(new NavText(" -- " + this.message));
            }
        }

        private void LogDeepTrace(NavJsonObject json)
        {
            using (LogDeepTrace_Scope__1956442834 \u03b2scope = new LogDeepTrace_Scope__1956442834(this, json))
                \u03b2scope.Run();
        }

        [NavName("LogDeepTrace")]
        [SignatureSpan(1276770580556152864L)]
        [SourceSpans(1277896428923650072L, 1278177903900426264L, 1278459374582235144L)]
        private sealed class LogDeepTrace_Scope__1956442834 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("json")]
            public NavJsonObject json;
            [NavName("t")]
            public NavText t = NavText.Default(0);
            protected override uint RawScopeId { get => LogDeepTrace_Scope__1956442834.\u03b1scopeId; set => LogDeepTrace_Scope__1956442834.\u03b1scopeId = value; }

            internal LogDeepTrace_Scope__1956442834(Codeunit10012739 \u03b2parent, NavJsonObject json) : base(\u03b2parent)
            {
                this.json = json;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.json.ALWriteTo(DataError.ThrowError, new ByRef<NavText>(() => this.t, setValue => this.t = setValue));
                StmtHit(1);
                base.Parent.LogDeepTrace_1953297028(this.t);
            }
        }

        private void LogEntities()
        {
            using (LogEntities_Scope__1980957169 \u03b2scope = new LogEntities_Scope__1980957169(this))
                \u03b2scope.Run();
        }

        [NavName("LogEntities")]
        [SignatureSpan(1171780414218633247L)]
        [SourceSpans(1172343325517479971L, 1172624804789223508L, 1172906279765999651L, 1173187767627677735L, 1173750739056066617L, 1174032222622777389L, 1174313654649880660L, 1174595129626656797L, 1175439550262018092L, 1175721029533761629L, 1176002504510537772L, 1176283992372215856L, 1176846963800604738L, 1177128447367315510L, 1177409879394418781L, 1177691354371194909L, 1178535775006556202L, 1178817254278299739L, 1179098729255075882L, 1179380217116753966L, 1179943188545142848L, 1180224672111853620L, 1180506104138956891L, 1180787579115733021L, 1181631999751094312L, 1181913479022837849L, 1182194953999613992L, 1182476441861292076L, 1183039413289680958L, 1183320896856391730L, 1183602328883495001L, 1183883803860271133L, 1184446732338987016L)]
        private sealed class LogEntities_Scope__1980957169 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => LogEntities_Scope__1980957169.\u03b1scopeId; set => LogEntities_Scope__1980957169.\u03b1scopeId = value; }

            internal LogEntities_Scope__1980957169(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__DeepTracePanelEntities))
                {
                    StmtHit(1);
                    base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("------ %1  ------", ALCompiler.ToNavValue(base.Parent._PanelEntities.Target.ALTableName))));
                    StmtHit(2);
                    base.Parent._PanelEntities.Target.ALReset();
                    if (CStmtHit(3) & (base.Parent._PanelEntities.Target.ALFind(DataError.TrapError, "-")))
                        do
                        {
                            StmtHit(4);
                            base.Parent.LogDeepTrace_1953297028(new NavText(NavFormatEvaluateHelper.Format(base.Parent._PanelEntities.Target)));
                        }
                        while (!(CStmtHit(5) & (base.Parent._PanelEntities.Target.ALNext() == 0)));
                    StmtHit(6);
                    base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("------ %1  ------", ALCompiler.ToNavValue(base.Parent._PanelEntities.Target.ALTableName))));
                    StmtHit(7);
                    base.Parent.LogDeepTrace_1953297028(new NavText(""));
                }

                if (CStmtHit(8) & (base.Parent.__DeepTracePanelRowColumnEntities))
                {
                    StmtHit(9);
                    base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("------ %1  ------", ALCompiler.ToNavValue(base.Parent._PanelRowColumnEntities.Target.ALTableName))));
                    StmtHit(10);
                    base.Parent._PanelRowColumnEntities.Target.ALReset();
                    if (CStmtHit(11) & (base.Parent._PanelRowColumnEntities.Target.ALFind(DataError.TrapError, "-")))
                        do
                        {
                            StmtHit(12);
                            base.Parent.LogDeepTrace_1953297028(new NavText(NavFormatEvaluateHelper.Format(base.Parent._PanelRowColumnEntities.Target)));
                        }
                        while (!(CStmtHit(13) & (base.Parent._PanelRowColumnEntities.Target.ALNext() == 0)));
                    StmtHit(14);
                    base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("------ %1  ------", ALCompiler.ToNavValue(base.Parent._PanelRowColumnEntities.Target.ALTableName))));
                    StmtHit(15);
                    base.Parent.LogDeepTrace_1953297028(new NavText(""));
                }

                if (CStmtHit(16) & (base.Parent.__DeepTracePanelControlEntities))
                {
                    StmtHit(17);
                    base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("------ %1  ------", ALCompiler.ToNavValue(base.Parent._PanelControlEntities.Target.ALTableName))));
                    StmtHit(18);
                    base.Parent._PanelControlEntities.Target.ALReset();
                    if (CStmtHit(19) & (base.Parent._PanelControlEntities.Target.ALFind(DataError.TrapError, "-")))
                        do
                        {
                            StmtHit(20);
                            base.Parent.LogDeepTrace_1953297028(new NavText(NavFormatEvaluateHelper.Format(base.Parent._PanelControlEntities.Target)));
                        }
                        while (!(CStmtHit(21) & (base.Parent._PanelControlEntities.Target.ALNext() == 0)));
                    StmtHit(22);
                    base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("------ %1  ------", ALCompiler.ToNavValue(base.Parent._PanelControlEntities.Target.ALTableName))));
                    StmtHit(23);
                    base.Parent.LogDeepTrace_1953297028(new NavText(""));
                }

                if (CStmtHit(24) & (base.Parent.__DeepTraceMenuButtonEntities))
                {
                    StmtHit(25);
                    base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("------ %1  ------", ALCompiler.ToNavValue(base.Parent._MenuButtonEntities.Target.ALTableName))));
                    StmtHit(26);
                    base.Parent._MenuButtonEntities.Target.ALReset();
                    if (CStmtHit(27) & (base.Parent._MenuButtonEntities.Target.ALFind(DataError.TrapError, "-")))
                        do
                        {
                            StmtHit(28);
                            base.Parent.LogDeepTrace_1953297028(new NavText(NavFormatEvaluateHelper.Format(base.Parent._MenuButtonEntities.Target)));
                        }
                        while (!(CStmtHit(29) & (base.Parent._MenuButtonEntities.Target.ALNext() == 0)));
                    StmtHit(30);
                    base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("------ %1  ------", ALCompiler.ToNavValue(base.Parent._MenuButtonEntities.Target.ALTableName))));
                    StmtHit(31);
                    base.Parent.LogDeepTrace_1953297028(new NavText(""));
                }
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void LogError(NavText message)
        {
            if (LogError_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (LogError_Scope \u03b2scope = new LogError_Scope(this, message))
                \u03b2scope.RunEvent();
        }

        [NavName("LogError")]
        [SignatureSpan(1289436954511081500L)]
        [SourceSpans(1289999848630059016L)]
        private sealed class LogError_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("message")]
            public NavText message;
            protected override uint RawScopeId { get => LogError_Scope.\u03b1scopeId; set => LogError_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => LogError_Scope.\u03b3eventScope; set => LogError_Scope.\u03b3eventScope = value; }

            internal LogError_Scope(Codeunit10012739 \u03b2parent, NavText message) : base(\u03b2parent)
            {
                this.message = message.ModifyLength(0);
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void LogTrace(NavText message)
        {
            if (LogTrace_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (LogTrace_Scope \u03b2scope = new LogTrace_Scope(this, message))
                \u03b2scope.RunEvent();
        }

        [NavName("LogTrace")]
        [SignatureSpan(1285214829859438620L)]
        [SourceSpans(1285777723978416136L)]
        private sealed class LogTrace_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("message")]
            public NavText message;
            protected override uint RawScopeId { get => LogTrace_Scope.\u03b1scopeId; set => LogTrace_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => LogTrace_Scope.\u03b3eventScope; set => LogTrace_Scope.\u03b3eventScope = value; }

            internal LogTrace_Scope(Codeunit10012739 \u03b2parent, NavText message) : base(\u03b2parent)
            {
                this.message = message.ModifyLength(0);
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void LogWarning(NavText message)
        {
            if (LogWarning_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (LogWarning_Scope \u03b2scope = new LogWarning_Scope(this, message))
                \u03b2scope.RunEvent();
        }

        [NavName("LogWarning")]
        [SignatureSpan(1288029579627200542L)]
        [SourceSpans(1288592473746178056L)]
        private sealed class LogWarning_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("message")]
            public NavText message;
            protected override uint RawScopeId { get => LogWarning_Scope.\u03b1scopeId; set => LogWarning_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => LogWarning_Scope.\u03b3eventScope; set => LogWarning_Scope.\u03b3eventScope = value; }

            internal LogWarning_Scope(Codeunit10012739 \u03b2parent, NavText message) : base(\u03b2parent)
            {
                this.message = message.ModifyLength(0);
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void MediaRequest(NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008958)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound)
        {
            if (MediaRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (MediaRequest_Scope \u03b2scope = new MediaRequest_Scope(this, pMainProfileID, pStoreProfileID, pControlID, pControlRec, pFound))
                \u03b2scope.RunEvent();
        }

        [NavName("MediaRequest")]
        [SignatureSpan(209698943597608992L)]
        [SourceSpans(210261837716586504L)]
        private sealed class MediaRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("pMainProfileID")]
            public NavText pMainProfileID;
            [NavName("pStoreProfileID")]
            public NavText pStoreProfileID;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pControlRec")]
            public INavRecordHandle pControlRec;
            [NavName("pFound")]
            public ByRef<bool> pFound;
            protected override uint RawScopeId { get => MediaRequest_Scope.\u03b1scopeId; set => MediaRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => MediaRequest_Scope.\u03b3eventScope; set => MediaRequest_Scope.\u03b3eventScope = value; }

            internal MediaRequest_Scope(Codeunit10012739 \u03b2parent, NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008958)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound) : base(\u03b2parent)
            {
                this.pMainProfileID = pMainProfileID.ModifyLength(0);
                this.pStoreProfileID = pStoreProfileID.ModifyLength(0);
                this.pControlID = pControlID.ModifyLength(0);
                this.pControlRec = pControlRec;
                this.pFound = pFound;
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void MenuButtonRequest(NavText pProfileID, NavText pMenuID, int pButtonNo, [NavObjectId(ObjectId = 99009054)][NavByReferenceAttribute] INavRecordHandle pMenuButtonsRec, ByRef<bool> pFound)
        {
            if (MenuButtonRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (MenuButtonRequest_Scope \u03b2scope = new MenuButtonRequest_Scope(this, pProfileID, pMenuID, pButtonNo, pMenuButtonsRec, pFound))
                \u03b2scope.RunEvent();
        }

        [NavName("MenuButtonRequest")]
        [SignatureSpan(155374273079803941L)]
        [SourceSpans(155937167198781448L)]
        private sealed class MenuButtonRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("pProfileID")]
            public NavText pProfileID;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pButtonNo")]
            public int pButtonNo;
            [NavName("pMenuButtonsRec")]
            public INavRecordHandle pMenuButtonsRec;
            [NavName("pFound")]
            public ByRef<bool> pFound;
            protected override uint RawScopeId { get => MenuButtonRequest_Scope.\u03b1scopeId; set => MenuButtonRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => MenuButtonRequest_Scope.\u03b3eventScope; set => MenuButtonRequest_Scope.\u03b3eventScope = value; }

            internal MenuButtonRequest_Scope(Codeunit10012739 \u03b2parent, NavText pProfileID, NavText pMenuID, int pButtonNo, [NavObjectId(ObjectId = 99009054)][NavByReferenceAttribute] INavRecordHandle pMenuButtonsRec, ByRef<bool> pFound) : base(\u03b2parent)
            {
                this.pProfileID = pProfileID.ModifyLength(0);
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pButtonNo = pButtonNo;
                this.pMenuButtonsRec = pMenuButtonsRec;
                this.pFound = pFound;
            }
        }

        private bool MenuLoaded(NavText pMenuID)
        {
            using (MenuLoaded_Scope_562367159 \u03b2scope = new MenuLoaded_Scope_562367159(this, pMenuID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("MenuLoaded")]
        [SignatureSpan(107523527027851294L)]
        [SourceSpans(108086425441796126L, 108367900418572341L, 108649375395348522L, 108930846077157384L)]
        private sealed class MenuLoaded_Scope_562367159 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            protected override uint RawScopeId { get => MenuLoaded_Scope_562367159.\u03b1scopeId; set => MenuLoaded_Scope_562367159.\u03b1scopeId = value; }

            internal MenuLoaded_Scope_562367159(Codeunit10012739 \u03b2parent, NavText pMenuID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.loadedMenusTemp.Target.ALReset();
                StmtHit(1);
                base.Parent.loadedMenusTemp.Target.ALSetRangeSafe(2, NavType.Code, this.pMenuID);
                StmtHit(2);
                this.\u03b3retVal = !base.Parent.loadedMenusTemp.Target.ALIsEmpty;
                return;
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void MenuRequest(NavText pMainProfileID, NavText pStoreProfileID, NavText pMenuID, [NavObjectId(ObjectId = 99009053)][NavByReferenceAttribute] INavRecordHandle pMenuRec, [NavObjectId(ObjectId = 99009054)][NavByReferenceAttribute] INavRecordHandle pMenuButtonsRec, bool pOverwrite, ByRef<bool> pFound)
        {
            if (MenuRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (MenuRequest_Scope \u03b2scope = new MenuRequest_Scope(this, pMainProfileID, pStoreProfileID, pMenuID, pMenuRec, pMenuButtonsRec, pOverwrite, pFound))
                \u03b2scope.RunEvent();
        }

        [NavName("MenuRequest")]
        [SignatureSpan(153966898195922975L)]
        [SourceSpans(154529792314900488L)]
        private sealed class MenuRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("pMainProfileID")]
            public NavText pMainProfileID;
            [NavName("pStoreProfileID")]
            public NavText pStoreProfileID;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pMenuRec")]
            public INavRecordHandle pMenuRec;
            [NavName("pMenuButtonsRec")]
            public INavRecordHandle pMenuButtonsRec;
            [NavName("pOverwrite")]
            public bool pOverwrite;
            [NavName("pFound")]
            public ByRef<bool> pFound;
            protected override uint RawScopeId { get => MenuRequest_Scope.\u03b1scopeId; set => MenuRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => MenuRequest_Scope.\u03b3eventScope; set => MenuRequest_Scope.\u03b3eventScope = value; }

            internal MenuRequest_Scope(Codeunit10012739 \u03b2parent, NavText pMainProfileID, NavText pStoreProfileID, NavText pMenuID, [NavObjectId(ObjectId = 99009053)][NavByReferenceAttribute] INavRecordHandle pMenuRec, [NavObjectId(ObjectId = 99009054)][NavByReferenceAttribute] INavRecordHandle pMenuButtonsRec, bool pOverwrite, ByRef<bool> pFound) : base(\u03b2parent)
            {
                this.pMainProfileID = pMainProfileID.ModifyLength(0);
                this.pStoreProfileID = pStoreProfileID.ModifyLength(0);
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pMenuRec = pMenuRec;
                this.pMenuButtonsRec = pMenuButtonsRec;
                this.pOverwrite = pOverwrite;
                this.pFound = pFound;
            }
        }

        private bool MgrKey()
        {
            using (MgrKey_Scope_688967636 \u03b2scope = new MgrKey_Scope_688967636(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("MgrKey")]
        [SignatureSpan(92605353258713114L)]
        [SourceSpans(93168251672657968L, 93449722354466824L)]
        private sealed class MgrKey_Scope_688967636 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            protected override uint RawScopeId { get => MgrKey_Scope_688967636.\u03b1scopeId; set => MgrKey_Scope_688967636.\u03b1scopeId = value; }

            internal MgrKey_Scope_688967636(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.GetValue(new NavText("mgrkey")) == NavFormatEvaluateHelper.Format(ALCompiler.ToNavValue(true));
                return;
            }
        }

        private void MoveJsonValues(NavJsonObject fromObj, NavJsonObject toObj)
        {
            using (MoveJsonValues_Scope__1096614589 \u03b2scope = new MoveJsonValues_Scope__1096614589(this, fromObj, toObj))
                \u03b2scope.Run();
        }

        [NavName("MoveJsonValues")]
        [SignatureSpan(1115766893840171042L)]
        [SourceSpans(1117455692161220635L, 1117737167138390028L, 1118018672179544097L, 1118300164336189480L, 1118581643607932964L, 1119144593561485353L, 1119426016998653963L, 1119707487680462856L)]
        private sealed class MoveJsonValues_Scope__1096614589 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("fromObj")]
            public NavJsonObject fromObj;
            [NavName("toObj")]
            public NavJsonObject toObj;
            [NavName("ks")]
            public NavList<NavText> ks = NavList<NavText>.Default;
            [NavName("k")]
            public NavText k = NavText.Default(0);
            [NavName("v")]
            public NavText v = NavText.Default(0);
            [NavName("jt")]
            public NavJsonToken jt;
            protected override uint RawScopeId { get => MoveJsonValues_Scope__1096614589.\u03b1scopeId; set => MoveJsonValues_Scope__1096614589.\u03b1scopeId = value; }

            internal MoveJsonValues_Scope__1096614589(Codeunit10012739 \u03b2parent, NavJsonObject fromObj, NavJsonObject toObj) : base(\u03b2parent)
            {
                this.fromObj = fromObj;
                this.toObj = toObj;
                this.ks = NavList<NavText>.Default;
                this.jt = NavJsonToken.Default;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.ks = this.fromObj.ALKeys;
                StmtHit(1);
                foreach (var @tmp0 in this.ks)
                {
                    this.k = @tmp0;
                    {
                        if (CStmtHit(2) & (this.fromObj.ALGet(DataError.TrapError, this.k, new ByRef<NavJsonToken>(() => this.jt, setValue => this.jt = setValue))))
                            if (CStmtHit(3) & (!this.toObj.ALContains(this.k)))
                            {
                                CStmtHit(4);
                                this.toObj.ALAdd(DataError.ThrowError, this.k, this.jt);
                            }
                            else
                            {
                                StmtHit(5);
                                this.toObj.ALReplace(DataError.ThrowError, this.k, this.jt);
                            }
                    }
                }

                StmtHit(6);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 477313505")]
        public void Navigate(NavCode pControlID, NavText pURL)
        {
            using (Navigate_Scope_1048526931 \u03b2scope = new Navigate_Scope_1048526931(this, pControlID, pURL))
                \u03b2scope.Run();
        }

        [NavName("Navigate")]
        [SignatureSpan(1049338773551185942L)]
        [SourceSpans(1049901710619836441L, 1050183189891579975L, 1050746122665263184L, 1051027593347072008L)]
        private sealed class Navigate_Scope_1048526931 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pURL")]
            public NavText pURL;
            protected override uint RawScopeId { get => Navigate_Scope_1048526931.\u03b1scopeId; set => Navigate_Scope_1048526931.\u03b1scopeId = value; }

            internal Navigate_Scope_1048526931(Codeunit10012739 \u03b2parent, NavCode pControlID, NavText pURL) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pURL = pURL.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("Navigate(%1, %2)", this.pControlID, this.pURL)));
                }

                StmtHit(2);
                base.Parent.SendPOSCommandEvent(new NavText("NAVIGATE"), new NavText(ALSystemString.ALStrSubstNo("[%1]%2", this.pControlID, this.pURL)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2191027818")]
        public void Next(NavCode pControlID)
        {
            using (Next_Scope_872094116 \u03b2scope = new Next_Scope_872094116(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("Next")]
        [SignatureSpan(1044835173922766866L)]
        [SourceSpans(1045398110991417369L, 1045679590263160889L, 1046242523036844100L, 1046523993718652936L)]
        private sealed class Next_Scope_872094116 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            protected override uint RawScopeId { get => Next_Scope_872094116.\u03b1scopeId; set => Next_Scope_872094116.\u03b1scopeId = value; }

            internal Next_Scope_872094116(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("Next(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SendPOSCommandEvent(new NavText("NEXT"), new NavText(ALSystemString.ALStrSubstNo("[%1]", this.pControlID)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3903073231")]
        public void NoStandardPanels(bool newValue)
        {
            using (NoStandardPanels_Scope__1763699926 \u03b2scope = new NoStandardPanels_Scope__1763699926(this, newValue))
                \u03b2scope.Run();
        }

        [NavName("NoStandardPanels")]
        [SignatureSpan(320881533654401054L)]
        [SourceSpans(321444470723051545L, 321725949994795075L, 322288882768478243L, 322570353450287112L)]
        private sealed class NoStandardPanels_Scope__1763699926 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("newValue")]
            public bool newValue;
            protected override uint RawScopeId { get => NoStandardPanels_Scope__1763699926.\u03b1scopeId; set => NoStandardPanels_Scope__1763699926.\u03b1scopeId = value; }

            internal NoStandardPanels_Scope__1763699926(Codeunit10012739 \u03b2parent, bool newValue) : base(\u03b2parent)
            {
                this.newValue = newValue;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("NoStandardPanels(%1)", ALCompiler.ToNavValue(this.newValue))));
                }

                StmtHit(2);
                base.Parent._NO_STD_PANELS = this.newValue;
            }
        }

        private void OnPOSEvent([NavObjectId(ObjectId = 10012741)] NavCodeunitHandle pPosEvent)
        {
            using (OnPOSEvent_Scope_1267763311 \u03b2scope = new OnPOSEvent_Scope_1267763311(this, pPosEvent))
                \u03b2scope.Run();
        }

        [NavName("OnPOSEvent")]
        [SignatureSpan(470626247069138974L)]
        [SourceSpans(471189158367985684L, 471470637639729192L, 472033583298314265L, 472315062570057800L, 472878008228642849L, 473159487500386358L, 473440941002326024L)]
        private sealed class OnPOSEvent_Scope_1267763311 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPosEvent")]
            public NavCodeunitHandle pPosEvent;
            protected override uint RawScopeId { get => OnPOSEvent_Scope_1267763311.\u03b1scopeId; set => OnPOSEvent_Scope_1267763311.\u03b1scopeId = value; }

            internal OnPOSEvent_Scope_1267763311(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 10012741)] NavCodeunitHandle pPosEvent) : base(\u03b2parent)
            {
                this.pPosEvent = pPosEvent.ALByValue(this);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent._dualDisp))
                {
                    StmtHit(1);
                    this.pPosEvent.Target.Invoke(224998679, new object[] { -999999999 });
                }

                if (CStmtHit(2) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(3);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("OnPOSEvent(%1)", ALCompiler.ObjectToExactNavValue<NavOption>(this.pPosEvent.Target.Invoke(1553536834, Array.Empty<object>())))));
                }

                if (CStmtHit(4) & (base.Parent._ControllerInitialized))
                {
                    StmtHit(5);
                    base.Parent._ActiveController.Target.InvokeInterfaceMethod("ProcessEvent", -508129505, new object[] { this.pPosEvent });
                }
            }
        }

        private bool PanelLoaded(NavText pPanelID)
        {
            using (PanelLoaded_Scope_1490433432 \u03b2scope = new PanelLoaded_Scope_1490433432(this, pPanelID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("PanelLoaded")]
        [SignatureSpan(113434501540151327L)]
        [SourceSpans(113997399954096159L, 114278874930872375L, 114560349907648555L, 114841820589457416L)]
        private sealed class PanelLoaded_Scope_1490433432 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            protected override uint RawScopeId { get => PanelLoaded_Scope_1490433432.\u03b1scopeId; set => PanelLoaded_Scope_1490433432.\u03b1scopeId = value; }

            internal PanelLoaded_Scope_1490433432(Codeunit10012739 \u03b2parent, NavText pPanelID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.loadedPanelsTemp.Target.ALReset();
                StmtHit(1);
                base.Parent.loadedPanelsTemp.Target.ALSetRangeSafe(2, NavType.Code, this.pPanelID);
                StmtHit(2);
                this.\u03b3retVal = !base.Parent.loadedPanelsTemp.Target.ALIsEmpty;
                return;
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void PanelRequest(NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008880)][NavByReferenceAttribute] INavRecordHandle pPanelRec, [NavObjectId(ObjectId = 99008873)][NavByReferenceAttribute] INavRecordHandle pPanelRowColumns, [NavObjectId(ObjectId = 99008874)][NavByReferenceAttribute] INavRecordHandle pPanelControls, ByRef<bool> found)
        {
            if (PanelRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (PanelRequest_Scope \u03b2scope = new PanelRequest_Scope(this, pMainProfileID, pStoreProfileID, pControlID, pPanelRec, pPanelRowColumns, pPanelControls, found))
                \u03b2scope.RunEvent();
        }

        [NavName("PanelRequest")]
        [SignatureSpan(166351797174075424L)]
        [SourceSpans(166914691293052936L)]
        private sealed class PanelRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("pMainProfileID")]
            public NavText pMainProfileID;
            [NavName("pStoreProfileID")]
            public NavText pStoreProfileID;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pPanelRec")]
            public INavRecordHandle pPanelRec;
            [NavName("pPanelRowColumns")]
            public INavRecordHandle pPanelRowColumns;
            [NavName("pPanelControls")]
            public INavRecordHandle pPanelControls;
            [NavName("found")]
            public ByRef<bool> found;
            protected override uint RawScopeId { get => PanelRequest_Scope.\u03b1scopeId; set => PanelRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => PanelRequest_Scope.\u03b3eventScope; set => PanelRequest_Scope.\u03b3eventScope = value; }

            internal PanelRequest_Scope(Codeunit10012739 \u03b2parent, NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008880)][NavByReferenceAttribute] INavRecordHandle pPanelRec, [NavObjectId(ObjectId = 99008873)][NavByReferenceAttribute] INavRecordHandle pPanelRowColumns, [NavObjectId(ObjectId = 99008874)][NavByReferenceAttribute] INavRecordHandle pPanelControls, ByRef<bool> found) : base(\u03b2parent)
            {
                this.pMainProfileID = pMainProfileID.ModifyLength(0);
                this.pStoreProfileID = pStoreProfileID.ModifyLength(0);
                this.pControlID = pControlID.ModifyLength(0);
                this.pPanelRec = pPanelRec;
                this.pPanelRowColumns = pPanelRowColumns;
                this.pPanelControls = pPanelControls;
                this.found = found;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3450114977")]
        public void Pause(NavCode pControlID)
        {
            using (Pause_Scope__1826597639 \u03b2scope = new Pause_Scope__1826597639(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("Pause")]
        [SignatureSpan(1040331574294347795L)]
        [SourceSpans(1040894511362998297L, 1041175990634741818L, 1041738923408425029L, 1042020394090233864L)]
        private sealed class Pause_Scope__1826597639 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            protected override uint RawScopeId { get => Pause_Scope__1826597639.\u03b1scopeId; set => Pause_Scope__1826597639.\u03b1scopeId = value; }

            internal Pause_Scope__1826597639(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("Pause(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SendPOSCommandEvent(new NavText("PAUSE"), new NavText(ALSystemString.ALStrSubstNo("[%1]", this.pControlID)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 532503165")]
        public void PlayURL(NavCode pControlID, NavText pURL)
        {
            using (PlayURL_Scope_1199016765 \u03b2scope = new PlayURL_Scope_1199016765(this, pControlID, pURL))
                \u03b2scope.Run();
        }

        [NavName("PlayURL")]
        [SignatureSpan(1031324375037509653L)]
        [SourceSpans(1032168774198034465L, 1032450249174810698L, 1032731719856619528L)]
        private sealed class PlayURL_Scope_1199016765 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pURL")]
            public NavText pURL;
            protected override uint RawScopeId { get => PlayURL_Scope_1199016765.\u03b1scopeId; set => PlayURL_Scope_1199016765.\u03b1scopeId = value; }

            internal PlayURL_Scope_1199016765(Codeunit10012739 \u03b2parent, NavCode pControlID, NavText pURL) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pURL = pURL.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.Playlist(this.pControlID, new NavCode(20, ""));
                StmtHit(1);
                base.Parent.SetPosImageUrl(NavOption.Create(NCLEnumMetadata.Create(99008881), 6), new NavText(this.pControlID), this.pURL);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3856344927")]
        public void Play(NavCode pControlID)
        {
            using (Play_Scope_377842909 \u03b2scope = new Play_Scope_377842909(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("Play")]
        [SignatureSpan(1029917000153628690L)]
        [SourceSpans(1030479924337377348L, 1030761395019186184L)]
        private sealed class Play_Scope_377842909 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            protected override uint RawScopeId { get => Play_Scope_377842909.\u03b1scopeId; set => Play_Scope_377842909.\u03b1scopeId = value; }

            internal Play_Scope_377842909(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.SendPOSCommandEvent(new NavText("PLAY"), new NavText(ALSystemString.ALStrSubstNo("[%1]", this.pControlID)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2265745303")]
        public void Playlist(NavCode pControlID, NavCode pPlaylistID)
        {
            using (Playlist_Scope__556047278 \u03b2scope = new Playlist_Scope__556047278(this, pControlID, pPlaylistID))
                \u03b2scope.Run();
        }

        [NavName("Playlist")]
        [SignatureSpan(1033294699874942998L)]
        [SourceSpans(1034139111920369689L, 1034420591192113230L, 1034983523965796487L, 1035264994647605256L)]
        private sealed class Playlist_Scope__556047278 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pPlaylistID")]
            public NavCode pPlaylistID;
            protected override uint RawScopeId { get => Playlist_Scope__556047278.\u03b1scopeId; set => Playlist_Scope__556047278.\u03b1scopeId = value; }

            internal Playlist_Scope__556047278(Codeunit10012739 \u03b2parent, NavCode pControlID, NavCode pPlaylistID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pPlaylistID = pPlaylistID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("Playlist(%1, %2)", this.pControlID, this.pPlaylistID)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 6), new NavText(this.pControlID), new NavText(base.Parent._MediaEntities.Target.ALFieldName(5)), new NavText(this.pPlaylistID) });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2916750170")]
        public bool PopMenu(NavCode pButtonPadID)
        {
            using (PopMenu_Scope__1992903705 \u03b2scope = new PopMenu_Scope__1992903705(this, pButtonPadID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("PopMenu")]
        [SignatureSpan(779967220776370197L)]
        [SourceSpans(781374582775349273L, 781656062047092798L, 782218994820775999L, 782500482682454047L, 782781961954197528L, 783063419751104544L, 783344894727880740L, 783907844681433161L, 784189319658209299L, 784470790340018184L)]
        private sealed class PopMenu_Scope__1992903705 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pButtonPadID")]
            public NavCode pButtonPadID;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("menuStack")]
            public NavCodeunitHandle menuStack;
            [NavName("menu")]
            public NavText menu = NavText.Default(0);
            protected override uint RawScopeId { get => PopMenu_Scope__1992903705.\u03b1scopeId; set => PopMenu_Scope__1992903705.\u03b1scopeId = value; }

            internal PopMenu_Scope__1992903705(Codeunit10012739 \u03b2parent, NavCode pButtonPadID) : base(\u03b2parent)
            {
                this.pButtonPadID = pButtonPadID.ModifyLength(20);
                this.menuStack = new NavCodeunitHandle(this, 10012738);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("PopMenu(%1)", this.pButtonPadID)));
                }

                StmtHit(2);
                this.menuStack.Target.Invoke(1091980582, new object[] { base.Parent.GetButtonPadMenuList(this.pButtonPadID) });
                if (CStmtHit(3) & (((int)ALCompiler.ObjectToInt32(this.menuStack.Target.Invoke(1991726454, Array.Empty<object>()))) <= 1))
                {
                    StmtHit(4);
                    this.\u03b3retVal = false;
                    return;
                }

                StmtHit(5);
                this.menu = ALCompiler.ObjectToExactNavValue<NavText>(this.menuStack.Target.Invoke(-760389506, Array.Empty<object>()));
                StmtHit(6);
                base.Parent.SetMenuVisible(this.menu, false);
                StmtHit(7);
                base.Parent.UpdateMenuPosition(base.Parent.GetButtonPadMenu(this.pButtonPadID), new NavText(this.pButtonPadID));
                StmtHit(8);
                this.\u03b3retVal = true;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 476065578")]
        public void PopupGridData(NavCode pDataGridID, NavJsonObject pDataJson, NavCode pInputID, int pHeight, bool pHideColumnHeader)
        {
            using (PopupGridData_Scope__1188390463 \u03b2scope = new PopupGridData_Scope__1188390463(this, pDataGridID, pDataJson, pInputID, pHeight, pHideColumnHeader))
                \u03b2scope.Run();
        }

        [NavName("PopupGridData")]
        [SignatureSpan(924082408885780507L)]
        [SourceSpans(925208295907983397L, 925489775179726886L, 926052725133279260L, 926334182930186360L, 926615657906962570L, 926897132883738719L, 927178607860514964L, 927460082837291147L, 927741557814067259L, 928023032790843431L, 928304503472652296L)]
        private sealed class PopupGridData_Scope__1188390463 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pDataGridID")]
            public NavCode pDataGridID;
            [NavName("pDataJson")]
            public NavJsonObject pDataJson;
            [NavName("pInputID")]
            public NavCode pInputID;
            [NavName("pHeight")]
            public int pHeight;
            [NavName("pHideColumnHeader")]
            public bool pHideColumnHeader;
            [NavName("panelID")]
            public static readonly NavTextConstant panelID = new NavTextConstant(new int[] { 1033 }, new string[] { "##POPUPGRIDCONTAINER" }, null, null);
            protected override uint RawScopeId { get => PopupGridData_Scope__1188390463.\u03b1scopeId; set => PopupGridData_Scope__1188390463.\u03b1scopeId = value; }

            internal PopupGridData_Scope__1188390463(Codeunit10012739 \u03b2parent, NavCode pDataGridID, NavJsonObject pDataJson, NavCode pInputID, int pHeight, bool pHideColumnHeader) : base(\u03b2parent)
            {
                this.pDataGridID = pDataGridID.ModifyLength(20);
                this.pDataJson = pDataJson;
                this.pInputID = pInputID.ModifyLength(20);
                this.pHeight = pHeight;
                this.pHideColumnHeader = pHideColumnHeader;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!base.Parent.ContainsPanel(new NavText(panelID))))
                {
                    StmtHit(1);
                    base.Parent.CreatePanel(new NavText(panelID), 1, 1);
                }
                else
                {
                    StmtHit(2);
                    base.Parent.HidePopupGrid();
                }

                StmtHit(3);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2), new NavText(panelID), new NavText(base.Parent._SHARED.Target.ALFieldName(20)), new NavText(this.pInputID) });
                StmtHit(4);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2), new NavText(panelID), new NavText(base.Parent._PanelEntities.Target.ALFieldName(11)), this.pHeight });
                StmtHit(5);
                base.Parent.SetControlPosition_1520947238(NavOption.Create(NCLEnumMetadata.Create(99008881), 3), new NavText(this.pDataGridID), new NavText(panelID), 1, 1, 1, 1);
                StmtHit(6);
                base.Parent._CONTROLS.Target.Invoke(-1410208911, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pDataGridID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(32)), this.pHideColumnHeader });
                StmtHit(7);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pDataGridID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(5)), new NavText(panelID) });
                StmtHit(8);
                base.Parent.AddGridDataSet(this.pDataGridID, new NavText(panelID), this.pDataJson, 0);
                StmtHit(9);
                base.Parent.SetActiveDataGrid(new NavText(this.pDataGridID));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3725901595")]
        public void PopupMenu(NavText pMenuID)
        {
            using (PopupMenu_Scope_609288950 \u03b2scope = new PopupMenu_Scope_609288950(this, pMenuID))
                \u03b2scope.Run();
        }

        [NavName("PopupMenu")]
        [SignatureSpan(796292769429389335L)]
        [SourceSpans(796855693613137953L, 797137164294946824L)]
        private sealed class PopupMenu_Scope_609288950 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            protected override uint RawScopeId { get => PopupMenu_Scope_609288950.\u03b1scopeId; set => PopupMenu_Scope_609288950.\u03b1scopeId = value; }

            internal PopupMenu_Scope_609288950(Codeunit10012739 \u03b2parent, NavText pMenuID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.PopupMenu_126275962(this.pMenuID, 0, 0);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 646091031")]
        public void PopupMenu_126275962(NavText pMenuID, int pWidthPX, int pHeightPX)
        {
            using (PopupMenu_Scope__126275962 \u03b2scope = new PopupMenu_Scope__126275962(this, pMenuID, pWidthPX, pHeightPX))
                \u03b2scope.Run();
        }

        [NavName("PopupMenu")]
        [SignatureSpan(797700144313270295L)]
        [SourceSpans(799388981289025561L, 799670460560769112L, 800233406219354143L, 800514885491097617L, 801077831149682736L, 801359310421426235L, 802203731056787512L, 802485210328531002L, 802766685305307265L, 803611093055766582L, 803892568032542781L, 804174043009318941L, 804455513691127816L)]
        private sealed class PopupMenu_Scope__126275962 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pWidthPX")]
            public int pWidthPX;
            [NavName("pHeightPX")]
            public int pHeightPX;
            [NavName("width")]
            public int width = default(int);
            [NavName("height")]
            public int height = default(int);
            [NavName("txt_mgrKeyRequired")]
            public static readonly NavTextConstant txt_mgrKeyRequired = new NavTextConstant(new int[] { 1033 }, new string[] { "Menu [%1] requires manager key." }, "Codeunit 2892615804", "Codeunit 2892615804 - Method 1486306019 - NamedType 2155365587");
            protected override uint RawScopeId { get => PopupMenu_Scope__126275962.\u03b1scopeId; set => PopupMenu_Scope__126275962.\u03b1scopeId = value; }

            internal PopupMenu_Scope__126275962(Codeunit10012739 \u03b2parent, NavText pMenuID, int pWidthPX, int pHeightPX) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pWidthPX = pWidthPX;
                this.pHeightPX = pHeightPX;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("PopupMenu(%1, %2, %3)", this.pMenuID, ALCompiler.ToNavValue(this.pWidthPX), ALCompiler.ToNavValue(this.pHeightPX))));
                }

                if (CStmtHit(2) & (!base.Parent.GetMenu(this.pMenuID)))
                {
                    StmtHit(3);
                    return;
                }

                if (CStmtHit(4) & (base.Parent._MenuEntities.Target.GetFieldValueSafe(105, NavType.Boolean).ToBoolean() & (!base.Parent.MgrKey())))
                {
                    StmtHit(5);
                    NavDialog.ALError(Guid.Parse("8da61efd-0002-0003-0507-0b0d1113171d"), ALSystemString.ALStrSubstNo(txt_mgrKeyRequired, this.pMenuID));
                }

                if (CStmtHit(6) & (!base.Parent.ContainsPanel(new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 5)))))))
                {
                    StmtHit(7);
                    base.Parent.CreatePanel(new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 5)))), 1, 1);
                    StmtHit(8);
                    base.Parent.ShowControl(new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 5)))), 1, 1, 1, 1, NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 0), new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 5)))));
                }

                StmtHit(9);
                base.Parent.ShowMenu(new NavCode(20, this.pMenuID), new NavCode(20, NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 5)))));
                StmtHit(10);
                base.Parent.modalPanelStack.Target.Invoke(1257355291, new object[] { new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 5)))), new NavText("") });
                StmtHit(11);
                base.Parent.ResumeCurrentPanel();
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2945518759")]
        public bool PosIsActive()
        {
            using (PosIsActive_Scope_1111124075 \u03b2scope = new PosIsActive_Scope_1111124075(this))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("PosIsActive")]
        [SignatureSpan(551972489587654681L)]
        [SourceSpans(552535413771403295L, 552816884453212168L)]
        private sealed class PosIsActive_Scope_1111124075 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            protected override uint RawScopeId { get => PosIsActive_Scope_1111124075.\u03b1scopeId; set => PosIsActive_Scope_1111124075.\u03b1scopeId = value; }

            internal PosIsActive_Scope_1111124075(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.GetInitialized();
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1965549831")]
        public void PosMessageBanner(NavText msg, int level, int timeout)
        {
            using (PosMessageBanner_Scope__120667136 \u03b2scope = new PosMessageBanner_Scope__120667136(this, msg, level, timeout))
                \u03b2scope.Run();
        }

        [NavName("PosMessageBanner")]
        [SignatureSpan(1280429729484439582L)]
        [SourceSpans(1281555603621740563L, 1281837078598516757L, 1282118553575292951L, 1282400028552069184L, 1282681499233878024L)]
        private sealed class PosMessageBanner_Scope__120667136 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("Msg")]
            public NavText msg;
            [NavName("Level")]
            public int level;
            [NavName("Timeout")]
            public int timeout;
            [NavName("j")]
            public NavJsonArray j;
            protected override uint RawScopeId { get => PosMessageBanner_Scope__120667136.\u03b1scopeId; set => PosMessageBanner_Scope__120667136.\u03b1scopeId = value; }

            internal PosMessageBanner_Scope__120667136(Codeunit10012739 \u03b2parent, NavText msg, int level, int timeout) : base(\u03b2parent)
            {
                this.msg = msg.ModifyLength(0);
                this.level = level;
                this.timeout = timeout;
                this.j = NavJsonArray.Default;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.j.ALAdd(this.msg);
                StmtHit(1);
                this.j.ALAdd(this.level);
                StmtHit(2);
                this.j.ALAdd(this.timeout);
                StmtHit(3);
                base.Parent.PostEvent(new NavText("RUNCOMMAND"), new NavText("_SHOW_MESSAGE"), new NavText(NavFormatEvaluateHelper.Format(this.j)), new NavText(""));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3137049235")]
        public void PostEvent(NavText pValue1, NavText pValue2, NavText pValue3, NavText pValue4)
        {
            using (PostEvent_Scope_459504990 \u03b2scope = new PostEvent_Scope_459504990(this, pValue1, pValue2, pValue3, pValue4))
                \u03b2scope.Run();
        }

        [NavName("PostEvent")]
        [SignatureSpan(1213720159988482071L)]
        [SourceSpans(1214283097057132577L, 1214564576328876082L, 1214846029830815752L)]
        private sealed class PostEvent_Scope_459504990 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pValue1")]
            public NavText pValue1;
            [NavName("pValue2")]
            public NavText pValue2;
            [NavName("pValue3")]
            public NavText pValue3;
            [NavName("pValue4")]
            public NavText pValue4;
            protected override uint RawScopeId { get => PostEvent_Scope_459504990.\u03b1scopeId; set => PostEvent_Scope_459504990.\u03b1scopeId = value; }

            internal PostEvent_Scope_459504990(Codeunit10012739 \u03b2parent, NavText pValue1, NavText pValue2, NavText pValue3, NavText pValue4) : base(\u03b2parent)
            {
                this.pValue1 = pValue1.ModifyLength(0);
                this.pValue2 = pValue2.ModifyLength(0);
                this.pValue3 = pValue3.ModifyLength(0);
                this.pValue4 = pValue4.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.pValue1 == "RUNCOMMAND"))
                {
                    StmtHit(1);
                    base.Parent.SendPOSCommandEvent(this.pValue2, this.pValue3);
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3032874726")]
        public bool PreProcessEvent([NavObjectId(ObjectId = 10012741)][NavByReferenceAttribute] NavCodeunitHandle pPOSEvent)
        {
            using (PreProcessEvent_Scope_1867638575 \u03b2scope = new PreProcessEvent_Scope_1867638575(this, pPOSEvent))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("PreProcessEvent")]
        [SignatureSpan(327073983143477277L)]
        [SourceSpans(332140519840546841L, 332421999112290344L, 332984931885973539L, 333547881839525933L, 336362644492189784L, 336644123763933225L, 336925598740709428L, 337207086602387485L, 337488565874131000L, 337770023673135120L, 338051515827683369L, 338332990804459570L, 338895940758011950L, 339177415734788151L, 339458890711564334L, 339740378573242412L, 340021857844985909L, 340584807798538273L, 340866265595445294L, 341429215550177300L, 341992199862288454L, 343681079787716651L, 343962571944362058L, 344244051216105534L, 344806983989788759L, 345651374560378950L, 346214324513931362L, 346777222927876111L, 347340172882149392L, 348184649351364723L, 348466124328140915L, 349592024235245684L, 349873499212021877L, 351280822556295210L, 351562297533071413L, 351843785394749469L, 352125264666492985L, 352969685301854236L, 353251164573597744L, 353814110232182810L, 354095589503926300L, 354939997256155152L, 355784473724321875L, 356910386516328517L, 357191865788071986L, 357473340764848193L, 357754828626526309L, 358036307898269740L, 358599223492083792L, 359725136284090437L, 360006615555833906L, 360288090532610113L, 360569578394288229L, 360851057666031660L, 361413973259845687L, 361695448236621873L, 361976923213398104L, 363102750106058760L)]
        private sealed class PreProcessEvent_Scope_1867638575 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPOSEvent")]
            public NavCodeunitHandle pPOSEvent;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("eventType")]
            public NavOption eventType = NavOption.Create(NCLEnumMetadata.Create(10012741), 0);
            [NavName("sender")]
            public NavText sender = NavText.Default(0);
            [NavName("i")]
            public int i = default(int);
            [NavName("v")]
            public NavVariant v;
            [NavName("currType")]
            public int currType = default(int);
            [NavName("currID")]
            public NavText currID = NavText.Default(0);
            [NavName("lMenuID")]
            public NavText lMenuID = NavText.Default(0);
            [NavName("lGrid")]
            public INavRecordHandle lGrid;
            [NavName("splitText")]
            public NavList<NavText> splitText = NavList<NavText>.Default;
            [NavName("posEventItemType")]
            public NavOption posEventItemType = NavOption.Create(NCLEnumMetadata.Create(99008885), 0);
            [NavName("ctrlDataArr")]
            public NavJsonArray ctrlDataArr;
            [NavName("ctrlDataEntity")]
            public NavJsonObject ctrlDataEntity;
            [NavName("jTok")]
            public NavJsonToken jTok;
            [NavName("updateJournal")]
            public bool updateJournal = default(bool);
            protected override uint RawScopeId { get => PreProcessEvent_Scope_1867638575.\u03b1scopeId; set => PreProcessEvent_Scope_1867638575.\u03b1scopeId = value; }

            internal PreProcessEvent_Scope_1867638575(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 10012741)][NavByReferenceAttribute] NavCodeunitHandle pPOSEvent) : base(\u03b2parent)
            {
                this.pPOSEvent = pPOSEvent;
                this.v = NavVariant.Default(this);
                this.lGrid = new NavRecordHandle(this, 99008876, false, SecurityFiltering.Validated);
                this.splitText = NavList<NavText>.Default;
                this.ctrlDataArr = NavJsonArray.Default;
                this.ctrlDataEntity = NavJsonObject.Default;
                this.jTok = NavJsonToken.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("PreProcessEvent"));
                }

                StmtHit(2);
                this.sender = ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(-586392693, Array.Empty<object>()));
                StmtHit(3);
                this.pPOSEvent.Target.Invoke(1101439803, new object[] { base.Parent.ActivePanelID() });
                if (CStmtHit(4) & ((ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(126936087, Array.Empty<object>())) != "") & this.ctrlDataArr.ALReadFrom(DataError.TrapError, ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(126936087, Array.Empty<object>())))))
                {
                    StmtHit(5);
                    base.Parent._ignoreModifications = true;
                    StmtHit(6);
                    base.Parent._CONTROLS.Target.Invoke(-1263557647, new object[] { true });
                    if (CStmtHit(7) & (base.Parent.__LogLevel > 3))
                    {
                        StmtHit(8);
                        base.Parent.LogTrace(new NavText("---> IgnoreModifications ON"));
                    }

                    this.i = 0;
                    StmtHit(9);
                    int @tmp0 = this.ctrlDataArr.ALCount - 1;
                    for (; this.i <= @tmp0;)
                    {
                        {
                            CStmtHit(10);
                            this.ctrlDataArr.ALGet(DataError.ThrowError, this.i, new ByRef<NavJsonToken>(() => this.jTok, setValue => this.jTok = setValue));
                            StmtHit(11);
                            this.ctrlDataEntity = this.jTok.ALAsObject();
                            StmtHit(12);
                            this.ctrlDataEntity.ALGet(DataError.ThrowError, "T", new ByRef<NavJsonToken>(() => this.jTok, setValue => this.jTok = setValue));
                            StmtHit(13);
                            this.currType = this.jTok.ALAsValue().ALAsInteger();
                            StmtHit(14);
                            this.ctrlDataEntity.ALGet(DataError.ThrowError, "I", new ByRef<NavJsonToken>(() => this.jTok, setValue => this.jTok = setValue));
                            if (CStmtHit(15) & (!this.jTok.ALAsValue().ALIsNull))
                            {
                                StmtHit(16);
                                this.currID = this.jTok.ALAsValue().ALAsText();
                            }
                            else
                            {
                                StmtHit(17);
                                this.currID = new NavText("");
                            }

                            StmtHit(18);
                            this.ctrlDataEntity.ALGet(DataError.ThrowError, "V", new ByRef<NavJsonToken>(() => this.jTok, setValue => this.jTok = setValue));
                            StmtHit(19);
                            int @tmp2 = this.currType;
                            if ((@tmp2 == NavOption.Create(this.posEventItemType.NavOptionMetadata, 1).ToInt32()))
                            {
                                {
                                    StmtHit(20);
                                    base.Parent.SetInputText(this.currID, this.jTok.ALAsValue().ALAsText());
                                }

                                goto @tmp1;
                            }

                            if ((@tmp2 == NavOption.Create(this.posEventItemType.NavOptionMetadata, 2).ToInt32()))
                            {
                                {
                                    if (CStmtHit(21) & (this.jTok.ALIsValue))
                                    {
                                        if (CStmtHit(22) & (this.jTok.ALAsValue().ALAsText() == "###activedg"))
                                        {
                                            StmtHit(23);
                                            base.Parent.SetActiveDataGrid(this.currID);
                                        }
                                    }
                                    else
                                    {
                                        StmtHit(24);
                                        this.updateJournal = base.Parent.SyncGridData(this.currID, this.jTok.ALAsObject());
                                    }
                                }

                                goto @tmp1;
                            }

                            if ((@tmp2 == NavOption.Create(this.posEventItemType.NavOptionMetadata, 3).ToInt32()))
                            {
                                {
                                    StmtHit(25);
                                    base.Parent.SyncZoomData(this.currID, this.jTok.ALAsValue().ALAsText());
                                }

                                goto @tmp1;
                            }

                            if ((@tmp2 == NavOption.Create(this.posEventItemType.NavOptionMetadata, 4).ToInt32()))
                            {
                                {
                                    StmtHit(26);
                                    base.Parent.SetMainControlValue_1893130901(new NavText(base.Parent._POS.Target.ALFieldName(20)), this.jTok.ALAsValue().ALAsText());
                                }

                                goto @tmp1;
                            }

                            @tmp1:
                                ;
                        }

                        if (this.i >= @tmp0)
                            break;
                        this.i = this.i + 1;
                    }

                    StmtHit(27);
                    StmtHit(28);
                    NavOption @tmp4 = ALCompiler.ObjectToExactNavValue<NavOption>(this.pPOSEvent.Target.Invoke(1553536834, Array.Empty<object>()));
                    if ((@tmp4.CompareTo(NavOption.Create(this.eventType.NavOptionMetadata, 18)) == 0))
                    {
                        {
                            StmtHit(29);
                            base.Parent.SyncButtonModification(this.pPOSEvent, new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(653)), ((int)ALCompiler.ObjectToInt32(this.pPOSEvent.Target.Invoke(237886395, Array.Empty<object>()))));
                            StmtHit(30);
                            base.Parent.SyncButtonModification(this.pPOSEvent, new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(654)), ((int)ALCompiler.ObjectToInt32(this.pPOSEvent.Target.Invoke(-195321010, Array.Empty<object>()))));
                        }

                        goto @tmp3;
                    }

                    if ((@tmp4.CompareTo(NavOption.Create(this.eventType.NavOptionMetadata, 19)) == 0))
                    {
                        {
                            StmtHit(31);
                            base.Parent.SyncButtonModification(this.pPOSEvent, new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(655)), ((int)ALCompiler.ObjectToInt32(this.pPOSEvent.Target.Invoke(237886395, Array.Empty<object>()))));
                            StmtHit(32);
                            base.Parent.SyncButtonModification(this.pPOSEvent, new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(656)), ((int)ALCompiler.ObjectToInt32(this.pPOSEvent.Target.Invoke(-195321010, Array.Empty<object>()))));
                        }

                        goto @tmp3;
                    }

                    @tmp3:
                        ;
                    StmtHit(33);
                    base.Parent._ignoreModifications = false;
                    StmtHit(34);
                    base.Parent._CONTROLS.Target.Invoke(-1263557647, new object[] { false });
                    if (CStmtHit(35) & (base.Parent.__LogLevel > 3))
                    {
                        StmtHit(36);
                        base.Parent.LogTrace(new NavText("<--- IgnoreModifications OFF"));
                    }

                    if (CStmtHit(37) & (this.updateJournal))
                    {
                        StmtHit(38);
                        base.Parent.UpdateSelectedJournalLine(true);
                    }

                    if (CStmtHit(39) & (this.sender == ""))
                    {
                        StmtHit(40);
                        this.\u03b3retVal = false;
                        return;
                    }

                    StmtHit(41);
                    NavOption @tmp6 = ALCompiler.ObjectToExactNavValue<NavOption>(this.pPOSEvent.Target.Invoke(1553536834, Array.Empty<object>()));
                    if ((@tmp6.CompareTo(NavOption.Create(this.eventType.NavOptionMetadata, 15)) == 0))
                    {
                        {
                            StmtHit(42);
                            this.pPOSEvent.Target.Invoke(1845809118, new object[] { base.Parent.GetRecordZoomDataXML(ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(-586392693, Array.Empty<object>()))) });
                        }

                        goto @tmp5;
                    }

                    if ((@tmp6.CompareTo(NavOption.Create(this.eventType.NavOptionMetadata, 9)) == 0))
                    {
                        {
                            if (CStmtHit(43) & (base.Parent.ActivePanelID() == NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 5)))))
                            {
                                StmtHit(44);
                                base.Parent.HideActivePanel(true);
                                StmtHit(45);
                                this.pPOSEvent.Target.Invoke(1101439803, new object[] { base.Parent.ActivePanelID() });
                                if (CStmtHit(46) & ((ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(-436090315, Array.Empty<object>())) == "CANCEL") & (ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(-166923495, Array.Empty<object>())) == "Escape")))
                                {
                                    StmtHit(47);
                                    this.\u03b3retVal = false;
                                    return;
                                }
                            }

                            StmtHit(48);
                            this.\u03b3retVal = base.Parent.RunCommand(ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(-436090315, Array.Empty<object>())), ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(-166923495, Array.Empty<object>())));
                            return;
                        }

                        goto @tmp5;
                    }

                    if ((@tmp6.CompareTo(NavOption.Create(this.eventType.NavOptionMetadata, 0)) == 0))
                    {
                        {
                            if (CStmtHit(49) & (base.Parent.ActivePanelID() == NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 5)))))
                            {
                                StmtHit(50);
                                base.Parent.HideActivePanel(true);
                                StmtHit(51);
                                this.pPOSEvent.Target.Invoke(1101439803, new object[] { base.Parent.ActivePanelID() });
                                if (CStmtHit(52) & ((ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(-436090315, Array.Empty<object>())) == "CANCEL") & (ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(-166923495, Array.Empty<object>())) == "Escape")))
                                {
                                    StmtHit(53);
                                    this.\u03b3retVal = false;
                                    return;
                                }
                            }

                            StmtHit(54);
                            this.splitText = NavTextExtensions.ALSplit(this.sender, new NavText(","));
                            StmtHit(55);
                            this.splitText.ALGet(DataError.ThrowError, 3, new ByRef<NavText>(() => this.currID, setValue => this.currID = setValue));
                            StmtHit(56);
                            this.\u03b3retVal = base.Parent.RunCommand_49859252(this.currID, ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(-436090315, Array.Empty<object>())), ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(-166923495, Array.Empty<object>())));
                            return;
                        }

                        goto @tmp5;
                    }

                    @tmp5:
                        ;
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2373632670")]
        public void Previous(NavCode pControlID)
        {
            using (Previous_Scope__2129759905 \u03b2scope = new Previous_Scope__2129759905(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("Previous")]
        [SignatureSpan(1047086973736976406L)]
        [SourceSpans(1047649910805626905L, 1047931390077370429L, 1048494322851053636L, 1048775793532862472L)]
        private sealed class Previous_Scope__2129759905 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            protected override uint RawScopeId { get => Previous_Scope__2129759905.\u03b1scopeId; set => Previous_Scope__2129759905.\u03b1scopeId = value; }

            internal Previous_Scope__2129759905(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("Previous(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SendPOSCommandEvent(new NavText("PREV"), new NavText(ALSystemString.ALStrSubstNo("[%1]", this.pControlID)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3224543494")]
        public bool ProcessEvent([NavObjectId(ObjectId = 10012741)][NavByReferenceAttribute] NavCodeunitHandle pPosEvent)
        {
            using (ProcessEvent_Scope__508129505 \u03b2scope = new ProcessEvent_Scope__508129505(this, pPosEvent))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("ProcessEvent")]
        [SignatureSpan(1260726481110106138L)]
        [SourceSpans(1261289418178756674L, 1261570910335402014L, 1261852389607145510L, 1262696775882768392L)]
        private sealed class ProcessEvent_Scope__508129505 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPosEvent")]
            public NavCodeunitHandle pPosEvent;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            protected override uint RawScopeId { get => ProcessEvent_Scope__508129505.\u03b1scopeId; set => ProcessEvent_Scope__508129505.\u03b1scopeId = value; }

            internal ProcessEvent_Scope__508129505(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 10012741)][NavByReferenceAttribute] NavCodeunitHandle pPosEvent) : base(\u03b2parent)
            {
                this.pPosEvent = pPosEvent;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (ALCompiler.ObjectToExactNavValue<NavOption>(this.pPosEvent.Target.Invoke(1553536834, Array.Empty<object>())) == NavOption.Create(NCLEnumMetadata.Create(10012741), 2)))
                {
                    if (CStmtHit(1) & (base.Parent.IsDualDisplay()))
                    {
                        StmtHit(2);
                        base.Parent.ResetControlLibrary();
                    }
                }
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void RecordZoomRequest(NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008878)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound)
        {
            if (RecordZoomRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (RecordZoomRequest_Scope \u03b2scope = new RecordZoomRequest_Scope(this, pMainProfileID, pStoreProfileID, pControlID, pControlRec, pFound))
                \u03b2scope.RunEvent();
        }

        [NavName("RecordZoomRequest")]
        [SignatureSpan(196188144712351781L)]
        [SourceSpans(196751038831329288L)]
        private sealed class RecordZoomRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("pMainProfileID")]
            public NavText pMainProfileID;
            [NavName("pStoreProfileID")]
            public NavText pStoreProfileID;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pControlRec")]
            public INavRecordHandle pControlRec;
            [NavName("pFound")]
            public ByRef<bool> pFound;
            protected override uint RawScopeId { get => RecordZoomRequest_Scope.\u03b1scopeId; set => RecordZoomRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => RecordZoomRequest_Scope.\u03b3eventScope; set => RecordZoomRequest_Scope.\u03b3eventScope = value; }

            internal RecordZoomRequest_Scope(Codeunit10012739 \u03b2parent, NavText pMainProfileID, NavText pStoreProfileID, NavText pControlID, [NavObjectId(ObjectId = 99008878)][NavByReferenceAttribute] INavRecordHandle pControlRec, ByRef<bool> pFound) : base(\u03b2parent)
            {
                this.pMainProfileID = pMainProfileID.ModifyLength(0);
                this.pStoreProfileID = pStoreProfileID.ModifyLength(0);
                this.pControlID = pControlID.ModifyLength(0);
                this.pControlRec = pControlRec;
                this.pFound = pFound;
            }
        }

        private void RefreshControlRuntimeProperties(NavOption pControlType, NavText pControlID, bool pDelete)
        {
            using (RefreshControlRuntimeProperties_Scope_975322604 \u03b2scope = new RefreshControlRuntimeProperties_Scope_975322604(this, pControlType, pControlID, pDelete))
                \u03b2scope.Run();
        }

        [NavName("RefreshControlRuntimeProperties")]
        [SignatureSpan(573083138615672883L)]
        [SourceSpans(574490461959946281L, 574771936936722457L, 575053411913498682L, 575334886890274867L, 575616374751952929L, 575897866908598294L, 576179346180341798L, 576742296133894224L, 577305207432740872L)]
        private sealed class RefreshControlRuntimeProperties_Scope_975322604 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pDelete")]
            public bool pDelete;
            [NavName("l_CONTROLS")]
            public INavRecordHandle l_CONTROLS;
            protected override uint RawScopeId { get => RefreshControlRuntimeProperties_Scope_975322604.\u03b1scopeId; set => RefreshControlRuntimeProperties_Scope_975322604.\u03b1scopeId = value; }

            internal RefreshControlRuntimeProperties_Scope_975322604(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID, bool pDelete) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
                this.pDelete = pDelete;
                this.l_CONTROLS = new NavRecordHandle(this, 99001760, false, SecurityFiltering.Validated);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.l_CONTROLS.Target.ALCopy(base.Parent._CONTROLS.Target, true);
                StmtHit(1);
                this.l_CONTROLS.Target.ALReset();
                StmtHit(2);
                this.l_CONTROLS.Target.ALSetRangeSafe(2, NavType.Option, this.pControlType);
                StmtHit(3);
                this.l_CONTROLS.Target.ALSetRangeSafe(4, NavType.Code, this.pControlID);
                if (CStmtHit(4) & (!this.l_CONTROLS.Target.ALIsEmpty))
                {
                    if (CStmtHit(5) & (this.pDelete))
                    {
                        StmtHit(6);
                        this.l_CONTROLS.Target.ALDeleteAll();
                    }
                    else
                    {
                        StmtHit(7);
                        this.l_CONTROLS.Target.ALModifyAllSafe(50, NavType.DateTime, ALCompiler.ObjectToExactNavValue<NavDateTime>(base.Parent._CONTROLS.Target.Invoke(717507646, Array.Empty<object>())));
                    }
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2773163296")]
        public void RefreshControl(NavOption pControlType, NavText pControlID, bool pRemoveEntities)
        {
            using (RefreshControl_Scope_1838628398 \u03b2scope = new RefreshControl_Scope_1838628398(this, pControlType, pControlID, pRemoveEntities))
                \u03b2scope.Run();
        }

        [NavName("RefreshControl")]
        [SignatureSpan(564075913589030940L)]
        [SourceSpans(564920312749555785L, 565201783431364616L)]
        private sealed class RefreshControl_Scope_1838628398 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pRemoveEntities")]
            public bool pRemoveEntities;
            protected override uint RawScopeId { get => RefreshControl_Scope_1838628398.\u03b1scopeId; set => RefreshControl_Scope_1838628398.\u03b1scopeId = value; }

            internal RefreshControl_Scope_1838628398(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID, bool pRemoveEntities) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
                this.pRemoveEntities = pRemoveEntities;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.RefreshControl_617729402(this.pControlType, this.pControlID, this.pRemoveEntities, false);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3146022745")]
        public void RefreshControl_617729402(NavOption pControlType, NavText pControlID, bool pRemoveEntities, bool pRemoveRuntimeProperties)
        {
            using (RefreshControl_Scope__617729402 \u03b2scope = new RefreshControl_Scope__617729402(this, pControlType, pControlID, pRemoveEntities, pRemoveRuntimeProperties))
                \u03b2scope.Run();
        }

        [NavName("RefreshControl")]
        [SignatureSpan(565764763449688092L)]
        [SourceSpans(567735075402219545L, 568016554673963093L, 568579487447646316L, 568860962424422442L, 569142437401198640L, 569705400239652890L, 569986879511396412L, 570549812285079644L, 571112762238632042L, 571394237215408256L, 571675725077086233L, 571957204348829814L, 572520132827545608L)]
        private sealed class RefreshControl_Scope__617729402 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pRemoveEntities")]
            public bool pRemoveEntities;
            [NavName("pRemoveRuntimeProperties")]
            public bool pRemoveRuntimeProperties;
            [NavName("position")]
            public NavText position = NavText.Default(0);
            [NavName("parent")]
            public NavText parent = NavText.Default(0);
            protected override uint RawScopeId { get => RefreshControl_Scope__617729402.\u03b1scopeId; set => RefreshControl_Scope__617729402.\u03b1scopeId = value; }

            internal RefreshControl_Scope__617729402(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID, bool pRemoveEntities, bool pRemoveRuntimeProperties) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
                this.pRemoveEntities = pRemoveEntities;
                this.pRemoveRuntimeProperties = pRemoveRuntimeProperties;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("RefreshControl(%1, %2)", this.pControlType, this.pControlID)));
                }

                StmtHit(2);
                this.position = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent._CONTROLS.Target.Invoke(-1790301861, new object[] { this.pControlType, this.pControlID, new NavText(base.Parent._SHARED.Target.ALFieldName(20)) }));
                StmtHit(3);
                this.parent = new NavText(((NavCode)base.Parent._CONTROLS.Target.GetFieldValueSafe(20, NavType.Code)));
                StmtHit(4);
                base.Parent.UnloadControl(this.pControlType, this.pControlID);
                if (CStmtHit(5) & (this.pRemoveEntities))
                {
                    StmtHit(6);
                    base.Parent.RemoveControlEntities(this.pControlType, this.pControlID);
                }

                StmtHit(7);
                base.Parent.RefreshControlRuntimeProperties(this.pControlType, this.pControlID, this.pRemoveRuntimeProperties);
                StmtHit(8);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { this.pControlType, this.pControlID, new NavText(base.Parent._SHARED.Target.ALFieldName(5)), -1 });
                StmtHit(9);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { this.pControlType, this.pControlID, new NavText(base.Parent._SHARED.Target.ALFieldName(5)), this.pControlType.ToInt32() });
                if (CStmtHit(10) & (this.position != ""))
                {
                    StmtHit(11);
                    base.Parent._CONTROLS.Target.Invoke(-204461422, new object[] { this.pControlType, this.pControlID, new NavText(base.Parent._SHARED.Target.ALFieldName(20)), this.position, this.parent });
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2240546006")]
        public void RefreshDataGrid(NavText pControlID)
        {
            using (RefreshDataGrid_Scope__346089654 \u03b2scope = new RefreshDataGrid_Scope__346089654(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("RefreshDataGrid")]
        [SignatureSpan(900719985813356573L)]
        [SourceSpans(901282922882007065L, 901564402153750596L, 902127334927433798L, 902408805609242632L)]
        private sealed class RefreshDataGrid_Scope__346089654 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            protected override uint RawScopeId { get => RefreshDataGrid_Scope__346089654.\u03b1scopeId; set => RefreshDataGrid_Scope__346089654.\u03b1scopeId = value; }

            internal RefreshDataGrid_Scope__346089654(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("RefreshDataGrid(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SendPOSCommandEvent(new NavText("RESET"), new NavText(ALSystemString.ALStrSubstNo("[%1]1", this.pControlID)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 83082165")]
        public void RefreshInputControl(NavCode pControlID)
        {
            using (RefreshInputControl_Scope__1727542824 \u03b2scope = new RefreshInputControl_Scope__1727542824(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("RefreshInputControl")]
        [SignatureSpan(825847641990889505L)]
        [SourceSpans(826410566174638152L, 826692036856446984L)]
        private sealed class RefreshInputControl_Scope__1727542824 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            protected override uint RawScopeId { get => RefreshInputControl_Scope__1727542824.\u03b1scopeId; set => RefreshInputControl_Scope__1727542824.\u03b1scopeId = value; }

            internal RefreshInputControl_Scope__1727542824(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.RefreshControl(NavOption.Create(NCLEnumMetadata.Create(99008881), 1), new NavText(this.pControlID), true);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1962942910")]
        public void RefreshInterfaceProfile()
        {
            using (RefreshInterfaceProfile_Scope__1960114225 \u03b2scope = new RefreshInterfaceProfile_Scope__1960114225(this))
                \u03b2scope.Run();
        }

        [NavName("RefreshInterfaceProfile")]
        [SignatureSpan(1002332452429561893L)]
        [SourceSpans(1003458339451764761L, 1003739818723508274L, 1004865701450743841L, 1005147176427520059L, 1005428664289198115L, 1005991648602488916L, 1006273127874232397L, 1006836060647915695L, 1007117548509593685L, 1007399027781337163L, 1007680502758113324L, 1007961977734889625L, 1008243452711665860L, 1008806394075283499L, 1009932251032715297L, 1014717338522812446L, 1014998817794555941L, 1015280292771332129L, 1015843221250048008L)]
        private sealed class RefreshInterfaceProfile_Scope__1960114225 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("found")]
            public bool found = default(bool);
            protected override uint RawScopeId { get => RefreshInterfaceProfile_Scope__1960114225.\u03b1scopeId; set => RefreshInterfaceProfile_Scope__1960114225.\u03b1scopeId = value; }

            internal RefreshInterfaceProfile_Scope__1960114225(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("RefreshInterfaceProfile()"));
                }

                StmtHit(2);
                base.Parent.loadedPanelsTemp.Target.ALReset();
                StmtHit(3);
                base.Parent.loadedPanelsTemp.Target.ALSetRangeSafe(1000, NavType.Boolean, ALCompiler.ToNavValue(false));
                if (CStmtHit(4) & (base.Parent.loadedPanelsTemp.Target.ALFindSet(DataError.TrapError)))
                {
                    do
                    {
                        if (CStmtHit(5) & (!base.Parent.panelNeedsControlRefresh.ALContains(new NavText(((NavCode)base.Parent.loadedPanelsTemp.Target.GetFieldValueSafe(2, NavType.Code))))))
                        {
                            StmtHit(6);
                            base.Parent.panelNeedsControlRefresh.ALAdd(new NavText(((NavCode)base.Parent.loadedPanelsTemp.Target.GetFieldValueSafe(2, NavType.Code))));
                        }

                        StmtHit(7);
                        base.Parent.PanelRequest(base.Parent._InterfaceProfileID, base.Parent._StoreInterfaceProfileID, new NavText(((NavCode)base.Parent.loadedPanelsTemp.Target.GetFieldValueSafe(2, NavType.Code))), base.Parent._PanelEntities, base.Parent._PanelRowColumnEntities, base.Parent._PanelControlEntities, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                        if (CStmtHit(8) & (this.found & (((NavCode)base.Parent.loadedPanelsTemp.Target.GetFieldValueSafe(1010, NavType.Code)) != ((NavCode)base.Parent._PanelEntities.Target.GetFieldValueSafe(1010, NavType.Code)))))
                        {
                            StmtHit(9);
                            base.Parent.loadedPanelsTemp.Target.SetFieldValueSafe(1010, NavType.Code, ((NavCode)base.Parent._PanelEntities.Target.GetFieldValueSafe(1010, NavType.Code)));
                            StmtHit(10);
                            base.Parent.loadedPanelsTemp.Target.ALModify(DataError.ThrowError);
                            StmtHit(11);
                            base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2), new NavText(((NavCode)base.Parent.loadedPanelsTemp.Target.GetFieldValueSafe(2, NavType.Code))), new NavText(base.Parent._SHARED.Target.ALFieldName(5)), -1 });
                            StmtHit(12);
                            base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2), new NavText(((NavCode)base.Parent.loadedPanelsTemp.Target.GetFieldValueSafe(2, NavType.Code))), new NavText(base.Parent._SHARED.Target.ALFieldName(5)), ((NavOption)base.Parent.loadedControlsTemp.Target.GetFieldValueSafe(2, NavType.Option)).ToInt32() });
                        }
                    }
                    while (!(CStmtHit(13) & (base.Parent.loadedPanelsTemp.Target.ALNext() == 0)));
                }

                StmtHit(14);
                base.Parent.loadedPanelsTemp.Target.ALReset();
                if (CStmtHit(15) & (base.Parent.ActivePanelID() != ""))
                {
                    StmtHit(16);
                    base.Parent.LoadPanel(base.Parent.ActivePanelID());
                    StmtHit(17);
                    base.Parent.ResumeCurrentPanel();
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1314521703")]
        public void RefreshMenuButton_267048875(NavCode pMenuID, int pButtonNo, bool pRemoveRuntimeProperties)
        {
            using (RefreshMenuButton_Scope_267048875 \u03b2scope = new RefreshMenuButton_Scope_267048875(this, pMenuID, pButtonNo, pRemoveRuntimeProperties))
                \u03b2scope.Run();
        }

        [NavName("RefreshMenuButton")]
        [SignatureSpan(741405148958031903L)]
        [SourceSpans(742812510957010968L, 743093990228754449L, 743375460910563353L, 743656940182306928L, 744219872955990094L, 744782822909542441L, 745064297886318617L, 745345772863094864L, 745627247839871028L, 745908735701549089L, 746190227858194471L, 746471707129937958L, 747034657083490384L, 747879047654080585L, 748160522630922292L, 748723472584474722L, 749286418242994184L)]
        private sealed class RefreshMenuButton_Scope_267048875 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [NavName("pButtonNo")]
            public int pButtonNo;
            [NavName("pRemoveRuntimeProperties")]
            public bool pRemoveRuntimeProperties;
            [NavName("l_CONTROLS")]
            public INavRecordHandle l_CONTROLS;
            [NavName("l_ControlID")]
            public NavText l_ControlID = NavText.Default(0);
            protected override uint RawScopeId { get => RefreshMenuButton_Scope_267048875.\u03b1scopeId; set => RefreshMenuButton_Scope_267048875.\u03b1scopeId = value; }

            internal RefreshMenuButton_Scope_267048875(Codeunit10012739 \u03b2parent, NavCode pMenuID, int pButtonNo, bool pRemoveRuntimeProperties) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
                this.pButtonNo = pButtonNo;
                this.pRemoveRuntimeProperties = pRemoveRuntimeProperties;
                this.l_CONTROLS = new NavRecordHandle(this, 99001760, false, SecurityFiltering.Validated);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.pButtonNo < 0))
                {
                    StmtHit(1);
                    return;
                }

                if (CStmtHit(2) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(3);
                    base.Parent.LogTrace(new NavText(ALSystemString.ALStrSubstNo("RefreshMenuButton(%1, %2, %3)", this.pMenuID, ALCompiler.ToNavValue(this.pButtonNo), ALCompiler.ToNavValue(this.pRemoveRuntimeProperties))));
                }

                StmtHit(4);
                this.l_ControlID = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.pMenuID), this.pButtonNo }));
                StmtHit(5);
                this.l_CONTROLS.Target.ALCopy(base.Parent._CONTROLS.Target, true);
                StmtHit(6);
                this.l_CONTROLS.Target.ALReset();
                StmtHit(7);
                this.l_CONTROLS.Target.ALSetRangeSafe(2, NavType.Option, NavOption.Create(NCLEnumMetadata.Create(99008881), 8));
                StmtHit(8);
                this.l_CONTROLS.Target.ALSetRangeSafe(4, NavType.Code, this.l_ControlID);
                if (CStmtHit(9) & (!this.l_CONTROLS.Target.ALIsEmpty))
                {
                    if (CStmtHit(10) & (this.pRemoveRuntimeProperties))
                    {
                        StmtHit(11);
                        this.l_CONTROLS.Target.ALDeleteAll();
                    }
                    else
                    {
                        StmtHit(12);
                        this.l_CONTROLS.Target.ALModifyAllSafe(50, NavType.DateTime, ALCompiler.ObjectToExactNavValue<NavDateTime>(base.Parent._CONTROLS.Target.Invoke(717507646, Array.Empty<object>())));
                    }
                }

                StmtHit(13);
                base.Parent.UnloadControl(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), this.l_ControlID);
                StmtHit(14);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), this.l_ControlID, new NavText(base.Parent._SHARED.Target.ALFieldName(5)), -1 });
                StmtHit(15);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), this.l_ControlID, new NavText(base.Parent._SHARED.Target.ALFieldName(5)), NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8).ToInt32() });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 228740763")]
        public void RefreshMenuButton(NavCode pMenuID, int pButtonNo)
        {
            using (RefreshMenuButton_Scope__1622512140 \u03b2scope = new RefreshMenuButton_Scope__1622512140(this, pMenuID, pButtonNo))
                \u03b2scope.Run();
        }

        [NavName("RefreshMenuButton")]
        [SignatureSpan(739997774074150943L)]
        [SourceSpans(740560698257899573L, 740842168939708424L)]
        private sealed class RefreshMenuButton_Scope__1622512140 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [NavName("pButtonNo")]
            public int pButtonNo;
            protected override uint RawScopeId { get => RefreshMenuButton_Scope__1622512140.\u03b1scopeId; set => RefreshMenuButton_Scope__1622512140.\u03b1scopeId = value; }

            internal RefreshMenuButton_Scope__1622512140(Codeunit10012739 \u03b2parent, NavCode pMenuID, int pButtonNo) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
                this.pButtonNo = pButtonNo;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.RefreshMenuButton_267048875(this.pMenuID, this.pButtonNo, false);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2004303644")]
        public void RefreshMenuButtons([NavObjectId(ObjectId = 99009053)][NavByReferenceAttribute] INavRecordHandle pMenuEntity)
        {
            using (RefreshMenuButtons_Scope__993781415 \u03b2scope = new RefreshMenuButtons_Scope__993781415(this, pMenuEntity))
                \u03b2scope.Run();
        }

        [NavName("RefreshMenuButtons")]
        [SignatureSpan(730990574817312800L)]
        [SourceSpans(732397923931389995L, 732679398908559372L, 734086790971916346L, 734368248768823307L, 734649719450632200L)]
        private sealed class RefreshMenuButtons_Scope__993781415 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuEntity")]
            public INavRecordHandle pMenuEntity;
            [NavName("i")]
            public int i = default(int);
            [NavName("n")]
            public int n = default(int);
            protected override uint RawScopeId { get => RefreshMenuButtons_Scope__993781415.\u03b1scopeId; set => RefreshMenuButtons_Scope__993781415.\u03b1scopeId = value; }

            internal RefreshMenuButtons_Scope__993781415(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99009053)][NavByReferenceAttribute] INavRecordHandle pMenuEntity) : base(\u03b2parent)
            {
                this.pMenuEntity = pMenuEntity;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.n = base.Parent.GetNrOfButtons(base.Parent._MenuEntities);
                this.i = 1;
                StmtHit(1);
                int @tmp0 = this.n;
                for (; this.i <= @tmp0;)
                {
                    {
                        CStmtHit(2);
                        base.Parent.RefreshMenuButton(((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(1, NavType.Code)), this.i);
                    }

                    if (this.i >= @tmp0)
                        break;
                    this.i = this.i + 1;
                }

                StmtHit(3);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2206586937")]
        public void RefreshMenuProfile()
        {
            using (RefreshMenuProfile_Scope__1292026512 \u03b2scope = new RefreshMenuProfile_Scope__1292026512(this))
                \u03b2scope.Run();
        }

        [NavName("RefreshMenuProfile")]
        [SignatureSpan(992480828242395168L)]
        [SourceSpans(993606715264598041L, 993888194536341620L, 994451127310024736L, 994732602286800954L, 995014090148479010L, 995577061576867982L, 995858549438546003L, 996140028710289530L, 996421503687065673L, 996702978663841835L, 996984453640618135L, 997265928617394367L, 997547403594170422L, 998110344957788202L, 998673247666700296L)]
        private sealed class RefreshMenuProfile_Scope__1292026512 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("found")]
            public bool found = default(bool);
            protected override uint RawScopeId { get => RefreshMenuProfile_Scope__1292026512.\u03b1scopeId; set => RefreshMenuProfile_Scope__1292026512.\u03b1scopeId = value; }

            internal RefreshMenuProfile_Scope__1292026512(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo(" ---- RefreshMenuProfile [%1] - [%2] -----", base.Parent._MenuProfileID, base.Parent._StoreMenuProfileID)));
                }

                StmtHit(2);
                base.Parent.loadedMenusTemp.Target.ALReset();
                StmtHit(3);
                base.Parent.loadedMenusTemp.Target.ALSetRangeSafe(1000, NavType.Boolean, ALCompiler.ToNavValue(false));
                if (CStmtHit(4) & (base.Parent.loadedMenusTemp.Target.ALFindSet(DataError.TrapError)))
                {
                    do
                    {
                        StmtHit(5);
                        base.Parent.MenuRequest(base.Parent._MenuProfileID, base.Parent._StoreMenuProfileID, new NavText(((NavCode)base.Parent.loadedMenusTemp.Target.GetFieldValueSafe(2, NavType.Code))), base.Parent._MenuEntities, base.Parent._MenuButtonEntities, false, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                        if (CStmtHit(6) & (this.found & (((NavCode)base.Parent.loadedMenusTemp.Target.GetFieldValueSafe(1010, NavType.Code)) != ((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(10, NavType.Code)))))
                        {
                            StmtHit(7);
                            base.Parent.HideExtraButtons(new NavText(((NavCode)base.Parent.loadedMenusTemp.Target.GetFieldValueSafe(1010, NavType.Code))), new NavText(((NavCode)base.Parent.loadedMenusTemp.Target.GetFieldValueSafe(2, NavType.Code))), base.Parent.GetNrOfButtons(base.Parent._MenuEntities));
                            StmtHit(8);
                            base.Parent.loadedMenusTemp.Target.SetFieldValueSafe(1010, NavType.Code, new NavCode(10, ((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(10, NavType.Code))));
                            StmtHit(9);
                            base.Parent.loadedMenusTemp.Target.ALModify(DataError.ThrowError);
                            StmtHit(10);
                            base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), new NavText(((NavCode)base.Parent.loadedMenusTemp.Target.GetFieldValueSafe(2, NavType.Code))), new NavText(base.Parent._SHARED.Target.ALFieldName(5)), -1 });
                            StmtHit(11);
                            base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), new NavText(((NavCode)base.Parent.loadedMenusTemp.Target.GetFieldValueSafe(2, NavType.Code))), new NavText(base.Parent._SHARED.Target.ALFieldName(5)), NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7).ToInt32() });
                            StmtHit(12);
                            base.Parent.RefreshMenuButtons(base.Parent._MenuEntities);
                        }
                    }
                    while (!(CStmtHit(13) & (base.Parent.loadedMenusTemp.Target.ALNext() == 0)));
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1319140996")]
        public void RefreshMenu(NavText pMenuID)
        {
            using (RefreshMenu_Scope_1697532027 \u03b2scope = new RefreshMenu_Scope_1697532027(this, pMenuID))
                \u03b2scope.Run();
        }

        [NavName("RefreshMenu")]
        [SignatureSpan(722546325514027033L)]
        [SourceSpans(723109249697775651L, 723390720379584520L)]
        private sealed class RefreshMenu_Scope_1697532027 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            protected override uint RawScopeId { get => RefreshMenu_Scope_1697532027.\u03b1scopeId; set => RefreshMenu_Scope_1697532027.\u03b1scopeId = value; }

            internal RefreshMenu_Scope_1697532027(Codeunit10012739 \u03b2parent, NavText pMenuID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.RefreshMenu_1500321386(this.pMenuID, true);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 66452384")]
        public void RefreshMenu_1500321386(NavText pMenuID, bool pRefreshMenuButtons)
        {
            using (RefreshMenu_Scope__1500321386 \u03b2scope = new RefreshMenu_Scope__1500321386(this, pMenuID, pRefreshMenuButtons))
                \u03b2scope.Run();
        }

        [NavName("RefreshMenu")]
        [SignatureSpan(723953700397907993L)]
        [SourceSpans(725079587420110873L, 725361066691854422L, 725924012350439447L, 726205491622182929L, 726768424395866144L, 727049899372642358L, 727331374349418532L, 727894324302970957L, 728457287141425186L, 728738766413168657L, 729301712071753759L, 729583191343497233L, 730146124117180458L, 730427594798989320L)]
        private sealed class RefreshMenu_Scope__1500321386 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pRefreshMenuButtons")]
            public bool pRefreshMenuButtons;
            [NavName("i")]
            public int i = default(int);
            protected override uint RawScopeId { get => RefreshMenu_Scope__1500321386.\u03b1scopeId; set => RefreshMenu_Scope__1500321386.\u03b1scopeId = value; }

            internal RefreshMenu_Scope__1500321386(Codeunit10012739 \u03b2parent, NavText pMenuID, bool pRefreshMenuButtons) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pRefreshMenuButtons = pRefreshMenuButtons;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("RefreshMenu(%1, %2)", this.pMenuID, ALCompiler.ToNavValue(this.pRefreshMenuButtons))));
                }

                if (CStmtHit(2) & (this.pMenuID == ""))
                {
                    StmtHit(3);
                    return;
                }

                StmtHit(4);
                base.Parent.loadedMenusTemp.Target.ALReset();
                StmtHit(5);
                base.Parent.loadedMenusTemp.Target.ALSetFilter(2, this.pMenuID);
                StmtHit(6);
                base.Parent.loadedMenusTemp.Target.ALDeleteAll();
                StmtHit(7);
                base.Parent.RefreshControl_617729402(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), this.pMenuID, false, true);
                if (CStmtHit(8) & (!this.pRefreshMenuButtons))
                {
                    StmtHit(9);
                    return;
                }

                if (CStmtHit(10) & (!base.Parent.GetMenu(this.pMenuID)))
                {
                    StmtHit(11);
                    return;
                }

                StmtHit(12);
                base.Parent.RefreshMenuButtons(base.Parent._MenuEntities);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3348468944")]
        public void RefreshPanel(NavText pPanelID)
        {
            using (RefreshPanel_Scope__1644946629 \u03b2scope = new RefreshPanel_Scope__1644946629(this, pPanelID))
                \u03b2scope.Run();
        }

        [NavName("RefreshPanel")]
        [SignatureSpan(555631664285745178L)]
        [SourceSpans(556194601354395673L, 556476080626139199L, 557601963353374751L, 557883438330150967L, 558164913306927141L, 558727863260479519L, 559009338237255733L, 559290813214031929L, 559572288190808099L, 560135238144360488L, 560416713121136707L, 560698188097912898L, 560979663074689068L, 561542613028241446L, 561824088005017665L, 562105562981793856L, 562387037958570026L, 562949987912122396L, 563231462888898598L, 563512933570707464L)]
        private sealed class RefreshPanel_Scope__1644946629 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            protected override uint RawScopeId { get => RefreshPanel_Scope__1644946629.\u03b1scopeId; set => RefreshPanel_Scope__1644946629.\u03b1scopeId = value; }

            internal RefreshPanel_Scope__1644946629(Codeunit10012739 \u03b2parent, NavText pPanelID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("RefreshPanel(%1)", this.pPanelID)));
                }

                StmtHit(2);
                base.Parent.loadedPanelsTemp.Target.ALReset();
                StmtHit(3);
                base.Parent.loadedPanelsTemp.Target.ALSetRangeSafe(2, NavType.Code, this.pPanelID);
                StmtHit(4);
                base.Parent.loadedPanelsTemp.Target.ALDeleteAll();
                StmtHit(5);
                base.Parent._PanelEntities.Target.ALReset();
                StmtHit(6);
                base.Parent._PanelEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pPanelID);
                StmtHit(7);
                base.Parent._PanelEntities.Target.ALSetRangeSafe(1000, NavType.Boolean, ALCompiler.ToNavValue(false));
                StmtHit(8);
                base.Parent._PanelEntities.Target.ALDeleteAll();
                StmtHit(9);
                base.Parent._PanelRowColumnEntities.Target.ALReset();
                StmtHit(10);
                base.Parent._PanelRowColumnEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pPanelID);
                StmtHit(11);
                base.Parent._PanelRowColumnEntities.Target.ALSetRangeSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(false));
                StmtHit(12);
                base.Parent._PanelRowColumnEntities.Target.ALDeleteAll();
                StmtHit(13);
                base.Parent._PanelControlEntities.Target.ALReset();
                StmtHit(14);
                base.Parent._PanelControlEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pPanelID);
                StmtHit(15);
                base.Parent._PanelControlEntities.Target.ALSetRangeSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(false));
                StmtHit(16);
                base.Parent._PanelControlEntities.Target.ALDeleteAll();
                StmtHit(17);
                base.Parent.LoadPanel(this.pPanelID);
                StmtHit(18);
                base.Parent.ResumePanelControls(this.pPanelID);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 375612336")]
        public void RefreshStyleProfile()
        {
            using (RefreshStyleProfile_Scope_2079651057 \u03b2scope = new RefreshStyleProfile_Scope_2079651057(this))
                \u03b2scope.Run();
        }

        [NavName("RefreshStyleProfile")]
        [SignatureSpan(991073453358514209L)]
        [SourceSpans(991636377542262820L, 991917848224071688L)]
        private sealed class RefreshStyleProfile_Scope_2079651057 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            protected override uint RawScopeId { get => RefreshStyleProfile_Scope_2079651057.\u03b1scopeId; set => RefreshStyleProfile_Scope_2079651057.\u03b1scopeId = value; }

            internal RefreshStyleProfile_Scope_2079651057(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.styleProfilePending = true;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3322368402")]
        public void RefreshZoomControl(NavCode pInterfaceProfileID, NavCode pControlID)
        {
            using (RefreshZoomControl_Scope_904469264 \u03b2scope = new RefreshZoomControl_Scope_904469264(this, pInterfaceProfileID, pControlID))
                \u03b2scope.Run();
        }

        [NavName("RefreshZoomControl")]
        [SignatureSpan(945193032143994912L)]
        [SourceSpans(945755956327743565L, 946037427009552392L)]
        private sealed class RefreshZoomControl_Scope_904469264 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pInterfaceProfileID")]
            public NavCode pInterfaceProfileID;
            [NavName("pControlID")]
            public NavCode pControlID;
            protected override uint RawScopeId { get => RefreshZoomControl_Scope_904469264.\u03b1scopeId; set => RefreshZoomControl_Scope_904469264.\u03b1scopeId = value; }

            internal RefreshZoomControl_Scope_904469264(Codeunit10012739 \u03b2parent, NavCode pInterfaceProfileID, NavCode pControlID) : base(\u03b2parent)
            {
                this.pInterfaceProfileID = pInterfaceProfileID.ModifyLength(10);
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.RefreshControl(NavOption.Create(NCLEnumMetadata.Create(99008881), 4), new NavText(this.pControlID), true);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4149458189")]
        public void Refresh(NavCode pControlID)
        {
            using (Refresh_Scope_473330946 \u03b2scope = new Refresh_Scope_473330946(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("Refresh")]
        [SignatureSpan(1051590573365395477L)]
        [SourceSpans(1052153510434045977L, 1052434989705789500L, 1052997922479472711L, 1053279393161281544L)]
        private sealed class Refresh_Scope_473330946 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            protected override uint RawScopeId { get => Refresh_Scope_473330946.\u03b1scopeId; set => Refresh_Scope_473330946.\u03b1scopeId = value; }

            internal Refresh_Scope_473330946(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("Refresh(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SendPOSCommandEvent(new NavText("REFRESH"), new NavText(ALSystemString.ALStrSubstNo("[%1]", this.pControlID)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 838666611")]
        public void RegisterPanelClosedEvent(NavCode pPanelID)
        {
            using (RegisterPanelClosedEvent_Scope__580348916 \u03b2scope = new RegisterPanelClosedEvent_Scope__580348916(this, pPanelID))
                \u03b2scope.Run();
        }

        [NavName("RegisterPanelClosedEvent")]
        [SignatureSpan(1025694875501985830L)]
        [SourceSpans(1026257812570636313L, 1026539291842379850L, 1027102224616063024L, 1027383695297871880L)]
        private sealed class RegisterPanelClosedEvent_Scope__580348916 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavCode pPanelID;
            protected override uint RawScopeId { get => RegisterPanelClosedEvent_Scope__580348916.\u03b1scopeId; set => RegisterPanelClosedEvent_Scope__580348916.\u03b1scopeId = value; }

            internal RegisterPanelClosedEvent_Scope__580348916(Codeunit10012739 \u03b2parent, NavCode pPanelID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("RegisterPanelCloseEvent(%1)", this.pPanelID)));
                }

                StmtHit(2);
                base.Parent.panelClosedEventRegister.Target.Invoke(-1685229465, new object[] { new NavText(this.pPanelID) });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3455996353")]
        public void RemoveControlEntities(NavOption pControlType, NavText pControlID)
        {
            using (RemoveControlEntities_Scope_1736536040 \u03b2scope = new RemoveControlEntities_Scope_1736536040(this, pControlType, pControlID))
                \u03b2scope.Run();
        }

        [NavName("RemoveControlEntities")]
        [SignatureSpan(577868187451064355L)]
        [SourceSpans(578712586615324684L, 579557063081525291L, 579838538058301509L, 580120013035077703L, 580401488011853871L, 581527387918958637L, 581808862895734855L, 582090337872511049L, 582371812849287217L, 583497712756391980L, 583779187733168198L, 584060662709944392L, 584342137686720560L, 585468037593825321L, 585749512570601539L, 586030987547377733L, 586312462524153901L, 587438362431258665L, 587719837408034883L, 588001312384811077L, 588282787361587245L, 589408687268692014L, 589690162245468232L, 589971637222244426L, 590253112199020594L, 591379012106125352L, 591660487082901570L, 591941962059677764L, 592223437036453932L, 593349336943558702L, 593630811920334920L, 593912286897111114L, 594193761873887282L, 595038130969640968L)]
        private sealed class RemoveControlEntities_Scope_1736536040 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            protected override uint RawScopeId { get => RemoveControlEntities_Scope_1736536040.\u03b1scopeId; set => RemoveControlEntities_Scope_1736536040.\u03b1scopeId = value; }

            internal RemoveControlEntities_Scope_1736536040(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                NavOption @tmp1 = this.pControlType;
                if ((@tmp1.CompareTo(NavOption.Create(NCLEnumMetadata.Create(99008881), 5)) == 0))
                {
                    {
                        StmtHit(1);
                        base.Parent._BrowserEntities.Target.ALReset();
                        StmtHit(2);
                        base.Parent._BrowserEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pControlID);
                        StmtHit(3);
                        base.Parent._BrowserEntities.Target.ALSetRangeSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(false));
                        StmtHit(4);
                        base.Parent._BrowserEntities.Target.ALDeleteAll();
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(NCLEnumMetadata.Create(99008881), 0)) == 0))
                {
                    {
                        StmtHit(5);
                        base.Parent._ButtonPadEntities.Target.ALReset();
                        StmtHit(6);
                        base.Parent._ButtonPadEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pControlID);
                        StmtHit(7);
                        base.Parent._ButtonPadEntities.Target.ALSetRangeSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(false));
                        StmtHit(8);
                        base.Parent._ButtonPadEntities.Target.ALDeleteAll();
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(NCLEnumMetadata.Create(99008881), 3)) == 0))
                {
                    {
                        StmtHit(9);
                        base.Parent._DataGridEntities.Target.ALReset();
                        StmtHit(10);
                        base.Parent._DataGridEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pControlID);
                        StmtHit(11);
                        base.Parent._DataGridEntities.Target.ALSetRangeSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(false));
                        StmtHit(12);
                        base.Parent._DataGridEntities.Target.ALDeleteAll();
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(NCLEnumMetadata.Create(99008881), 1)) == 0))
                {
                    {
                        StmtHit(13);
                        base.Parent._InputEntities.Target.ALReset();
                        StmtHit(14);
                        base.Parent._InputEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pControlID);
                        StmtHit(15);
                        base.Parent._InputEntities.Target.ALSetRangeSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(false));
                        StmtHit(16);
                        base.Parent._InputEntities.Target.ALDeleteAll();
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(NCLEnumMetadata.Create(99008881), 6)) == 0))
                {
                    {
                        StmtHit(17);
                        base.Parent._MediaEntities.Target.ALReset();
                        StmtHit(18);
                        base.Parent._MediaEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pControlID);
                        StmtHit(19);
                        base.Parent._MediaEntities.Target.ALSetRangeSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(false));
                        StmtHit(20);
                        base.Parent._MediaEntities.Target.ALDeleteAll();
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(NCLEnumMetadata.Create(99008881), 4)) == 0))
                {
                    {
                        StmtHit(21);
                        base.Parent._RecordZoomEntities.Target.ALReset();
                        StmtHit(22);
                        base.Parent._RecordZoomEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pControlID);
                        StmtHit(23);
                        base.Parent._RecordZoomEntities.Target.ALSetRangeSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(false));
                        StmtHit(24);
                        base.Parent._RecordZoomEntities.Target.ALDeleteAll();
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(NCLEnumMetadata.Create(99008881), 7)) == 0))
                {
                    {
                        StmtHit(25);
                        base.Parent._MenuEntities.Target.ALReset();
                        StmtHit(26);
                        base.Parent._MenuEntities.Target.ALSetRangeSafe(1, NavType.Code, this.pControlID);
                        StmtHit(27);
                        base.Parent._MenuEntities.Target.ALSetRangeSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(false));
                        StmtHit(28);
                        base.Parent._MenuEntities.Target.ALDeleteAll();
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(NavOption.Create(NCLEnumMetadata.Create(99008881), 8)) == 0))
                {
                    {
                        StmtHit(29);
                        base.Parent._MenuButtonEntities.Target.ALReset();
                        StmtHit(30);
                        base.Parent._MenuButtonEntities.Target.ALSetRangeSafe(1, NavType.Code, this.pControlID);
                        StmtHit(31);
                        base.Parent._MenuButtonEntities.Target.ALSetRangeSafe(2000, NavType.Boolean, ALCompiler.ToNavValue(false));
                        StmtHit(32);
                        base.Parent._MenuButtonEntities.Target.ALDeleteAll();
                    }

                    goto @tmp0;
                }

                @tmp0:
                    ;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 426909008")]
        public bool RemoveMenu(NavText pMenuID, NavCode pButtonPadID)
        {
            using (RemoveMenu_Scope__1508347324 \u03b2scope = new RemoveMenu_Scope__1508347324(this, pMenuID, pButtonPadID))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("RemoveMenu")]
        [SignatureSpan(785033770358341656L)]
        [SourceSpans(786441132357320729L, 786722611629064254L, 787285544402747455L, 787567032264425503L, 787848511536168984L, 788129969333076002L, 788411444309852199L, 788974394263404563L, 789255864945213448L)]
        private sealed class RemoveMenu_Scope__1508347324 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pButtonPadID")]
            public NavCode pButtonPadID;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            [NavName("menuStack")]
            public NavCodeunitHandle menuStack;
            [NavName("menu")]
            public NavText menu = NavText.Default(0);
            protected override uint RawScopeId { get => RemoveMenu_Scope__1508347324.\u03b1scopeId; set => RemoveMenu_Scope__1508347324.\u03b1scopeId = value; }

            internal RemoveMenu_Scope__1508347324(Codeunit10012739 \u03b2parent, NavText pMenuID, NavCode pButtonPadID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pButtonPadID = pButtonPadID.ModifyLength(20);
                this.menuStack = new NavCodeunitHandle(this, 10012738);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("PopMenu(%1)", this.pButtonPadID)));
                }

                StmtHit(2);
                this.menuStack.Target.Invoke(1091980582, new object[] { base.Parent.GetButtonPadMenuList(this.pButtonPadID) });
                if (CStmtHit(3) & (((int)ALCompiler.ObjectToInt32(this.menuStack.Target.Invoke(1991726454, Array.Empty<object>()))) <= 1))
                {
                    StmtHit(4);
                    this.\u03b3retVal = false;
                    return;
                }

                StmtHit(5);
                this.menuStack.Target.Invoke(-1260004393, new object[] { this.pMenuID });
                StmtHit(6);
                base.Parent.SetMenuVisible(this.pMenuID, false);
                StmtHit(7);
                this.\u03b3retVal = true;
                return;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2126964932")]
        public int RemovePOSDataByTag(NavText pTag)
        {
            using (RemovePOSDataByTag_Scope_1660707436 \u03b2scope = new RemovePOSDataByTag_Scope_1660707436(this, pTag))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("RemovePOSDataByTag")]
        [SignatureSpan(542120865400487968L)]
        [SourceSpans(543809689491341337L, 544654114421669921L, 544935589398446130L, 545217077260124201L, 545780048689561620L, 546624525158449202L, 546906000135225434L, 547187475112001588L, 548313375019106406L, 548594849995882552L, 548876324972658764L, 549157799949434957L, 549439274926211130L, 549720749902987396L, 550565131883642923L, 551128038887522339L, 551409509569331208L)]
        private sealed class RemovePOSDataByTag_Scope_1660707436 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pTag")]
            public NavText pTag;
            [ReturnValue]
            public int \u03b3retVal = default(int);
            [NavName("menuID")]
            public NavText menuID = NavText.Default(0);
            [NavName("buttonNo")]
            public int buttonNo = default(int);
            protected override uint RawScopeId { get => RemovePOSDataByTag_Scope_1660707436.\u03b1scopeId; set => RemovePOSDataByTag_Scope_1660707436.\u03b1scopeId = value; }

            internal RemovePOSDataByTag_Scope_1660707436(Codeunit10012739 \u03b2parent, NavText pTag) : base(\u03b2parent)
            {
                this.pTag = pTag.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.ClearByTag(this.pTag);
                StmtHit(1);
                base.Parent._TAGGED_CONTROLS.Target.ALReset();
                StmtHit(2);
                base.Parent._TAGGED_CONTROLS.Target.ALSetRangeSafe(5, NavType.Text, this.pTag);
                if (CStmtHit(3) & (base.Parent._TAGGED_CONTROLS.Target.ALFindSet(DataError.TrapError, true)))
                    do
                    {
                        StmtHit(4);
                        NavOption @tmp1 = ((NavOption)base.Parent._TAGGED_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option));
                        if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._TAGGED_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7)) == 0))
                        {
                            {
                                StmtHit(5);
                                base.Parent._MenuEntities.Target.ALReset();
                                StmtHit(6);
                                base.Parent._MenuEntities.Target.ALSetRangeSafe(1, NavType.Code, ((NavCode)base.Parent._TAGGED_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code)));
                                StmtHit(7);
                                base.Parent._MenuEntities.Target.ALDeleteAll();
                            }

                            goto @tmp0;
                        }

                        if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._TAGGED_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8)) == 0))
                        {
                            {
                                StmtHit(8);
                                base.Parent.pOSUTILS.Target.Invoke(-2094906302, new object[] { new NavText(((NavCode)base.Parent._TAGGED_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))), new ByRef<NavText>(() => this.menuID, setValue => this.menuID = setValue), new ByRef<int>(() => this.buttonNo, setValue => this.buttonNo = setValue) });
                                StmtHit(9);
                                base.Parent._MenuButtonEntities.Target.ALReset();
                                StmtHit(10);
                                base.Parent._MenuButtonEntities.Target.ALSetRangeSafe(1, NavType.Code, this.menuID);
                                StmtHit(11);
                                base.Parent._MenuButtonEntities.Target.ALSetRangeSafe(2, NavType.Integer, ALCompiler.ToNavValue(this.buttonNo));
                                StmtHit(12);
                                base.Parent._MenuButtonEntities.Target.ALDeleteAll();
                                StmtHit(13);
                                base.Parent.HideControl_888901552(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { this.menuID, this.buttonNo })));
                            }

                            goto @tmp0;
                        }

                        @tmp0:
                            ;
                    }
                    while (!(CStmtHit(14) & (base.Parent._TAGGED_CONTROLS.Target.ALNext() == 0)));
                StmtHit(15);
                base.Parent._TAGGED_CONTROLS.Target.ALDeleteAll();
            }
        }

        private void RemovePanelControlFromPosition(NavText pPanelID, int pColumn, int pRow, int pColumnSpan, int pRowSpan)
        {
            using (RemovePanelControlFromPosition_Scope_1772247227 \u03b2scope = new RemovePanelControlFromPosition_Scope_1772247227(this, pPanelID, pColumn, pRow, pColumnSpan, pRowSpan))
                \u03b2scope.Run();
        }

        [NavName("RemovePanelControlFromPosition")]
        [SignatureSpan(863846789625479218L)]
        [SourceSpans(865254125854654489L, 865535605126398087L, 866098537901064208L, 866380030057644048L, 866661522213371950L, 866942997190148191L, 867224485051826224L, 867787469365117029L, 868068961521762474L, 868350453678407729L, 868631932950151407L, 868913390747058288L, 869194865723834431L, 870039264884359224L, 870320679731593231L, 870602133233532936L)]
        private sealed class RemovePanelControlFromPosition_Scope_1772247227 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("pColumn")]
            public int pColumn;
            [NavName("pRow")]
            public int pRow;
            [NavName("pColumnSpan")]
            public int pColumnSpan;
            [NavName("pRowSpan")]
            public int pRowSpan;
            [NavName("c")]
            public int c = default(int);
            [NavName("r")]
            public int r = default(int);
            protected override uint RawScopeId { get => RemovePanelControlFromPosition_Scope_1772247227.\u03b1scopeId; set => RemovePanelControlFromPosition_Scope_1772247227.\u03b1scopeId = value; }

            internal RemovePanelControlFromPosition_Scope_1772247227(Codeunit10012739 \u03b2parent, NavText pPanelID, int pColumn, int pRow, int pColumnSpan, int pRowSpan) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.pColumn = pColumn;
                this.pRow = pRow;
                this.pColumnSpan = pColumnSpan;
                this.pRowSpan = pRowSpan;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("RemovePanelControlFromPosition(%1, %2, %3, %4, %5)", this.pPanelID, ALCompiler.ToNavValue(this.pColumn), ALCompiler.ToNavValue(this.pRow), ALCompiler.ToNavValue(this.pColumnSpan), ALCompiler.ToNavValue(this.pRowSpan))));
                }

                this.c = this.pColumn;
                StmtHit(2);
                int @tmp0 = this.pColumn + this.pColumnSpan;
                for (; this.c <= @tmp0;)
                {
                    {
                        this.r = this.pRow;
                        StmtHit(3);
                        int @tmp1 = this.pRow + this.pRowSpan;
                        for (; this.r <= @tmp1;)
                        {
                            {
                                CStmtHit(4);
                                base.Parent._PanelControlEntities.Target.ALReset();
                                StmtHit(5);
                                base.Parent._PanelControlEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pPanelID);
                                if (CStmtHit(6) & (base.Parent._PanelControlEntities.Target.ALFindSet(DataError.TrapError)))
                                    do
                                    {
                                        if (CStmtHit(7) & ((this.r >= base.Parent._PanelControlEntities.Target.GetFieldValueSafe(5, NavType.Integer).ToInt32()) & (this.c >= base.Parent._PanelControlEntities.Target.GetFieldValueSafe(4, NavType.Integer).ToInt32())))
                                        {
                                            if (CStmtHit(8) & ((this.r < base.Parent._PanelControlEntities.Target.GetFieldValueSafe(5, NavType.Integer).ToInt32() + base.Parent._PanelControlEntities.Target.GetFieldValueSafe(7, NavType.Integer).ToInt32()) & (this.c < base.Parent._PanelControlEntities.Target.GetFieldValueSafe(4, NavType.Integer).ToInt32() + base.Parent._PanelControlEntities.Target.GetFieldValueSafe(6, NavType.Integer).ToInt32())))
                                            {
                                                if (CStmtHit(9) & (base.Parent.__LogLevel > 3))
                                                {
                                                    StmtHit(10);
                                                    base.Parent.LogTrace(new NavText(ALSystemString.ALStrSubstNo("Removing %1 Control \"%2\" From Panel Cell c=%3, r=%4", ((NavOption)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(8, NavType.Option)), ((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code)), ALCompiler.ToNavValue(base.Parent._PanelControlEntities.Target.GetFieldValueSafe(4, NavType.Integer).ToInt32()), ALCompiler.ToNavValue(base.Parent._PanelControlEntities.Target.GetFieldValueSafe(5, NavType.Integer).ToInt32()))));
                                                }

                                                StmtHit(11);
                                                base.Parent.HideControl_888901552(((NavOption)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(8, NavType.Option)), new NavText(((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code))));
                                                StmtHit(12);
                                                base.Parent._PanelControlEntities.Target.ALDelete(DataError.ThrowError);
                                            }
                                        }
                                    }
                                    while (!(CStmtHit(13) & (base.Parent._PanelControlEntities.Target.ALNext() == 0)));
                            }

                            if (this.r >= @tmp1)
                                break;
                            this.r = this.r + 1;
                        }

                        StmtHit(14);
                    }

                    if (this.c >= @tmp0)
                        break;
                    this.c = this.c + 1;
                }
            }
        }

        private void RemovePanelControls(NavText pPanelID)
        {
            using (RemovePanelControls_Scope__2134894489 \u03b2scope = new RemovePanelControls_Scope__2134894489(this, pPanelID))
                \u03b2scope.Run();
        }

        [NavName("RemovePanelControls")]
        [SignatureSpan(452048898601910311L)]
        [SourceSpans(453174759854309401L, 453456239126052934L, 454019171899736105L, 454582121853288473L, 454863596830064690L, 455145071806840896L, 455426559668518941L, 455989543981809709L, 456271023253553233L, 456552489640394789L, 457396871621050433L, 457678346597826602L, 457959817279635464L)]
        private sealed class RemovePanelControls_Scope__2134894489 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("l_CONTROLS")]
            public INavRecordHandle l_CONTROLS;
            protected override uint RawScopeId { get => RemovePanelControls_Scope__2134894489.\u03b1scopeId; set => RemovePanelControls_Scope__2134894489.\u03b1scopeId = value; }

            internal RemovePanelControls_Scope__2134894489(Codeunit10012739 \u03b2parent, NavText pPanelID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.l_CONTROLS = new NavRecordHandle(this, 99001760, false, SecurityFiltering.Validated);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("RemovePanelControls(%1)", this.pPanelID)));
                }

                StmtHit(2);
                this.l_CONTROLS.Target.ALCopy(base.Parent._CONTROLS.Target, true);
                StmtHit(3);
                this.l_CONTROLS.Target.ALReset();
                StmtHit(4);
                this.l_CONTROLS.Target.ALSetRangeSafe(2, NavType.Option, ALCompiler.ToNavValue(0), ALCompiler.ToNavValue(6));
                StmtHit(5);
                this.l_CONTROLS.Target.ALSetRangeSafe(20, NavType.Code, this.pPanelID);
                if (CStmtHit(6) & (this.l_CONTROLS.Target.ALFindSet(DataError.TrapError)))
                    do
                    {
                        if (CStmtHit(7) & (((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code)) != ""))
                        {
                            StmtHit(8);
                            base.Parent.HideControl_888901552(((NavOption)this.l_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)), new NavText(((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))));
                        }
                    }
                    while (!(CStmtHit(9) & (this.l_CONTROLS.Target.ALNext() == 0)));
                StmtHit(10);
                base.Parent._PanelControlEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pPanelID);
                StmtHit(11);
                base.Parent._PanelControlEntities.Target.ALDeleteAll();
            }
        }

        private void ResetAllPanelControls(NavText pPanelID)
        {
            using (ResetAllPanelControls_Scope__1371073577 \u03b2scope = new ResetAllPanelControls_Scope__1371073577(this, pPanelID))
                \u03b2scope.Run();
        }

        [NavName("ResetAllPanelControls")]
        [SignatureSpan(443604649298624553L)]
        [SourceSpans(444730510551023641L, 445011989822767176L, 445574922596450345L, 446137872550002713L, 446419347526778930L, 446700822503555136L, 446982310365233181L, 447545294678523949L, 447826773950922776L, 448389758263558211L, 449234200373755983L, 449515675350532164L, 450360083100991560L, 451204465081647141L, 451485892813783048L)]
        private sealed class ResetAllPanelControls_Scope__1371073577 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("l_CONTROLS")]
            public INavRecordHandle l_CONTROLS;
            protected override uint RawScopeId { get => ResetAllPanelControls_Scope__1371073577.\u03b1scopeId; set => ResetAllPanelControls_Scope__1371073577.\u03b1scopeId = value; }

            internal ResetAllPanelControls_Scope__1371073577(Codeunit10012739 \u03b2parent, NavText pPanelID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.l_CONTROLS = new NavRecordHandle(this, 99001760, false, SecurityFiltering.Validated);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ResetAllPanelControls(%1)", this.pPanelID)));
                }

                StmtHit(2);
                this.l_CONTROLS.Target.ALCopy(base.Parent._CONTROLS.Target, true);
                StmtHit(3);
                this.l_CONTROLS.Target.ALReset();
                StmtHit(4);
                this.l_CONTROLS.Target.ALSetRangeSafe(2, NavType.Option, ALCompiler.ToNavValue(0), ALCompiler.ToNavValue(6));
                StmtHit(5);
                this.l_CONTROLS.Target.ALSetRangeSafe(20, NavType.Code, this.pPanelID);
                if (CStmtHit(6) & (this.l_CONTROLS.Target.ALFindSet(DataError.TrapError)))
                    do
                    {
                        if (CStmtHit(7) & (((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code)) != ""))
                        {
                            StmtHit(8);
                            NavOption @tmp1 = ((NavOption)this.l_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option));
                            if ((@tmp1.CompareTo(NavOption.Create(NCLEnumMetadata.Create(99008881), 1)) == 0))
                            {
                                {
                                    StmtHit(9);
                                    base.Parent.SetInputText(new NavText(((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))), new NavText(""));
                                }

                                goto @tmp0;
                            }

                            if ((@tmp1.CompareTo(NavOption.Create(NCLEnumMetadata.Create(99008881), 3)) == 0))
                            {
                                {
                                    StmtHit(10);
                                    base.Parent.ClearMarkedRecords_2109721568(new NavCode(20, ((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))), true);
                                    StmtHit(11);
                                    base.Parent.ResetDataGrid(new NavCode(20, ((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))));
                                }

                                goto @tmp0;
                            }

                            if ((@tmp1.CompareTo(NavOption.Create(NCLEnumMetadata.Create(99008881), 2)) == 0))
                            {
                                {
                                    StmtHit(12);
                                    base.Parent.ResetAllPanelControls(new NavText(((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))));
                                }

                                goto @tmp0;
                            }

                            @tmp0:
                                ;
                        }
                    }
                    while (!(CStmtHit(13) & (this.l_CONTROLS.Target.ALNext() == 0)));
            }
        }

        private void ResetControlLibrary()
        {
            using (ResetControlLibrary_Scope_918057132 \u03b2scope = new ResetControlLibrary_Scope_918057132(this))
                \u03b2scope.Run();
        }

        [NavName("ResetControlLibrary")]
        [SignatureSpan(1270578131067076647L)]
        [SourceSpans(1271703992319475737L, 1271985471591219254L, 1272266929388126243L, 1272548404364902424L, 1272829879341678628L, 1273392842180132888L, 1273674321451876383L, 1273955774953816072L)]
        private sealed class ResetControlLibrary_Scope_918057132 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("panelID")]
            public NavText panelID = NavText.Default(0);
            protected override uint RawScopeId { get => ResetControlLibrary_Scope_918057132.\u03b1scopeId; set => ResetControlLibrary_Scope_918057132.\u03b1scopeId = value; }

            internal ResetControlLibrary_Scope_918057132(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText("---- ResetControlLibrary ----"));
                }

                StmtHit(2);
                this.panelID = base.Parent.ActivePanelID();
                StmtHit(3);
                base.Parent.ClearControls();
                StmtHit(4);
                base.Parent.styleProfilePending = true;
                if (CStmtHit(5) & (this.panelID != ""))
                {
                    StmtHit(6);
                    base.Parent.ShowPanel(this.panelID);
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3505150435")]
        public void ResetDataGrid(NavCode pControlID)
        {
            using (ResetDataGrid_Scope_1067467051 \u03b2scope = new ResetDataGrid_Scope_1067467051(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("ResetDataGrid")]
        [SignatureSpan(1027946675316195355L)]
        [SourceSpans(1028509612384845849L, 1028791091656589378L, 1029072549453496389L, 1029354020135305224L)]
        private sealed class ResetDataGrid_Scope_1067467051 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            protected override uint RawScopeId { get => ResetDataGrid_Scope_1067467051.\u03b1scopeId; set => ResetDataGrid_Scope_1067467051.\u03b1scopeId = value; }

            internal ResetDataGrid_Scope_1067467051(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ResetDataGrid(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SendPOSCommandEvent(new NavText("RESET"), new NavText(ALSystemString.ALStrSubstNo("[%1]", this.pControlID)));
            }
        }

        private void ResumeCurrentPanel()
        {
            using (ResumeCurrentPanel_Scope_470053050 \u03b2scope = new ResumeCurrentPanel_Scope_470053050(this))
                \u03b2scope.Run();
        }

        [NavName("ResumeCurrentPanel")]
        [SignatureSpan(433471550134681638L)]
        [SourceSpans(435160361340633113L, 435441840612376621L, 436004773386059811L, 436567736224514071L, 436849215496257553L, 437412161154842659L, 437693640426586143L, 438256573200269349L, 439100998130597918L, 439382473107374107L, 439663948084150298L, 439945423060926503L, 440226898037702691L, 440508373014478883L, 440789847991255083L, 441071322968031269L, 441352797944807459L, 441915760783261732L, 442197240055005222L, 442478715031781418L, 443041643510497288L)]
        private sealed class ResumeCurrentPanel_Scope_470053050 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("panelID")]
            public NavText panelID = NavText.Default(0);
            [NavName("tmpView")]
            public NavText tmpView = NavText.Default(0);
            protected override uint RawScopeId { get => ResumeCurrentPanel_Scope_470053050.\u03b1scopeId; set => ResumeCurrentPanel_Scope_470053050.\u03b1scopeId = value; }

            internal ResumeCurrentPanel_Scope_470053050(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("ResumeCurrentPanel()"));
                }

                StmtHit(2);
                this.panelID = base.Parent.ActivePanelID();
                if (CStmtHit(3) & (this.panelID == ""))
                {
                    StmtHit(4);
                    return;
                }

                if (CStmtHit(5) & (!base.Parent.PanelLoaded(this.panelID)))
                {
                    StmtHit(6);
                    base.Parent.LoadPanel(this.panelID);
                }

                StmtHit(7);
                base.Parent.ResumePanelControls(this.panelID);
                StmtHit(8);
                base.Parent.gActiveDataGrid = new NavText("");
                StmtHit(9);
                base.Parent.gActiveInput = new NavText("");
                StmtHit(10);
                base.Parent.gActiveZoom = new NavText("");
                StmtHit(11);
                this.tmpView = new NavText(base.Parent._CONTROLS.Target.ALGetView());
                StmtHit(12);
                base.Parent.SetActiveControls(this.panelID);
                StmtHit(13);
                base.Parent._CONTROLS.Target.ALSetView(this.tmpView);
                StmtHit(14);
                base.Parent.SetActiveDataGrid(base.Parent.gActiveDataGrid);
                StmtHit(15);
                base.Parent.SetActiveInput(base.Parent.gActiveInput);
                StmtHit(16);
                base.Parent.SetActiveZoom(base.Parent.gActiveZoom);
                if (CStmtHit(17) & (base.Parent._lastOpenPanel != this.panelID))
                {
                    StmtHit(18);
                    base.Parent._lastOpenPanel = this.panelID;
                    StmtHit(19);
                    base.Parent.SendPanelOpenedEvent(new NavCode(20, this.panelID));
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4096349966")]
        public void ResumePanelControls(NavText pPanelID)
        {
            using (ResumePanelControls_Scope_1040166710 \u03b2scope = new ResumePanelControls_Scope_1040166710(this, pPanelID))
                \u03b2scope.Run();
        }

        [NavName("ResumePanelControls")]
        [SignatureSpan(121878725073633313L)]
        [SourceSpans(124130512002940953L, 124411991274684473L, 124974936933269537L, 125256416205013009L, 125819348978696233L, 126100823955472409L, 126382298932248626L, 126663773909024832L, 126945261770702877L, 127508233199091788L, 127789708175867970L, 128071196037546029L, 128352666719354917L, 128915586608136246L, 129197065879879716L, 129478540856655926L, 130322948607115300L, 130604423583891521L, 130885898560667746L, 131167386422345770L, 131730357850734842L, 132293320689188974L, 132574799960932395L, 133137732734615610L, 133419224891261024L, 133700712752939074L, 133982192024682570L, 134826612660043814L, 135108091931787377L, 135952516862115944L, 136234004723793992L, 136515496880439382L, 136796976152182915L, 138485765883297840L, 139048685772079138L, 139611670085369906L, 139893149357113435L, 140174615743954986L, 140737522748096524L, 141019027789381675L, 141300507061125159L, 141581964858032173L, 141863422654939147L, 142144893336748040L)]
        private sealed class ResumePanelControls_Scope_1040166710 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("nestedPanels")]
            public NavList<NavText> nestedPanels = NavList<NavText>.Default;
            [NavName("nestedPanel")]
            public NavText nestedPanel = NavText.Default(0);
            [NavName("refreshControls")]
            public bool refreshControls = default(bool);
            [NavName("l_CONTROLS")]
            public INavRecordHandle l_CONTROLS;
            [NavName("l_PanelControls")]
            public INavRecordHandle l_PanelControls;
            protected override uint RawScopeId { get => ResumePanelControls_Scope_1040166710.\u03b1scopeId; set => ResumePanelControls_Scope_1040166710.\u03b1scopeId = value; }

            internal ResumePanelControls_Scope_1040166710(Codeunit10012739 \u03b2parent, NavText pPanelID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.nestedPanels = NavList<NavText>.Default;
                this.l_CONTROLS = new NavRecordHandle(this, 99001760, false, SecurityFiltering.Validated);
                this.l_PanelControls = new NavRecordHandle(this, 99001760, false, SecurityFiltering.Validated);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("ResumePanelControls: " + this.pPanelID));
                }

                if (CStmtHit(2) & (!base.Parent.GetPanel(this.pPanelID)))
                {
                    StmtHit(3);
                    return;
                }

                StmtHit(4);
                this.l_CONTROLS.Target.ALCopy(base.Parent._CONTROLS.Target, true);
                StmtHit(5);
                this.l_CONTROLS.Target.ALReset();
                StmtHit(6);
                this.l_CONTROLS.Target.ALSetRangeSafe(2, NavType.Option, ALCompiler.ToNavValue(0), ALCompiler.ToNavValue(6));
                StmtHit(7);
                this.l_CONTROLS.Target.ALSetRangeSafe(20, NavType.Code, this.pPanelID);
                if (CStmtHit(8) & (this.l_CONTROLS.Target.ALFindSet(DataError.TrapError)))
                    do
                    {
                        StmtHit(9);
                        this.l_PanelControls.Target.SetFieldValueSafe(2, NavType.Option, ((NavOption)this.l_CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)));
                        StmtHit(10);
                        this.l_PanelControls.Target.SetFieldValueSafe(4, NavType.Code, ((NavCode)this.l_CONTROLS.Target.GetFieldValueSafe(4, NavType.Code)));
                        if (CStmtHit(11) & (!this.l_PanelControls.Target.ALInsert(DataError.TrapError)))
                            ;
                    }
                    while (!(CStmtHit(12) & (this.l_CONTROLS.Target.ALNext() == 0)));
                if (CStmtHit(13) & (base.Parent.panelNeedsControlRefresh.ALContains(this.pPanelID)))
                {
                    StmtHit(14);
                    this.refreshControls = true;
                    StmtHit(15);
                    base.Parent.panelNeedsControlRefresh.ALRemove(this.pPanelID);
                }

                StmtHit(16);
                base.Parent._PanelControlEntities.Target.ALReset();
                StmtHit(17);
                base.Parent._PanelControlEntities.Target.ALSetRangeSafe(2, NavType.Code, this.pPanelID);
                StmtHit(18);
                base.Parent.LogDeepTrace_1953297028(new NavText("ResumePanelControls.ControlCount = " + NavFormatEvaluateHelper.Format(ALCompiler.ToNavValue(base.Parent._PanelControlEntities.Target.ALCount))));
                if (CStmtHit(19) & (base.Parent._PanelControlEntities.Target.ALFind(DataError.TrapError, "-")))
                    do
                    {
                        StmtHit(20);
                        base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("ResumePanelControls [%1]: %2 - %3 at r=%4,c=%5", ALCompiler.ToNavValue(base.Parent._PanelControlEntities.Target.GetFieldValueSafe(3, NavType.Integer).ToInt32()), ((NavOption)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(8, NavType.Option)), ((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code)), ALCompiler.ToNavValue(base.Parent._PanelControlEntities.Target.GetFieldValueSafe(5, NavType.Integer).ToInt32()), ALCompiler.ToNavValue(base.Parent._PanelControlEntities.Target.GetFieldValueSafe(4, NavType.Integer).ToInt32()))));
                        if (CStmtHit(21) & (this.l_PanelControls.Target.ALGet(DataError.TrapError, ((NavOption)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(8, NavType.Option)), ((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code)), ALCompiler.ToNavValue(""))))
                        {
                            StmtHit(22);
                            this.l_PanelControls.Target.ALDelete(DataError.ThrowError);
                        }

                        StmtHit(23);
                        base.Parent.SetControlPosition(base.Parent._PanelControlEntities);
                        if (CStmtHit(24) & (((NavOption)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(8, NavType.Option)) == NavOption.Create(((NavOption)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(8, NavType.Option)).NavOptionMetadata, 2)))
                        {
                            if (CStmtHit(25) & (this.pPanelID != ((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code))))
                            {
                                StmtHit(26);
                                this.nestedPanels.ALAdd(new NavText(((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code))));
                            }
                        }
                        else
                        {
                            if (CStmtHit(27) & (this.refreshControls))
                            {
                                StmtHit(28);
                                base.Parent.RefreshControl(((NavOption)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(8, NavType.Option)), new NavText(((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code))), true);
                            }

                            if (CStmtHit(29) & (((NavOption)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(8, NavType.Option)) == NavOption.Create(((NavOption)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(8, NavType.Option)).NavOptionMetadata, 0)))
                            {
                                if (CStmtHit(30) & (base.Parent.GetButtonPad(new NavText(((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code))))))
                                {
                                    if (CStmtHit(31) & (base.Parent.GetButtonPadMenu(new NavCode(20, ((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code)))) != ""))
                                    {
                                        StmtHit(32);
                                        base.Parent.UpdateMenuPosition(base.Parent.GetButtonPadMenu(new NavCode(20, ((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code)))), new NavText(((NavCode)base.Parent._ButtonPadEntities.Target.GetFieldValueSafe(2, NavType.Code))));
                                    }
                                }
                            }
                        }
                    }
                    while (!(CStmtHit(33) & (base.Parent._PanelControlEntities.Target.ALNext() == 0)));
                if (CStmtHit(34) & (this.l_PanelControls.Target.ALFindSet(DataError.TrapError)))
                    do
                    {
                        if (CStmtHit(35) & (((NavCode)this.l_PanelControls.Target.GetFieldValueSafe(4, NavType.Code)) != ""))
                        {
                            StmtHit(36);
                            base.Parent.HideControl_888901552(((NavOption)this.l_PanelControls.Target.GetFieldValueSafe(2, NavType.Option)), new NavText(((NavCode)this.l_PanelControls.Target.GetFieldValueSafe(4, NavType.Code))));
                        }
                    }
                    while (!(CStmtHit(37) & (this.l_PanelControls.Target.ALNext() == 0)));
                StmtHit(38);
                foreach (var @tmp0 in this.nestedPanels)
                {
                    this.nestedPanel = @tmp0;
                    {
                        if (CStmtHit(39) & (!base.Parent.PanelLoaded(this.nestedPanel)))
                        {
                            CStmtHit(40);
                            base.Parent.LoadPanel(this.nestedPanel);
                        }

                        StmtHit(41);
                        base.Parent.ResumePanelControls(this.nestedPanel);
                    }
                }

                StmtHit(42);
            }
        }

        private bool RunCommand_49859252(NavText pButtonPadID, NavText pCommand, NavText pParameter)
        {
            using (RunCommand_Scope_49859252 \u03b2scope = new RunCommand_Scope_49859252(this, pButtonPadID, pCommand, pParameter))
            {
                \u03b2scope.Run();
                return \u03b2scope.handled;
            }
        }

        [NavName("RunCommand")]
        [SignatureSpan(1220757060177690654L)]
        [SourceSpans(1221319971476537369L, 1221601450748280927L, 1222164383521964057L, 1222727346360418328L, 1223008825632161816L, 1223571758409383948L, 1224697709852557369L, 1224979184829333540L, 1226105097621340201L, 1226386589777985584L, 1226668069049729068L, 1228075422458773545L, 1228356914615418928L, 1228638393887162412L, 1229201322365878306L, 1229482814522523720L, 1229764306679169098L, 1230045785950912577L, 1230608748789366840L, 1230890228061110342L, 1231171703037886516L, 1233141972040745080L, 1233423451312488505L, 1234549334039724074L, 1234830809016500260L, 1235956721808506921L, 1236238201080250428L, 1236519676057026600L, 1237927046645940273L, 1238208525917683762L, 1239052877833568264L)]
        private sealed class RunCommand_Scope_49859252 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pButtonPadID")]
            public NavText pButtonPadID;
            [NavName("pCommand")]
            public NavText pCommand;
            [NavName("pParameter")]
            public NavText pParameter;
            [ReturnValue("handled")]
            [NavName("handled")]
            public bool handled = default(bool);
            protected override uint RawScopeId { get => RunCommand_Scope_49859252.\u03b1scopeId; set => RunCommand_Scope_49859252.\u03b1scopeId = value; }

            internal RunCommand_Scope_49859252(Codeunit10012739 \u03b2parent, NavText pButtonPadID, NavText pCommand, NavText pParameter) : base(\u03b2parent)
            {
                this.pButtonPadID = pButtonPadID.ModifyLength(0);
                this.pCommand = pCommand.ModifyLength(0);
                this.pParameter = pParameter.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText(ALSystemString.ALStrSubstNo("RunCommand(%1, %2, %3)", this.pButtonPadID, this.pCommand, this.pParameter)));
                }

                StmtHit(2);
                this.handled = false;
                if (CStmtHit(3) & (this.pCommand == ""))
                {
                    StmtHit(4);
                    this.handled = false;
                    return;
                }

                StmtHit(5);
                NavText @tmp1 = this.pCommand;
                if ((@tmp1.CompareTo(new NavText("RESETALL")) == 0))
                {
                    {
                        StmtHit(6);
                        base.Parent.ResetAllPanelControls(base.Parent.ActivePanelID());
                        StmtHit(7);
                        this.handled = true;
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(new NavText("LASTMENU")) == 0))
                {
                    {
                        if (CStmtHit(8) & (this.pButtonPadID != ""))
                        {
                            if (CStmtHit(9) & (base.Parent.PopMenu(new NavCode(20, this.pButtonPadID))))
                            {
                                StmtHit(10);
                                this.handled = true;
                            }
                        }
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(new NavText("CANCEL")) == 0) || (@tmp1.CompareTo(new NavText("CANCEL2")) == 0))
                {
                    {
                        if (CStmtHit(11) & (this.pButtonPadID != ""))
                            if (CStmtHit(12) & (base.Parent.PopMenu(new NavCode(20, this.pButtonPadID))))
                            {
                                StmtHit(13);
                                this.handled = true;
                            }

                        if (CStmtHit(14) & (!this.handled))
                        {
                            if (CStmtHit(15) & (base.Parent.ActivePanelID() != NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 4)))))
                            {
                                if (CStmtHit(16) & (base.Parent.ActivePanelID() != NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 3)))))
                                {
                                    StmtHit(17);
                                    this.handled = base.Parent.HideActivePanel(false);
                                }
                                else if (CStmtHit(18) & (this.pParameter == "Escape"))
                                {
                                    StmtHit(19);
                                    base.Parent.SendPOSCommandEvent(new NavText("LOGOFF"), new NavText(""));
                                    StmtHit(20);
                                    this.handled = true;
                                }
                            }
                        }
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(new NavText("OK")) == 0))
                {
                    {
                        if (CStmtHit(21) & ((base.Parent.ActivePanelID() != NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 4)))) & (base.Parent.ActivePanelID() != NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 3))))))
                        {
                            StmtHit(22);
                            this.handled = base.Parent.HideActivePanel(true);
                        }
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(new NavText("POPUP")) == 0))
                {
                    {
                        StmtHit(23);
                        base.Parent.PopupMenu(this.pParameter);
                        StmtHit(24);
                        this.handled = true;
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(new NavText("IMENU")) == 0))
                {
                    {
                        if (CStmtHit(25) & (this.pButtonPadID != ""))
                        {
                            StmtHit(26);
                            base.Parent.StackMenu(new NavCode(20, this.pParameter), new NavCode(20, this.pButtonPadID));
                            StmtHit(27);
                            this.handled = true;
                        }
                    }

                    goto @tmp0;
                }

                if ((@tmp1.CompareTo(new NavText("CUSTOM")) == 0))
                {
                    {
                        if (CStmtHit(28) & (this.pParameter == "THROW_ERROR"))
                        {
                            StmtHit(29);
                            NavDialog.ALError(Guid.Parse("8da61efd-0002-0003-0507-0b0d1113171d"), "Simulated error!");
                        }
                    }

                    goto @tmp0;
                }

                @tmp0:
                    ;
            }
        }

        private bool RunCommand(NavText pCommand, NavText pParameter)
        {
            using (RunCommand_Scope__730108835 \u03b2scope = new RunCommand_Scope__730108835(this, pCommand, pParameter))
            {
                \u03b2scope.Run();
                return \u03b2scope.\u03b3retVal;
            }
        }

        [NavName("RunCommand")]
        [SignatureSpan(1219349685293809694L)]
        [SourceSpans(1219912583707754547L, 1220194054389563400L)]
        private sealed class RunCommand_Scope__730108835 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pCommand")]
            public NavText pCommand;
            [NavName("pParameter")]
            public NavText pParameter;
            [ReturnValue]
            public bool \u03b3retVal = default(bool);
            protected override uint RawScopeId { get => RunCommand_Scope__730108835.\u03b1scopeId; set => RunCommand_Scope__730108835.\u03b1scopeId = value; }

            internal RunCommand_Scope__730108835(Codeunit10012739 \u03b2parent, NavText pCommand, NavText pParameter) : base(\u03b2parent)
            {
                this.pCommand = pCommand.ModifyLength(0);
                this.pParameter = pParameter.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.\u03b3retVal = base.Parent.RunCommand_49859252(new NavText(""), this.pCommand, this.pParameter);
                return;
            }
        }

        private static NCLOptionMetadata SelectGridColumn_Scope__419809427_sortOrder_metadata = NCLOptionMetadata.Create("None,Ascending,Descending");
        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2544220467")]
        public void SelectGridColumn(NavCode pControlID, int columnNo, int sortOrder)
        {
            using (SelectGridColumn_Scope__419809427 \u03b2scope = new SelectGridColumn_Scope__419809427(this, pControlID, columnNo, sortOrder))
                \u03b2scope.Run();
        }

        [NavName("SelectGridColumn")]
        [SignatureSpan(1018658001082581022L)]
        [SourceSpans(1019220938151231513L, 1019502417422975045L, 1020065350196658320L, 1020346825173434508L, 1020628295855243272L)]
        private sealed class SelectGridColumn_Scope__419809427 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("columnNo")]
            public int columnNo;
            [NavName("sortOrder")]
            public NavOption sortOrder;
            protected override uint RawScopeId { get => SelectGridColumn_Scope__419809427.\u03b1scopeId; set => SelectGridColumn_Scope__419809427.\u03b1scopeId = value; }

            internal SelectGridColumn_Scope__419809427(Codeunit10012739 \u03b2parent, NavCode pControlID, int columnNo, int sortOrder) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.columnNo = columnNo;
                this.sortOrder = NavOption.Create(SelectGridColumn_Scope__419809427_sortOrder_metadata, sortOrder);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SelectGridColumn(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1002)), this.columnNo });
                StmtHit(3);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1005)), this.sortOrder });
            }
        }

        private void SendModalPanelClosedEvent(NavText pPanelID, bool modalResult, NavText pPayload)
        {
            using (SendModalPanelClosedEvent_Scope__292687222 \u03b2scope = new SendModalPanelClosedEvent_Scope__292687222(this, pPanelID, modalResult, pPayload))
                \u03b2scope.Run();
        }

        [NavName("SendModalPanelClosedEvent")]
        [SignatureSpan(489203595536367661L)]
        [SourceSpans(490610918880641070L, 490892393857417256L, 491173868834193439L, 491455343810969625L, 491736831672647702L, 492018310944391196L, 492581260897943581L, 492862718694850592L, 493425681533304854L, 493707173689950263L, 493988652961693759L, 494833043532283929L, 495114514214092808L)]
        private sealed class SendModalPanelClosedEvent_Scope__292687222 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("modalResult")]
            public bool modalResult;
            [NavName("pPayload")]
            public NavText pPayload;
            [NavName("evnt")]
            public NavCodeunitHandle evnt;
            [NavName("evntType")]
            public NavOption evntType = NavOption.Create(NCLEnumMetadata.Create(10012741), 0);
            protected override uint RawScopeId { get => SendModalPanelClosedEvent_Scope__292687222.\u03b1scopeId; set => SendModalPanelClosedEvent_Scope__292687222.\u03b1scopeId = value; }

            internal SendModalPanelClosedEvent_Scope__292687222(Codeunit10012739 \u03b2parent, NavText pPanelID, bool modalResult, NavText pPayload) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.modalResult = modalResult;
                this.pPayload = pPayload.ModifyLength(0);
                this.evnt = new NavCodeunitHandle(this, 10012741);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.evnt.Target.Invoke(-1364555097, new object[] { NavOption.Create(this.evntType.NavOptionMetadata, 11) });
                StmtHit(1);
                this.evnt.Target.Invoke(1101439803, new object[] { base.Parent.ActivePanelID() });
                StmtHit(2);
                this.evnt.Target.Invoke(1769627309, new object[] { this.pPanelID });
                StmtHit(3);
                this.evnt.Target.Invoke(1546799811, new object[] { 1 });
                if (CStmtHit(4) & (this.modalResult))
                {
                    StmtHit(5);
                    this.evnt.Target.Invoke(1653354174, new object[] { 1 });
                }
                else
                {
                    StmtHit(6);
                    this.evnt.Target.Invoke(1653354174, new object[] { 0 });
                }

                StmtHit(7);
                this.evnt.Target.Invoke(1845809118, new object[] { this.pPayload });
                if (CStmtHit(8) & (this.modalResult))
                    if (CStmtHit(9) & (this.pPanelID == NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 6)))))
                    {
                        StmtHit(10);
                        this.evnt.Target.Invoke(1808351587, new object[] { new NavText(NavFormatEvaluateHelper.Format(base.Parent.GetSelectedDate(), 0, 9)) });
                    }

                StmtHit(11);
                base.Parent.OnPOSEvent(this.evnt);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4213078203")]
        public void SendPOSCommandEvent(NavText pCommand, NavText pParameter)
        {
            using (SendPOSCommandEvent_Scope__999906039 \u03b2scope = new SendPOSCommandEvent_Scope__999906039(this, pCommand, pParameter))
                \u03b2scope.Run();
        }

        [NavName("SendPOSCommandEvent")]
        [SignatureSpan(1215409009849139233L)]
        [SourceSpans(1216534896871342105L, 1216816376143085654L, 1217097846824894488L, 1217379326096637969L, 1217660783893544984L, 1217942271755223067L, 1218223751026966558L, 1218505208823873560L, 1218786679505682440L)]
        private sealed class SendPOSCommandEvent_Scope__999906039 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pCommand")]
            public NavText pCommand;
            [NavName("pParameter")]
            public NavText pParameter;
            [NavName("j")]
            public NavJsonArray j;
            protected override uint RawScopeId { get => SendPOSCommandEvent_Scope__999906039.\u03b1scopeId; set => SendPOSCommandEvent_Scope__999906039.\u03b1scopeId = value; }

            internal SendPOSCommandEvent_Scope__999906039(Codeunit10012739 \u03b2parent, NavText pCommand, NavText pParameter) : base(\u03b2parent)
            {
                this.pCommand = pCommand.ModifyLength(0);
                this.pParameter = pParameter.ModifyLength(0);
                this.j = NavJsonArray.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText(ALSystemString.ALStrSubstNo("SendPOSCommandEvent(%1, %2)", this.pCommand, this.pParameter)));
                }

                if (CStmtHit(2) & (this.pCommand == ""))
                {
                    StmtHit(3);
                    return;
                }

                StmtHit(4);
                this.j.ALAdd(this.pCommand);
                if (CStmtHit(5) & (this.pParameter != ""))
                {
                    StmtHit(6);
                    this.j.ALAdd(this.pParameter);
                }

                StmtHit(7);
                base.Parent.commands.ALAdd(this.j);
            }
        }

        private void SendPanelCloseRequest(NavText pPanelID, NavText pPayload)
        {
            using (SendPanelCloseRequest_Scope__1674656170 \u03b2scope = new SendPanelCloseRequest_Scope__1674656170(this, pPanelID, pPayload))
                \u03b2scope.Run();
        }

        [NavName("SendPanelCloseRequest")]
        [SignatureSpan(476255746604662825L)]
        [SourceSpans(477663069948936226L, 477944544925712434L, 478226019902488616L, 478507494879264799L, 478788969856040992L, 479633394786369561L, 479914865468178440L)]
        private sealed class SendPanelCloseRequest_Scope__1674656170 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("pPayload")]
            public NavText pPayload;
            [NavName("evnt")]
            public NavCodeunitHandle evnt;
            [NavName("evntType")]
            public NavOption evntType = NavOption.Create(NCLEnumMetadata.Create(10012741), 0);
            protected override uint RawScopeId { get => SendPanelCloseRequest_Scope__1674656170.\u03b1scopeId; set => SendPanelCloseRequest_Scope__1674656170.\u03b1scopeId = value; }

            internal SendPanelCloseRequest_Scope__1674656170(Codeunit10012739 \u03b2parent, NavText pPanelID, NavText pPayload) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.pPayload = pPayload.ModifyLength(0);
                this.evnt = new NavCodeunitHandle(this, 10012741);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.panelCloseDenied = false;
                StmtHit(1);
                this.evnt.Target.Invoke(-1364555097, new object[] { NavOption.Create(this.evntType.NavOptionMetadata, 14) });
                StmtHit(2);
                this.evnt.Target.Invoke(1101439803, new object[] { base.Parent.ActivePanelID() });
                StmtHit(3);
                this.evnt.Target.Invoke(1769627309, new object[] { this.pPanelID });
                StmtHit(4);
                this.evnt.Target.Invoke(1845809118, new object[] { this.pPayload });
                StmtHit(5);
                base.Parent.OnPOSEvent(this.evnt);
            }
        }

        private void SendPanelClosedEvent(NavCode pPanelID)
        {
            using (SendPanelClosedEvent_Scope_299255071 \u03b2scope = new SendPanelClosedEvent_Scope_299255071(this, pPanelID))
                \u03b2scope.Run();
        }

        [NavName("SendPanelClosedEvent")]
        [SignatureSpan(480477871256305704L)]
        [SourceSpans(481885194600579118L, 482166669577355304L, 482448144554131487L, 483011094507683865L, 483292565189492744L)]
        private sealed class SendPanelClosedEvent_Scope_299255071 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavCode pPanelID;
            [NavName("evnt")]
            public NavCodeunitHandle evnt;
            [NavName("evntType")]
            public NavOption evntType = NavOption.Create(NCLEnumMetadata.Create(10012741), 0);
            protected override uint RawScopeId { get => SendPanelClosedEvent_Scope_299255071.\u03b1scopeId; set => SendPanelClosedEvent_Scope_299255071.\u03b1scopeId = value; }

            internal SendPanelClosedEvent_Scope_299255071(Codeunit10012739 \u03b2parent, NavCode pPanelID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(20);
                this.evnt = new NavCodeunitHandle(this, 10012741);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.evnt.Target.Invoke(-1364555097, new object[] { NavOption.Create(this.evntType.NavOptionMetadata, 11) });
                StmtHit(1);
                this.evnt.Target.Invoke(1101439803, new object[] { base.Parent.ActivePanelID() });
                StmtHit(2);
                this.evnt.Target.Invoke(1769627309, new object[] { new NavText(this.pPanelID) });
                StmtHit(3);
                base.Parent.OnPOSEvent(this.evnt);
            }
        }

        private void SendPanelOpenedEvent(NavCode pPanelID)
        {
            using (SendPanelOpenedEvent_Scope__1901113869 \u03b2scope = new SendPanelOpenedEvent_Scope__1901113869(this, pPanelID))
                \u03b2scope.Run();
        }

        [NavName("SendPanelOpenedEvent")]
        [SignatureSpan(483855570977620008L)]
        [SourceSpans(485544382183571517L, 485825861455314961L, 486388807113900053L, 486670286385643537L, 487233219159326765L, 487514694136102952L, 487796169112879135L, 488359119066431513L, 488640589748240392L)]
        private sealed class SendPanelOpenedEvent_Scope__1901113869 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavCode pPanelID;
            [NavName("evnt")]
            public NavCodeunitHandle evnt;
            [NavName("evntType")]
            public NavOption evntType = NavOption.Create(NCLEnumMetadata.Create(10012741), 0);
            [NavName("signal")]
            public bool signal = default(bool);
            protected override uint RawScopeId { get => SendPanelOpenedEvent_Scope__1901113869.\u03b1scopeId; set => SendPanelOpenedEvent_Scope__1901113869.\u03b1scopeId = value; }

            internal SendPanelOpenedEvent_Scope__1901113869(Codeunit10012739 \u03b2parent, NavCode pPanelID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(20);
                this.evnt = new NavCodeunitHandle(this, 10012741);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!base.Parent.panelOpenedEventRegister.ALGet(DataError.TrapError, new NavText(this.pPanelID), new ByRef<bool>(() => this.signal, setValue => this.signal = setValue))))
                {
                    StmtHit(1);
                    return;
                }

                if (CStmtHit(2) & (!this.signal))
                {
                    StmtHit(3);
                    return;
                }

                StmtHit(4);
                this.evnt.Target.Invoke(-1364555097, new object[] { NavOption.Create(this.evntType.NavOptionMetadata, 24) });
                StmtHit(5);
                this.evnt.Target.Invoke(1101439803, new object[] { base.Parent.ActivePanelID() });
                StmtHit(6);
                this.evnt.Target.Invoke(1769627309, new object[] { new NavText(this.pPanelID) });
                StmtHit(7);
                base.Parent.OnPOSEvent(this.evnt);
            }
        }

        private void SetActiveControls(NavText pPanelID)
        {
            using (SetActiveControls_Scope__1924489990 \u03b2scope = new SetActiveControls_Scope__1924489990(this, pPanelID))
                \u03b2scope.Run();
        }

        [NavName("SetActiveControls")]
        [SignatureSpan(458522823067762725L)]
        [SourceSpans(460211634273714201L, 460493113545457732L, 461056046319140911L, 461337521295917118L, 461618996272693301L, 461900484134371358L, 462463455564005396L, 463026452760952890L, 463307932032696383L, 464152369847926835L, 464433849119670343L, 465559744731807792L, 465841224003551300L, 466967119615688751L, 467248598887432259L, 468092963688218662L, 469218820645716010L, 469500312802295850L, 469781766304235528L)]
        private sealed class SetActiveControls_Scope__1924489990 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("subPanels")]
            public NavList<NavText> subPanels = NavList<NavText>.Default;
            [NavName("lControlID")]
            public NavText lControlID = NavText.Default(0);
            [NavName("tmpView")]
            public NavText tmpView = NavText.Default(0);
            protected override uint RawScopeId { get => SetActiveControls_Scope__1924489990.\u03b1scopeId; set => SetActiveControls_Scope__1924489990.\u03b1scopeId = value; }

            internal SetActiveControls_Scope__1924489990(Codeunit10012739 \u03b2parent, NavText pPanelID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.subPanels = NavList<NavText>.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetActiveControls(%1)", this.pPanelID)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.ALSetRangeSafe(50, NavType.DateTime);
                StmtHit(3);
                base.Parent._CONTROLS.Target.ALSetRangeSafe(20, NavType.Code, this.pPanelID);
                StmtHit(4);
                base.Parent._CONTROLS.Target.ALSetCurrentKey(DataError.ThrowError, 10);
                if (CStmtHit(5) & (base.Parent._CONTROLS.Target.ALFind(DataError.TrapError, "-")))
                    do
                    {
                        StmtHit(6);
                        NavOption @tmp1 = ((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option));
                        if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2)) == 0))
                        {
                            {
                                if (CStmtHit(7) & (((NavCode)base.Parent._CONTROLS.Target.GetFieldValueSafe(4, NavType.Code)) != this.pPanelID))
                                {
                                    StmtHit(8);
                                    this.subPanels.ALAdd(new NavText(((NavCode)base.Parent._CONTROLS.Target.GetFieldValueSafe(4, NavType.Code))));
                                }
                            }

                            goto @tmp0;
                        }

                        if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3)) == 0))
                        {
                            {
                                if (CStmtHit(9) & (base.Parent.gActiveDataGrid == ""))
                                {
                                    StmtHit(10);
                                    base.Parent.gActiveDataGrid = new NavText(((NavCode)base.Parent._CONTROLS.Target.GetFieldValueSafe(4, NavType.Code)));
                                }
                            }

                            goto @tmp0;
                        }

                        if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1)) == 0))
                        {
                            {
                                if (CStmtHit(11) & (base.Parent.gActiveInput == ""))
                                {
                                    StmtHit(12);
                                    base.Parent.gActiveInput = new NavText(((NavCode)base.Parent._CONTROLS.Target.GetFieldValueSafe(4, NavType.Code)));
                                }
                            }

                            goto @tmp0;
                        }

                        if ((@tmp1.CompareTo(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 4)) == 0))
                        {
                            {
                                if (CStmtHit(13) & (base.Parent.gActiveZoom == ""))
                                {
                                    StmtHit(14);
                                    base.Parent.gActiveZoom = new NavText(((NavCode)base.Parent._CONTROLS.Target.GetFieldValueSafe(4, NavType.Code)));
                                }
                            }

                            goto @tmp0;
                        }

                        @tmp0:
                            ;
                    }
                    while (!(CStmtHit(15) & (base.Parent._CONTROLS.Target.ALNext() == 0)));
                StmtHit(16);
                foreach (var @tmp2 in this.subPanels)
                {
                    this.lControlID = @tmp2;
                    {
                        CStmtHit(17);
                        base.Parent.SetActiveControls(this.lControlID);
                    }
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2183901783")]
        public void SetActiveDataGrid(NavText pControlID)
        {
            using (SetActiveDataGrid_Scope__240251716 \u03b2scope = new SetActiveDataGrid_Scope__240251716(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("SetActiveDataGrid")]
        [SignatureSpan(919297334280585247L)]
        [SourceSpans(919860271349235737L, 920141750620979270L, 920423208417886280L, 920704679099695112L)]
        private sealed class SetActiveDataGrid_Scope__240251716 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            protected override uint RawScopeId { get => SetActiveDataGrid_Scope__240251716.\u03b1scopeId; set => SetActiveDataGrid_Scope__240251716.\u03b1scopeId = value; }

            internal SetActiveDataGrid_Scope__240251716(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetActiveDataGrid(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SetMainControlValue_1893130901(new NavText(base.Parent._POS.Target.ALFieldName(43)), this.pControlID);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2114076913")]
        public void SetActiveInput(NavText pControlID)
        {
            using (SetActiveInput_Scope_1594117119 \u03b2scope = new SetActiveInput_Scope_1594117119(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("SetActiveInput")]
        [SignatureSpan(805018493709451292L)]
        [SourceSpans(805581430778101785L, 805862910049845315L, 806144367846752325L, 806425838528561160L)]
        private sealed class SetActiveInput_Scope_1594117119 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            protected override uint RawScopeId { get => SetActiveInput_Scope_1594117119.\u03b1scopeId; set => SetActiveInput_Scope_1594117119.\u03b1scopeId = value; }

            internal SetActiveInput_Scope_1594117119(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetActiveInput(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SetMainControlValue_1893130901(new NavText(base.Parent._POS.Target.ALFieldName(41)), this.pControlID);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2435953322")]
        public void SetActiveZoom(NavText pControlID)
        {
            using (SetActiveZoom_Scope__896451774 \u03b2scope = new SetActiveZoom_Scope__896451774(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("SetActiveZoom")]
        [SignatureSpan(931119283305185307L)]
        [SourceSpans(931682220373835801L, 931963699645579330L, 932245157442486346L, 932526628124295176L)]
        private sealed class SetActiveZoom_Scope__896451774 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            protected override uint RawScopeId { get => SetActiveZoom_Scope__896451774.\u03b1scopeId; set => SetActiveZoom_Scope__896451774.\u03b1scopeId = value; }

            internal SetActiveZoom_Scope__896451774(Codeunit10012739 \u03b2parent, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetActiveZoom(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SetMainControlValue_1893130901(new NavText(base.Parent._POS.Target.ALFieldName(44)), this.pControlID);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3047974862")]
        public void SetAutoLogoffTimeout(int timeout)
        {
            using (SetAutoLogoffTimeout_Scope_1694892829 \u03b2scope = new SetAutoLogoffTimeout_Scope_1694892829(this, timeout))
                \u03b2scope.Run();
        }

        [NavName("SetAutoLogoffTimeout")]
        [SignatureSpan(1085649045555314722L)]
        [SourceSpans(1086211982623965209L, 1086493461895708742L, 1087056394669391944L, 1087337865351200776L)]
        private sealed class SetAutoLogoffTimeout_Scope_1694892829 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("Timeout")]
            public int timeout;
            protected override uint RawScopeId { get => SetAutoLogoffTimeout_Scope_1694892829.\u03b1scopeId; set => SetAutoLogoffTimeout_Scope_1694892829.\u03b1scopeId = value; }

            internal SetAutoLogoffTimeout_Scope_1694892829(Codeunit10012739 \u03b2parent, int timeout) : base(\u03b2parent)
            {
                this.timeout = timeout;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetAutoLogoffTimeout(%1)", ALCompiler.ToNavValue(this.timeout))));
                }

                StmtHit(2);
                base.Parent.SetMainControlValue_1888936601(new NavText(base.Parent._POS.Target.ALFieldName(32)), this.timeout);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1817299915")]
        public void SetButtonCaption(NavCode menuID, int buttonNo, NavOption caption, NavText newValue)
        {
            using (SetButtonCaption_Scope__1436137779 \u03b2scope = new SetButtonCaption_Scope__1436137779(this, menuID, buttonNo, caption, newValue))
                \u03b2scope.Run();
        }

        [NavName("SetButtonCaption")]
        [SignatureSpan(417708925665411102L)]
        [SourceSpans(418271862734061593L, 418553342005805162L, 419116274779553904L, 419960712594718759L, 420242191866527898L, 420805120345178120L)]
        private sealed class SetButtonCaption_Scope__1436137779 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("menuID")]
            public NavCode menuID;
            [NavName("buttonNo")]
            public int buttonNo;
            [NavName("caption")]
            public NavOption caption;
            [NavName("newValue")]
            public NavText newValue;
            protected override uint RawScopeId { get => SetButtonCaption_Scope__1436137779.\u03b1scopeId; set => SetButtonCaption_Scope__1436137779.\u03b1scopeId = value; }

            internal SetButtonCaption_Scope__1436137779(Codeunit10012739 \u03b2parent, NavCode menuID, int buttonNo, NavOption caption, NavText newValue) : base(\u03b2parent)
            {
                this.menuID = menuID.ModifyLength(20);
                this.buttonNo = buttonNo;
                this.caption = caption;
                this.newValue = newValue.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetButtonCaption(%1, %2, %3, %4)", this.menuID, ALCompiler.ToNavValue(this.buttonNo), this.caption, this.newValue)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.buttonNo })), base.Parent.ButtonCaptionTypeText(this.caption), this.newValue });
                if (CStmtHit(3) & (this.caption != NavOption.Create(this.caption.NavOptionMetadata, 0)))
                {
                    StmtHit(4);
                    base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.buttonNo })), NavTextExtensions.ALTrimEnd(base.Parent.ButtonCaptionTypeText(this.caption), new NavText("Text")), 25 });
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2118676866")]
        public void SetButtonCommand(NavCode menuID, int buttonNo, NavText newValue)
        {
            using (SetButtonCommand_Scope__1999077560 \u03b2scope = new SetButtonCommand_Scope__1999077560(this, menuID, buttonNo, newValue))
                \u03b2scope.Run();
        }

        [NavName("SetButtonCommand")]
        [SignatureSpan(421368100363501598L)]
        [SourceSpans(421931037432152089L, 422212516703895645L, 422775449477644408L, 423338395136163848L)]
        private sealed class SetButtonCommand_Scope__1999077560 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("menuID")]
            public NavCode menuID;
            [NavName("buttonNo")]
            public int buttonNo;
            [NavName("newValue")]
            public NavText newValue;
            protected override uint RawScopeId { get => SetButtonCommand_Scope__1999077560.\u03b1scopeId; set => SetButtonCommand_Scope__1999077560.\u03b1scopeId = value; }

            internal SetButtonCommand_Scope__1999077560(Codeunit10012739 \u03b2parent, NavCode menuID, int buttonNo, NavText newValue) : base(\u03b2parent)
            {
                this.menuID = menuID.ModifyLength(20);
                this.buttonNo = buttonNo;
                this.newValue = newValue.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetButtonCommand(%1, %2, %3)", this.menuID, ALCompiler.ToNavValue(this.buttonNo), this.newValue)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.buttonNo })), new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(4)), this.newValue });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4266819319")]
        public void SetButtonEnabled(NavCode menuID, int buttonNo, bool newValue)
        {
            using (SetButtonEnabled_Scope__1144439413 \u03b2scope = new SetButtonEnabled_Scope__1144439413(this, menuID, buttonNo, newValue))
                \u03b2scope.Run();
        }

        [NavName("SetButtonEnabled")]
        [SignatureSpan(415175650874425374L)]
        [SourceSpans(415738587943075865L, 416020067214819421L, 416582999988568189L, 417145945647087624L)]
        private sealed class SetButtonEnabled_Scope__1144439413 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("menuID")]
            public NavCode menuID;
            [NavName("buttonNo")]
            public int buttonNo;
            [NavName("newValue")]
            public bool newValue;
            protected override uint RawScopeId { get => SetButtonEnabled_Scope__1144439413.\u03b1scopeId; set => SetButtonEnabled_Scope__1144439413.\u03b1scopeId = value; }

            internal SetButtonEnabled_Scope__1144439413(Codeunit10012739 \u03b2parent, NavCode menuID, int buttonNo, bool newValue) : base(\u03b2parent)
            {
                this.menuID = menuID.ModifyLength(20);
                this.buttonNo = buttonNo;
                this.newValue = newValue;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetButtonEnabled(%1, %2, %3)", this.menuID, ALCompiler.ToNavValue(this.buttonNo), ALCompiler.ToNavValue(this.newValue))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1410208911, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.buttonNo })), new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(37)), !this.newValue });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1982401101")]
        public void SetButtonFont(NavCode menuID, int buttonNo, NavOption caption, NavText newValue)
        {
            using (SetButtonFont_Scope__586531772 \u03b2scope = new SetButtonFont_Scope__586531772(this, menuID, buttonNo, caption, newValue))
                \u03b2scope.Run();
        }

        [NavName("SetButtonFont")]
        [SignatureSpan(425590225015144475L)]
        [SourceSpans(426716112037347353L, 426997591309090919L, 427560536967675961L, 427842016239419433L, 428404949013168228L, 428967894671687688L)]
        private sealed class SetButtonFont_Scope__586531772 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("menuID")]
            public NavCode menuID;
            [NavName("buttonNo")]
            public int buttonNo;
            [NavName("caption")]
            public NavOption caption;
            [NavName("newValue")]
            public NavText newValue;
            [NavName("fieldName")]
            public NavText fieldName = NavText.Default(0);
            protected override uint RawScopeId { get => SetButtonFont_Scope__586531772.\u03b1scopeId; set => SetButtonFont_Scope__586531772.\u03b1scopeId = value; }

            internal SetButtonFont_Scope__586531772(Codeunit10012739 \u03b2parent, NavCode menuID, int buttonNo, NavOption caption, NavText newValue) : base(\u03b2parent)
            {
                this.menuID = menuID.ModifyLength(20);
                this.buttonNo = buttonNo;
                this.caption = caption;
                this.newValue = newValue.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetButtonFont(%1, %2, %3, %4)", this.menuID, ALCompiler.ToNavValue(this.buttonNo), this.caption, this.newValue)));
                }

                if (CStmtHit(2) & (this.caption != NavOption.Create(NCLEnumMetadata.Create(99008883), 0)))
                {
                    StmtHit(3);
                    this.fieldName = new NavText(NavFormatEvaluateHelper.Format(this.caption));
                }

                StmtHit(4);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.buttonNo })), new NavText(this.fieldName + "Font"), this.newValue });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2530408568")]
        public void SetButtonHighlighted(NavCode menuID, int buttonNo, bool newValue)
        {
            using (SetButtonHighlighted_Scope_2050328345 \u03b2scope = new SetButtonHighlighted_Scope_2050328345(this, menuID, buttonNo, newValue))
                \u03b2scope.Run();
        }

        [NavName("SetButtonHighlighted")]
        [SignatureSpan(412642376083439650L)]
        [SourceSpans(413205313152090137L, 413486792423833697L, 414049725197582460L, 414612670856101896L)]
        private sealed class SetButtonHighlighted_Scope_2050328345 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("menuID")]
            public NavCode menuID;
            [NavName("buttonNo")]
            public int buttonNo;
            [NavName("newValue")]
            public bool newValue;
            protected override uint RawScopeId { get => SetButtonHighlighted_Scope_2050328345.\u03b1scopeId; set => SetButtonHighlighted_Scope_2050328345.\u03b1scopeId = value; }

            internal SetButtonHighlighted_Scope_2050328345(Codeunit10012739 \u03b2parent, NavCode menuID, int buttonNo, bool newValue) : base(\u03b2parent)
            {
                this.menuID = menuID.ModifyLength(20);
                this.buttonNo = buttonNo;
                this.newValue = newValue;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetButtonHighlighted(%1, %2, %3)", this.menuID, ALCompiler.ToNavValue(this.buttonNo), ALCompiler.ToNavValue(this.newValue))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1410208911, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.buttonNo })), new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(1202)), this.newValue });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 392529789")]
        public void SetButtonSkin(NavCode menuID, int buttonNo, NavText newValue)
        {
            using (SetButtonSkin_Scope__959976847 \u03b2scope = new SetButtonSkin_Scope__959976847(this, menuID, buttonNo, newValue))
                \u03b2scope.Run();
        }

        [NavName("SetButtonSkin")]
        [SignatureSpan(429530874690011163L)]
        [SourceSpans(430093811758661657L, 430375291030405210L, 430938223804153973L, 431501169462673416L)]
        private sealed class SetButtonSkin_Scope__959976847 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("menuID")]
            public NavCode menuID;
            [NavName("buttonNo")]
            public int buttonNo;
            [NavName("newValue")]
            public NavText newValue;
            protected override uint RawScopeId { get => SetButtonSkin_Scope__959976847.\u03b1scopeId; set => SetButtonSkin_Scope__959976847.\u03b1scopeId = value; }

            internal SetButtonSkin_Scope__959976847(Codeunit10012739 \u03b2parent, NavCode menuID, int buttonNo, NavText newValue) : base(\u03b2parent)
            {
                this.menuID = menuID.ModifyLength(20);
                this.buttonNo = buttonNo;
                this.newValue = newValue.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetButtonSkin(%1, %2, %3)", this.menuID, ALCompiler.ToNavValue(this.buttonNo), this.newValue)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.buttonNo })), new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(910)), this.newValue });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 917410846")]
        public void SetControlPosition([NavObjectId(ObjectId = 99008874)][NavByReferenceAttribute] INavRecordHandle pPanelControlEntity)
        {
            using (SetControlPosition_Scope_1184793874 \u03b2scope = new SetControlPosition_Scope_1184793874(this, pPanelControlEntity))
                \u03b2scope.Run();
        }

        [NavName("SetControlPosition")]
        [SignatureSpan(859624639204032544L)]
        [SourceSpans(860187563387781340L, 860469034069590024L)]
        private sealed class SetControlPosition_Scope_1184793874 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelControlEntity")]
            public INavRecordHandle pPanelControlEntity;
            protected override uint RawScopeId { get => SetControlPosition_Scope_1184793874.\u03b1scopeId; set => SetControlPosition_Scope_1184793874.\u03b1scopeId = value; }

            internal SetControlPosition_Scope_1184793874(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99008874)][NavByReferenceAttribute] INavRecordHandle pPanelControlEntity) : base(\u03b2parent)
            {
                this.pPanelControlEntity = pPanelControlEntity;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent._CONTROLS.Target.Invoke(-204461422, new object[] { ((NavOption)this.pPanelControlEntity.Target.GetFieldValueSafe(8, NavType.Option)), new NavText(((NavCode)this.pPanelControlEntity.Target.GetFieldValueSafe(9, NavType.Code))), new NavText(base.Parent._SHARED.Target.ALFieldName(20)), base.Parent.GetPanelControlPositionText(this.pPanelControlEntity), new NavText(((NavCode)this.pPanelControlEntity.Target.GetFieldValueSafe(2, NavType.Code))) });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3490047031")]
        public void SetControlPosition_1520947238(NavOption pControlType, NavText pControlID, NavText pParentPanelID, int pRow, int pColumn, int pRowSpan, int pColumnSpan)
        {
            using (SetControlPosition_Scope_1520947238 \u03b2scope = new SetControlPosition_Scope_1520947238(this, pControlType, pControlID, pParentPanelID, pRow, pColumn, pRowSpan, pColumnSpan))
                \u03b2scope.Run();
        }

        [NavName("SetControlPosition")]
        [SignatureSpan(861032014087913504L)]
        [SourceSpans(863002313155543235L, 863283783837351944L)]
        private sealed class SetControlPosition_Scope_1520947238 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pParentPanelID")]
            public NavText pParentPanelID;
            [NavName("pRow")]
            public int pRow;
            [NavName("pColumn")]
            public int pColumn;
            [NavName("pRowSpan")]
            public int pRowSpan;
            [NavName("pColumnSpan")]
            public int pColumnSpan;
            protected override uint RawScopeId { get => SetControlPosition_Scope_1520947238.\u03b1scopeId; set => SetControlPosition_Scope_1520947238.\u03b1scopeId = value; }

            internal SetControlPosition_Scope_1520947238(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID, NavText pParentPanelID, int pRow, int pColumn, int pRowSpan, int pColumnSpan) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
                this.pParentPanelID = pParentPanelID.ModifyLength(0);
                this.pRow = pRow;
                this.pColumn = pColumn;
                this.pRowSpan = pRowSpan;
                this.pColumnSpan = pColumnSpan;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent._CONTROLS.Target.Invoke(-204461422, new object[] { this.pControlType, this.pControlID, new NavText(base.Parent._SHARED.Target.ALFieldName(20)), base.Parent.GetPanelControlPositionText_550393579(this.pParentPanelID, this.pRow, this.pColumn, this.pRowSpan, this.pColumnSpan), this.pParentPanelID });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2230057572")]
        public void SetDataGridActiveRecord(NavCode pControlID, NavText pRecordID)
        {
            using (SetDataGridActiveRecord_Scope_1941480616 \u03b2scope = new SetDataGridActiveRecord_Scope_1941480616(this, pControlID, pRecordID))
                \u03b2scope.Run();
        }

        [NavName("SetDataGridActiveRecord")]
        [SignatureSpan(958703831029252133L)]
        [SourceSpans(959829718051455001L, 960111197323198555L, 960674130096881805L, 960955600778690568L)]
        private sealed class SetDataGridActiveRecord_Scope_1941480616 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pRecordID")]
            public NavText pRecordID;
            [NavName("recID")]
            public NavRecordId recID = NavRecordId.Default;
            protected override uint RawScopeId { get => SetDataGridActiveRecord_Scope_1941480616.\u03b1scopeId; set => SetDataGridActiveRecord_Scope_1941480616.\u03b1scopeId = value; }

            internal SetDataGridActiveRecord_Scope_1941480616(Codeunit10012739 \u03b2parent, NavCode pControlID, NavText pRecordID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pRecordID = pRecordID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetDataGridActiveRecord(%1, %2)", this.pControlID, this.pRecordID)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1003)), this.pRecordID });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1911885438")]
        public void SetDataGridActiveRecord_1945150601(NavCode pControlID, NavRecordId pRecordID)
        {
            using (SetDataGridActiveRecord_Scope_1945150601 \u03b2scope = new SetDataGridActiveRecord_Scope_1945150601(this, pControlID, pRecordID))
                \u03b2scope.Run();
        }

        [NavName("SetDataGridActiveRecord")]
        [SignatureSpan(963770380611223589L)]
        [SourceSpans(964333304794972223L, 964614775476781064L)]
        private sealed class SetDataGridActiveRecord_Scope_1945150601 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pRecordID")]
            public NavRecordId pRecordID;
            protected override uint RawScopeId { get => SetDataGridActiveRecord_Scope_1945150601.\u03b1scopeId; set => SetDataGridActiveRecord_Scope_1945150601.\u03b1scopeId = value; }

            internal SetDataGridActiveRecord_Scope_1945150601(Codeunit10012739 \u03b2parent, NavCode pControlID, NavRecordId pRecordID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pRecordID = pRecordID;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.SetDataGridActiveRecord(this.pControlID, new NavText(NavFormatEvaluateHelper.Format(this.pRecordID)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2576806457")]
        public void SetDataGridMarkedRecords(NavCode pControlID, NavJsonArray pRecordIDStringArray)
        {
            using (SetDataGridMarkedRecords_Scope_736155664 \u03b2scope = new SetDataGridMarkedRecords_Scope_736155664(this, pControlID, pRecordIDStringArray))
                \u03b2scope.Run();
        }

        [NavName("SetDataGridMarkedRecords")]
        [SignatureSpan(891149836602966054L)]
        [SourceSpans(892275723625168921L, 892557202896912461L, 893120135670595630L, 893401610647371918L, 893683081329180680L)]
        private sealed class SetDataGridMarkedRecords_Scope_736155664 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pRecordIDStringArray")]
            public NavJsonArray pRecordIDStringArray;
            [NavName("tmpText")]
            public NavText tmpText = NavText.Default(0);
            protected override uint RawScopeId { get => SetDataGridMarkedRecords_Scope_736155664.\u03b1scopeId; set => SetDataGridMarkedRecords_Scope_736155664.\u03b1scopeId = value; }

            internal SetDataGridMarkedRecords_Scope_736155664(Codeunit10012739 \u03b2parent, NavCode pControlID, NavJsonArray pRecordIDStringArray) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pRecordIDStringArray = pRecordIDStringArray;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetDataGridMarkedRecords(%1)", this.pControlID)));
                }

                StmtHit(2);
                this.pRecordIDStringArray.ALWriteTo(DataError.ThrowError, new ByRef<NavText>(() => this.tmpText, setValue => this.tmpText = setValue));
                StmtHit(3);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1004)), this.tmpText });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 979222367")]
        public void SetDataTag(NavText pTag)
        {
            using (SetDataTag_Scope_1319767854 \u03b2scope = new SetDataTag_Scope_1319767854(this, pTag))
                \u03b2scope.Run();
        }

        [NavName("SetDataTag")]
        [SignatureSpan(540713490516607000L)]
        [SourceSpans(541276414700355612L, 541557885382164488L)]
        private sealed class SetDataTag_Scope_1319767854 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pTag")]
            public NavText pTag;
            protected override uint RawScopeId { get => SetDataTag_Scope_1319767854.\u03b1scopeId; set => SetDataTag_Scope_1319767854.\u03b1scopeId = value; }

            internal SetDataTag_Scope_1319767854(Codeunit10012739 \u03b2parent, NavText pTag) : base(\u03b2parent)
            {
                this.pTag = pTag.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.currDataTag = this.pTag;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4240322454")]
        public void SetDisplayNo(int pScreenNo)
        {
            using (SetDisplayNo_Scope__1818073535 \u03b2scope = new SetDisplayNo_Scope__1818073535(this, pScreenNo))
                \u03b2scope.Run();
        }

        [NavName("SetDisplayNo")]
        [SignatureSpan(1257911731342344218L)]
        [SourceSpans(1258474655526092870L, 1258756126207901704L)]
        private sealed class SetDisplayNo_Scope__1818073535 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pScreenNo")]
            public int pScreenNo;
            protected override uint RawScopeId { get => SetDisplayNo_Scope__1818073535.\u03b1scopeId; set => SetDisplayNo_Scope__1818073535.\u03b1scopeId = value; }

            internal SetDisplayNo_Scope__1818073535(Codeunit10012739 \u03b2parent, int pScreenNo) : base(\u03b2parent)
            {
                this.pScreenNo = pScreenNo;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.SetMainControlValue_1888936601(new NavText(base.Parent._POS.Target.ALFieldName(11)), this.pScreenNo);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 533583476")]
        public void SetGridSelectedColumn(NavCode pControlID, int pSelectedColumn)
        {
            using (SetGridSelectedColumn_Scope_216377196 \u03b2scope = new SetGridSelectedColumn_Scope_216377196(this, pControlID, pSelectedColumn))
                \u03b2scope.Run();
        }

        [NavName("SetGridSelectedColumn")]
        [SignatureSpan(1023443075687776291L)]
        [SourceSpans(1024006012756426777L, 1024287492028170314L, 1024850424801853591L, 1025131895483662344L)]
        private sealed class SetGridSelectedColumn_Scope_216377196 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pSelectedColumn")]
            public int pSelectedColumn;
            protected override uint RawScopeId { get => SetGridSelectedColumn_Scope_216377196.\u03b1scopeId; set => SetGridSelectedColumn_Scope_216377196.\u03b1scopeId = value; }

            internal SetGridSelectedColumn_Scope_216377196(Codeunit10012739 \u03b2parent, NavCode pControlID, int pSelectedColumn) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pSelectedColumn = pSelectedColumn;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetGridSelectedColumn(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1002)), this.pSelectedColumn });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2970150605")]
        public void SetIdleTimerInterval(int pSeconds)
        {
            using (SetIdleTimerInterval_Scope_1280628581 \u03b2scope = new SetIdleTimerInterval_Scope_1280628581(this, pSeconds))
                \u03b2scope.Run();
        }

        [NavName("SetIdleTimerInterval")]
        [SignatureSpan(407575826501468194L)]
        [SourceSpans(408138750685216841L, 408420221367025672L)]
        private sealed class SetIdleTimerInterval_Scope_1280628581 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pSeconds")]
            public int pSeconds;
            protected override uint RawScopeId { get => SetIdleTimerInterval_Scope_1280628581.\u03b1scopeId; set => SetIdleTimerInterval_Scope_1280628581.\u03b1scopeId = value; }

            internal SetIdleTimerInterval_Scope_1280628581(Codeunit10012739 \u03b2parent, int pSeconds) : base(\u03b2parent)
            {
                this.pSeconds = pSeconds;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.SetMainControlValue_1888936601(new NavText(base.Parent._POS.Target.ALFieldName(30)), this.pSeconds);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2868626165")]
        public void SetInitialized(bool pInitalized)
        {
            using (SetInitialized_Scope__1730720718 \u03b2scope = new SetInitialized_Scope__1730720718(this, pInitalized))
                \u03b2scope.Run();
        }

        [NavName("SetInitialized")]
        [SignatureSpan(94012702372790300L)]
        [SourceSpans(94575639441440793L, 94857118713184324L, 95138576510091300L, 95420047191900168L)]
        private sealed class SetInitialized_Scope__1730720718 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pInitalized")]
            public bool pInitalized;
            protected override uint RawScopeId { get => SetInitialized_Scope__1730720718.\u03b1scopeId; set => SetInitialized_Scope__1730720718.\u03b1scopeId = value; }

            internal SetInitialized_Scope__1730720718(Codeunit10012739 \u03b2parent, bool pInitalized) : base(\u03b2parent)
            {
                this.pInitalized = pInitalized;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetInitialized(%1)", ALCompiler.ToNavValue(this.pInitalized))));
                }

                StmtHit(2);
                base.Parent._Initialized = this.pInitalized;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 993244790")]
        public void SetInputEnabled(NavText pControlID, bool pEnabled)
        {
            using (SetInputEnabled_Scope__494435084 \u03b2scope = new SetInputEnabled_Scope__494435084(this, pControlID, pEnabled))
                \u03b2scope.Run();
        }

        [NavName("SetInputEnabled")]
        [SignatureSpan(808396193430765597L)]
        [SourceSpans(808959117614514266L, 809240588296323080L)]
        private sealed class SetInputEnabled_Scope__494435084 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pEnabled")]
            public bool pEnabled;
            protected override uint RawScopeId { get => SetInputEnabled_Scope__494435084.\u03b1scopeId; set => SetInputEnabled_Scope__494435084.\u03b1scopeId = value; }

            internal SetInputEnabled_Scope__494435084(Codeunit10012739 \u03b2parent, NavText pControlID, bool pEnabled) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pEnabled = pEnabled;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.SignalNotImplemented(new NavText(ALSystemString.ALStrSubstNo("SetInputEnabled(%1, %2)", this.pControlID, ALCompiler.ToNavValue(this.pEnabled))));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3099951682")]
        public void SetInputEnterPressedCommand(NavText pControlID, NavText pCommand, NavText pParameter, NavText pCommand_NoText, NavText pParameter_NoText)
        {
            using (SetInputEnterPressedCommand_Scope_1115174055 \u03b2scope = new SetInputEnterPressedCommand_Scope_1115174055(this, pControlID, pCommand, pParameter, pCommand_NoText, pParameter_NoText))
                \u03b2scope.Run();
        }

        [NavName("SetInputEnterPressedCommand")]
        [SignatureSpan(817121917710827561L)]
        [SourceSpans(817684854779478041L, 817966334051221598L, 818247791848128653L, 818529266824904849L, 818810741801681051L, 819092216778457245L, 819373687460265992L)]
        private sealed class SetInputEnterPressedCommand_Scope_1115174055 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pCommand")]
            public NavText pCommand;
            [NavName("pParameter")]
            public NavText pParameter;
            [NavName("pCommand_NoText")]
            public NavText pCommand_NoText;
            [NavName("pParameter_NoText")]
            public NavText pParameter_NoText;
            protected override uint RawScopeId { get => SetInputEnterPressedCommand_Scope_1115174055.\u03b1scopeId; set => SetInputEnterPressedCommand_Scope_1115174055.\u03b1scopeId = value; }

            internal SetInputEnterPressedCommand_Scope_1115174055(Codeunit10012739 \u03b2parent, NavText pControlID, NavText pCommand, NavText pParameter, NavText pCommand_NoText, NavText pParameter_NoText) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pCommand = pCommand.ModifyLength(0);
                this.pParameter = pParameter.ModifyLength(0);
                this.pCommand_NoText = pCommand_NoText.ModifyLength(0);
                this.pParameter_NoText = pParameter_NoText.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetInputEnterPressedCommand(%1, %2)", this.pControlID, this.pCommand)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(20)), this.pCommand });
                StmtHit(3);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(60)), this.pParameter });
                StmtHit(4);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(21)), this.pCommand_NoText });
                StmtHit(5);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(61)), this.pCommand_NoText });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4037288251")]
        public void SetInputMaxLength(NavText pControlID, int pMaxLength)
        {
            using (SetInputMaxLength_Scope__1047461207 \u03b2scope = new SetInputMaxLength_Scope__1047461207(this, pControlID, pMaxLength))
                \u03b2scope.Run();
        }

        [NavName("SetInputMaxLength")]
        [SignatureSpan(821906992316022815L)]
        [SourceSpans(822469929384673305L, 822751408656416854L, 823032866453323911L, 823314337135132680L)]
        private sealed class SetInputMaxLength_Scope__1047461207 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pMaxLength")]
            public int pMaxLength;
            protected override uint RawScopeId { get => SetInputMaxLength_Scope__1047461207.\u03b1scopeId; set => SetInputMaxLength_Scope__1047461207.\u03b1scopeId = value; }

            internal SetInputMaxLength_Scope__1047461207(Codeunit10012739 \u03b2parent, NavText pControlID, int pMaxLength) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pMaxLength = pMaxLength;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetInputMaxLength(%1, %2)", this.pControlID, ALCompiler.ToNavValue(this.pMaxLength))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(3010)), this.pMaxLength });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4224629465")]
        public void SetInputOptionString(NavText pControlID, NavText pOptionString)
        {
            using (SetInputOptionString_Scope_1078924071 \u03b2scope = new SetInputOptionString_Scope_1078924071(this, pControlID, pOptionString))
                \u03b2scope.Run();
        }

        [NavName("SetInputOptionString")]
        [SignatureSpan(408983201385349154L)]
        [SourceSpans(409546125569097867L, 409827600545874079L, 410109071227682824L)]
        private sealed class SetInputOptionString_Scope_1078924071 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pOptionString")]
            public NavText pOptionString;
            protected override uint RawScopeId { get => SetInputOptionString_Scope_1078924071.\u03b1scopeId; set => SetInputOptionString_Scope_1078924071.\u03b1scopeId = value; }

            internal SetInputOptionString_Scope_1078924071(Codeunit10012739 \u03b2parent, NavText pControlID, NavText pOptionString) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pOptionString = pOptionString.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(100)), this.pOptionString });
                StmtHit(1);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(14)), 7 });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 83448128")]
        public void SetInputPasswordChar(NavText pControlID, NavText pPassChar)
        {
            using (SetInputPasswordChar_Scope__2042309878 \u03b2scope = new SetInputPasswordChar_Scope__2042309878(this, pControlID, pPassChar))
                \u03b2scope.Run();
        }

        [NavName("SetInputPasswordChar")]
        [SignatureSpan(813181268035960866L)]
        [SourceSpans(813744205104611353L, 814025684376354904L, 814307142173261959L, 814588612855070728L)]
        private sealed class SetInputPasswordChar_Scope__2042309878 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pPassChar")]
            public NavText pPassChar;
            protected override uint RawScopeId { get => SetInputPasswordChar_Scope__2042309878.\u03b1scopeId; set => SetInputPasswordChar_Scope__2042309878.\u03b1scopeId = value; }

            internal SetInputPasswordChar_Scope__2042309878(Codeunit10012739 \u03b2parent, NavText pControlID, NavText pPassChar) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pPassChar = pPassChar.ModifyLength(1);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetInputPasswordChar(%1, %2)", this.pControlID, this.pPassChar)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(26)), new NavText(this.pPassChar) });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2684455886")]
        public void SetInputPromptWidth(NavText pControlID, int pPromptWidth)
        {
            using (SetInputPromptWidth_Scope_1330138212 \u03b2scope = new SetInputPromptWidth_Scope_1330138212(this, pControlID, pPromptWidth))
                \u03b2scope.Run();
        }

        [NavName("SetInputPromptWidth")]
        [SignatureSpan(819936667478589473L)]
        [SourceSpans(820499604547239961L, 820781083818983514L, 821062541615890576L, 821344012297699336L)]
        private sealed class SetInputPromptWidth_Scope_1330138212 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pPromptWidth")]
            public int pPromptWidth;
            protected override uint RawScopeId { get => SetInputPromptWidth_Scope_1330138212.\u03b1scopeId; set => SetInputPromptWidth_Scope_1330138212.\u03b1scopeId = value; }

            internal SetInputPromptWidth_Scope_1330138212(Codeunit10012739 \u03b2parent, NavText pControlID, int pPromptWidth) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pPromptWidth = pPromptWidth;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetInputPromptWidth(%1, %2)", this.pControlID, ALCompiler.ToNavValue(this.pPromptWidth))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(5)), this.pPromptWidth });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3428922826")]
        public void SetInputPrompt(NavText pControlID, NavText pPrompt)
        {
            using (SetInputPrompt_Scope__1739087392 \u03b2scope = new SetInputPrompt_Scope__1739087392(this, pControlID, pPrompt))
                \u03b2scope.Run();
        }

        [NavName("SetInputPrompt")]
        [SignatureSpan(815151592873394204L)]
        [SourceSpans(815714529942044697L, 815996009213788240L, 816277467010695300L, 816558937692504072L)]
        private sealed class SetInputPrompt_Scope__1739087392 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pPrompt")]
            public NavText pPrompt;
            protected override uint RawScopeId { get => SetInputPrompt_Scope__1739087392.\u03b1scopeId; set => SetInputPrompt_Scope__1739087392.\u03b1scopeId = value; }

            internal SetInputPrompt_Scope__1739087392(Codeunit10012739 \u03b2parent, NavText pControlID, NavText pPrompt) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pPrompt = pPrompt.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetInputPrompt(%1, %2)", this.pControlID, this.pPrompt)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(3)), this.pPrompt });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 137483798")]
        public void SetInputText(NavText pControlID, NavText pText)
        {
            using (SetInputText_Scope_1717809131 \u03b2scope = new SetInputText_Scope_1717809131(this, pControlID, pText))
                \u03b2scope.Run();
        }

        [NavName("SetInputText")]
        [SignatureSpan(809803568314646554L)]
        [SourceSpans(810366505383297049L, 810647984655040588L, 810929442451947645L, 811210913133756424L)]
        private sealed class SetInputText_Scope_1717809131 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pText")]
            public NavText pText;
            protected override uint RawScopeId { get => SetInputText_Scope_1717809131.\u03b1scopeId; set => SetInputText_Scope_1717809131.\u03b1scopeId = value; }

            internal SetInputText_Scope_1717809131(Codeunit10012739 \u03b2parent, NavText pControlID, NavText pText) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(0);
                this.pText = pText.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetInputText(%1, %2)", this.pControlID, this.pText)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.pControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(4)), this.pText });
            }
        }

        private static NCLOptionMetadata SetInputType_Scope_1083521742_dataType_metadata = NCLOptionMetadata.Create("Text,Integer,Decimal,DateTime,Binary,Date,Time,Option");
        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2367745719")]
        public void SetInputType(NavText inputControlID, int dataType)
        {
            using (SetInputType_Scope_1083521742 \u03b2scope = new SetInputType_Scope_1083521742(this, inputControlID, dataType))
                \u03b2scope.Run();
        }

        [NavName("SetInputType")]
        [SignatureSpan(965177755495104538L)]
        [SourceSpans(965740679678853257L, 966022150360662024L)]
        private sealed class SetInputType_Scope_1083521742 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("inputControlID")]
            public NavText inputControlID;
            [NavName("dataType")]
            public NavOption dataType;
            protected override uint RawScopeId { get => SetInputType_Scope_1083521742.\u03b1scopeId; set => SetInputType_Scope_1083521742.\u03b1scopeId = value; }

            internal SetInputType_Scope_1083521742(Codeunit10012739 \u03b2parent, NavText inputControlID, int dataType) : base(\u03b2parent)
            {
                this.inputControlID = inputControlID.ModifyLength(0);
                this.dataType = NavOption.Create(SetInputType_Scope_1083521742_dataType_metadata, dataType);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 1), this.inputControlID, new NavText(base.Parent._InputEntities.Target.ALFieldName(14)), this.dataType });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1304663155")]
        public void SetLanguage(NavCode language)
        {
            using (SetLanguage_Scope__760945027 \u03b2scope = new SetLanguage_Scope__760945027(this, language))
                \u03b2scope.Run();
        }

        [NavName("SetLanguage")]
        [SignatureSpan(1185009712357310489L)]
        [SourceSpans(1186417074356289561L, 1186698553628033086L, 1187261499286618150L, 1187542978558361640L, 1187824453535137828L, 1188105928511914050L, 1188668878465794064L, 1188950370622111791L, 1189231845598953550L, 1189794795552440415L, 1190076253349347343L, 1190639203302899752L, 1190920678279675946L, 1191202153256452195L, 1191765103210201104L, 1192046595366649903L, 1192328070343426143L, 1192609528140333071L, 1192891003117109288L, 1193453931595825160L)]
        private sealed class SetLanguage_Scope__760945027 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("language")]
            public NavCode language;
            [NavName("recid")]
            public NavRecordId recid = NavRecordId.Default;
            [NavName("found")]
            public bool found = default(bool);
            protected override uint RawScopeId { get => SetLanguage_Scope__760945027.\u03b1scopeId; set => SetLanguage_Scope__760945027.\u03b1scopeId = value; }

            internal SetLanguage_Scope__760945027(Codeunit10012739 \u03b2parent, NavCode language) : base(\u03b2parent)
            {
                this.language = language.ModifyLength(10);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetLanguage(%1)", this.language)));
                }

                if (CStmtHit(2) & (base.Parent._ActiveLanguage != this.language))
                {
                    StmtHit(3);
                    base.Parent._ActiveLanguage = new NavText(this.language);
                    StmtHit(4);
                    base.Parent.languagePending = true;
                    StmtHit(5);
                    base.Parent.LogDebug(new NavText("_ActiveLanguage set to " + base.Parent._ActiveLanguage));
                    StmtHit(6);
                    foreach (var @tmp0 in base.Parent._TranslatedMenuButtons)
                    {
                        this.recid = @tmp0;
                        {
                            CStmtHit(7);
                            base.Parent._MenuButtonEntities.Target.ALGet(DataError.ThrowError, this.recid);
                            StmtHit(8);
                            base.Parent.MenuButtonRequest(new NavText(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(10, NavType.Code))), new NavText(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code))), base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(2, NavType.Integer).ToInt32(), base.Parent._MenuButtonEntities, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                            StmtHit(9);
                            base.Parent.RefreshMenuButton(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code)), base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(2, NavType.Integer).ToInt32());
                        }
                    }

                    StmtHit(10);
                    StmtHit(11);
                    base.Parent._MenuButtonEntities.Target.ALReset();
                    StmtHit(12);
                    base.Parent._TranslatedMenuButtons = NavList<NavRecordId>.Default;
                    StmtHit(13);
                    base.Parent.ButtonTranslationRequest(base.Parent._ActiveLanguage, base.Parent._MenuButtonEntities, new ByRef<NavList<NavRecordId>>(() => base.Parent._TranslatedMenuButtons, setValue => base.Parent._TranslatedMenuButtons = setValue));
                    StmtHit(14);
                    foreach (var @tmp1 in base.Parent._TranslatedMenuButtons)
                    {
                        this.recid = @tmp1;
                        {
                            CStmtHit(15);
                            base.Parent._MenuButtonEntities.Target.ALGet(DataError.ThrowError, this.recid);
                            StmtHit(16);
                            base.Parent.RefreshMenuButton(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code)), base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(2, NavType.Integer).ToInt32());
                        }
                    }

                    StmtHit(17);
                    StmtHit(18);
                    base.Parent._MenuButtonEntities.Target.ALReset();
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4218014567")]
        public void SetLogLevel(int logLevel)
        {
            using (SetLogLevel_Scope_1645083635 \u03b2scope = new SetLogLevel_Scope_1645083635(this, logLevel))
                \u03b2scope.Run();
        }

        [NavName("SetLogLevel")]
        [SignatureSpan(298082060535529497L)]
        [SourceSpans(298644984719278111L, 298926455401086984L)]
        private sealed class SetLogLevel_Scope_1645083635 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("LogLevel")]
            public int logLevel;
            protected override uint RawScopeId { get => SetLogLevel_Scope_1645083635.\u03b1scopeId; set => SetLogLevel_Scope_1645083635.\u03b1scopeId = value; }

            internal SetLogLevel_Scope_1645083635(Codeunit10012739 \u03b2parent, int logLevel) : base(\u03b2parent)
            {
                this.logLevel = logLevel;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.__LogLevel = this.logLevel;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 246649693")]
        public void SetLookupAssistValue(NavText pValue)
        {
            using (SetLookupAssistValue_Scope_23642758 \u03b2scope = new SetLookupAssistValue_Scope_23642758(this, pValue))
                \u03b2scope.Run();
        }

        [NavName("SetLookupAssistValue")]
        [SignatureSpan(922675034001899554L)]
        [SourceSpans(923237958185648181L, 923519428867457032L)]
        private sealed class SetLookupAssistValue_Scope_23642758 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pValue")]
            public NavText pValue;
            protected override uint RawScopeId { get => SetLookupAssistValue_Scope_23642758.\u03b1scopeId; set => SetLookupAssistValue_Scope_23642758.\u03b1scopeId = value; }

            internal SetLookupAssistValue_Scope_23642758(Codeunit10012739 \u03b2parent, NavText pValue) : base(\u03b2parent)
            {
                this.pValue = pValue.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.SendPOSCommandEvent(new NavText("_SETLOOKUPVAL"), this.pValue);
            }
        }

        private void SetMainControlValue_1888936601(NavText pFieldName, int pValue)
        {
            using (SetMainControlValue_Scope_1888936601 \u03b2scope = new SetMainControlValue_Scope_1888936601(this, pFieldName, pValue))
                \u03b2scope.Run();
        }

        [NavName("SetMainControlValue")]
        [SignatureSpan(85849953816084519L)]
        [SourceSpans(86412865114931225L, 86694344386674772L, 87257277160358017L, 87538747842166792L)]
        private sealed class SetMainControlValue_Scope_1888936601 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pFieldName")]
            public NavText pFieldName;
            [NavName("pValue")]
            public int pValue;
            protected override uint RawScopeId { get => SetMainControlValue_Scope_1888936601.\u03b1scopeId; set => SetMainControlValue_Scope_1888936601.\u03b1scopeId = value; }

            internal SetMainControlValue_Scope_1888936601(Codeunit10012739 \u03b2parent, NavText pFieldName, int pValue) : base(\u03b2parent)
            {
                this.pFieldName = pFieldName.ModifyLength(0);
                this.pValue = pValue;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetMainControlValue(%1, %2)", this.pFieldName, ALCompiler.ToNavValue(this.pValue))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 98), new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 2)))), this.pFieldName, this.pValue });
            }
        }

        private void SetMainControlValue_1888936603(NavText pFieldName, Decimal18 pValue)
        {
            using (SetMainControlValue_Scope_1888936603 \u03b2scope = new SetMainControlValue_Scope_1888936603(this, pFieldName, pValue))
                \u03b2scope.Run();
        }

        [NavName("SetMainControlValue")]
        [SignatureSpan(88101753630294055L)]
        [SourceSpans(88664664929140761L, 88946144200884308L, 89509076974567553L, 89790547656376328L)]
        private sealed class SetMainControlValue_Scope_1888936603 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pFieldName")]
            public NavText pFieldName;
            [NavName("pValue")]
            public Decimal18 pValue;
            protected override uint RawScopeId { get => SetMainControlValue_Scope_1888936603.\u03b1scopeId; set => SetMainControlValue_Scope_1888936603.\u03b1scopeId = value; }

            internal SetMainControlValue_Scope_1888936603(Codeunit10012739 \u03b2parent, NavText pFieldName, Decimal18 pValue) : base(\u03b2parent)
            {
                this.pFieldName = pFieldName.ModifyLength(0);
                this.pValue = pValue;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetMainControlValue(%1, %2)", this.pFieldName, ALCompiler.ToNavValue(this.pValue))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 98), new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 2)))), this.pFieldName, this.pValue });
            }
        }

        private void SetMainControlValue(NavText pFieldName, bool pValue)
        {
            using (SetMainControlValue_Scope_1888936606 \u03b2scope = new SetMainControlValue_Scope_1888936606(this, pFieldName, pValue))
                \u03b2scope.Run();
        }

        [NavName("SetMainControlValue")]
        [SignatureSpan(83598154001874983L)]
        [SourceSpans(84161065300721689L, 84442544572465236L, 85005477346148479L, 85286948027957256L)]
        private sealed class SetMainControlValue_Scope_1888936606 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pFieldName")]
            public NavText pFieldName;
            [NavName("pValue")]
            public bool pValue;
            protected override uint RawScopeId { get => SetMainControlValue_Scope_1888936606.\u03b1scopeId; set => SetMainControlValue_Scope_1888936606.\u03b1scopeId = value; }

            internal SetMainControlValue_Scope_1888936606(Codeunit10012739 \u03b2parent, NavText pFieldName, bool pValue) : base(\u03b2parent)
            {
                this.pFieldName = pFieldName.ModifyLength(0);
                this.pValue = pValue;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetMainControlValue(%1, %2)", this.pFieldName, ALCompiler.ToNavValue(this.pValue))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1410208911, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 98), new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 2)))), this.pFieldName, this.pValue });
            }
        }

        private void SetMainControlValue_1893130901(NavText pFieldName, NavText pValue)
        {
            using (SetMainControlValue_Scope_1893130901 \u03b2scope = new SetMainControlValue_Scope_1893130901(this, pFieldName, pValue))
                \u03b2scope.Run();
        }

        [NavName("SetMainControlValue")]
        [SignatureSpan(90353553444503591L)]
        [SourceSpans(90916464743350297L, 91197944015093844L, 91760876788777087L, 92042347470585864L)]
        private sealed class SetMainControlValue_Scope_1893130901 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pFieldName")]
            public NavText pFieldName;
            [NavName("pValue")]
            public NavText pValue;
            protected override uint RawScopeId { get => SetMainControlValue_Scope_1893130901.\u03b1scopeId; set => SetMainControlValue_Scope_1893130901.\u03b1scopeId = value; }

            internal SetMainControlValue_Scope_1893130901(Codeunit10012739 \u03b2parent, NavText pFieldName, NavText pValue) : base(\u03b2parent)
            {
                this.pFieldName = pFieldName.ModifyLength(0);
                this.pValue = pValue.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetMainControlValue(%1, %2)", this.pFieldName, this.pValue)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 98), new NavText(NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 2)))), this.pFieldName, this.pValue });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3521837772")]
        public void SetMenuBackgroundImage(NavCode pMenuID, NavText pImageUri)
        {
            using (SetMenuBackgroundImage_Scope_565192747 \u03b2scope = new SetMenuBackgroundImage_Scope_565192747(this, pMenuID, pImageUri))
                \u03b2scope.Run();
        }

        [NavName("SetMenuBackgroundImage")]
        [SignatureSpan(1062849572436443172L)]
        [SourceSpans(1063412509505093657L, 1063693988776837207L, 1064256921550520456L, 1064538392232329224L)]
        private sealed class SetMenuBackgroundImage_Scope_565192747 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [NavName("pImageUri")]
            public NavText pImageUri;
            protected override uint RawScopeId { get => SetMenuBackgroundImage_Scope_565192747.\u03b1scopeId; set => SetMenuBackgroundImage_Scope_565192747.\u03b1scopeId = value; }

            internal SetMenuBackgroundImage_Scope_565192747(Codeunit10012739 \u03b2parent, NavCode pMenuID, NavText pImageUri) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
                this.pImageUri = pImageUri.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetMenuBackgroundImage(%1, %2)", this.pMenuID, this.pImageUri)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), new NavText(this.pMenuID), new NavText(base.Parent._MenuEntities.Target.ALFieldName(62)), this.pImageUri });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1583250773")]
        public void SetMenuButtonSpacing(NavText pMenuID, int pNewValue)
        {
            using (SetMenuButtonSpacing_Scope__594963758 \u03b2scope = new SetMenuButtonSpacing_Scope__594963758(this, pMenuID, pNewValue))
                \u03b2scope.Run();
        }

        [NavName("SetMenuButtonSpacing")]
        [SignatureSpan(794885394545508386L)]
        [SourceSpans(795448318729257093L, 795729789411065864L)]
        private sealed class SetMenuButtonSpacing_Scope__594963758 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pNewValue")]
            public int pNewValue;
            protected override uint RawScopeId { get => SetMenuButtonSpacing_Scope__594963758.\u03b1scopeId; set => SetMenuButtonSpacing_Scope__594963758.\u03b1scopeId = value; }

            internal SetMenuButtonSpacing_Scope__594963758(Codeunit10012739 \u03b2parent, NavText pMenuID, int pNewValue) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pNewValue = pNewValue;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), this.pMenuID, new NavText(base.Parent._MenuEntities.Target.ALFieldName(300)), this.pNewValue });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1413861449")]
        public void SetMenuDesignMode(NavCode pMenuID, bool pDesignMode)
        {
            using (SetMenuDesignMode_Scope_522608884 \u03b2scope = new SetMenuDesignMode_Scope_522608884(this, pMenuID, pDesignMode))
                \u03b2scope.Run();
        }

        [NavName("SetMenuDesignMode")]
        [SignatureSpan(1056094172993814559L)]
        [SourceSpans(1056657110062465049L, 1056938589334208596L, 1057501522107891838L, 1057782992789700616L)]
        private sealed class SetMenuDesignMode_Scope_522608884 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [NavName("pDesignMode")]
            public bool pDesignMode;
            protected override uint RawScopeId { get => SetMenuDesignMode_Scope_522608884.\u03b1scopeId; set => SetMenuDesignMode_Scope_522608884.\u03b1scopeId = value; }

            internal SetMenuDesignMode_Scope_522608884(Codeunit10012739 \u03b2parent, NavCode pMenuID, bool pDesignMode) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
                this.pDesignMode = pDesignMode;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetMenuDesignMode(%1, %2)", this.pMenuID, ALCompiler.ToNavValue(this.pDesignMode))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1410208911, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), new NavText(this.pMenuID), new NavText(base.Parent._MenuEntities.Target.ALFieldName(3010)), this.pDesignMode });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1769414140")]
        public void SetMenuDragDropEnabled(NavCode pMenuID, bool pEnabled)
        {
            using (SetMenuDragDropEnabled_Scope__1069284296 \u03b2scope = new SetMenuDragDropEnabled_Scope__1069284296(this, pMenuID, pEnabled))
                \u03b2scope.Run();
        }

        [NavName("SetMenuDragDropEnabled")]
        [SignatureSpan(1060597772622233636L)]
        [SourceSpans(1061160709690884121L, 1061442188962627670L, 1062005121736310916L, 1062286592418119688L)]
        private sealed class SetMenuDragDropEnabled_Scope__1069284296 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [NavName("pEnabled")]
            public bool pEnabled;
            protected override uint RawScopeId { get => SetMenuDragDropEnabled_Scope__1069284296.\u03b1scopeId; set => SetMenuDragDropEnabled_Scope__1069284296.\u03b1scopeId = value; }

            internal SetMenuDragDropEnabled_Scope__1069284296(Codeunit10012739 \u03b2parent, NavCode pMenuID, bool pEnabled) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
                this.pEnabled = pEnabled;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetMenuDragDropEnabled(%1, %2)", this.pMenuID, ALCompiler.ToNavValue(this.pEnabled))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1410208911, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), new NavText(this.pMenuID), new NavText(base.Parent._MenuEntities.Target.ALFieldName(328)), this.pEnabled });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3587099417")]
        public void SetMenuLayoutStyle(NavCode pMenuID, int pLayoutStyle)
        {
            using (SetMenuLayoutStyle_Scope__1396412752 \u03b2scope = new SetMenuLayoutStyle_Scope__1396412752(this, pMenuID, pLayoutStyle))
                \u03b2scope.Run();
        }

        [NavName("SetMenuLayoutStyle")]
        [SignatureSpan(1058345972808024096L)]
        [SourceSpans(1058908909876674585L, 1059190389148418134L, 1059753321922101379L, 1060034792603910152L)]
        private sealed class SetMenuLayoutStyle_Scope__1396412752 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [NavName("pLayoutStyle")]
            public int pLayoutStyle;
            protected override uint RawScopeId { get => SetMenuLayoutStyle_Scope__1396412752.\u03b1scopeId; set => SetMenuLayoutStyle_Scope__1396412752.\u03b1scopeId = value; }

            internal SetMenuLayoutStyle_Scope__1396412752(Codeunit10012739 \u03b2parent, NavCode pMenuID, int pLayoutStyle) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
                this.pLayoutStyle = pLayoutStyle;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetMenuLayoutStyle(%1, %2)", this.pMenuID, ALCompiler.ToNavValue(this.pLayoutStyle))));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), new NavText(this.pMenuID), new NavText(base.Parent._MenuEntities.Target.ALFieldName(70)), this.pLayoutStyle });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 292273413")]
        public void SetMenuVisible(NavText pMenuID, bool pVisible)
        {
            using (SetMenuVisible_Scope_326346580 \u03b2scope = new SetMenuVisible_Scope_326346580(this, pMenuID, pVisible))
                \u03b2scope.Run();
        }

        [NavName("SetMenuVisible")]
        [SignatureSpan(789818844963536924L)]
        [SourceSpans(790381769147285552L, 790663239829094408L)]
        private sealed class SetMenuVisible_Scope_326346580 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pVisible")]
            public bool pVisible;
            protected override uint RawScopeId { get => SetMenuVisible_Scope_326346580.\u03b1scopeId; set => SetMenuVisible_Scope_326346580.\u03b1scopeId = value; }

            internal SetMenuVisible_Scope_326346580(Codeunit10012739 \u03b2parent, NavText pMenuID, bool pVisible) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pVisible = pVisible;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.SetMenuVisible_1628810055(this.pMenuID, this.pVisible, true);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2468932379")]
        public void SetMenuVisible_1628810055(NavText pMenuID, bool pVisible, bool pClearPosition)
        {
            using (SetMenuVisible_Scope__1628810055 \u03b2scope = new SetMenuVisible_Scope__1628810055(this, pMenuID, pVisible, pClearPosition))
                \u03b2scope.Run();
        }

        [NavName("SetMenuVisible")]
        [SignatureSpan(791226219847417884L)]
        [SourceSpans(791789156916068377L, 792070636187811938L, 792633581846396951L, 792915061118140433L, 793478006776725527L, 793759498933370909L, 794040978205114489L, 794322414527184904L)]
        private sealed class SetMenuVisible_Scope__1628810055 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pVisible")]
            public bool pVisible;
            [NavName("pClearPosition")]
            public bool pClearPosition;
            protected override uint RawScopeId { get => SetMenuVisible_Scope__1628810055.\u03b1scopeId; set => SetMenuVisible_Scope__1628810055.\u03b1scopeId = value; }

            internal SetMenuVisible_Scope__1628810055(Codeunit10012739 \u03b2parent, NavText pMenuID, bool pVisible, bool pClearPosition) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pVisible = pVisible;
                this.pClearPosition = pClearPosition;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetMenuVisible(%1, %2, %3)", this.pMenuID, ALCompiler.ToNavValue(this.pVisible), ALCompiler.ToNavValue(this.pClearPosition))));
                }

                if (CStmtHit(2) & (this.pMenuID == ""))
                {
                    StmtHit(3);
                    return;
                }

                if (CStmtHit(4) & (!this.pVisible))
                    if (CStmtHit(5) & (this.pClearPosition))
                    {
                        StmtHit(6);
                        base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), this.pMenuID, new NavText(base.Parent._SHARED.Target.ALFieldName(20)), new NavText("") });
                    }
            }
        }

        private static NCLOptionMetadata SetPanelColumnWidth_Scope__1891276771_pSizeType_metadata = NCLOptionMetadata.Create(",Pixel,Percent");
        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3008652906")]
        public void SetPanelColumnWidth(NavText pPanelID, int pColumn, int pSizeType, int pSize)
        {
            using (SetPanelColumnWidth_Scope__1891276771 \u03b2scope = new SetPanelColumnWidth_Scope__1891276771(this, pPanelID, pColumn, pSizeType, pSize))
                \u03b2scope.Run();
        }

        [NavName("SetPanelColumnWidth")]
        [SignatureSpan(653022006250307617L)]
        [SourceSpans(653584943318958144L, 653866422590701631L, 654147897567477806L, 654429372544254005L, 654710847521030187L, 655273780294713401L, 655555255271489582L, 655836730248265767L, 656118200930074632L)]
        private sealed class SetPanelColumnWidth_Scope__1891276771 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("pColumn")]
            public int pColumn;
            [NavName("pSizeType")]
            public NavOption pSizeType;
            [NavName("pSize")]
            public int pSize;
            protected override uint RawScopeId { get => SetPanelColumnWidth_Scope__1891276771.\u03b1scopeId; set => SetPanelColumnWidth_Scope__1891276771.\u03b1scopeId = value; }

            internal SetPanelColumnWidth_Scope__1891276771(Codeunit10012739 \u03b2parent, NavText pPanelID, int pColumn, int pSizeType, int pSize) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.pColumn = pColumn;
                this.pSizeType = NavOption.Create(SetPanelColumnWidth_Scope__1891276771_pSizeType_metadata, pSizeType);
                this.pSize = pSize;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!base.Parent._PanelRowColumnEntities.Target.ALGet(DataError.TrapError, this.pPanelID, ALCompiler.ToNavValue(0), ALCompiler.ToNavValue(this.pColumn))))
                {
                    StmtHit(1);
                    base.Parent._PanelRowColumnEntities.Target.SetFieldValueSafe(2, NavType.Code, new NavCode(25, this.pPanelID));
                    StmtHit(2);
                    base.Parent._PanelRowColumnEntities.Target.SetFieldValueSafe(3, NavType.Option, NavOption.Create(((NavOption)base.Parent._PanelRowColumnEntities.Target.GetFieldValueSafe(3, NavType.Option)).NavOptionMetadata, 0));
                    StmtHit(3);
                    base.Parent._PanelRowColumnEntities.Target.SetFieldValueSafe(4, NavType.Integer, ALCompiler.ToNavValue(this.pColumn));
                    StmtHit(4);
                    base.Parent._PanelRowColumnEntities.Target.ALInsert(DataError.ThrowError);
                }

                StmtHit(5);
                base.Parent._PanelRowColumnEntities.Target.SetFieldValueSafe(5, NavType.Option, NavOption.Create(((NavOption)base.Parent._PanelRowColumnEntities.Target.GetFieldValueSafe(5, NavType.Option)).NavOptionMetadata, this.pSizeType));
                StmtHit(6);
                base.Parent._PanelRowColumnEntities.Target.SetFieldValueSafe(6, NavType.Integer, ALCompiler.ToNavValue(this.pSize));
                StmtHit(7);
                base.Parent._PanelRowColumnEntities.Target.ALModify(DataError.ThrowError);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4281926380")]
        public void SetPanelColumns(NavText pPanelID, int pNewValue)
        {
            using (SetPanelColumns_Scope_1128159546 \u03b2scope = new SetPanelColumns_Scope_1128159546(this, pPanelID, pNewValue))
                \u03b2scope.Run();
        }

        [NavName("SetPanelColumns")]
        [SignatureSpan(656681180948398109L)]
        [SourceSpans(657244118017048600L, 657525597288792091L, 658088530062475398L, 658370000744284168L)]
        private sealed class SetPanelColumns_Scope_1128159546 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("pNewValue")]
            public int pNewValue;
            protected override uint RawScopeId { get => SetPanelColumns_Scope_1128159546.\u03b1scopeId; set => SetPanelColumns_Scope_1128159546.\u03b1scopeId = value; }

            internal SetPanelColumns_Scope_1128159546(Codeunit10012739 \u03b2parent, NavText pPanelID, int pNewValue) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.pNewValue = pNewValue;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.pNewValue < 1))
                {
                    StmtHit(1);
                    this.pNewValue = 1;
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2), this.pPanelID, new NavText(base.Parent._PanelEntities.Target.ALFieldName(3)), this.pNewValue });
            }
        }

        private static NCLOptionMetadata SetPanelRowHeight_Scope_321882841_pSizeType_metadata = NCLOptionMetadata.Create(",Pixel,Percent");
        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4074323881")]
        public void SetPanelRowHeight(NavText pPanelID, int pRow, int pSizeType, int pSize)
        {
            using (SetPanelRowHeight_Scope_321882841 \u03b2scope = new SetPanelRowHeight_Scope_321882841(this, pPanelID, pRow, pSizeType, pSize))
                \u03b2scope.Run();
        }

        [NavName("SetPanelRowHeight")]
        [SignatureSpan(649362831552217119L)]
        [SourceSpans(649925768620867645L, 650207247892611135L, 650488722869387310L, 650770197846163506L, 651051672822939691L, 651614605596622905L, 651896080573399086L, 652177555550175271L, 652459026231984136L)]
        private sealed class SetPanelRowHeight_Scope_321882841 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("pRow")]
            public int pRow;
            [NavName("pSizeType")]
            public NavOption pSizeType;
            [NavName("pSize")]
            public int pSize;
            protected override uint RawScopeId { get => SetPanelRowHeight_Scope_321882841.\u03b1scopeId; set => SetPanelRowHeight_Scope_321882841.\u03b1scopeId = value; }

            internal SetPanelRowHeight_Scope_321882841(Codeunit10012739 \u03b2parent, NavText pPanelID, int pRow, int pSizeType, int pSize) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.pRow = pRow;
                this.pSizeType = NavOption.Create(SetPanelRowHeight_Scope_321882841_pSizeType_metadata, pSizeType);
                this.pSize = pSize;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!base.Parent._PanelRowColumnEntities.Target.ALGet(DataError.TrapError, this.pPanelID, ALCompiler.ToNavValue(1), ALCompiler.ToNavValue(this.pRow))))
                {
                    StmtHit(1);
                    base.Parent._PanelRowColumnEntities.Target.SetFieldValueSafe(2, NavType.Code, new NavCode(25, this.pPanelID));
                    StmtHit(2);
                    base.Parent._PanelRowColumnEntities.Target.SetFieldValueSafe(3, NavType.Option, NavOption.Create(((NavOption)base.Parent._PanelRowColumnEntities.Target.GetFieldValueSafe(3, NavType.Option)).NavOptionMetadata, 1));
                    StmtHit(3);
                    base.Parent._PanelRowColumnEntities.Target.SetFieldValueSafe(4, NavType.Integer, ALCompiler.ToNavValue(this.pRow));
                    StmtHit(4);
                    base.Parent._PanelRowColumnEntities.Target.ALInsert(DataError.ThrowError);
                }

                StmtHit(5);
                base.Parent._PanelRowColumnEntities.Target.SetFieldValueSafe(5, NavType.Option, NavOption.Create(((NavOption)base.Parent._PanelRowColumnEntities.Target.GetFieldValueSafe(5, NavType.Option)).NavOptionMetadata, this.pSizeType));
                StmtHit(6);
                base.Parent._PanelRowColumnEntities.Target.SetFieldValueSafe(6, NavType.Integer, ALCompiler.ToNavValue(this.pSize));
                StmtHit(7);
                base.Parent._PanelRowColumnEntities.Target.ALModify(DataError.ThrowError);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2445076625")]
        public void SetPanelRows(NavText pPanelID, int pNewValue)
        {
            using (SetPanelRows_Scope__813361756 \u03b2scope = new SetPanelRows_Scope__813361756(this, pPanelID, pNewValue))
                \u03b2scope.Run();
        }

        [NavName("SetPanelRows")]
        [SignatureSpan(658932980762607642L)]
        [SourceSpans(659495917831258136L, 659777397103001627L, 660340329876684931L, 660621800558493704L)]
        private sealed class SetPanelRows_Scope__813361756 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("pNewValue")]
            public int pNewValue;
            protected override uint RawScopeId { get => SetPanelRows_Scope__813361756.\u03b1scopeId; set => SetPanelRows_Scope__813361756.\u03b1scopeId = value; }

            internal SetPanelRows_Scope__813361756(Codeunit10012739 \u03b2parent, NavText pPanelID, int pNewValue) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.pNewValue = pNewValue;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.pNewValue < 1))
                {
                    StmtHit(1);
                    this.pNewValue = 1;
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2), this.pPanelID, new NavText(base.Parent._PanelEntities.Target.ALFieldName(4)), this.pNewValue });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 32063404")]
        public void SetPosCtrlActiveInteraceProfile(NavText pPrimaryProfileID, NavText pSecondaryProfileID)
        {
            using (SetPosCtrlActiveInteraceProfile_Scope__473009837 \u03b2scope = new SetPosCtrlActiveInteraceProfile_Scope__473009837(this, pPrimaryProfileID, pSecondaryProfileID))
                \u03b2scope.Run();
        }

        [NavName("SetPosCtrlActiveInteraceProfile")]
        [SignatureSpan(966585130378985517L)]
        [SourceSpans(968273967354740761L, 968555446626484340L, 969118392285069363L, 969399871556812853L, 969681346533589020L, 970525767168950330L, 970807246440693820L, 971088721417469980L, 971933142052831250L, 972214621324574818L, 972496096301350955L, 972777571278127189L, 973059046254903334L, 973621974733619208L)]
        private sealed class SetPosCtrlActiveInteraceProfile_Scope__473009837 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPrimaryProfileID")]
            public NavText pPrimaryProfileID;
            [NavName("pSecondaryProfileID")]
            public NavText pSecondaryProfileID;
            [NavName("ProfileEntity")]
            public INavRecordHandle profileEntity;
            [NavName("RecRef")]
            public NavRecordRef recRef;
            [NavName("refresh")]
            public bool refresh = default(bool);
            protected override uint RawScopeId { get => SetPosCtrlActiveInteraceProfile_Scope__473009837.\u03b1scopeId; set => SetPosCtrlActiveInteraceProfile_Scope__473009837.\u03b1scopeId = value; }

            internal SetPosCtrlActiveInteraceProfile_Scope__473009837(Codeunit10012739 \u03b2parent, NavText pPrimaryProfileID, NavText pSecondaryProfileID) : base(\u03b2parent)
            {
                this.pPrimaryProfileID = pPrimaryProfileID.ModifyLength(0);
                this.pSecondaryProfileID = pSecondaryProfileID.ModifyLength(0);
                this.profileEntity = new NavRecordHandle(this, 99008881, false, SecurityFiltering.Validated);
                this.recRef = new NavRecordRef(this, SecurityFiltering.Validated);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetPosCtrlActiveInteraceProfile(%1, %2)", this.pPrimaryProfileID, this.pSecondaryProfileID)));
                }

                if (CStmtHit(2) & (base.Parent._InterfaceProfileID != this.pPrimaryProfileID))
                {
                    StmtHit(3);
                    base.Parent._InterfaceProfileID = this.pPrimaryProfileID;
                    StmtHit(4);
                    this.refresh = true;
                }

                if (CStmtHit(5) & (base.Parent._StoreInterfaceProfileID != this.pSecondaryProfileID))
                {
                    StmtHit(6);
                    base.Parent._StoreInterfaceProfileID = this.pSecondaryProfileID;
                    StmtHit(7);
                    this.refresh = true;
                }

                if (CStmtHit(8) & (this.refresh))
                {
                    StmtHit(9);
                    base.Parent.InterfaceProfileRequest(base.Parent._InterfaceProfileID, base.Parent._StoreInterfaceProfileID, this.profileEntity);
                    StmtHit(10);
                    this.recRef.ALGetTable(this.profileEntity.Target);
                    StmtHit(11);
                    base.Parent.pendingPOSData.ALAdd(ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(-506675773, new object[] { new NavText("InterfaceProfile"), new ByRef<NavRecordRef>(() => this.recRef, setValue => this.recRef.ALAssign(setValue)) })));
                    StmtHit(12);
                    base.Parent.RefreshInterfaceProfile();
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2914751172")]
        public void SetPosCtrlActiveMenuProfile(NavText pPrimaryProfileID, NavText pSecondaryProfileID)
        {
            using (SetPosCtrlActiveMenuProfile_Scope__2021536941 \u03b2scope = new SetPosCtrlActiveMenuProfile_Scope__2021536941(this, pPrimaryProfileID, pSecondaryProfileID))
                \u03b2scope.Run();
        }

        [NavName("SetPosCtrlActiveMenuProfile")]
        [SignatureSpan(974184954751942697L)]
        [SourceSpans(975310841774145561L, 975592321045889136L, 976155266704474158L, 976436745976217648L, 976718220952993820L, 977562641588355125L, 977844120860098615L, 978125595836874780L, 978970016472236050L, 979251495743979553L, 979532949245919240L)]
        private sealed class SetPosCtrlActiveMenuProfile_Scope__2021536941 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPrimaryProfileID")]
            public NavText pPrimaryProfileID;
            [NavName("pSecondaryProfileID")]
            public NavText pSecondaryProfileID;
            [NavName("refresh")]
            public bool refresh = default(bool);
            protected override uint RawScopeId { get => SetPosCtrlActiveMenuProfile_Scope__2021536941.\u03b1scopeId; set => SetPosCtrlActiveMenuProfile_Scope__2021536941.\u03b1scopeId = value; }

            internal SetPosCtrlActiveMenuProfile_Scope__2021536941(Codeunit10012739 \u03b2parent, NavText pPrimaryProfileID, NavText pSecondaryProfileID) : base(\u03b2parent)
            {
                this.pPrimaryProfileID = pPrimaryProfileID.ModifyLength(0);
                this.pSecondaryProfileID = pSecondaryProfileID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetPosCtrlActiveMenuProfile(%1, %2)", this.pPrimaryProfileID, this.pSecondaryProfileID)));
                }

                if (CStmtHit(2) & (base.Parent._MenuProfileID != this.pPrimaryProfileID))
                {
                    StmtHit(3);
                    base.Parent._MenuProfileID = this.pPrimaryProfileID;
                    StmtHit(4);
                    this.refresh = true;
                }

                if (CStmtHit(5) & (base.Parent._StoreMenuProfileID != this.pSecondaryProfileID))
                {
                    StmtHit(6);
                    base.Parent._StoreMenuProfileID = this.pSecondaryProfileID;
                    StmtHit(7);
                    this.refresh = true;
                }

                if (CStmtHit(8) & (this.refresh))
                {
                    StmtHit(9);
                    base.Parent.RefreshMenuProfile();
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4088457324")]
        public void SetPosCtrlActiveStyle(NavText pPrimaryProfileID, NavText pSecondaryProfileID)
        {
            using (SetPosCtrlActiveStyle_Scope__255122583 \u03b2scope = new SetPosCtrlActiveStyle_Scope__255122583(this, pPrimaryProfileID, pSecondaryProfileID))
                \u03b2scope.Run();
        }

        [NavName("SetPosCtrlActiveStyle")]
        [SignatureSpan(986569853730095139L)]
        [SourceSpans(987132790798745625L, 987414270070489194L, 987977215729074223L, 988258695000817713L, 988540169977593896L, 989384590612955190L, 989666069884698680L, 989947544861474856L, 990510473340190728L)]
        private sealed class SetPosCtrlActiveStyle_Scope__255122583 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPrimaryProfileID")]
            public NavText pPrimaryProfileID;
            [NavName("pSecondaryProfileID")]
            public NavText pSecondaryProfileID;
            protected override uint RawScopeId { get => SetPosCtrlActiveStyle_Scope__255122583.\u03b1scopeId; set => SetPosCtrlActiveStyle_Scope__255122583.\u03b1scopeId = value; }

            internal SetPosCtrlActiveStyle_Scope__255122583(Codeunit10012739 \u03b2parent, NavText pPrimaryProfileID, NavText pSecondaryProfileID) : base(\u03b2parent)
            {
                this.pPrimaryProfileID = pPrimaryProfileID.ModifyLength(0);
                this.pSecondaryProfileID = pSecondaryProfileID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetPosCtrlActiveStyle(%1, %2)", this.pPrimaryProfileID, this.pSecondaryProfileID)));
                }

                if (CStmtHit(2) & (base.Parent._StyleProfileID != this.pPrimaryProfileID))
                {
                    StmtHit(3);
                    base.Parent._StyleProfileID = this.pPrimaryProfileID;
                    StmtHit(4);
                    base.Parent.styleProfilePending = true;
                }

                if (CStmtHit(5) & (base.Parent._StoreStyleProfileID != this.pSecondaryProfileID))
                {
                    StmtHit(6);
                    base.Parent._StoreStyleProfileID = this.pSecondaryProfileID;
                    StmtHit(7);
                    base.Parent.styleProfilePending = true;
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2122382911")]
        public void SetPosDesignMode(bool pDesignMode)
        {
            using (SetPosDesignMode_Scope_1716864790 \u03b2scope = new SetPosDesignMode_Scope_1716864790(this, pDesignMode))
                \u03b2scope.Run();
        }

        [NavName("SetPosDesignMode")]
        [SignatureSpan(1053842373179605022L)]
        [SourceSpans(1054405310248255513L, 1054686789519999046L, 1055249722293682246L, 1055531192975491080L)]
        private sealed class SetPosDesignMode_Scope_1716864790 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pDesignMode")]
            public bool pDesignMode;
            protected override uint RawScopeId { get => SetPosDesignMode_Scope_1716864790.\u03b1scopeId; set => SetPosDesignMode_Scope_1716864790.\u03b1scopeId = value; }

            internal SetPosDesignMode_Scope_1716864790(Codeunit10012739 \u03b2parent, bool pDesignMode) : base(\u03b2parent)
            {
                this.pDesignMode = pDesignMode;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetPosDesignMode(%1)", ALCompiler.ToNavValue(this.pDesignMode))));
                }

                StmtHit(2);
                base.Parent.SetMainControlValue(new NavText(base.Parent._POS.Target.ALFieldName(25)), this.pDesignMode);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2430229192")]
        public NavText SetPosImageUrl(NavOption pControlType, NavText pControlID, NavText pURL)
        {
            using (SetPosImageUrl_Scope__1475021588 \u03b2scope = new SetPosImageUrl_Scope__1475021588(this, pControlType, pControlID, pURL))
            {
                \u03b2scope.Run();
                return \u03b2scope.imgCode;
            }
        }

        [NavName("SetPosImageUrl")]
        [SignatureSpan(852024853485781029L)]
        [SourceSpans(853995126783868938L, 855402505962455057L, 855965438736138302L, 856246913712914482L, 856528388689690652L, 856809863666466841L, 857372813620019255L, 857654288596795441L, 858217251435249687L, 858498743591895069L, 858780222863638705L, 859061659185709064L)]
        private sealed class SetPosImageUrl_Scope__1475021588 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pURL")]
            public NavText pURL;
            [ReturnValue("imgCode")]
            [NavName("imgCode")]
            public NavText imgCode = NavText.Default(0);
            [NavName("oldUrl")]
            public NavText oldUrl = NavText.Default(0);
            [NavName("jObj")]
            public NavJsonObject jObj;
            [NavName("jTok")]
            public NavJsonToken jTok;
            [NavName("Crypto")]
            public NavCodeunitHandle crypto;
            protected override uint RawScopeId { get => SetPosImageUrl_Scope__1475021588.\u03b1scopeId; set => SetPosImageUrl_Scope__1475021588.\u03b1scopeId = value; }

            internal SetPosImageUrl_Scope__1475021588(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID, NavText pURL) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
                this.pURL = pURL.ModifyLength(0);
                this.jObj = NavJsonObject.Default;
                this.jTok = NavJsonToken.Default;
                this.crypto = new NavCodeunitHandle(this, 1266);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!((this.pControlType.CompareTo(NavOption.Create(this.pControlType.NavOptionMetadata, 7)) == 0) || (this.pControlType.CompareTo(NavOption.Create(this.pControlType.NavOptionMetadata, 8)) == 0) || (this.pControlType.CompareTo(NavOption.Create(this.pControlType.NavOptionMetadata, 6)) == 0))))
                {
                    StmtHit(1);
                    this.imgCode = this.imgCode;
                    return;
                }

                StmtHit(2);
                this.imgCode = ALCompiler.ObjectToExactNavValue<NavText>(this.crypto.Target.Invoke(-435899332, new object[] { this.pURL, 0 }));
                StmtHit(3);
                this.imgCode = new NavText("_$" + NavTextExtensions.ALSubstring(this.imgCode, 1, 8));
                StmtHit(4);
                this.jObj.ALAdd(DataError.ThrowError, "u", this.pURL);
                StmtHit(5);
                this.jObj.ALAdd(DataError.ThrowError, "t", 1);
                StmtHit(6);
                base.Parent.SetPosImage(this.pControlType, this.pControlID, this.imgCode);
                StmtHit(7);
                this.oldUrl = base.Parent.AddPendingImage(this.imgCode, this.jObj);
                if (CStmtHit(8) & (this.oldUrl != ""))
                    if (CStmtHit(9) & (this.oldUrl != this.pURL))
                    {
                        StmtHit(10);
                        base.Parent.LogWarning(new NavText(ALSystemString.ALStrSubstNo("SetPosImageUrl: Hash collision for %1 %2 (newUrl=[%3] oldUrl=[%4], hash=[%5])", ALCompiler.ToNavValue(NavFormatEvaluateHelper.Format(this.pControlType)), this.pControlID, this.pURL, this.oldUrl, this.imgCode)));
                    }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1612667395")]
        public void SetPosImage(NavOption pControlType, NavText pControlID, NavText pImgID)
        {
            using (SetPosImage_Scope_880088188 \u03b2scope = new SetPosImage_Scope_880088188(this, pControlType, pControlID, pImgID))
                \u03b2scope.Run();
        }

        [NavName("SetPosImage")]
        [SignatureSpan(846113878973480994L)]
        [SourceSpans(846676777387687946L, 848084156566274065L, 848647089339957357L, 848928560021766152L)]
        private sealed class SetPosImage_Scope_880088188 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("pImgID")]
            public NavText pImgID;
            protected override uint RawScopeId { get => SetPosImage_Scope_880088188.\u03b1scopeId; set => SetPosImage_Scope_880088188.\u03b1scopeId = value; }

            internal SetPosImage_Scope_880088188(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID, NavText pImgID) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
                this.pImgID = pImgID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (!((this.pControlType.CompareTo(NavOption.Create(this.pControlType.NavOptionMetadata, 6)) == 0) || (this.pControlType.CompareTo(NavOption.Create(this.pControlType.NavOptionMetadata, 7)) == 0) || (this.pControlType.CompareTo(NavOption.Create(this.pControlType.NavOptionMetadata, 8)) == 0))))
                {
                    StmtHit(1);
                    return;
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { this.pControlType, this.pControlID, new NavText(base.Parent._MenuButtonEntities.Target.ALFieldName(1222)), this.pImgID });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 526518663")]
        public void SetSelectedButton(NavCode pMenuID, int i)
        {
            using (SetSelectedButton_Scope_1125768672 \u03b2scope = new SetSelectedButton_Scope_1125768672(this, pMenuID, i))
                \u03b2scope.Run();
        }

        [NavName("SetSelectedButton")]
        [SignatureSpan(1065101372250652703L)]
        [SourceSpans(1065664309319303193L, 1065945788591046730L, 1066508734249631798L, 1066790213521375278L, 1067353163474927663L, 1067634616976867336L)]
        private sealed class SetSelectedButton_Scope_1125768672 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [NavName("i")]
            public int i;
            protected override uint RawScopeId { get => SetSelectedButton_Scope_1125768672.\u03b1scopeId; set => SetSelectedButton_Scope_1125768672.\u03b1scopeId = value; }

            internal SetSelectedButton_Scope_1125768672(Codeunit10012739 \u03b2parent, NavCode pMenuID, int i) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
                this.i = i;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetSelectedButton(%1, %2)", this.pMenuID, ALCompiler.ToNavValue(this.i))));
                }

                if (CStmtHit(2) & (!base.Parent.menuSelectedButton.ALContainsKey(new NavText(this.pMenuID))))
                {
                    StmtHit(3);
                    base.Parent.menuSelectedButton.ALAdd(DataError.ThrowError, new NavText(this.pMenuID), this.i);
                }
                else
                {
                    StmtHit(4);
                    base.Parent.menuSelectedButton.ALSet(new NavText(this.pMenuID), this.i);
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1604691565")]
        public void SetSelectedDate(NavDateTime dt)
        {
            using (SetSelectedDate_Scope_1768324170 \u03b2scope = new SetSelectedDate_Scope_1768324170(this, dt))
                \u03b2scope.Run();
        }

        [NavName("SetSelectedDate")]
        [SignatureSpan(1211749835151048733L)]
        [SourceSpans(1212312772219699225L, 1212594251491442748L, 1212875709288349776L, 1213157179970158600L)]
        private sealed class SetSelectedDate_Scope_1768324170 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("dt")]
            public NavDateTime dt;
            protected override uint RawScopeId { get => SetSelectedDate_Scope_1768324170.\u03b1scopeId; set => SetSelectedDate_Scope_1768324170.\u03b1scopeId = value; }

            internal SetSelectedDate_Scope_1768324170(Codeunit10012739 \u03b2parent, NavDateTime dt) : base(\u03b2parent)
            {
                this.dt = dt;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SetSelectedDate(%1)", this.dt)));
                }

                StmtHit(2);
                base.Parent.SetMainControlValue_1893130901(new NavText(base.Parent._POS.Target.ALFieldName(20)), new NavText(NavFormatEvaluateHelper.Format(this.dt, 0, 9)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3394487088")]
        public void SetStyleProfileFilters(NavText fontIdsFilter, NavText skinIdsFilter, NavText colorIdsFilter, bool skipDefaultResources)
        {
            using (SetStyleProfileFilters_Scope_61703294 \u03b2scope = new SetStyleProfileFilters_Scope_61703294(this, fontIdsFilter, skinIdsFilter, colorIdsFilter, skipDefaultResources))
                \u03b2scope.Run();
        }

        [NavName("SetStyleProfileFilters")]
        [SignatureSpan(980095929264242724L)]
        [SourceSpans(980658866332893226L, 980940345604636716L, 981221820581412904L, 982066241216774186L, 982347720488517676L, 982629195465293864L, 983473616100655148L, 983755095372398638L, 984036570349174824L, 984880990984536120L, 985162470256279610L, 985443945233055784L, 986006873711771656L)]
        private sealed class SetStyleProfileFilters_Scope_61703294 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("fontIdsFilter")]
            public NavText fontIdsFilter;
            [NavName("skinIdsFilter")]
            public NavText skinIdsFilter;
            [NavName("colorIdsFilter")]
            public NavText colorIdsFilter;
            [NavName("skipDefaultResources")]
            public bool skipDefaultResources;
            protected override uint RawScopeId { get => SetStyleProfileFilters_Scope_61703294.\u03b1scopeId; set => SetStyleProfileFilters_Scope_61703294.\u03b1scopeId = value; }

            internal SetStyleProfileFilters_Scope_61703294(Codeunit10012739 \u03b2parent, NavText fontIdsFilter, NavText skinIdsFilter, NavText colorIdsFilter, bool skipDefaultResources) : base(\u03b2parent)
            {
                this.fontIdsFilter = fontIdsFilter.ModifyLength(0);
                this.skinIdsFilter = skinIdsFilter.ModifyLength(0);
                this.colorIdsFilter = colorIdsFilter.ModifyLength(0);
                this.skipDefaultResources = skipDefaultResources;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent._FontIdsFilter != this.fontIdsFilter))
                {
                    StmtHit(1);
                    base.Parent._FontIdsFilter = this.fontIdsFilter;
                    StmtHit(2);
                    base.Parent.styleProfilePending = true;
                }

                if (CStmtHit(3) & (base.Parent._SkinIdsFilter != this.skinIdsFilter))
                {
                    StmtHit(4);
                    base.Parent._SkinIdsFilter = this.skinIdsFilter;
                    StmtHit(5);
                    base.Parent.styleProfilePending = true;
                }

                if (CStmtHit(6) & (base.Parent._ColorIdsFilter != this.colorIdsFilter))
                {
                    StmtHit(7);
                    base.Parent._ColorIdsFilter = this.colorIdsFilter;
                    StmtHit(8);
                    base.Parent.styleProfilePending = true;
                }

                if (CStmtHit(9) & (base.Parent._SkipDefaultResources != this.skipDefaultResources))
                {
                    StmtHit(10);
                    base.Parent._SkipDefaultResources = this.skipDefaultResources;
                    StmtHit(11);
                    base.Parent.styleProfilePending = true;
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1758177323")]
        public NavText SetValue(NavText pKey, NavText pValue)
        {
            using (SetValue_Scope_1392435367 \u03b2scope = new SetValue_Scope_1392435367(this, pKey, pValue))
            {
                \u03b2scope.Run();
                return \u03b2scope.oldValue;
            }
        }

        [NavName("SetValue")]
        [SignatureSpan(58546855298990102L)]
        [SourceSpans(59109779482738735L, 59391250164547592L)]
        private sealed class SetValue_Scope_1392435367 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pKey")]
            public NavText pKey;
            [NavName("pValue")]
            public NavText pValue;
            [ReturnValue("oldValue")]
            [NavName("oldValue")]
            public NavText oldValue = NavText.Default(0);
            protected override uint RawScopeId { get => SetValue_Scope_1392435367.\u03b1scopeId; set => SetValue_Scope_1392435367.\u03b1scopeId = value; }

            internal SetValue_Scope_1392435367(Codeunit10012739 \u03b2parent, NavText pKey, NavText pValue) : base(\u03b2parent)
            {
                this.pKey = pKey.ModifyLength(0);
                this.pValue = pValue.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.oldValue = base.Parent.SetValue_711940861(this.pKey, this.pValue, new NavText(""));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2311755044")]
        public NavText SetValue_711940861(NavText pKey, NavText pValue, NavText pTag)
        {
            using (SetValue_Scope__711940861 \u03b2scope = new SetValue_Scope__711940861(this, pKey, pValue, pTag))
            {
                \u03b2scope.Run();
                return \u03b2scope.oldValue;
            }
        }

        [NavName("SetValue")]
        [SignatureSpan(59954230182871062L)]
        [SourceSpans(61643054273724470L, 61924529250500647L, 62206017112178708L, 62487496383922193L, 63050429157605410L, 63894866972835888L, 64176346244579400L, 64457821221355566L, 65583716833493032L, 65865208990138408L, 66146688261881896L, 66709638215434284L, 67272583874019357L, 67554076030664733L, 67835555302408240L, 68679941578031139L, 68961433734676513L, 69524400868098097L, 69805880139841593L, 70368830093393974L, 70931762867077159L, 71213237843853357L, 72057624119476232L)]
        private sealed class SetValue_Scope__711940861 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pKey")]
            public NavText pKey;
            [NavName("pValue")]
            public NavText pValue;
            [NavName("pTag")]
            public NavText pTag;
            [ReturnValue("oldValue")]
            [NavName("oldValue")]
            public NavText oldValue = NavText.Default(0);
            [NavName("mods")]
            public NavDictionary<NavText, NavText> mods = NavDictionary<NavText, NavText>.Default;
            [NavName("isValEmpty")]
            public bool isValEmpty = default(bool);
            protected override uint RawScopeId { get => SetValue_Scope__711940861.\u03b1scopeId; set => SetValue_Scope__711940861.\u03b1scopeId = value; }

            internal SetValue_Scope__711940861(Codeunit10012739 \u03b2parent, NavText pKey, NavText pValue, NavText pTag) : base(\u03b2parent)
            {
                this.pKey = pKey.ModifyLength(0);
                this.pValue = pValue.ModifyLength(0);
                this.pTag = pTag.ModifyLength(0);
                this.mods = NavDictionary<NavText, NavText>.Default;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.oldValue = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.context.Target.Invoke(-1056550292, new object[] { this.pKey, this.pValue }));
                StmtHit(1);
                this.pKey = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.context.Target.Invoke(-1140655136, Array.Empty<object>()));
                if (CStmtHit(2) & (this.pKey == ""))
                {
                    StmtHit(3);
                    this.oldValue = this.oldValue;
                    return;
                }

                StmtHit(4);
                this.isValEmpty = this.pValue == "";
                if (CStmtHit(5) & (base.Parent._contextExpressions.ALContainsKey(this.pKey)))
                {
                    StmtHit(6);
                    this.pValue = new NavText(ALSystemString.ALStrSubstNo(base.Parent._contextExpressions.ALGet(this.pKey), this.pValue));
                    StmtHit(7);
                    base.Parent.context.Target.Invoke(-1056550292, new object[] { this.pKey, this.pValue });
                }

                if (CStmtHit(8) & (base.Parent.contextTags.ALContainsKey(this.pKey)))
                {
                    if (CStmtHit(9) & (this.isValEmpty | (this.pTag == "")))
                    {
                        StmtHit(10);
                        base.Parent.contextTags.ALRemove(this.pKey);
                    }
                    else
                    {
                        StmtHit(11);
                        base.Parent.contextTags.ALSet(this.pKey, this.pTag);
                    }
                }
                else if (CStmtHit(12) & (!this.isValEmpty))
                    if (CStmtHit(13) & (this.pTag != ""))
                    {
                        StmtHit(14);
                        base.Parent.contextTags.ALAdd(DataError.ThrowError, this.pKey, this.pTag);
                    }

                if (CStmtHit(15) & (!base.Parent._ignoreModifications))
                {
                    if (CStmtHit(16) & (this.oldValue != this.pValue))
                    {
                        if (CStmtHit(17) & (base.Parent.modifiedContext.ALContains(this.pKey)))
                        {
                            StmtHit(18);
                            base.Parent.modifiedContext.ALReplace(DataError.ThrowError, this.pKey, this.pValue);
                        }
                        else
                        {
                            StmtHit(19);
                            base.Parent.modifiedContext.ALAdd(DataError.ThrowError, this.pKey, this.pValue);
                        }

                        StmtHit(20);
                        this.mods.ALAdd(DataError.ThrowError, this.pKey, this.pValue);
                        StmtHit(21);
                        base.Parent._lastModifiedContext = this.mods;
                    }
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1575681521")]
        public void ShowControl(NavText pPanelID, int pColumn, int pRow, int pColumnSpan, int pRowSpan, NavOption pControlType, NavText pControlID)
        {
            using (ShowControl_Scope__733130942 \u03b2scope = new ShowControl_Scope__733130942(this, pPanelID, pColumn, pRow, pColumnSpan, pRowSpan, pControlType, pControlID))
                \u03b2scope.Run();
        }

        [NavName("ShowControl")]
        [SignatureSpan(827255016874770457L)]
        [SourceSpans(828662378873749529L, 828943858145558590L, 829788278780854296L, 830069758052597777L, 830632703711182884L, 830914195867828262L, 831195675139571809L, 831758590733385815L, 832321540686938150L, 832603015663714372L, 832884490640490562L, 833165965617266750L, 833447440594042922L, 834010390547595302L, 834291865524371513L, 834573353386049579L, 834854845542694978L, 835136324814438468L, 835417765431476253L, 835980715385028645L, 836262190361804857L, 836543665338581052L, 836825140315357242L, 837106615292133430L, 837388090268909616L, 837669565245685802L, 837951040222462008L, 838232515199238194L, 838513990176014373L, 839076940129566770L, 839358415106342950L, 839921377944797229L, 840202870101442602L, 840484349373186086L, 840765807170093100L, 841328735648808968L)]
        private sealed class ShowControl_Scope__733130942 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("pColumn")]
            public int pColumn;
            [NavName("pRow")]
            public int pRow;
            [NavName("pColumnSpan")]
            public int pColumnSpan;
            [NavName("pRowSpan")]
            public int pRowSpan;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            [NavName("panelControlLine")]
            public INavRecordHandle panelControlLine;
            [NavName("txtControlNotFound")]
            public static readonly NavTextConstant txtControlNotFound = new NavTextConstant(new int[] { 1033 }, new string[] { "%1 with id %2 does not exist." }, "Codeunit 2892615804", "Codeunit 2892615804 - Method 1956456800 - NamedType 1781352960");
            protected override uint RawScopeId { get => ShowControl_Scope__733130942.\u03b1scopeId; set => ShowControl_Scope__733130942.\u03b1scopeId = value; }

            internal ShowControl_Scope__733130942(Codeunit10012739 \u03b2parent, NavText pPanelID, int pColumn, int pRow, int pColumnSpan, int pRowSpan, NavOption pControlType, NavText pControlID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.pColumn = pColumn;
                this.pRow = pRow;
                this.pColumnSpan = pColumnSpan;
                this.pRowSpan = pRowSpan;
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
                this.panelControlLine = new NavRecordHandle(this, 99008874, false, SecurityFiltering.Validated);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ShowControl(%1, %2, %3, %4, %5, %6, %7)", this.pPanelID, ALCompiler.ToNavValue(this.pColumn), ALCompiler.ToNavValue(this.pRow), ALCompiler.ToNavValue(this.pColumnSpan), ALCompiler.ToNavValue(this.pRowSpan), this.pControlType, this.pControlID)));
                }

                if (CStmtHit(2) & (this.pPanelID == ""))
                {
                    StmtHit(3);
                    return;
                }

                if (CStmtHit(4) & (!base.Parent.PanelLoaded(this.pPanelID)))
                    if (CStmtHit(5) & (!base.Parent.LoadPanel(this.pPanelID)))
                    {
                        StmtHit(6);
                        NavDialog.ALError(Guid.Parse("8da61efd-0002-0003-0507-0b0d1113171d"), ALSystemString.ALStrSubstNo(txtControlNotFound, ((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).CreateInstance(NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2)), this.pPanelID));
                    }

                StmtHit(7);
                base.Parent.RemovePanelControlFromPosition(this.pPanelID, this.pColumn, this.pRow, this.pColumnSpan, this.pRowSpan);
                StmtHit(8);
                base.Parent._PanelControlEntities.Target.ALReset();
                StmtHit(9);
                base.Parent._PanelControlEntities.Target.ALSetCurrentKey(DataError.ThrowError, 8, 9);
                StmtHit(10);
                base.Parent._PanelControlEntities.Target.ALSetRangeSafe(8, NavType.Option, this.pControlType);
                StmtHit(11);
                base.Parent._PanelControlEntities.Target.ALSetRangeSafe(9, NavType.Code, this.pControlID);
                StmtHit(12);
                base.Parent._PanelControlEntities.Target.ALDeleteAll();
                StmtHit(13);
                base.Parent._PanelControlEntities.Target.ALReset();
                StmtHit(14);
                base.Parent._PanelControlEntities.Target.SetFieldValueSafe(2, NavType.Code, new NavCode(25, this.pPanelID));
                if (CStmtHit(15) & (base.Parent._PanelControlEntities.Target.ALFindLast(DataError.TrapError)))
                    if (CStmtHit(16) & (base.Parent._PanelControlEntities.Target.GetFieldValueSafe(3, NavType.Integer).ToInt32() >= base.Parent._TmpLineIndexer))
                    {
                        StmtHit(17);
                        base.Parent._TmpLineIndexer = base.Parent._PanelControlEntities.Target.GetFieldValueSafe(3, NavType.Integer).ToInt32();
                    }

                StmtHit(18);
                base.Parent._TmpLineIndexer = base.Parent._TmpLineIndexer + (1);
                StmtHit(19);
                base.Parent._PanelControlEntities.Target.ALInit();
                StmtHit(20);
                base.Parent._PanelControlEntities.Target.SetFieldValueSafe(2, NavType.Code, new NavCode(25, this.pPanelID));
                StmtHit(21);
                base.Parent._PanelControlEntities.Target.SetFieldValueSafe(3, NavType.Integer, ALCompiler.ToNavValue(base.Parent._TmpLineIndexer));
                StmtHit(22);
                base.Parent._PanelControlEntities.Target.SetFieldValueSafe(8, NavType.Option, this.pControlType);
                StmtHit(23);
                base.Parent._PanelControlEntities.Target.SetFieldValueSafe(9, NavType.Code, new NavCode(25, this.pControlID));
                StmtHit(24);
                base.Parent._PanelControlEntities.Target.SetFieldValueSafe(4, NavType.Integer, ALCompiler.ToNavValue(this.pColumn));
                StmtHit(25);
                base.Parent._PanelControlEntities.Target.SetFieldValueSafe(5, NavType.Integer, ALCompiler.ToNavValue(this.pRow));
                StmtHit(26);
                base.Parent._PanelControlEntities.Target.SetFieldValueSafe(6, NavType.Integer, ALCompiler.ToNavValue(this.pColumnSpan));
                StmtHit(27);
                base.Parent._PanelControlEntities.Target.SetFieldValueSafe(7, NavType.Integer, ALCompiler.ToNavValue(this.pRowSpan));
                StmtHit(28);
                base.Parent._PanelControlEntities.Target.ALInsert(DataError.ThrowError);
                StmtHit(29);
                base.Parent.SetControlPosition(base.Parent._PanelControlEntities);
                StmtHit(30);
                base.Parent._PanelControlEntities.Target.ALReset();
                if (CStmtHit(31) & (this.pControlType == NavOption.Create(this.pControlType.NavOptionMetadata, 2)))
                {
                    if (CStmtHit(32) & (!base.Parent.PanelLoaded(this.pControlID)))
                    {
                        StmtHit(33);
                        base.Parent.LoadPanel(this.pControlID);
                    }

                    StmtHit(34);
                    base.Parent.ResumePanelControls(this.pControlID);
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 68847655")]
        public void ShowDataTable(NavCode pControlID, NavCode pDataTableID)
        {
            using (ShowDataTable_Scope_1062296984 \u03b2scope = new ShowDataTable_Scope_1062296984(this, pControlID, pDataTableID))
                \u03b2scope.Run();
        }

        [NavName("ShowDataTable")]
        [SignatureSpan(902971785627566107L)]
        [SourceSpans(903534722696216601L, 903816201967960148L, 904379134741643407L, 904942080400228360L)]
        private sealed class ShowDataTable_Scope_1062296984 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pDataTableID")]
            public NavCode pDataTableID;
            protected override uint RawScopeId { get => ShowDataTable_Scope_1062296984.\u03b1scopeId; set => ShowDataTable_Scope_1062296984.\u03b1scopeId = value; }

            internal ShowDataTable_Scope_1062296984(Codeunit10012739 \u03b2parent, NavCode pControlID, NavCode pDataTableID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
                this.pDataTableID = pDataTableID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ShowDataTable(%1, %2)", this.pControlID, this.pDataTableID)));
                }

                StmtHit(2);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), new NavText(this.pControlID), new NavText(base.Parent._DataGridEntities.Target.ALFieldName(5)), new NavText(this.pDataTableID) });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3795280497")]
        public void ShowDualDisplay(int pScreenNo)
        {
            using (ShowDualDisplay_Scope__2108379994 \u03b2scope = new ShowDualDisplay_Scope__2108379994(this, pScreenNo))
                \u03b2scope.Run();
        }

        [NavName("ShowDualDisplay")]
        [SignatureSpan(1253126656737148957L)]
        [SourceSpans(1254534018736128025L, 1254815498007871555L, 1255378443666456604L, 1255659922938200081L, 1256222855711883303L, 1256504330688659488L, 1257067280642211885L, 1257348751324020744L)]
        private sealed class ShowDualDisplay_Scope__2108379994 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pScreenNo")]
            public int pScreenNo;
            [NavName("DualConfig")]
            public NavJsonObject dualConfig;
            [NavName("DualConfigTxt")]
            public NavText dualConfigTxt = NavText.Default(0);
            protected override uint RawScopeId { get => ShowDualDisplay_Scope__2108379994.\u03b1scopeId; set => ShowDualDisplay_Scope__2108379994.\u03b1scopeId = value; }

            internal ShowDualDisplay_Scope__2108379994(Codeunit10012739 \u03b2parent, int pScreenNo) : base(\u03b2parent)
            {
                this.pScreenNo = pScreenNo;
                this.dualConfig = NavJsonObject.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ShowDualDisplay(%1)", ALCompiler.ToNavValue(this.pScreenNo))));
                }

                if (CStmtHit(2) & (!base.Parent.IsDualDisplay()))
                {
                    StmtHit(3);
                    return;
                }

                StmtHit(4);
                base.Parent.showDualDisplayPending = true;
                StmtHit(5);
                base.Parent.SetDisplayNo(this.pScreenNo);
                StmtHit(6);
                base.Parent.SendPOSCommandEvent(new NavText("_FORMLOAD"), new NavText(""));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 847721461")]
        public void ShowMenu(NavCode pMenuID, NavCode pButtonPadID)
        {
            using (ShowMenu_Scope__656596980 \u03b2scope = new ShowMenu_Scope__656596980(this, pMenuID, pButtonPadID))
                \u03b2scope.Run();
        }

        [NavName("ShowMenu")]
        [SignatureSpan(752945623005855766L)]
        [SourceSpans(753508560074506265L, 753790039346249804L, 754352972119932975L, 754634442801741832L)]
        private sealed class ShowMenu_Scope__656596980 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [NavName("pButtonPadID")]
            public NavCode pButtonPadID;
            protected override uint RawScopeId { get => ShowMenu_Scope__656596980.\u03b1scopeId; set => ShowMenu_Scope__656596980.\u03b1scopeId = value; }

            internal ShowMenu_Scope__656596980(Codeunit10012739 \u03b2parent, NavCode pMenuID, NavCode pButtonPadID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
                this.pButtonPadID = pButtonPadID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ShowMenu(%1, %2)", this.pMenuID, this.pButtonPadID)));
                }

                StmtHit(2);
                base.Parent.StackMenu_1361759889(this.pMenuID, this.pButtonPadID, true);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3861142709")]
        public void ShowPanelModal(NavText pPanelID, NavText pPayload)
        {
            using (ShowPanelModal_Scope__1811840056 \u03b2scope = new ShowPanelModal_Scope__1811840056(this, pPanelID, pPayload))
                \u03b2scope.Run();
        }

        [NavName("ShowPanelModal")]
        [SignatureSpan(613896984478416924L)]
        [SourceSpans(614459908662165553L, 614741379343974408L)]
        private sealed class ShowPanelModal_Scope__1811840056 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("pPayload")]
            public NavText pPayload;
            protected override uint RawScopeId { get => ShowPanelModal_Scope__1811840056.\u03b1scopeId; set => ShowPanelModal_Scope__1811840056.\u03b1scopeId = value; }

            internal ShowPanelModal_Scope__1811840056(Codeunit10012739 \u03b2parent, NavText pPanelID, NavText pPayload) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.pPayload = pPayload.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.ShowPanelModal_1883873996(this.pPanelID, 0, 0, this.pPayload);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3519619143")]
        public void ShowPanelModal_1883873996(NavText pPanelID, int widthPercent, int heightPercent, NavText pPayload)
        {
            using (ShowPanelModal_Scope__1883873996 \u03b2scope = new ShowPanelModal_Scope__1883873996(this, pPanelID, widthPercent, heightPercent, pPayload))
                \u03b2scope.Run();
        }

        [NavName("ShowPanelModal")]
        [SignatureSpan(615304359362297884L)]
        [SourceSpans(616711721361276953L, 616993200633020532L, 617556146291605537L, 617837625563349009L, 618400558337032241L, 618682033313808413L, 618963508290584615L, 619244978972393480L)]
        private sealed class ShowPanelModal_Scope__1883873996 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("widthPercent")]
            public int widthPercent;
            [NavName("heightPercent")]
            public int heightPercent;
            [NavName("pPayload")]
            public NavText pPayload;
            [NavName("widthPX")]
            public int widthPX = default(int);
            [NavName("heightPX")]
            public int heightPX = default(int);
            protected override uint RawScopeId { get => ShowPanelModal_Scope__1883873996.\u03b1scopeId; set => ShowPanelModal_Scope__1883873996.\u03b1scopeId = value; }

            internal ShowPanelModal_Scope__1883873996(Codeunit10012739 \u03b2parent, NavText pPanelID, int widthPercent, int heightPercent, NavText pPayload) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
                this.widthPercent = widthPercent;
                this.heightPercent = heightPercent;
                this.pPayload = pPayload.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ShowPanelModal(%1, %2, %3, %4)", this.pPanelID, ALCompiler.ToNavValue(this.widthPercent), ALCompiler.ToNavValue(this.heightPercent), this.pPayload)));
                }

                if (CStmtHit(2) & (!base.Parent.GetPanel(this.pPanelID)))
                {
                    StmtHit(3);
                    return;
                }

                StmtHit(4);
                base.Parent.modalPanelStack.Target.Invoke(1257355291, new object[] { this.pPanelID, this.pPayload });
                StmtHit(5);
                base.Parent.ResumeCurrentPanel();
                StmtHit(6);
                base.Parent.currShowPanelModal = this.pPanelID;
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1584576150")]
        public void ShowPanel(NavText pPanelID)
        {
            using (ShowPanel_Scope__377786894 \u03b2scope = new ShowPanel_Scope__377786894(this, pPanelID))
                \u03b2scope.Run();
        }

        [NavName("ShowPanel")]
        [SignatureSpan(595601110987964439L)]
        [SourceSpans(597289947963719705L, 597571427235463228L, 598134372894048280L, 598415852165791761L, 598978797824376867L, 599260277096120451L, 599541752072896544L, 600104714911350816L, 600386207067996244L, 600667686339739735L, 601230636293292120L, 601512094090199061L, 602356501840658479L, 603200922476019747L, 603482401747763217L, 604045347406348324L, 604326826678091809L, 604608301654868010L, 605452722290229284L, 605734201561972766L, 606297147220557856L, 606578626492301350L, 606860101469077537L, 607423064307531820L, 607704560759144497L, 607986061505724471L, 608267527892566069L, 608549015754244165L, 608830495025987647L, 609111982887665711L, 609393462159409189L, 610237852729999401L, 610519340591677509L, 610800819863420986L, 611082260480458775L, 611645210434011177L, 612208160387563566L, 612489635364339753L, 613334004460093448L)]
        private sealed class ShowPanel_Scope__377786894 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelID")]
            public NavText pPanelID;
            [NavName("panelid")]
            public NavText panelid = NavText.Default(0);
            [NavName("payload")]
            public NavText payload = NavText.Default(0);
            [NavName("warning")]
            public NavText warning = NavText.Default(0);
            protected override uint RawScopeId { get => ShowPanel_Scope__377786894.\u03b1scopeId; set => ShowPanel_Scope__377786894.\u03b1scopeId = value; }

            internal ShowPanel_Scope__377786894(Codeunit10012739 \u03b2parent, NavText pPanelID) : base(\u03b2parent)
            {
                this.pPanelID = pPanelID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("ShowPanel(%1)", this.pPanelID)));
                }

                if (CStmtHit(2) & (this.pPanelID == ""))
                {
                    StmtHit(3);
                    return;
                }

                if (CStmtHit(4) & (base.Parent.currShowPanelModal != ""))
                {
                    StmtHit(5);
                    this.warning = new NavText(ALSystemString.ALStrSubstNo("Modal Panel [%1] was hidden by simultaineously showing panel %2", base.Parent.currShowPanelModal, this.pPanelID));
                    StmtHit(6);
                    base.Parent.LogWarning(this.warning);
                    if (CStmtHit(7) & (this.pPanelID == "#POS"))
                    {
                        if (CStmtHit(8) & (base.Parent.pendingShowPanelOnModalPanelClose.ALContainsKey(base.Parent.currShowPanelModal)))
                        {
                            StmtHit(9);
                            base.Parent.pendingShowPanelOnModalPanelClose.ALSet(base.Parent.currShowPanelModal, this.pPanelID);
                        }
                        else
                        {
                            StmtHit(10);
                            base.Parent.pendingShowPanelOnModalPanelClose.ALAdd(DataError.ThrowError, base.Parent.currShowPanelModal, this.pPanelID);
                        }

                        StmtHit(11);
                        return;
                    }

                    StmtHit(12);
                    base.Parent.PosMessageBanner(this.warning, 0, 5000);
                }

                if (CStmtHit(13) & (this.pPanelID == base.Parent.ActivePanelID()))
                {
                    StmtHit(14);
                    return;
                }

                if (CStmtHit(15) & (!base.Parent._standardPanelsLoaded))
                {
                    StmtHit(16);
                    base.Parent.LoadStandardPanels();
                    StmtHit(17);
                    base.Parent._standardPanelsLoaded = true;
                }

                if (CStmtHit(18) & (((int)ALCompiler.ObjectToInt32(base.Parent.modalPanelStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                {
                    StmtHit(19);
                    base.Parent.CloseAllDialogs();
                }

                if (CStmtHit(20) & (((int)ALCompiler.ObjectToInt32(base.Parent.panelStack.Target.Invoke(1991726454, Array.Empty<object>()))) <= 0))
                {
                    StmtHit(21);
                    base.Parent.panelStack.Target.Invoke(-1685229465, new object[] { this.pPanelID });
                    StmtHit(22);
                    base.Parent.ResumeCurrentPanel();
                }
                else if (CStmtHit(23) & (ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.panelStack.Target.Invoke(918080733, Array.Empty<object>())) != this.pPanelID))
                {
                    if (CStmtHit(24) & (((bool)ALCompiler.ObjectToBoolean(base.Parent.panelStack.Target.Invoke(-309671161, new object[] { this.pPanelID })))))
                    {
                        while (CStmtHit(25) & (ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.panelStack.Target.Invoke(918080733, Array.Empty<object>())) != this.pPanelID))
                        {
                            StmtHit(26);
                            this.panelid = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.panelStack.Target.Invoke(918080733, Array.Empty<object>()));
                            if (CStmtHit(27) & (((bool)ALCompiler.ObjectToBoolean(base.Parent.panelClosedEventRegister.Target.Invoke(-309671161, new object[] { this.panelid })))))
                            {
                                StmtHit(28);
                                base.Parent.SendPanelCloseRequest(this.panelid, new NavText(""));
                                if (CStmtHit(29) & (base.Parent.panelCloseDenied))
                                {
                                    StmtHit(30);
                                    return;
                                }
                            }

                            StmtHit(31);
                            base.Parent.panelStack.Target.Invoke(-760389506, Array.Empty<object>());
                            if (CStmtHit(32) & (((bool)ALCompiler.ObjectToBoolean(base.Parent.panelClosedEventRegister.Target.Invoke(-309671161, new object[] { this.panelid })))))
                            {
                                StmtHit(33);
                                base.Parent.SendPanelClosedEvent(new NavCode(20, this.panelid));
                            }
                        }

                        StmtHit(34);
                        StmtHit(35);
                        base.Parent.ResumeCurrentPanel();
                    }
                    else
                    {
                        StmtHit(36);
                        base.Parent.panelStack.Target.Invoke(-1685229465, new object[] { this.pPanelID });
                        StmtHit(37);
                        base.Parent.ResumeCurrentPanel();
                    }
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2042452121")]
        public void ShowRecordZoomJSON(NavText dataSetJSON, NavCode pControlID, bool allowEdit)
        {
            using (ShowRecordZoomJSON_Scope__160281107 \u03b2scope = new ShowRecordZoomJSON_Scope__160281107(this, dataSetJSON, pControlID, allowEdit))
                \u03b2scope.Run();
        }

        [NavName("ShowRecordZoomJSON")]
        [SignatureSpan(935341407956828192L)]
        [SourceSpans(936748769955807257L, 937030249227550813L, 937311719909359641L, 937593199181103142L, 938156131954786449L, 938719081908338741L, 939000556885114918L, 939282031861891105L, 939563519723569194L, 939844998995312686L, 940407948948865067L, 940689402450804744L)]
        private sealed class ShowRecordZoomJSON_Scope__160281107 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("dataSetJSON")]
            public NavText dataSetJSON;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("allowEdit")]
            public bool allowEdit;
            [NavName("dsKey")]
            public NavText dsKey = NavText.Default(0);
            [NavName("jo")]
            public NavJsonObject jo;
            protected override uint RawScopeId { get => ShowRecordZoomJSON_Scope__160281107.\u03b1scopeId; set => ShowRecordZoomJSON_Scope__160281107.\u03b1scopeId = value; }

            internal ShowRecordZoomJSON_Scope__160281107(Codeunit10012739 \u03b2parent, NavText dataSetJSON, NavCode pControlID, bool allowEdit) : base(\u03b2parent)
            {
                this.dataSetJSON = dataSetJSON.ModifyLength(0);
                this.pControlID = pControlID.ModifyLength(20);
                this.allowEdit = allowEdit;
                this.jo = NavJsonObject.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("GetRecordZoomDataXML(XML, %1, %2)", this.pControlID, ALCompiler.ToNavValue(this.allowEdit))));
                }

                if (CStmtHit(2) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(3);
                    base.Parent.LogDeepTrace_1953297028(this.dataSetJSON);
                }

                StmtHit(4);
                base.Parent._CONTROLS.Target.Invoke(-1410208911, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 4), new NavText(this.pControlID), new NavText(base.Parent._RecordZoomEntities.Target.ALFieldName(1000)), !this.allowEdit });
                StmtHit(5);
                base.Parent.zoomDatasetJSON.ALSet(new NavText(this.pControlID), this.dataSetJSON);
                StmtHit(6);
                this.dsKey = new NavText(this.pControlID + "|-999");
                StmtHit(7);
                this.jo.ALReadFrom(DataError.ThrowError, this.dataSetJSON);
                if (CStmtHit(8) & (base.Parent.pendingDataSets.ALContains(this.dsKey)))
                {
                    StmtHit(9);
                    base.Parent.pendingDataSets.ALReplace(DataError.ThrowError, this.dsKey, this.jo);
                }
                else
                {
                    StmtHit(10);
                    base.Parent.pendingDataSets.ALAdd(DataError.ThrowError, this.dsKey, this.jo);
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 973744515")]
        public void ShowTooltip(NavText txt, int contentType)
        {
            using (ShowTooltip_Scope__773455029 \u03b2scope = new ShowTooltip_Scope__773455029(this, txt, contentType))
                \u03b2scope.Run();
        }

        [NavName("ShowTooltip")]
        [SignatureSpan(1263259755901091865L)]
        [SourceSpans(1264667117900070931L, 1264948597171814417L, 1265230054968721437L, 1265511529945497638L, 1265793004922273815L, 1266074479899050042L, 1266355950580858888L)]
        private sealed class ShowTooltip_Scope__773455029 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("txt")]
            public NavText txt;
            [NavName("contentType")]
            public int contentType;
            [NavName("jArr")]
            public NavJsonArray jArr;
            [NavName("jObj")]
            public NavJsonObject jObj;
            protected override uint RawScopeId { get => ShowTooltip_Scope__773455029.\u03b1scopeId; set => ShowTooltip_Scope__773455029.\u03b1scopeId = value; }

            internal ShowTooltip_Scope__773455029(Codeunit10012739 \u03b2parent, NavText txt, int contentType) : base(\u03b2parent)
            {
                this.txt = txt.ModifyLength(0);
                this.contentType = contentType;
                this.jArr = NavJsonArray.Default;
                this.jObj = NavJsonObject.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.txt == ""))
                {
                    StmtHit(1);
                    return;
                }

                StmtHit(2);
                this.jObj.ALAdd(DataError.ThrowError, "txt", this.txt);
                StmtHit(3);
                this.jObj.ALAdd(DataError.ThrowError, "type", this.contentType);
                StmtHit(4);
                this.jArr.ALAdd(this.jObj);
                StmtHit(5);
                base.Parent.SendPOSCommandEvent(new NavText("_SHOWTOOLTIP"), new NavText(NavFormatEvaluateHelper.Format(this.jArr)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2517078934")]
        public void SignalInputValidationError(NavText pErrorMessage)
        {
            using (SignalInputValidationError_Scope__1302451986 \u03b2scope = new SignalInputValidationError_Scope__1302451986(this, pErrorMessage))
                \u03b2scope.Run();
        }

        [NavName("SignalInputValidationError")]
        [SignatureSpan(1082271345834000424L)]
        [SourceSpans(1082834270017749081L, 1083115740699557896L)]
        private sealed class SignalInputValidationError_Scope__1302451986 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pErrorMessage")]
            public NavText pErrorMessage;
            protected override uint RawScopeId { get => SignalInputValidationError_Scope__1302451986.\u03b1scopeId; set => SignalInputValidationError_Scope__1302451986.\u03b1scopeId = value; }

            internal SignalInputValidationError_Scope__1302451986(Codeunit10012739 \u03b2parent, NavText pErrorMessage) : base(\u03b2parent)
            {
                this.pErrorMessage = pErrorMessage.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.SendPOSCommandEvent(new NavText("_VALIDATION_FAILED"), base.Parent.JavascriptStringEncode(this.pErrorMessage));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 894681453")]
        public void SignalNotImplemented(NavText methodName)
        {
            using (SignalNotImplemented_Scope_1640313108 \u03b2scope = new SignalNotImplemented_Scope_1640313108(this, methodName))
                \u03b2scope.Run();
        }

        [NavName("SignalNotImplemented")]
        [SignatureSpan(1239615857851891746L)]
        [SourceSpans(1240741731989192748L, 1241023202671001608L)]
        private sealed class SignalNotImplemented_Scope_1640313108 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("methodName")]
            public NavText methodName;
            [NavName("l")]
            public static readonly NavTextConstant l = new NavTextConstant(new int[] { 1033 }, new string[] { "***NOT IMPLEMENTED***.  \"%1\": is not implemented." }, "Codeunit 2892615804", "Codeunit 2892615804 - Method 2232333815 - NamedType 1764832336");
            protected override uint RawScopeId { get => SignalNotImplemented_Scope_1640313108.\u03b1scopeId; set => SignalNotImplemented_Scope_1640313108.\u03b1scopeId = value; }

            internal SignalNotImplemented_Scope_1640313108(Codeunit10012739 \u03b2parent, NavText methodName) : base(\u03b2parent)
            {
                this.methodName = methodName.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.LogTrace(new NavText(ALSystemString.ALStrSubstNo(l, this.methodName)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 775577377")]
        public void StackMenu_1361759889(NavCode pMenuID, NavCode pButtonPadID, bool pClearStack)
        {
            using (StackMenu_Scope_1361759889 \u03b2scope = new StackMenu_Scope_1361759889(this, pMenuID, pButtonPadID, pClearStack))
                \u03b2scope.Run();
        }

        [NavName("StackMenu")]
        [SignatureSpan(756604797703946263L)]
        [SourceSpans(758012159702925335L, 758293638974668817L, 758856584633253922L, 759138063904997406L, 759700996678680639L, 759982484540358678L, 760263989581905957L, 760545455968747581L, 761108388742430778L, 761671321516113952L, 761952796492890162L, 762234267174699016L)]
        private sealed class StackMenu_Scope_1361759889 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [NavName("pButtonPadID")]
            public NavCode pButtonPadID;
            [NavName("pClearStack")]
            public bool pClearStack;
            [NavName("menuStack")]
            public NavCodeunitHandle menuStack;
            [NavName("menu")]
            public NavText menu = NavText.Default(0);
            protected override uint RawScopeId { get => StackMenu_Scope_1361759889.\u03b1scopeId; set => StackMenu_Scope_1361759889.\u03b1scopeId = value; }

            internal StackMenu_Scope_1361759889(Codeunit10012739 \u03b2parent, NavCode pMenuID, NavCode pButtonPadID, bool pClearStack) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
                this.pButtonPadID = pButtonPadID.ModifyLength(20);
                this.pClearStack = pClearStack;
                this.menuStack = new NavCodeunitHandle(this, 10012738);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.pMenuID == ""))
                {
                    StmtHit(1);
                    return;
                }

                if (CStmtHit(2) & (!base.Parent.MenuLoaded(new NavText(this.pMenuID))))
                {
                    StmtHit(3);
                    base.Parent.LoadMenu(new NavText(this.pMenuID));
                }

                StmtHit(4);
                this.menuStack.Target.Invoke(1091980582, new object[] { base.Parent.GetButtonPadMenuList(this.pButtonPadID) });
                if (CStmtHit(5) & (this.pClearStack))
                {
                    while (CStmtHit(6) & (((int)ALCompiler.ObjectToInt32(this.menuStack.Target.Invoke(1991726454, Array.Empty<object>()))) > 0))
                    {
                        StmtHit(7);
                        base.Parent.SetMenuVisible_1628810055(ALCompiler.ObjectToExactNavValue<NavText>(this.menuStack.Target.Invoke(-760389506, Array.Empty<object>())), false, true);
                    }
                }
                else
                {
                    StmtHit(8);
                    base.Parent.SetMenuVisible_1628810055(ALCompiler.ObjectToExactNavValue<NavText>(this.menuStack.Target.Invoke(918080733, Array.Empty<object>())), false, true);
                }

                StmtHit(9);
                this.menuStack.Target.Invoke(-1685229465, new object[] { new NavText(this.pMenuID) });
                StmtHit(10);
                base.Parent.UpdateMenuPosition(new NavText(this.pMenuID), new NavText(this.pButtonPadID));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2308792714")]
        public void StackMenu(NavCode pMenuID, NavCode pButtonPadID)
        {
            using (StackMenu_Scope__1077737328 \u03b2scope = new StackMenu_Scope__1077737328(this, pMenuID, pButtonPadID))
                \u03b2scope.Run();
        }

        [NavName("StackMenu")]
        [SignatureSpan(755197422820065303L)]
        [SourceSpans(755760347003813936L, 756041817685622792L)]
        private sealed class StackMenu_Scope__1077737328 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavCode pMenuID;
            [NavName("pButtonPadID")]
            public NavCode pButtonPadID;
            protected override uint RawScopeId { get => StackMenu_Scope__1077737328.\u03b1scopeId; set => StackMenu_Scope__1077737328.\u03b1scopeId = value; }

            internal StackMenu_Scope__1077737328(Codeunit10012739 \u03b2parent, NavCode pMenuID, NavCode pButtonPadID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(20);
                this.pButtonPadID = pButtonPadID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.StackMenu_1361759889(this.pMenuID, this.pButtonPadID, false);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1511916330")]
        public void Stop(NavCode pControlID)
        {
            using (Stop_Scope_1137738475 \u03b2scope = new Stop_Scope_1137738475(this, pControlID))
                \u03b2scope.Run();
        }

        [NavName("Stop")]
        [SignatureSpan(1042583374108557330L)]
        [SourceSpans(1043146311177207833L, 1043427790448951353L, 1043990723222634564L, 1044272193904443400L)]
        private sealed class Stop_Scope_1137738475 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlID")]
            public NavCode pControlID;
            protected override uint RawScopeId { get => Stop_Scope_1137738475.\u03b1scopeId; set => Stop_Scope_1137738475.\u03b1scopeId = value; }

            internal Stop_Scope_1137738475(Codeunit10012739 \u03b2parent, NavCode pControlID) : base(\u03b2parent)
            {
                this.pControlID = pControlID.ModifyLength(20);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("Stop(%1)", this.pControlID)));
                }

                StmtHit(2);
                base.Parent.SendPOSCommandEvent(new NavText("STOP"), new NavText(ALSystemString.ALStrSubstNo("[%1]", this.pControlID)));
            }
        }

        [NavEvent(NavEventType.Internal, true, false, false)]
        private void StyleProfileRequest(NavText mainProfileID, NavText storeProfileID, NavText fontIdsFilter, NavText skinIdsFilter, NavText colorIdsFilter, bool skipDefaultResources, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil)
        {
            if (StyleProfileRequest_Scope.\u03b3eventScope == null && !this.Session.IsEventSessionRecorderEnabled)
                return;
            using (StyleProfileRequest_Scope \u03b2scope = new StyleProfileRequest_Scope(this, mainProfileID, storeProfileID, fontIdsFilter, skinIdsFilter, colorIdsFilter, skipDefaultResources, jsonUtil))
                \u03b2scope.RunEvent();
        }

        [NavName("StyleProfileRequest")]
        [SignatureSpan(1203305611617566759L)]
        [SourceSpans(1203868505736544264L)]
        private sealed class StyleProfileRequest_Scope : NavEventMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            public static NavEventScope \u03b3eventScope;
            [NavName("mainProfileID")]
            public NavText mainProfileID;
            [NavName("storeProfileID")]
            public NavText storeProfileID;
            [NavName("fontIdsFilter")]
            public NavText fontIdsFilter;
            [NavName("skinIdsFilter")]
            public NavText skinIdsFilter;
            [NavName("colorIdsFilter")]
            public NavText colorIdsFilter;
            [NavName("skipDefaultResources")]
            public bool skipDefaultResources;
            [NavName("jsonUtil")]
            public NavCodeunitHandle jsonUtil;
            protected override uint RawScopeId { get => StyleProfileRequest_Scope.\u03b1scopeId; set => StyleProfileRequest_Scope.\u03b1scopeId = value; }
            public override NavEventScope EventScope { get => StyleProfileRequest_Scope.\u03b3eventScope; set => StyleProfileRequest_Scope.\u03b3eventScope = value; }

            internal StyleProfileRequest_Scope(Codeunit10012739 \u03b2parent, NavText mainProfileID, NavText storeProfileID, NavText fontIdsFilter, NavText skinIdsFilter, NavText colorIdsFilter, bool skipDefaultResources, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle jsonUtil) : base(\u03b2parent)
            {
                this.mainProfileID = mainProfileID.ModifyLength(0);
                this.storeProfileID = storeProfileID.ModifyLength(0);
                this.fontIdsFilter = fontIdsFilter.ModifyLength(0);
                this.skinIdsFilter = skinIdsFilter.ModifyLength(0);
                this.colorIdsFilter = colorIdsFilter.ModifyLength(0);
                this.skipDefaultResources = skipDefaultResources;
                this.jsonUtil = jsonUtil;
            }
        }

        private void SyncButtonModification([NavObjectId(ObjectId = 10012741)][NavByReferenceAttribute] NavCodeunitHandle pPOSEvent, NavText pFieldName, int pValue)
        {
            using (SyncButtonModification_Scope_1805710910 \u03b2scope = new SyncButtonModification_Scope_1805710910(this, pPOSEvent, pFieldName, pValue))
                \u03b2scope.Run();
        }

        [NavName("SyncButtonModification")]
        [SignatureSpan(363665755894186026L)]
        [SourceSpans(365917504168788017L, 366198979145564195L, 366480454122340391L, 366761929099116617L, 367043404075892850L, 367324891937570845L, 367606371209314321L, 367887829006221421L, 368169303982997551L, 368450774664806408L)]
        private sealed class SyncButtonModification_Scope_1805710910 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPOSEvent")]
            public NavCodeunitHandle pPOSEvent;
            [NavName("pFieldName")]
            public NavText pFieldName;
            [NavName("pValue")]
            public int pValue;
            [NavName("splitText")]
            public NavList<NavText> splitText = NavList<NavText>.Default;
            [NavName("menuID")]
            public NavText menuID = NavText.Default(0);
            [NavName("buttonID")]
            public NavText buttonID = NavText.Default(0);
            [NavName("buttonNo")]
            public int buttonNo = default(int);
            [NavName("prevValue")]
            public int prevValue = default(int);
            [NavName("fRef")]
            public NavFieldRef fRef;
            [NavName("rRef")]
            public NavRecordRef rRef;
            protected override uint RawScopeId { get => SyncButtonModification_Scope_1805710910.\u03b1scopeId; set => SyncButtonModification_Scope_1805710910.\u03b1scopeId = value; }

            internal SyncButtonModification_Scope_1805710910(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 10012741)][NavByReferenceAttribute] NavCodeunitHandle pPOSEvent, NavText pFieldName, int pValue) : base(\u03b2parent)
            {
                this.pPOSEvent = pPOSEvent;
                this.pFieldName = pFieldName.ModifyLength(0);
                this.pValue = pValue;
                this.splitText = NavList<NavText>.Default;
                this.fRef = new NavFieldRef(this);
                this.rRef = new NavRecordRef(this, SecurityFiltering.Validated);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                this.splitText = NavTextExtensions.ALSplit(ALCompiler.ObjectToExactNavValue<NavText>(this.pPOSEvent.Target.Invoke(-586392693, Array.Empty<object>())), new NavText(","));
                StmtHit(1);
                this.menuID = this.splitText.ALGet(2);
                StmtHit(2);
                this.buttonNo = ((int)ALCompiler.ObjectToInt32(this.pPOSEvent.Target.Invoke(-1053347230, Array.Empty<object>())));
                StmtHit(3);
                this.buttonID = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { this.menuID, this.buttonNo }));
                StmtHit(4);
                this.prevValue = ALCompiler.ToInt32(((Decimal18)ALCompiler.ObjectToDecimal(base.Parent._CONTROLS.Target.Invoke(-820668825, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), this.buttonID, this.pFieldName }))));
                if (CStmtHit(5) & (this.prevValue == this.pValue))
                {
                    StmtHit(6);
                    return;
                }

                StmtHit(7);
                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), this.buttonID, this.pFieldName, this.pValue });
                StmtHit(8);
                base.Parent.AddMenuModifications(this.menuID, this.buttonNo);
            }
        }

        private bool SyncGridData(NavText pGridID, NavJsonObject data)
        {
            using (SyncGridData_Scope_298148825 \u03b2scope = new SyncGridData_Scope_298148825(this, pGridID, data))
            {
                \u03b2scope.Run();
                return \u03b2scope.updateJournalLine;
            }
        }

        [NavName("SyncGridData")]
        [SignatureSpan(398568653014433824L)]
        [SourceSpans(399975989243609113L, 400257468515352648L, 400820401289035811L, 401101889150713925L, 401383381307359288L, 401664860579102768L, 401946335555878973L, 402227810532655149L, 402509298394333215L, 402790777666076718L, 403635185416536130L, 404198113895252034L, 404479593166995524L, 404761063848804421L, 405042543120547900L, 405324013802356808L, 405605493074100283L, 405886968050876575L, 406449913709461572L, 406731392981205061L, 407012846483144712L)]
        private sealed class SyncGridData_Scope_298148825 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pGridID")]
            public NavText pGridID;
            [NavName("data")]
            public NavJsonObject data;
            [ReturnValue("UpdateJournalLine")]
            [NavName("UpdateJournalLine")]
            public bool updateJournalLine = default(bool);
            [NavName("jt")]
            public NavJsonToken jt;
            [NavName("idx")]
            public int idx = default(int);
            [NavName("x_idx")]
            public int x_idx = default(int);
            [NavName("currentColumnIndex")]
            public int currentColumnIndex = default(int);
            protected override uint RawScopeId { get => SyncGridData_Scope_298148825.\u03b1scopeId; set => SyncGridData_Scope_298148825.\u03b1scopeId = value; }

            internal SyncGridData_Scope_298148825(Codeunit10012739 \u03b2parent, NavText pGridID, NavJsonObject data) : base(\u03b2parent)
            {
                this.pGridID = pGridID.ModifyLength(0);
                this.data = data;
                this.jt = NavJsonToken.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SyncGridData(%1, %2)", this.pGridID, this.data)));
                }

                StmtHit(2);
                this.updateJournalLine = false;
                if (CStmtHit(3) & (this.data.ALGet(DataError.TrapError, base.Parent._DataGridEntities.Target.ALFieldName(1000), new ByRef<NavJsonToken>(() => this.jt, setValue => this.jt = setValue))))
                {
                    if (CStmtHit(4) & (this.pGridID == NavFormatEvaluateHelper.Format(base.Parent._Const.CreateInstance(NavOption.Create(base.Parent._Const.NavOptionMetadata, 7)))))
                    {
                        StmtHit(5);
                        this.idx = this.jt.ALAsValue().ALAsInteger();
                        StmtHit(6);
                        this.x_idx = base.Parent.GetDataGridCurrentRowIndex(this.pGridID);
                        StmtHit(7);
                        base.Parent.GoToRow_1548454713(new NavCode(20, this.pGridID), this.idx, false);
                        if (CStmtHit(8) & (this.idx != this.x_idx))
                        {
                            StmtHit(9);
                            this.updateJournalLine = true;
                        }
                    }
                    else
                    {
                        StmtHit(10);
                        base.Parent.GoToRow_1548454713(new NavCode(20, this.pGridID), this.jt.ALAsValue().ALAsInteger(), false);
                    }
                }

                if (CStmtHit(11) & (this.data.ALGet(DataError.TrapError, base.Parent._DataGridEntities.Target.ALFieldName(1003), new ByRef<NavJsonToken>(() => this.jt, setValue => this.jt = setValue))))
                {
                    StmtHit(12);
                    base.Parent.SetDataGridActiveRecord(new NavCode(20, this.pGridID), this.jt.ALAsValue().ALAsText());
                }

                if (CStmtHit(13) & (this.data.ALGet(DataError.TrapError, base.Parent._DataGridEntities.Target.ALFieldName(1004), new ByRef<NavJsonToken>(() => this.jt, setValue => this.jt = setValue))))
                {
                    StmtHit(14);
                    base.Parent.SetDataGridMarkedRecords(new NavCode(20, this.pGridID), this.jt.ALAsArray());
                }

                if (CStmtHit(15) & (this.data.ALGet(DataError.TrapError, base.Parent._DataGridEntities.Target.ALFieldName(1001), new ByRef<NavJsonToken>(() => this.jt, setValue => this.jt = setValue))))
                {
                    StmtHit(16);
                    this.currentColumnIndex = this.jt.ALAsValue().ALAsInteger();
                    StmtHit(17);
                    base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 3), this.pGridID, new NavText(base.Parent._DataGridEntities.Target.ALFieldName(1001)), this.currentColumnIndex });
                }

                if (CStmtHit(18) & (this.data.ALGet(DataError.TrapError, base.Parent._DataGridEntities.Target.ALFieldName(1002), new ByRef<NavJsonToken>(() => this.jt, setValue => this.jt = setValue))))
                {
                    StmtHit(19);
                    base.Parent.SetGridSelectedColumn(new NavCode(20, this.pGridID), this.jt.ALAsValue().ALAsInteger());
                }
            }
        }

        private void SyncZoomData(NavText pZoomID, NavText data)
        {
            using (SyncZoomData_Scope_542650200 \u03b2scope = new SyncZoomData_Scope_542650200(this, pZoomID, data))
                \u03b2scope.Run();
        }

        [NavName("SyncZoomData")]
        [SignatureSpan(384213429198848032L)]
        [SourceSpans(388716990172561433L, 388998469444304968L, 389561402217988128L, 390124365056442419L, 390405844328185951L, 390687319304962065L, 391531727055421492L, 391813202032197666L, 392094677008973862L, 392376151985750051L, 392657626962526242L, 392939101939302433L, 393502051893575692L, 393783544049500192L, 394065019026276392L, 394346494003052581L, 394627968979828775L, 394909443956604975L, 395190918933381171L, 395472393910157353L, 396035343863709736L, 396316818840485941L, 396598276637392907L, 397161226590945305L, 397442701567721504L, 397724176544497712L, 398005647226306568L)]
        private sealed class SyncZoomData_Scope_542650200 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pZoomID")]
            public NavText pZoomID;
            [NavName("data")]
            public NavText data;
            [NavName("jt")]
            public NavJsonToken jt;
            [NavName("c")]
            public int c = default(int);
            [NavName("keyValueArr")]
            public NavJsonArray keyValueArr;
            [NavName("jKey")]
            public NavJsonToken jKey;
            [NavName("jValue")]
            public NavJsonToken jValue;
            [NavName("currKey")]
            public NavText currKey = NavText.Default(0);
            [NavName("currValue")]
            public NavText currValue = NavText.Default(0);
            [NavName("json")]
            public NavJsonObject json;
            [NavName("token")]
            public NavJsonToken token;
            [NavName("tables")]
            public NavJsonObject tables;
            [NavName("_rows")]
            public NavJsonArray _rows;
            [NavName("dataIndex")]
            public int dataIndex = default(int);
            [NavName("jsonData")]
            public NavJsonArray jsonData;
            protected override uint RawScopeId { get => SyncZoomData_Scope_542650200.\u03b1scopeId; set => SyncZoomData_Scope_542650200.\u03b1scopeId = value; }

            internal SyncZoomData_Scope_542650200(Codeunit10012739 \u03b2parent, NavText pZoomID, NavText data) : base(\u03b2parent)
            {
                this.pZoomID = pZoomID.ModifyLength(0);
                this.data = data.ModifyLength(0);
                this.jt = NavJsonToken.Default;
                this.keyValueArr = NavJsonArray.Default;
                this.jKey = NavJsonToken.Default;
                this.jValue = NavJsonToken.Default;
                this.json = NavJsonObject.Default;
                this.token = NavJsonToken.Default;
                this.tables = NavJsonObject.Default;
                this._rows = NavJsonArray.Default;
                this.jsonData = NavJsonArray.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("SyncZoomData(%1, %2)", this.pZoomID, this.data)));
                }

                StmtHit(2);
                this.jsonData.ALReadFrom(DataError.ThrowError, this.data);
                if (CStmtHit(3) & (!base.Parent.zoomDatasetJSON.ALContainsKey(this.pZoomID)))
                {
                    StmtHit(4);
                    base.Parent.LogError(new NavText(ALSystemString.ALStrSubstNo("No Server side DataSet found for ZoomControl [%1]", this.pZoomID)));
                    StmtHit(5);
                    return;
                }

                StmtHit(6);
                this.json.ALReadFrom(DataError.ThrowError, base.Parent.zoomDatasetJSON.ALGet(this.pZoomID));
                StmtHit(7);
                this.json.ALGet(DataError.ThrowError, "Tables", new ByRef<NavJsonToken>(() => this.token, setValue => this.token = setValue));
                StmtHit(8);
                this.token.ALAsArray().ALGet(DataError.ThrowError, 0, new ByRef<NavJsonToken>(() => this.token, setValue => this.token = setValue));
                StmtHit(9);
                this.tables = this.token.ALAsObject();
                StmtHit(10);
                this.tables.ALGet(DataError.ThrowError, "Rows", new ByRef<NavJsonToken>(() => this.token, setValue => this.token = setValue));
                StmtHit(11);
                this._rows = this.token.ALAsArray();
                this.c = 0;
                StmtHit(12);
                int @tmp0 = this.jsonData.ALCount - 1;
                for (; this.c <= @tmp0;)
                {
                    {
                        CStmtHit(13);
                        this.jsonData.ALGet(DataError.ThrowError, this.c, new ByRef<NavJsonToken>(() => this.jt, setValue => this.jt = setValue));
                        StmtHit(14);
                        this.keyValueArr = this.jt.ALAsArray();
                        StmtHit(15);
                        this.keyValueArr.ALGet(DataError.ThrowError, 0, new ByRef<NavJsonToken>(() => this.jKey, setValue => this.jKey = setValue));
                        StmtHit(16);
                        this.keyValueArr.ALGet(DataError.ThrowError, 1, new ByRef<NavJsonToken>(() => this.jValue, setValue => this.jValue = setValue));
                        StmtHit(17);
                        this.currKey = this.jKey.ALAsValue().ALAsText();
                        StmtHit(18);
                        this.currValue = this.jValue.ALAsValue().ALAsText();
                        StmtHit(19);
                        ALSystemVariable.ALEvaluate(DataError.ThrowError, new ByRef<int>(() => this.dataIndex, setValue => this.dataIndex = setValue), this.currKey);
                        StmtHit(20);
                        this._rows.ALGet(DataError.ThrowError, this.dataIndex, new ByRef<NavJsonToken>(() => this.token, setValue => this.token = setValue));
                        StmtHit(21);
                        this.token.ALAsObject().ALReplace(DataError.ThrowError, "2", this.currValue);
                    }

                    if (this.c >= @tmp0)
                        break;
                    this.c = this.c + 1;
                }

                StmtHit(22);
                StmtHit(23);
                this.currValue = NavText.Default(0);
                StmtHit(24);
                this.json.ALWriteTo(DataError.ThrowError, new ByRef<NavText>(() => this.currValue, setValue => this.currValue = setValue));
                StmtHit(25);
                base.Parent.zoomDatasetJSON.ALSet(this.pZoomID, this.currValue);
            }
        }

        private void TagControl(NavOption pControlType, NavCode pProfileID, NavCode pControlID, NavText pTag)
        {
            using (TagControl_Scope__1185023272 \u03b2scope = new TagControl_Scope__1185023272(this, pControlType, pProfileID, pControlID, pTag))
                \u03b2scope.Run();
        }

        [NavName("TagControl")]
        [SignatureSpan(537617291541872670L)]
        [SourceSpans(538743139909369888L, 539024614886146104L, 539306089862922289L, 539587564839698474L, 539869052701376548L, 540150510498283528L)]
        private sealed class TagControl_Scope__1185023272 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pProfileID")]
            public NavCode pProfileID;
            [NavName("pControlID")]
            public NavCode pControlID;
            [NavName("pTag")]
            public NavText pTag;
            protected override uint RawScopeId { get => TagControl_Scope__1185023272.\u03b1scopeId; set => TagControl_Scope__1185023272.\u03b1scopeId = value; }

            internal TagControl_Scope__1185023272(Codeunit10012739 \u03b2parent, NavOption pControlType, NavCode pProfileID, NavCode pControlID, NavText pTag) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pProfileID = pProfileID.ModifyLength(20);
                this.pControlID = pControlID.ModifyLength(25);
                this.pTag = pTag.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent._TAGGED_CONTROLS.Target.ALInit();
                StmtHit(1);
                base.Parent._TAGGED_CONTROLS.Target.SetFieldValueSafe(2, NavType.Option, this.pControlType);
                StmtHit(2);
                base.Parent._TAGGED_CONTROLS.Target.SetFieldValueSafe(4, NavType.Code, this.pControlID);
                StmtHit(3);
                base.Parent._TAGGED_CONTROLS.Target.SetFieldValueSafe(5, NavType.Text, new NavText(100, this.pTag));
                if (CStmtHit(4) & (base.Parent._TAGGED_CONTROLS.Target.ALInsert(DataError.TrapError)))
                    ;
            }
        }

        private void UnloadControl(NavOption pControlType, NavText pControlID)
        {
            using (UnloadControl_Scope_2143954076 \u03b2scope = new UnloadControl_Scope_2143954076(this, pControlType, pControlID))
                \u03b2scope.Run();
        }

        [NavName("UnloadControl")]
        [SignatureSpan(104427302283313185L)]
        [SourceSpans(104990200697258019L, 105271675674034242L, 105553150650810427L, 105834638512488485L, 106116117784231977L, 106397592761008216L, 106960521239724040L)]
        private sealed class UnloadControl_Scope_2143954076 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlType")]
            public NavOption pControlType;
            [NavName("pControlID")]
            public NavText pControlID;
            protected override uint RawScopeId { get => UnloadControl_Scope_2143954076.\u03b1scopeId; set => UnloadControl_Scope_2143954076.\u03b1scopeId = value; }

            internal UnloadControl_Scope_2143954076(Codeunit10012739 \u03b2parent, NavOption pControlType, NavText pControlID) : base(\u03b2parent)
            {
                this.pControlType = pControlType;
                this.pControlID = pControlID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.loadedControlsTemp.Target.ALReset();
                StmtHit(1);
                base.Parent.loadedControlsTemp.Target.ALSetRangeSafe(2, NavType.Option, this.pControlType);
                StmtHit(2);
                base.Parent.loadedControlsTemp.Target.ALSetRangeSafe(4, NavType.Code, this.pControlID);
                if (CStmtHit(3) & (base.Parent.loadedControlsTemp.Target.ALFindSet(DataError.TrapError)))
                {
                    StmtHit(4);
                    base.Parent.loadedControlsTemp.Target.ALDeleteAll();
                    StmtHit(5);
                    base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("UnloadControl(%1, %2)", this.pControlType, this.pControlID)));
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 386740117")]
        public void UpdateButtonSkin(NavCode menuID, int buttonNo, [NavObjectId(ObjectId = 99008870)][NavByReferenceAttribute] INavRecordHandle skinEntity, NavText fieldListCSV)
        {
            using (UpdateButtonSkin_Scope__190457558 \u03b2scope = new UpdateButtonSkin_Scope__190457558(this, menuID, buttonNo, skinEntity, fieldListCSV))
                \u03b2scope.Run();
        }

        [NavName("UpdateButtonSkin")]
        [SignatureSpan(1078330696159133726L)]
        [SourceSpans(1079738058158112793L, 1080019537429856361L, 1080582470203539492L, 1080863945180315719L, 1081145420157091906L, 1081426895133868094L, 1081708365815676936L)]
        private sealed class UpdateButtonSkin_Scope__190457558 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("MenuID")]
            public NavCode menuID;
            [NavName("ButtonNo")]
            public int buttonNo;
            [NavName("SkinEntity")]
            public INavRecordHandle skinEntity;
            [NavName("FieldListCSV")]
            public NavText fieldListCSV;
            [NavName("RecRef")]
            public NavRecordRef recRef;
            [NavName("jArr")]
            public NavJsonArray jArr;
            protected override uint RawScopeId { get => UpdateButtonSkin_Scope__190457558.\u03b1scopeId; set => UpdateButtonSkin_Scope__190457558.\u03b1scopeId = value; }

            internal UpdateButtonSkin_Scope__190457558(Codeunit10012739 \u03b2parent, NavCode menuID, int buttonNo, [NavObjectId(ObjectId = 99008870)][NavByReferenceAttribute] INavRecordHandle skinEntity, NavText fieldListCSV) : base(\u03b2parent)
            {
                this.menuID = menuID.ModifyLength(20);
                this.buttonNo = buttonNo;
                this.skinEntity = skinEntity;
                this.fieldListCSV = fieldListCSV.ModifyLength(0);
                this.recRef = new NavRecordRef(this, SecurityFiltering.Validated);
                this.jArr = NavJsonArray.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("UpdateButtonSkin(%1, %2, Entity, %3)", this.menuID, ALCompiler.ToNavValue(this.buttonNo), this.fieldListCSV)));
                }

                StmtHit(2);
                this.recRef.ALGetTable(this.skinEntity.Target);
                StmtHit(3);
                this.jArr.ALAdd(ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(this.menuID), this.buttonNo })));
                StmtHit(4);
                this.jArr.ALAdd(ALCompiler.ObjectToExactNavValue<NavJsonObject>(base.Parent.pOSUTILS.Target.Invoke(1885169396, new object[] { new NavText(""), new ByRef<NavRecordRef>(() => this.recRef, setValue => this.recRef.ALAssign(setValue)), this.fieldListCSV })));
                StmtHit(5);
                base.Parent.SendPOSCommandEvent(new NavText("_UPDATE_BTN_SKIN"), new NavText(NavFormatEvaluateHelper.Format(this.jArr)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 145963749")]
        public void UpdateContext(ByRef<NavDictionary<NavText, NavText>> dict, NavText pTag, bool isMerging)
        {
            using (UpdateContext_Scope_1114993508 \u03b2scope = new UpdateContext_Scope_1114993508(this, dict, pTag, isMerging))
                \u03b2scope.Run();
        }

        [NavName("UpdateContext")]
        [SignatureSpan(48132281158271003L)]
        [SourceSpans(50947018041131033L, 51228497312874534L, 51509955109781530L, 51791430087802892L, 52072922243203101L, 52635872196755490L, 52917360058433560L, 53198852215078938L, 53480344371724327L, 53761823643467821L, 54324739237281829L, 54887684895866907L, 55169164167610417L, 55450652029288491L, 55732144185933860L, 56013636342579262L, 57139454645305355L, 57420942506983459L, 57702421778726953L, 57983875280666632L)]
        private sealed class UpdateContext_Scope_1114993508 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("dict")]
            public ByRef<NavDictionary<NavText, NavText>> dict;
            [NavName("pTag")]
            public NavText pTag;
            [NavName("isMerging")]
            public bool isMerging;
            [NavName("ks")]
            public NavList<NavText> ks = NavList<NavText>.Default;
            [NavName("k")]
            public NavText k = NavText.Default(0);
            [NavName("v")]
            public NavText v = NavText.Default(0);
            [NavName("oldValue")]
            public NavText oldValue = NavText.Default(0);
            [NavName("newK")]
            public NavText newK = NavText.Default(0);
            [NavName("mods")]
            public NavDictionary<NavText, NavText> mods = NavDictionary<NavText, NavText>.Default;
            [NavName("shouldUpdate")]
            public bool shouldUpdate = default(bool);
            protected override uint RawScopeId { get => UpdateContext_Scope_1114993508.\u03b1scopeId; set => UpdateContext_Scope_1114993508.\u03b1scopeId = value; }

            internal UpdateContext_Scope_1114993508(Codeunit10012739 \u03b2parent, ByRef<NavDictionary<NavText, NavText>> dict, NavText pTag, bool isMerging) : base(\u03b2parent)
            {
                this.dict = dict;
                this.pTag = pTag.ModifyLength(0);
                this.isMerging = isMerging;
                this.ks = NavList<NavText>.Default;
                this.mods = NavDictionary<NavText, NavText>.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("UpdateContext"));
                }

                StmtHit(2);
                this.ks = this.dict.Value.ALKeys;
                StmtHit(3);
                foreach (var @tmp0 in this.ks)
                {
                    this.k = @tmp0;
                    {
                        CStmtHit(4);
                        this.v = this.dict.Value.ALGet(this.k);
                        StmtHit(5);
                        this.shouldUpdate = false;
                        if (CStmtHit(6) & (this.isMerging))
                        {
                            if (CStmtHit(7) & (this.v != ""))
                                if (CStmtHit(8) & (base.Parent.GetValue(this.k) == ""))
                                {
                                    StmtHit(9);
                                    this.shouldUpdate = true;
                                }
                        }
                        else
                        {
                            StmtHit(10);
                            this.shouldUpdate = true;
                        }

                        if (CStmtHit(11) & (this.shouldUpdate))
                        {
                            StmtHit(12);
                            this.oldValue = base.Parent.SetValue_711940861(this.k, this.v, this.pTag);
                            if (CStmtHit(13) & (!base.Parent._ignoreModifications))
                            {
                                if (CStmtHit(14) & (this.oldValue != this.v))
                                {
                                    if (CStmtHit(15) & (this.mods.ALAdd(DataError.TrapError, ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.context.Target.Invoke(-1140655136, Array.Empty<object>())), this.v)))
                                        ;
                                }
                            }
                        }
                    }
                }

                StmtHit(16);
                if (CStmtHit(17) & (!base.Parent._ignoreModifications))
                {
                    StmtHit(18);
                    base.Parent._lastModifiedContext = this.mods;
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 783896973")]
        public void UpdateMenuPermissions()
        {
            using (UpdateMenuPermissions_Scope__1274942724 \u03b2scope = new UpdateMenuPermissions_Scope__1274942724(this))
                \u03b2scope.Run();
        }

        [NavName("UpdateMenuPermissions")]
        [SignatureSpan(1194016911614148643L)]
        [SourceSpans(1195424273613127705L, 1195705752884871216L, 1196268685658947596L, 1196550190700101677L, 1196831669971910734L, 1197394619925397599L, 1197957535519211531L, 1198520485472763940L, 1198801960449540131L, 1199083435426316362L, 1199646385380065292L, 1199927890421415981L, 1200209369693159519L, 1200490810310197259L, 1200772285286973476L, 1201053755968782344L)]
        private sealed class UpdateMenuPermissions_Scope__1274942724 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("recid")]
            public NavRecordId recid = NavRecordId.Default;
            [NavName("found")]
            public bool found = default(bool);
            protected override uint RawScopeId { get => UpdateMenuPermissions_Scope__1274942724.\u03b1scopeId; set => UpdateMenuPermissions_Scope__1274942724.\u03b1scopeId = value; }

            internal UpdateMenuPermissions_Scope__1274942724(Codeunit10012739 \u03b2parent) : base(\u03b2parent)
            {
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("UpdateMenuPermissions()"));
                }

                StmtHit(2);
                foreach (var @tmp0 in base.Parent._BlockedMenuButtons)
                {
                    this.recid = @tmp0;
                    {
                        if (CStmtHit(3) & (base.Parent._MenuButtonEntities.Target.ALGet(DataError.TrapError, this.recid)))
                        {
                            CStmtHit(4);
                            base.Parent.MenuButtonRequest(new NavText(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(10, NavType.Code))), new NavText(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code))), base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(2, NavType.Integer).ToInt32(), base.Parent._MenuButtonEntities, new ByRef<bool>(() => this.found, setValue => this.found = setValue));
                            StmtHit(5);
                            base.Parent.RefreshMenuButton(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code)), base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(2, NavType.Integer).ToInt32());
                        }
                    }
                }

                StmtHit(6);
                StmtHit(7);
                base.Parent._MenuButtonEntities.Target.ALReset();
                StmtHit(8);
                base.Parent._BlockedMenuButtons = NavList<NavRecordId>.Default;
                StmtHit(9);
                base.Parent.ButtonPermissionRequest(base.Parent._MenuButtonEntities, new ByRef<NavList<NavRecordId>>(() => base.Parent._BlockedMenuButtons, setValue => base.Parent._BlockedMenuButtons = setValue));
                StmtHit(10);
                foreach (var @tmp1 in base.Parent._BlockedMenuButtons)
                {
                    this.recid = @tmp1;
                    {
                        if (CStmtHit(11) & (base.Parent._MenuButtonEntities.Target.ALGet(DataError.TrapError, this.recid)))
                        {
                            CStmtHit(12);
                            base.Parent.RefreshMenuButton(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code)), base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(2, NavType.Integer).ToInt32());
                        }
                    }
                }

                StmtHit(13);
                StmtHit(14);
                base.Parent._MenuButtonEntities.Target.ALReset();
            }
        }

        private void UpdateMenuPosition(NavText pMenuID, NavText pButtonPadID)
        {
            using (UpdateMenuPosition_Scope__683284347 \u03b2scope = new UpdateMenuPosition_Scope__683284347(this, pMenuID, pButtonPadID))
                \u03b2scope.Run();
        }

        [NavName("UpdateMenuPosition")]
        [SignatureSpan(769834147382231078L)]
        [SourceSpans(771522958588182553L, 771804437859926102L, 772367370633609254L, 772930320587161727L, 773493270540714099L, 773774745517490301L, 774337708355944477L, 774619200512589866L, 774900679784333332L, 775463642622787629L, 775745121894531126L, 776589508170154018L, 776871000326799391L, 777152479598542899L, 777433954575581204L, 777715446732095566L, 778559854482423827L, 779404240758046728L)]
        private sealed class UpdateMenuPosition_Scope__683284347 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuID")]
            public NavText pMenuID;
            [NavName("pButtonPadID")]
            public NavText pButtonPadID;
            [NavName("i")]
            public int i = default(int);
            [NavName("n")]
            public int n = default(int);
            [NavName("lastPosition")]
            public NavText lastPosition = NavText.Default(0);
            protected override uint RawScopeId { get => UpdateMenuPosition_Scope__683284347.\u03b1scopeId; set => UpdateMenuPosition_Scope__683284347.\u03b1scopeId = value; }

            internal UpdateMenuPosition_Scope__683284347(Codeunit10012739 \u03b2parent, NavText pMenuID, NavText pButtonPadID) : base(\u03b2parent)
            {
                this.pMenuID = pMenuID.ModifyLength(0);
                this.pButtonPadID = pButtonPadID.ModifyLength(0);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("UpdateMenuPosition(%1, %2)", this.pMenuID, this.pButtonPadID)));
                }

                StmtHit(2);
                base.Parent.SetMenuVisible(this.pMenuID, true);
                StmtHit(3);
                this.lastPosition = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent._CONTROLS.Target.Invoke(-1790301861, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), this.pMenuID, new NavText(base.Parent._SHARED.Target.ALFieldName(20)) }));
                StmtHit(4);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), this.pMenuID, new NavText(base.Parent._SHARED.Target.ALFieldName(20)), new NavText("") });
                StmtHit(5);
                base.Parent._CONTROLS.Target.Invoke(-455720855, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 7), this.pMenuID, new NavText(base.Parent._SHARED.Target.ALFieldName(20)), this.pButtonPadID });
                if (CStmtHit(6) & (this.lastPosition != ""))
                {
                    if (CStmtHit(7) & (this.lastPosition == this.pButtonPadID))
                    {
                        StmtHit(8);
                        return;
                    }
                    else if (CStmtHit(9) & (base.Parent.GetButtonPad(this.lastPosition)))
                    {
                        StmtHit(10);
                        base.Parent.RemoveMenu(this.pMenuID, new NavCode(20, this.lastPosition));
                    }
                }

                if (CStmtHit(11) & (!base.Parent.MenuLoaded(this.pMenuID)))
                {
                    if (CStmtHit(12) & (base.Parent.GetMenu(this.pMenuID)))
                    {
                        StmtHit(13);
                        this.n = base.Parent.GetNrOfButtons(base.Parent._MenuEntities);
                        this.i = 1;
                        StmtHit(14);
                        int @tmp0 = this.n;
                        for (; this.i <= @tmp0;)
                        {
                            {
                                CStmtHit(15);
                                base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { this.pMenuID, this.i })), new NavText(base.Parent._SHARED.Target.ALFieldName(5)), NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 8).ToInt32() });
                            }

                            if (this.i >= @tmp0)
                                break;
                            this.i = this.i + 1;
                        }

                        StmtHit(16);
                    }
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 22372821")]
        public void UpdatePOSData1(int pTableNo, int pFilterField1, NavText pFilter1)
        {
            using (UpdatePOSData1_Scope__469435878 \u03b2scope = new UpdatePOSData1_Scope__469435878(this, pTableNo, pFilterField1, pFilter1))
                \u03b2scope.Run();
        }

        [NavName("UpdatePOSData1")]
        [SignatureSpan(525513841770692636L)]
        [SourceSpans(526076765954441281L, 526358236636250120L)]
        private sealed class UpdatePOSData1_Scope__469435878 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pTableNo")]
            public int pTableNo;
            [NavName("pFilterField1")]
            public int pFilterField1;
            [NavName("pFilter1")]
            public NavText pFilter1;
            protected override uint RawScopeId { get => UpdatePOSData1_Scope__469435878.\u03b1scopeId; set => UpdatePOSData1_Scope__469435878.\u03b1scopeId = value; }

            internal UpdatePOSData1_Scope__469435878(Codeunit10012739 \u03b2parent, int pTableNo, int pFilterField1, NavText pFilter1) : base(\u03b2parent)
            {
                this.pTableNo = pTableNo;
                this.pFilterField1 = pFilterField1;
                this.pFilter1 = pFilter1.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.UpdatePOSData2(this.pTableNo, this.pFilterField1, this.pFilter1, 0, new NavText(""));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4290575969")]
        public void UpdatePOSData2(int pTableNo, int pFilterField1, NavText pFilter1, int pFilterField2, NavText pFilter2)
        {
            using (UpdatePOSData2_Scope_2119086763 \u03b2scope = new UpdatePOSData2_Scope_2119086763(this, pTableNo, pFilterField1, pFilter1, pFilterField2, pFilter2))
                \u03b2scope.Run();
        }

        [NavName("UpdatePOSData2")]
        [SignatureSpan(526921216654573596L)]
        [SourceSpans(527484140838322266L, 527765611520131080L)]
        private sealed class UpdatePOSData2_Scope_2119086763 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pTableNo")]
            public int pTableNo;
            [NavName("pFilterField1")]
            public int pFilterField1;
            [NavName("pFilter1")]
            public NavText pFilter1;
            [NavName("pFilterField2")]
            public int pFilterField2;
            [NavName("pFilter2")]
            public NavText pFilter2;
            protected override uint RawScopeId { get => UpdatePOSData2_Scope_2119086763.\u03b1scopeId; set => UpdatePOSData2_Scope_2119086763.\u03b1scopeId = value; }

            internal UpdatePOSData2_Scope_2119086763(Codeunit10012739 \u03b2parent, int pTableNo, int pFilterField1, NavText pFilter1, int pFilterField2, NavText pFilter2) : base(\u03b2parent)
            {
                this.pTableNo = pTableNo;
                this.pFilterField1 = pFilterField1;
                this.pFilter1 = pFilter1.ModifyLength(0);
                this.pFilterField2 = pFilterField2;
                this.pFilter2 = pFilter2.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.UpdatePOSData3(this.pTableNo, this.pFilterField1, this.pFilter1, this.pFilterField2, this.pFilter2, 0, new NavText(""));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3028615491")]
        public void UpdatePOSData3(int pTableNo, int pFilterField1, NavText pFilter1, int pFilterField2, NavText pFilter2, int pFilterField3, NavText pFilter3)
        {
            using (UpdatePOSData3_Scope__934659077 \u03b2scope = new UpdatePOSData3_Scope__934659077(this, pTableNo, pFilterField1, pFilter1, pFilterField2, pFilter2, pFilterField3, pFilter3))
                \u03b2scope.Run();
        }

        [NavName("UpdatePOSData3")]
        [SignatureSpan(528328591538454556L)]
        [SourceSpans(528891515722203251L, 529172986404012040L)]
        private sealed class UpdatePOSData3_Scope__934659077 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pTableNo")]
            public int pTableNo;
            [NavName("pFilterField1")]
            public int pFilterField1;
            [NavName("pFilter1")]
            public NavText pFilter1;
            [NavName("pFilterField2")]
            public int pFilterField2;
            [NavName("pFilter2")]
            public NavText pFilter2;
            [NavName("pFilterField3")]
            public int pFilterField3;
            [NavName("pFilter3")]
            public NavText pFilter3;
            protected override uint RawScopeId { get => UpdatePOSData3_Scope__934659077.\u03b1scopeId; set => UpdatePOSData3_Scope__934659077.\u03b1scopeId = value; }

            internal UpdatePOSData3_Scope__934659077(Codeunit10012739 \u03b2parent, int pTableNo, int pFilterField1, NavText pFilter1, int pFilterField2, NavText pFilter2, int pFilterField3, NavText pFilter3) : base(\u03b2parent)
            {
                this.pTableNo = pTableNo;
                this.pFilterField1 = pFilterField1;
                this.pFilter1 = pFilter1.ModifyLength(0);
                this.pFilterField2 = pFilterField2;
                this.pFilter2 = pFilter2.ModifyLength(0);
                this.pFilterField3 = pFilterField3;
                this.pFilter3 = pFilter3.ModifyLength(0);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.UpdatePOSData4(this.pTableNo, this.pFilterField1, this.pFilter1, this.pFilterField2, this.pFilter2, this.pFilterField3, this.pFilter3, 0, new NavText(""));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 307033845")]
        public void UpdatePOSData4(int pTableNo, int pFilterField1, NavText pFilter1, int pFilterField2, NavText pFilter2, int pFilterField3, NavText pFilter3, int pFilterField4, NavText pFilter4)
        {
            using (UpdatePOSData4_Scope__197186925 \u03b2scope = new UpdatePOSData4_Scope__197186925(this, pTableNo, pFilterField1, pFilter1, pFilterField2, pFilter2, pFilterField3, pFilter3, pFilterField4, pFilter4))
                \u03b2scope.Run();
        }

        [NavName("UpdatePOSData4")]
        [SignatureSpan(529735966422335516L)]
        [SourceSpans(531143315536478335L, 531987740466741279L, 532269228328419356L, 532550707600162870L, 532832182576939050L, 533395128235524124L, 533676607507267638L, 533958082484043818L, 534521028142628892L, 534802507414372406L, 535083982391148586L, 535646928049733660L, 535928407321477174L, 536209882298253354L, 536772815071936550L, 537054285753745416L)]
        private sealed class UpdatePOSData4_Scope__197186925 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pTableNo")]
            public int pTableNo;
            [NavName("pFilterField1")]
            public int pFilterField1;
            [NavName("pFilter1")]
            public NavText pFilter1;
            [NavName("pFilterField2")]
            public int pFilterField2;
            [NavName("pFilter2")]
            public NavText pFilter2;
            [NavName("pFilterField3")]
            public int pFilterField3;
            [NavName("pFilter3")]
            public NavText pFilter3;
            [NavName("pFilterField4")]
            public int pFilterField4;
            [NavName("pFilter4")]
            public NavText pFilter4;
            [NavName("lRecRef")]
            public NavRecordRef lRecRef;
            [NavName("lFieldRef")]
            public NavFieldRef lFieldRef;
            protected override uint RawScopeId { get => UpdatePOSData4_Scope__197186925.\u03b1scopeId; set => UpdatePOSData4_Scope__197186925.\u03b1scopeId = value; }

            internal UpdatePOSData4_Scope__197186925(Codeunit10012739 \u03b2parent, int pTableNo, int pFilterField1, NavText pFilter1, int pFilterField2, NavText pFilter2, int pFilterField3, NavText pFilter3, int pFilterField4, NavText pFilter4) : base(\u03b2parent)
            {
                this.pTableNo = pTableNo;
                this.pFilterField1 = pFilterField1;
                this.pFilter1 = pFilter1.ModifyLength(0);
                this.pFilterField2 = pFilterField2;
                this.pFilter2 = pFilter2.ModifyLength(0);
                this.pFilterField3 = pFilterField3;
                this.pFilter3 = pFilter3.ModifyLength(0);
                this.pFilterField4 = pFilterField4;
                this.pFilter4 = pFilter4.ModifyLength(0);
                this.lRecRef = new NavRecordRef(this, SecurityFiltering.Validated);
                this.lFieldRef = new NavFieldRef(this);
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("UpdatePOSData: table=%1, f1={%1, %2}, f2={%2, %3}, f3={%4, %5}, f4={%6, %7}", ALCompiler.ToNavValue(this.pTableNo), ALCompiler.ToNavValue(this.pFilterField1), this.pFilter1, ALCompiler.ToNavValue(this.pFilterField2), this.pFilter2, ALCompiler.ToNavValue(this.pFilterField3), this.pFilter3, ALCompiler.ToNavValue(this.pFilterField4), this.pFilter4)));
                StmtHit(1);
                this.lRecRef.ALOpen(CompilationTarget.Cloud, this.pTableNo);
                if (CStmtHit(2) & (this.pFilterField1 > 0))
                {
                    StmtHit(3);
                    this.lFieldRef.ALAssign(this.lRecRef.ALField(this, this.pFilterField1));
                    StmtHit(4);
                    this.lFieldRef.ALSetFilter(this.pFilter1);
                }

                if (CStmtHit(5) & (this.pFilterField1 > 0))
                {
                    StmtHit(6);
                    this.lFieldRef.ALAssign(this.lRecRef.ALField(this, this.pFilterField2));
                    StmtHit(7);
                    this.lFieldRef.ALSetFilter(this.pFilter2);
                }

                if (CStmtHit(8) & (this.pFilterField3 > 0))
                {
                    StmtHit(9);
                    this.lFieldRef.ALAssign(this.lRecRef.ALField(this, this.pFilterField3));
                    StmtHit(10);
                    this.lFieldRef.ALSetFilter(this.pFilter3);
                }

                if (CStmtHit(11) & (this.pFilterField4 > 0))
                {
                    StmtHit(12);
                    this.lFieldRef.ALAssign(this.lRecRef.ALField(this, this.pFilterField4));
                    StmtHit(13);
                    this.lFieldRef.ALSetFilter(this.pFilter4);
                }

                StmtHit(14);
                base.Parent.UpdatePOSData(new ByRef<NavRecordRef>(() => this.lRecRef, setValue => this.lRecRef.ALAssign(setValue)), false);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 4160081248")]
        public void UpdatePOSData(ByRef<NavRecordRef> pRecRef, bool pDelete)
        {
            using (UpdatePOSData_Scope_1545030233 \u03b2scope = new UpdatePOSData_Scope_1545030233(this, pRecRef, pDelete))
                \u03b2scope.Run();
        }

        [NavName("UpdatePOSData")]
        [SignatureSpan(507217968280240155L)]
        [SourceSpans(509188280232771609L, 509469759504515140L, 510032692281606156L, 510877168748134468L, 512003068655239228L, 513128968562343995L, 514254868469448764L, 515380768376553545L, 516506668283658300L, 517632568190763073L, 518758468097867838L, 519884368004972606L, 521010267912077375L, 521854675662536727L, 522136150639312970L, 522417638500991012L, 522980609929379934L, 523262084906156067L, 523543568472866858L, 523825000499970090L, 524106475476746301L, 524950861752369160L)]
        private sealed class UpdatePOSData_Scope_1545030233 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pRecRef")]
            public ByRef<NavRecordRef> pRecRef;
            [NavName("pDelete")]
            public bool pDelete;
            [NavName("fieldRef")]
            public NavFieldRef fieldRef;
            [NavName("fldNo")]
            public int fldNo = default(int);
            [NavName("JSONUtil")]
            public NavCodeunitHandle jSONUtil;
            [NavName("c")]
            public int c = default(int);
            protected override uint RawScopeId { get => UpdatePOSData_Scope_1545030233.\u03b1scopeId; set => UpdatePOSData_Scope_1545030233.\u03b1scopeId = value; }

            internal UpdatePOSData_Scope_1545030233(Codeunit10012739 \u03b2parent, ByRef<NavRecordRef> pRecRef, bool pDelete) : base(\u03b2parent)
            {
                this.pRecRef = pRecRef;
                this.pDelete = pDelete;
                this.fieldRef = new NavFieldRef(this);
                this.jSONUtil = new NavCodeunitHandle(this, 1234);
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("UpdatePOSData(%1)", ALCompiler.ToNavValue(this.pRecRef.Value.ALName))));
                }

                StmtHit(2);
                int @tmp1 = this.pRecRef.Value.ALNumber;
                if ((@tmp1 == 99008900))
                {
                    {
                        StmtHit(3);
                        base.Parent.AddJsonRequest_870727125(new NavText("HARDWAREPROFILESETUP"), this.pRecRef.Value);
                    }

                    goto @tmp0;
                }

                if ((@tmp1 == 99001790))
                {
                    {
                        StmtHit(4);
                        base.Parent.AddJsonRequest_870727125(new NavText("PRINTERSETUP"), this.pRecRef.Value);
                    }

                    goto @tmp0;
                }

                if ((@tmp1 == 99001791))
                {
                    {
                        StmtHit(5);
                        base.Parent.AddJsonRequest_870727125(new NavText("DRAWERSETUP"), this.pRecRef.Value);
                    }

                    goto @tmp0;
                }

                if ((@tmp1 == 99001792))
                {
                    {
                        StmtHit(6);
                        base.Parent.AddJsonRequest_870727125(new NavText("DISPLAYSETUP"), this.pRecRef.Value);
                    }

                    goto @tmp0;
                }

                if ((@tmp1 == 99001793))
                {
                    {
                        StmtHit(7);
                        base.Parent.AddJsonRequest_870727125(new NavText("AUTHENTICATIONDEVICESETUP"), this.pRecRef.Value);
                    }

                    goto @tmp0;
                }

                if ((@tmp1 == 99001794))
                {
                    {
                        StmtHit(8);
                        base.Parent.AddJsonRequest_870727125(new NavText("SCANNERSETUP"), this.pRecRef.Value);
                    }

                    goto @tmp0;
                }

                if ((@tmp1 == 99008918))
                {
                    {
                        StmtHit(9);
                        base.Parent.AddJsonRequest_870727125(new NavText("SERIALDEVICESETUP"), this.pRecRef.Value);
                    }

                    goto @tmp0;
                }

                if ((@tmp1 == 99001800))
                {
                    {
                        StmtHit(10);
                        base.Parent.AddJsonRequest_870727125(new NavText("MSRDEVICESETUP"), this.pRecRef.Value);
                    }

                    goto @tmp0;
                }

                if ((@tmp1 == 99008957))
                {
                    {
                        StmtHit(11);
                        base.Parent.AddJsonRequest_870727125(new NavText("DALLASKEYSETUP"), this.pRecRef.Value);
                    }

                    goto @tmp0;
                }

                if ((@tmp1 == 99008971))
                {
                    {
                        StmtHit(12);
                        base.Parent.AddJsonRequest_870727125(new NavText("PROPERTYPROFILE"), this.pRecRef.Value);
                    }

                    goto @tmp0;
                }

                {
                    {
                        StmtHit(13);
                        this.c = 0;
                        StmtHit(14);
                        this.jSONUtil.Target.Invoke(-473954417, new object[] { new NavText(ALSystemString.ALDelChr(this.pRecRef.Value.ALName, "=", " ")) });
                        if (CStmtHit(15) & (this.pRecRef.Value.ALFind(DataError.TrapError, "-")))
                            do
                            {
                                StmtHit(16);
                                base.Parent.pOSUTILS.Target.Invoke(-417084632, new object[] { new NavText("GENERAL_" + NavFormatEvaluateHelper.Format(ALCompiler.ToNavValue(this.c))), this.pRecRef, this.jSONUtil });
                                StmtHit(17);
                                this.c = this.c + 1;
                            }
                            while (!(CStmtHit(18) & (this.pRecRef.Value.ALNext() == 0)));
                        StmtHit(19);
                        this.jSONUtil.Target.Invoke(2090071347, Array.Empty<object>());
                        StmtHit(20);
                        base.Parent.pendingPOSData.ALAdd(ALCompiler.ObjectToExactNavValue<NavText>(this.jSONUtil.Target.Invoke(1959899813, Array.Empty<object>())));
                    }
                }

                @tmp0:
                    ;
            }
        }

        private void UpdateSelectedJournalLine(bool updateTransactionNewLine)
        {
            using (UpdateSelectedJournalLine_Scope__1502637049 \u03b2scope = new UpdateSelectedJournalLine_Scope__1502637049(this, updateTransactionNewLine))
                \u03b2scope.Run();
        }

        [NavName("UpdateSelectedJournalLine")]
        [SignatureSpan(474003946790453293L)]
        [SourceSpans(474566858089299993L, 474848337361043520L, 475411270134726734L, 475692740816535560L)]
        private sealed class UpdateSelectedJournalLine_Scope__1502637049 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("updateTransactionNewLine")]
            public bool updateTransactionNewLine;
            protected override uint RawScopeId { get => UpdateSelectedJournalLine_Scope__1502637049.\u03b1scopeId; set => UpdateSelectedJournalLine_Scope__1502637049.\u03b1scopeId = value; }

            internal UpdateSelectedJournalLine_Scope__1502637049(Codeunit10012739 \u03b2parent, bool updateTransactionNewLine) : base(\u03b2parent)
            {
                this.updateTransactionNewLine = updateTransactionNewLine;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("UpdateSelectedJournalLine()")));
                }

                StmtHit(2);
                base.Parent._ActiveController.Target.InvokeInterfaceMethod("UpdateSelectedJournalLine", -1502637049, new object[] { this.updateTransactionNewLine });
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1300627050")]
        public void UpdateTagExpressions(ByRef<NavDictionary<NavText, NavText>> dict)
        {
            using (UpdateTagExpressions_Scope__1041547779 \u03b2scope = new UpdateTagExpressions_Scope__1041547779(this, dict))
                \u03b2scope.Run();
        }

        [NavName("UpdateTagExpressions")]
        [SignatureSpan(39969506831761442L)]
        [SourceSpans(41658343807516697L, 41939823079260205L, 42221280876167196L, 42502755853991948L, 42784248009588770L, 43065722986364978L, 43628685824819225L, 43910177981464614L, 44191657253208100L, 44473145114886207L, 44754624386629690L, 45317574340182075L, 46161960615804954L, 46443452772450359L, 46724932044193844L, 47006355481362443L, 47287826163171336L)]
        private sealed class UpdateTagExpressions_Scope__1041547779 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("dict")]
            public ByRef<NavDictionary<NavText, NavText>> dict;
            [NavName("tags")]
            public NavList<NavText> tags = NavList<NavText>.Default;
            [NavName("tag")]
            public NavText tag = NavText.Default(0);
            [NavName("expr")]
            public NavText expr = NavText.Default(0);
            [NavName("isValid")]
            public bool isValid = default(bool);
            protected override uint RawScopeId { get => UpdateTagExpressions_Scope__1041547779.\u03b1scopeId; set => UpdateTagExpressions_Scope__1041547779.\u03b1scopeId = value; }

            internal UpdateTagExpressions_Scope__1041547779(Codeunit10012739 \u03b2parent, ByRef<NavDictionary<NavText, NavText>> dict) : base(\u03b2parent)
            {
                this.dict = dict;
                this.tags = NavList<NavText>.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 3))
                {
                    StmtHit(1);
                    base.Parent.LogTrace(new NavText("UpdateTagExpressions"));
                }

                StmtHit(2);
                this.tags = this.dict.Value.ALKeys;
                StmtHit(3);
                foreach (var @tmp0 in this.tags)
                {
                    this.tag = @tmp0;
                    {
                        CStmtHit(4);
                        this.expr = this.dict.Value.ALGet(this.tag);
                        StmtHit(5);
                        this.tag = ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.context.Target.Invoke(-1846915125, new object[] { this.tag }));
                        if (CStmtHit(6) & (this.expr != ""))
                        {
                            if (CStmtHit(7) & (NavTextExtensions.ALContains(this.expr, new NavText("%1"))))
                            {
                                StmtHit(8);
                                this.isValid = true;
                                if (CStmtHit(9) & (!base.Parent._contextExpressions.ALContainsKey(this.tag)))
                                {
                                    StmtHit(10);
                                    base.Parent._contextExpressions.ALAdd(DataError.ThrowError, this.tag, this.expr);
                                }
                                else
                                {
                                    StmtHit(11);
                                    base.Parent._contextExpressions.ALSet(this.tag, this.expr);
                                }
                            }
                        }

                        if (CStmtHit(12) & (!this.isValid))
                            if (CStmtHit(13) & (base.Parent._contextExpressions.ALContainsKey(this.tag)))
                            {
                                StmtHit(14);
                                base.Parent._contextExpressions.ALRemove(this.tag);
                            }
                    }
                }

                StmtHit(15);
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 2040408003")]
        public void UploadMenuHeaderRec([NavObjectId(ObjectId = 99009053)][NavByReferenceAttribute] INavRecordHandle pMenuEntities)
        {
            using (UploadMenuHeaderRec_Scope__1778858761 \u03b2scope = new UploadMenuHeaderRec_Scope__1778858761(this, pMenuEntities))
                \u03b2scope.Run();
        }

        [NavName("UploadMenuHeaderRec")]
        [SignatureSpan(709035526628769825L)]
        [SourceSpans(709598463697420313L, 709879942969163857L, 710442888627748898L, 711005860056137763L, 711287335032913986L, 711568822894592043L, 711850302166335529L, 712131759963242556L, 712413234940018802L, 712976197778472996L, 713257677050216572L, 713820618413834280L, 714102046145970184L)]
        private sealed class UploadMenuHeaderRec_Scope__1778858761 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuEntities")]
            public INavRecordHandle pMenuEntities;
            protected override uint RawScopeId { get => UploadMenuHeaderRec_Scope__1778858761.\u03b1scopeId; set => UploadMenuHeaderRec_Scope__1778858761.\u03b1scopeId = value; }

            internal UploadMenuHeaderRec_Scope__1778858761(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99009053)][NavByReferenceAttribute] INavRecordHandle pMenuEntities) : base(\u03b2parent)
            {
                this.pMenuEntities = pMenuEntities;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("UploadMenuHeaderRec(%1)", ALCompiler.ToNavValue(this.pMenuEntities.Target.ALCount))));
                }

                if (CStmtHit(2) & (this.pMenuEntities.Target.ALFind(DataError.TrapError, "-")))
                    do
                    {
                        StmtHit(3);
                        base.Parent._MenuEntities.Target.ALInit();
                        StmtHit(4);
                        base.Parent._MenuEntities.Target.ALTransferFields(this.pMenuEntities.Target, true);
                        if (CStmtHit(5) & (!base.Parent._MenuEntities.Target.ALInsert(DataError.TrapError)))
                        {
                            StmtHit(6);
                            base.Parent._MenuEntities.Target.ALModify(DataError.ThrowError);
                        }

                        StmtHit(7);
                        base.Parent.RefreshMenu_1500321386(new NavText(((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(1, NavType.Code))), false);
                        StmtHit(8);
                        base.Parent.HideExtraButtons(new NavText(((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(10, NavType.Code))), new NavText(((NavCode)base.Parent._MenuEntities.Target.GetFieldValueSafe(1, NavType.Code))), base.Parent.GetNrOfButtons(base.Parent._MenuEntities));
                        if (CStmtHit(9) & (base.Parent.currDataTag != ""))
                        {
                            StmtHit(10);
                            base.Parent.TagControl(NavOption.Create(NCLEnumMetadata.Create(99008881), 7), ((NavCode)this.pMenuEntities.Target.GetFieldValueSafe(10, NavType.Code)), new NavCode(25, ((NavCode)this.pMenuEntities.Target.GetFieldValueSafe(1, NavType.Code))), base.Parent.currDataTag);
                        }
                    }
                    while (!(CStmtHit(11) & (this.pMenuEntities.Target.ALNext() == 0)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1599704779")]
        public void UploadMenuLineRec([NavObjectId(ObjectId = 99009054)][NavByReferenceAttribute] INavRecordHandle pMenuButtonEntities)
        {
            using (UploadMenuLineRec_Scope_949820061 \u03b2scope = new UploadMenuLineRec_Scope_949820061(this, pMenuButtonEntities))
                \u03b2scope.Run();
        }

        [NavName("UploadMenuLineRec")]
        [SignatureSpan(714665026164293663L)]
        [SourceSpans(715790913186496537L, 716072392458240085L, 716635338116825128L, 717198322430115898L, 717479801701859388L, 717761289563537453L, 718042768835280937L, 718605684429094953L, 718887159405871182L, 719168647267549233L, 719450126539292719L, 719731584336199729L, 720013059312975973L, 720294534289752232L, 720857497128206372L, 721138976399950032L, 721701917763567662L, 721983345495703560L)]
        private sealed class UploadMenuLineRec_Scope_949820061 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pMenuButtonEntities")]
            public INavRecordHandle pMenuButtonEntities;
            [NavName("menuid")]
            public NavText menuid = NavText.Default(0);
            [NavName("imgID")]
            public NavText imgID = NavText.Default(0);
            protected override uint RawScopeId { get => UploadMenuLineRec_Scope_949820061.\u03b1scopeId; set => UploadMenuLineRec_Scope_949820061.\u03b1scopeId = value; }

            internal UploadMenuLineRec_Scope_949820061(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99009054)][NavByReferenceAttribute] INavRecordHandle pMenuButtonEntities) : base(\u03b2parent)
            {
                this.pMenuButtonEntities = pMenuButtonEntities;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("UploadMenuLineRec(%1)", ALCompiler.ToNavValue(this.pMenuButtonEntities.Target.ALCount))));
                }

                if (CStmtHit(2) & (this.pMenuButtonEntities.Target.ALFind(DataError.TrapError, "-")))
                    do
                    {
                        if (CStmtHit(3) & (this.menuid != ((NavCode)this.pMenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code))))
                        {
                            StmtHit(4);
                            this.menuid = new NavText(((NavCode)this.pMenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code)));
                            if (CStmtHit(5) & (!base.Parent.MenuLoaded(this.menuid)))
                            {
                                StmtHit(6);
                                base.Parent.LoadMenu(this.menuid);
                            }
                        }

                        StmtHit(7);
                        base.Parent._MenuButtonEntities.Target.ALInit();
                        StmtHit(8);
                        base.Parent._MenuButtonEntities.Target.ALTransferFields(this.pMenuButtonEntities.Target, true);
                        if (CStmtHit(9) & (!base.Parent._MenuButtonEntities.Target.ALInsert(DataError.TrapError)))
                        {
                            StmtHit(10);
                            base.Parent._MenuButtonEntities.Target.ALModify(DataError.ThrowError);
                        }

                        StmtHit(11);
                        this.imgID = new NavText(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(1222, NavType.Code)));
                        StmtHit(12);
                        base.Parent.RefreshMenuButton_267048875(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code)), base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(2, NavType.Integer).ToInt32(), true);
                        StmtHit(13);
                        base.Parent.SetPosImage(NavOption.Create(NCLEnumMetadata.Create(99008881), 8), ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code))), base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(2, NavType.Integer).ToInt32() })), this.imgID);
                        if (CStmtHit(14) & (base.Parent.currDataTag != ""))
                        {
                            StmtHit(15);
                            base.Parent.TagControl(NavOption.Create(NCLEnumMetadata.Create(99008881), 8), ((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(10, NavType.Code)), new NavCode(25, ALCompiler.ObjectToExactNavValue<NavText>(base.Parent.pOSUTILS.Target.Invoke(937397687, new object[] { new NavText(((NavCode)base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(1, NavType.Code))), base.Parent._MenuButtonEntities.Target.GetFieldValueSafe(2, NavType.Integer).ToInt32() }))), base.Parent.currDataTag);
                        }
                    }
                    while (!(CStmtHit(16) & (this.pMenuButtonEntities.Target.ALNext() == 0)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 1766888156")]
        public void UploadPosPanelControlsRec([NavObjectId(ObjectId = 99008874)][NavByReferenceAttribute] INavRecordHandle pPosPanelControlEntities, bool pMerge)
        {
            using (UploadPosPanelControlsRec_Scope__1072134520 \u03b2scope = new UploadPosPanelControlsRec_Scope__1072134520(this, pPosPanelControlEntities, pMerge))
                \u03b2scope.Run();
        }

        [NavName("UploadPosPanelControlsRec")]
        [SignatureSpan(693554402906079271L)]
        [SourceSpans(694961764905058329L, 695243244176801902L, 695806189835386901L, 696087681992032305L, 696650666305323084L, 696932145577066574L, 697213633438744619L, 697495125595390010L, 697776604867133494L, 698339537640816699L, 699183936801341495L, 700028301602193452L, 700309793758773292L, 700872726532456473L, 701154201509232670L, 701717164347686957L, 702280135776075819L, 702561610752852053L, 702843098614530099L, 703124577886273585L, 703406052863049920L, 704250477793378496L, 704531948475187272L, 704813427746930762L, 705094915608608807L, 705376407765254198L, 705657887036997682L, 706220819810680887L, 707346693947981875L, 707909600951926828L, 708191093108506668L, 708472546610446344L)]
        private sealed class UploadPosPanelControlsRec_Scope__1072134520 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPosPanelControlEntities")]
            public INavRecordHandle pPosPanelControlEntities;
            [NavName("pMerge")]
            public bool pMerge;
            [NavName("tmpPanelID")]
            public NavText tmpPanelID = NavText.Default(0);
            [NavName("panelsAffected")]
            public NavList<NavText> panelsAffected = NavList<NavText>.Default;
            protected override uint RawScopeId { get => UploadPosPanelControlsRec_Scope__1072134520.\u03b1scopeId; set => UploadPosPanelControlsRec_Scope__1072134520.\u03b1scopeId = value; }

            internal UploadPosPanelControlsRec_Scope__1072134520(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99008874)][NavByReferenceAttribute] INavRecordHandle pPosPanelControlEntities, bool pMerge) : base(\u03b2parent)
            {
                this.pPosPanelControlEntities = pPosPanelControlEntities;
                this.pMerge = pMerge;
                this.panelsAffected = NavList<NavText>.Default;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("UploadPosPanelControlsRec(%1, %2)", ALCompiler.ToNavValue(this.pPosPanelControlEntities.Target.ALCount), ALCompiler.ToNavValue(this.pMerge))));
                }

                if (CStmtHit(2) & (!this.pMerge))
                {
                    if (CStmtHit(3) & (this.pPosPanelControlEntities.Target.ALFind(DataError.TrapError, "-")))
                        do
                        {
                            if (CStmtHit(4) & (this.tmpPanelID != ((NavCode)this.pPosPanelControlEntities.Target.GetFieldValueSafe(2, NavType.Code))))
                            {
                                StmtHit(5);
                                this.tmpPanelID = new NavText(((NavCode)this.pPosPanelControlEntities.Target.GetFieldValueSafe(2, NavType.Code)));
                                if (CStmtHit(6) & (this.tmpPanelID != ""))
                                {
                                    if (CStmtHit(7) & (!base.Parent.PanelLoaded(this.tmpPanelID)))
                                    {
                                        StmtHit(8);
                                        base.Parent.LoadPanel(this.tmpPanelID);
                                    }

                                    StmtHit(9);
                                    this.panelsAffected.ALAdd(this.tmpPanelID);
                                }
                            }
                        }
                        while (!(CStmtHit(10) & (this.pPosPanelControlEntities.Target.ALNext() == 0)));
                }

                StmtHit(11);
                foreach (var @tmp0 in this.panelsAffected)
                {
                    this.tmpPanelID = @tmp0;
                    {
                        CStmtHit(12);
                        base.Parent.RemovePanelControls(this.tmpPanelID);
                    }
                }

                StmtHit(13);
                this.tmpPanelID = new NavText("");
                StmtHit(14);
                this.panelsAffected = NavList<NavText>.Default;
                if (CStmtHit(15) & (this.pPosPanelControlEntities.Target.ALFind(DataError.TrapError, "-")))
                    do
                    {
                        StmtHit(16);
                        base.Parent._PanelControlEntities.Target.ALInit();
                        StmtHit(17);
                        base.Parent._PanelControlEntities.Target.ALTransferFields(this.pPosPanelControlEntities.Target, true);
                        if (CStmtHit(18) & (!base.Parent._PanelControlEntities.Target.ALInsert(DataError.TrapError)))
                        {
                            StmtHit(19);
                            base.Parent._PanelControlEntities.Target.ALModify(DataError.ThrowError);
                            StmtHit(20);
                            base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("UploadPosPanelControl[MODIFY](%1, %2, %3)", ALCompiler.ToNavValue(base.Parent._PanelControlEntities.Target.GetFieldValueSafe(3, NavType.Integer).ToInt32()), ((NavOption)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(8, NavType.Option)), ((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code)))));
                        }
                        else
                        {
                            StmtHit(21);
                            base.Parent.LogDeepTrace_1953297028(new NavText(ALSystemString.ALStrSubstNo("UploadPosPanelControl[INSERT](%1, %2, %3)", ALCompiler.ToNavValue(base.Parent._PanelControlEntities.Target.GetFieldValueSafe(3, NavType.Integer).ToInt32()), ((NavOption)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(8, NavType.Option)), ((NavCode)base.Parent._PanelControlEntities.Target.GetFieldValueSafe(9, NavType.Code)))));
                        }

                        if (CStmtHit(22) & (this.tmpPanelID != ((NavCode)this.pPosPanelControlEntities.Target.GetFieldValueSafe(2, NavType.Code))))
                        {
                            StmtHit(23);
                            this.tmpPanelID = new NavText(((NavCode)this.pPosPanelControlEntities.Target.GetFieldValueSafe(2, NavType.Code)));
                            if (CStmtHit(24) & (this.tmpPanelID != ""))
                            {
                                if (CStmtHit(25) & (!base.Parent.PanelLoaded(this.tmpPanelID)))
                                {
                                    StmtHit(26);
                                    base.Parent.LoadPanel(this.tmpPanelID);
                                }

                                StmtHit(27);
                                this.panelsAffected.ALAdd(this.tmpPanelID);
                            }
                        }
                    }
                    while (!(CStmtHit(28) & (this.pPosPanelControlEntities.Target.ALNext() == 0)));
                StmtHit(29);
                foreach (var @tmp1 in this.panelsAffected)
                {
                    this.tmpPanelID = @tmp1;
                    {
                        CStmtHit(30);
                        base.Parent.ResumePanelControls(this.tmpPanelID);
                    }
                }
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 454169880")]
        public void UploadPosPanelRec([NavObjectId(ObjectId = 99008880)][NavByReferenceAttribute] INavRecordHandle pPanelEntities)
        {
            using (UploadPosPanelRec_Scope__1497993980 \u03b2scope = new UploadPosPanelRec_Scope__1497993980(this, pPanelEntities))
                \u03b2scope.Run();
        }

        [NavName("UploadPosPanelRec")]
        [SignatureSpan(681732453881479199L)]
        [SourceSpans(682858340903682073L, 683139820175425616L, 683702765834010659L, 684265750147301433L, 684547229419044923L, 684828717280722994L, 685110209437368367L, 685954587123056676L, 686236062099832900L, 686517549961510956L, 686799029233254442L, 687361962007003221L, 687924911960555646L, 688769345480753193L, 689050773212889096L)]
        private sealed class UploadPosPanelRec_Scope__1497993980 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPanelEntities")]
            public INavRecordHandle pPanelEntities;
            [NavName("tmpPanelID")]
            public NavText tmpPanelID = NavText.Default(0);
            protected override uint RawScopeId { get => UploadPosPanelRec_Scope__1497993980.\u03b1scopeId; set => UploadPosPanelRec_Scope__1497993980.\u03b1scopeId = value; }

            internal UploadPosPanelRec_Scope__1497993980(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99008880)][NavByReferenceAttribute] INavRecordHandle pPanelEntities) : base(\u03b2parent)
            {
                this.pPanelEntities = pPanelEntities;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("UploadPosPanelRec(%1)", ALCompiler.ToNavValue(this.pPanelEntities.Target.ALCount))));
                }

                if (CStmtHit(2) & (this.pPanelEntities.Target.ALFind(DataError.TrapError, "-")))
                    do
                    {
                        if (CStmtHit(3) & (this.tmpPanelID != ((NavCode)this.pPanelEntities.Target.GetFieldValueSafe(2, NavType.Code))))
                        {
                            StmtHit(4);
                            this.tmpPanelID = new NavText(((NavCode)this.pPanelEntities.Target.GetFieldValueSafe(2, NavType.Code)));
                            if (CStmtHit(5) & (!base.Parent.PanelLoaded(this.tmpPanelID)))
                                if (CStmtHit(6) & (base.Parent.GetPanel(this.tmpPanelID)))
                                    ;
                        }

                        StmtHit(7);
                        base.Parent._PanelEntities.Target.ALInit();
                        StmtHit(8);
                        base.Parent._PanelEntities.Target.ALTransferFields(this.pPanelEntities.Target, true);
                        if (CStmtHit(9) & (!base.Parent._PanelEntities.Target.ALInsert(DataError.TrapError)))
                        {
                            StmtHit(10);
                            base.Parent._PanelEntities.Target.ALModify(DataError.ThrowError);
                        }

                        StmtHit(11);
                        base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2), new NavText(((NavCode)base.Parent._PanelEntities.Target.GetFieldValueSafe(2, NavType.Code))), new NavText(base.Parent._SHARED.Target.ALFieldName(5)), -1 });
                        StmtHit(12);
                        base.Parent._CONTROLS.Target.Invoke(-1036856097, new object[] { NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2), new NavText(((NavCode)base.Parent._PanelEntities.Target.GetFieldValueSafe(2, NavType.Code))), new NavText(base.Parent._SHARED.Target.ALFieldName(5)), NavOption.Create(((NavOption)base.Parent._CONTROLS.Target.GetFieldValueSafe(2, NavType.Option)).NavOptionMetadata, 2).ToInt32() });
                    }
                    while (!(CStmtHit(13) & (this.pPanelEntities.Target.ALNext() == 0)));
            }
        }

        [NavFunctionVisibility(FunctionVisibility.External), NavCaption(TranslationKey = "Codeunit 2892615804 - Method 3572053930")]
        public void UploadPosPanelRowColumnsRec([NavObjectId(ObjectId = 99008873)][NavByReferenceAttribute] INavRecordHandle pPosPanelRowColumnEntities)
        {
            using (UploadPosPanelRowColumnsRec_Scope_520468517 \u03b2scope = new UploadPosPanelRowColumnsRec_Scope_520468517(this, pPosPanelRowColumnEntities))
                \u03b2scope.Run();
        }

        [NavName("UploadPosPanelRowColumnsRec")]
        [SignatureSpan(689613753231212585L)]
        [SourceSpans(690176690299863065L, 690458169571606630L, 691021115230191663L, 691584086658580525L, 691865561635356761L, 692147049497034805L, 692428528768778291L, 692709995155619893L, 692991422887755784L)]
        private sealed class UploadPosPanelRowColumnsRec_Scope_520468517 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pPosPanelRowColumnEntities")]
            public INavRecordHandle pPosPanelRowColumnEntities;
            protected override uint RawScopeId { get => UploadPosPanelRowColumnsRec_Scope_520468517.\u03b1scopeId; set => UploadPosPanelRowColumnsRec_Scope_520468517.\u03b1scopeId = value; }

            internal UploadPosPanelRowColumnsRec_Scope_520468517(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99008873)][NavByReferenceAttribute] INavRecordHandle pPosPanelRowColumnEntities) : base(\u03b2parent)
            {
                this.pPosPanelRowColumnEntities = pPosPanelRowColumnEntities;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (base.Parent.__LogLevel > 2))
                {
                    StmtHit(1);
                    base.Parent.LogDebug(new NavText(ALSystemString.ALStrSubstNo("UploadPosPanelRowColumnsRec(%1)", ALCompiler.ToNavValue(this.pPosPanelRowColumnEntities.Target.ALCount))));
                }

                if (CStmtHit(2) & (this.pPosPanelRowColumnEntities.Target.ALFind(DataError.TrapError, "-")))
                    do
                    {
                        StmtHit(3);
                        base.Parent._PanelRowColumnEntities.Target.ALInit();
                        StmtHit(4);
                        base.Parent._PanelRowColumnEntities.Target.ALTransferFields(this.pPosPanelRowColumnEntities.Target, true);
                        if (CStmtHit(5) & (!base.Parent._PanelRowColumnEntities.Target.ALInsert(DataError.TrapError)))
                        {
                            StmtHit(6);
                            base.Parent._PanelRowColumnEntities.Target.ALModify(DataError.ThrowError);
                        }
                    }
                    while (!(CStmtHit(7) & (this.pPosPanelRowColumnEntities.Target.ALNext() == 0)));
            }
        }

        private void WriteControlPropertyToJSON([NavObjectId(ObjectId = 99001760)][NavByReferenceAttribute] INavRecordHandle pControlProperty, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle pJsonUtil)
        {
            using (WriteControlPropertyToJSON_Scope__257601589 \u03b2scope = new WriteControlPropertyToJSON_Scope__257601589(this, pControlProperty, pJsonUtil))
                \u03b2scope.Run();
        }

        [NavName("WriteControlPropertyToJSON")]
        [SignatureSpan(266556888906399790L)]
        [SourceSpans(267682750158798893L, 267964229430542434L, 268527192268996657L, 268808671540740197L, 269371621494292588L, 269653057816363016L)]
        private sealed class WriteControlPropertyToJSON_Scope__257601589 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("pControlProperty")]
            public INavRecordHandle pControlProperty;
            [NavName("pJsonUtil")]
            public NavCodeunitHandle pJsonUtil;
            protected override uint RawScopeId { get => WriteControlPropertyToJSON_Scope__257601589.\u03b1scopeId; set => WriteControlPropertyToJSON_Scope__257601589.\u03b1scopeId = value; }

            internal WriteControlPropertyToJSON_Scope__257601589(Codeunit10012739 \u03b2parent, [NavObjectId(ObjectId = 99001760)][NavByReferenceAttribute] INavRecordHandle pControlProperty, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle pJsonUtil) : base(\u03b2parent)
            {
                this.pControlProperty = pControlProperty;
                this.pJsonUtil = pJsonUtil;
            }

            protected override void OnRun()
            {
                if (CStmtHit(0) & (this.pControlProperty.Target.GetFieldValueSafe(8, NavType.Integer).ToInt32() == 12))
                {
                    StmtHit(1);
                    this.pJsonUtil.Target.Invoke(1213051198, new object[] { new NavText(((NavText)this.pControlProperty.Target.GetFieldValueSafe(5, NavType.Text))), ALCompiler.ToVariant(this, this.pControlProperty.Target.GetFieldValueSafe(12, NavType.Decimal).ToDecimal()) });
                }
                else if (CStmtHit(2) & (this.pControlProperty.Target.GetFieldValueSafe(8, NavType.Integer).ToInt32() == 11))
                {
                    StmtHit(3);
                    this.pJsonUtil.Target.Invoke(312227950, new object[] { new NavText(((NavText)this.pControlProperty.Target.GetFieldValueSafe(5, NavType.Text))), ALCompiler.ToVariant(this, this.pControlProperty.Target.GetFieldValueSafe(11, NavType.Boolean).ToBoolean()) });
                }
                else
                {
                    StmtHit(4);
                    this.pJsonUtil.Target.Invoke(-1675069947, new object[] { new NavText(((NavText)this.pControlProperty.Target.GetFieldValueSafe(5, NavType.Text))), ALCompiler.NavValueToVariant(this, ALCompiler.ObjectToExactNavValue<NavText>(this.pControlProperty.Target.Invoke(-1430120492, Array.Empty<object>()))) });
                }
            }
        }

        private void WriteFieldPropertyToJSON(NavText propertyName, ByRef<NavFieldRef> controlfieldRef, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle pJsonUtil)
        {
            using (WriteFieldPropertyToJSON_Scope_1262996852 \u03b2scope = new WriteFieldPropertyToJSON_Scope_1262996852(this, propertyName, controlfieldRef, pJsonUtil))
                \u03b2scope.Run();
        }

        [NavName("WriteFieldPropertyToJSON")]
        [SignatureSpan(264586564068966444L)]
        [SourceSpans(265712412436463708L, 265993883118272520L)]
        private sealed class WriteFieldPropertyToJSON_Scope_1262996852 : NavMethodScope<Codeunit10012739>
        {
            public static uint \u03b1scopeId;
            [NavName("propertyName")]
            public NavText propertyName;
            [NavName("controlfieldRef")]
            public ByRef<NavFieldRef> controlfieldRef;
            [NavName("pJsonUtil")]
            public NavCodeunitHandle pJsonUtil;
            protected override uint RawScopeId { get => WriteFieldPropertyToJSON_Scope_1262996852.\u03b1scopeId; set => WriteFieldPropertyToJSON_Scope_1262996852.\u03b1scopeId = value; }

            internal WriteFieldPropertyToJSON_Scope_1262996852(Codeunit10012739 \u03b2parent, NavText propertyName, ByRef<NavFieldRef> controlfieldRef, [NavObjectId(ObjectId = 1234)][NavByReferenceAttribute] NavCodeunitHandle pJsonUtil) : base(\u03b2parent)
            {
                this.propertyName = propertyName.ModifyLength(0);
                this.controlfieldRef = controlfieldRef;
                this.pJsonUtil = pJsonUtil;
            }

            protected override void OnRun()
            {
                StmtHit(0);
                base.Parent.pOSUTILS.Target.Invoke(1262996852, new object[] { new NavText(this.controlfieldRef.Value.ALName), this.controlfieldRef, this.pJsonUtil });
            }
        }
    }
}
