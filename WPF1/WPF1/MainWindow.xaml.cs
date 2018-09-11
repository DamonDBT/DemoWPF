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
using System.Threading;

namespace WPF1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            WindowComposite wc = new WindowComposite();
            wc.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            w.Show();
        }
        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Action ac = new Action(()=> { this.textBox.Text = "12"; });
            ac.Invoke();
            //new Thread(ac ).Start();
           

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            WindowPage wp = new WindowPage();
            wp.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            WindowProperty wp = new WindowProperty();
            wp.Show();
        }
    }
}
