using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using SalaryTrackingSolution.Module.BusinessObjects;

namespace SalaryTrackingSolution.Module.UI.Model
{
    [DomainComponent, DefaultClassOptions]
    [DefaultProperty("FullName")]
    public class ShowDetailSalaryInformation : NonPersistentLiteObject, INotifyPropertyChanged
    {
        private SalaryTrackingSolutionDbContext _context;
        public ShowDetailSalaryInformation()
        {
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        [Browsable(false)]
        [DevExpress.ExpressApp.Data.Key]
        public Int64 Id { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public string LocalId
        {
            get;
            set;
        }

        public string GlobalId
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }

        public string Segment
        {
            get;
            set;
        }
        public string Note
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public DateTime? JoinDate
        {
            get;
            set;
        }

        public DateTime? EndDate
        {
            get;
            set;
        }

        public Int64 BaseSalary
        {
            get;
            set;
        }

        public Int64 Responsibility
        {
            get;
            set;

        }

        public Int64 HouseTransport
        {
            get;
            set;
        }

        public Int64 Telephone
        {
            get;
            set;
        }

        public Int64 ShuiPayToEmployee
        {
            get;
            set;
        }
        public Int64 Total
        {
            get => BaseSalary + Responsibility + HouseTransport + Telephone + ShuiPayToEmployee;
        }

        public Int64 SalaryForShui
        {
            get => BaseSalary + Responsibility;
        }

        public Int64 Shui
        {
            get => (Int64)(SalaryForShui * 0.105);
        }

        public Int64 PIT
        {
            get => BaseSalary - 11000000 > 0 ? (Int64)((BaseSalary - 11000000) * 0.1) : 0;
        }

        public Int64 TotalGross
        {
            get => Total + Shui + PIT;
        }

        public override void OnLoaded()
        {
            base.OnLoaded();
            var employee = _context.Employees.FirstOrDefault(x => x.GlobalId == GlobalId);
            if (employee != null)
            {
                Segment = employee.Segment;

            }
        }

        public override void OnCreated()
        {
            base.OnCreated();
        }
         
    }
}
