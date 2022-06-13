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
using DevExpress.ExpressApp.ConditionalAppearance;
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
                nonPersistentObjectSpace.AutoRefreshAdditionalObjectSpaces = true;
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
            else 
            if (e.ObjectType == typeof(IndividualSalary))
            {
                IObjectSpace objectSpace = (IObjectSpace)sender;
                BindingList<IndividualSalary> objects = new BindingList<IndividualSalary>();
                var listEmployee = _context.Employees.ToList();
                foreach (var employee in listEmployee)
                {
                    objects.Add(objectSpace.GetObject(ConvertSalaryToIndividualSalary(employee)));
                }
                e.Objects = DistinctIndividual(objects);
            }
        }

        private void nonPersistentObjectSpace_ObjectByKeyGetting(object sender, ObjectByKeyGettingEventArgs e)
        {
            IObjectSpace objectSpace = (IObjectSpace)sender;
            if (e.ObjectType == typeof(ShowDetailSalaryInformation))
            {
                BindingList<ShowDetailSalaryInformation> objects = new BindingList<ShowDetailSalaryInformation>();
                if (Convert.ToInt64(e.Key) == 161)
                {
                    ShowDetailSalaryInformation obj138 = objectSpace.CreateObject<ShowDetailSalaryInformation>();
                    obj138.Id = 161;
                    e.Object = obj138;
                }
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
            else if (e.ObjectType == typeof(IndividualSalary))
            {
                if ((Convert.ToInt64(e.Key)) == 151)
                {
                    IndividualSalary obj138 = objectSpace.CreateObject<IndividualSalary>();
                    obj138.Id = 151;
                    e.Object = obj138;
                }
                if ((Convert.ToInt64(e.Key)) == 171)
                {
                    IndividualSalary obj138 = objectSpace.CreateObject<IndividualSalary>();
                    obj138.Id = 171;
                    e.Object = obj138;
                }
            }
            else if (e.ObjectType == typeof(MoveSalaryModel))
            {
                if ((Convert.ToInt64(e.Key)) == 163)
                {
                    MoveSalaryModel obj138 = objectSpace.CreateObject<MoveSalaryModel>();
                    obj138.Id = 163;
                    e.Object = obj138;
                }
            }
            else if (e.ObjectType == typeof(SummaryModel))
            {
                if ((Convert.ToInt64(e.Key)) == 201)
                {
                    SummaryModel obj138 = objectSpace.CreateObject<SummaryModel>();
                    obj138.Id = 201;
                    e.Object = obj138;
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
        private List<SalaryInIndividual> CreateHistory(Employee employee)
        {
            var listSalaryInIndividual = new List<SalaryInIndividual>();
            var listHistorySalaries = _context.HistorySalaries.ToList()
                .Where(x => x.Employee.GlobalId == employee.GlobalId).ToList();
            for(int i = 0; i < listHistorySalaries.Count - 1; i++)
            {
                var salary = listHistorySalaries.ElementAt(i);
                var date = listHistorySalaries.ElementAt(i + 1).UpdateAt;
                listSalaryInIndividual.Add(new SalaryInIndividual
                {
                    Time = salary.UpdateAt.ToShortDateString()
                    + "-" + new DateTime(date.Year, date.Month, 1).ToShortDateString(),
                    TypeOfChanges = salary.TypeOfChanges,
                    BaseSalary = salary.BaseSalaryNew,
                    Responsibility = salary.ResponsibilityNew,
                    Telephone = salary.TelephoneNew,
                    ShuiPayToEmployee = salary.ShuiPayToEmployeeNew,
                    HouseTransport = salary.HouseTransportNew,

                });
            }
            var last = listHistorySalaries.Last();
            listSalaryInIndividual.Add(new SalaryInIndividual
            {
                Time = new DateTime(last.UpdateAt.Year, last.UpdateAt.Month, 1).ToShortDateString()+ "-now",
                TypeOfChanges = last.TypeOfChanges,
                BaseSalary = last.BaseSalaryNew,
                Responsibility = last.ResponsibilityNew,
                Telephone = last.TelephoneNew,
                ShuiPayToEmployee = last.ShuiPayToEmployeeNew,
                HouseTransport = last.HouseTransportNew,

            });
            return listSalaryInIndividual;
        }
        private IndividualSalary ConvertSalaryToIndividualSalary(Employee employee)
        {
            return new IndividualSalary()
            {
                GlobalId = employee.GlobalId,
                History = CreateHistory(employee)
            };
        }

        private BindingList<IndividualSalary> DistinctIndividual(BindingList<IndividualSalary> objects)
        {
            var temp = objects.OrderByDescending(x => x.GlobalId).ToList();
            for (int i = 0; i < temp.Count - 1; i++)
            {
                if (temp[i].GlobalId == temp[i + 1].GlobalId)
                {
                    temp.RemoveAt(i);
                }
            }

            return new BindingList<IndividualSalary>(temp);
        }
    }
}
