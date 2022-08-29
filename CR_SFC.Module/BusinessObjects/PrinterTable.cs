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
    public class PrinterTable : XPBaseObject
    {
        public PrinterTable(Session session) : base(session)
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

        // NOTE: DB'de yok
        Machines machineID;
        public Machines MachineID
        {
            get => machineID;
            set => SetPropertyValue(nameof(MachineID), ref machineID, value);
        }

        string printerName;
        [Size(50)]
        public string PrinterName
        {
            get => printerName;
            set => SetPropertyValue(nameof(PrinterName), ref printerName, value);
        }

        string building1IpAddress;
        [Size(15)]
        public string Building1IpAddress
        {
            get => building1IpAddress;
            set => SetPropertyValue(nameof(Building1IpAddress), ref building1IpAddress, value);
        }

        string building2IpAddress;
        [Size(15)]
        public string Building2IpAddress
        {
            get => building2IpAddress;
            set => SetPropertyValue(nameof(Building2IpAddress), ref building2IpAddress, value);
        }

        string building3IpAddress;
        [Size(15)]
        public string Building3IpAddress
        {
            get => building3IpAddress;
            set => SetPropertyValue(nameof(Building3IpAddress), ref building3IpAddress, value);
        }

        string building4IpAddress;
        [Size(15)]
        public string Building4IpAddress
        {
            get => building4IpAddress;
            set => SetPropertyValue(nameof(Building4IpAddress), ref building4IpAddress, value);
        }

        string machineName;
        public string MachineName
        {
            get => machineName;
            set => SetPropertyValue(nameof(MachineName), ref machineName, value);
        }

        string buildingNo;
        [Size(15)]
        public string BuildingNo
        {
            get => buildingNo;
            set => SetPropertyValue(nameof(BuildingNo), ref buildingNo, value);
        }

        string printerType;
        [Size(50)]
        public string PrinterType
        {
            get => printerType;
            set => SetPropertyValue(nameof(PrinterType), ref printerType, value);
        }

    }
}