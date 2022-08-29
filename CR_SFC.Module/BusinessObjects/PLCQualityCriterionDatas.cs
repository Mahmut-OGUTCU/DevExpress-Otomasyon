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
    public class PLCQualityCriterionDatas : XPBaseObject
    {
        public PLCQualityCriterionDatas(Session session) : base(session)
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

        Machines machineID;
        public Machines MachineID
        {
            get => machineID;
            set => SetPropertyValue(nameof(MachineID), ref machineID, value);
        }

        DataExplains dataExplainID;
        public DataExplains DataExplainID
        {
            get => dataExplainID;
            set => SetPropertyValue(nameof(DataExplainID), ref dataExplainID, value);
        }

        double dataValue;
        public double DataValue
        {
            get => dataValue;
            set => SetPropertyValue(nameof(DataValue), ref dataValue, value);
        }

        double dataDifferenceValue;
        public double DataDifferenceValue
        {
            get => dataDifferenceValue;
            set => SetPropertyValue(nameof(DataDifferenceValue), ref dataDifferenceValue, value);
        }

        DateTime times;
        [RuleRequiredField("times2-Required", DefaultContexts.Save, "Lütfen Times Alanını Doldurunuz")]
        public DateTime Times
        {
            get => times;
            set => SetPropertyValue(nameof(Times), ref times, value);
        }

    }
}