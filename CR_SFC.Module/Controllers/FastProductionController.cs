using CR_SFC.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CR_SFC.Module.Controllers
{
    public partial class FastProductionController : ViewController
    {
        public FastProductionController()
        {
            InitializeComponent();
            TargetObjectType = typeof(FastProductions);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.ObjectSaving += ObjectSpace_ObjectSaving;
            ObjectSpace.ObjectDeleted += ObjectSpace_ObjectDeleted;
        }

        private void ObjectSpace_ObjectDeleted(object sender, ObjectsManipulatingEventArgs e)
        {
            if (View.CurrentObject is FastProductions fastProduction)
            {
                var machine = fastProduction.MachineID;
                var machineFastProductions = machine.FastProduction;
                var index = 1;
                foreach (var item in machineFastProductions)
                {
                    item.ProductionIndex = index;
                    index++;
                }
            }
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ObjectSpace.ObjectSaving -= ObjectSpace_ObjectSaving;
            ObjectSpace.ObjectDeleted -= ObjectSpace_ObjectDeleted;
        }

        private void ObjectSpace_ObjectSaving(object sender, ObjectManipulatingEventArgs e)
        {
            ObjectCount();

            if (View.CurrentObject is FastProductions fastProduction)
            {
                var machine = fastProduction.MachineID;
                var machineFastProductions = machine.FastProduction;
                foreach (var item1 in machineFastProductions)
                {
                    foreach (var item2 in machineFastProductions)
                    {
                        if ((item1.Address == item2.Address) && (item1.ProductionIndex != item2.ProductionIndex))
                        {
                            throw new UserFriendlyException("Aynı Tag Kaydedilemez.");
                        }
                    }
                }
            }
        }

        private void ObjectCount()
        {
            // Makine'ye kayıtlı fast productionların sayısına bakar, maks 4 adet girilebilir.
            if (View.CurrentObject is FastProductions fastProduction)
            {
                var machine = fastProduction.MachineID;
                if (machine != null)
                {
                    var machineFastProductions = machine.FastProduction;
                    if (machineFastProductions.Count() > 4)
                        throw new UserFriendlyException("Bir makineye 4 adetten fazla fast production ekleyemezsiniz.");

                    fastProduction.ProductionIndex = machineFastProductions.Count();
                }
            }

        }

    }
}
