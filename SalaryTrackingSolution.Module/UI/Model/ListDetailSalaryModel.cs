using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Data;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using SalaryTrackingSolution.Module.BusinessObjects;

namespace SalaryTrackingSolution.Module.UI.Model
{
    [DomainComponent, DefaultClassOptions]

    public class ListDetailSalaryModel : NonPersistentLiteObject
    {
        [Key]
        public Int16 Id { get; set; }

        public Guid LocalId { get; set; }
        public Employee Employee { get; set; }
        public ShowDetailSalaryInformation DetailSalaryInformation { get; set; }
    }
}
