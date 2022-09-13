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
    public class QualityCriterions : XPBaseObject
    {
        public QualityCriterions(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int id;
        [Key(AutoGenerate = true), VisibleInListView(false), VisibleInDetailView(false)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
        }

        int criterionCycleTime;
        [XafDisplayName("Criterion Cycle Time"), VisibleInListView(false)]
        public int CriterionCycleTime
        {
            get => criterionCycleTime;
            set => SetPropertyValue(nameof(CriterionCycleTime), ref criterionCycleTime, value);
        }

        int qualityType;
        [XafDisplayName("Quality Type"), VisibleInListView(false)]
        public int QualityType
        {
            get => qualityType;
            set => SetPropertyValue(nameof(QualityType), ref qualityType, value);
        }

        double criterionGain;
        [XafDisplayName("Criterion Gain"), VisibleInListView(false)]
        public double CriterionGain
        {
            get => criterionGain;
            set => SetPropertyValue(nameof(CriterionGain), ref criterionGain, value);
        }

        double precisionValue;
        [XafDisplayName("Precision Value"), VisibleInListView(false)]
        public double PrecisionValue
        {
            get => precisionValue;
            set => SetPropertyValue(nameof(PrecisionValue), ref precisionValue, value);
        }

        double minValue;
        [XafDisplayName("Min Value"), VisibleInListView(false)]
        public double MinValue
        {
            get => minValue;
            set => SetPropertyValue(nameof(MinValue), ref minValue, value);
        }

        double maxValue;
        [XafDisplayName("Max Value"), VisibleInListView(false)]
        public double MaxValue
        {
            get => maxValue;
            set => SetPropertyValue(nameof(MaxValue), ref maxValue, value);
        }

        double destMinValue;
        [XafDisplayName("Dest Min Value"), VisibleInListView(false)]
        public double DestMinValue
        {
            get => destMinValue;
            set => SetPropertyValue(nameof(DestMinValue), ref destMinValue, value);
        }

        double destMaxValue;
        [XafDisplayName("Dest Max Value"), VisibleInListView(false)]
        public double DestMaxValue
        {
            get => destMaxValue;
            set => SetPropertyValue(nameof(DestMaxValue), ref destMaxValue, value);
        }

        double cycleDifferenceValue;
        [XafDisplayName("Cycle Difference Value"), VisibleInListView(false)]
        public double CycleDifferenceValue
        {
            get => cycleDifferenceValue;
            set => SetPropertyValue(nameof(CycleDifferenceValue), ref cycleDifferenceValue, value);
        }

        bool cycleWrite;
        [XafDisplayName("Cycle Write"), VisibleInListView(false)]
        public bool CycleWrite
        {
            get => cycleWrite;
            set => SetPropertyValue(nameof(CycleWrite), ref cycleWrite, value);
        }

        bool cycleDifference;
        [XafDisplayName("Cycle Difference"), VisibleInListView(false)]
        public bool CycleDifference
        {
            get => cycleDifference;
            set => SetPropertyValue(nameof(CycleDifference), ref cycleDifference, value);
        }

        string machineName;
        [Size(50), VisibleInDetailView(false), VisibleInListView(false)]
        public string MachineName
        {
            get => MachineID?.Name.ToString();
            set => SetPropertyValue(nameof(MachineName), ref machineName, value);
        }

        string criterionName;
        [Size(50), XafDisplayName("Criterion Name")]
        public string CriterionName
        {
            get => criterionName;
            set => SetPropertyValue(nameof(CriterionName), ref criterionName, value);
        }

        string criterionAddress;
        [Size(50), XafDisplayName("Criterion Address")]
        public string CriterionAddress
        {
            get => criterionAddress;
            set => SetPropertyValue(nameof(CriterionAddress), ref criterionAddress, value);
        }

        string conditionAddress;
        [Size(50), XafDisplayName("Condition Address")]
        public string ConditionAddress
        {
            get => conditionAddress;
            set => SetPropertyValue(nameof(ConditionAddress), ref conditionAddress, value);
        }

        string criterionType;
        [Size(50), XafDisplayName("Criterion Type")]
        public string CriterionType
        {
            get => criterionType;
            set => SetPropertyValue(nameof(CriterionType), ref criterionType, value);
        }

        Machines _Machines;
        [Association("QualityCriterion-Machines"), ImmediatePostData, XafDisplayName("Machine Name")]
        public Machines MachineID
        {
            get => _Machines;
            set => SetPropertyValue<Machines>(nameof(MachineID), ref _Machines, value);
        }
    }
}