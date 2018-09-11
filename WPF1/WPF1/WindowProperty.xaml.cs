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
    /// WindowProperty.xaml 的交互逻辑
    /// </summary>
    public partial class WindowProperty : Window
    {
        public WindowProperty()
        {
            InitializeComponent();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //List<Person> persons = new List<Person>() {
            //    new Person()            {       name = "zhangsan", Age = 12, Address = "chongqing" },
            //    new Person() { name = "laowang", Age = 16, Address = "chongqing" }
            //};
            //this.dataGrid.DataContext = persons;
            //this.listBox.DataContext = persons;

            Student s = new Student() { Name="zhangsa"};
            //this.dataGrid.DataContext = s;
        }
    }

    class Person : DependencyObject
    {
        public string Address { get; set; }
        public int Age { get; set; }
        public string name { get; set; }
    }

    public class Student : DependencyObject

    {

        //声明一个静态只读的DependencyProperty字段

        public static readonly DependencyProperty NameProperty;



        static Student()

        {

            //注册我们定义的依赖属性Name

            NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Student),

                new PropertyMetadata("名称", OnValueChanged));

        }



        private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)

        {
        }



        //属性包装器，通过它来读取和设置我们刚才注册的依赖属性

        public string Name

        {

            get { return (string)GetValue(NameProperty); }

            set { SetValue(NameProperty, value); }

        }



    }

}
