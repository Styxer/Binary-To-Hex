using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Binary_To_Hex
{
    public  class CheckBoxEntry : BindableBase
    {
        #region Services
        private readonly IEventAggregator _ea;
        #endregion

        #region Properties
        private int _name;
        public int Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        private Brush _brush;
        public Brush Brush
        {
            get { return _brush; }
            set { SetProperty(ref _brush, value); }
        }
        #endregion

        #region Function
        public DelegateCommand ClickCmd { get; set; } 
        #endregion

        #region Constructor
        public CheckBoxEntry(int name, bool isSelected, Brush brush, IEventAggregator ea)
        {
            #region Init Properties
            Name = name;
            IsSelected = isSelected;
            Brush = brush;
            #endregion

            #region Init Services
            _ea = ea;
            #endregion

            #region Init Function
            ClickCmd = new DelegateCommand(CheckedChnagedExecute); 
            #endregion
        }
        #endregion


        #region Functions
        private void CheckedChnagedExecute()
        {
            IsSelected = !IsSelected;
            Brush = IsSelected ? new SolidColorBrush(Colors.Blue) : new SolidColorBrush(Colors.Black);
            _ea.GetEvent<CheckBoxChangedEvent>().Publish();
        } 
        #endregion

    }
}
