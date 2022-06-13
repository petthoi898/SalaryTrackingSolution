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
using DevExpress.ExpressApp.Model;
using SalaryTrackingSolution.Module.UI.Model;

namespace SalaryTrackingSolution.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class NonPersistentObjectActivatorController : WindowController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        ShowNavigationItemController showNavigationItemController;

        public NonPersistentObjectActivatorController()
        {
            InitializeComponent();
            // Target required Windows (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            showNavigationItemController = Frame.GetController<ShowNavigationItemController>();
            if (showNavigationItemController != null)
            {
                showNavigationItemController.CustomShowNavigationItem += ShowNavigationItemController_CustomShowNavigationItem;
            }
        }

        private void ShowNavigationItemController_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e)
        {
            var args = e.ActionArguments;
            var shortcut = args.SelectedChoiceActionItem.Data as ViewShortcut;
            if (shortcut != null)
            {
                var model = Application.FindModelView(shortcut.ViewId);
                if (model is IModelDetailView && string.IsNullOrEmpty(shortcut.ObjectKey))
                {
                    var objectType = ((IModelDetailView)model).ModelClass.TypeInfo.Type;
                    if (typeof(ListDetailSalaryModel).IsAssignableFrom(objectType))
                    {
                        var objectSpace = Application.CreateObjectSpace(objectType);
                        var obj = objectSpace.CreateObject(objectType);
                        objectSpace.RemoveFromModifiedObjects(obj);
                        var detailView = Application.CreateDetailView(objectSpace, shortcut.ViewId, true, obj);
                        detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
                        args.ShowViewParameters.CreatedView = detailView;
                        args.ShowViewParameters.TargetWindow = TargetWindow.Current;
                        e.Handled = true;
                    }
                }
            }
        }

        protected override void OnDeactivated()
        {
            if (showNavigationItemController != null)
            {
                showNavigationItemController.CustomShowNavigationItem -= ShowNavigationItemController_CustomShowNavigationItem;
            }
            base.OnDeactivated();
        }
    }
}
