﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllPayWebServiceTest.ProdApiTopUpWs {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TopUpMemberBankInfo", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class TopUpMemberBankInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long MIDField;
        
        private long MerchantIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserVAccNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BankNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BankVAccNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthNameField;
        
        private int TopUpLimitField;
        
        private int MonthlyTradeLimitField;
        
        private int DailyTradeLimitField;
        
        private int SingleTradeLimitField;
        
        private int MonthlyTopUpAmountField;
        
        private int MonthlyTradeAmountField;
        
        private int DailyTopUpAmountField;
        
        private int DailyTradeAmountField;
        
        private int MonthlyAvailableTradeAmountField;
        
        private int DailyAvailableTradeAmountField;
        
        private int TopUpCashField;
        
        private int AvailableTopUpAmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SystemBankNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RtnCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RtnMsgField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long MID {
            get {
                return this.MIDField;
            }
            set {
                if ((this.MIDField.Equals(value) != true)) {
                    this.MIDField = value;
                    this.RaisePropertyChanged("MID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long MerchantID {
            get {
                return this.MerchantIDField;
            }
            set {
                if ((this.MerchantIDField.Equals(value) != true)) {
                    this.MerchantIDField = value;
                    this.RaisePropertyChanged("MerchantID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string UserVAccNo {
            get {
                return this.UserVAccNoField;
            }
            set {
                if ((object.ReferenceEquals(this.UserVAccNoField, value) != true)) {
                    this.UserVAccNoField = value;
                    this.RaisePropertyChanged("UserVAccNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string BankName {
            get {
                return this.BankNameField;
            }
            set {
                if ((object.ReferenceEquals(this.BankNameField, value) != true)) {
                    this.BankNameField = value;
                    this.RaisePropertyChanged("BankName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string BankVAccNo {
            get {
                return this.BankVAccNoField;
            }
            set {
                if ((object.ReferenceEquals(this.BankVAccNoField, value) != true)) {
                    this.BankVAccNoField = value;
                    this.RaisePropertyChanged("BankVAccNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string AuthName {
            get {
                return this.AuthNameField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthNameField, value) != true)) {
                    this.AuthNameField = value;
                    this.RaisePropertyChanged("AuthName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public int TopUpLimit {
            get {
                return this.TopUpLimitField;
            }
            set {
                if ((this.TopUpLimitField.Equals(value) != true)) {
                    this.TopUpLimitField = value;
                    this.RaisePropertyChanged("TopUpLimit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public int MonthlyTradeLimit {
            get {
                return this.MonthlyTradeLimitField;
            }
            set {
                if ((this.MonthlyTradeLimitField.Equals(value) != true)) {
                    this.MonthlyTradeLimitField = value;
                    this.RaisePropertyChanged("MonthlyTradeLimit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public int DailyTradeLimit {
            get {
                return this.DailyTradeLimitField;
            }
            set {
                if ((this.DailyTradeLimitField.Equals(value) != true)) {
                    this.DailyTradeLimitField = value;
                    this.RaisePropertyChanged("DailyTradeLimit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public int SingleTradeLimit {
            get {
                return this.SingleTradeLimitField;
            }
            set {
                if ((this.SingleTradeLimitField.Equals(value) != true)) {
                    this.SingleTradeLimitField = value;
                    this.RaisePropertyChanged("SingleTradeLimit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=10)]
        public int MonthlyTopUpAmount {
            get {
                return this.MonthlyTopUpAmountField;
            }
            set {
                if ((this.MonthlyTopUpAmountField.Equals(value) != true)) {
                    this.MonthlyTopUpAmountField = value;
                    this.RaisePropertyChanged("MonthlyTopUpAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=11)]
        public int MonthlyTradeAmount {
            get {
                return this.MonthlyTradeAmountField;
            }
            set {
                if ((this.MonthlyTradeAmountField.Equals(value) != true)) {
                    this.MonthlyTradeAmountField = value;
                    this.RaisePropertyChanged("MonthlyTradeAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=12)]
        public int DailyTopUpAmount {
            get {
                return this.DailyTopUpAmountField;
            }
            set {
                if ((this.DailyTopUpAmountField.Equals(value) != true)) {
                    this.DailyTopUpAmountField = value;
                    this.RaisePropertyChanged("DailyTopUpAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=13)]
        public int DailyTradeAmount {
            get {
                return this.DailyTradeAmountField;
            }
            set {
                if ((this.DailyTradeAmountField.Equals(value) != true)) {
                    this.DailyTradeAmountField = value;
                    this.RaisePropertyChanged("DailyTradeAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=14)]
        public int MonthlyAvailableTradeAmount {
            get {
                return this.MonthlyAvailableTradeAmountField;
            }
            set {
                if ((this.MonthlyAvailableTradeAmountField.Equals(value) != true)) {
                    this.MonthlyAvailableTradeAmountField = value;
                    this.RaisePropertyChanged("MonthlyAvailableTradeAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=15)]
        public int DailyAvailableTradeAmount {
            get {
                return this.DailyAvailableTradeAmountField;
            }
            set {
                if ((this.DailyAvailableTradeAmountField.Equals(value) != true)) {
                    this.DailyAvailableTradeAmountField = value;
                    this.RaisePropertyChanged("DailyAvailableTradeAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=16)]
        public int TopUpCash {
            get {
                return this.TopUpCashField;
            }
            set {
                if ((this.TopUpCashField.Equals(value) != true)) {
                    this.TopUpCashField = value;
                    this.RaisePropertyChanged("TopUpCash");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=17)]
        public int AvailableTopUpAmount {
            get {
                return this.AvailableTopUpAmountField;
            }
            set {
                if ((this.AvailableTopUpAmountField.Equals(value) != true)) {
                    this.AvailableTopUpAmountField = value;
                    this.RaisePropertyChanged("AvailableTopUpAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=18)]
        public string SystemBankName {
            get {
                return this.SystemBankNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SystemBankNameField, value) != true)) {
                    this.SystemBankNameField = value;
                    this.RaisePropertyChanged("SystemBankName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=19)]
        public string RtnCode {
            get {
                return this.RtnCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.RtnCodeField, value) != true)) {
                    this.RtnCodeField = value;
                    this.RaisePropertyChanged("RtnCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=20)]
        public string RtnMsg {
            get {
                return this.RtnMsgField;
            }
            set {
                if ((object.ReferenceEquals(this.RtnMsgField, value) != true)) {
                    this.RtnMsgField = value;
                    this.RaisePropertyChanged("RtnMsg");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProdApiTopUpWs.TopUpWSSoap")]
    public interface TopUpWSSoap {
        
        // CODEGEN: 命名空間 http://tempuri.org/ 的元素名稱  TopUpBalanceResult 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TopUpBalance", ReplyAction="*")]
        AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceResponse TopUpBalance(AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceRequest request);
        
        // CODEGEN: 命名空間 http://tempuri.org/ 的元素名稱  CheckTopUpMaintainResult 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckTopUpMaintain", ReplyAction="*")]
        AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainResponse CheckTopUpMaintain(AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class TopUpBalanceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="TopUpBalance", Namespace="http://tempuri.org/", Order=0)]
        public AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceRequestBody Body;
        
        public TopUpBalanceRequest() {
        }
        
        public TopUpBalanceRequest(AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class TopUpBalanceRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long mid;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public long merchantID;
        
        public TopUpBalanceRequestBody() {
        }
        
        public TopUpBalanceRequestBody(long mid, long merchantID) {
            this.mid = mid;
            this.merchantID = merchantID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class TopUpBalanceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="TopUpBalanceResponse", Namespace="http://tempuri.org/", Order=0)]
        public AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceResponseBody Body;
        
        public TopUpBalanceResponse() {
        }
        
        public TopUpBalanceResponse(AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class TopUpBalanceResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public AllPayWebServiceTest.ProdApiTopUpWs.TopUpMemberBankInfo[] TopUpBalanceResult;
        
        public TopUpBalanceResponseBody() {
        }
        
        public TopUpBalanceResponseBody(AllPayWebServiceTest.ProdApiTopUpWs.TopUpMemberBankInfo[] TopUpBalanceResult) {
            this.TopUpBalanceResult = TopUpBalanceResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckTopUpMaintainRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckTopUpMaintain", Namespace="http://tempuri.org/", Order=0)]
        public AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainRequestBody Body;
        
        public CheckTopUpMaintainRequest() {
        }
        
        public CheckTopUpMaintainRequest(AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CheckTopUpMaintainRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long merchantID;
        
        public CheckTopUpMaintainRequestBody() {
        }
        
        public CheckTopUpMaintainRequestBody(long merchantID) {
            this.merchantID = merchantID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckTopUpMaintainResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckTopUpMaintainResponse", Namespace="http://tempuri.org/", Order=0)]
        public AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainResponseBody Body;
        
        public CheckTopUpMaintainResponse() {
        }
        
        public CheckTopUpMaintainResponse(AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CheckTopUpMaintainResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CheckTopUpMaintainResult;
        
        public CheckTopUpMaintainResponseBody() {
        }
        
        public CheckTopUpMaintainResponseBody(string CheckTopUpMaintainResult) {
            this.CheckTopUpMaintainResult = CheckTopUpMaintainResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TopUpWSSoapChannel : AllPayWebServiceTest.ProdApiTopUpWs.TopUpWSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TopUpWSSoapClient : System.ServiceModel.ClientBase<AllPayWebServiceTest.ProdApiTopUpWs.TopUpWSSoap>, AllPayWebServiceTest.ProdApiTopUpWs.TopUpWSSoap {
        
        public TopUpWSSoapClient() {
        }
        
        public TopUpWSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TopUpWSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TopUpWSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TopUpWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceResponse AllPayWebServiceTest.ProdApiTopUpWs.TopUpWSSoap.TopUpBalance(AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceRequest request) {
            return base.Channel.TopUpBalance(request);
        }
        
        public AllPayWebServiceTest.ProdApiTopUpWs.TopUpMemberBankInfo[] TopUpBalance(long mid, long merchantID) {
            AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceRequest inValue = new AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceRequest();
            inValue.Body = new AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceRequestBody();
            inValue.Body.mid = mid;
            inValue.Body.merchantID = merchantID;
            AllPayWebServiceTest.ProdApiTopUpWs.TopUpBalanceResponse retVal = ((AllPayWebServiceTest.ProdApiTopUpWs.TopUpWSSoap)(this)).TopUpBalance(inValue);
            return retVal.Body.TopUpBalanceResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainResponse AllPayWebServiceTest.ProdApiTopUpWs.TopUpWSSoap.CheckTopUpMaintain(AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainRequest request) {
            return base.Channel.CheckTopUpMaintain(request);
        }
        
        public string CheckTopUpMaintain(long merchantID) {
            AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainRequest inValue = new AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainRequest();
            inValue.Body = new AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainRequestBody();
            inValue.Body.merchantID = merchantID;
            AllPayWebServiceTest.ProdApiTopUpWs.CheckTopUpMaintainResponse retVal = ((AllPayWebServiceTest.ProdApiTopUpWs.TopUpWSSoap)(this)).CheckTopUpMaintain(inValue);
            return retVal.Body.CheckTopUpMaintainResult;
        }
    }
}
