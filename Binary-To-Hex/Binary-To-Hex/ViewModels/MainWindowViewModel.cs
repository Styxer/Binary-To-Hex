using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Binary_To_Hex.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _hexNumber;
        public string HexNumber
        {
            get { return _hexNumber; }
            set { SetProperty(ref _hexNumber, value); }
        }

        private ObservableCollection<CheckBoxEntry> _extensionGroups;
        public  ObservableCollection<CheckBoxEntry> ExtensionGroups
        {
            get { return _extensionGroups; }
            set { SetProperty(ref _extensionGroups, value); }
        }


        #region Comamnds

        public DelegateCommand CheckedChnaged { get;  set; }



        #endregion

        public MainWindowViewModel()
        {
            _extensionGroups = new ObservableCollection<CheckBoxEntry>();

            for (int i = 0; i < 32; i++)
            {
                ExtensionGroups.Add(new CheckBoxEntry(i, true));
            }

            CheckedChnaged = new DelegateCommand(CheckedChnagedExecute);

            HexNumber = "‭FFFFFFFF‬";

        }

     

      

        #region Function
        private void CheckedChnagedExecute()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in ExtensionGroups)
            {
                if (item.IsSelected)
                    builder.Append("1");
                else
                    builder.Append("0");
            }
            HexNumber = HexConverted(builder.ToString());
        }

        string HexConverted(string strBinary)
        {
            string strHex = Convert.ToInt32(strBinary, 2).ToString("X");
            return strHex;
        }
        #endregion
    }
}
