using KlijentskaAplikacija.WPF.Commands;
using KlijentskaAplikacija.WPF.ViewModels;
using KlijentskaAplikacija.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.State.Navigators
{
    public class Navigator :ObservableObject ,INavigator
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return currentViewModel;
            }
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(currentViewModel));
            }
        }
       

       
        
    }
}
