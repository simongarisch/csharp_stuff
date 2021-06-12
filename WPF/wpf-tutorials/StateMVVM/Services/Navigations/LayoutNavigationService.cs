﻿using MVVMEssentials.ViewModels;
using StateMVVM.Stores;
using StateMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateMVVM.Services.Navigations
{
    public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly CreateViewModel<TViewModel> _createViewModel;
        private readonly CreateViewModel<GlobalMessageViewModel> _createGlobalMessageViewModel;
        private readonly CreateViewModel<NavigationBarViewModel> _createNavigationBarViewModel;

        public LayoutNavigationService(NavigationStore navigationStore,
            CreateViewModel<TViewModel> createViewModel,
            CreateViewModel<GlobalMessageViewModel> createGlobalMessageViewModel,
            CreateViewModel<NavigationBarViewModel> createNavigationBarViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createGlobalMessageViewModel = createGlobalMessageViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(
                _createNavigationBarViewModel(), 
                _createGlobalMessageViewModel(),
                _createViewModel());
        }
    }
}
