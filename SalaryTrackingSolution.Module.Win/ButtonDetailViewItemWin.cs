using System;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using SalaryTrackingSolution.Module.UI.Model;

namespace SalaryTrackingSolution.Module.Win
{
    public interface IModelButtonDetailViewItemWin : IModelViewItem { }

    [ViewItemAttribute(typeof(IModelButtonDetailViewItemWin))]
    public class ButtonDetailViewItemWin : ViewItem, IComplexViewItem
    {
        private XafApplication application;
        private IObjectSpace ObjectSpace;
        public ButtonDetailViewItemWin(IModelViewItem model, Type objectType)
            : base(objectType, model.Id)
        {
          
        }

        public void Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.application = application;
            ObjectSpace = objectSpace;
        }

        protected override object CreateControlCore()
        {
            Button button = new Button();
            button.Text = "Click me!";
            button.Click += button_Click;
            return button;
        }
        void button_Click(object sender, EventArgs e)
        {
            var model = ObjectSpace.GetObjectByKey<IndividualSalary>(151);
        }
    }
}
