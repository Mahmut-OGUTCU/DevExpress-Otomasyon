﻿using CR_SFC.Module.BusinessObjects;
using CR_SFC.Module.EnumObjects;
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
    public partial class MachineController : ViewController <DetailView>
    {

        public MachineController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Machines);
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ObjectSpace.ObjectChanged -= ObjectSpace_ObjectChanged;
        }

        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {

            if ((e.PropertyName == "ConnectionID" && ((Connections)e.NewValue)?.DeviceName != "MODBUS") && ((Machines)View.CurrentObject).EtorCheck)
                ((Machines)View.CurrentObject).EtorCheck = false;
        }
    }
}
    