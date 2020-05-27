using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KY.NetForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            keyValues.Add("q", 1);
            keyValues.Add("qq", 12);
            keyValues.Add("qqq", 13);
            keyValues.Add("qqqq", 14);
            keyValues.Add("qqqqq", 15);
            keyValues.Add("qqqqqq", 16);
            keyValues.Add("qqqqqqq", 17);
            keyValues.Add("qqqqqqqq", 18);
            List<MyProerty> list = new List<MyProerty>();
            foreach (var item in keyValues)
            {
                list.Add(new MyProerty() { ProertyName= item.Key, PropertyType= item.Value.GetType() });
            }

          //  list.Add(new MyProerty { ProertyName = "IDSSSSS", PropertyType = typeof(int) });
            Service service = new Service();
            service.CreateAndSave("helloworld", "modulehello", "typehello", list, "helloworld");
            var data= service.InitData(keyValues);
            richTextBox1.Text += Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
    }
}
