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
using System.Windows.Shapes;
using System.Xml;

namespace WPF_learn3_Binding
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            // XmlDocument doc = new XmlDocument();
            // doc.Load(@"D:\PathToXml.xml");
            //
            // XmlDataProvider provider = new XmlDataProvider();
            // provider.Document = doc;
            //
            // provider.XPath = @"/Root/Person";
            //
            // this.listView.DataContext = provider;
            // this.listView.SetBinding(ListView.ItemsSourceProperty, new Binding());
            // RelativeSource rs = new RelativeSource(RelativeSourceMode.FindAncestor);
            // rs.AncestorLevel = 1;
            // rs.AncestorType = typeof(Grid);
            // Binding binding = new Binding("ActualWidth"){RelativeSource = rs};
            // this.textBox1.SetBinding(TextBox.WidthProperty, binding);

        }
    }
}
