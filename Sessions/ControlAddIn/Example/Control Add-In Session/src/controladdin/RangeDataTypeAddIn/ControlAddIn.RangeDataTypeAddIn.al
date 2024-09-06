controladdin RangeDataTypeAddIn
{
    RequestedHeight = 29;
    MinimumHeight = 29;
    MaximumHeight = 29;
    HorizontalStretch = true;
    HorizontalShrink = true;
    Scripts = 'src/controladdin/RangeDataTypeAddIn/static/js/main.js';
    StyleSheets = 'src/controladdin/RangeDataTypeAddIn/static/css/main.css';
    StartupScript = 'src/controladdin/RangeDataTypeAddIn/static/js/startup.js';

    procedure Init();
    procedure SetConfig(Value: JsonObject);
    procedure SetCaption(Value: Text);
    procedure SetValue(Value: Integer);


    event OnValidate(Value: Integer);
    event OnReadyPage();
}