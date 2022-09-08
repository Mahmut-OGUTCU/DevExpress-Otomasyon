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
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CR_SFC.Module.Controllers
{
    public partial class ConnectionController : ViewController <DetailView>
    {
        public ConnectionController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Connections);
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

            if (e.PropertyName == "ProductNameProductNameID" && e.NewValue != null)
                ((Connections)View.CurrentObject).DeviceName = ((Connections)View.CurrentObject).ProductNameProductNameID.ProtocolName;

            //
            if (((Connections)View.CurrentObject).DeviceName?.ToString() != "SIEMENS")
                ((Connections)View.CurrentObject).PLCTypeID = (EnumObjects.PLCType)0;

            //
            if ((e.PropertyName == "ProductName" && e.NewValue == null))
                ((Connections)View.CurrentObject).DeviceName = "Seçiniz";
        }
    }
}
