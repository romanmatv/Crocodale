using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Crocodale
{
    public partial class Dictionary : Form
    {
        //DataSet dataSet1 = new DataSet();
        public Dictionary()
        {
            InitializeComponent();
            FileInfo f = new FileInfo("dictionary.xml");
            if (f.Exists)
            {
                dataSet1.ReadXml("dictionary.xml", XmlReadMode.ReadSchema);
                dataGridView1.DataSource = dataSet1.DefaultViewManager;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {          
        }

        private void Dictionary_FormClosing(object sender, FormClosingEventArgs e)
        {
            var xmldoc = new XmlDocument();
            xmldoc.InnerXml = dataSet1.GetXml();
            xmldoc.Save("dictionary.xml");
        }
    }
}
