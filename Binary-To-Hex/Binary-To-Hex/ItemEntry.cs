using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_To_Hex
{
    public  class ItemEntry
    {
        public ItemEntry(int name, bool isSelected)
        {
            Name = name;
            IsSelected = isSelected;
        }

        public int Name { get; set; }
        public bool IsSelected { get; set; }
        DelegateCommand<string> CheckedChnaged;
    }
}
