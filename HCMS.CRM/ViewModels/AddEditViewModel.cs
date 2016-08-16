using HCMS.CRM.Framework;
using HCMS.CRM.Views;

namespace HCMS.CRM.ViewModels
{
    class AddEditViewModel : ViewModelBase<ViewInterfaces.IDialogView>
    {
        private const string EDIT_MODE_TITLE = "Edit";
        private const string ADD_MODE_TITLE = "Add";
        private const string SAVE_ERROR_MESSAGE = "Saving operation failed! Internal error has occured. Exception message:\r\n";
        private const string SAVE_ERROR_TITLE = "Error";

        private readonly SofiaCarRentalContext context;
        private string title;
        private int? currentCarId;
        private Car currentCar;
        private Framework.RelayCommandbk command;

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                this.title = value.Trim();
            }
        }
        public Car CurrentCar
        {
            get
            {
                return this.currentCar;
            }
            private set
            {
                this.currentCar = value;
            }
        }

        public bool? OperationIsSuccessful
        {
            get
            {
                return this.View.DialogResult;
            }
            private set
            {
                this.View.DialogResult = value;
            }
        }

        public AddEditViewModel(int? currentCarId)
    : base(new AddEditWindow())
        {
            this.context = new SofiaCarRentalContext();
            this.currentCarId = currentCarId;
        }

        public bool? ShowDialog()
        {
            return this.View.ShowDialog();
        }
    }
}
