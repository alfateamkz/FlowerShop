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
    public partial class Flowers : Form
    {
        public Flowers()
        {
            InitializeComponent();
            AppLogic.ShowFlowersTable(dataGridView1);
        }

        private void добавитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowersAdd f = new FlowersAdd(); f.Show();
        }

        private void изменитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowersUpdate f = new FlowersUpdate(); f.Show();
        }

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowersDelete f = new FlowersDelete(); f.Show();
        }
    }
}
