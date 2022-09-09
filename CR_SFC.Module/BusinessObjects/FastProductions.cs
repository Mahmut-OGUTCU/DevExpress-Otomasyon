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
    public class FastProductions : XPBaseObject
    {
        public FastProductions(Session session) : base(session)
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

        Machines machineID;
        [Association("FastProductions-Machines")]
        public Machines MachineID
        {
            get => machineID;
            set => SetPropertyValue(nameof(MachineID), ref machineID, value);
        }

        int productionIndex;
        public int ProductionIndex
        {
            get => productionIndex;
            set => SetPropertyValue(nameof(ProductionIndex), ref productionIndex, value);
        }

        #region TagRelationships
        Tags _AddressTagID;
        [NonPersistent, XafDisplayName("Connect Address")]
        public Tags AddressTagID
        {
            get
            {
                if (Address != null)
                {
                    if (_AddressTagID == null)
                        return Session.Query<Tags>().FirstOrDefault(x => x.TagName == Address);
                }
                return _AddressTagID;
            }
            set
            {
                SetPropertyValue(nameof(AddressTagID), ref _AddressTagID, value);
                Address = AddressTagID.TagName;
            }
        }
        #endregion

        string address;
        [Size(50), VisibleInDetailView(false)]
        public string Address
        {
            get => address;
            set => SetPropertyValue(nameof(Address), ref address, value);
        }

        string explain;
        [Size(50)]
        public string Explain
        {
            get => explain;
            set => SetPropertyValue(nameof(Explain), ref explain, value);
        }
    }
}