using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using SalaryTrackingSolution.Module.BusinessObjects;
using SalaryTrackingSolution.Module.StaticFile;
using TypeOfContracts = SalaryTrackingSolution.Module.BusinessObjects.TypeOfContracts;

namespace SalaryTrackingSolution.Module.UI.Model
{
    [DomainComponent]
    public class SignContractModel : NonPersistentLiteObject
    {
        private SalaryTrackingSolutionDbContext _context;
        public SignContractModel()
        {
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
        }
        [Browsable(false)]
        [DevExpress.ExpressApp.Data.Key]
        public Int64 Id { get; set; }

        public string NewContractId { get; set; }
        public string CurrentContractId
        {
            get
            {
                if (Employee != null)
                {
                    var contract = _context.Contracts.ToList().FirstOrDefault(x => x.EmployeeId == Employee.Id);
                    return contract != null ? contract.ContractId : string.Empty;
                }
                else return string.Empty;
            }

        }
        public virtual Employee Employee
        {
            get
            {
                if (LocalId != null)
                {
                    var employee = _context.Employees.ToList().FirstOrDefault(x => x.LocalId == LocalId);
                    return employee != null ? employee : new Employee();
                }
                else return null;
            }
        }
        public string LocalId
        {
            get;
            set;
        }
        public string GlobalId {
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
                    return employee != null? employee.FirstName : null;
                }
                else return null;
            }
        }

        public string MiddleName {
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

        public string LastName {
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
        public string CurrentContractNote
        {
            get
            {
                if (LocalId != null)
                {
                    var contract = _context.Contracts.ToList().LastOrDefault(x => x.EmployeeId == Employee.Id);
                    return contract != null ? contract.Note : null;

                }
                else return null;
            }

        }
        public string NewContractNote
        {
            get;
            set;
        }

        public TypeOfContracts TypeOfContracts
        {
            get; 
            set;
        }

        public Int16 Period
        {
            get;
            set;
        }
        public DateTime? JoinDate
        {
            get
            {
                if (LocalId != null)
                {
                    var employee = _context.Employees.ToList().FirstOrDefault(x => x.LocalId == LocalId);
                    return employee != null ? employee.JoinDate : null;

                }
                else return null;
            }
        }

        public Int16 ProbationScore
        {
            get;
            set;
        }
        public Int64 ProbationSalary
        {
            get
            {
                if (LocalId != null)
                {
                    var employee = _context.Employees.ToList().FirstOrDefault(x => x.LocalId == LocalId);
                    return employee != null ? employee.ProbationSalary == 0 ? employee.TrialSalary : employee.ProbationSalary : 0;
                }
                else return 0;
            }
        }
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
                        return salary != null ? salary.BaseSalary : 0;
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
        private Int64 shui;
        public Int64 ShuiPayToEmployeeAllowance
        {
            get
            {
                if (shui == 0)
                {
                    if (Employee != null)
                    {
                        var salary = _context.Salaries.ToList().FirstOrDefault(x => x.Employee.Id == Employee.Id);
                        return salary != null ? salary.ShuiPayToEmployee : 0;
                    }
                }

                return shui;

            }
            set
            {
                shui = value;
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
            if (Employee != null)
            {
                var newHistory = CreateHistorySalary();
                _context.HistorySalaries.Add(newHistory);
                var newContract = CreateNewContract();
                _context.Contracts.Add(newContract);
                UpdateSalary();
                _context.SaveChanges();
                MessageBox.Show("Successfully sign contract!");
            }
            else
            {
                MessageBox.Show("Fill in Local ID that employee need to sign contract!");
            }
           
        }
        private HistorySalary CreateHistorySalary()
        {
            return new HistorySalary()
            {
                EmployeeId = Employee.Id,
                TypeOfChanges = TypeOfChanges.SignContract,
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
        private void ObsoleteOldContract()
        {
            _context.Contracts.ToList()
                .Where(x => x.EmployeeId == Employee.Id).ToList()
                .ForEach(x => x.Status = "Obsolete");
        }
        private Contract CreateNewContract()
        {
            ObsoleteOldContract();
            return new Contract()
            {
                BaseSalary = BaseSalary,
                EmployeeId = Employee.Id,
                ProbationSalary = ProbationSalary,
                ProbationScore = ProbationScore,
                TypeOfContract = TypeOfContracts.Name,
                Period = Period,
                Note = NewContractNote,
                Status = "Active"
            };
        }

    }
}
