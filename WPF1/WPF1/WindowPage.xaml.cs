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

namespace WPF1
{
    /// <summary>
    /// WindowPage.xaml 的交互逻辑
    /// </summary>
    public partial class WindowPage : Window
    {
        public WindowPage()
        {
            InitializeComponent();
           
            this.frame.Source = new Uri("http://www.cnblogs.com/zzw1986/p/7583521.html");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            //wb.Navigate("http://www.cnblogs.com/zzw1986/p/7583521.html");
            //fame = new Uri("http://www.cnblogs.com/zzw1986/p/7583521.html");
        }
    }
}
