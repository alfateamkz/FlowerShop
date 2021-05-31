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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            AppLogic.RegisterEntry();

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelOutput f = new ExcelOutput(); f.Show();
        }


        private void цветыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Flowers f = new Flowers(); f.Show();
        }

        private void контрагентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Counteragents f = new Counteragents(); f.Show();
        }

        private void поставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Provisions f = new Provisions(); f.Show();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Orders f = new Orders(); f.Show();
        }

        private void создатьЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderAdd f = new OrderAdd(); f.Show();
        }

        private void колвоБукетовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AppLogic.SortActions.BouquetQuantity().ToString(),"Кол-во созданных букетов");
        }

        private void оКToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ReportTable f = new ReportTable(1); f.intParam = Convert.ToInt32(toolStripTextBox3.Text);
            f.Show();
        }

        private void оКToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportTable f = new ReportTable(2); f.intParam = Convert.ToInt32(toolStripTextBox2.Text);
            f.Show();
        }

        private void поНазваниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSelectDate f = new ReportSelectDate(); f.ShowDialog();
        }

        private void заПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSelectPeriod f = new ReportSelectPeriod(); f.ShowDialog();
        }
    }
}
