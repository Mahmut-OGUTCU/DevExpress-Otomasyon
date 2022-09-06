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
    public class TextileProductionDatas : XPBaseObject
    {
        public TextileProductionDatas(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int oid;
        [Key(AutoGenerate = true)]
        public int OID
        {
            get => oid;
            set => SetPropertyValue(nameof(OID), ref oid, value);
        }

        double welfValue;
        public double WelfValue
        {
            get => welfValue;
            set => SetPropertyValue(nameof(WelfValue), ref welfValue, value);
        }

        double welfValueNOSFC;
        public double WelfValueNOSFC
        {
            get => welfValueNOSFC;
            set => SetPropertyValue(nameof(WelfValueNOSFC), ref welfValueNOSFC, value);
        }

        Machines machine;
        public Machines Machine
        {
            get => machine;
            set => SetPropertyValue(nameof(Machine), ref machine, value);
        }

        string code;
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        string name;
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        string employeeCode;
        public string EmployeeCode
        {
            get => employeeCode;
            set => SetPropertyValue(nameof(EmployeeCode), ref employeeCode, value);
        }

        string rollFinishCounter;
        public string RollFinishCounter
        {
            get => rollFinishCounter;
            set => SetPropertyValue(nameof(RollFinishCounter), ref rollFinishCounter, value);
        }

        DateTime startTime;
        [RuleRequiredField("startTime2-Required", DefaultContexts.Save, "Lütfen Start Time Alanını Doldurunuz")]
        public DateTime StartTime
        {
            get => startTime;
            set => SetPropertyValue(nameof(StartTime), ref startTime, value);
        }

        DateTime endTime;
        [RuleRequiredField("endTime2-Required", DefaultContexts.Save, "Lütfen End Time Alanını Doldurunuz")]
        public DateTime EndTime
        {
            get => endTime;
            set => SetPropertyValue(nameof(EndTime), ref endTime, value);
        }

    }
}