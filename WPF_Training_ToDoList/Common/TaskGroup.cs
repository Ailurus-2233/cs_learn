using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Training_ToDoList.Common
{
    public class TaskGroup
    {
        public TaskGroup(string name, string icon, int count, string backgroundColor)
        {
            Name = name;
            Icon = icon;
            Count = count;
            BackgroundColor = backgroundColor;
        }

        public string Name { get; set; }
        public string Icon { get; set; }
        public int Count { get; set; }
        public string BackgroundColor { get; set; }
    }
}