namespace ControlAddIn.ControlAddIn;

page 70001 "ControlAddIn Display"
{
    ApplicationArea = Basic;
    Caption = 'ControlAddIn Display';
    PageType = Card;
    UsageCategory = Tasks;

    layout
    {
        area(Content)
        {
            usercontrol(ToastsNotify; ToastsNotificationAddIn)
            {
                ApplicationArea = Basic;
            }
            usercontrol(ValidManifest; ValidManifestAddIn)
            {
                ApplicationArea = Basic;
            }
            usercontrol(InValidManifest; InValidManifestAddIn)
            {
                ApplicationArea = Basic;
            }
            usercontrol(FlexibleWidth; FlexibleWidthAddIn)
            {
                ApplicationArea = Basic;
            }
            usercontrol(FlexibleHeight; FlexibleHeightAddIn)
            {
                ApplicationArea = Basic;
            }
            group(Toasts)
            {
                Caption = 'Toasts Notification';
                field(NotifyTitle; NotifyTitle)
                {
                    Caption = 'Title';
                    ApplicationArea = Basic;

                    // trigger OnValidate()
                    // begin
                    //     ShowToasts();
                    // end;
                }
                field(NotifyMessage; NotifyMessage)
                {
                    Caption = 'Message';
                    ApplicationArea = Basic;
                    trigger OnValidate()
                    begin
                        ShowToasts();
                    end;
                }
            }

            group("Range Datatype")
            {
                Caption = 'Range Datatype';
                group("Percentage")
                {
                    usercontrol(RangeField; RangeDataTypeAddIn)
                    {
                        ApplicationArea = Basic;

                        trigger OnReadyPage()
                        var
                            Settings: JsonObject;
                        begin
                            Settings.Add('min', 1);
                            Settings.Add('max', 100);
                            Settings.Add('step', 1);

                            CurrPage.RangeField.Init();
                            CurrPage.RangeField.SetConfig(Settings);
                        end;

                        trigger OnValidate(Value: Integer)
                        begin
                            Message('Range Value: %1', Value);
                        end;
                    }
                }
            }
        }
    }

    local procedure ShowToasts()
    begin
        if (NotifyTitle <> '') and (NotifyMessage <> '') then begin
            CurrPage.ToastsNotify.NotifyWithTitle(NotifyTitle, NotifyMessage);
        end;
    end;

    var
        NotifyTitle: Text;
        NotifyMessage: Text;
}
