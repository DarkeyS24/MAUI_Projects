using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppMVVMCommunityToolKit.Models
{
    public partial class Person : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string name;
        
        [ObservableProperty]
        private string email;
    }
}
