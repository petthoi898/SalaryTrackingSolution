using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using SalaryTrackingSolution.Module.BusinessObjects;
using SalaryTrackingSolution.Module.StaticFile;

namespace SalaryTrackingSolution.Module.UI.Model
{

    [DomainComponent]
    public class ReviewSalaryModel : NonPersistentLiteObject, INotifyPropertyChanged, IObjectSpaceLink
    {
        private SalaryTrackingSolutionDbContext _context;
        public ReviewSalaryModel()
        {
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
        }
        [Browsable(false)]
        [DevExpress.ExpressApp.Data.Key]
        public Int64 Id { get; set; }
        public virtual Employee Employee { get; set; }
        public string LocalId => Employee == null ? null : Employee.LocalId;

        public string GlobalId => Employee == null ? null : Employee.GlobalId;

        public string FirstName => Employee == null ? null : Employee.FirstName;

        public string MiddleName => Employee == null ? null : Employee.MiddleName;

        public string LastName => Employee == null ? null : Employee.LastName;

        public string Segment => Employee == null ? null : Employee.Segment;
        public DateTime? JoinDate => Employee == null ? null : Employee.JoinDate;
        public Int16 ProbationScore { get; set; }

        public Int64 ProbationSalary => Employee == null ? 0 :
            Employee.ProbationSalary != 0 ? Employee.ProbationSalary : Employee.TrialSalary;

        private Int64 baseSalary;
        public Int64 BaseSalary
        {
            get
            {
                if (baseSalary == 0)
                {
                    if (Employee != null)
                    {
                        var salary = _context.Salaries.ToList().FirstOrDefault(x => x.Employee.Id == Employee.Id);
                        baseSalary =  salary != null ? salary.BaseSalary : 0;
                    }
                }
                
                return baseSalary;

            }
            set
            {
                baseSalary = value;
                OnPropertyChanged(nameof(BaseSalary));
            }
        }

        private Int64 responsibility;
        public Int64 ResponsibilityAllowance
        {
            get
            {
                if (responsibility == 0)
                {

                    if (Employee != null)
                    {
                        var salary = _context.Salaries.ToList().FirstOrDefault(x => x.Employee.Id == Employee.Id);
                        responsibility =  salary != null ? salary.ResponsibilityAllowance : 0;
                    }
                }

                return responsibility;

            }
            set
            {
                responsibility = value;
                OnPropertyChanged(nameof(ResponsibilityAllowance));
            }
        }

        private Int64 houseTransport;
        public Int64 HouseTransportAllowance
        {
            get
            {
                if (houseTransport == 0)
                {
                    if (Employee != null)
                    {
                        var salary = _context.Salaries.ToList().FirstOrDefault(x => x.Employee.Id == Employee.Id);
                        houseTransport = salary != null ? salary.HouseTransportAllowance : 0;
                    }
                }

                return houseTransport;

            }
            set
            {
                houseTransport = value;
                OnPropertyChanged(nameof(HouseTransportAllowance));
            }
        }

        private Int64 telephone;
        public Int64 TelephoneAllowance
        {
            get
            {
                if (telephone == 0)
                {
                    if (Employee != null)
                    {
                        var salary = _context.Salaries.ToList().FirstOrDefault(x => x.Employee.Id == Employee.Id);
                        telephone = salary != null ? salary.TelephoneAllowance : 0;
                    }
                }

                return telephone;

            }
            set
            {
                telephone = value;
                OnPropertyChanged(nameof(TelephoneAllowance));
            }
        }

        private Int64 shuiPayToEmployee;
        public Int64 ShuiPayToEmployeeAllowance
        {
            get
            {
                if (shuiPayToEmployee == 0)
                {
                    if (Employee != null)
                    {
                        var salary = _context.Salaries.ToList().FirstOrDefault(x => x.Employee.Id == Employee.Id);
                        shuiPayToEmployee = salary != null ? salary.ShuiPayToEmployee : 0;
                    }
                }

                return shuiPayToEmployee;

            }
            set
            {
                shuiPayToEmployee = value;
                OnPropertyChanged(nameof(ShuiPayToEmployeeAllowance));
            }
        }
        public DateTime? EffectiveDate
        {
            get
            {
                var join = JoinDate.GetValueOrDefault();
                if (join != null)
                {
                    return join.AddMonths(4);
                }
                else return null;
            }
        }

        public Int64 TotalLaborContractSalary =>
            BaseSalary + ResponsibilityAllowance + HouseTransportAllowance;

        private IObjectSpace objectSpace;
        IObjectSpace IObjectSpaceLink.ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }

        public override void OnLoaded()
        {
            base.OnLoaded();
        }

        public override void OnCreated()
        {
            base.OnCreated();
        }

        public override void OnSaving()
        {
            if (HasChangeSalary())
            {
                var salaryOld = _context.Salaries.ToList().LastOrDefault(x => x.EmployeeId == Employee.Id);
                var newHistory = new HistorySalary()
                {
                    EmployeeId = Employee.Id,
                    TypeOfChanges = TypeOfChanges.Review,
                    BaseSalaryNew = BaseSalary,
                    HouseTransportNew = HouseTransportAllowance,
                    ResponsibilityNew = ResponsibilityAllowance,
                    TelephoneNew = TelephoneAllowance,
                    ShuiPayToEmployeeNew = ShuiPayToEmployeeAllowance,
                    BaseSalaryOld = salaryOld.BaseSalary,
                    HouseTransportOld = salaryOld.HouseTransportAllowance,
                    ResponsibilityOld = salaryOld.ResponsibilityAllowance,
                    TelephoneOld = salaryOld.TelephoneAllowance,
                    ShuiPayToEmployeeOld = salaryOld.ShuiPayToEmployee,
                    UpdateAt = DateTime.Now
                };
                _context.HistorySalaries.Add(newHistory);
                salaryOld.BaseSalary = BaseSalary;
                salaryOld.ResponsibilityAllowance = ResponsibilityAllowance;
                salaryOld.HouseTransportAllowance = HouseTransportAllowance;
                salaryOld.TelephoneAllowance = TelephoneAllowance;
                salaryOld.ShuiPayToEmployee = ShuiPayToEmployeeAllowance;
                _context.SaveChanges();
            }

        }

        private void UpdateSalaryInDb()
        {

        }
        private bool HasChangeSalary()
        {
            var salaryOld = _context.Salaries.FirstOrDefault(x => x.EmployeeId == Employee.Id);
            if (salaryOld != null)
            {
                return salaryOld.BaseSalary != BaseSalary ||
                       salaryOld.ShuiPayToEmployee != ShuiPayToEmployeeAllowance ||
                       salaryOld.HouseTransportAllowance != HouseTransportAllowance ||
                       salaryOld.TelephoneAllowance != TelephoneAllowance;
            }
            return true;
        }
    }
}
