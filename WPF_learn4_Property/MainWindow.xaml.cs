using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPF_learn4_Property
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student stu;

        public MainWindow()
        {
            InitializeComponent();
            stu = new Student();
            var textBox1ToStuBinding = new Binding("Text") {Source = textBox1, Mode = BindingMode.TwoWay};
            var stuToTextBox2Binding = new Binding("Name") {Source = stu, Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged};
            stu.SetBinding(Student.PropertyName, textBox1ToStuBinding);
            textBox2.SetBinding(TextBox.TextProperty, stuToTextBox2Binding);
        }
    }

    class Student : DependencyObject
    {

        public string Name
        {
            get => (string)GetValue(PropertyName);
            set => SetValue(PropertyName, value);
        }

        public static readonly DependencyProperty PropertyName =
            DependencyProperty.Register(nameof(Name), typeof(string), typeof(Student), new PropertyMetadata("学生姓名"));

        public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }
    }
}