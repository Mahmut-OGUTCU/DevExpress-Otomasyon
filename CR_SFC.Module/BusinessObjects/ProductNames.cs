using CR_SFC.Module.EnumObjects;
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

        PLCLibrarys _PanoID;
        [XafDisplayName("Pano Name"), VisibleInListView(false)]
        public PLCLibrarys PanotID
        {
            get => _PanoID;
            set => SetPropertyValue(nameof(PanotID), ref _PanoID, value);
        }

        string panoName;
        [VisibleInDetailView(false)]
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

        ProtocolType _ProtocolID;
        [XafDisplayName("Protocol Name"), VisibleInListView(false)]
        public ProtocolType ProtocolID
        {
            get => _ProtocolID;
            set => SetPropertyValue(nameof(ProtocolID), ref _ProtocolID, value);
        }

        string protocolName;
        [VisibleInDetailView(false)]
        public string ProtocolName
        {
            get => protocolName;
            set => SetPropertyValue(nameof(ProtocolName), ref protocolName, value);
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (_PanoID != null)
                panoName = _PanoID.PanoName;

            if (_ProtocolID == 0)
                throw new UserFriendlyException("Protokol Seçiniz.");

            var aa = _ProtocolID;

            if (_ProtocolID != 0)
                ProtocolName = ProtocolID.ToString();
        }
    }
}