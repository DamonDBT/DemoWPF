using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;

namespace WinFromBinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //绑定到非dataGridView中可以不用属性
        Person p = new Person();
        //双向绑定dataGridView必须是  属性  类型，字段无法绑定
        public BindingList<Person> list1 { get; set; }



        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            p.Name = "zhangsan";
            p.Age = 12;
            //textbox 的属性--数据源---数据源中的什么数据
            this.textBox1.DataBindings.Add("Text", p, "Name");
            list1 = new BindingList<Person>();
            //{
            //    new Person() { Name = "zhangsan", Age = 13 },
            //    new Person() { Name = "zhangsan", Age = 15 }
            //};

            for (int i = 0; i < 20; i++)
            {
                list1.Add(new Person() { Name = "zhangsan", Age = 13 });
            }

            //1、单向绑定，dgv变化后，list1 不变化，要手动遍历dgv取得数据，麻烦
            this.dataGridView1.DataSource = list1;



            //2、双向绑定  但不能增加、删除行
            //this.dataGridView1.DataBindings.Add("DataSource", this, "list1" );



            //3、双向绑定，并且dgv 可以增加行、删除行
            //但是后台增加list数据后，dgv不增加显示
            //可以关闭 增加行的功能
            //BindingSource bs = new BindingSource();
            //bs.DataSource = list1;
            //this.dataGridView1.DataSource = bs;


            //4、双向绑定，并且dgv 可以增加行、删除行
            //list1,要用BindingList 类型，不是list类型
            //后台增加list数据后，dgv  增加显示

            //BindingSource bs = new BindingSource();
            //bs.DataSource = list1;
            //this.dataGridView1.DataSource = bs;

            //Random ra = new Random();
            //new Thread(() =>
            //{ 
            //    while (true)
            //    {
            //        for (int i = 0; i < list1.Count; i++)
            //        {
            //            var aa = ra.Next(1, 100);//前台数据居然不变化！！！点了那个单元格才变化，不行
            //                                     //var result = this.dataGridView1.DataSource as BindingList<Person>;
            //                                     //result[0].Age = aa;
            //            list1[i].Age = aa;
            //        }
            //        list1.Add(new Person() { Name = "zhangsan", Age = 13 });


            //        //this.dataGridView1.Refresh();

            //        Debug.Write(list1[0].Age);
            //        Thread.Sleep(200); 
            //    }

            //}).Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list1.Add(new Person() { Name = "zhangsan", Age = 15 });
            //如果list1 是list类型，后台增加，dgv不变
            //如果是BindingList 类型，后台增加，dgv变化

            //list1[0].Name = "23";
            //this.dataGridView1.DataBindings.Add("DataSource", this, "list1");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string con = "Data Source=127.0.0.1;port=3306;Initial Catalog=test01;user id=root;password=dengbitao;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(con);

            conn.Open();

            MySqlCommand sc = new MySqlCommand();
            sc.Connection = conn;


            MySqlCommand sc1 = new MySqlCommand();
            sc1.Connection = conn;
            sc1.CommandText = "select * from test01.student";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sc1);
            student st = new student();


            Thread t = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    sc.CommandText = st.ToString();
                    for (int m = 0; m < 1000; m++)
                    {
                        sc.ExecuteNonQuery();
                    }
                    //Debug.WriteLine("insert ok");

                    //da.Fill(dt);
                    //dt.Clear();

                    Thread.Sleep(1);
                } 
                conn.Close();
            });
            t.IsBackground = true;
            t.Start();

 

            Debug.WriteLine("did ok");

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class student
    {
        Random ra = new Random();

        public string name = "zhangsan";
        public int age = 12;
        public int score = 55;
        public string born_date = "";
        public string born_time = "";

        public override string ToString()
        {
            age = ra.Next(1, 60);
            score = ra.Next(30, 100);

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into test01.student (name,age,score,born_date,born_time) values( ");
            sb.Append("'" + name.ToString() + "'" + ",");
            sb.Append("'" + age.ToString() + "'" + ",");
            sb.Append("'" + score.ToString() + "'" + ",");
            sb.Append("'" + DateTime.Now.ToShortDateString() + "'" + ",");
            sb.Append("'" + DateTime.Now.ToShortTimeString() + "'");
            sb.Append(" )");

            return sb.ToString();
        }
    }
}
