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
using TypeOfContracts = SalaryTrackingSolution.Module.BusinessObjects.TypeOfContracts;

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
        public Int64 Id
        {
            get; 
            set;
        }

        [Browsable(false)]
        public Guid ContractId
        {
            get; 
            set;
        }
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

        public string Manager
        {
            get;
            set;
        }
        public virtual Segment Segment
        {
            get;
            set;
        }

        public TypeOfContractsNewHire TypeOfContractsNewHire
        {
            get; 
            set;
        }

        public string ContractNo
        {
            get;
            set;
        }

        public Int64 Salary
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

        public DateTime JoinDate
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

        public Int64 ResponsibilityAllowance
        {
            get;
            set;
        }

        public Int64 HouseTransportAllowance
        {
            get; 
            set;
        }

        public Int64 TelephoneAllowance
        {
            get;
            set;
        }

        [DisplayName("SHUI Pay To Employee")]
        public Int64 SHUIPayToEmployeeAllowance
        {
            get;
            set;
        }

        public override void OnSaving()
        {
            if (ValidLocalIdAndGlobalId())
            {
                var newEmployee = CreateNewEmployee();
                _context.Employees.Add(newEmployee);
                var newSalary = CreateNewSalary(newEmployee);
                _context.Salaries.Add(newSalary);
                var newHistorySalary = CreateNewHistorySalary(newEmployee);
                _context.HistorySalaries.Add(newHistorySalary);
                var newContract = CreateNewContract(newEmployee);
                _context.Contracts.Add(newContract);
                _context.SaveChanges();
                MessageBox.Show("Successfully Add New Employee");
            }
            else
            {
                MessageBox.Show("Local ID or Global ID is invalid!");
            }
        }
        private bool ValidLocalIdAndGlobalId()
        {
            var listEmployee = _context.Employees.ToList();
            return listEmployee.FirstOrDefault(x => x.LocalId == LocalId) == null &&
                   listEmployee.FirstOrDefault(x => x.GlobalId == GlobalId) == null;
        }
        private Employee CreateNewEmployee()
        {
            return new Employee()
            {
                EndDate = EndDate,
                FirstName = FirstName,
                GlobalId = GlobalId,
                JoinDate = JoinDate,
                LastName = LastName,
                LocalId = LocalId,
                MiddleName = MiddleName,
                Note = Note,
                ProbationaryContractNo = TypeOfContractsNewHire.Name == StaticFile.TypeOfContracts.ProbationContract
                    ? ContractNo
                    : null,
                ProbationSalary = TypeOfContractsNewHire.Name == StaticFile.TypeOfContracts.ProbationContract ? Salary : 0,
                TrialSalary = TypeOfContractsNewHire.Name == StaticFile.TypeOfContracts.TrainingContract ? Salary : 0,
                TraineeShipContractNo = TypeOfContractsNewHire.Name == StaticFile.TypeOfContracts.TrainingContract
                    ? ContractNo
                    : null,
                Active = Active,
                Segment = Segment.Name

            };
        }
        private Salary CreateNewSalary(Employee newEmployee)
        {
            return new Salary()
            {
                EmployeeId = newEmployee.Id,
                ContractDate = DateTime.Now,
                HouseTransportAllowance = HouseTransportAllowance,
                TelephoneAllowance = TelephoneAllowance,
                ResponsibilityAllowance = ResponsibilityAllowance,
                ShuiPayToEmployee = SHUIPayToEmployeeAllowance,
                BaseSalary = BaseSalary
            };
        }
        private HistorySalary CreateNewHistorySalary(Employee newEmployee)
        {
            return new HistorySalary()
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
        }
        private Contract CreateNewContract(Employee newEmployee)
        {
            return new Contract()
            {
                TypeOfContract = TypeOfContractsNewHire.Name,
                BaseSalary = BaseSalary,
                EmployeeId = newEmployee.Id,
                Note = Note,
                ProbationSalary = TypeOfContractsNewHire.Name == StaticFile.TypeOfContracts.ProbationContract ? Salary : 0,
                TrialSalary = TypeOfContractsNewHire.Name == StaticFile.TypeOfContracts.TrainingContract ? Salary : 0,
                Status = "Active"

            };
        }
    }
}
