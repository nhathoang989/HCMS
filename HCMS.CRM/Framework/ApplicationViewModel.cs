using DevExpress.Mvvm;
using HCMS.CRM.ViewInterfaces;
using HCMS.CRM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCMS.CRM.Framework
{
    public class ApplicationViewModel : ObjectBase
    {
        #region Fields

        private ICommand _changePageCommand;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        #endregion

        public ApplicationViewModel()
        {
            // Add available pages
            PageViewModels.Add(new LoginViewModel());
            PageViewModels.Add(new HomeViewModel());

            // Set starting page
            if (!App.currUser.IsAuth)
            {
                CurrentPageViewModel = PageViewModels[0];
            }
            else {
                CurrentPageViewModel = PageViewModels[1];
            }
            
        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((string)p),
                        p => p is string);
                }

                return _changePageCommand;
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        #endregion

        #region Methods

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        private void ChangeViewModel(string pageArg)
        {
            var viewModel = Helpers.MenuHelper.GetPageView(pageArg);
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        #endregion
    }
}
