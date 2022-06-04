using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using SalaryTrackingSolution.Module.BusinessObjects;
using SalaryTrackingSolution.Module.StaticFile;

namespace SalaryTrackingSolution.Module.UI.Model
{
    [DomainComponent, DefaultClassOptions]
    public class DemotionModel : NonPersistentLiteObject
    {
        private SalaryTrackingSolutionDbContext _context;
        public DemotionModel()
        {
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
        }
        [Browsable(false)]
        [DevExpress.ExpressApp.Data.Key]
        public Int64 Id { get; set; }
        public virtual Employee Employee
        {
            get
            {
                if (LocalId != null)
                {
                    var employee = _context.Employees.ToList().FirstOrDefault(x => x.LocalId == LocalId);
                    return employee;
                }
                else return null;
            }
        }
        public string LocalId
        {
            get;
            set;
        }
        public string GlobalId
        {
            get
            {
                if (LocalId != null)
                {
                    var employee = _context.Employees.ToList().FirstOrDefault(x => x.LocalId == LocalId);
                    return employee != null ? employee.GlobalId : null;
                }
                else return null;
            }
        }

        public string FirstName
        {
            get
            {
                if (LocalId != null)
                {
                    var employee = _context.Employees.ToList().FirstOrDefault(x => x.LocalId == LocalId);
                    return employee != null ? employee.FirstName : null;
                }
                else return null;
            }
        }

        public string MiddleName
        {
            get
            {
                if (LocalId != null)
                {
                    var employee = _context.Employees.ToList().FirstOrDefault(x => x.LocalId == LocalId);
                    return employee != null ? employee.MiddleName : null;
                }
                else return null;
            }
        }

        public string LastName
        {
            get
            {
                if (LocalId != null)
                {
                    var employee = _context.Employees.ToList().FirstOrDefault(x => x.LocalId == LocalId);
                    return employee != null ? employee.LastName : null;

                }
                else return null;
            }
        }

        public string Segment
        {
            get
            {
                if (LocalId != null)
                {
                    var employee = _context.Employees.ToList().FirstOrDefault(x => x.LocalId == LocalId);
                    return employee != null ? employee.Segment : null;

                }
                else return null;
            }
        }
        public DateTime? JoinDate => Employee == null ? null : Employee.JoinDate;

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
                        baseSalary = salary != null ? salary.BaseSalary : 0;
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
                        return salary != null ? salary.ResponsibilityAllowance : 0;
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
                        return salary != null ? salary.HouseTransportAllowance : 0;
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
                        return salary != null ? salary.TelephoneAllowance : 0;
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
                        return salary != null ? salary.ShuiPayToEmployee : 0;
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
            BaseSalary + ResponsibilityAllowance + HouseTransportAllowance + TelephoneAllowance + ShuiPayToEmployeeAllowance;
        public Int64 CurrentBaseSalary
        {
            get
            {
                if (Employee != null)
                {
                    var salary = _context.Salaries.ToList().LastOrDefault(x => x.Employee.Id == Employee.Id);
                    return salary != null ? salary.BaseSalary : 0;
                }
                else return 0;
            }

        }
        public Int64 CurrentResponsibilityAllowance
        {
            get
            {
                if (Employee != null)
                {
                    var salary = _context.Salaries.ToList().LastOrDefault(x => x.Employee.Id == Employee.Id);
                    return salary != null ? salary.ResponsibilityAllowance : 0;
                }
                else return 0;
            }
        }
        public Int64 CurrentHouseTransportAllowance
        {
            get
            {
                if (Employee != null)
                {
                    var salary = _context.Salaries.ToList().LastOrDefault(x => x.Employee.Id == Employee.Id);
                    return salary != null ? salary.HouseTransportAllowance : 0;
                }
                return 0;
            }

        }
        public Int64 CurrentTelephoneAllowance
        {
            get
            {
                if (Employee != null)
                {
                    var salary = _context.Salaries.ToList().LastOrDefault(x => x.Employee.Id == Employee.Id);
                    return salary != null ? salary.TelephoneAllowance : 0;
                }

                return 0;
            }
        }
        public Int64 CurrentShuiPayToEmployeeAllowance
        {
            get
            {
                if (Employee != null)
                {
                    var salary = _context.Salaries.ToList().LastOrDefault(x => x.Employee.Id == Employee.Id);
                    return salary != null ? salary.ShuiPayToEmployee : 0;
                }
                return 0;
            }

        }
        public Int64 CurrentTotalLaborContractSalary =>
            CurrentBaseSalary + CurrentResponsibilityAllowance + CurrentHouseTransportAllowance
            + CurrentTelephoneAllowance + CurrentShuiPayToEmployeeAllowance;

        public override void OnSaving()
        {
            if (HasChangeAnything())
            {
                var newHistory = CreateHistorySalary();
                _context.HistorySalaries.Add(newHistory);
                UpdateSalary();
                _context.SaveChanges();
                MessageBox.Show("Successfully Update!");
            }
            else
            {
                MessageBox.Show("Nothing Changed !");
            }
        }

        private bool HasChangeAnything()
        {
            return CurrentBaseSalary != BaseSalary ||
                   CurrentShuiPayToEmployeeAllowance != ShuiPayToEmployeeAllowance ||
                   CurrentTelephoneAllowance != TelephoneAllowance ||
                   CurrentHouseTransportAllowance != HouseTransportAllowance ||
                   CurrentResponsibilityAllowance != ResponsibilityAllowance;
        }
        private HistorySalary CreateHistorySalary()
        {
            return new HistorySalary()
            {
                EmployeeId = Employee.Id,
                TypeOfChanges = TypeOfChanges.Demotion,
                BaseSalaryNew = BaseSalary,
                HouseTransportNew = HouseTransportAllowance,
                ResponsibilityNew = ResponsibilityAllowance,
                TelephoneNew = TelephoneAllowance,
                ShuiPayToEmployeeNew = ShuiPayToEmployeeAllowance,
                BaseSalaryOld = CurrentBaseSalary,
                HouseTransportOld = CurrentHouseTransportAllowance,
                ResponsibilityOld = CurrentResponsibilityAllowance,
                TelephoneOld = CurrentTelephoneAllowance,
                ShuiPayToEmployeeOld = CurrentShuiPayToEmployeeAllowance,
                UpdateAt = DateTime.Now
            };
        }
        private void UpdateSalary()
        {
            var salary = _context.Salaries.ToList().FirstOrDefault(x => x.EmployeeId == Employee.Id);
            if (salary != null)
            {
                salary.BaseSalary = BaseSalary;
                salary.HouseTransportAllowance = HouseTransportAllowance;
                salary.ResponsibilityAllowance = ResponsibilityAllowance;
                salary.TelephoneAllowance = TelephoneAllowance;
                salary.ShuiPayToEmployee = ShuiPayToEmployeeAllowance;
                _context.SaveChanges();
            }
        }
    }
}
