namespace ControlAddIn.ControlAddIn;

using Microsoft.Finance.GST.Base;

tableextension 70000 "GST Setup Ext." extends "GST Setup"
{
    fields
    {
        field(70000; "TDS Threshold %"; Decimal)
        {
            Caption = 'TDS Threshold %';
            DataClassification = ToBeClassified;
        }
    }
}
