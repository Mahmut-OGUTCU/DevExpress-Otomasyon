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
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.ObjectSaving += ObjectSpace_ObjectSaving;
            ObjectSpace.ObjectDeleting += ObjectSpace_ObjectDeleting;
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ObjectSpace.ObjectSaving -= ObjectSpace_ObjectSaving;
            ObjectSpace.ObjectDeleting -= ObjectSpace_ObjectDeleting;
        }
        private void ObjectSpace_ObjectDeleting(object sender, ObjectsManipulatingEventArgs e)
        {
            ObjectCount(false);
        }

        private void ObjectSpace_ObjectSaving(object sender, ObjectManipulatingEventArgs e)
        {
            ObjectCount(true);
        }

        private void ObjectCount(bool savingordeleting)
        {
            // Makine'ye kayıtlı fast productionların sayısına bakar, maks 4 adet girilebilir.
            if (View.CurrentObject is FastProductions fastProduction)
            {
                var machine = fastProduction.MachineID;
                if (machine != null)
                {
                    var machineFastProductions = machine.FastProduction;
                    if (machineFastProductions.Count() > 4 && savingordeleting)
                        throw new UserFriendlyException("Bir makineye 4 adetten fazla fast production ekleyemezsiniz.");
                    if (machineFastProductions.Count() != fastProduction.ProductionIndex && !savingordeleting)
                        throw new UserFriendlyException("En son ProductionIndex kaydını siliniz.");

                    fastProduction.ProductionIndex = machineFastProductions.Count();
                }
            }
            
        }

    }
}
