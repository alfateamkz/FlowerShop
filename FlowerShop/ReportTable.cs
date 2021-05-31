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
    public partial class ReportTable : Form
    {
        public int intParam;
        public DateTime dateStart;
        public DateTime dateEnd;
        public ReportTable(int filter)
        {
            InitializeComponent();
            switch (filter)
            {
                case 1:
                    AppLogic.SortActions.ByAgent(intParam, dataGridView1);
                    break;
                case 2:
                    AppLogic.SortActions.BySum(intParam, dataGridView1);
                    break;
                case 3:
                    AppLogic.SortActions.ByDate(dateStart, dataGridView1);
                    break;
                case 4:
                    AppLogic.SortActions.ByPeriod(dateStart,dateEnd, dataGridView1);
                    break;
            }    
        }
    }
}
