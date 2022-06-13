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
using DevExpress.Spreadsheet;
using DevExpress.Export.Xl;
using System.IO;
using System.Diagnostics;
using SalaryTrackingSolution.Module.BusinessObjects;
using System.Data.Entity;
using SalaryTrackingSolution.Module.StaticFile;
using SalaryTrackingSolution.Module.UI.Model;
using System.Collections;
using DevExpress.Office;
using DevExpress.DataAccess.Excel;
using DevExpress.XtraPivotGrid;
using PivotFilterType = DevExpress.XtraPivotGrid.PivotFilterType;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.Utils;

namespace SalaryTrackingSolution.Module.UI.UserControl
{
    public partial class ucMoveSalary : System.Windows.Forms.UserControl
    {
        private SalaryTrackingSolutionDbContext _context;
        private GridControl gridSalaryChange;
        private BandedGridView mainView;
        private DataTable data;
        public ucMoveSalary()
        {
            InitializeComponent();
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
            gridSalaryChange = new GridControl();
            data = new DataTable();
            InitialGUI();
        }

        private void InitialGUI()
        {
            InitialGridBandHeader();
            //InitialData();
        }

        private void InitialGridBandHeader()
        {
            mainView = new BandedGridView(gridSalaryChange);
            gridSalaryChange.Parent = this;
            gridSalaryChange.Dock = DockStyle.Fill;
            InformationColumns();
        }

        
        private void InformationColumns()
        {
            GridBand gridBandInformation = new GridBand();

            BandedGridColumn colLocalId = new BandedGridColumn();
            BandedGridColumn colGloalId = new BandedGridColumn();
            BandedGridColumn colFirstNameAndMiddleName = new BandedGridColumn();
            BandedGridColumn colFirstName = new BandedGridColumn();
            BandedGridColumn colDivisionDept = new BandedGridColumn();
            BandedGridColumn colJoiningDate = new BandedGridColumn();
            BandedGridColumn colTerminationDate = new BandedGridColumn();
            //gridSalaryChange.DataSource = this.customersBindingSource;
            gridSalaryChange.ViewCollection.Add(mainView);
            gridSalaryChange.MainView = mainView;

            mainView.Bands.AddRange(new GridBand[] { gridBandInformation });
            mainView.Columns.AddRange(new BandedGridColumn[] { colLocalId, colGloalId, colFirstNameAndMiddleName, colFirstName, colDivisionDept, colJoiningDate, colTerminationDate });

            colLocalId.FieldName = "LocalID";
            colLocalId.Caption = "Local ID";
            colLocalId.Visible = true;
            colLocalId.Width = 94;

            colGloalId.FieldName = "GlobalID";
            colLocalId.Caption = "Global ID";
            colGloalId.Visible = true;
            colGloalId.Width = 74;

            colFirstNameAndMiddleName.Caption = "Last Name And Middle Name";
            colFirstNameAndMiddleName.FieldName = "LastMiddleName";
            colFirstNameAndMiddleName.Visible = true;
            colFirstNameAndMiddleName.Width = 67;

            colFirstName.FieldName = "FirstName";
            colFirstName.Caption = "First Name";
            colFirstName.Visible = true;
            colFirstName.Width = 94;

            colDivisionDept.FieldName = "Division/Dept.";
            colDivisionDept.Caption = "Division/Dept.";
            colDivisionDept.Visible = true;
            colDivisionDept.Width = 94;

            colJoiningDate.FieldName = "JoiningDate";
            colJoiningDate.Caption = "Joining Date";
            colJoiningDate.Visible = true;
            colJoiningDate.Width = 94;

            colTerminationDate.FieldName = "TerminationDate";
            colTerminationDate.Caption = "Termination Date";
            colTerminationDate.Visible = true;
            colTerminationDate.Width = 94;

            gridBandInformation.Caption = "Employee's Information";
            gridBandInformation.Columns.Add(colLocalId);
            gridBandInformation.Columns.Add(colGloalId);
            gridBandInformation.Columns.Add(colFirstNameAndMiddleName);
            gridBandInformation.Columns.Add(colFirstName);
            gridBandInformation.Columns.Add(colDivisionDept);
            gridBandInformation.Columns.Add(colJoiningDate);
            gridBandInformation.Columns.Add(colTerminationDate);
            gridBandInformation.VisibleIndex = 0;
            mainView.OptionsCustomization.AllowChangeColumnParent = false;
            gridBandInformation.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridBandInformation.Width = 200;

            data.Columns.Add("LocalID");
            data.Columns.Add("GlobalID");
            data.Columns.Add("LastMiddleName");
            data.Columns.Add("FirstName");
            data.Columns.Add("Division/Dept.");
            data.Columns.Add("JoiningDate");
            data.Columns.Add("TerminationDate");
        }
        private void CreateBandAndColumns(BandedGridView bandedView, int month, DateTime now)
        {
            GridBand gridBandSalary = new GridBand();
            BandedGridColumn colEffectiveDate = new BandedGridColumn();
            BandedGridColumn colTypeOfChanges = new BandedGridColumn();
            BandedGridColumn colBaseSalary = new BandedGridColumn();
            BandedGridColumn colResponsibility = new BandedGridColumn();
            BandedGridColumn colTelephone = new BandedGridColumn();
            BandedGridColumn colShuiPayToEmployee = new BandedGridColumn();
            BandedGridColumn colTotalSalary = new BandedGridColumn();
            BandedGridColumn colDiff = new BandedGridColumn();
            mainView.Bands.Add(gridBandSalary);
            mainView.Columns.AddRange(new BandedGridColumn[] { colEffectiveDate, colTypeOfChanges, colBaseSalary });

            colEffectiveDate.FieldName = "EffectiveDate" + now.ToString("MM-yyyy");
            colEffectiveDate.Caption = "Effective Date";
            colEffectiveDate.Visible = true;
            colEffectiveDate.Width = 74;
            colEffectiveDate.MinWidth = 74;

            colTypeOfChanges.FieldName = "TypeOfChanges" + now.ToString("MM-yyyy");
            colTypeOfChanges.Caption = "TypeOfChanges";
            colTypeOfChanges.Visible = true;
            colTypeOfChanges.Width = 74;
            colTypeOfChanges.MinWidth = 74;

            colBaseSalary.FieldName = "BaseSalary" + now.ToString("MM-yyyy");
            colBaseSalary.Caption = "BaseSalary";
            colBaseSalary.Visible = true;
            colBaseSalary.Width = 74;
            colBaseSalary.MinWidth = 74;


            colResponsibility.FieldName = "Responsibility" + now.ToString("MM-yyyy");
            colResponsibility.Caption = "Responsibility";
            colResponsibility.Visible = true;
            colResponsibility.Width = 74;
            colResponsibility.MinWidth = 74;

            colTelephone.FieldName = "Telephone" + now.ToString("MM-yyyy");
            colTelephone.Caption = "Telephone";
            colTelephone.Visible = true;
            colTelephone.Width = 74;
            colTelephone.MinWidth = 74;

            colShuiPayToEmployee.FieldName = "ShuiPayToEmployee" + now.ToString("MM-yyyy");
            colShuiPayToEmployee.Caption = "Shui Pay To Employee";
            colShuiPayToEmployee.Visible = true;
            colShuiPayToEmployee.Width = 74;
            colShuiPayToEmployee.MinWidth = 74;

            colTotalSalary.FieldName = "TotalSalary" + now.ToString("MM-yyyy");
            colTotalSalary.Caption = "Total Salary";
            colTotalSalary.Visible = true;
            colTotalSalary.Width = 74;
            colTotalSalary.MinWidth = 74;

            colDiff.FieldName = "Diff" + now.ToString("MM-yyyy");
            colDiff.Caption = "Diff";
            colDiff.Visible = true;
            colDiff.Width = 74;
            colDiff.MinWidth = 74;

            gridBandSalary.Caption = now.ToString("MMM-yyyy");
            gridBandSalary.Columns.Add(colEffectiveDate);
            gridBandSalary.Columns.Add(colTypeOfChanges);
            gridBandSalary.Columns.Add(colBaseSalary);
            gridBandSalary.Columns.Add(colResponsibility);
            gridBandSalary.Columns.Add(colTelephone);
            gridBandSalary.Columns.Add(colShuiPayToEmployee);
            gridBandSalary.Columns.Add(colTotalSalary);
            gridBandSalary.Columns.Add(colDiff);
        }
       
