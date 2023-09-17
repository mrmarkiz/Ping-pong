using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class FormMenu : Form
    {
        private Form1 baseForm;
        public FormMenu(Form1 baseForm)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            this.baseForm = baseForm;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            baseForm.Enabled = true;
            baseForm.continueGame = true;
            baseForm.botStep = 1 + int.Parse(comboBox1.SelectedItem.ToString());
            this.Close();
        }
    }
}
