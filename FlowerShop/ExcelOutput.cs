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
    public partial class ExcelOutput : Form
    {
        ExcelReport Excel;
        public ExcelOutput()
        {
            InitializeComponent();
            Excel = new ExcelReport();
            AppLogic.ShowProvisionsTable(dataGridView1);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void отчет1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.EntriesAmount(dataGridView1);
        }

        private void отчет2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.WithSummary(dataGridView1);
        }

        private void отчет3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
