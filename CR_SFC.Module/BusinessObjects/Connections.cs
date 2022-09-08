﻿using CR_SFC.Module.EnumObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
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
    [Appearance("DeviceNameEnable", TargetItems = "DeviceName", Enabled = false)]
    [Appearance("PLCTypeEnable", TargetItems = "PLCTypeID", Criteria = "DeviceName != 'SIEMENS'",  Enabled = false)]
    [Appearance("FillPLCType", TargetItems = "PLCTypeID", Criteria = "DeviceName = 'SIEMENS'", Context = "Any", Enabled = true)]
    public class Connections : XPBaseObject
    {
        public Connections(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        #region ProductNameRelationships
        ProductNames _ProductNameProductNameID;
        [NonPersistent, ImmediatePostData, XafDisplayName("Product Name")]
        public ProductNames ProductNameProductNameID
        {
            get
            {
                if (_ProductNameProductNameID == null)
                    return Session.Query<ProductNames>().FirstOrDefault(x => x.ProductName == ProductName);
                return _ProductNameProductNameID;
            }
            set
            {
                SetPropertyValue(nameof(ProductNameProductNameID), ref _ProductNameProductNameID, value);
                ProductName = ProductNameProductNameID.ProductName;
            }
        }
        #endregion

        int id;
        [Key(AutoGenerate = true), VisibleInDetailView(false), VisibleInListView(false)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
        }

        int machineNumber;
        [XafDisplayName("Machine Number"), VisibleInListView(false)]
        public int MachineNumber
        {
            get => machineNumber;
            set => SetPropertyValue(nameof(MachineNumber), ref machineNumber, value);
        }

        int inputNumber;
        [XafDisplayName("Input Number"), VisibleInListView(false)]
        public int InputNumber
        {
            get => inputNumber;
            set => SetPropertyValue(nameof(InputNumber), ref inputNumber, value);
        }

        int threadSleepTime;
        [RuleRequiredField("threadSleepTime-Required", DefaultContexts.Save, "Lütfen Thread Sleep Time Alanını Doldurunuz"), 
            XafDisplayName("Thread Sleep Time (ms)"), VisibleInListView(false)]
        public int ThreadSleepTime
        {
            get => threadSleepTime;
            set => SetPropertyValue(nameof(ThreadSleepTime), ref threadSleepTime, value);
        }

        int rack;
        [VisibleInListView(false)]
        public int Rack
        {
            get => rack;
            set => SetPropertyValue(nameof(Rack), ref rack, value);
        }

        int slot;
        [VisibleInListView(false)]
        public int Slot
        {
            get => slot;
            set => SetPropertyValue(nameof(Slot), ref slot, value);
        }

        string productName;
        [Size(50), VisibleInListView(false), VisibleInDetailView(false)]
        public string ProductName
        {
            get => productName;
            set => SetPropertyValue(nameof(ProductName), ref productName, value);
        }

        string productCode;
        [Size(50), VisibleInListView(false)]
        public string ProductCode
        {
            get => productCode;
            set => SetPropertyValue(nameof(ProductCode), ref productCode, value);
        }

        string ipAddress;
        [Size(15), VisibleInListView(false)]
        [RuleRequiredField("ipAddress-Required", DefaultContexts.Save, "Lütfen Ip Address Alanını Doldurunuz")]
        public string IpAddress
        {
            get => ipAddress;
            set => SetPropertyValue(nameof(IpAddress), ref ipAddress, value);
        }

        string terminalType;
        [Size(50), VisibleInListView(false)]
        [ModelDefault("PredefinedValues", "0;1")]
        public string TerminalType
        {
            get => terminalType;
            set => SetPropertyValue(nameof(TerminalType), ref terminalType, value);
        }

        string communicationAddress;
        [Size(20), VisibleInListView(false)]
        public string CommunicationAddress
        {
            get => communicationAddress;
            set => SetPropertyValue(nameof(CommunicationAddress), ref communicationAddress, value);
        }

        string deviceName; //ProductNameProductNameID.ProtocolName
        [Size(50), VisibleInListView(false)]
        public string DeviceName
        {
            get => deviceName;
            set => SetPropertyValue(nameof(DeviceName), ref deviceName, value);
        }

        string _PLCType;
        [Size(50), VisibleInListView(false), VisibleInDetailView(false), ImmediatePostData, XafDisplayName("PLC Type")]
        public string PLCType
        {
            get => _PLCType;
            set => SetPropertyValue(nameof(PLCType), ref _PLCType, value);
        }

        PLCType _PLCTypeID;
        [NonPersistent, ImmediatePostData, XafDisplayName("PLC Type"), VisibleInListView(false)]
        public PLCType PLCTypeID
        {
            get
            {
                if (_PLCTypeID.ToString() == "Seçiniz")
                {
                    foreach (var item in Enum.GetValues(typeof(PLCType)))
                    {
                        if (item.ToString() == PLCType)
                        {
                            return (PLCType)item;
                        }
                    }
                }
                return _PLCTypeID;
            }
            set
            {
                SetPropertyValue(nameof(PLCTypeID), ref _PLCTypeID, value);
                PLCType = PLCTypeID.ToString();
            }
        }

        string topic;
        [Size(70), VisibleInListView(false)]
        public string Topic
        {
            get => topic;
            set => SetPropertyValue(nameof(Topic), ref topic, value);
        }

        string port;
        [Size(10), VisibleInListView(false)]
        public string Port
        {
            get => port;
            set => SetPropertyValue(nameof(Port), ref port, value);
        }

        DateTime serviceCheck;
        [VisibleInListView(false)]
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
    }
}