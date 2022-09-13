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
    public class Shifts : XPBaseObject
    {
        public Shifts(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        #region MachineRelationships
        Machines _ShiftMachineID;
        [NonPersistent, ImmediatePostData, XafDisplayName("Machine Name")]
        public Machines ShiftMachineID
        {
            get
            {
                if (_ShiftMachineID == null)
                    return Session.Query<Machines>().FirstOrDefault(x => x.Name == Machine);
                return _ShiftMachineID;
            }
            set
            {
                SetPropertyValue(nameof(ShiftMachineID), ref _ShiftMachineID, value);
                Machine = ShiftMachineID.Name;
            }
        }
        #endregion

        int oid;
        [Key(AutoGenerate = true), VisibleInDetailView(false), VisibleInListView(false)]
        public int OID
        {
            get => oid;
            set => SetPropertyValue(nameof(OID), ref oid, value);
        }

        string code;
        [XafDisplayName("Code"), VisibleInListView(false)]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        string machine;
        [VisibleInDetailView(false), VisibleInListView(false)]
        public string Machine
        {
            get => machine;
            set => SetPropertyValue(nameof(Machine), ref machine, value);
        }

        string employeeCode;
        [XafDisplayName("Employee Code"), VisibleInListView(false)]
        public string EmployeeCode
        {
            get => employeeCode;
            set => SetPropertyValue(nameof(EmployeeCode), ref employeeCode, value);
        }

        DateTime startTime;
        [XafDisplayName("Start Time"), VisibleInListView(false)]
        [RuleRequiredField("startTime1-Required", DefaultContexts.Save, "Lütfen Start Time Alanını Doldurunuz")]
        public DateTime StartTime
        {
            get => startTime;
            set => SetPropertyValue(nameof(StartTime), ref startTime, value);
        }

        DateTime endTime;
        [XafDisplayName("End Time"), VisibleInListView(false)]
        [RuleRequiredField("endTime1-Required", DefaultContexts.Save, "Lütfen End Time Alanını Doldurunuz")]
        public DateTime EndTime
        {
            get => endTime;
            set => SetPropertyValue(nameof(EndTime), ref endTime, value);
        }

    }
}