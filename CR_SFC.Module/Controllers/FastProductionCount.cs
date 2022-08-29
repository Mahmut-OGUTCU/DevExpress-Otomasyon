﻿using CR_SFC.Module.BusinessObjects;
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
    public partial class FastProductionCount : ViewController
    {
        public FastProductionCount()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.ObjectSaving += ObjectSpace_ObjectSaving;
        }

        private void ObjectSpace_ObjectSaving(object sender, ObjectManipulatingEventArgs e)
        {
            // Makine'ye kayıtlı fast productionların sayısına bakar, maks 4 adet girilebilir.
            if (View.CurrentObject is FastProductions fastProduction)
            {
                var machine = fastProduction.MachineID;
                var machineFastProductions = machine.FastProduction;
                if (machineFastProductions.Count() > 4)
                    throw new UserFriendlyException("Bir makineye 4 adetten fazla fast production ekleyemezsiniz.");
            }
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ObjectSpace.ObjectSaving -= ObjectSpace_ObjectSaving;
        }
    }
}
