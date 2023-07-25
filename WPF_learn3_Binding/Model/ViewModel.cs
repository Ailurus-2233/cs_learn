using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF6_Binding.Model
{
    public class ViewModel
    {
        public string Message { get; set; }

        public ViewModel()
        {
            Message = "Hello, World!";
        }
    }
}
