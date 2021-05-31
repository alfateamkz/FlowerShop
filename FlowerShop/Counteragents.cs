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
    public partial class Counteragents : Form
    {
        public Counteragents()
        {
            InitializeComponent();
            AppLogic.ShowCounteragentsTable(dataGridView1);
        }

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounteragentsDelete f = new CounteragentsDelete(); f.Show();
        }

        private void изменитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounteragentsUpdate f = new CounteragentsUpdate(); f.Show();
        }

        private void добавитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounteragentsAdd f = new CounteragentsAdd(); f.Show();
        }
    }
}
