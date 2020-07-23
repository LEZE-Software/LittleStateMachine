using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StateTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string txtVal;

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayEvent newEv = new DisplayEvent();

            newEv.GetPayload(txtVal);

            MainValues.eventQue.Add(newEv);
        }

        private void textChanged(object sender, EventArgs e)
        {
            TextBox senderBox = sender as TextBox;
            txtVal = senderBox.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBox leo = new TextBox()
            {
                Name = "txt_new",
                Location = new Point(50, 50),
                Width = 100,
                Height = 23,
                Text = Text
            };
            leo.TextChanged += new EventHandler(textChanged);

            this.Controls.Add(leo);
        }
    }
}
