﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.269
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllPayWebServiceTest.DevPaymentCenterWebATM {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/", ConfigurationName="DevPaymentCenterWebATM.WebATMSoap")]
    public interface WebATMSoap {
        
        // CODEGEN: 命名空間 http://PaymentCenter.AllPay.com.tw/ 的項目名稱  merchantTradeNo 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://PaymentCenter.AllPay.com.tw/WebATMQuery", ReplyAction="*")]
        AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryResponse WebATMQuery(AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class WebATMQueryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="WebATMQuery", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryRequestBody Body;
        
        public WebATMQueryRequest() {
        }
        
        public WebATMQueryRequest(AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class WebATMQueryRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long merchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string merchantTradeNo;
        
        public WebATMQueryRequestBody() {
        }
        
        public WebATMQueryRequestBody(long merchantID, string merchantTradeNo) {
            this.merchantID = merchantID;
            this.merchantTradeNo = merchantTradeNo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class WebATMQueryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="WebATMQueryResponse", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryResponseBody Body;
        
        public WebATMQueryResponse() {
        }
        
        public WebATMQueryResponse(AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class WebATMQueryResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string WebATMQueryResult;
        
        public WebATMQueryResponseBody() {
        }
        
        public WebATMQueryResponseBody(string WebATMQueryResult) {
            this.WebATMQueryResult = WebATMQueryResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebATMSoapChannel : AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebATMSoapClient : System.ServiceModel.ClientBase<AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMSoap>, AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMSoap {
        
        public WebATMSoapClient() {
        }
        
        public WebATMSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebATMSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebATMSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebATMSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryResponse AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMSoap.WebATMQuery(AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryRequest request) {
            return base.Channel.WebATMQuery(request);
        }
        
        public string WebATMQuery(long merchantID, string merchantTradeNo) {
            AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryRequest inValue = new AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryRequest();
            inValue.Body = new AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryRequestBody();
            inValue.Body.merchantID = merchantID;
            inValue.Body.merchantTradeNo = merchantTradeNo;
            AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMQueryResponse retVal = ((AllPayWebServiceTest.DevPaymentCenterWebATM.WebATMSoap)(this)).WebATMQuery(inValue);
            return retVal.Body.WebATMQueryResult;
        }
    }
}
