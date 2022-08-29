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
    public class PrinterProductionData : XPBaseObject
    {
        public PrinterProductionData(Session session) : base(session)
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

        int reupdate;
        public int Reupdate
        {
            get => reupdate;
            set => SetPropertyValue(nameof(Reupdate), ref reupdate, value);
        }

        double totalValue;
        public double TotalValue
        {
            get => totalValue;
            set => SetPropertyValue(nameof(TotalValue), ref totalValue, value);
        }

        double currentValue;
        public double CurrentValue
        {
            get => currentValue;
            set => SetPropertyValue(nameof(CurrentValue), ref currentValue, value);
        }

        DateTime times;
        public DateTime Times
        {
            get => times;
            set => SetPropertyValue(nameof(Times), ref times, value);
        }

    }
}