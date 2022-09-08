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
    public class Reports : XPBaseObject
    {
        public Reports(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        #region MachineRelationships
        Machines _MachineID;
        [NonPersistent, ImmediatePostData, XafDisplayName("Machine Name")]
        public Machines MachineID
        {
            get
            {
                if (_MachineID == null)
                    return Session.Query<Machines>().FirstOrDefault(x => x.Name == MachineName);
                return _MachineID;
            }
            set
            {
                SetPropertyValue(nameof(MachineID), ref _MachineID, value);
                MachineName = MachineID.Name;
            }
        }
        #endregion

        int id;
        [Key(AutoGenerate = true)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
        }

        string machineName;
        [Size(50), VisibleInDetailView(false), VisibleInListView(false)]
        public string MachineName
        {
            get => machineName;
            set => SetPropertyValue(nameof(MachineName), ref machineName, value);
        }

        string type;
        [Size(50)]
        public string Type
        {
            get => type;
            set => SetPropertyValue(nameof(Type), ref type, value);
        }

        string description;
        [Size(50)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        string panel;
        [Size(50)]
        public string Panel
        {
            get => panel;
            set => SetPropertyValue(nameof(Panel), ref panel, value);
        }

        string pano;
        [Size(50)]
        public string Pano
        {
            get => pano;
            set => SetPropertyValue(nameof(Pano), ref pano, value);
        }

        string sectionName;
        [Size(50)]
        public string SectionName
        {
            get => sectionName;
            set => SetPropertyValue(nameof(SectionName), ref sectionName, value);
        }

        string protocol;
        [Size(50)]
        public string Protocol
        {
            get => protocol;
            set => SetPropertyValue(nameof(Protocol), ref protocol, value);
        }

        string tag;
        [Size(50)]
        public string Tag
        {
            get => tag;
            set => SetPropertyValue(nameof(Tag), ref tag, value);
        }

        string address;
        [Size(50)]
        public string Address
        {
            get => address;
            set => SetPropertyValue(nameof(Address), ref address, value);
        }

        string input;
        [Size(50)]
        public string Input
        {
            get => input;
            set => SetPropertyValue(nameof(Input), ref input, value);
        }

    }
}