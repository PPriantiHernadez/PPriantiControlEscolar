﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceReferenceAlumno {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/SL_WCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Alumno))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CorrectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception ExField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Correct {
            get {
                return this.CorrectField;
            }
            set {
                if ((this.CorrectField.Equals(value) != true)) {
                    this.CorrectField = value;
                    this.RaisePropertyChanged("Correct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Exception Ex {
            get {
                return this.ExField;
            }
            set {
                if ((object.ReferenceEquals(this.ExField, value) != true)) {
                    this.ExField = value;
                    this.RaisePropertyChanged("Ex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Object {
            get {
                return this.ObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectField, value) != true)) {
                    this.ObjectField = value;
                    this.RaisePropertyChanged("Object");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Objects {
            get {
                return this.ObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectsField, value) != true)) {
                    this.ObjectsField = value;
                    this.RaisePropertyChanged("Objects");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceAlumno.IAlumno")]
    public interface IAlumno {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/Add", ReplyAction="http://tempuri.org/IAlumno/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.ServiceReferenceAlumno.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        PL.ServiceReferenceAlumno.Result Add(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/Add", ReplyAction="http://tempuri.org/IAlumno/AddResponse")]
        System.Threading.Tasks.Task<PL.ServiceReferenceAlumno.Result> AddAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/Update", ReplyAction="http://tempuri.org/IAlumno/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.ServiceReferenceAlumno.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        PL.ServiceReferenceAlumno.Result Update(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/Update", ReplyAction="http://tempuri.org/IAlumno/UpdateResponse")]
        System.Threading.Tasks.Task<PL.ServiceReferenceAlumno.Result> UpdateAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/Delete", ReplyAction="http://tempuri.org/IAlumno/DeleteResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.ServiceReferenceAlumno.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        PL.ServiceReferenceAlumno.Result Delete(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/Delete", ReplyAction="http://tempuri.org/IAlumno/DeleteResponse")]
        System.Threading.Tasks.Task<PL.ServiceReferenceAlumno.Result> DeleteAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/GetAll", ReplyAction="http://tempuri.org/IAlumno/GetAllResponse")]
        PL.ServiceReferenceAlumno.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/GetAll", ReplyAction="http://tempuri.org/IAlumno/GetAllResponse")]
        System.Threading.Tasks.Task<PL.ServiceReferenceAlumno.Result> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/GetById", ReplyAction="http://tempuri.org/IAlumno/GetByIdResponse")]
        PL.ServiceReferenceAlumno.Result GetById(int IdAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/GetById", ReplyAction="http://tempuri.org/IAlumno/GetByIdResponse")]
        System.Threading.Tasks.Task<PL.ServiceReferenceAlumno.Result> GetByIdAsync(int IdAlumno);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlumnoChannel : PL.ServiceReferenceAlumno.IAlumno, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlumnoClient : System.ServiceModel.ClientBase<PL.ServiceReferenceAlumno.IAlumno>, PL.ServiceReferenceAlumno.IAlumno {
        
        public AlumnoClient() {
        }
        
        public AlumnoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AlumnoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PL.ServiceReferenceAlumno.Result Add(ML.Alumno alumno) {
            return base.Channel.Add(alumno);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReferenceAlumno.Result> AddAsync(ML.Alumno alumno) {
            return base.Channel.AddAsync(alumno);
        }
        
        public PL.ServiceReferenceAlumno.Result Update(ML.Alumno alumno) {
            return base.Channel.Update(alumno);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReferenceAlumno.Result> UpdateAsync(ML.Alumno alumno) {
            return base.Channel.UpdateAsync(alumno);
        }
        
        public PL.ServiceReferenceAlumno.Result Delete(ML.Alumno alumno) {
            return base.Channel.Delete(alumno);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReferenceAlumno.Result> DeleteAsync(ML.Alumno alumno) {
            return base.Channel.DeleteAsync(alumno);
        }
        
        public PL.ServiceReferenceAlumno.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReferenceAlumno.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public PL.ServiceReferenceAlumno.Result GetById(int IdAlumno) {
            return base.Channel.GetById(IdAlumno);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReferenceAlumno.Result> GetByIdAsync(int IdAlumno) {
            return base.Channel.GetByIdAsync(IdAlumno);
        }
    }
}
