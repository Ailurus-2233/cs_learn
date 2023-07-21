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

namespace WPF5_ControlTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static int buttonColorId = 0;
        static readonly Color[] colors = { Colors.Green, Colors.Red, Colors.Blue, Colors.Yellow };

        private void ButtonClickChangeColor(object sender, RoutedEventArgs e)
        {
            // 更换资源列表里的Button.Background
            if (Resources["Button.Background"] is SolidColorBrush scb)
            {
                buttonColorId = (buttonColorId + 1) % 4;
                scb.Color = colors[buttonColorId];
            }
        }
    }
}