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
    public class Stances : XPBaseObject
    {
        public Stances(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int id;
        [Key(AutoGenerate = true), VisibleInDetailView(false), VisibleInListView(false)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
        }

        int priority;
        [XafDisplayName("Priority"), VisibleInListView(false)]
        public int Priority
        {
            get => priority;
            set => SetPropertyValue(nameof(Priority), ref priority, value);
        }

        int startValue;
        [XafDisplayName("Start Value"), VisibleInListView(false)]
        public int StartValue
        {
            get => startValue;
            set => SetPropertyValue(nameof(StartValue), ref startValue, value);
        }

        int endValue;
        [XafDisplayName("End Value"), VisibleInListView(false)]
        public int EndValue
        {
            get => endValue;
            set => SetPropertyValue(nameof(EndValue), ref endValue, value);
        }

        int waitParam;
        [XafDisplayName("Wait Param"), VisibleInListView(false)]
        public int WaitParam
        {
            get => waitParam;
            set => SetPropertyValue(nameof(WaitParam), ref waitParam, value);
        }

        string address;
        [Size(50), XafDisplayName("Address"), VisibleInListView(false)]
        public string Address
        {
            get => address;
            set => SetPropertyValue(nameof(Address), ref address, value);
        }

        string explain;
        [Size(250), XafDisplayName("Explain"), VisibleInListView(false)]
        public string Explain
        {
            get => explain;
            set => SetPropertyValue(nameof(Explain), ref explain, value);
        }

        Machines _Machines;
        [Association("Stance-Machines")]
        public Machines MachineID
        {
            get => _Machines;
            set => SetPropertyValue<Machines>(nameof(MachineID), ref _Machines, value);
        }

    }
}