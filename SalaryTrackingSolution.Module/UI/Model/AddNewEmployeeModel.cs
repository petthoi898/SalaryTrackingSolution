using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Data;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using SalaryTrackingSolution.Module.BusinessObjects;
using SalaryTrackingSolution.Module.StaticFile;

namespace SalaryTrackingSolution.Module.UI.Model
{
    [DomainComponent]
    [DefaultProperty("FullName")]
    public class AddNewEmployeeModel : NonPersistentLiteObject
    {

        private SalaryTrackingSolutionDbContext _context;
        public AddNewEmployeeModel()
        {
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
        }
        [Browsable(false)]
        [DevExpress.ExpressApp.Data.Key]
        public Int64 Id { get; set; }
        [Browsable(false)]
        public Guid ContractId { get; set; }

        public virtual Contract Contract { get; set; }
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

        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        //public string Manager
        //{
        //    get;
        //    set;
        //}

        public virtual Segment Segment
        {
            get;
            set;
        }

        
        private void ResetProbation()
        {
            probationSalary = 0;
            ProbationaryContractNo = "";
        }

        private void ResetTrial()
        {
            trialSalary = 0;
            TraineeShipContractNo = "";
        }
        private Int64 trialSalary;

        public Int64 TrialSalary
        {
            get => trialSalary;
            set
            {
                trialSalary = value;
                ResetProbation();
            }
        }

        public string TraineeShipContractNo
        {
            get;
            set;
        }

        private Int64 probationSalary;
        public Int64 ProbationSalary
        {
            get => probationSalary;
            set
            {
                probationSalary = value;
                ResetTrial();
                
            }
        }


        public string ProbationaryContractNo
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }
        public bool Active { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Int64 BaseSalary { get; set; }
        public Int64 ResponsibilityAllowance { get; set; }
        public Int64 HouseTransportAllowance { get; set; }
        public Int64 TelephoneAllowance { get; set; }
        [DisplayName("SHUI Pay To Employee")]
        public Int64 SHUIPayToEmployeeAllowance { get; set; }

        public override void OnSaving()
        {
            var newEmployee = new Employee()
            {
                EndDate = EndDate,
                FirstName = FirstName,
                GlobalId = GlobalId,
                JoinDate = JoinDate,
                LastName = LastName,
                LocalId = LocalId,
                MiddleName = MiddleName,
                Note = Note,
                ProbationaryContractNo = ProbationaryContractNo,
                ProbationSalary = ProbationSalary,
                TrialSalary = TrialSalary,
                TraineeShipContractNo = TraineeShipContractNo,
                Active = Active,
                Segment = Segment.Name

            };
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
            var newSalary = new Salary()
            {
                EmployeeId = newEmployee.Id,
                ContractDate = DateTime.Now,
                HouseTransportAllowance = HouseTransportAllowance,
                TelephoneAllowance = TelephoneAllowance,
                ResponsibilityAllowance = ResponsibilityAllowance,
                ShuiPayToEmployee = SHUIPayToEmployeeAllowance,
                BaseSalary = BaseSalary

            };
            
            _context.Salaries.Add(newSalary);
            _context.SaveChanges();
            var newHistorySalary = new HistorySalary()
            {
                EmployeeId = newEmployee.Id,
                TypeOfChanges = TypeOfChanges.NewHire,
                BaseSalaryNew = BaseSalary,
                HouseTransportNew = HouseTransportAllowance,
                ResponsibilityNew = ResponsibilityAllowance,
                TelephoneNew = TelephoneAllowance,
                ShuiPayToEmployeeNew = SHUIPayToEmployeeAllowance,
                UpdateAt = DateTime.Now
            };
            _context.HistorySalaries.Add(newHistorySalary);
            _context.SaveChanges();
            var newContract = new Contract()
            {
                TypeOfChanges = TypeOfChanges.NewHire,
                BaseSalary = BaseSalary,
                EmployeeId = newEmployee.Id,
                Note = Note,
                //Manager = Manager,
                ProbationSalary = ProbationSalary,
                TrialSalary = TrialSalary

            };
            _context.Contracts.Add(newContract);
            _context.SaveChanges();
            MessageBox.Show("Successfully Add New Employee");
        }
    }
}
