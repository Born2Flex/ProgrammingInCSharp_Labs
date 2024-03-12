﻿using System;
using System.ComponentModel;
using KMA.ProgrammingInCSharp.Navigation;
using KMA.ProgrammingInCSharp.Utils.Tools;

namespace KMA.ProgrammingInCSharp.ViewModels;

public class ResultViewModel: INavigatable<BaseNavigationTypes>, INotifyPropertyChanged
{
    #region Fields

    private RelayCommand<object> _backCommand;
    private Action _gotoInput;

    #endregion

    #region Properties

    public RelayCommand<object> GoBackCommand
    {
        get { return _backCommand ??= new RelayCommand<object>(_ => GotoInput()); }
    }
    
    private void GotoInput()
    {
        _gotoInput.Invoke();
    }
    
    public BaseNavigationTypes ViewType
    {
        get { return BaseNavigationTypes.ShowResult; }
    }

    #endregion
    
    public ResultViewModel(Action gotoInput)
    {
        _gotoInput = gotoInput;
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}