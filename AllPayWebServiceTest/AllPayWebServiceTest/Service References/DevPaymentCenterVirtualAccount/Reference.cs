﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllPayWebServiceTest.DevPaymentCenterVirtualAccount {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ATMTradeQueryOutput", Namespace="http://PaymentCenter.AllPay.com.tw/")]
    [System.SerializableAttribute()]
    public partial class ATMTradeQueryOutput : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MerchantIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MerchantTradeNoField;
        
        private int RtnCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RtnMsgField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TradeNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string _paymentDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PaymentDateField;
        
        private int TradeAmtField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccBankField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReplyURLField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string MerchantId {
            get {
                return this.MerchantIdField;
            }
            set {
                if ((object.ReferenceEquals(this.MerchantIdField, value) != true)) {
                    this.MerchantIdField = value;
                    this.RaisePropertyChanged("MerchantId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string MerchantTradeNo {
            get {
                return this.MerchantTradeNoField;
            }
            set {
                if ((object.ReferenceEquals(this.MerchantTradeNoField, value) != true)) {
                    this.MerchantTradeNoField = value;
                    this.RaisePropertyChanged("MerchantTradeNo");
                }
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
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TradeNo {
            get {
                return this.TradeNoField;
            }
            set {
                if ((object.ReferenceEquals(this.TradeNoField, value) != true)) {
                    this.TradeNoField = value;
                    this.RaisePropertyChanged("TradeNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string _paymentDate {
            get {
                return this._paymentDateField;
            }
            set {
                if ((object.ReferenceEquals(this._paymentDateField, value) != true)) {
                    this._paymentDateField = value;
                    this.RaisePropertyChanged("_paymentDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string PaymentDate {
            get {
                return this.PaymentDateField;
            }
            set {
                if ((object.ReferenceEquals(this.PaymentDateField, value) != true)) {
                    this.PaymentDateField = value;
                    this.RaisePropertyChanged("PaymentDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public int TradeAmt {
            get {
                return this.TradeAmtField;
            }
            set {
                if ((this.TradeAmtField.Equals(value) != true)) {
                    this.TradeAmtField = value;
                    this.RaisePropertyChanged("TradeAmt");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string AccBank {
            get {
                return this.AccBankField;
            }
            set {
                if ((object.ReferenceEquals(this.AccBankField, value) != true)) {
                    this.AccBankField = value;
                    this.RaisePropertyChanged("AccBank");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string AccNo {
            get {
                return this.AccNoField;
            }
            set {
                if ((object.ReferenceEquals(this.AccNoField, value) != true)) {
                    this.AccNoField = value;
                    this.RaisePropertyChanged("AccNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string ReplyURL {
            get {
                return this.ReplyURLField;
            }
            set {
                if ((object.ReferenceEquals(this.ReplyURLField, value) != true)) {
                    this.ReplyURLField = value;
                    this.RaisePropertyChanged("ReplyURL");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/", ConfigurationName="DevPaymentCenterVirtualAccount.VirtualAccountSoap")]
    public interface VirtualAccountSoap {
        
        // CODEGEN: 命名空間 http://PaymentCenter.AllPay.com.tw/ 的元素名稱  merchantTradeNo 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://PaymentCenter.AllPay.com.tw/ATMQuery", ReplyAction="*")]
        AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryResponse ATMQuery(AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ATMQueryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ATMQuery", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryRequestBody Body;
        
        public ATMQueryRequest() {
        }
        
        public ATMQueryRequest(AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class ATMQueryRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long merchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string merchantTradeNo;
        
        public ATMQueryRequestBody() {
        }
        
        public ATMQueryRequestBody(long merchantID, string merchantTradeNo) {
            this.merchantID = merchantID;
            this.merchantTradeNo = merchantTradeNo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ATMQueryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ATMQueryResponse", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryResponseBody Body;
        
        public ATMQueryResponse() {
        }
        
        public ATMQueryResponse(AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class ATMQueryResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMTradeQueryOutput ATMQueryResult;
        
        public ATMQueryResponseBody() {
        }
        
        public ATMQueryResponseBody(AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMTradeQueryOutput ATMQueryResult) {
            this.ATMQueryResult = ATMQueryResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface VirtualAccountSoapChannel : AllPayWebServiceTest.DevPaymentCenterVirtualAccount.VirtualAccountSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VirtualAccountSoapClient : System.ServiceModel.ClientBase<AllPayWebServiceTest.DevPaymentCenterVirtualAccount.VirtualAccountSoap>, AllPayWebServiceTest.DevPaymentCenterVirtualAccount.VirtualAccountSoap {
        
        public VirtualAccountSoapClient() {
        }
        
        public VirtualAccountSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VirtualAccountSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VirtualAccountSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VirtualAccountSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryResponse AllPayWebServiceTest.DevPaymentCenterVirtualAccount.VirtualAccountSoap.ATMQuery(AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryRequest request) {
            return base.Channel.ATMQuery(request);
        }
        
        public AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMTradeQueryOutput ATMQuery(long merchantID, string merchantTradeNo) {
            AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryRequest inValue = new AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryRequest();
            inValue.Body = new AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryRequestBody();
            inValue.Body.merchantID = merchantID;
            inValue.Body.merchantTradeNo = merchantTradeNo;
            AllPayWebServiceTest.DevPaymentCenterVirtualAccount.ATMQueryResponse retVal = ((AllPayWebServiceTest.DevPaymentCenterVirtualAccount.VirtualAccountSoap)(this)).ATMQuery(inValue);
            return retVal.Body.ATMQueryResult;
        }
    }
}
