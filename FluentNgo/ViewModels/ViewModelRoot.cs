using FluentNgo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentNgo.ViewModels
{
    public class ViewModelRoot : ObservableObject
    {
        public StudentViewModel StudentVM { get; set; }
        public DonorViewModel DonorVM { get; set; }

        public ViewModelRoot()
        {
            StudentVM = new StudentViewModel();
            DonorVM = new DonorViewModel();
        }
    }
}
