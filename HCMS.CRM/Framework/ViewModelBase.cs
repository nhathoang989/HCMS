using DevExpress.Mvvm;
using HCMS.CRM.ViewInterfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace HCMS.CRM.Framework
{
    public class ViewModelBase<ViewType> : ObjectBase
    where ViewType : ViewInterfaces.IView
    {
        public virtual string Title
        {
            get { return string.Empty; }
        }

        private readonly ViewType view;

        public ViewType View
        {
            get
            {
                return this.view;
            }
        }
        public ViewModelBase(ViewType view)
        {
            this.view = view;
            this.View.DataContext = this;
        }        
    }
}
