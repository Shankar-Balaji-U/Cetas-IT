namespace ControlAddIn.Example.Range;

using Microsoft.Finance.GST.Base;

pageextension 70000 "Tax Type Setup Ext." extends "Tax Type Setup"
{
    layout
    {
        addafter("Generate E-Inv. on Ser. Post")
        {
            group("TDS Threshold %")
            {
                usercontrol(TDSThreshold; RangeDataTypeAddIn)
                {
                    ApplicationArea = Basic;

                    trigger OnReadyPage()
                    var
                        Settings: JsonObject;
                    begin
                        Settings.Add('min', 1);
                        Settings.Add('max', 100);
                        Settings.Add('step', 1);

                        CurrPage.TDSThreshold.Init();
                        CurrPage.TDSThreshold.SetConfig(Settings);
                        CurrPage.TDSThreshold.SetValue(Rec."TDS Threshold %");
                    end;

                    trigger OnValidate(Value: Integer)
                    begin
                        Rec."TDS Threshold %" := Value;
                    end;
                }
            }
        }
    }
}
