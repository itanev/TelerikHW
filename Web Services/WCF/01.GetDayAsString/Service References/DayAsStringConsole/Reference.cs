﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _01.GetDayAsString.DayAsStringConsole {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DayAsStringConsole.IDayAsStringService")]
    public interface IDayAsStringService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDayAsStringService/GetDayAsString", ReplyAction="http://tempuri.org/IDayAsStringService/GetDayAsStringResponse")]
        string GetDayAsString(System.DateTime value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDayAsStringService/GetDayAsString", ReplyAction="http://tempuri.org/IDayAsStringService/GetDayAsStringResponse")]
        System.Threading.Tasks.Task<string> GetDayAsStringAsync(System.DateTime value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDayAsStringServiceChannel : _01.GetDayAsString.DayAsStringConsole.IDayAsStringService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DayAsStringServiceClient : System.ServiceModel.ClientBase<_01.GetDayAsString.DayAsStringConsole.IDayAsStringService>, _01.GetDayAsString.DayAsStringConsole.IDayAsStringService {
        
        public DayAsStringServiceClient() {
        }
        
        public DayAsStringServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DayAsStringServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DayAsStringServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DayAsStringServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetDayAsString(System.DateTime value) {
            return base.Channel.GetDayAsString(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDayAsStringAsync(System.DateTime value) {
            return base.Channel.GetDayAsStringAsync(value);
        }
    }
}