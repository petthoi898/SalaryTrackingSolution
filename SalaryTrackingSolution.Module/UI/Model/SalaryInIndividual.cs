using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryTrackingSolution.Module.UI.Model
{
    public class SalaryInIndividual
    {
        public string Time { get; set; }
        public string TypeOfChanges { get; set; }
        public Int64 BaseSalary { get; set; }
        public Int64 Responsibility { get; set; }
        public Int64 HouseTransport { get; set; }
        public Int64 Telephone { get; set; }
        public Int64 ShuiPayToEmployee { get; set; }
        public Int64 Total => BaseSalary + Responsibility + HouseTransport + ShuiPayToEmployee;
        public string Remark { get; set; }
    }
}
