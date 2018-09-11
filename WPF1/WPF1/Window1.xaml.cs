using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

       

        private void btnAppBeginInvoke_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ModifyUI()

        {

            // 模拟一些工作正在进行

            Thread.Sleep(TimeSpan.FromSeconds(2));

            //lblHello.Content = "欢迎你光临WPF的世界,Dispatcher";
            //this.Dispatcher.Invoke(new dle(() => { this.lblHello.Content = "welcome me!"; }));
            this.Dispatcher.BeginInvoke(new Action(()=> { this.lblHello.Content = "dsadf"; }));

        }
        delegate void dle();


        private void btnThd_Click(object sender, RoutedEventArgs e)

        {

            Thread thread = new Thread(ModifyUI);

            thread.Start();

        }
    }
}
