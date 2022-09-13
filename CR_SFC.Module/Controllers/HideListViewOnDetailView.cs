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
    public partial class HideListViewOnDetailView : ViewController <DetailView>
    {
        public HideListViewOnDetailView()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            IsFirstRecord();
            ObjectSpace.ObjectSaved += ObjectSpace_ObjectSaved;
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ObjectSpace.ObjectSaved -= ObjectSpace_ObjectSaved;
        }

        private void ObjectSpace_ObjectSaved(object sender, ObjectManipulatingEventArgs e)
        {
            ShowListView();
        }

        private void ShowListView()
        {
            // Kayit eklendikten sonra (save method) detailview da listview'ları göster. listview'lar => ListPropertyEditor
            var items = View.Items.Where(x => x is ListPropertyEditor);
            foreach (var item in items)
            {
                Console.WriteLine((IAppearanceVisibility)item);
                ((IAppearanceVisibility)item).Visibility = ViewItemVisibility.Show;
                Console.WriteLine((IAppearanceVisibility)item);
            }
        }

        private void IsFirstRecord()
        {
            // Kayit ekleme olacaksa IsNewObject ile yakalıyoruz.
            if (ObjectSpace.IsNewObject(View.CurrentObject))
                HideListView();
        }

        private void HideListView()
        {
            // İlk kayit olacaksa (First New Record) detailview da listview'lasrı gizle. listview'lar => ListPropertyEditor
            var items = View.Items.Where(x => x is ListPropertyEditor);
            foreach (var item in items)
                ((IAppearanceVisibility)item).Visibility = ViewItemVisibility.Hide;
        }
    }
}
