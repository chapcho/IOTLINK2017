﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FTOPApp.DYP_MW_Webservice {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DYP_MW_Webservice.DYP_WebserviceSoap")]
    public interface DYP_WebserviceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Set_LogData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Set_LogData(string corp_cd, string gtr_id, string log_data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Set_LogData", ReplyAction="*")]
        System.Threading.Tasks.Task<string> Set_LogDataAsync(string corp_cd, string gtr_id, string log_data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_CommonCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Get_CommonCode(string corp_cd, string type, string code_type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_CommonCode", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> Get_CommonCodeAsync(string corp_cd, string type, string code_type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_PLANTCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Get_PLANTCode(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_PLANTCode", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> Get_PLANTCodeAsync(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_LINECode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Get_LINECode(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_LINECode", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> Get_LINECodeAsync(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_OPCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Get_OPCode(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_OPCode", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> Get_OPCodeAsync(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_EQMCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Get_EQMCode(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_EQMCode", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> Get_EQMCodeAsync(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_ItemMst", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Get_ItemMst(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_ItemMst", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> Get_ItemMstAsync(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_ItemDetail", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Get_ItemDetail(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_ItemDetail", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> Get_ItemDetailAsync(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_GTRCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Get_GTRCode(string corp_cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_GTRCode", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> Get_GTRCodeAsync(string corp_cd);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DYP_WebserviceSoapChannel : FTOPApp.DYP_MW_Webservice.DYP_WebserviceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DYP_WebserviceSoapClient : System.ServiceModel.ClientBase<FTOPApp.DYP_MW_Webservice.DYP_WebserviceSoap>, FTOPApp.DYP_MW_Webservice.DYP_WebserviceSoap {
        
        public DYP_WebserviceSoapClient() {
        }
        
        public DYP_WebserviceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DYP_WebserviceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DYP_WebserviceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DYP_WebserviceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Set_LogData(string corp_cd, string gtr_id, string log_data) {
            return base.Channel.Set_LogData(corp_cd, gtr_id, log_data);
        }
        
        public System.Threading.Tasks.Task<string> Set_LogDataAsync(string corp_cd, string gtr_id, string log_data) {
            return base.Channel.Set_LogDataAsync(corp_cd, gtr_id, log_data);
        }
        
        public System.Data.DataTable Get_CommonCode(string corp_cd, string type, string code_type) {
            return base.Channel.Get_CommonCode(corp_cd, type, code_type);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Get_CommonCodeAsync(string corp_cd, string type, string code_type) {
            return base.Channel.Get_CommonCodeAsync(corp_cd, type, code_type);
        }
        
        public System.Data.DataTable Get_PLANTCode(string corp_cd) {
            return base.Channel.Get_PLANTCode(corp_cd);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Get_PLANTCodeAsync(string corp_cd) {
            return base.Channel.Get_PLANTCodeAsync(corp_cd);
        }
        
        public System.Data.DataTable Get_LINECode(string corp_cd) {
            return base.Channel.Get_LINECode(corp_cd);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Get_LINECodeAsync(string corp_cd) {
            return base.Channel.Get_LINECodeAsync(corp_cd);
        }
        
        public System.Data.DataTable Get_OPCode(string corp_cd) {
            return base.Channel.Get_OPCode(corp_cd);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Get_OPCodeAsync(string corp_cd) {
            return base.Channel.Get_OPCodeAsync(corp_cd);
        }
        
        public System.Data.DataTable Get_EQMCode(string corp_cd) {
            return base.Channel.Get_EQMCode(corp_cd);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Get_EQMCodeAsync(string corp_cd) {
            return base.Channel.Get_EQMCodeAsync(corp_cd);
        }
        
        public System.Data.DataTable Get_ItemMst(string corp_cd) {
            return base.Channel.Get_ItemMst(corp_cd);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Get_ItemMstAsync(string corp_cd) {
            return base.Channel.Get_ItemMstAsync(corp_cd);
        }
        
        public System.Data.DataTable Get_ItemDetail(string corp_cd) {
            return base.Channel.Get_ItemDetail(corp_cd);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Get_ItemDetailAsync(string corp_cd) {
            return base.Channel.Get_ItemDetailAsync(corp_cd);
        }
        
        public System.Data.DataTable Get_GTRCode(string corp_cd) {
            return base.Channel.Get_GTRCode(corp_cd);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Get_GTRCodeAsync(string corp_cd) {
            return base.Channel.Get_GTRCodeAsync(corp_cd);
        }
    }
}
