using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using SalaryTrackingSolution.Module.BusinessObjects;
using SalaryTrackingSolution.Module.StaticFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SalaryTrackingSolution.Module.UI.Model
{
    [DomainComponent, DefaultClassOptions]
    public class SummaryModel : NonPersistentLiteObject
    {
        public SummaryModel()
        {

        }
        public SummaryModel(string detail)
        {
            Detail = detail;
        }
        [Browsable(false)]
        [DevExpress.ExpressApp.Data.Key]
        public Int64 Id { get; set; }

        public string Detail { get; set; }

        // Jan
        public Int64 NoOfEEJan { get; set; }
        public Int64 SalaryDiffJan { get; set; }
        // Feb
        public Int64 NoOfEEFeb { get; set; }
        public Int64 SalaryDiffFeb { get; set; }
        // Mar
        public Int64 NoOfEEMar { get; set; }
        public Int64 SalaryDiffMar { get; set; }
        // Apr
        public Int64 NoOfEEApr { get; set; }
        public Int64 SalaryDiffApr { get; set; }
        // May
        public Int64 NoOfEEMay { get; set; }
        public Int64 SalaryDiffMay { get; set; }
        // Jun
        public Int64 NoOfEEJun { get; set; }
        public Int64 SalaryDiffJun { get; set; }
        // Jul
        public Int64 NoOfEEJul { get; set; }
        public Int64 SalaryDiffJul { get; set; }
        // Aug
        public Int64 NoOfEEAug { get; set; }
        public Int64 SalaryDiffAug { get; set; }
        // Sep
        public Int64 NoOfEESep { get; set; }
        public Int64 SalaryDiffSep { get; set; }
        // Oct
        public Int64 NoOfEEOct { get; set; }
        public Int64 SalaryDiffOct { get; set; }
        // Nov
        public Int64 NoOfEENov { get; set; }
        public Int64 SalaryDiffNov { get; set; }
        // Dec
        public Int64 NoOfEEDec { get; set; }
        public Int64 SalaryDiffDec { get; set; }


        public void InitSummary(List<HistorySalary> history, int month, int monthGUI, string type)
        {
            //var time = month > 0 ? new DateTime(DateTime.Now.Year, month, 1) : new DateTime(DateTime.Now.Year - 1, month + 12, 1);
            month = month > 0 ? month : month + 12;
            switch (monthGUI)
            {
                case 1:
                    InitJan(history, month, type);
                    break;
                case 2:
                    InitFeb(history, month, type);

                    break;
                case 3:
                    InitMar(history, month, type);

                    break;
                case 4:
                    InitApr(history, month, type);

                    break;
                case 5:
                    InitMay(history, month, type);

                    break;
                case 6:
                    InitJun(history, month, type);

                    break;
                case 7:
                    InitJul(history, month, type);

                    break;
                case 8:
                    InitAug(history, month, type);

                    break;
                case 9:
                    InitSep(history, month, type);

                    break;
                case 10:
                    InitOct(history, month, type);

                    break;
                case 11:
                    InitNov(history, month, type);

                    break;
                case 12:
                    InitDec(history, month, type);

                    break;

            }
        }

        private void InitMar(List<HistorySalary> history, int i, string type)
        {
            NoOfEEMar = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEEMar == 0) return;

            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach (var element in listNewhire)
            {
                SalaryDiffMar += (element.TotalNew - element.TotalOld);
            }
        }

        private void InitApr(List<HistorySalary> history, int i, string type)
        {
            NoOfEEApr = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEEApr == 0) return;

            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach (var element in listNewhire)
            {
                SalaryDiffApr += (element.TotalNew - element.TotalOld);
            }
        }

        private void InitMay(List<HistorySalary> history, int i, string type)
        {
            NoOfEEMay = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEEMay == 0) return;

            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach (var element in listNewhire)
            {
                SalaryDiffMay += (element.TotalNew - element.TotalOld);
            }
        }

        private void InitJun(List<HistorySalary> history, int i, string type)
        {
            NoOfEEJun = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEEJun == 0) return;

            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach (var element in listNewhire)
            {
                SalaryDiffJun += (element.TotalNew - element.TotalOld);
            }
        }

        private void InitJul(List<HistorySalary> history, int i, string type)
        {
            NoOfEEJul = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEEJul == 0) return;

            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach (var element in listNewhire)
            {
                SalaryDiffJul += (element.TotalNew - element.TotalOld);
            }
        }

        private void InitAug(List<HistorySalary> history, int i, string type)
        {
            NoOfEEAug = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEEAug == 0) return;

            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach (var element in listNewhire)
            {
                SalaryDiffAug += (element.TotalNew - element.TotalOld);
            }
        }

        private void InitSep(List<HistorySalary> history, int i, string type)
        {
            NoOfEESep = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEESep == 0) return;

            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach (var element in listNewhire)
            {
                SalaryDiffSep += (element.TotalNew - element.TotalOld);
            }
        }

        private void InitOct(List<HistorySalary> history, int i, string type)
        {
            NoOfEEOct = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEEOct == 0) return;

            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach (var element in listNewhire)
            {
                SalaryDiffOct += (element.TotalNew - element.TotalOld);
            }
        }

        private void InitNov(List<HistorySalary> history, int i, string type)
        {
            NoOfEENov = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEENov == 0) return;

            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach (var element in listNewhire)
            {
                SalaryDiffNov += (element.TotalNew - element.TotalOld);
            }
        }

        private void InitDec(List<HistorySalary> history, int i, string type)
        {
            NoOfEEDec = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEEDec == 0) return;

            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach (var element in listNewhire)
            {
                SalaryDiffDec += (element.TotalNew - element.TotalOld);
            }
        }

        private void InitFeb(List<HistorySalary> history, int i, string type)
        {
            NoOfEEFeb = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEEFeb == 0) return;

            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach (var element in listNewhire)
            {
                SalaryDiffFeb += (element.TotalNew - element.TotalOld);
            }
        }

        private void InitJan(List<HistorySalary> history, int i, string type)
        {
            NoOfEEJan = history.Where(x => x.UpdateAt.Month == i).Select(x => x.TypeOfChanges == type).ToList().Count;
            if (NoOfEEJan == 0) return;
            var listNewhire = history.Where(x => x.TypeOfChanges == type).ToList();
            foreach(var element in listNewhire)
            {
                SalaryDiffJan += (element.TotalNew - element.TotalOld);
            }
        }
    }
}
