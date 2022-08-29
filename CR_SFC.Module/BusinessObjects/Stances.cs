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
        [Key(AutoGenerate = true)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
        }

        // Machine olduğu için iptal
        //int machineID;
        //public int MachineID
        //{
        //    get => machineID;
        //    set => SetPropertyValue(nameof(MachineID), ref machineID, value);
        //}

        int priority;
        public int Priority
        {
            get => priority;
            set => SetPropertyValue(nameof(Priority), ref priority, value);
        }

        int startValue;
        public int StartValue
        {
            get => startValue;
            set => SetPropertyValue(nameof(StartValue), ref startValue, value);
        }

        int endValue;
        public int EndValue
        {
            get => endValue;
            set => SetPropertyValue(nameof(EndValue), ref endValue, value);
        }

        int waitParam;
        public int WaitParam
        {
            get => waitParam;
            set => SetPropertyValue(nameof(WaitParam), ref waitParam, value);
        }

        string address;
        [Size(50)]
        public string Address
        {
            get => address;
            set => SetPropertyValue(nameof(Address), ref address, value);
        }

        string explain;
        [Size(250)]
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