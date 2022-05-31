using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using DevExpress.ExpressApp.Data;

namespace SalaryTrackingSolution.Module.BusinessObjects
{
    // Register this entity in the DbContext using the "public DbSet<Employee> Employees { get; set; }" syntax.
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("FullName")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Employee : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        public Employee()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new List<AssociatedEntityObject>();
        }
        [Browsable(false)]  // Hide the entity identifier from UI.
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        private string localId;
        public string LocalId
        {
            get => localId;
            set
            {
                if (localId != value)
                {
                    localId = value;
                    OnPropertyChanged();
                }
            }

        }
        private string globalId;

        public string GlobalId
        {
            get => globalId;
            set
            {
                if (globalId != value)
                {
                    globalId = value;
                    OnPropertyChanged();
                }
            }

        }
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string middleName;

        public string MiddleName
        {
            get => middleName;
            set
            {
                if (middleName != value)
                {
                    middleName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FullName
        {
            get => ObjectFormatter.Format($"{FirstName} {MiddleName} {LastName}", this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);
        }

        private string segment;

        public string Segment
        {
            get => segment;
            set
            {
                if (segment != value)
                {
                    segment = value;
                    OnPropertyChanged();
                }
            }
        }
        private Int64 trialSalary;

        public Int64 TrialSalary
        {
            get => trialSalary;
            set
            {
                trialSalary = value;
                OnPropertyChanged();
            
            }
        }

        private string traineeShipContractNo;
        public string TraineeShipContractNo
        {
            get => traineeShipContractNo;
            set
            {
                if (traineeShipContractNo != value)
                {
                    traineeShipContractNo = value;
                    OnPropertyChanged();
                }
            }

        }
        private Int64 probationSalary;

        public Int64 ProbationSalary
        {
            get => probationSalary;
            set
            {
                probationSalary = value;
                OnPropertyChanged();
            }
        }

        private string probationaryContractNo;
        public string ProbationaryContractNo
        {
            get => probationaryContractNo;
            set
            {
                if (probationaryContractNo != value)
                {
                    probationaryContractNo = value;
                    OnPropertyChanged();
                }
            }

        }
        private string note;
        public string Note
        {
            get => note;
            set
            {
                if (note != value)
                {
                    note = value;
                    OnPropertyChanged();
                }
            }

        }

        private DateTime? joinDate;
        public DateTime? JoinDate
        {
            get => joinDate;
            set
            {
                if (joinDate != value)
                {
                    joinDate = value;
                    OnPropertyChanged();
                }
            }
        }
        private DateTime? endDate;

        public DateTime? EndDate
        {
            get => endDate;
            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool active;

        public bool Active
        {
            get => active;
            set
            {
                active = value;
                OnPropertyChanged();
            }
        }
       
        #region IXafEntityObject members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIXafEntityObjecttopic.aspx)
        void IXafEntityObject.OnCreated()
        {
            // Place the entity initialization code here.
            // You can initialize reference properties using Object Space methods; e.g.:
            // this.Address = objectSpace.CreateObject<Address>();
        }
        void IXafEntityObject.OnLoaded()
        {
            // Place the code that is executed each time the entity is loaded here.
        }
        void IXafEntityObject.OnSaving()
        {
            // Place the code that is executed each time the entity is saved here.
        }
        #endregion

        #region IObjectSpaceLink members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIObjectSpaceLinktopic.aspx)
        // Use the Object Space to access other entities from IXafEntityObject methods (see https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113707.aspx).
        private IObjectSpace objectSpace;
        IObjectSpace IObjectSpaceLink.ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
        #endregion

        #region INotifyPropertyChanged members (see http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged(v=vs.110).aspx)
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
