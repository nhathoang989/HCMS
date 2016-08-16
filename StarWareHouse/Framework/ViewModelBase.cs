using StarWareHouse.ViewInterfaces;
using StarWareHouse.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace StarWareHouse.Framework
{
    public class ViewModelBase<ViewType> : ObjectBase
    where ViewType : ViewInterfaces.IView
    {
        #region Fields

        private ICommand _changePageCommand;

        private IView _currentPageViewModel;
        private List<IView> _pageViewModels;

        #endregion        

        private readonly ViewType view;
        public ViewType View
        {
            get
            {
                return this.view;
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
                        p => ChangeViewModel((IView)p),
                        p => p is IView);
                }

                return _changePageCommand;
            }
        }

        public List<IView> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IView>();

                return _pageViewModels;
            }
        }

        public IView CurrentPageViewModel
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

        public ViewModelBase(ViewType view)
        {
            this.view = view;
            this.View.DataContext = this;
        }

        public ViewModelBase()
        {
            // Add available pages
            PageViewModels.Add(new HomeViewModel());
            PageViewModels.Add(new LoginViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        private void ChangeViewModel(IView viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }
    }
}
