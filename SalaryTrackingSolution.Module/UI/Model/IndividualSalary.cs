using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Data;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using SalaryTrackingSolution.Module.BusinessObjects;

namespace SalaryTrackingSolution.Module.UI.Model
{
    [DomainComponent, DefaultClassOptions]
    public class IndividualSalary : NonPersistentLiteObject
    {
        private SalaryTrackingSolutionDbContext _context;

        public IndividualSalary()
        {
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
        }
        [Key]
        [Browsable(false)]
        public Int16 Id { get; set; }
        public string GlobalId { get; set; }

        public string LocalId
        {
            get
            {
                if (GlobalId != null)
                {
                    var employee = _context.Employees.ToList().FirstOrDefault(x => x.GlobalId == GlobalId);
                    return employee != null ? employee.LocalId : null;
                }
                return null;
            }
        }

        public Employee Employee {
            get
            {
                if (GlobalId != null)
                {
                    var employee = _context.Employees.ToList().FirstOrDefault(x => x.GlobalId == GlobalId);
                    return employee != null ? employee : null;
                }

                return null;
            }

        }

        public IList<HistorySalary> ListHistorySalaries
        {
            get;
            set;
        }

        
    }
}
