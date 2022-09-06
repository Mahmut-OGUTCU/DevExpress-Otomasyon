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
    [Appearance("ShowOnProductType0", TargetItems = "EtorCheck, MqttTopicName, CycleTimeControl, ConnectCheck, Module, OperationTime, CycleTime, SlaveAddress, TransactionBatch, MachineWorkCondition, ConnectCheckAddID", Criteria = "ProductType = 0", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType0", TargetItems = "EtorCheck, MqttTopicName, CycleTimeControl, ConnectCheck, Module, OperationTime, CycleTime, SlaveAddress, TransactionBatch, MachineWorkCondition, ConnectCheckAddID", Criteria = "ProductType != 0", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    [Appearance("HideOffProductType0", TargetItems =
        "ProductionGain, ProductionSet, CurrentProductionAddress, ProductionValue",
        Criteria = "ProductType = 0", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    #region Appearance Product Type 1
    [Appearance("ShowOnProductType1", TargetItems = "StartValue, EndValue, ProductionAddress", Criteria = "ProductType = 1", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType1", TargetItems = "StartValue, EndValue, ProductionAddress", Criteria = "ProductType != 1", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    [Appearance("HideOffProductType1", TargetItems =
        "ProductionGain, ProductionSet, CurrentProductionAddress, ProductionValue",
        Criteria = "ProductType = 1", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    #region Appearance Product Type 2
    [Appearance("ShowOnProductType2", TargetItems =
    "Type2ProductionGroupNumber, Type2ProductionGroupNumberAdd, Type2FilterTime, Type2FilterAdress, FastProduction",
    Criteria = "ProductType = 2", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType2", TargetItems =
    "Type2ProductionGroupNumber, Type2ProductionGroupNumberAdd, Type2FilterTime, Type2FilterAdress, FastProduction",
    Criteria = "ProductType != 2", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    [Appearance("HideOffProductType2", TargetItems =
        "ProductionGain, ProductionSet, CurrentProductionAddress, ProductionValue",
        Criteria = "ProductType = 2", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    #region Appearance Product Type 3
    [Appearance("ShowOnProductType3", TargetItems =
        "ProductionValue, CurrentDatasWriteControl, ProductionGain, ProductionSet, CurrentProductionAddress, ProductionStartType, " +
        "SecondQualityProductionAddress, ProductionStartAddress, StartValueType4, StopValueType4, SavedCurrentDatas",
        Criteria = "ProductType = 3", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType3", TargetItems =
        "CurrentDatasWriteControl, ProductionStartType, SecondQualityProductionAddress, ProductionStartAddress, StartValueType4, StopValueType4, SavedCurrentDatas",
        Criteria = "ProductType != 3", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    #region Appearance Product Type 4
    [Appearance("ShowOnProductType4", TargetItems =
        "ProductionValue, CurrentProductionAddress, ProductionGain, ProductionSet, ActiveProductType5, ResetAddQuality60sType5, " +
        "ResetAddCurrentValueType5, ResetAddQualityTotalValueType5, ResetAddRollFinishValueType5",
        Criteria = "ProductType = 4", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType4", TargetItems =
        "ActiveProductType5, ResetAddQuality60sType5, ResetAddCurrentValueType5, ResetAddQualityTotalValueType5, ResetAddRollFinishValueType5",
        Criteria = "ProductType != 4", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    #region Appearance Product Type 5
    [Appearance("ShowOnProductType5", TargetItems =
        "CurrentMetersTag, HexCMAdressControl, HexCMByteControl, TotalMetersTag, HexTMAdressControl, HexTMByteControl, ProductionSet, TotalFirstIndex, TotalSecondIndex, CurrentFirstIndex, CurrentSecondIndex",
        Criteria = "ProductType = 5", Context = "Any", Visibility = ViewItemVisibility.Show)]
    [Appearance("HideOnProductType5", TargetItems =
        "CurrentMetersTag, HexCMAdressControl, HexCMByteControl, TotalMetersTag, HexTMAdressControl, HexTMByteControl, TotalFirstIndex, TotalSecondIndex, CurrentFirstIndex, CurrentSecondIndex",
        Criteria = "ProductType != 5", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    [Appearance("HideOffProductType5", TargetItems =
        "ProductionGain, CurrentProductionAddress, ProductionValue",
        Criteria = "ProductType = 5", Context = "Any", Visibility = ViewItemVisibility.Hide)]
    #endregion
    [Appearance("test1", TargetItems = "EtorCheck", Criteria = "ConnectionsDeviceName = 'MODBUS'", Context = "Any", Enabled = true)]
    [Appearance("test2", TargetItems = "EtorCheck", Criteria = "ConnectionsDeviceName != 'MODBUS'", Context = "Any", Enabled = false)]
    public class Machines : XPBaseObject
    {
        public Machines(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int id;
        [Key(AutoGenerate = true), VisibleInDetailView(false)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
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

        int productionStartType;
        [VisibleInListView(false), XafDisplayName("Product. Start Type")]
        [ModelDefault("PredefinedValues", "1;2")]
        public int ProductionStartType
        {
            get => productionStartType;
            set => SetPropertyValue(nameof(ProductionStartType), ref productionStartType, value);
        }

        int savedCurrentDatas;
        [VisibleInListView(false)]
        public int SavedCurrentDatas
        {
            get => savedCurrentDatas;
            set => SetPropertyValue(nameof(SavedCurrentDatas), ref savedCurrentDatas, value);
        }

        int startValueType4;
        [VisibleInListView(false)]
        public int StartValueType4
        {
            get => startValueType4;
            set => SetPropertyValue(nameof(StartValueType4), ref startValueType4, value);
        }

        int stopValueType4;
        [VisibleInListView(false)]
        public int StopValueType4
        {
            get => stopValueType4;
            set => SetPropertyValue(nameof(StopValueType4), ref stopValueType4, value);
        }

        int cycleTime;
        [VisibleInListView(false), XafDisplayName("Cycle Time (s)")]
        public int CycleTime
        {
            get => cycleTime;
            set => SetPropertyValue(nameof(CycleTime), ref cycleTime, value);
        }

        ProductionType productType;
        [ImmediatePostData, VisibleInListView(false)]
        public ProductionType ProductType
        {
            get => productType;
            set => SetPropertyValue(nameof(StartValue), ref productType, value);
        }

        int startValue;
        [VisibleInListView(false)]
        public int StartValue
        {
            get => startValue;
            set => SetPropertyValue(nameof(StartValue), ref startValue, value);
        }

        int endValue;
        [VisibleInListView(false)]
        public int EndValue
        {
            get => endValue;
            set => SetPropertyValue(nameof(EndValue), ref endValue, value);
        }

        int slaveAddress;
        [VisibleInListView(false)]
        public int SlaveAddress
        {
            get => slaveAddress;
            set => SetPropertyValue(nameof(SlaveAddress), ref slaveAddress, value);
        }

        int transactionBatch;
        [VisibleInListView(false)]
        public int TransactionBatch
        {
            get => transactionBatch;
            set => SetPropertyValue(nameof(TransactionBatch), ref transactionBatch, value);
        }

        int type2ProductionGroupNumber;
        [VisibleInListView(false), XafDisplayName("Group Number Exp.")]
        public int Type2ProductionGroupNumber
        {
            get => type2ProductionGroupNumber;
            set => SetPropertyValue(nameof(Type2ProductionGroupNumber), ref type2ProductionGroupNumber, value);
        }

        int type2FilterTime;
        [VisibleInListView(false), XafDisplayName("Filter Time")]
        public int Type2FilterTime
        {
            get => type2FilterTime;
            set => SetPropertyValue(nameof(Type2FilterTime), ref type2FilterTime, value);
        }

        int operationTime;
        [VisibleInListView(false), XafDisplayName("Operation Time")]
        public int OperationTime
        {
            get => operationTime;
            set => SetPropertyValue(nameof(OperationTime), ref operationTime, value);
        }

        bool currentDatasWriteControl;
        [VisibleInListView(false), XafDisplayName("SavedCurrentDatasControl")]
        public bool CurrentDatasWriteControl
        {
            get => currentDatasWriteControl;
            set => SetPropertyValue(nameof(CurrentDatasWriteControl), ref currentDatasWriteControl, value);
        }

        bool cycleTimeControl;
        [VisibleInListView(false), XafDisplayName("Cycle Time Control")]
        public bool CycleTimeControl
        {
            get => cycleTimeControl;
            set => SetPropertyValue(nameof(CycleTimeControl), ref cycleTimeControl, value);
        }

        bool machineWorkCondition;
        [VisibleInListView(false)]
        public bool MachineWorkCondition
        {
            get => machineWorkCondition;
            set => SetPropertyValue(nameof(MachineWorkCondition), ref machineWorkCondition, value);
        }

        string _ConnectionsDeviceName;
        [NonPersistent, VisibleInListView(false)]
        private string ConnectionsDeviceName
        {
            get => ConnectionID?.DeviceName;
            set => _ConnectionsDeviceName = value;
        }

        bool etorCheck; // ConnectionsDeviceName, MODBUS ise tıklanabilir olacak
        [VisibleInListView(false), XafDisplayName("Gateway")]
        public bool EtorCheck
        {
            get => etorCheck;
            set => SetPropertyValue(nameof(EtorCheck), ref etorCheck, value);
        }

        bool hexCMAdressControl;
        [VisibleInListView(false)]
        public bool HexCMAdressControl
        {
            get => hexCMAdressControl;
            set => SetPropertyValue(nameof(HexCMAdressControl), ref hexCMAdressControl, value);
        }

        bool hexTMAdressControl;
        [VisibleInListView(false)]
        public bool HexTMAdressControl
        {
            get => hexTMAdressControl;
            set => SetPropertyValue(nameof(HexTMAdressControl), ref hexTMAdressControl, value);
        }

        bool hexCMByteControl;
        [VisibleInListView(false)]
        public bool HexCMByteControl
        {
            get => hexCMByteControl;
            set => SetPropertyValue(nameof(HexCMByteControl), ref hexCMByteControl, value);
        }

        bool hexTMByteControl;
        [VisibleInListView(false)]
        public bool HexTMByteControl
        {
            get => hexTMByteControl;
            set => SetPropertyValue(nameof(HexTMByteControl), ref hexTMByteControl, value);
        }

        bool connectCheck;
        [VisibleInListView(false), XafDisplayName("Machine Connect Control")]
        public bool ConnectCheck
        {
            get => connectCheck;
            set => SetPropertyValue(nameof(ConnectCheck), ref connectCheck, value);
        }

        string module;
        [Size(20), VisibleInListView(false)]
        public string Module
        {
            get => module;
            set => SetPropertyValue(nameof(Module), ref module, value);
        }

        string productionAddress;
        [Size(50), VisibleInListView(false), XafDisplayName("Production Add.")]
        public string ProductionAddress
        {
            get => productionAddress;
            set => SetPropertyValue(nameof(ProductionAddress), ref productionAddress, value);
        }

        string productionValue;
        [Size(50), VisibleInListView(false), XafDisplayName("Production Val. Add.")]
        public string ProductionValue
        {
            get => productionValue;
            set => SetPropertyValue(nameof(ProductionValue), ref productionValue, value);
        }

        string currentProductionAddress;
        [Size(50), VisibleInListView(false), XafDisplayName("Current Production Add.")]
        public string CurrentProductionAddress
        {
            get => currentProductionAddress;
            set => SetPropertyValue(nameof(CurrentProductionAddress), ref currentProductionAddress, value);
        }

        string productionSet;
        [Size(50), VisibleInListView(false)]
        public string ProductionSet
        {
            get => productionSet;
            set => SetPropertyValue(nameof(ProductionSet), ref productionSet, value);
        }

        string productionGain;
        [Size(50), VisibleInListView(false)]
        public string ProductionGain
        {
            get => productionGain;
            set => SetPropertyValue(nameof(ProductionGain), ref productionGain, value);
        }

        string secondQualityProductionAddress;
        [Size(50), VisibleInListView(false), XafDisplayName("2. Qu. Product. Add.")]
        public string SecondQualityProductionAddress
        {
            get => secondQualityProductionAddress;
            set => SetPropertyValue(nameof(SecondQualityProductionAddress), ref secondQualityProductionAddress, value);
        }

        string productionStartAddress;
        [Size(50), VisibleInListView(false), XafDisplayName("Product. Start. Add.")]
        public string ProductionStartAddress
        {
            get => productionStartAddress;
            set => SetPropertyValue(nameof(ProductionStartAddress), ref productionStartAddress, value);
        }

        string activeProductType5;
        [Size(50), VisibleInListView(false), XafDisplayName("Active Pro. Add.")]
        public string ActiveProductType5
        {
            get => activeProductType5;
            set => SetPropertyValue(nameof(ActiveProductType5), ref activeProductType5, value);
        }

        string resetAddQuality60sType5;
        [Size(50), VisibleInListView(false), XafDisplayName("Reset Add. Quality 60s")]
        public string ResetAddQuality60sType5
        {
            get => resetAddQuality60sType5;
            set => SetPropertyValue(nameof(ResetAddQuality60sType5), ref resetAddQuality60sType5, value);
        }

        string resetAddCurrentValueType5;
        [Size(50), VisibleInListView(false), XafDisplayName("Reset Add. Current Value")]
        public string ResetAddCurrentValueType5
        {
            get => resetAddCurrentValueType5;
            set => SetPropertyValue(nameof(ResetAddCurrentValueType5), ref resetAddCurrentValueType5, value);
        }

        string resetAddQualityTotalValueType5;
        [Size(50), VisibleInListView(false), XafDisplayName("Reset Add. Quality Total")]
        public string ResetAddQualityTotalValueType5
        {
            get => resetAddQualityTotalValueType5;
            set => SetPropertyValue(nameof(ResetAddQualityTotalValueType5), ref resetAddQualityTotalValueType5, value);
        }

        string resetAddRollFinishValueType5;
        [Size(50), VisibleInListView(false), XafDisplayName("Reset Add. Roll Finish")]
        public string ResetAddRollFinishValueType5
        {
            get => resetAddRollFinishValueType5;
            set => SetPropertyValue(nameof(ResetAddRollFinishValueType5), ref resetAddRollFinishValueType5, value);
        }

        string currentMetersTag;
        [Size(50), VisibleInListView(false)]
        public string CurrentMetersTag
        {
            get => currentMetersTag;
            set => SetPropertyValue(nameof(CurrentMetersTag), ref currentMetersTag, value);
        }

        string totalMetersTag;
        [Size(50), VisibleInListView(false)]
        public string TotalMetersTag
        {
            get => totalMetersTag;
            set => SetPropertyValue(nameof(TotalMetersTag), ref totalMetersTag, value);
        }

        string currentFirstIndex;
        [Size(50), VisibleInListView(false)]
        public string CurrentFirstIndex
        {
            get => currentFirstIndex;
            set => SetPropertyValue(nameof(CurrentFirstIndex), ref currentFirstIndex, value);
        }

        string currentSecondIndex;
        [Size(50), VisibleInListView(false)]
        public string CurrentSecondIndex
        {
            get => currentSecondIndex;
            set => SetPropertyValue(nameof(CurrentSecondIndex), ref currentSecondIndex, value);
        }

        string totalFirstIndex;
        [Size(50), VisibleInListView(false)]
        public string TotalFirstIndex
        {
            get => totalFirstIndex;
            set => SetPropertyValue(nameof(TotalFirstIndex), ref totalFirstIndex, value);
        }

        string totalSecondIndex;
        [Size(50), VisibleInListView(false)]
        public string TotalSecondIndex
        {
            get => totalSecondIndex;
            set => SetPropertyValue(nameof(TotalSecondIndex), ref totalSecondIndex, value);
        }

        Tags _ConnectCheckAddID;
        [Size(50), VisibleInListView(false), XafDisplayName("Connect Address")]
        public Tags ConnectCheckAddID
        {
            get => _ConnectCheckAddID;
            set => SetPropertyValue(nameof(ConnectCheckAddID), ref _ConnectCheckAddID, value);
        }

        string connectCheckAdd;
        [Size(50), VisibleInListView(false), VisibleInDetailView(false)]
        public string ConnectCheckAdd
        {
            get => connectCheckAdd;
            set => SetPropertyValue(nameof(ConnectCheckAdd), ref connectCheckAdd, value);
        }

        string mqttTopicName;
        [Size(50), VisibleInListView(false), XafDisplayName("Topic Name")]
        public string MqttTopicName
        {
            get => mqttTopicName;
            set => SetPropertyValue(nameof(MqttTopicName), ref mqttTopicName, value);
        }

        string type2ProductionGroupNumberAdd;
        [Size(50), VisibleInListView(false), XafDisplayName("Group Number Add.")]
        public string Type2ProductionGroupNumberAdd
        {
            get => type2ProductionGroupNumberAdd;
            set => SetPropertyValue(nameof(Type2ProductionGroupNumberAdd), ref type2ProductionGroupNumberAdd, value);
        }

        string type2FilterAdress;
        [Size(50), VisibleInListView(false), XafDisplayName("Filter Address")]
        public string Type2FilterAdress
        {
            get => type2FilterAdress;
            set => SetPropertyValue(nameof(Type2FilterAdress), ref type2FilterAdress, value);
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

        [DevExpress.Xpo.Aggregated, Association("FastProductions-Machines")]
        public XPCollection<FastProductions> FastProduction
        {
            get { return GetCollection<FastProductions>(nameof(FastProduction)); }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            ProductType = 0;
        }
    }
}