﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.1008
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllPayWebServiceTest.StageAllpayWs {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Payment.allpay.com.tw/", ConfigurationName="StageAllpayWs.AllPaySoap")]
    public interface AllPaySoap {
        
        // CODEGEN: 命名空間 http://Payment.allpay.com.tw/ 的項目名稱  MerchantID 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://Payment.allpay.com.tw/QueryTrade", ReplyAction="*")]
        AllPayWebServiceTest.StageAllpayWs.QueryTradeResponse QueryTrade(AllPayWebServiceTest.StageAllpayWs.QueryTradeRequest request);
        
        // CODEGEN: 命名空間 http://Payment.allpay.com.tw/ 的項目名稱  MerchantID 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://Payment.allpay.com.tw/QueryTradeInfo", ReplyAction="*")]
        AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoResponse QueryTradeInfo(AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class QueryTradeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="QueryTrade", Namespace="http://Payment.allpay.com.tw/", Order=0)]
        public AllPayWebServiceTest.StageAllpayWs.QueryTradeRequestBody Body;
        
        public QueryTradeRequest() {
        }
        
        public QueryTradeRequest(AllPayWebServiceTest.StageAllpayWs.QueryTradeRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://Payment.allpay.com.tw/")]
    public partial class QueryTradeRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string XMLData;
        
        public QueryTradeRequestBody() {
        }
        
        public QueryTradeRequestBody(string MerchantID, string XMLData) {
            this.MerchantID = MerchantID;
            this.XMLData = XMLData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class QueryTradeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="QueryTradeResponse", Namespace="http://Payment.allpay.com.tw/", Order=0)]
        public AllPayWebServiceTest.StageAllpayWs.QueryTradeResponseBody Body;
        
        public QueryTradeResponse() {
        }
        
        public QueryTradeResponse(AllPayWebServiceTest.StageAllpayWs.QueryTradeResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://Payment.allpay.com.tw/")]
    public partial class QueryTradeResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string QueryTradeResult;
        
        public QueryTradeResponseBody() {
        }
        
        public QueryTradeResponseBody(string QueryTradeResult) {
            this.QueryTradeResult = QueryTradeResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class QueryTradeInfoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="QueryTradeInfo", Namespace="http://Payment.allpay.com.tw/", Order=0)]
        public AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoRequestBody Body;
        
        public QueryTradeInfoRequest() {
        }
        
        public QueryTradeInfoRequest(AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://Payment.allpay.com.tw/")]
    public partial class QueryTradeInfoRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string MerchantTradeNo;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int TimeStamp;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string CheckMacValue;
        
        public QueryTradeInfoRequestBody() {
        }
        
        public QueryTradeInfoRequestBody(string MerchantID, string MerchantTradeNo, int TimeStamp, string CheckMacValue) {
            this.MerchantID = MerchantID;
            this.MerchantTradeNo = MerchantTradeNo;
            this.TimeStamp = TimeStamp;
            this.CheckMacValue = CheckMacValue;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class QueryTradeInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="QueryTradeInfoResponse", Namespace="http://Payment.allpay.com.tw/", Order=0)]
        public AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoResponseBody Body;
        
        public QueryTradeInfoResponse() {
        }
        
        public QueryTradeInfoResponse(AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://Payment.allpay.com.tw/")]
    public partial class QueryTradeInfoResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string QueryTradeInfoResult;
        
        public QueryTradeInfoResponseBody() {
        }
        
        public QueryTradeInfoResponseBody(string QueryTradeInfoResult) {
            this.QueryTradeInfoResult = QueryTradeInfoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AllPaySoapChannel : AllPayWebServiceTest.StageAllpayWs.AllPaySoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AllPaySoapClient : System.ServiceModel.ClientBase<AllPayWebServiceTest.StageAllpayWs.AllPaySoap>, AllPayWebServiceTest.StageAllpayWs.AllPaySoap {
        
        public AllPaySoapClient() {
        }
        
        public AllPaySoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AllPaySoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AllPaySoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AllPaySoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.StageAllpayWs.QueryTradeResponse AllPayWebServiceTest.StageAllpayWs.AllPaySoap.QueryTrade(AllPayWebServiceTest.StageAllpayWs.QueryTradeRequest request) {
            return base.Channel.QueryTrade(request);
        }
        
        public string QueryTrade(string MerchantID, string XMLData) {
            AllPayWebServiceTest.StageAllpayWs.QueryTradeRequest inValue = new AllPayWebServiceTest.StageAllpayWs.QueryTradeRequest();
            inValue.Body = new AllPayWebServiceTest.StageAllpayWs.QueryTradeRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.XMLData = XMLData;
            AllPayWebServiceTest.StageAllpayWs.QueryTradeResponse retVal = ((AllPayWebServiceTest.StageAllpayWs.AllPaySoap)(this)).QueryTrade(inValue);
            return retVal.Body.QueryTradeResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoResponse AllPayWebServiceTest.StageAllpayWs.AllPaySoap.QueryTradeInfo(AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoRequest request) {
            return base.Channel.QueryTradeInfo(request);
        }
        
        public string QueryTradeInfo(string MerchantID, string MerchantTradeNo, int TimeStamp, string CheckMacValue) {
            AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoRequest inValue = new AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoRequest();
            inValue.Body = new AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.MerchantTradeNo = MerchantTradeNo;
            inValue.Body.TimeStamp = TimeStamp;
            inValue.Body.CheckMacValue = CheckMacValue;
            AllPayWebServiceTest.StageAllpayWs.QueryTradeInfoResponse retVal = ((AllPayWebServiceTest.StageAllpayWs.AllPaySoap)(this)).QueryTradeInfo(inValue);
            return retVal.Body.QueryTradeInfoResult;
        }
    }
}
