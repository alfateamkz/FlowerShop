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
    public partial class CounteragentsUpdate : Form
    {
        public CounteragentsUpdate()
        {
            InitializeComponent();
            AppLogic.FillCounteragentsList();
            comboBox3.DataSource = AppLogic.CounteragentsList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CounteragentEntity entity = (CounteragentEntity)comboBox3.SelectedItem;
            if (entity != null)
            {
                AppLogic.CounteragentEntityActions.Update
                    (new CounteragentEntity { ID=entity.ID,Title=textBox1.Text});
            }
        }
    }
}
