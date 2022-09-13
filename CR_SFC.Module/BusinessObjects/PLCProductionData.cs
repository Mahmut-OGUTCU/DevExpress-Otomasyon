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
    public class PLCProductionData : XPBaseObject
    {
        public PLCProductionData(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int oid;
        [Key(AutoGenerate = true), VisibleInDetailView(false), VisibleInListView(false)]
        public int OID
        {
            get => oid;
            set => SetPropertyValue(nameof(OID), ref oid, value);
        }

        Machines machineID;
        [XafDisplayName("Machine Name")]
        public Machines MachineID
        {
            get => machineID;
            set => SetPropertyValue(nameof(MachineID), ref machineID, value);
        }

        DataTypes dataTypeID;
        [XafDisplayName("Data Type")]
        public DataTypes DataTypeID
        {
            get => dataTypeID;
            set => SetPropertyValue(nameof(DataTypeID), ref dataTypeID, value);
        }

        int dataValue;
        [XafDisplayName("Data Value")]
        public int DataValue
        {
            get => dataValue;
            set => SetPropertyValue(nameof(DataValue), ref dataValue, value);
        }

        int counters;
        [XafDisplayName("Counters")]
        public int Counters
        {
            get => counters;
            set => SetPropertyValue(nameof(Counters), ref counters, value);
        }

        DataExplains dataExplainID;
        [XafDisplayName("Data Explain")]
        public DataExplains DataExplainID
        {
            get => dataExplainID;
            set => SetPropertyValue(nameof(DataExplainID), ref dataExplainID, value);
        }

        int reupdate;
        [XafDisplayName("Reupdate")]
        public int Reupdate
        {
            get => reupdate;
            set => SetPropertyValue(nameof(Reupdate), ref reupdate, value);
        }

        int workorderID;
        [XafDisplayName("Work Order")]
        public int WorkorderID
        {
            get => workorderID;
            set => SetPropertyValue(nameof(WorkorderID), ref workorderID, value);
        }

        byte bant_no;
        [XafDisplayName("Bant No")]
        public byte Bant_no
        {
            get => bant_no;
            set => SetPropertyValue(nameof(Bant_no), ref bant_no, value);
        }

        Int16 batchNo;
        [XafDisplayName("Batch No")]
        public Int16 BatchNo
        {
            get => batchNo;
            set => SetPropertyValue(nameof(BatchNo), ref batchNo, value);
        }

        string dataExplainCode;
        [Size(30), XafDisplayName("Data Explain Code")]
        public string DataExplainCode
        {
            get => dataExplainCode;
            set => SetPropertyValue(nameof(DataExplainCode), ref dataExplainCode, value);
        }

        string stockCardCode;
        [Size(50), XafDisplayName("Stock Card Code")]
        public string StockCardCode
        {
            get => stockCardCode;
            set => SetPropertyValue(nameof(StockCardCode), ref stockCardCode, value);
        }

        string packageNumber;
        [Size(50), XafDisplayName("Package Number")]
        public string PackageNumber
        {
            get => packageNumber;
            set => SetPropertyValue(nameof(PackageNumber), ref packageNumber, value);
        }

        string packagingFiche;
        [Size(200), XafDisplayName("Packaging Fiche")]
        public string PackagingFiche
        {
            get => packagingFiche;
            set => SetPropertyValue(nameof(PackagingFiche), ref packagingFiche, value);
        }

        string packagingFiche2;
        [Size(200), XafDisplayName("Packaging Fiche 2")]
        public string PackagingFiche2
        {
            get => packagingFiche2;
            set => SetPropertyValue(nameof(PackagingFiche2), ref packagingFiche2, value);
        }

        string serialLotCode;
        [Size(100), XafDisplayName("Serial Lot Code")]
        public string SerialLotCode
        {
            get => serialLotCode;
            set => SetPropertyValue(nameof(SerialLotCode), ref serialLotCode, value);
        }

        string ficheNo;
        [Size(50), XafDisplayName("Fiche No")]
        public string FicheNo
        {
            get => ficheNo;
            set => SetPropertyValue(nameof(FicheNo), ref ficheNo, value);
        }

        DateTime productionDate;
        [XafDisplayName("Production Date")]
        public DateTime ProductionDate
        {
            get => productionDate;
            set => SetPropertyValue(nameof(ProductionDate), ref productionDate, value);
        }

        DateTime expireDate;
        [XafDisplayName("Expire Date")]
        public DateTime ExpireDate
        {
            get => expireDate;
            set => SetPropertyValue(nameof(ExpireDate), ref expireDate, value);
        }

    }
}