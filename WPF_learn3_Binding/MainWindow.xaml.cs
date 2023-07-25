using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF6_Binding.Model;

namespace WPF_learn3_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // private Student su;

        // private SliderString ss;

        public MainWindow()
        {
            InitializeComponent();

            // ss = new SliderString();
            // ss.SliderValue = "0";
            // ss.TextShow = "0";
            //
            // var binding1 = new Binding()
            // {
            //     Source = ss,
            //     Path = new PropertyPath("TextShow")
            // };
            //
            // var binding2 = new Binding()
            // {
            //     Source = ss,
            //     Path = new PropertyPath("SliderValue")
            // };
            //
            //
            // this.textBox2.SetBinding(TextBox.TextProperty, new Binding("Text.Length"){ Source = this.textBox1 ,Mode = BindingMode.OneWay});

            // List<string> list = new List<string>(){"tom", "tim", "blog", "xxx"};
            // this.TextBox1.SetBinding(TextBox.TextProperty, new Binding(".[0]"){Source = list});
            // this.TextBox2.SetBinding(TextBox.TextProperty, new Binding(".[1]"){Source = list, Mode = BindingMode.OneWay});
            // this.TextBox3.SetBinding(TextBox.TextProperty, new Binding(".[2]"){Source = list, Mode = BindingMode.OneWay});


            // BindingOperations.SetBinding(this.TextBox1, TextBox.TextProperty, binding1);
            // BindingOperations.SetBinding(this.Slider1, RangeBase.ValueProperty, binding2);

            // su = new Student("Su");
            //
            // var binding = new Binding
            // {
            //     Source = su,
            //     Path = new PropertyPath("Name")
            // };
            //
            // BindingOperations.SetBinding(this.textBoxName, TextBox.TextProperty, binding);
            // this.textBoxName.SetBinding(TextBox.TextProperty, new Binding("Name") {Source = su = new Student("su")});

            string s = "HelloWorld";
            // this.textBlock.SetBinding(TextBlock.TextProperty, new Binding(){Source = s});

        }

        // private void Button_Click(object sender, RoutedEventArgs e)
        // {
        //     su.Name += "Hello";
        // }
    }
}