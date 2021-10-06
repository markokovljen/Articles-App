using KlijentskaAplikacija.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.State.Navigators
{
    public enum ViewType
    {
        Login,
        Home,
        AddUser,
        ModifyProfile
        
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        
    }
}
