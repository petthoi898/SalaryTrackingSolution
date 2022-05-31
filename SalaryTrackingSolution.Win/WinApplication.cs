using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using System.Collections.Generic;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Win.Utils;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.EF;
using SalaryTrackingSolution.Module;
using SalaryTrackingSolution.Module.BusinessObjects;
using System.Data.Common;

namespace SalaryTrackingSolution.Win {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Win.WinApplication._members
    public partial class SalaryTrackingSolutionWindowsFormsApplication : WinApplication {
        public SalaryTrackingSolutionWindowsFormsApplication() {
			InitializeComponent();
			SplashScreen = new DXSplashScreen(typeof(XafSplashScreen), new DefaultOverlayFormOptions());
        }
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            if(args.Connection != null) {
                args.ObjectSpaceProviders.Add(new EFObjectSpaceProvider(typeof(SalaryTrackingSolutionDbContext), TypesInfo, null, (DbConnection)args.Connection));
            }
            else {
                args.ObjectSpaceProviders.Add(new EFObjectSpaceProvider(typeof(SalaryTrackingSolutionDbContext), TypesInfo, null, args.ConnectionString));
            }
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
        }
        private void SalaryTrackingSolutionWindowsFormsApplication_CustomizeLanguagesList(object sender, CustomizeLanguagesListEventArgs e) {
            string userLanguageName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            if(userLanguageName != "en-US" && e.Languages.IndexOf(userLanguageName) == -1) {
                e.Languages.Add(userLanguageName);
            }
        }
        private void SalaryTrackingSolutionWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
            e.Updater.Update();
            e.Handled = true;
#else
            if(System.Diagnostics.Debugger.IsAttached) {
                e.Updater.Update();
                e.Handled = true;
            }
            else {
				string message = "The application cannot connect to the specified database, " +
					"because the database doesn't exist, its version is older " +
					"than that of the application or its schema does not match " +
					"the ORM data model structure. To avoid this error, use one " +
					"of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

				if(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
					message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
				}
				throw new InvalidOperationException(message);
            }
#endif
        }
    }
}
