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
    public class ProductNames : XPBaseObject
    {
        public ProductNames(Session session) : base(session)
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

        string productName;
        public string ProductName
        {
            get => productName;
            set => SetPropertyValue(nameof(ProductName), ref productName, value);
        }


        string panoName;
        public string PanoName
        {
            get => panoName;
            set => SetPropertyValue(nameof(PanoName), ref panoName, value);
        }

        string sectionName;
        public string SectionName
        {
            get => sectionName;
            set => SetPropertyValue(nameof(SectionName), ref sectionName, value);
        }

        string protocolName;
        public string ProtocolName
        {
            get => protocolName;
            set => SetPropertyValue(nameof(ProtocolName), ref protocolName, value);
        }
    }
}