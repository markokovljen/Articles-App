using KlijentskaAplikacija.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.Commands
{
    public class UndoCommand : ICommand
    {
        private readonly HomeViewModel homeViewModel;

        public UndoCommand(HomeViewModel homeViewModel)
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
            if (homeViewModel.Index < 0)
                return;

            homeViewModel.History[homeViewModel.Index].UnExecute();
            homeViewModel.Index--;
        }
    }
}
