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
using DevExpress.ExpressApp.Data;

namespace SalaryTrackingSolution.Module.BusinessObjects
{
    // Register this entity in the DbContext using the "public DbSet<Allowance> Allowances { get; set; }" syntax.
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Allowance : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {

        private SalaryTrackingSolutionDbContext _context { get; set; }
        public Allowance()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new List<AssociatedEntityObject>();
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
        }
        [Browsable(false)]  // Hide the entity identifier from UI.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        [Browsable(false)]  // Hide the entity identifier from UI.

        public Guid AllowanceCodeId { get; set; }
        public virtual AllowanceCode AllowanceCode { get; set; }

        private float amountOld;
        private float amount;

        public float Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged();
            }
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
            var allowanceInDb = _context.Allowances.FirstOrDefault(x => x.Id == Id);
            if (allowanceInDb != null)
            {
                amountOld = allowanceInDb.Amount;
            }
        }
        void IXafEntityObject.OnSaving()
        {
            //// Place the code that is executed each time the entity is saved here.
            if (!IsNewObjectCriteriaOperator.IsNewObject(this))
            {
                var userUpdate = _context.UserLoginInfos.ToList()
                    .FirstOrDefault(x => x.UserForeignKey == (int)SecuritySystem.CurrentUserId);
                var newHistory = new HistoryAllowance()
                {
                    AllowanceCodeId = AllowanceCodeId,
                    AmountNew = Amount,
                    AmountOld = amountOld,
                    EmployeeId = EmployeeId,
                    UpdateAt = DateTime.Now,
                    //UpdateBy = userUpdate.Id
                };
                _context.HistoryAllowances.Add(newHistory);
                _context.SaveChanges();

            }
            //else
            //{
            //    var listAllowance = _context.Allowances.ToList().Where(x => x.EmployeeId == EmployeeId).ToList();
            //}
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
