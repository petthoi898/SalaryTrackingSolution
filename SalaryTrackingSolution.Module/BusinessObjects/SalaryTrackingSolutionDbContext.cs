using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EF.DesignTime;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using SalaryTrackingSolution.Module.UI.Model;

namespace SalaryTrackingSolution.Module.BusinessObjects {
	public class SalaryTrackingSolutionContextInitializer : DbContextTypesInfoInitializerBase {
		protected override DbContext CreateDbContext() {
			DbContextInfo contextInfo = new DbContextInfo(typeof(SalaryTrackingSolutionDbContext), new DbProviderInfo(providerInvariantName: "System.Data.SqlClient", providerManifestToken: "2008"));
            return contextInfo.CreateInstance();
		}
	}
	[TypesInfoInitializer(typeof(SalaryTrackingSolutionContextInitializer))]
	public class SalaryTrackingSolutionDbContext : DbContext {
		public SalaryTrackingSolutionDbContext(String connectionString)
			: base(connectionString) {
		}
		public SalaryTrackingSolutionDbContext(DbConnection connection)
			: base(connection, false) {
		}
		public SalaryTrackingSolutionDbContext() {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
	    public DbSet<PermissionPolicyRole> Roles { get; set; }
		public DbSet<PermissionPolicyTypePermissionObject> TypePermissionObjects { get; set; }
		public DbSet<SalaryTrackingSolution.Module.BusinessObjects.ApplicationUser> Users { get; set; }
		public DbSet<SalaryTrackingSolution.Module.BusinessObjects.ApplicationUserLoginInfo> UserLoginInfos { get; set; }
		public DbSet<FileData> FileData { get; set; }
		public DbSet<ReportDataV2> ReportDataV2 { get; set; }
		public DbSet<ModelDifference> ModelDifferences { get; set; }
		public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<AllowanceCode> AllowanceCodes { get; set; }
        public DbSet<HistoryAllowance> HistoryAllowances { get; set; }
        public DbSet<HistorySalary> HistorySalaries { get; set; }
		//public DbSet<AddNewEmployeeModel>	AddNewEmployeeModels { get; set; }
        public DbSet<Contract> Contracts { get; set; }
		public DbSet<Segment> Segments { get; set; }

    }
}
