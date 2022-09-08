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
using CR_SFC.Module.EnumObjects;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraPrinting.Native;

namespace CR_SFC.Module.BusinessObjects
{
    [DefaultClassOptions]
    #region Appearance Product Type 0
    [Appearance("ShowOnProductType0", TargetItems = "EtorCheck, MqttTopicName, CycleTimeControl, ConnectCheck, Module, OperationTime, CycleTime, SlaveAddress, TransactionBatch, MachineWorkCondition, ConnectCheckAddTagID", Criteria = "ProductType = 0", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType0", TargetItems = "EtorCheck, MqttTopicName, CycleTimeControl, ConnectCheck, Module, OperationTime, CycleTime, SlaveAddress, TransactionBatch, MachineWorkCondition, ConnectCheckAddTagID", Criteria = "ProductType != 0", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    [Appearance("HideOffProductType0", TargetItems =
        "ProductionGain, ProductionSet, CurrentProductionAddressTagID, ProductionValueTagID",
        Criteria = "ProductType = 0", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    #region Appearance Product Type 1
    [Appearance("ShowOnProductType1", TargetItems = "StartValue, EndValue, ProductionAddressTagID", Criteria = "ProductType = 1", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType1", TargetItems = "StartValue, EndValue, ProductionAddressTagID", Criteria = "ProductType != 1", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    [Appearance("HideOffProductType1", TargetItems =
        "ProductionGain, ProductionSet, CurrentProductionAddressTagID, ProductionValueTagID",
        Criteria = "ProductType = 1", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    #region Appearance Product Type 2
    [Appearance("ShowOnProductType2", TargetItems =
    "Type2ProductionGroupNumber, Type2ProductionGroupNumberAddTagID, Type2FilterTime, Type2FilterAdressTagID, FastProduction",
    Criteria = "ProductType = 2", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType2", TargetItems =
    "Type2ProductionGroupNumber, Type2ProductionGroupNumberAddTagID, Type2FilterTime, Type2FilterAdressTagID, FastProduction",
    Criteria = "ProductType != 2", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    [Appearance("HideOffProductType2", TargetItems =
        "ProductionGain, ProductionSet, CurrentProductionAddressTagID, ProductionValueTagID",
        Criteria = "ProductType = 2", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    #region Appearance Product Type 3
    [Appearance("ShowOnProductType3", TargetItems =
        "ProductionValueTagID, CurrentDatasWriteControl, ProductionGain, ProductionSet, CurrentProductionAddressTagID, ProductionStartType, " +
        "SecondQualityProductionAddressTagID, ProductionStartAddressTagID, StartValueType4, StopValueType4, SavedCurrentDatas",
        Criteria = "ProductType = 3", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType3", TargetItems =
        "CurrentDatasWriteControl, ProductionStartType, SecondQualityProductionAddressTagID, ProductionStartAddressTagID, StartValueType4, StopValueType4, SavedCurrentDatas",
        Criteria = "ProductType != 3", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    #region Appearance Product Type 4
    [Appearance("ShowOnProductType4", TargetItems =
        "ProductionValueTagID, CurrentProductionAddressTagID, ProductionGain, ProductionSet, ActiveProductType5TagID, ResetAddQuality60sType5, " +
        "ResetAddCurrentValueType5, ResetAddQualityTotalValueType5, ResetAddRollFinishValueType5",
        Criteria = "ProductType = 4", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType4", TargetItems =
        "ActiveProductType5TagID, ResetAddQuality60sType5, ResetAddCurrentValueType5, ResetAddQualityTotalValueType5, ResetAddRollFinishValueType5",
        Criteria = "ProductType != 4", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    #region Appearance Product Type 5
    [Appearance("ShowOnProductType5", TargetItems =
        "CurrentMetersTagID, HexCMAdressControl, HexCMByteControl, TotalMetersTagID, HexTMAdressControl, HexTMByteControl, TotalFirstIndex, TotalSecondIndex, CurrentFirstIndex, CurrentSecondIndex",
        Criteria = "ProductType = 5", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType5", TargetItems =
        "CurrentMetersTagID, HexCMAdressControl, HexCMByteControl, TotalMetersTagID, HexTMAdressControl, HexTMByteControl, TotalFirstIndex, TotalSecondIndex, CurrentFirstIndex, CurrentSecondIndex",
        Criteria = "ProductType != 5", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    [Appearance("HideOffProductType5", TargetItems =
        "ProductionGain, ProductionSet, CurrentProductionAddressTagID, ProductionValueTagID",
        Criteria = "ProductType = 5", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    [Appearance("test1", TargetItems = "EtorCheck", Criteria = "ConnectionsDeviceName = 'MODBUS'", Context = "Any", Enabled = true)]
    [Appearance("test2", TargetItems = "EtorCheck", Criteria = "ConnectionsDeviceName != 'MODBUS'", Context = "Any", Enabled = false)]
    [Appearance("test3", TargetItems = "StartValue, EndValue", Criteria = "1=1", Context = "Any", Enabled = false)]
    public class Machines : XPBaseObject
    {
        public Machines(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        #region Giris
        int id;
        [Key(AutoGenerate = true), VisibleInDetailView(false)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
        }

        ProductionType productType;
        [ImmediatePostData, VisibleInListView(false), VisibleInLookupListView(false)]
        public ProductionType ProductType
        {
            get => productType;
            set => SetPropertyValue(nameof(StartValue), ref productType, value);
        }

        string _Name;
        [Size(20), XafDisplayName("Machine Name")]
        public string Name
        {
            get => _Name;
            set => SetPropertyValue(nameof(Name), ref _Name, value);
        }

        Connections _ConnectionID;
        [Association("Connections-Machines"), ImmediatePostData]
        public Connections ConnectionID
        {
            get => _ConnectionID;
            set => SetPropertyValue(nameof(ConnectionID), ref _ConnectionID, value);
        }
        #endregion

        #region NoProduction

            #region TagRelationships
            Tags _ConnectCheckAddTagID;
            [NonPersistent, XafDisplayName("Connect Address")]
            public Tags ConnectCheckAddTagID
            {
                get
                {
                    if (ConnectCheckAdd != null)
                    {
                        if (_ConnectCheckAddTagID == null)
                            return Session.Query<Tags>().FirstOrDefault(x => x.TagName == ConnectCheckAdd);
                    }
                    return _ConnectCheckAddTagID;
                }
                set
                {
                    SetPropertyValue(nameof(ConnectCheckAddTagID), ref _ConnectCheckAddTagID, value);
                    ConnectCheckAdd = ConnectCheckAddTagID.TagName;
                }
            }
            #endregion

        string mqttTopicName;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Topic Name")]
        public string MqttTopicName
        {
            get => mqttTopicName;
            set => SetPropertyValue(nameof(MqttTopicName), ref mqttTopicName, value);
        }

        int operationTime;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Operation Time")]
        public int OperationTime
        {
            get => operationTime;
            set => SetPropertyValue(nameof(OperationTime), ref operationTime, value);
        }

        string module;
        [Size(20), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Module")]
        public string Module
        {
            get => module;
            set => SetPropertyValue(nameof(Module), ref module, value);
        }

        int transactionBatch;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Transction Batch")]
        public int TransactionBatch
        {
            get => transactionBatch != 1 ? transactionBatch : 1;
            set => SetPropertyValue(nameof(TransactionBatch), ref transactionBatch, value);
        }

        string connectCheckAdd;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Connect Address"), VisibleInDetailView(false)]
        public string ConnectCheckAdd
        {
            get => connectCheckAdd;
            set => SetPropertyValue(nameof(ConnectCheckAdd), ref connectCheckAdd, value);
        }

        int cycleTime;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Cycle Time (s)")]
        public int CycleTime
        {
            get => cycleTime;
            set => SetPropertyValue(nameof(CycleTime), ref cycleTime, value);
        }

        int slaveAddress;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Slave Address")]
        public int SlaveAddress
        {
            get => slaveAddress != 1 ? slaveAddress : 1;
            set => SetPropertyValue(nameof(SlaveAddress), ref slaveAddress, value);
        }

        bool cycleTimeControl;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Cycle Time Control")]
        public bool CycleTimeControl
        {
            get => cycleTimeControl;
            set => SetPropertyValue(nameof(CycleTimeControl), ref cycleTimeControl, value);
        }

        bool machineWorkCondition;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Work Order Control")]
        public bool MachineWorkCondition
        {
            get => machineWorkCondition;
            set => SetPropertyValue(nameof(MachineWorkCondition), ref machineWorkCondition, value);
        }

        bool etorCheck; // ConnectionsDeviceName, MODBUS ise tıklanabilir olacak
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Gateway")]
        public bool EtorCheck
        {
            get => etorCheck;
            set => SetPropertyValue(nameof(EtorCheck), ref etorCheck, value);
        }

        bool connectCheck;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Machine Connect Control")]
        public bool ConnectCheck
        {
            get => connectCheck;
            set => SetPropertyValue(nameof(ConnectCheck), ref connectCheck, value);
        }
        #endregion

        #region TimeOfProduction

            #region TagRelationships
            Tags _ProductionAddressTagID;
            [NonPersistent, XafDisplayName("Production Add.")]
            public Tags ProductionAddressTagID
            {
                get
                {
                    if (ProductionAddress != null)
                    {
                        if (_ProductionAddressTagID == null)
                            return Session.Query<Tags>().FirstOrDefault(x => x.TagName == ProductionAddress);
                    }
                    return _ProductionAddressTagID;
                }
                set
                {
                    SetPropertyValue(nameof(ProductionAddressTagID), ref _ProductionAddressTagID, value);
                    ProductionAddress = ProductionAddressTagID.TagName;
                }
            }
            #endregion

        int startValue;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Start Value")]
        public int StartValue
        {
            get => 1;
            set => SetPropertyValue(nameof(StartValue), ref startValue, value);
        }

        int endValue;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("End Value")]
        public int EndValue
        {
            get => 2;
            set => SetPropertyValue(nameof(EndValue), ref endValue, value);
        }

        string productionAddress;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Production Add."), VisibleInDetailView(false)]
        public string ProductionAddress
        {
            get => productionAddress;
            set => SetPropertyValue(nameof(ProductionAddress), ref productionAddress, value);
        }
        #endregion

        #region NumberOfProduction

            #region TagRelationships
            Tags _Type2ProductionGroupNumberAddTagID;
            [NonPersistent, XafDisplayName("Group Number Add.")]
            public Tags Type2ProductionGroupNumberAddTagID
            {
                get
                {
                    if (Type2ProductionGroupNumberAdd != null)
                    {
                        if (_Type2ProductionGroupNumberAddTagID == null)
                            return Session.Query<Tags>().FirstOrDefault(x => x.TagName == Type2ProductionGroupNumberAdd);
                    }
                    return _Type2ProductionGroupNumberAddTagID;
                }
                set
                {
                    SetPropertyValue(nameof(Type2ProductionGroupNumberAddTagID), ref _Type2ProductionGroupNumberAddTagID, value);
                    Type2ProductionGroupNumberAdd = Type2ProductionGroupNumberAddTagID.TagName;
                }
            }

            Tags _Type2FilterAdressTagID;
            [NonPersistent, XafDisplayName("Filter Add.")]
            public Tags Type2FilterAdressTagID
            {
                get
                {
                    if (Type2FilterAdress != null)
                    {
                        if (_Type2FilterAdressTagID == null)
                            return Session.Query<Tags>().FirstOrDefault(x => x.TagName == Type2FilterAdress);
                    }
                    return _Type2FilterAdressTagID;
                }
                set
                {
                    SetPropertyValue(nameof(Type2FilterAdressTagID), ref _Type2FilterAdressTagID, value);
                    Type2FilterAdress = Type2FilterAdressTagID.TagName;
                }
            }
            #endregion

        [DevExpress.Xpo.Aggregated, Association("FastProductions-Machines")]
        public XPCollection<FastProductions> FastProduction
        {
            get { return GetCollection<FastProductions>(nameof(FastProduction)); }
        }

        string type2ProductionGroupNumberAdd;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Group Number Add."), VisibleInDetailView(false)]
        public string Type2ProductionGroupNumberAdd
        {
            get => type2ProductionGroupNumberAdd;
            set => SetPropertyValue(nameof(Type2ProductionGroupNumberAdd), ref type2ProductionGroupNumberAdd, value);
        }

        int type2ProductionGroupNumber;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Group Number Exp.")]
        public int Type2ProductionGroupNumber
        {
            get => type2ProductionGroupNumber;
            set => SetPropertyValue(nameof(Type2ProductionGroupNumber), ref type2ProductionGroupNumber, value);
        }

        string type2FilterAdress;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Filter Add."), VisibleInDetailView(false)]
        public string Type2FilterAdress
        {
            get => type2FilterAdress;
            set => SetPropertyValue(nameof(Type2FilterAdress), ref type2FilterAdress, value);
        }

        int _Type2FilterTime;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Filter Time")]
        public int Type2FilterTime
        {
            get => _Type2FilterTime;
            set => SetPropertyValue(nameof(Type2FilterTime), ref _Type2FilterTime, value);
        }
        #endregion

        #region MeterOfProduction

            #region TagRelationships
            Tags _CurrentProductionAddressTagID;
            [NonPersistent, XafDisplayName("Current Product. Add.")]
            public Tags CurrentProductionAddressTagID
            {
                get
                {
                    if (CurrentProductionAddress != null)
                    {
                        if (_CurrentProductionAddressTagID == null)
                            return Session.Query<Tags>().FirstOrDefault(x => x.TagName == CurrentProductionAddress);
                    }
                    return _CurrentProductionAddressTagID;
                }
                set
                {
                    SetPropertyValue(nameof(CurrentProductionAddressTagID), ref _CurrentProductionAddressTagID, value);
                    CurrentProductionAddress = CurrentProductionAddressTagID.TagName;
                }
            }

            Tags _ProductionValueTagID;
            [NonPersistent, XafDisplayName("Production Val. Add.")]
            public Tags ProductionValueTagID
            {
                get
                {
                    if (ProductionValue != null)
                    {
                        if (_ProductionValueTagID == null)
                            return Session.Query<Tags>().FirstOrDefault(x => x.TagName == ProductionValue);
                    }
                    return _ProductionValueTagID;
                }
                set
                {
                    SetPropertyValue(nameof(ProductionValueTagID), ref _ProductionValueTagID, value);
                    ProductionValue = ProductionValueTagID.TagName;
                }
            }

            Tags _SecondQualityProductionAddressTagID;
            [NonPersistent, XafDisplayName("2. Qu. Product. Add.")]
            public Tags SecondQualityProductionAddressTagID
            {
                get
                {
                    if (SecondQualityProductionAddress != null)
                    {
                        if (_SecondQualityProductionAddressTagID == null)
                            return Session.Query<Tags>().FirstOrDefault(x => x.TagName == SecondQualityProductionAddress);
                    }
                    return _SecondQualityProductionAddressTagID;
                }
                set
                {
                    SetPropertyValue(nameof(SecondQualityProductionAddressTagID), ref _SecondQualityProductionAddressTagID, value);
                    SecondQualityProductionAddress = SecondQualityProductionAddressTagID.TagName;
                }
            }

            Tags _ProductionStartAddressTagID;
            [NonPersistent, XafDisplayName("Product. Start Add.")]
            public Tags ProductionStartAddressTagID
            {
                get
                {
                    if (ProductionStartAddress != null)
                    {
                        if (_ProductionStartAddressTagID == null)
                            return Session.Query<Tags>().FirstOrDefault(x => x.TagName == ProductionStartAddress);
                    }
                    return _ProductionStartAddressTagID;
                }
                set
                {
                    SetPropertyValue(nameof(ProductionStartAddressTagID), ref _ProductionStartAddressTagID, value);
                    ProductionStartAddress = ProductionStartAddressTagID.TagName;
                }
            }
            #endregion

        int productionStartType;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Product. Start Type")]
        [ModelDefault("PredefinedValues", "1;2")]
        public int ProductionStartType
        {
            get => productionStartType;
            set => SetPropertyValue(nameof(ProductionStartType), ref productionStartType, value);
        }

        string currentProductionAddress;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Current Product. Add."), VisibleInDetailView(false)]
        public string CurrentProductionAddress
        {
            get => currentProductionAddress;
            set => SetPropertyValue(nameof(CurrentProductionAddress), ref currentProductionAddress, value);
        }

        string productionValue;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Production Val. Add."), VisibleInDetailView(false)]
        public string ProductionValue
        {
            get => productionValue;
            set => SetPropertyValue(nameof(ProductionValue), ref productionValue, value);
        }

        int startValueType4;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Start Value")]
        public int StartValueType4
        {
            get => startValueType4;
            set => SetPropertyValue(nameof(StartValueType4), ref startValueType4, value);
        }

        int stopValueType4;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Stop Value")]
        public int StopValueType4
        {
            get => stopValueType4;
            set => SetPropertyValue(nameof(StopValueType4), ref stopValueType4, value);
        }

        string productionGain;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Production Gain")]
        public string ProductionGain
        {
            get => productionGain;
            set => SetPropertyValue(nameof(ProductionGain), ref productionGain, value);
        }

        string productionSet;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Production Set")]
        public string ProductionSet
        {
            get => productionSet;
            set => SetPropertyValue(nameof(ProductionSet), ref productionSet, value);
        }

        int savedCurrentDatas;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Saved Current Datas")]
        public int SavedCurrentDatas
        {
            get => savedCurrentDatas;
            set => SetPropertyValue(nameof(SavedCurrentDatas), ref savedCurrentDatas, value);
        }

        bool currentDatasWriteControl;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Saved Current Datas Control")]
        public bool CurrentDatasWriteControl
        {
            get => currentDatasWriteControl;
            set => SetPropertyValue(nameof(CurrentDatasWriteControl), ref currentDatasWriteControl, value);
        }

        string secondQualityProductionAddress;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("2. Qu. Product. Add."), VisibleInDetailView(false)]
        public string SecondQualityProductionAddress
        {
            get => secondQualityProductionAddress;
            set => SetPropertyValue(nameof(SecondQualityProductionAddress), ref secondQualityProductionAddress, value);
        }

        string productionStartAddress;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Product. Start Add."), VisibleInDetailView(false)]
        public string ProductionStartAddress
        {
            get => productionStartAddress;
            set => SetPropertyValue(nameof(ProductionStartAddress), ref productionStartAddress, value);
        }
        #endregion

        #region TextileOfProduction

            #region TagRelationships
            Tags _ActiveProductType5TagID;
            [NonPersistent, XafDisplayName("Active Pro. Add.")]
            public Tags ActiveProductType5TagID
            {
                get
                {
                    if (ActiveProductType5 != null)
                    {
                        if (_ActiveProductType5TagID == null)
                            return Session.Query<Tags>().FirstOrDefault(x => x.TagName == ActiveProductType5);
                    }
                    return _ActiveProductType5TagID;
                }
                set
                {
                    SetPropertyValue(nameof(ActiveProductType5TagID), ref _ActiveProductType5TagID, value);
                    ActiveProductType5 = ActiveProductType5TagID.TagName;
                }
            }
            #endregion

        // Current Product. Add.
        // Production Val. Add.
        // Production Gain
        // Production Set MeterOfProduction'da

        string activeProductType5;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Active Pro. Add."), VisibleInDetailView(false)]
        public string ActiveProductType5
        {
            get => activeProductType5;
            set => SetPropertyValue(nameof(ActiveProductType5), ref activeProductType5, value);
        }

        string resetAddCurrentValueType5;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Reset Add. Current Value")]
        public string ResetAddCurrentValueType5
        {
            get => resetAddCurrentValueType5;
            set => SetPropertyValue(nameof(ResetAddCurrentValueType5), ref resetAddCurrentValueType5, value);
        }

        string resetAddQuality60sType5;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Reset Add. Quality 60s")]
        public string ResetAddQuality60sType5
        {
            get => resetAddQuality60sType5;
            set => SetPropertyValue(nameof(ResetAddQuality60sType5), ref resetAddQuality60sType5, value);
        }

        string resetAddQualityTotalValueType5;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Reset Add. Quality Total")]
        public string ResetAddQualityTotalValueType5
        {
            get => resetAddQualityTotalValueType5;
            set => SetPropertyValue(nameof(ResetAddQualityTotalValueType5), ref resetAddQualityTotalValueType5, value);
        }

        string resetAddRollFinishValueType5;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Reset Add. Roll Finish")]
        public string ResetAddRollFinishValueType5
        {
            get => resetAddRollFinishValueType5;
            set => SetPropertyValue(nameof(ResetAddRollFinishValueType5), ref resetAddRollFinishValueType5, value);
        }
        #endregion

        #region PrinterOfProduction

            #region TagRelationships
            Tags _CurrentMetersTagID;
            [NonPersistent, XafDisplayName("Current Meters")]
            public Tags CurrentMetersTagID
            {
                get
                {
                    if (CurrentMetersTag != null)
                    {
                        if (_CurrentMetersTagID == null)
                            return Session.Query<Tags>().FirstOrDefault(x => x.TagName == CurrentMetersTag);
                    }
                    return _CurrentMetersTagID;
                }
                set
                {
                    SetPropertyValue(nameof(CurrentMetersTagID), ref _CurrentMetersTagID, value);
                    CurrentMetersTag = CurrentMetersTagID.TagName;
                }
            }

            Tags _TotalMetersTagID;
            [NonPersistent, XafDisplayName("Total Meters")]
            public Tags TotalMetersTagID
            {
                get
                {
                    if (TotalMetersTag != null)
                    {
                        if (_TotalMetersTagID == null)
                            return Session.Query<Tags>().FirstOrDefault(x => x.TagName == TotalMetersTag);
                    }
                    return _TotalMetersTagID;
                }
                set
                {
                    SetPropertyValue(nameof(TotalMetersTagID), ref _TotalMetersTagID, value);
                    TotalMetersTag = TotalMetersTagID.TagName;
                }
            }
            #endregion


        string currentMetersTag;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Current Meters"), VisibleInDetailView(false)]
        public string CurrentMetersTag
        {
            get => currentMetersTag;
            set => SetPropertyValue(nameof(CurrentMetersTag), ref currentMetersTag, value);
        }

        string currentFirstIndex;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("C. First Index")]
        public string CurrentFirstIndex
        {
            get => currentFirstIndex;
            set => SetPropertyValue(nameof(CurrentFirstIndex), ref currentFirstIndex, value);
        }

        string currentSecondIndex;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("C. Second Index")]
        public string CurrentSecondIndex
        {
            get => currentSecondIndex;
            set => SetPropertyValue(nameof(CurrentSecondIndex), ref currentSecondIndex, value);
        }

        bool hexCMAdressControl;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("C. Hex")]
        public bool HexCMAdressControl
        {
            get => hexCMAdressControl;
            set => SetPropertyValue(nameof(HexCMAdressControl), ref hexCMAdressControl, value);
        }

        bool hexCMByteControl;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("C. Byte")]
        public bool HexCMByteControl
        {
            get => hexCMByteControl;
            set => SetPropertyValue(nameof(HexCMByteControl), ref hexCMByteControl, value);
        }

        string totalMetersTag;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("Total Meters"), VisibleInDetailView(false)]
        public string TotalMetersTag
        {
            get => totalMetersTag;
            set => SetPropertyValue(nameof(TotalMetersTag), ref totalMetersTag, value);
        }

        string totalFirstIndex;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("T. First Index")]
        public string TotalFirstIndex
        {
            get => totalFirstIndex;
            set => SetPropertyValue(nameof(TotalFirstIndex), ref totalFirstIndex, value);
        }

        string totalSecondIndex;
        [Size(50), VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("T. Second Index")]
        public string TotalSecondIndex
        {
            get => totalSecondIndex;
            set => SetPropertyValue(nameof(TotalSecondIndex), ref totalSecondIndex, value);
        }

        bool hexTMAdressControl;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("T. Hex")]
        public bool HexTMAdressControl
        {
            get => hexTMAdressControl;
            set => SetPropertyValue(nameof(HexTMAdressControl), ref hexTMAdressControl, value);
        }

        bool hexTMByteControl;
        [VisibleInListView(false), VisibleInLookupListView(false), XafDisplayName("T. Byte")]
        public bool HexTMByteControl
        {
            get => hexTMByteControl;
            set => SetPropertyValue(nameof(HexTMByteControl), ref hexTMByteControl, value);
        }
        #endregion

        string _ConnectionsDeviceName; // etorCheck için -> BODBUS ise etorcheck enable = true (NoProduction)
        [NonPersistent, VisibleInListView(false), VisibleInLookupListView(false)]
        private string ConnectionsDeviceName
        {
            get => ConnectionID?.DeviceName;
            set => _ConnectionsDeviceName = value;
        }

        [DevExpress.Xpo.Aggregated, Association("QualityCriterion-Machines")]
        public XPCollection<QualityCriterions> QualityCriterion
        {
            get { return GetCollection<QualityCriterions>(nameof(QualityCriterion)); }
        }

        [DevExpress.Xpo.Aggregated, Association("Warnings-Machines")]
        public XPCollection<Warnings> Warning
        {
            get { return GetCollection<Warnings>(nameof(Warning)); }
        }

        [DevExpress.Xpo.Aggregated, Association("Stance-Machines")]
        public XPCollection<Stances> Stance
        {
            get { return GetCollection<Stances>(nameof(Stance)); }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            ProductType = 0;
        }
    }
}