﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllPayWebServiceTest.DevPaymentCenterCredit {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/", ConfigurationName="DevPaymentCenterCredit.creditcardSoap")]
    public interface creditcardSoap {
        
        // CODEGEN: 命名空間 http://PaymentCenter.AllPay.com.tw/ 的元素名稱  xmlData 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://PaymentCenter.AllPay.com.tw/CreateTrade", ReplyAction="*")]
        AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeResponse CreateTrade(AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeRequest request);
        
        // CODEGEN: 命名空間 http://PaymentCenter.AllPay.com.tw/ 的元素名稱  xmlData 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://PaymentCenter.AllPay.com.tw/VerifyOrderByOtp", ReplyAction="*")]
        AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpResponse VerifyOrderByOtp(AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpRequest request);
        
        // CODEGEN: 命名空間 http://PaymentCenter.AllPay.com.tw/ 的元素名稱  xmlData 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://PaymentCenter.AllPay.com.tw/ResendOtp", ReplyAction="*")]
        AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpResponse ResendOtp(AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpRequest request);
        
        // CODEGEN: 命名空間 http://PaymentCenter.AllPay.com.tw/ 的元素名稱  merchantTradeNo 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://PaymentCenter.AllPay.com.tw/QueryTrade", ReplyAction="*")]
        AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeResponse QueryTrade(AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeRequest request);
        
        // CODEGEN: 命名空間 http://PaymentCenter.AllPay.com.tw/ 的元素名稱  merchantTradeNo 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://PaymentCenter.AllPay.com.tw/PlatformQueryTrade", ReplyAction="*")]
        AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeResponse PlatformQueryTrade(AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeRequest request);
        
        // CODEGEN: 命名空間 http://PaymentCenter.AllPay.com.tw/ 的元素名稱  merchantTradeNo 未標示為 nillable，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://PaymentCenter.AllPay.com.tw/QueryPeriodTrade", ReplyAction="*")]
        AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeResponse QueryPeriodTrade(AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateTradeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CreateTrade", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeRequestBody Body;
        
        public CreateTradeRequest() {
        }
        
        public CreateTradeRequest(AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class CreateTradeRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long merchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string xmlData;
        
        public CreateTradeRequestBody() {
        }
        
        public CreateTradeRequestBody(long merchantID, string xmlData) {
            this.merchantID = merchantID;
            this.xmlData = xmlData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateTradeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CreateTradeResponse", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeResponseBody Body;
        
        public CreateTradeResponse() {
        }
        
        public CreateTradeResponse(AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class CreateTradeResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CreateTradeResult;
        
        public CreateTradeResponseBody() {
        }
        
        public CreateTradeResponseBody(string CreateTradeResult) {
            this.CreateTradeResult = CreateTradeResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class VerifyOrderByOtpRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="VerifyOrderByOtp", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpRequestBody Body;
        
        public VerifyOrderByOtpRequest() {
        }
        
        public VerifyOrderByOtpRequest(AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class VerifyOrderByOtpRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long merchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string xmlData;
        
        public VerifyOrderByOtpRequestBody() {
        }
        
        public VerifyOrderByOtpRequestBody(long merchantID, string xmlData) {
            this.merchantID = merchantID;
            this.xmlData = xmlData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class VerifyOrderByOtpResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="VerifyOrderByOtpResponse", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpResponseBody Body;
        
        public VerifyOrderByOtpResponse() {
        }
        
        public VerifyOrderByOtpResponse(AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class VerifyOrderByOtpResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string VerifyOrderByOtpResult;
        
        public VerifyOrderByOtpResponseBody() {
        }
        
        public VerifyOrderByOtpResponseBody(string VerifyOrderByOtpResult) {
            this.VerifyOrderByOtpResult = VerifyOrderByOtpResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ResendOtpRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ResendOtp", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpRequestBody Body;
        
        public ResendOtpRequest() {
        }
        
        public ResendOtpRequest(AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class ResendOtpRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long merchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string xmlData;
        
        public ResendOtpRequestBody() {
        }
        
        public ResendOtpRequestBody(long merchantID, string xmlData) {
            this.merchantID = merchantID;
            this.xmlData = xmlData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ResendOtpResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ResendOtpResponse", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpResponseBody Body;
        
        public ResendOtpResponse() {
        }
        
        public ResendOtpResponse(AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class ResendOtpResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ResendOtpResult;
        
        public ResendOtpResponseBody() {
        }
        
        public ResendOtpResponseBody(string ResendOtpResult) {
            this.ResendOtpResult = ResendOtpResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class QueryTradeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="QueryTrade", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeRequestBody Body;
        
        public QueryTradeRequest() {
        }
        
        public QueryTradeRequest(AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class QueryTradeRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long merchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string merchantTradeNo;
        
        public QueryTradeRequestBody() {
        }
        
        public QueryTradeRequestBody(long merchantID, string merchantTradeNo) {
            this.merchantID = merchantID;
            this.merchantTradeNo = merchantTradeNo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class QueryTradeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="QueryTradeResponse", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeResponseBody Body;
        
        public QueryTradeResponse() {
        }
        
        public QueryTradeResponse(AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
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
    public partial class PlatformQueryTradeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PlatformQueryTrade", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeRequestBody Body;
        
        public PlatformQueryTradeRequest() {
        }
        
        public PlatformQueryTradeRequest(AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class PlatformQueryTradeRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long merchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string merchantTradeNo;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public long PlatformID;
        
        public PlatformQueryTradeRequestBody() {
        }
        
        public PlatformQueryTradeRequestBody(long merchantID, string merchantTradeNo, long PlatformID) {
            this.merchantID = merchantID;
            this.merchantTradeNo = merchantTradeNo;
            this.PlatformID = PlatformID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PlatformQueryTradeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PlatformQueryTradeResponse", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeResponseBody Body;
        
        public PlatformQueryTradeResponse() {
        }
        
        public PlatformQueryTradeResponse(AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class PlatformQueryTradeResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string PlatformQueryTradeResult;
        
        public PlatformQueryTradeResponseBody() {
        }
        
        public PlatformQueryTradeResponseBody(string PlatformQueryTradeResult) {
            this.PlatformQueryTradeResult = PlatformQueryTradeResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class QueryPeriodTradeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="QueryPeriodTrade", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeRequestBody Body;
        
        public QueryPeriodTradeRequest() {
        }
        
        public QueryPeriodTradeRequest(AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class QueryPeriodTradeRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long merchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string merchantTradeNo;
        
        public QueryPeriodTradeRequestBody() {
        }
        
        public QueryPeriodTradeRequestBody(long merchantID, string merchantTradeNo) {
            this.merchantID = merchantID;
            this.merchantTradeNo = merchantTradeNo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class QueryPeriodTradeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="QueryPeriodTradeResponse", Namespace="http://PaymentCenter.AllPay.com.tw/", Order=0)]
        public AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeResponseBody Body;
        
        public QueryPeriodTradeResponse() {
        }
        
        public QueryPeriodTradeResponse(AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://PaymentCenter.AllPay.com.tw/")]
    public partial class QueryPeriodTradeResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string QueryPeriodTradeResult;
        
        public QueryPeriodTradeResponseBody() {
        }
        
        public QueryPeriodTradeResponseBody(string QueryPeriodTradeResult) {
            this.QueryPeriodTradeResult = QueryPeriodTradeResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface creditcardSoapChannel : AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class creditcardSoapClient : System.ServiceModel.ClientBase<AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap>, AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap {
        
        public creditcardSoapClient() {
        }
        
        public creditcardSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public creditcardSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public creditcardSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public creditcardSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeResponse AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap.CreateTrade(AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeRequest request) {
            return base.Channel.CreateTrade(request);
        }
        
        public string CreateTrade(long merchantID, string xmlData) {
            AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeRequest inValue = new AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeRequest();
            inValue.Body = new AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeRequestBody();
            inValue.Body.merchantID = merchantID;
            inValue.Body.xmlData = xmlData;
            AllPayWebServiceTest.DevPaymentCenterCredit.CreateTradeResponse retVal = ((AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap)(this)).CreateTrade(inValue);
            return retVal.Body.CreateTradeResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpResponse AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap.VerifyOrderByOtp(AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpRequest request) {
            return base.Channel.VerifyOrderByOtp(request);
        }
        
        public string VerifyOrderByOtp(long merchantID, string xmlData) {
            AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpRequest inValue = new AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpRequest();
            inValue.Body = new AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpRequestBody();
            inValue.Body.merchantID = merchantID;
            inValue.Body.xmlData = xmlData;
            AllPayWebServiceTest.DevPaymentCenterCredit.VerifyOrderByOtpResponse retVal = ((AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap)(this)).VerifyOrderByOtp(inValue);
            return retVal.Body.VerifyOrderByOtpResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpResponse AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap.ResendOtp(AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpRequest request) {
            return base.Channel.ResendOtp(request);
        }
        
        public string ResendOtp(long merchantID, string xmlData) {
            AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpRequest inValue = new AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpRequest();
            inValue.Body = new AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpRequestBody();
            inValue.Body.merchantID = merchantID;
            inValue.Body.xmlData = xmlData;
            AllPayWebServiceTest.DevPaymentCenterCredit.ResendOtpResponse retVal = ((AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap)(this)).ResendOtp(inValue);
            return retVal.Body.ResendOtpResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeResponse AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap.QueryTrade(AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeRequest request) {
            return base.Channel.QueryTrade(request);
        }
        
        public string QueryTrade(long merchantID, string merchantTradeNo) {
            AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeRequest inValue = new AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeRequest();
            inValue.Body = new AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeRequestBody();
            inValue.Body.merchantID = merchantID;
            inValue.Body.merchantTradeNo = merchantTradeNo;
            AllPayWebServiceTest.DevPaymentCenterCredit.QueryTradeResponse retVal = ((AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap)(this)).QueryTrade(inValue);
            return retVal.Body.QueryTradeResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeResponse AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap.PlatformQueryTrade(AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeRequest request) {
            return base.Channel.PlatformQueryTrade(request);
        }
        
        public string PlatformQueryTrade(long merchantID, string merchantTradeNo, long PlatformID) {
            AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeRequest inValue = new AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeRequest();
            inValue.Body = new AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeRequestBody();
            inValue.Body.merchantID = merchantID;
            inValue.Body.merchantTradeNo = merchantTradeNo;
            inValue.Body.PlatformID = PlatformID;
            AllPayWebServiceTest.DevPaymentCenterCredit.PlatformQueryTradeResponse retVal = ((AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap)(this)).PlatformQueryTrade(inValue);
            return retVal.Body.PlatformQueryTradeResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeResponse AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap.QueryPeriodTrade(AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeRequest request) {
            return base.Channel.QueryPeriodTrade(request);
        }
        
        public string QueryPeriodTrade(long merchantID, string merchantTradeNo) {
            AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeRequest inValue = new AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeRequest();
            inValue.Body = new AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeRequestBody();
            inValue.Body.merchantID = merchantID;
            inValue.Body.merchantTradeNo = merchantTradeNo;
            AllPayWebServiceTest.DevPaymentCenterCredit.QueryPeriodTradeResponse retVal = ((AllPayWebServiceTest.DevPaymentCenterCredit.creditcardSoap)(this)).QueryPeriodTrade(inValue);
            return retVal.Body.QueryPeriodTradeResult;
        }
    }
}
