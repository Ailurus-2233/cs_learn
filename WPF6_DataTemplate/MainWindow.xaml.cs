using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF6_DataTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<object> array = new() 
            {
                new { Name = "张三", Age = 18, Sex = "男"},
                new { Name = "李四", Age = 19, Sex = "男" },
                new { Name = "王五", Age = 20, Sex = "男" },
                new { Name = "赵六", Age = 21, Sex = "女" },
            };

            com.ItemsSource = array;
        }
    }
}
