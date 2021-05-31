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
    public partial class FlowersDelete : Form
    {
        public FlowersDelete()
        {
            InitializeComponent();
            AppLogic.FillFlowersList();
            comboBox3.DataSource = AppLogic.FlowersList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FlowerEntity entity = (FlowerEntity)comboBox3.SelectedItem;
            if (entity != null)
            {
                AppLogic.FlowerEntityActions.Delete(entity.ID);
            }
        }
    }
}
