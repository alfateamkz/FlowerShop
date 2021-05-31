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
    public partial class ReportSelectDate : Form
    {
        public ReportSelectDate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value != null)
            {
                this.Close();
                ReportTable f = new ReportTable(3); f.dateStart = dateTimePicker1.Value.Date;
                f.Show();
            }
        }
    }
}
