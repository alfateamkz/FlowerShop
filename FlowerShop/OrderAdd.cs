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
    public partial class OrderAdd : Form
    {
        public OrderAdd()
        {
            InitializeComponent();
            AppLogic.FillFlowersList();
            AppLogic.FillBouquetMaterialsList();
            comboBox1.DataSource = AppLogic.BouquetMaterialsList;
            comboBox3.DataSource = AppLogic.FlowersList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FlowerEntity flower = (FlowerEntity)comboBox3.SelectedItem;
            if (flower != null)
            {
                OrderModel.BasketAddItem(flower,Convert.ToInt32(textBox2.Text));
                listBox1.DataSource = OrderModel.basket.ToList();
            }
    
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OrderModel.CreateBouquet = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            OrderModel.CreateBouquet = false;
            OrderModel.ClearBasket();
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
            OrderModel.CreateOrder();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox1.Text,out OrderModel.DocNumber))
            { }
            if (Int32.TryParse(textBox2.Text, out OrderModel.Quantity))
            { }
            BouquetMaterialEntity entity = (BouquetMaterialEntity)comboBox1.SelectedItem;
            if (entity != null)
            {
                OrderModel.BouquetMaterial = entity;
            }
            FlowerEntity flower = (FlowerEntity)comboBox3.SelectedItem;
            if (flower != null)
            {
                OrderModel.SelectedFlower = flower;
            }

            if (OrderModel.CreateBouquet)
            {
                button1.Enabled = true;
                comboBox1.Enabled = true;
                radioButton1.Checked = true;
                listBox1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                comboBox1.Enabled = false;
                radioButton1.Checked = false;
                listBox1.Enabled = false;

            }
        }
    }
}
