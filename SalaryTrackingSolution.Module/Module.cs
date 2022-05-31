using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using System.Data.Entity;
using SalaryTrackingSolution.Module.BusinessObjects;
using DevExpress.ExpressApp.ReportsV2;
using SalaryTrackingSolution.Module.UI.Model;
using DevExpress.XtraPrinting.Native;
using StructureMap.Pipeline;

namespace SalaryTrackingSolution.Module {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    public sealed partial class SalaryTrackingSolutionModule : ModuleBase {
        static SalaryTrackingSolutionModule() {
            DevExpress.Data.Linq.CriteriaToEFExpressionConverter.SqlFunctionsType = typeof(System.Data.Entity.SqlServer.SqlFunctions);
			DevExpress.Data.Linq.CriteriaToEFExpressionConverter.EntityFunctionsType = typeof(System.Data.Entity.DbFunctions);
			DevExpress.ExpressApp.SystemModule.ResetViewSettingsController.DefaultAllowRecreateView = false;
            // Uncomment this code to delete and recreate the database each time the data model has changed.
            // Do not use this code in a production environment to avoid data loss.
            // #if DEBUG
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SalaryTrackingSolutionDbContext>());
            // #endif 
        }

        private SalaryTrackingSolutionDbContext _context;
        public SalaryTrackingSolutionModule() {
            InitializeComponent();
            _context = new SalaryTrackingSolutionDbContext("ConnectionString");
			DevExpress.ExpressApp.Security.SecurityModule.UsedExportedTypes = DevExpress.Persistent.Base.UsedExportedTypes.Custom;
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
            application.SetupComplete += Application_SetupComplete;

        }
        public override void Setup(ApplicationModulesManager moduleManager) {
            base.Setup(moduleManager);
			ReportsModuleV2 reportModule = moduleManager.Modules.FindModule<ReportsModuleV2>();
            reportModule.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.EF.ReportDataV2);

        }
        private void Application_SetupComplete(object sender, EventArgs e)
        {
            Application.ObjectSpaceCreated += Application_ObjectSpaceCreated;
        }
        private void Application_ObjectSpaceCreated(object sender, ObjectSpaceCreatedEventArgs e)
        {
            var nonPersistentObjectSpace = e.ObjectSpace as NonPersistentObjectSpace;
            if (nonPersistentObjectSpace != null)
            {
                nonPersistentObjectSpace.ObjectByKeyGetting += nonPersistentObjectSpace_ObjectByKeyGetting;
                nonPersistentObjectSpace.ObjectsGetting += NonPersistentObjectSpace_ObjectsGetting;
                nonPersistentObjectSpace.Committing += NonPersistentObjectSpace_Committing;


            }
            CompositeObjectSpace compositeObjectSpace = e.ObjectSpace as CompositeObjectSpace;
            if (compositeObjectSpace != null)
            {
                if (!(compositeObjectSpace.Owner is CompositeObjectSpace))
                {
                    compositeObjectSpace.PopulateAdditionalObjectSpaces((XafApplication)sender);
                }
            }
        }

        private void NonPersistentObjectSpace_Committing(object sender, CancelEventArgs e)
        {
            IObjectSpace objectSpace = (IObjectSpace)sender;
            foreach (Object obj in objectSpace.ModifiedObjects)
            {
                ShowDetailSalaryInformation myobj = obj as ShowDetailSalaryInformation;
                if (obj != null)
                {
                }
            }
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
        private void NonPersistentObjectSpace_ObjectsGetting(object sender, ObjectsGettingEventArgs e)
        {
            ShowDetailSalaryInformation a = new ShowDetailSalaryInformation();
            
            if (e.ObjectType == typeof(ShowDetailSalaryInformation))
            {
                IObjectSpace objectSpace = (IObjectSpace)sender;
                BindingList<ShowDetailSalaryInformation> objects = new BindingList<ShowDetailSalaryInformation>();
                var listSalary = _context.Salaries.ToList();
                objects.AllowEdit = true;
                
                foreach (var salary in listSalary)
                {
                    objects.Add(objectSpace.GetObject(ConvertToDetailSalaryInformation(salary)));
                }
                e.Objects = objects;
            }
        }

        private void nonPersistentObjectSpace_ObjectByKeyGetting(object sender, ObjectByKeyGettingEventArgs e)
        {
            IObjectSpace objectSpace = (IObjectSpace)sender;
            
            if (e.ObjectType == typeof(ShowDetailSalaryInformation))
            {
                BindingList<ShowDetailSalaryInformation> objects = new BindingList<ShowDetailSalaryInformation>();
                
            }
            else if (e.ObjectType.IsAssignableFrom(typeof(AddNewEmployeeModel)))
            {
                if ((Convert.ToInt64(e.Key)) == 138)
                {
                    AddNewEmployeeModel obj138 = objectSpace.CreateObject<AddNewEmployeeModel>();
                    obj138.Id = 138;
                    e.Object = obj138;
                }
               
            }
            else if (e.ObjectType == typeof(SignContractModel))
            {
                if ((Convert.ToInt64(e.Key)) == 141)
                {
                    SignContractModel obj138 = objectSpace.CreateObject<SignContractModel>();
                    obj138.Id = 141;
                    e.Object = obj138;
                }
            }
            else if (e.ObjectType == typeof(ReviewSalaryModel))
            {
                if ((Convert.ToInt64(e.Key)) == 143)
                {
                    ReviewSalaryModel obj138 = objectSpace.CreateObject<ReviewSalaryModel>();
                    obj138.Id = 143;
                    e.Object = obj138;
                }
            }
            else if (e.ObjectType == typeof(PromotionModel))
            {
                if ((Convert.ToInt64(e.Key)) == 145)
                {
                    PromotionModel obj138 = objectSpace.CreateObject<PromotionModel>();
                    obj138.Id = 145;
                    e.Object = obj138;
                }
            }
            else if (e.ObjectType == typeof(DemotionModel))
            {
                if ((Convert.ToInt64(e.Key)) == 147)
                {
                    DemotionModel obj138 = objectSpace.CreateObject<DemotionModel>();
                    obj138.Id = 147;
                    e.Object = obj138;
                }
            }
        }
    }
}
