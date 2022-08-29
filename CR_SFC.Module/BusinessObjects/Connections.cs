﻿using DevExpress.Data.Filtering;
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
    public class Connections : XPBaseObject
    {
        public Connections(Session session) : base(session)
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

        int machineNumber;
        public int MachineNumber
        {
            get => machineNumber;
            set => SetPropertyValue(nameof(MachineNumber), ref machineNumber, value);
        }

        int inputNumber;
        public int InputNumber
        {
            get => inputNumber;
            set => SetPropertyValue(nameof(InputNumber), ref inputNumber, value);
        }

        int threadSleepTime;
        [RuleRequiredField("threadSleepTime-Required", DefaultContexts.Save, "Lütfen Thread Sleep Time Alanını Doldurunuz")]
        public int ThreadSleepTime
        {
            get => threadSleepTime;
            set => SetPropertyValue(nameof(ThreadSleepTime), ref threadSleepTime, value);
        }

        int rack;
        public int Rack
        {
            get => rack;
            set => SetPropertyValue(nameof(Rack), ref rack, value);
        }

        int slot;
        public int Slot
        {
            get => slot;
            set => SetPropertyValue(nameof(Slot), ref slot, value);
        }

        // NOTE: DB'de yok
        ProductNames _ProductOID;
        [XafDisplayName("Product Name")]
        public ProductNames ProductOID
        {
            get => _ProductOID;
            set => SetPropertyValue(nameof(ProductOID), ref _ProductOID, value);
        }

        string productName;
        [Size(50), VisibleInDetailView(false)]
        public string ProductName
        {
            get => productName;
            set => SetPropertyValue(nameof(ProductName), ref productName, value);
        }

        string productCode;
        [Size(50)]
        public string ProductCode
        {
            get => productCode;
            set => SetPropertyValue(nameof(ProductCode), ref productCode, value);
        }

        string ipAddress;
        [Size(15)]
        [RuleRequiredField("ipAddress-Required", DefaultContexts.Save, "Lütfen Ip Address Alanını Doldurunuz")]
        public string IpAddress
        {
            get => ipAddress;
            set => SetPropertyValue(nameof(IpAddress), ref ipAddress, value);
        }

        string terminalType;
        [Size(50)]
        public string TerminalType
        {
            get => terminalType;
            set => SetPropertyValue(nameof(TerminalType), ref terminalType, value);
        }

        string communicationAddress;
        [Size(20)]
        public string CommunicationAddress
        {
            get => communicationAddress;
            set => SetPropertyValue(nameof(CommunicationAddress), ref communicationAddress, value);
        }

        string deviceName;
        [Size(50)]
        public string DeviceName
        {
            get => deviceName;
            set => SetPropertyValue(nameof(DeviceName), ref deviceName, value);
        }

        string pLCType;
        [Size(50)]
        public string PLCType
        {
            get => pLCType;
            set => SetPropertyValue(nameof(PLCType), ref pLCType, value);
        }

        string topic;
        [Size(70)]
        public string Topic
        {
            get => topic;
            set => SetPropertyValue(nameof(Topic), ref topic, value);
        }

        string port;
        [Size(10)]
        public string Port
        {
            get => port;
            set => SetPropertyValue(nameof(Port), ref port, value);
        }

        DateTime serviceCheck;
        public DateTime ServiceCheck
        {
            get => serviceCheck;
            set => SetPropertyValue(nameof(ServiceCheck), ref serviceCheck, value);
        }

        [Association("Connections-Machines")]
        public XPCollection<Machines> Machines
        {
            get { return GetCollection<Machines>(nameof(Machines)); }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (ProductOID != null)
                productName = ProductOID.ProductName;

        }
    }
}