using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DrawGraphics
{
    public partial class TextProperty : Form
    {
        text t=(text)Form1.GraphicList.graphiclist[Form1.GraphicList.SelectedIndex];
        public TextProperty()
        {
            InitializeComponent();

            //初始化 线条+填充 样式下拉列表框
            //HatchStyle.ForwardDiagonal; HatchStyle.Cross; HatchStyle.DiagonalBrick; HatchStyle.SmallCheckerBoard; HatchStyle.ZigZag;

            string[] s = new string[3] { "Hatch", "Linear", "Solid" };

            for (int i = 0; i < 3; i++)
            {
                string t = s[i];
                this.comboBox1.Items.Add(t);
            }


            //初始化  Hacth下拉表
            string[] h = new string[5] { "ForwardDiagonal", "Cross", "DiagonalBrick", "SmallCheckerBoard", "ZigZag" };
            for (int i = 0; i < 5; i++)
            {
                string t = h[i];
                this.comboBox2.Items.Add(t);
            }


            this.textBox1.Text = this.t.content;
            this.label2.BackColor = SaveTextProperty.TextFore;
            this.label3.BackColor = SaveTextProperty.TextBack;
            this.comboBox1.Text = SaveTextProperty.TextStyle;
            this.comboBox2.Text = SaveTextProperty.TextHacthStyle;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            DialogResult dr = fd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                SaveTextProperty.TextFont= fd.Font;//保存字体
            }
        }


        //保存
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != t.content)
            {
                SaveTextProperty.TextContent = this.textBox1.Text;//保存文本
                t.content=this.textBox1.Text;
            }
            t.font = SaveTextProperty.TextFont;

            //设置颜色样式
            switch (this.comboBox1.SelectedItem.ToString())
            {
                case "Solid": t.brush = new SolidBrush(this.label2.BackColor); break;
                case "Hatch":
                    //记录线条Hacth子样式
                    SaveTextProperty.TextHacthStyle = this.comboBox2.SelectedItem.ToString();
                    switch (this.comboBox2.SelectedItem.ToString())
                    {
                        case "Cross":
                            t.brushIn = new HatchBrush(HatchStyle.Cross, this.label2.BackColor, this.label3.BackColor);
                            break;
                        case "DiagonalBrick":
                            t.brushIn = new HatchBrush(HatchStyle.DiagonalBrick, this.label2.BackColor, this.label3.BackColor);
                            break;
                        case "ForwardDiagonal":
                            t.brushIn = new HatchBrush(HatchStyle.ForwardDiagonal, this.label2.BackColor, this.label3.BackColor);
                            break;
                        case "SmallCheckerBoard":
                            t.brushIn = new HatchBrush(HatchStyle.SmallCheckerBoard, this.label2.BackColor, this.label3.BackColor);
                            break;
                        case "ZigZag":
                            t.brushIn = new HatchBrush(HatchStyle.ZigZag, this.label2.BackColor, this.label3.BackColor);
                            break;
                        default: break;
                    }
                    break;
                case "Linear": t.brushIn = new LinearGradientBrush(t.Start, t.End, this.label2.BackColor, this.label3.BackColor); break;
            }

            //记录线条样式
            SaveTextProperty.TextStyle= this.comboBox1.SelectedItem.ToString();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //前景色
        private void label2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label2.BackColor = cd.Color;
                SaveTextProperty.TextFore = this.label2.BackColor;
            }
        }
        //背景色
        private void label3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label3.BackColor = cd.Color;
                SaveTextProperty.TextBack = this.label3.BackColor;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem.ToString() == "Hatch")
            {
                this.label5.Visible = true;
                this.comboBox2.Visible = true;
            }
            else
            {
                this.label5.Visible = false;
                this.comboBox2.Visible = false;
            }
        }
    }
}