using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace WPF_learn3_Binding
{
    /// <summary>
    /// DataValidate.xaml 的交互逻辑
    /// </summary>
    public partial class DataValidate : Window
    {
        public DataValidate()
        {
            InitializeComponent();

            var binding = new Binding("Value")
            {
                Source = slider1,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            var rule = new RangeValidationRule
            {
                ValidatesOnTargetUpdated = true
            };
            binding.ValidationRules.Add(rule);
            binding.NotifyOnValidationError = true;
            this.textBox1.SetBinding(TextBox.TextProperty, binding);

            this.textBox1.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(this.ValidationError));
        }

        private void ValidationError(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Validation.GetErrors(this.textBox1).Count.ToString());
            if (Validation.GetErrors(this.textBox1).Count > 0)
            {   
                MessageBox.Show(Validation.GetErrors(this.textBox1)[0].ErrorContent.ToString());
            }
        }
    }

    internal class RangeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!double.TryParse(value.ToString(), out var d)) return new ValidationResult(false, "ValidationError");
            return d is >= 0 and <= 100 ? new ValidationResult(true, null) : new ValidationResult(false, "ValidationError");
        }
    }   
}
