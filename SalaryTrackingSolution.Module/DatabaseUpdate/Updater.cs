using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.EF;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using SalaryTrackingSolution.Module.BusinessObjects;

namespace SalaryTrackingSolution.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            //string name = "MyName";
            //EntityObject1 theObject = ObjectSpace.FirstOrDefault<EntityObject1>(u => u.Name == name);
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<EntityObject1>();
            //    theObject.Name = name;
            //}
            ApplicationUser sampleUser = ObjectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "User");
            if(sampleUser == null) {
                sampleUser = ObjectSpace.CreateObject<ApplicationUser>();
                sampleUser.UserName = "User";
                // Set a password if the standard authentication type is used
                sampleUser.SetPassword("");

                // The UserLoginInfo object requires a user object Id (Oid).
                // Commit the user object to the database before you create a UserLoginInfo object. This will correctly initialize the user key property.
                ObjectSpace.CommitChanges(); //This line persists created object(s).
                ((ISecurityUserWithLoginInfo)sampleUser).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(sampleUser));
            }
            PermissionPolicyRole defaultRole = CreateDefaultRole();
            sampleUser.Roles.Add(defaultRole);

            ApplicationUser userAdmin = ObjectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "Admin");
            if(userAdmin == null) {
                userAdmin = ObjectSpace.CreateObject<ApplicationUser>();
                userAdmin.UserName = "Admin";
                // Set a password if the standard authentication type is used
                userAdmin.SetPassword("");

                // The UserLoginInfo object requires a user object Id (Oid).
                // Commit the user object to the database before you create a UserLoginInfo object. This will correctly initialize the user key property.
                ObjectSpace.CommitChanges(); //This line persists created object(s).
                ((ISecurityUserWithLoginInfo)userAdmin).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(userAdmin));
            }
			// If a role with the Administrators name doesn't exist in the database, create this role
            PermissionPolicyRole adminRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(r => r.Name == "Administrators");
            if(adminRole == null) {
                adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                adminRole.Name = "Administrators";
            }
            adminRole.IsAdministrative = true;
			userAdmin.Roles.Add(adminRole);
            ObjectSpace.CommitChanges(); //This line persists created object(s).
            InitSegment();
            InitTypeOfContracts();
            InitTypeOfContractsNewHire();
            InitDepartment();
            //InitEmployee();

        }
        private void InitDepartment()
        {
            var segment = ObjectSpace.FirstOrDefault<Department>(x => x.Name == "Software");
            if (segment == null)
            {
                segment = ObjectSpace.CreateObject<Department>();
                segment.Name = "Software";
            }
            var segment1 = ObjectSpace.FirstOrDefault<Department>(x => x.Name == "Tester");
            if (segment1 == null)
            {
                segment1 = ObjectSpace.CreateObject<Department>();
                segment1.Name = "Tester";
            }
            ObjectSpace.CommitChanges();
        }
        private Employee CreateEmployee(string name)
        {
            return new Employee()
            {
                Active = true,
                FirstName = name,
                GlobalId = (new Random()).Next(1, 10000000).ToString(),
                LocalId = (new Random()).Next(1, 1000000).ToString(),
                MiddleName = name,
                LastName = name,
                JoinDate = DateTime.Now
            };
        }
        private void InitSegment()
        {
            var segment = ObjectSpace.FirstOrDefault<Segment>(x => x.Name == "Supplier");
            if (segment == null)
            {
                segment = ObjectSpace.CreateObject<Segment>();
                segment.Name = "Supplier";
            }
            var segment1 = ObjectSpace.FirstOrDefault<Segment>(x => x.Name == "Builder");
            if (segment1 == null)
            {
                segment1 = ObjectSpace.CreateObject<Segment>();
                segment1.Name = "Builder";
            }
            ObjectSpace.CommitChanges();
            
        }

        private void InitTypeOfContractsNewHire()
        {
            var segment = ObjectSpace.FirstOrDefault<TypeOfContractsNewHire>(x => x.Name == StaticFile.TypeOfContracts.ProbationContract);
            if (segment == null)
            {
                segment = ObjectSpace.CreateObject<TypeOfContractsNewHire>();
                segment.Name = StaticFile.TypeOfContracts.ProbationContract;
            }
            var segment3 = ObjectSpace.FirstOrDefault<TypeOfContractsNewHire>(x => x.Name == StaticFile.TypeOfContracts.TrainingContract);
            if (segment3 == null)
            {
                segment3 = ObjectSpace.CreateObject<TypeOfContractsNewHire>();
                segment3.Name = StaticFile.TypeOfContracts.TrainingContract;

            }
            ObjectSpace.CommitChanges();
        }
        private void InitTypeOfContracts()
        {
            var segment = ObjectSpace.FirstOrDefault<TypeOfContracts>(x => x.Name == StaticFile.TypeOfContracts.OfficialContractWithPeriod);
            if (segment == null)
            {
                segment = ObjectSpace.CreateObject<TypeOfContracts>();
                segment.Name = StaticFile.TypeOfContracts.OfficialContractWithPeriod;
            }
            var segment3 = ObjectSpace.FirstOrDefault<TypeOfContracts>(x => x.Name == StaticFile.TypeOfContracts.OfficialContractWithoutPeriod);
            if (segment3 == null)
            {
                segment3 = ObjectSpace.CreateObject<TypeOfContracts>();
                segment3.Name = StaticFile.TypeOfContracts.OfficialContractWithoutPeriod;

            }
            ObjectSpace.CommitChanges();

        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
        }
        private PermissionPolicyRole CreateDefaultRole() {
            PermissionPolicyRole defaultRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(role => role.Name == "Default");
            if(defaultRole == null) {
                defaultRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                defaultRole.Name = "Default";

                defaultRole.AddObjectPermissionFromLambda<ApplicationUser>(SecurityOperations.Read, cm => cm.ID == (int)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
                defaultRole.AddNavigationPermission(@"Application/NavigationItems/Items/Default/Items/MyDetails", SecurityPermissionState.Allow);
                defaultRole.AddMemberPermissionFromLambda<ApplicationUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", cm => cm.ID == (int)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
                defaultRole.AddMemberPermissionFromLambda<ApplicationUser>(SecurityOperations.Write, "StoredPassword", cm => cm.ID == (int)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<PermissionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Deny);
                defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
				defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.Create, SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.Create, SecurityPermissionState.Allow);
            }
            return defaultRole;
        }
    }
}