        private void SalaryColumns(BandedGridView bandedView, int numberMonth)
        {
            for(int i = numberMonth; i >= 0; i--)
            {
                var now = DateTime.Now.AddMonths(-i);
                CreateBandAndColumns(bandedView, i, now);
                CreateDataTable(now);
            }
            GetData(numberMonth);

        }

        private void CreateDataTable(DateTime now)
        {
            data.Columns.Add("EffectiveDate" + now.ToString("MM-yyyy"));
            data.Columns.Add("TypeOfChanges" + now.ToString("MM-yyyy"));
            data.Columns.Add("BaseSalary" + now.ToString("MM-yyyy"));
            data.Columns.Add("Responsibility" + now.ToString("MM-yyyy"));
            data.Columns.Add("Telephone" + now.ToString("MM-yyyy"));
            data.Columns.Add("ShuiPayToEmployee" + now.ToString("MM-yyyy"));
            data.Columns.Add("TotalSalary" + now.ToString("MM-yyyy"));
            data.Columns.Add("Diff" + now.ToString("MM-yyyy"));
        }

        private void GetData(int numberMonth)
        {
            var listEmployee = _context.Employees.ToList();
            foreach(var employee in listEmployee)
            {
                data.Rows.Add(CreateRowForEmployee(employee, numberMonth));

            }
        }
        private DataRow CreateRowForEmployee(Employee employee, int numberMonth)
        {
            DataRow row;
            row = data.NewRow();
            CreateEmployeeInformationForRow(employee, row);
            CreateEmployeeSalary(employee, row, numberMonth);
            return row;
        }
        private void CreateEmployeeInformationForRow(Employee employee, DataRow row)
        {
            row["LocalID"] = employee.LocalId;
            row["GlobalID"] = employee.GlobalId;
            row["LastMiddleName"] = employee.LastName + " " + employee.MiddleName;
            row["FirstName"] = employee.FirstName;
            row["Division/Dept."] = employee.Department;
            row["JoiningDate"] = employee.JoinDate;
            row["TerminationDate"] = employee.EndDate;
        }
       

