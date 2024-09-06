controladdin ToastsNotificationAddIn
{
    RequestedHeight = 0;
    MinimumHeight = 0;
    MaximumHeight = 0;
    RequestedWidth = 0;
    MinimumWidth = 0;
    MaximumWidth = 0;

    VerticalStretch = false;
    VerticalShrink = false;
    HorizontalStretch = false;
    HorizontalShrink = false;
    StyleSheets = 'src\controladdin\global-static\css\bootstrap.css';

    Scripts = 'src\controladdin\global-static\js\base.js',
              'src\controladdin\global-static\js\bootstrap.bundle.js',
              'src\controladdin\ToastsNotificationAddIn\js\main.js';
    StartupScript = 'src\controladdin\ToastsNotificationAddIn\js\startup.js';
    Images = 'src\controladdin\global-static\css\bootstrap.css',
             'src\controladdin\global-static\img\Cetas-Logo-Color.png';
    procedure Notify(Value: Text);
    procedure NotifyWithTitle(Title: Text; Message: Text);
}