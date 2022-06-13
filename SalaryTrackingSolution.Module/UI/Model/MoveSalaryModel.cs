using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using SalaryTrackingSolution.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryTrackingSolution.Module.UI.Model
{
    [DomainComponent]

    public class MoveSalaryModel : NonPersistentLiteObject
    {
        public MoveSalaryModel()
        {

        }
        public MoveSalaryModel(Employee employee)
        {
            LocalId = employee.LocalId;
            GlobalId = employee.GlobalId;
            FirstNameAndMiddleName = employee.FirstName + " " + employee.MiddleName;
            LastName = employee.LastName;
            Segment = employee.Department;
            JoinDate = employee.JoinDate;
            EndDate = employee.EndDate;
        }
        [Browsable(false)]
        [DevExpress.ExpressApp.Data.Key]
        public Int64 Id { get; set; }
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

        public string FirstNameAndMiddleName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }
        public string Segment
        {
            get;
            set;
        }
        public DateTime? JoinDate
        {
            get;
            set;
        }

        public DateTime? EndDate
        {
            get;
            set;
        }

        // DecPrev
        public string EffectiveDateDecPrev { get; set; }
        public string TypeOfChangesDecPrev { get; set; }
        public Int64 BaseSalaryDecPrev { get; set; }
        public Int64 ResponsibilityAllowanceDecPrev { get; set; }
        public Int64 HouseTransportDecPrev { get; set; }
        public Int64 TelephoneDecPrev { get; set; }
        public Int64 ShuiPayToEmployeeDecPrev { get; set; }
        public Int64 TotalDecPrev { get; set; }
        public Int64 DiffDecPrev { get; set; }

        // Jan
        public string EffectiveDateJan { get; set; }
        public string TypeOfChangesJan { get; set; }
        public Int64 BaseSalaryJan { get; set; }
        public Int64 ResponsibilityAllowanceJan { get; set; }
        public Int64 HouseTransportJan { get; set; }
        public Int64 TelephoneJan { get; set; }
        public Int64 ShuiPayToEmployeeJan { get; set; }
        public Int64 TotalJan { get; set; }
        public Int64 DiffJan { get; set; }

        // Feb
        public string EffectiveDateFeb { get; set; }
        public string TypeOfChangesFeb { get; set; }
        public Int64 BaseSalaryFeb { get; set; }
        public Int64 ResponsibilityAllowanceFeb { get; set; }
        public Int64 HouseTransportFeb { get; set; }
        public Int64 TelephoneFeb { get; set; }
        public Int64 ShuiPayToEmployeeFeb { get; set; }
        public Int64 TotalFeb { get; set; }
        public Int64 DiffFeb { get; set; }
        // Mar
        public string EffectiveDateMar { get; set; }
        public string TypeOfChangesMar { get; set; }
        public Int64 BaseSalaryMar { get; set; }
        public Int64 ResponsibilityAllowanceMar { get; set; }
        public Int64 HouseTransportMar { get; set; }
        public Int64 TelephoneMar { get; set; }
        public Int64 ShuiPayToEmployeeMar { get; set; }
        public Int64 TotalMar { get; set; }
        public Int64 DiffMar { get; set; }
        // Apr
        public string EffectiveDateApr { get; set; }
        public string TypeOfChangesApr { get; set; }
        public Int64 BaseSalaryApr { get; set; }
        public Int64 ResponsibilityAllowanceApr { get; set; }
        public Int64 HouseTransportApr { get; set; }
        public Int64 TelephoneApr { get; set; }
        public Int64 ShuiPayToEmployeeApr { get; set; }
        public Int64 TotalApr { get; set; }
        public Int64 DiffApr { get; set; }
        // May
        public string EffectiveDateMay { get; set; }
        public string TypeOfChangesMay { get; set; }
        public Int64 BaseSalaryMay { get; set; }
        public Int64 ResponsibilityAllowanceMay { get; set; }
        public Int64 HouseTransportMay { get; set; }
        public Int64 TelephoneMay { get; set; }
        public Int64 ShuiPayToEmployeeMay { get; set; }
        public Int64 TotalMay { get; set; }
        public Int64 DiffMay { get; set; }
        // Jun
        public string EffectiveDateJun { get; set; }
        public string TypeOfChangesJun { get; set; }
        public Int64 BaseSalaryJun { get; set; }
        public Int64 ResponsibilityAllowanceJun { get; set; }
        public Int64 HouseTransportJun { get; set; }
        public Int64 TelephoneJun { get; set; }
        public Int64 ShuiPayToEmployeeJun { get; set; }
        public Int64 TotalJun { get; set; }
        public Int64 DiffJun { get; set; }
        // Jul
        public string EffectiveDateJul { get; set; }
        public string TypeOfChangesJul { get; set; }
        public Int64 BaseSalaryJul { get; set; }
        public Int64 ResponsibilityAllowanceJul { get; set; }
        public Int64 HouseTransportJul { get; set; }
        public Int64 TelephoneJul { get; set; }
        public Int64 ShuiPayToEmployeeJul { get; set; }
        public Int64 TotalJul { get; set; }
        public Int64 DiffJul { get; set; }
        // Aug
        public string EffectiveDateAug { get; set; }
        public string TypeOfChangesAug { get; set; }
        public Int64 BaseSalaryAug { get; set; }
        public Int64 ResponsibilityAllowanceAug { get; set; }
        public Int64 HouseTransportAug { get; set; }
        public Int64 TelephoneAug { get; set; }
        public Int64 ShuiPayToEmployeeAug { get; set; }
        public Int64 TotalAug { get; set; }
        public Int64 DiffAug { get; set; }
        // Sep
        public string EffectiveDateSep { get; set; }
        public string TypeOfChangesSep { get; set; }
        public Int64 BaseSalarySep { get; set; }
        public Int64 ResponsibilityAllowanceSep { get; set; }
        public Int64 HouseTransportSep { get; set; }
        public Int64 TelephoneSep { get; set; }
        public Int64 ShuiPayToEmployeeSep { get; set; }
        public Int64 TotalSep { get; set; }
        public Int64 DiffSep { get; set; }
        // Oct
        public string EffectiveDateOct { get; set; }
        public string TypeOfChangesOct { get; set; }
        public Int64 BaseSalaryOct { get; set; }
        public Int64 ResponsibilityAllowanceOct { get; set; }
        public Int64 HouseTransportOct { get; set; }
        public Int64 TelephoneOct { get; set; }
        public Int64 ShuiPayToEmployeeOct { get; set; }
        public Int64 TotalOct { get; set; }
        public Int64 DiffOct { get; set; }
        // Nov
        public string EffectiveDateNov { get; set; }
        public string TypeOfChangesNov { get; set; }
        public Int64 BaseSalaryNov { get; set; }
        public Int64 ResponsibilityAllowanceNov { get; set; }
        public Int64 HouseTransportNov { get; set; }
        public Int64 TelephoneNov { get; set; }
        public Int64 ShuiPayToEmployeeNov { get; set; }
        public Int64 TotalNov { get; set; }
        public Int64 DiffNov { get; set; }
        // Dec
        public string EffectiveDateDec { get; set; }
        public string TypeOfChangesDec { get; set; }
        public Int64 BaseSalaryDec { get; set; }
        public Int64 ResponsibilityAllowanceDec { get; set; }
        public Int64 HouseTransportDec { get; set; }
        public Int64 TelephoneDec { get; set; }
        public Int64 ShuiPayToEmployeeDec { get; set; }
        public Int64 TotalDec { get; set; }
        public Int64 DiffDec { get; set; }
        public void InitSalary(SalaryInReportMoveModel salaryInMonth, int month)
        {
            switch (month)
            {
                case 1:
                    InitSalaryJan(salaryInMonth);
                    break;
                case 2:
                    InitSalaryFeb(salaryInMonth);
                    break;
                case 3:
                    InitSalaryMar(salaryInMonth);
                    break;

                case 4:
                    InitSalaryApr(salaryInMonth);

                    break;

                case 5:
                    InitSalaryMay(salaryInMonth);

                    break;

                case 6:
                    InitSalaryJun(salaryInMonth);

                    break;

                case 7:
                    InitSalaryJul(salaryInMonth);

                    break;

                case 8:
                    InitSalaryAug(salaryInMonth);

                    break;

                case 9:
                    InitSalarySep(salaryInMonth);

                    break;
                case 10:
                    InitSalaryOct(salaryInMonth);

                    break;
                case 11:
                    InitSalaryNov(salaryInMonth);

                    break;
                case 12:
                    InitSalaryDec(salaryInMonth);

                    break;
            }
        }

        private void InitSalaryJan(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateJan = salaryInMonth.EffectiveDate;
            TypeOfChangesJan = salaryInMonth.TypeOfChanges;
            BaseSalaryJan = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceJan = salaryInMonth.Responsibility;
            TelephoneJan = salaryInMonth.Telephone;
            HouseTransportJan = salaryInMonth.HouseTransport;
            TotalJan = salaryInMonth.Total;
        }

        private void InitSalaryDec(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateDec = salaryInMonth.EffectiveDate;
            TypeOfChangesDec = salaryInMonth.TypeOfChanges;
            BaseSalaryDec = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceDec = salaryInMonth.Responsibility;
            TelephoneDec = salaryInMonth.Telephone;
            HouseTransportDec = salaryInMonth.HouseTransport;
            TotalDec = salaryInMonth.Total;

        }

        private void InitSalaryNov(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateNov = salaryInMonth.EffectiveDate;
            TypeOfChangesNov = salaryInMonth.TypeOfChanges;
            BaseSalaryNov = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceNov = salaryInMonth.Responsibility;
            TelephoneNov = salaryInMonth.Telephone;
            HouseTransportNov = salaryInMonth.HouseTransport;
            TotalNov = salaryInMonth.Total;
        }

        private void InitSalaryOct(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateOct = salaryInMonth.EffectiveDate;
            TypeOfChangesOct = salaryInMonth.TypeOfChanges;
            BaseSalaryOct = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceOct = salaryInMonth.Responsibility;
            TelephoneOct = salaryInMonth.Telephone;
            HouseTransportOct = salaryInMonth.HouseTransport;
            TotalOct = salaryInMonth.Total;
        }

        private void InitSalarySep(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateSep = salaryInMonth.EffectiveDate;
            TypeOfChangesSep = salaryInMonth.TypeOfChanges;
            BaseSalarySep = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceSep = salaryInMonth.Responsibility;
            TelephoneSep = salaryInMonth.Telephone;
            HouseTransportSep = salaryInMonth.HouseTransport;
            TotalSep = salaryInMonth.Total;
        }

        private void InitSalaryAug(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateAug = salaryInMonth.EffectiveDate;
            TypeOfChangesAug = salaryInMonth.TypeOfChanges;
            BaseSalaryAug = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceAug = salaryInMonth.Responsibility;
            TelephoneAug = salaryInMonth.Telephone;
            HouseTransportAug = salaryInMonth.HouseTransport;
            TotalAug = salaryInMonth.Total; 
        }

        private void InitSalaryJul(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateJul = salaryInMonth.EffectiveDate;
            TypeOfChangesJul = salaryInMonth.TypeOfChanges;
            BaseSalaryJul = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceJul = salaryInMonth.Responsibility;
            TelephoneJul = salaryInMonth.Telephone;
            HouseTransportJul = salaryInMonth.HouseTransport;
            TotalJul = salaryInMonth.Total; 
        }

        private void InitSalaryJun(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateJun = salaryInMonth.EffectiveDate;
            TypeOfChangesJun = salaryInMonth.TypeOfChanges;
            BaseSalaryJun = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceJun = salaryInMonth.Responsibility;
            TelephoneJun = salaryInMonth.Telephone;
            HouseTransportJun = salaryInMonth.HouseTransport;
            TotalJun = salaryInMonth.Total;
        }

        private void InitSalaryApr(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateApr = salaryInMonth.EffectiveDate;
            TypeOfChangesApr = salaryInMonth.TypeOfChanges;
            BaseSalaryApr = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceApr = salaryInMonth.Responsibility;
            TelephoneApr = salaryInMonth.Telephone;
            HouseTransportApr = salaryInMonth.HouseTransport;
            TotalApr = salaryInMonth.Total;
        }

        private void InitSalaryMar(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateMar = salaryInMonth.EffectiveDate;
            TypeOfChangesMar = salaryInMonth.TypeOfChanges;
            BaseSalaryMar = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceMar = salaryInMonth.Responsibility;
            TelephoneMar = salaryInMonth.Telephone;
            HouseTransportMar = salaryInMonth.HouseTransport;
            TotalMar = salaryInMonth.Total;
        }

        public void InitSalaryMay(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateMay = salaryInMonth.EffectiveDate;
            TypeOfChangesMay = salaryInMonth.TypeOfChanges;
            BaseSalaryMay = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceMay = salaryInMonth.Responsibility;
            TelephoneMay = salaryInMonth.Telephone;
            HouseTransportMay = salaryInMonth.HouseTransport;
            TotalMay = salaryInMonth.Total;
        }
        public void InitSalaryFeb(SalaryInReportMoveModel salaryInMonth)
        {
            EffectiveDateFeb = salaryInMonth.EffectiveDate;
            TypeOfChangesFeb = salaryInMonth.TypeOfChanges;
            BaseSalaryFeb = salaryInMonth.BaseSalary;
            ResponsibilityAllowanceFeb = salaryInMonth.Responsibility;
            TelephoneFeb = salaryInMonth.Telephone;
            HouseTransportFeb = salaryInMonth.HouseTransport;
            TotalFeb = salaryInMonth.Total;
        }
    }
}
