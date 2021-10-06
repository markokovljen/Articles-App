using System;
using System.Collections.Generic;
using System.Text;

namespace KlijentskaAplikacija.WPF.ViewModels.Factories
{
    public interface IViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
