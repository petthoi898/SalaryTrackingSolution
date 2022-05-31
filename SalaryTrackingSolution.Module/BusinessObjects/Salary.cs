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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SalaryTrackingSolution.Module.BusinessObjects
{
    // Register this entity in the DbContext using the "public DbSet<Salary> Salarys { get; set; }" syntax.
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Salary : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        private SalaryTrackingSolutionDbContext _context;
        public Salary()
        {
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
        }

        [Browsable(false)]  // Hide the entity identifier from UI.
        [DevExpress.ExpressApp.Data.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Browsable(false)]
        [System.ComponentModel.DataAnnotations.Schema.Index("IX_OnCallIdEmployee", 2, IsUnique = true)]

        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public string FullName => $"{Employee.FirstName} {Employee.MiddleName} {Employee.LastName}";

        public Int64 BaseSalary { get; set; }

        //private Int64 responsibilityAllowance;

        public Int64 ResponsibilityAllowance { get; set; }

        //private Int64 houseTransportAllowance;

        public Int64 HouseTransportAllowance
        {
            get;
            set;
        }

       // private Int64 telephoneAllowance;

        public Int64 TelephoneAllowance
        {
            get;
            set;
        }

        //private Int64 shuiPayToEmployee;

        public Int64 ShuiPayToEmployee
        {
            get;
            set;
        }



        //private int laborContractNo;

        public int LaborContractNo
        {
            get;
            set;
        }

        //private DateTime contractDate;

        public DateTime ContractDate
        {
            get;
            set;
        }

      
        #region IXafEntityObject members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIXafEntityObjecttopic.aspx)
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

        }
        #endregion

        #region IObjectSpaceLink members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIObjectSpaceLinktopic.aspx)
        // Use the Object Space to access other entities from IXafEntityObject methods (see https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113707.aspx).
        private IObjectSpace objectSpace;
        IObjectSpace IObjectSpaceLink.ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
        #endregion

        #region INotifyPropertyChanged members (see http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged(v=vs.110).aspx)
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }
}
