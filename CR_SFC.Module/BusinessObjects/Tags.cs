using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
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
    public class Tags : XPBaseObject
    {
        public Tags(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int id;
        [Key(AutoGenerate = true), VisibleInDetailView(false), VisibleInListView(false)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
        }

        // NOTE: int olan bu alanı select olabilmesi için string yaptım. duruma göre değiştirilir.
        string dataLenght;
        [XafDisplayName("Lenght")]
        [ModelDefault("PredefinedValues", "1;8;16;32;64")]
        public string DataLenght
        {
            get => dataLenght;
            set => SetPropertyValue(nameof(DataLenght), ref dataLenght, value);
        }

        string tagName;
        [Size(30), XafDisplayName("Tag Name")]
        public string TagName
        {
            get => tagName;
            set => SetPropertyValue(nameof(TagName), ref tagName, value);
        }

        string tagAddress;
        [Size(50), XafDisplayName("Tag Address")]
        public string TagAddress
        {
            get => tagAddress;
            set => SetPropertyValue(nameof(TagAddress), ref tagAddress, value);
        }

        string dataType;
        [Size(10), XafDisplayName("Type"), ModelDefault("PredefinedValues", "Bit;Byte;Integer;UInteger;Float")]
        public string DataType
        {
            get => dataType;
            set => SetPropertyValue(nameof(DataType), ref dataType, value);
        }

        string registerOrder;
        [Size(10), XafDisplayName("Register Order"), ModelDefault("PredefinedValues", "LowHigh;HighLow")]
        public string RegisterOrder
        {
            get => registerOrder;
            set => SetPropertyValue(nameof(RegisterOrder), ref registerOrder, value);
        }

        string input;
        [Size(50), XafDisplayName("Input"), VisibleInDetailView(false), VisibleInListView(false)]
        public string Input
        {
            get => input;
            set => SetPropertyValue(nameof(Input), ref input, value);
        }
    }
}