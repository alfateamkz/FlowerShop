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
    public partial class ReportSelectPeriod : Form
    {
        public ReportSelectPeriod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value != null && dateTimePicker2.Value != null)
            {
                this.Close();
                ReportTable f = new ReportTable(4);
                f.dateStart = dateTimePicker1.Value.Date;
                f.dateEnd = dateTimePicker2.Value.Date;
                f.Show();
            }
        }
            
    }
}
