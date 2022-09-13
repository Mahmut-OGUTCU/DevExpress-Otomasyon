using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CR_SFC.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class DebugLogs : XPBaseObject
    {
        public DebugLogs(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int id;
        [Key(AutoGenerate = true), VisibleInListView(false), VisibleInDetailView(false)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
        }

        int lineNumber;
        [XafDisplayName("Line Number")]
        public int LineNumber
        {
            get => lineNumber;
            set => SetPropertyValue(nameof(LineNumber), ref lineNumber, value);
        }

        string logType;
        [Size(10), XafDisplayName("Log Type")]
        public string LogType
        {
            get => logType;
            set => SetPropertyValue(nameof(LogType), ref logType, value);
        }

        string header;
        [XafDisplayName("Header")]
        public string Header
        {
            get => header;
            set => SetPropertyValue(nameof(Header), ref header, value);
        }

        string ipAddress;
        [Size(15), XafDisplayName("IP Address")]
        public string IpAddress
        {
            get => ipAddress;
            set => SetPropertyValue(nameof(IpAddress), ref ipAddress, value);
        }

        string exceptionMessage;
        [XafDisplayName("Exeption Message")]
        public string ExceptionMessage
        {
            get => exceptionMessage;
            set => SetPropertyValue(nameof(ExceptionMessage), ref exceptionMessage, value);
        }

        string stackTrace;
        [XafDisplayName("Stack Trace")]
        public string StackTrace
        {
            get => stackTrace;
            set => SetPropertyValue(nameof(StackTrace), ref stackTrace, value);
        }

        DateTime timeOccurred;
        [XafDisplayName("Time Occurred")]
        [RuleRequiredField("timeOccurred-Required", DefaultContexts.Save, "Lütfen Time Occurred Alanını Doldurunuz")]
        public DateTime TimeOccurred
        {
            get => timeOccurred;
            set => SetPropertyValue(nameof(TimeOccurred), ref timeOccurred, value);
        }

    }
}