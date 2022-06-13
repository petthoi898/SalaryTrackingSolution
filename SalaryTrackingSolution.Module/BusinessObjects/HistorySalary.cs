using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SalaryTrackingSolution.Module.BusinessObjects
{
    // Register this entity in the DbContext using the "public DbSet<HistorySalary> HistorySalarys { get; set; }" syntax.
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class HistorySalary : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        public HistorySalary()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new List<AssociatedEntityObject>();
        }

        [Browsable(false)] // Hide the entity identifier from UI.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Browsable(false)] 
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public Int64 BaseSalaryNew { get; set; }
        public Int64 ResponsibilityNew { get; set; }
        public Int64 TelephoneNew { get; set; }
        public Int64 HouseTransportNew { get; set; }
        public Int64 ShuiPayToEmployeeNew { get; set; }
        public Int64 BaseSalaryOld { get; set; }
        public Int64 ResponsibilityOld { get; set; }
        public Int64 TelephoneOld { get; set; }
        public Int64 HouseTransportOld { get; set; }
        public Int64 ShuiPayToEmployeeOld { get; set; }
        [Browsable(false)]
        public Int64 TotalNew => BaseSalaryNew + ResponsibilityNew + HouseTransportNew + ShuiPayToEmployeeNew;
        [Browsable(false)]
        public Int64 TotalOld => BaseSalaryOld + ResponsibilityOld + TelephoneOld + HouseTransportOld + ShuiPayToEmployeeOld;
        public DateTime UpdateAt { get; set; }
        public Guid UpdateBy { get; set; } // update by
        public string TypeOfChanges { get; set; }

        #region IXafEntityObject members (see https: //documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIXafEntityObjecttopic.aspx)

        void IXafEntityObject.OnCreated()
        {
            // Place the entity initialization code here.
            // You can initialize reference properties using Object Space methods; e.g.:
            // this.Address = objectSpace.CreateObject<Address>();
        }

        void IXafEntityObject.OnLoaded()
        {
            // Place the code that is executed each time the entity is loaded here.
        }

        void IXafEntityObject.OnSaving()
        {

            // Place the code that is executed each time the entity is saved here.
        }

        #endregion

        #region IObjectSpaceLink members (see https: //documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIObjectSpaceLinktopic.aspx)

        // Use the Object Space to access other entities from IXafEntityObject methods (see https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113707.aspx).
        private IObjectSpace objectSpace;

        IObjectSpace IObjectSpaceLink.ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }

        #endregion

        #region INotifyPropertyChanged members (see http: //msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged(v=vs.110).aspx)

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
