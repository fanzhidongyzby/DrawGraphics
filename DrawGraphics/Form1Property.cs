using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DrawGraphics
{
    public partial class Form1Property : Form
    {
        public Form1Property()
        {
            InitializeComponent();

            //this.checkBox1.Checked = SaveForm1Property.MenuCheck;
            //this.checkBox2.Checked = SaveForm1Property.ToolCheck;
            //this.checkBox3.Checked = SaveForm1Property.StatusCheck;
            

            this.label5.BackColor=SaveForm1Property.MenuColor;
            this.label6.BackColor = SaveForm1Property.ToolColor;
            this.label7.BackColor = SaveForm1Property.StatusColor;

            this.label8.BackColor=SaveForm1Property.BackColor;
        }

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    SaveForm1Property.MenuCheck=this.checkBox1.Checked;
        //}

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    SaveForm1Property.ToolCheck = this.checkBox2.Checked;
        //}

        //private void checkBox3_CheckedChanged(object sender, EventArgs e)
        //{
        //    SaveForm1Property.StatusCheck = this.checkBox3.Checked;
        //}

        private void label5_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label5.BackColor = cd.Color;
                SaveForm1Property.MenuColor = this.label5.BackColor;
            }
            //colorDialog1.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label6.BackColor = cd.Color;
                SaveForm1Property.ToolColor = this.label6.BackColor;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label7.BackColor = cd.Color;
                SaveForm1Property.StatusColor = this.label7.BackColor;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label8.BackColor = cd.Color;
                SaveForm1Property.BackColor = this.label8.BackColor;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveForm1Property.Change = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}