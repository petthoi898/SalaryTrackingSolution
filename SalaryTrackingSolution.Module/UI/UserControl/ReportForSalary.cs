using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Helpers;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using SalaryTrackingSolution.Module.BusinessObjects;
using SalaryTrackingSolution.Module.UI.Model;
using System.Diagnostics;

namespace SalaryTrackingSolution.Module.UI.UserControl
{
    public partial class ReportForSalary : System.Windows.Forms.UserControl, IComplexControl
    {
        private SalaryTrackingSolutionDbContext _context;
        public ReportForSalary()
        {
            InitializeComponent();
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
        }

        private void ReportForSalary_Load(object sender, EventArgs e)
        {
            
        }

        public void Setup(IObjectSpace objectSpace, XafApplication application)
        {
            var listSalaries = _context.Salaries.ToList();
            List<ShowDetailSalaryInformation> dataSource = new List<ShowDetailSalaryInformation>();
            foreach (var salary in listSalaries)
            {
                 dataSource.Add(objectSpace.GetObject(ConvertToDetailSalaryInformation(salary)));
            }

            listSalary.DataSource = dataSource;
        }
        private ShowDetailSalaryInformation ConvertToDetailSalaryInformation(Salary salary)
        {
            var employee = salary.Employee;
            return new ShowDetailSalaryInformation()
            {
                LocalId = employee.LocalId,
                GlobalId = employee.GlobalId,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Active = employee.Active,
                JoinDate = employee.JoinDate,
                EndDate = employee.EndDate,
                Note = employee.Note,
                BaseSalary = salary.BaseSalary,
                Responsibility = salary.ResponsibilityAllowance,
                Telephone = salary.TelephoneAllowance,
                Segment = employee.Segment,
                HouseTransport = salary.HouseTransportAllowance,
                ShuiPayToEmployee = salary.ShuiPayToEmployee

            };
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "listSalary.xlsx";
                listSalary.ExportToXlsx(path);
                
                Process.Start(path);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex, "Meesage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listSalary_Click(object sender, EventArgs e)
        {

        }
    }
}
