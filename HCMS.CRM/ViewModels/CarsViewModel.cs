using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCMS.CRM.ViewInterfaces;
using HCMS.CRM.Framework;

namespace HCMS.CRM.ViewModels
{
    public class CarsViewModel : ViewModelBase<ViewInterfaces.IMainView>
    {
        private const string STATUS_MESSAGE = "{0} cars retrieved from the database.";
        private const string CONFIRM_DELETE_MESSAGE = "You are about to delete {0} {1}. Are you sure?";
        private const string CONFIRM_DELETE_TITLE = "Confirm delete.";
        private const string DELETE_ERROR_RELATED_ENTRY_MESSAGE =
            "Could not delete this car entry because other entries related to it exist " +
            "in the database. Exception message:\r\n";
        private const string DELETE_ERROR_MESSAGE = "Internal error has occured. Exception message:\r\n";
        private const string DELETE_ERROR_TITLE = "Deletion error!";

        private readonly SofiaCarRentalContext context;
        private string carMakerFilter;
        private bool isFilteringActive;
        private string status;
        private List<Car> carsToDisplay;
        private Car selectedCar;
        private Framework.RelayCommandbk command;

        public string CarMakerFilter
        {
            get
            {
                return this.carMakerFilter;
            }
            set
            {
                this.carMakerFilter = value.Trim();
                this.RaisePropertyChanged("CarMakerFilter");
            }
        }
        public string Status
        {
            get
            {
                return this.status;
            }
            private set
            {
                this.status = value.Trim();
                this.RaisePropertyChanged("Status");
            }
        }
        public List<Car> CarsToDisplay
        {
            get
            {
                return this.carsToDisplay;
            }
            private set
            {
                this.carsToDisplay = value;
                this.RaisePropertyChanged("CarsToDisplay");
            }
        }
        public Car SelectedCar
        {
            get
            {
                return this.selectedCar;
            }
            set
            {
                this.selectedCar = value;
                this.RaisePropertyChanged("SelectedCar");
            }
        }
        public CarsViewModel(IMainView view) : base(view)
        {
            this.context = new SofiaCarRentalContext();
            this.CarMakerFilter = string.Empty;
            this.isFilteringActive = false;
            this.Status = string.Empty;
        }
    }

    internal class SofiaCarRentalContext
    {
    }

    public class Car
    {
    }
}
