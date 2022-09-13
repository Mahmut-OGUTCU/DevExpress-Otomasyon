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
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CR_SFC.Module.Controllers
{
    public partial class ShowSavedMessage : ViewController
    {
        public ShowSavedMessage()
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
            if (ObjectSpace.IsDeleting)
                ShowMessage("Kayıt Silindi !");
        }

        private void ObjectSpace_ObjectSaving(object sender, ObjectManipulatingEventArgs e)
        {
            if (ObjectSpace.IsNewObject(View.CurrentObject))
                ShowMessage("Kayıt Eklendi !");
            else
                ShowMessage("Kayıt Güncellendi !");
        }

        private void ShowMessage(string message = "")
        {
            var aa = View;
            MessageOptions options = new MessageOptions
            {
                Duration = 2000,
                Type = InformationType.Success
            };
            options.Web.Position = InformationPosition.Bottom;
            options.Win.Caption = "BAŞARILI";
            options.Win.Type = WinMessageType.Toast;
            options.Message = string.Format(message);
            Application.ShowViewStrategy.ShowMessage(options);
        }
    }
}
