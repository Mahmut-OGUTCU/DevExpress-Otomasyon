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
            ObjectSpace.Committing += ObjectSpace_Committing;
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ObjectSpace.Committing -= ObjectSpace_Committing;
        }

        private void ObjectSpace_Committing(object sender, CancelEventArgs e)
        {
            MessageOptions options = new MessageOptions
            {
                Duration = 2000,
                Type = InformationType.Success
            };
            options.Web.Position = InformationPosition.Bottom;
            options.Win.Caption = "BAŞARILI";
            options.Win.Type = WinMessageType.Toast;

            if (ObjectSpace.IsNewObject(View.CurrentObject))
                options.Message = string.Format("Kayıt Eklendi !");

            else if (ObjectSpace.IsModified)
                options.Message = string.Format("Kayıt Güncellendi !");

            else
                options.Message = string.Format("Kayıt Silindi !");

            Application.ShowViewStrategy.ShowMessage(options);
        }
    }
}
