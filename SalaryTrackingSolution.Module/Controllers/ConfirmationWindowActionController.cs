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

namespace SalaryTrackingSolution.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ConfirmationWindowActionController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        DeleteObjectsViewController deleteObjectsViewController;
        public ConfirmationWindowActionController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            deleteObjectsViewController = Frame.GetController<DeleteObjectsViewController>();
            if (deleteObjectsViewController != null)
            {
                View.SelectionChanged += View_SelectionChanged;
                SetConfirmationMessage();
            }
        }

        private void View_SelectionChanged(object sender, EventArgs e)
        {
            SetConfirmationMessage();
        }
        private void SetConfirmationMessage()
        {
            deleteObjectsViewController.DeleteAction.ConfirmationMessage = String.Format("You are about to delete {0} object(s). Do you want to proceed?", View.SelectedObjects.Count);
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
            if (deleteObjectsViewController != null)
            {
                View.SelectionChanged -= View_SelectionChanged;
                deleteObjectsViewController = null;
            }
        }
    }
}
