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
    [XafDefaultProperty(nameof(ProductName))]
    public class ProductNames : XPBaseObject
    {
        public ProductNames(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        #region ProductNameRelationships
        PLCLibrarys _PanoNamePLCLibraryID;
        [NonPersistent, ImmediatePostData, XafDisplayName("Pano Name")]
        public PLCLibrarys PanoNamePLCLibraryID
        {
            get
            {
                if (_PanoNamePLCLibraryID == null)
                    return Session.Query<PLCLibrarys>().FirstOrDefault(x => x.PanoName == PanoName);
                return _PanoNamePLCLibraryID;
            }
            set
            {
                SetPropertyValue(nameof(PanoNamePLCLibraryID), ref _PanoNamePLCLibraryID, value);
                PanoName = PanoNamePLCLibraryID.PanoName;
            }
        }


        #endregion

        int oid;
        [Key(AutoGenerate = true), VisibleInListView(false), VisibleInDetailView(false)]
        public int OID
        {
            get => oid;
            set => SetPropertyValue(nameof(OID), ref oid, value);
        }

        string productName;
        [XafDisplayName("Product Name")]
        public string ProductName
        {
            get => productName;
            set => SetPropertyValue(nameof(ProductName), ref productName, value);
        }

        string panoName;
        [VisibleInListView(false), VisibleInDetailView(false)]
        public string PanoName
        {
            get => panoName;
            set => SetPropertyValue(nameof(PanoName), ref panoName, value);
        }

        string sectionName;
        [XafDisplayName("Section Name")]
        public string SectionName
        {
            get => sectionName;
            set => SetPropertyValue(nameof(SectionName), ref sectionName, value);
        }

        string protocolName;
        [VisibleInListView(false), VisibleInDetailView(false)]
        public string ProtocolName
        {
            get => protocolName;
            set => SetPropertyValue(nameof(ProtocolName), ref protocolName, value);
        }

        ProtocolType _ProtocolTypeID;
        [NonPersistent, ImmediatePostData, XafDisplayName("Pano Name")]
        public ProtocolType ProtocolTypeID
        {
            get
            {
                if (_ProtocolTypeID.ToString() == "Seçiniz")
                {
                    foreach (var item in Enum.GetValues(typeof(ProtocolType)))
                    {
                        if (item.ToString() == ProtocolName)
                        {
                            return (ProtocolType)item;
                        }
                    }
                }
                return _ProtocolTypeID;
            }
            set
            {
                SetPropertyValue(nameof(ProtocolTypeID), ref _ProtocolTypeID, value);
                ProtocolName = ProtocolTypeID.ToString();
            }
        }
    }
}