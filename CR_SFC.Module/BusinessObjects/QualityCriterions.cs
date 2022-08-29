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
        [Key(AutoGenerate = true)]
        public int ID
        {
            get => id;
            set => SetPropertyValue(nameof(ID), ref id, value);
        }

        int criterionCycleTime;
        public int CriterionCycleTime
        {
            get => criterionCycleTime;
            set => SetPropertyValue(nameof(CriterionCycleTime), ref criterionCycleTime, value);
        }

        int qualityType;
        public int QualityType
        {
            get => qualityType;
            set => SetPropertyValue(nameof(QualityType), ref qualityType, value);
        }

        double criterionGain;
        public double CriterionGain
        {
            get => criterionGain;
            set => SetPropertyValue(nameof(CriterionGain), ref criterionGain, value);
        }

        double precisionValue;
        public double PrecisionValue
        {
            get => precisionValue;
            set => SetPropertyValue(nameof(PrecisionValue), ref precisionValue, value);
        }

        double minValue;
        public double MinValue
        {
            get => minValue;
            set => SetPropertyValue(nameof(MinValue), ref minValue, value);
        }

        double maxValue;
        public double MaxValue
        {
            get => maxValue;
            set => SetPropertyValue(nameof(MaxValue), ref maxValue, value);
        }

        double destMinValue;
        public double DestMinValue
        {
            get => destMinValue;
            set => SetPropertyValue(nameof(DestMinValue), ref destMinValue, value);
        }

        double destMaxValue;
        public double DestMaxValue
        {
            get => destMaxValue;
            set => SetPropertyValue(nameof(DestMaxValue), ref destMaxValue, value);
        }

        double cycleDifferenceValue;
        public double CycleDifferenceValue
        {
            get => cycleDifferenceValue;
            set => SetPropertyValue(nameof(CycleDifferenceValue), ref cycleDifferenceValue, value);
        }

        bool cycleWrite;
        public bool CycleWrite
        {
            get => cycleWrite;
            set => SetPropertyValue(nameof(CycleWrite), ref cycleWrite, value);
        }

        bool cycleDifference;
        public bool CycleDifference
        {
            get => cycleDifference;
            set => SetPropertyValue(nameof(CycleDifference), ref cycleDifference, value);
        }

        string machineName;
        [Size(50), VisibleInDetailView(false)]
        public string MachineName
        {
            get => MachineID.Name;
            set => SetPropertyValue(nameof(MachineName), ref machineName, value);
        }

        string criterionName;
        [Size(50)]
        public string CriterionName
        {
            get => criterionName;
            set => SetPropertyValue(nameof(CriterionName), ref criterionName, value);
        }

        string criterionAddress;
        [Size(50)]
        public string CriterionAddress
        {
            get => criterionAddress;
            set => SetPropertyValue(nameof(CriterionAddress), ref criterionAddress, value);
        }

        string conditionAddress;
        [Size(50)]
        public string ConditionAddress
        {
            get => conditionAddress;
            set => SetPropertyValue(nameof(ConditionAddress), ref conditionAddress, value);
        }

        string criterionType;
        [Size(50)]
        public string CriterionType
        {
            get => criterionType;
            set => SetPropertyValue(nameof(CriterionType), ref criterionType, value);
        }

        Machines _Machines;
        [Association("QualityCriterion-Machines"), ImmediatePostData]
        public Machines MachineID
        {
            get => _Machines;
            set => SetPropertyValue<Machines>(nameof(MachineID), ref _Machines, value);
        }

    }
}