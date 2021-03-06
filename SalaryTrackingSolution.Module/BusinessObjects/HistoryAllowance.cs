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
    // Register this entity in the DbContext using the "public DbSet<HistoryAllowance> HistoryAllowances { get; set; }" syntax.
    [DefaultClassOptions]
    public class HistoryAllowance : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        private SalaryTrackingSolutionDbContext _context;
        public HistoryAllowance()
        {
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
        }
        [Browsable(false)]  // Hide the entity identifier from UI.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Browsable(false)]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [Browsable(false)]
        public Guid AllowanceCodeId { get; set; }
        public virtual AllowanceCode AllowanceCode { get; set; }
        public float AmountNew { get; set; }
        public float AmountOld { get; set; }
        public DateTime UpdateAt { get; set; }
        //[Browsable(false)]
        public Guid UpdateBy { get; set; }
        [Browsable(false)]
        public Int32 ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
       // public string UpdateBy { get; set; }

        #region IXafEntityObject members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIXafEntityObjecttopic.aspx)
        void IXafEntityObject.OnCreated()
        {
            // Place the entity initialization code here.
            // You can initialize reference properties using Object Space methods; e.g.:
            // this.Address = objectSpace.CreateObject<Address>();
            //UpdateBy = objectSpace.CreateObject<ApplicationUserLoginInfo>().User.UserName;
            var applicationUserLoginInfo =
                objectSpace.FindObject<ApplicationUserLoginInfo>(CriteriaOperator.Parse("Id = ?", UpdateBy));
            ApplicationUser = objectSpace.FindObject<ApplicationUser>(CriteriaOperator.Parse(""));
        }
        void IXafEntityObject.OnLoaded()
        {
            // Place the code that is executed each time the entity is loaded here.
            var a = _context.Users.ToList();
        }
        void IXafEntityObject.OnSaving()
        {
            // Place the code that is executed each time the entity is saved here.
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
