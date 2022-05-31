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
        public virtual Employee Employee { get; set; }
        public string LocalId => Employee == null ? null : Employee.LocalId;

        public string GlobalId => Employee == null ? null : Employee.GlobalId;

        public string FirstName => Employee == null ? null : Employee.FirstName;

        public string MiddleName => Employee == null ? null : Employee.MiddleName;

        public string LastName => Employee == null ? null : Employee.LastName;

        public string Segment => Employee == null ? null : Employee.Segment;
        public DateTime? JoinDate => Employee == null ? null : Employee.JoinDate;
        public Int16 ProbationScore { get; set; }
        public Int64 ProbationSalary => Employee == null ? 0 : Employee.ProbationSalary;

        public Int64 BaseSalary
        {
            get
            {
                if (Employee != null)
                {
                    var salary = _context.Salaries.ToList().FirstOrDefault(x => x.Employee.Id == Employee.Id);
                    return salary != null ? salary.BaseSalary : 0;
                }

                return 0;

            }
        }

        public Int64 ResponsibilityAllowance
        {
            get
            {
                if (Employee != null)
                {
                    var salary = _context.Salaries.ToList().FirstOrDefault(x => x.Employee.Id == Employee.Id);
                    return salary != null ? salary.ResponsibilityAllowance : 0;
                }

                return 0;

            }
        }


        public Int64 HouseTransportAllowance
        {
            get
            {
                if (Employee != null)
                {
                    var salary = _context.Salaries.ToList().FirstOrDefault(x => x.Employee.Id == Employee.Id);
                    return salary != null ? salary.HouseTransportAllowance + salary.TelephoneAllowance : 0;
                }

                return 0;

            }
        }
        [VisibleInDetailView(false)]
        public Int64 TelephoneAllowance
        {
            get
            {
                if (Employee != null)
                {
                    var salary = _context.Salaries.ToList().FirstOrDefault(x => x.Employee.Id == Employee.Id);
                    return salary != null ? salary.TelephoneAllowance : 0;
                }

                return 0;

            }
        }
        [VisibleInDetailView(false)]
        public Int64 ShuiPayToEmployeeAllowance
        {
            get
            {
                if (Employee != null)
                {
                    var salary = _context.Salaries.ToList().FirstOrDefault(x => x.Employee.Id == Employee.Id);
                    return salary != null ? salary.ShuiPayToEmployee : 0;
                }

                return 0;

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
            BaseSalary + ResponsibilityAllowance + HouseTransportAllowance ;
        
        public override void OnLoaded()
        {
            base.OnLoaded();

        }

        public override void OnSaving()
        {
            if (Employee == null)
                return;
            var check = _context.HistorySalaries.ToList().Where(x => x.EmployeeId == Employee.Id).ToList().Where(x => x.TypeOfChanges == TypeOfChanges.SignContract).ToList();
            if (check.Count != 0)
            {
                MessageBox.Show("Contract's Employee has already signed");
                return;

            }
            else
            {
                var salaryOld = _context.Salaries.ToList().LastOrDefault(x => x.EmployeeId == Employee.Id);
                var newHistory = new HistorySalary()
                {
                    EmployeeId = Employee.Id,
                    TypeOfChanges = TypeOfChanges.SignContract,
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
                _context.SaveChanges();
                MessageBox.Show("Successfully sign contract!");
            }
        }
        
    }
}
