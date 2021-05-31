using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShop
{
    public partial class ProvisionsAdd : Form
    {
        public ProvisionsAdd()
        {
            InitializeComponent();
            AppLogic.FillCounteragentsList();
            AppLogic.FillFlowersList();
            comboBox1.DataSource = AppLogic.CounteragentsList;
            comboBox2.DataSource = AppLogic.FlowersList;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CounteragentEntity entityAgent = (CounteragentEntity)comboBox1.SelectedItem;
            FlowerEntity entityFlower = (FlowerEntity)comboBox2.SelectedItem;
            if (entityAgent != null && entityFlower != null)
            {
                AppLogic.ProvisionEntityActions.Insert(new ProvisionEntity
                {
                    Date = DateTime.Now.Date,
                    CounteragentID = entityAgent.ID,
                    FlowerID = entityFlower.ID,
                    Price = Convert.ToDouble(textBox3.Text),
                    Quantity = Convert.ToInt32(textBox1.Text),
                    DocNumber = Convert.ToInt32(textBox2.Text)
                });
            }
        }
    }
}
