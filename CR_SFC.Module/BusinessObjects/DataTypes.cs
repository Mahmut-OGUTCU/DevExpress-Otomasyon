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
    public class DataTypes : XPBaseObject
    {
        public DataTypes(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int id;
        [Key(AutoGenerate = true), VisibleInListView(false), VisibleInDetailView(false)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
        }

        string name;
        [Size(50), XafDisplayName("Name")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

    }
}