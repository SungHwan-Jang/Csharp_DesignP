using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Observer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Temperature t = Form1.Temp;

            t.Changed += (s, e_) =>
              {
                  this.Invoke(new Action(delegate ()
                  {
                      trackBar1.Value = (int)t.Fahrenheit % 100;
                  }));
              };
        }
    }
}
