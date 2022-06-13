using DevExpress.XtraEditors;
using SalaryTrackingSolution.Module.BusinessObjects;
using SalaryTrackingSolution.Module.StaticFile;
using SalaryTrackingSolution.Module.UI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryTrackingSolution.Module.UI.UserControl
{
    public partial class ucSummary : DevExpress.XtraEditors.XtraUserControl
    {
        private SalaryTrackingSolutionDbContext _context;
        public ucSummary()
        {
            InitializeComponent();
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
            Initial();
        }

        private void Initial()
        {
            InitialGUI();
            InitialData();
        }

        private void InitialData()
        {
            gridControl1.DataSource = GetData();
        }

        private List<SummaryModel> GetData()
        {
            var result = new List<SummaryModel>();
            result.Add(GetDataElement(TypeOfChanges.NewHire));
            result.Add(GetDataElement(TypeOfChanges.SignContract));
            result.Add(GetDataElement(TypeOfChanges.Demotion));
            result.Add(GetDataElement(TypeOfChanges.Promotion));
            result.Add(GetDataElement(TypeOfChanges.Review ));
            return result;
        }
        private SummaryModel GetDataElement(string type)
        {
            var result = new SummaryModel(type);
            var listHistory = _context.HistorySalaries
                                .Where(x => x.TypeOfChanges == type)
                                .ToList();
            var now = DateTime.Now;
            int monthGUI = 1;
            foreach(var element in listHistory)
            {

            }
            for (int month = now.Month - 11; month <= now.Month; month++)
            {
                result.InitSummary(listHistory, month, monthGUI, type);
                monthGUI++;
            }
            return result;
        }
       
        private void InitialGUI()
        {
            var now = DateTime.Now;
            detail.Caption = "Detail";
            gridBand1.Caption = now.AddMonths(-11).ToString("MMM-yyyy");
            gridBand2.Caption = now.AddMonths(-10).ToString("MMM-yyyy");
            gridBand3.Caption = now.AddMonths(-9).ToString("MMM-yyyy");
            gridBand4.Caption = now.AddMonths(-8).ToString("MMM-yyyy");
            gridBand5.Caption = now.AddMonths(-7).ToString("MMM-yyyy");
            gridBand6.Caption = now.AddMonths(-6).ToString("MMM-yyyy");
            gridBand7.Caption = now.AddMonths(-5).ToString("MMM-yyyy");
            gridBand8.Caption = now.AddMonths(-4).ToString("MMM-yyyy");
            gridBand9.Caption = now.AddMonths(-3).ToString("MMM-yyyy");
            gridBand10.Caption = now.AddMonths(-2).ToString("MMM-yyyy");
            gridBand11.Caption = now.AddMonths(-1).ToString("MMM-yyyy");
            gridBand12.Caption = now.ToString("MMM-yyyy");
        }
    }
}
