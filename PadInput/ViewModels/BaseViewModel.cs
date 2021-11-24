using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Controls;

namespace PadInput.ViewModels
{
    internal abstract class BaseViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// プロパティ変更をUI側へ通知するイベント
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティ変更の通知メソッド。
        /// </summary>
        /// <param name="info"></param>
        protected void OnPropertyChanged(string info)
        {
            //イベントはnullを許容
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

    }
}
