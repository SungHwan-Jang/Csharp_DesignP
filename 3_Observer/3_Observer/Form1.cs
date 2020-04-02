using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Observer
{
    public partial class Form1 : Form
    {
        internal static Temperature Temp = new Temperature();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Temp.Changed += (s, e_) =>
            {
                this.Invoke(new Action(delegate ()
                {
                    textBox1.Text = Temp.Fahrenheit.ToString();
                }));
            };

            var f2 = new Form2();
            f2.Show();

            Task.Factory.StartNew(() =>
            {
                Temp.StartMeasure(10);
            });
        }
    }

    class Temperature
    {
        public event EventHandler Changed;

        private float _fahrenheit;

        public float Fahrenheit
        {
            get { return this._fahrenheit; }
            set
            {
                this._fahrenheit = value;
                if (Changed != null)
                {
                    Changed(null, EventArgs.Empty);
                }
            }
        }

        public void StartMeasure(int times)
        {
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < times; i++)
            {
                this.Fahrenheit = r.Next(20, 80);
                Thread.Sleep(1000);
            }
        }
    }
}
