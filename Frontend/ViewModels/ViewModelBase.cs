﻿using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Frontend.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            this.RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
