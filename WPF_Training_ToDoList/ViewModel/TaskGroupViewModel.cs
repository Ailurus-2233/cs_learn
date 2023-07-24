using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Training_ToDoList.Common;

namespace WPF_Training_ToDoList.ViewModel
{
    public class TaskGroupViewModel
    {
        public ObservableCollection<TaskGroup> TaskMenuItems { get; set; }

        public TaskGroupViewModel()
        {
            TaskMenuItems = new ObservableCollection<TaskGroup>
            {
                new TaskGroup("我的一天", "\xe635", 0, "#d96564"),
                new TaskGroup("重要", "\xe6b6", 0, "#e5c07b"),
                new TaskGroup("已计划日程", "\xe65b", 0, "#55afea"),
                new TaskGroup("已分配给你", "\xe614", 0, "#92e492"),
                new TaskGroup("任务", "\xe755", 0, "#7b5da7")
            };
        }

    }
}
