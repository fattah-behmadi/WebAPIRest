//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSettingIDFactor
    {
        public int ID_SettingSefareshat { get; set; }
        public Nullable<long> StartID { get; set; }
        public Nullable<long> Increment { get; set; }
        public string Setting_CurrencySymbol { get; set; }
        public Nullable<bool> Setting_TuochUi { get; set; }
        public Nullable<long> Setting_SarResidCheck { get; set; }
        public Nullable<long> Setting_SarResidEtmam { get; set; }
        public string Setting_PrintHalat { get; set; }
        public string Setting_PrintSize { get; set; }
        public string Setting_PrintRotate { get; set; }
        public string Setting_PrintTedad { get; set; }
        public string Setting_Printer { get; set; }
        public string Setting_Vahed { get; set; }
        public string Setting_BarcodeReader { get; set; }
        public Nullable<bool> Setting_Print_Serial { get; set; }
        public Nullable<bool> Setting_ShowFrmMovjodi { get; set; }
        public Nullable<long> Setting_NumberFishStart { get; set; }
        public Nullable<double> Setting_DarsadMaliyat { get; set; }
        public Nullable<double> Setting_DardadTakhfif { get; set; }
        public Nullable<long> Setting_MablaghTakhfif { get; set; }
        public Nullable<double> Setting_DarsadService { get; set; }
        public Nullable<long> Setting_MablaghService { get; set; }
        public Nullable<bool> SelectContact { get; set; }
        public string DefultContact { get; set; }
        public string DefaultBankID { get; set; }
        public Nullable<bool> SaveContact { get; set; }
        public string DefaultRPTAsh { get; set; }
        public Nullable<bool> SendFishTelegram { get; set; }
        public Nullable<int> NFishMoshtari { get; set; }
        public Nullable<int> NFishSandogh { get; set; }
        public Nullable<int> NFishAshpazkhane { get; set; }
        public Nullable<int> NFPeik { get; set; }
        public System.TimeSpan AMStart { get; set; }
        public System.TimeSpan AMEnd { get; set; }
        public System.TimeSpan PMStart { get; set; }
        public System.TimeSpan PMEnd { get; set; }
        public System.TimeSpan NmStart { get; set; }
        public System.TimeSpan NmEnd { get; set; }
        public string TimeWaith { get; set; }
        public string Api_Key { get; set; }
        public Nullable<bool> Active_Apikey { get; set; }
        public Nullable<int> NumberBonus { get; set; }
        public Nullable<long> LevelBonus { get; set; }
        public Nullable<bool> DefaultRPTCustomer { get; set; }
    }
}
