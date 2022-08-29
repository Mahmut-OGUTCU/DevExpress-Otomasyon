﻿using DevExpress.Data.Filtering;
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
    public class Shifts : XPBaseObject
    {
        public Shifts(Session session) : base(session)
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

        // NOTE: DB'de yok
        Machines machineID;
        public Machines MachineID
        {
            get => machineID;
            set => SetPropertyValue(nameof(MachineID), ref machineID, value);
        }

        string code;
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        string machine;
        public string Machine
        {
            get => machine;
            set => SetPropertyValue(nameof(Machine), ref machine, value);
        }

        string employeeCode;
        public string EmployeeCode
        {
            get => employeeCode;
            set => SetPropertyValue(nameof(EmployeeCode), ref employeeCode, value);
        }

        // little desc. for not null  => https://supportcenter.devexpress.com/ticket/details/t115053/missing-not-null-attribute-for-xpo-properties
        DateTime startTime;
        [RuleRequiredField("startTime1-Required", DefaultContexts.Save, "Lütfen Start Time Alanını Doldurunuz")]
        public DateTime StartTime
        {
            get => startTime;
            set => SetPropertyValue(nameof(StartTime), ref startTime, value);
        }

        DateTime endTime;
        [RuleRequiredField("endTime1-Required", DefaultContexts.Save, "Lütfen End Time Alanını Doldurunuz")]
        public DateTime EndTime
        {
            get => endTime;
            set => SetPropertyValue(nameof(EndTime), ref endTime, value);
        }

    }
}