using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace Binary_To_Hex.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        #region Services
        private readonly IEventAggregator _ea;
        #endregion

        #region Properties
        private string _hexNumber;
        public string HexNumber
        {
            get { return _hexNumber; }
            set { SetProperty(ref _hexNumber, value); }
        }

        private ObservableCollection<ExtensionGroupsEntry> _extensionGroupsMaster;
        public ObservableCollection<ExtensionGroupsEntry> ExtensionGroupsMaster
        {
            get { return _extensionGroupsMaster; }
            set { SetProperty(ref _extensionGroupsMaster, value); }
        } 
        #endregion



        public MainWindowViewModel(IEventAggregator ea)
        {

            #region Init Services
            _ea = ea;
            #endregion

            #region Init Properties
            int count = 0;
            ExtensionGroupsMaster = new ObservableCollection<ExtensionGroupsEntry>();
            for (int i = 0; i < 4; i++) //columns
            {
                var extensionEntry = new ExtensionGroupsEntry();
                extensionEntry.ExtensionGroup = new ObservableCollection<CheckBoxEntry>();
                for (int j = 0; j < 8; j++) //rows
                {
                    count++;
                    var checkboxEntry = new CheckBoxEntry(count, true, new SolidColorBrush(Colors.Blue), _ea);
                    extensionEntry.ExtensionGroup.Add(checkboxEntry);
                }
                ExtensionGroupsMaster.Add(extensionEntry);
            }

            HexNumber = "‭FFFFFFFF‬";
            #endregion

            #region Init Events
            _ea.GetEvent<CheckBoxChangedEvent>().Subscribe(CheckedChnagedExecute); 
            #endregion

        }

        #region Function
        private void CheckedChnagedExecute()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var extensionGroupsEntry in ExtensionGroupsMaster)
            {
                foreach (var item in extensionGroupsEntry.ExtensionGroup)
                {
                    if (item.IsSelected)
                        builder.Append("1");
                    else
                        builder.Append("0"); 
                }
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
