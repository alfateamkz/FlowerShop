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
    public partial class FlowersAdd : Form
    {
        public FlowersAdd()
        {
            InitializeComponent();
            AppLogic.FillFlowerTypesList();
            AppLogic.FillFreshDegreesList();
            comboBox1.DataSource = AppLogic.FreshDegreesList;
            comboBox2.DataSource = AppLogic.FlowerTypesList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FreshDegreeEntity entityDegree = (FreshDegreeEntity)comboBox1.SelectedItem;
            FlowerTypeEntity entityType = (FlowerTypeEntity)comboBox2.SelectedItem;
            if (entityDegree != null && entityType != null)
            {
                AppLogic.FlowerEntityActions.Insert(new FlowerEntity
                {
                    FreshID = entityDegree.ID,
                    TypeID = entityType.ID,
                    Title = textBox1.Text,
                    Sort = textBox2.Text,
                    Price = Convert.ToDouble(textBox3.Text)
                });
            }
        }
    }
}
