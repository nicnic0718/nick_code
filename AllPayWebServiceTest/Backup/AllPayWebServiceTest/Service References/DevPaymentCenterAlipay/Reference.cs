﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.296
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllPayWebServiceTest.DevPaymentCenterAlipay {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AlipayTradeQueryPost", Namespace="http://PaymentCenter.AllPay.com.tw/")]
    [System.SerializableAttribute()]
    public partial class AlipayTradeQueryPost : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long MerchantIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string XMLDataField;
        
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
        public long MerchantId {
            get {
                return this.MerchantIdField;
            }
            set {
                if ((this.MerchantIdField.Equals(value) != true)) {
                    this.MerchantIdField = value;
                    this.RaisePropertyChanged("MerchantId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string XMLData {
            get {
                return this.XMLDataField;
            }
            set {
                if ((object.ReferenceEquals(this.XMLDataField, value) != true)) {
                    this.XMLDataField = value;
                    this.RaisePropertyChanged("XMLData");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/", ConfigurationName="DevPaymentCenterAlipay.alipaySoap")]
    public interface alipaySoap {
        
        // CODEGEN: 命名空間 http://PaymentCenter.AllPay.com.tw/ 的項目名稱  alipayTradeQuery 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://PaymentCenter.AllPay.com.tw/AlipayQuery", ReplyAction="*")]
        AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryResponse AlipayQuery(AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AlipayQueryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AlipayQuery", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryRequestBody Body;
        
        public AlipayQueryRequest() {
        }
        
        public AlipayQueryRequest(AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class AlipayQueryRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayTradeQueryPost alipayTradeQuery;
        
        public AlipayQueryRequestBody() {
        }
        
        public AlipayQueryRequestBody(AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayTradeQueryPost alipayTradeQuery) {
            this.alipayTradeQuery = alipayTradeQuery;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AlipayQueryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AlipayQueryResponse", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryResponseBody Body;
        
        public AlipayQueryResponse() {
        }
        
        public AlipayQueryResponse(AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class AlipayQueryResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string AlipayQueryResult;
        
        public AlipayQueryResponseBody() {
        }
        
        public AlipayQueryResponseBody(string AlipayQueryResult) {
            this.AlipayQueryResult = AlipayQueryResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface alipaySoapChannel : AllPayWebServiceTest.DevPaymentCenterAlipay.alipaySoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class alipaySoapClient : System.ServiceModel.ClientBase<AllPayWebServiceTest.DevPaymentCenterAlipay.alipaySoap>, AllPayWebServiceTest.DevPaymentCenterAlipay.alipaySoap {
        
        public alipaySoapClient() {
        }
        
        public alipaySoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public alipaySoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public alipaySoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public alipaySoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryResponse AllPayWebServiceTest.DevPaymentCenterAlipay.alipaySoap.AlipayQuery(AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryRequest request) {
            return base.Channel.AlipayQuery(request);
        }
        
        public string AlipayQuery(AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayTradeQueryPost alipayTradeQuery) {
            AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryRequest inValue = new AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryRequest();
            inValue.Body = new AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryRequestBody();
            inValue.Body.alipayTradeQuery = alipayTradeQuery;
            AllPayWebServiceTest.DevPaymentCenterAlipay.AlipayQueryResponse retVal = ((AllPayWebServiceTest.DevPaymentCenterAlipay.alipaySoap)(this)).AlipayQuery(inValue);
            return retVal.Body.AlipayQueryResult;
        }
    }
}