        private void CreateEmployeeSalary(Employee employee, DataRow row, int numberMonth)
        {
            var listHistory = _context.HistorySalaries.Where(x => x.EmployeeId == employee.Id).ToList();
            for(int i = numberMonth; i >= 0; i--)
            {
                var columnMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-i); // DateTime.Now.AddMonths(-i);
                CreateSalaryForMonth(row, columnMonth, listHistory);
            }
        }

        private void CreateSalaryForMonth(DataRow row, DateTime columnMonth, List<HistorySalary> listHistory)
        {
            var salaryInColumnMonth = GetLastestUpdate(listHistory, columnMonth, listHistory.Count);//listHistory.FirstOrDefault(x => x.UpdateAt <= columnMonth);
            InitializeDataForMonth(row, salaryInColumnMonth, columnMonth);


        }
        private void InitializeDataForMonth(DataRow row, HistorySalary salary, DateTime columnMonth)
        {
            row["EffectiveDate" + columnMonth.ToString("MM-yyyy")]
                = CheckSameMonthAndYear(salary.UpdateAt, columnMonth) ? salary.UpdateAt.ToString("dd-MM-yyyy") : "";
            //= salary.TypeOfChanges != TypeOfChanges.NewHire ? string.IsNullOrEmpty(salary.TypeOfChanges) ? " " : salary.UpdateAt.ToString("dd-MM-yyyy") : "";
            row["TypeOfChanges" + columnMonth.ToString("MM-yyyy")]
                = CheckSameMonthAndYear(salary.UpdateAt, columnMonth) ? salary.TypeOfChanges : "";
            //= salary.TypeOfChanges == TypeOfChanges.NewHire ? salary.TypeOfChanges : "";
            row["BaseSalary" + columnMonth.ToString("MM-yyyy")] = salary.BaseSalaryNew;
            row["Responsibility" + columnMonth.ToString("MM-yyyy")] = salary.ResponsibilityNew;
            row["Telephone" + columnMonth.ToString("MM-yyyy")] = salary.TelephoneNew;
            row["ShuiPayToEmployee" + columnMonth.ToString("MM-yyyy")] = salary.ShuiPayToEmployeeNew;
            row["TotalSalary" + columnMonth.ToString("MM-yyyy")] = salary.TotalNew;
            if(data.Columns.Contains("Diff" + columnMonth.AddMonths(-1).ToString("MM-yyyy")))
            {
                row["Diff" + columnMonth.ToString("MM-yyyy")] = salary.TotalNew - Convert.ToInt32(row["TotalSalary" + columnMonth.AddMonths(-1).ToString("MM-yyyy")].ToString());

            }
            else
            {
                row["Diff" + columnMonth.ToString("MM-yyyy")] = salary.TotalNew;

            }
        }
        private bool CheckSameMonthAndYear(DateTime updateAt, DateTime columnMonth)
        {
            return updateAt.ToString("MM-yyyy") == columnMonth.ToString("MM-yyyy");
        }
        private HistorySalary GetLastestUpdate(List<HistorySalary> history, DateTime currentMonth, int number)
        {
            HistorySalary result = new HistorySalary();
            for(int i = number - 1; i >= 0; i--)
            {
                if(history.ElementAt(i).UpdateAt.Year < currentMonth.Year)
                {
                    result = history.ElementAt(i);
                    return result;
                }
                else if(history.ElementAt(i).UpdateAt.Year <= currentMonth.Year)
                {
                    if(history.ElementAt(i).UpdateAt.Month <= currentMonth.Month)
                    {
                        result = history.ElementAt(i);
                        return result;
                    }
                }
            }
            return result;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = "output.xlsx";
            gridSalaryChange.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Reset();
            var from = timeFrom.Value;
            var to = timeTo.Value;
            var numberMonth = (to.Year - from.Year) * 12 + to.Month - from.Month;
            if(numberMonth < 0)
            {
                return;
            }
            SalaryColumns(mainView, numberMonth);
            gridSalaryChange.DataSource = data;
            gridSalaryChange.Refresh();
        }

        private void Reset()
        {
            data = new DataTable();
            InitialGridBandHeader();
        }
    }
}
