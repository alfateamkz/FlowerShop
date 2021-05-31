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
    public partial class CounteragentsAdd : Form
    {
        public CounteragentsAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppLogic.CounteragentEntityActions.Insert(new CounteragentEntity { Title = textBox1.Text });
        }
    }
}
