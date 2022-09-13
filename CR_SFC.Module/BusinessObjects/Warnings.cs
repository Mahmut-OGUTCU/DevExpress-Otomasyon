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
    public class Warnings : XPBaseObject
    {
        public Warnings(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        #region TagRelationships
        Tags _AddressTagID;
        [NonPersistent, ImmediatePostData, XafDisplayName("Address")]
        public Tags AddressTagID
        {
            get
            {
                if (_AddressTagID == null)
                    return Session.Query<Tags>().FirstOrDefault(x => x.TagName == Address);
                return _AddressTagID;
            }
            set
            {
                SetPropertyValue(nameof(AddressTagID), ref _AddressTagID, value);
                Address = AddressTagID.TagName;
            }
        }
        #endregion

        int id;
        [Key(AutoGenerate = true), VisibleInDetailView(false), VisibleInListView(false)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
        }

        int currentValue;
        [XafDisplayName("Current Value"), VisibleInListView(false)]
        public int CurrentValue
        {
            get => currentValue;
            set => SetPropertyValue(nameof(CurrentValue), ref currentValue, value);
        }

        string address;
        [Size(20), VisibleInDetailView(false), VisibleInListView(false)]
        public string Address
        {
            get => address;
            set => SetPropertyValue(nameof(Address), ref address, value);
        }

        string explain;
        [Size(20), XafDisplayName("Explain"), VisibleInListView(false)]
        public string Explain
        {
            get => explain;
            set => SetPropertyValue(nameof(Explain), ref explain, value);
        }

        Machines _Machines;
        [Association("Warnings-Machines")]
        public Machines MachineID
        {
            get => _Machines;
            set => SetPropertyValue<Machines>(nameof(MachineID), ref _Machines, value);
        }

    }
}