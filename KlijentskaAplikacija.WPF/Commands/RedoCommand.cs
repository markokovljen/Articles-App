using KlijentskaAplikacija.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.Commands
{
    public class RedoCommand : ICommand
    {
        private readonly HomeViewModel homeViewModel;

        public RedoCommand(HomeViewModel homeViewModel)
        {
            this.homeViewModel = homeViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (homeViewModel.Index + 1 == homeViewModel.History.Count)
                return;

            homeViewModel.Index++;
            homeViewModel.History[homeViewModel.Index].Execute("redo");
        }
    }
}
