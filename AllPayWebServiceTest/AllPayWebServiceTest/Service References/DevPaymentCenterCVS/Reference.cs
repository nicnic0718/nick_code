﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllPayWebServiceTest.DevPaymentCenterCVS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseModel", Namespace="http://PaymentCenter.AllPay.com.tw/")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(AllPayWebServiceTest.DevPaymentCenterCVS.TradeInfoStore))]
    public partial class BaseModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int RtnCodeField;
        
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
        public int RtnCode {
            get {
                return this.RtnCodeField;
            }
            set {
                if ((this.RtnCodeField.Equals(value) != true)) {
                    this.RtnCodeField = value;
                    this.RaisePropertyChanged("RtnCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TradeInfoStore", Namespace="http://PaymentCenter.AllPay.com.tw/")]
    [System.SerializableAttribute()]
    public partial class TradeInfoStore : AllPayWebServiceTest.DevPaymentCenterCVS.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AlicardNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TEN_CODEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TRAN_NOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MMK_IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string STATUS_CODEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string STATUS_DESCField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BANK_TRAN_NOField;
        
        private int PAY_AMTField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DATA_1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DATA_2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DATA_3Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DATA_4Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DATA_5Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RTN_URLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TRACE_URLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ERR_URLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PAY_DATEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PAY_TIMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string POST_URLField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string AlicardNo {
            get {
                return this.AlicardNoField;
            }
            set {
                if ((object.ReferenceEquals(this.AlicardNoField, value) != true)) {
                    this.AlicardNoField = value;
                    this.RaisePropertyChanged("AlicardNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TEN_CODE {
            get {
                return this.TEN_CODEField;
            }
            set {
                if ((object.ReferenceEquals(this.TEN_CODEField, value) != true)) {
                    this.TEN_CODEField = value;
                    this.RaisePropertyChanged("TEN_CODE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TRAN_NO {
            get {
                return this.TRAN_NOField;
            }
            set {
                if ((object.ReferenceEquals(this.TRAN_NOField, value) != true)) {
                    this.TRAN_NOField = value;
                    this.RaisePropertyChanged("TRAN_NO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string MMK_ID {
            get {
                return this.MMK_IDField;
            }
            set {
                if ((object.ReferenceEquals(this.MMK_IDField, value) != true)) {
                    this.MMK_IDField = value;
                    this.RaisePropertyChanged("MMK_ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string STATUS_CODE {
            get {
                return this.STATUS_CODEField;
            }
            set {
                if ((object.ReferenceEquals(this.STATUS_CODEField, value) != true)) {
                    this.STATUS_CODEField = value;
                    this.RaisePropertyChanged("STATUS_CODE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string STATUS_DESC {
            get {
                return this.STATUS_DESCField;
            }
            set {
                if ((object.ReferenceEquals(this.STATUS_DESCField, value) != true)) {
                    this.STATUS_DESCField = value;
                    this.RaisePropertyChanged("STATUS_DESC");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string BANK_TRAN_NO {
            get {
                return this.BANK_TRAN_NOField;
            }
            set {
                if ((object.ReferenceEquals(this.BANK_TRAN_NOField, value) != true)) {
                    this.BANK_TRAN_NOField = value;
                    this.RaisePropertyChanged("BANK_TRAN_NO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public int PAY_AMT {
            get {
                return this.PAY_AMTField;
            }
            set {
                if ((this.PAY_AMTField.Equals(value) != true)) {
                    this.PAY_AMTField = value;
                    this.RaisePropertyChanged("PAY_AMT");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string DATA_1 {
            get {
                return this.DATA_1Field;
            }
            set {
                if ((object.ReferenceEquals(this.DATA_1Field, value) != true)) {
                    this.DATA_1Field = value;
                    this.RaisePropertyChanged("DATA_1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string DATA_2 {
            get {
                return this.DATA_2Field;
            }
            set {
                if ((object.ReferenceEquals(this.DATA_2Field, value) != true)) {
                    this.DATA_2Field = value;
                    this.RaisePropertyChanged("DATA_2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string DATA_3 {
            get {
                return this.DATA_3Field;
            }
            set {
                if ((object.ReferenceEquals(this.DATA_3Field, value) != true)) {
                    this.DATA_3Field = value;
                    this.RaisePropertyChanged("DATA_3");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string DATA_4 {
            get {
                return this.DATA_4Field;
            }
            set {
                if ((object.ReferenceEquals(this.DATA_4Field, value) != true)) {
                    this.DATA_4Field = value;
                    this.RaisePropertyChanged("DATA_4");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string DATA_5 {
            get {
                return this.DATA_5Field;
            }
            set {
                if ((object.ReferenceEquals(this.DATA_5Field, value) != true)) {
                    this.DATA_5Field = value;
                    this.RaisePropertyChanged("DATA_5");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string RTN_URL {
            get {
                return this.RTN_URLField;
            }
            set {
                if ((object.ReferenceEquals(this.RTN_URLField, value) != true)) {
                    this.RTN_URLField = value;
                    this.RaisePropertyChanged("RTN_URL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string TRACE_URL {
            get {
                return this.TRACE_URLField;
            }
            set {
                if ((object.ReferenceEquals(this.TRACE_URLField, value) != true)) {
                    this.TRACE_URLField = value;
                    this.RaisePropertyChanged("TRACE_URL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string ERR_URL {
            get {
                return this.ERR_URLField;
            }
            set {
                if ((object.ReferenceEquals(this.ERR_URLField, value) != true)) {
                    this.ERR_URLField = value;
                    this.RaisePropertyChanged("ERR_URL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=16)]
        public string PAY_DATE {
            get {
                return this.PAY_DATEField;
            }
            set {
                if ((object.ReferenceEquals(this.PAY_DATEField, value) != true)) {
                    this.PAY_DATEField = value;
                    this.RaisePropertyChanged("PAY_DATE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=17)]
        public string PAY_TIME {
            get {
                return this.PAY_TIMEField;
            }
            set {
                if ((object.ReferenceEquals(this.PAY_TIMEField, value) != true)) {
                    this.PAY_TIMEField = value;
                    this.RaisePropertyChanged("PAY_TIME");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=18)]
        public string POST_URL {
            get {
                return this.POST_URLField;
            }
            set {
                if ((object.ReferenceEquals(this.POST_URLField, value) != true)) {
                    this.POST_URLField = value;
                    this.RaisePropertyChanged("POST_URL");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/", ConfigurationName="DevPaymentCenterCVS.CVSSoap")]
    public interface CVSSoap {
        
        // CODEGEN: 命名空間 http://PaymentCenter.AllPay.com.tw/ 的元素名稱  merchantTradeNo 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://PaymentCenter.AllPay.com.tw/CVSQuery", ReplyAction="*")]
        AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryResponse CVSQuery(AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryRequest request);
        
        // CODEGEN: 命名空間 http://PaymentCenter.AllPay.com.tw/ 的元素名稱  tradeInfoStore 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://PaymentCenter.AllPay.com.tw/CVSServerPost", ReplyAction="*")]
        AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostResponse CVSServerPost(AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CVSQueryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CVSQuery", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryRequestBody Body;
        
        public CVSQueryRequest() {
        }
        
        public CVSQueryRequest(AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class CVSQueryRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long merchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string merchantTradeNo;
        
        public CVSQueryRequestBody() {
        }
        
        public CVSQueryRequestBody(long merchantID, string merchantTradeNo) {
            this.merchantID = merchantID;
            this.merchantTradeNo = merchantTradeNo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CVSQueryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CVSQueryResponse", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryResponseBody Body;
        
        public CVSQueryResponse() {
        }
        
        public CVSQueryResponse(AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class CVSQueryResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CVSQueryResult;
        
        public CVSQueryResponseBody() {
        }
        
        public CVSQueryResponseBody(string CVSQueryResult) {
            this.CVSQueryResult = CVSQueryResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CVSServerPostRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CVSServerPost", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostRequestBody Body;
        
        public CVSServerPostRequest() {
        }
        
        public CVSServerPostRequest(AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class CVSServerPostRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCVS.TradeInfoStore tradeInfoStore;
        
        public CVSServerPostRequestBody() {
        }
        
        public CVSServerPostRequestBody(AllPayWebServiceTest.DevPaymentCenterCVS.TradeInfoStore tradeInfoStore) {
            this.tradeInfoStore = tradeInfoStore;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CVSServerPostResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CVSServerPostResponse", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostResponseBody Body;
        
        public CVSServerPostResponse() {
        }
        
        public CVSServerPostResponse(AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class CVSServerPostResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CVSServerPostResult;
        
        public CVSServerPostResponseBody() {
        }
        
        public CVSServerPostResponseBody(string CVSServerPostResult) {
            this.CVSServerPostResult = CVSServerPostResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CVSSoapChannel : AllPayWebServiceTest.DevPaymentCenterCVS.CVSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CVSSoapClient : System.ServiceModel.ClientBase<AllPayWebServiceTest.DevPaymentCenterCVS.CVSSoap>, AllPayWebServiceTest.DevPaymentCenterCVS.CVSSoap {
        
        public CVSSoapClient() {
        }
        
        public CVSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CVSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CVSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CVSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryResponse AllPayWebServiceTest.DevPaymentCenterCVS.CVSSoap.CVSQuery(AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryRequest request) {
            return base.Channel.CVSQuery(request);
        }
        
        public string CVSQuery(long merchantID, string merchantTradeNo) {
            AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryRequest inValue = new AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryRequest();
            inValue.Body = new AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryRequestBody();
            inValue.Body.merchantID = merchantID;
            inValue.Body.merchantTradeNo = merchantTradeNo;
            AllPayWebServiceTest.DevPaymentCenterCVS.CVSQueryResponse retVal = ((AllPayWebServiceTest.DevPaymentCenterCVS.CVSSoap)(this)).CVSQuery(inValue);
            return retVal.Body.CVSQueryResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostResponse AllPayWebServiceTest.DevPaymentCenterCVS.CVSSoap.CVSServerPost(AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostRequest request) {
            return base.Channel.CVSServerPost(request);
        }
        
        public string CVSServerPost(AllPayWebServiceTest.DevPaymentCenterCVS.TradeInfoStore tradeInfoStore) {
            AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostRequest inValue = new AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostRequest();
            inValue.Body = new AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostRequestBody();
            inValue.Body.tradeInfoStore = tradeInfoStore;
            AllPayWebServiceTest.DevPaymentCenterCVS.CVSServerPostResponse retVal = ((AllPayWebServiceTest.DevPaymentCenterCVS.CVSSoap)(this)).CVSServerPost(inValue);
            return retVal.Body.CVSServerPostResult;
        }
    }
}
