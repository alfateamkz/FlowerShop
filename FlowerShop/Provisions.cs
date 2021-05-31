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
    public partial class Provisions : Form
    {
        public Provisions()
        {
            InitializeComponent();
            AppLogic.ShowProvisionsTable(dataGridView1);
        }

        private void добавитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProvisionsAdd f = new ProvisionsAdd(); f.Show();
        }
    }
}
