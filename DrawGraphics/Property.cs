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
    

    public partial class Property : Form
    {
        #region 基本属性
        public graphic g = (graphic)Form1.GraphicList.graphiclist[Form1.GraphicList.SelectedIndex];//记录选择的图形


        #endregion


        #region 基本方法
        /// <summary>
        ///判断是否是封闭图形
        /// </summary>
        /// <returns></returns>
        public bool CloseGraphic()
        {
            bool c = false;
            string type = g.GetType().ToString();//记录图形类型
            switch (type)
            {
                case "DrawGraphics.ellipse": c = true; break;
                case "DrawGraphics.rectangle": c = true; break;


                default: c = false; break;
            }
            return c;
        }

        #endregion


        #region 窗体初始化
        public Property()
        {
            InitializeComponent();

            //初始化宽度下拉列表框
            for (int i = 1; i <= 20; i++)
            {
                this.comboBox2.Items.Add(i.ToString());
            }

            //初始化 线条+填充 样式下拉列表框
            //HatchStyle.ForwardDiagonal; HatchStyle.Cross; HatchStyle.DiagonalBrick; HatchStyle.SmallCheckerBoard; HatchStyle.ZigZag;

            string[] s = new string[3] {"Hatch","Linear","Solid" };

            for (int i = 0 ; i < 3; i++)
            {
                string t = s[i];
                this.comboBox1.Items.Add(t);
            }


            for (int i = 0; i < 3; i++)
            {
                string t = s[i];
                this.comboBox3.Items.Add(t);
            }


            //初始化 线条+填充 Hacth下拉表
            string[] h = new string[5] { "ForwardDiagonal", "Cross", "DiagonalBrick", "SmallCheckerBoard", "ZigZag" };
            for (int i = 0; i < 5; i++)
            {
                string t = h[i];
                this.comboBox4.Items.Add(t);
            }

            for (int i = 0; i < 5; i++)
            {
                string t = h[i];
                this.comboBox5.Items.Add(t);
            }

            //是否显示填充选择按钮
            if (this.CloseGraphic())
            {
                this.panel1.Enabled = true;
            }
            
            //设置上次控件改变的值
            
            
            this.comboBox2.Text =  SavePropertyControl.Width.ToString();
            this.label2.BackColor = SavePropertyControl.LineFore;
            this.label3.BackColor = SavePropertyControl.LineBack;
            this.comboBox1.Text = SavePropertyControl.LineStyle;
            this.comboBox4.Text = SavePropertyControl.LineHacthStyle;

            this.label4.BackColor = SavePropertyControl.FillFore;
            this.label9.BackColor = SavePropertyControl.FillBack;
            this.comboBox3.Text = SavePropertyControl.FillStyle;
            this.comboBox5.Text = SavePropertyControl.FillHacthStyle;

            this.radioButton1.Checked = SavePropertyControl.Fill;
            this.radioButton2.Checked = !SavePropertyControl.Fill;

        }

        #endregion


        #region 基本设置
        //设置线条前景填充色
        private void label2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label2.BackColor = cd.Color;
            }
        }

        //设置线条背景填充色
        private void label3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label3.BackColor = cd.Color;
            }
        }

        //确定改变属性
        private void button4_Click(object sender, EventArgs e)
        {
            string type = g.GetType().ToString();//记录图形类型
            switch (type)
            {
                case "DrawGraphics.line":
                    //转化为直线对象
                    line l=(line)g;
                    //设置宽度
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//记录宽度
                        l.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //设置颜色样式
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": l.brush = new SolidBrush(this.label2.BackColor);break;
                        case "Hatch":
                            //记录线条Hacth子样式
                            SavePropertyControl.LineHacthStyle = this.comboBox4.SelectedItem.ToString();
                            switch (this.comboBox4.SelectedItem.ToString())
                            {
                                case "Cross":
                                    l.brush = new HatchBrush(HatchStyle.Cross, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "DiagonalBrick":
                                    l.brush = new HatchBrush(HatchStyle.DiagonalBrick, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ForwardDiagonal":
                                    l.brush = new HatchBrush(HatchStyle.ForwardDiagonal, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "SmallCheckerBoard":
                                    l.brush = new HatchBrush(HatchStyle.SmallCheckerBoard, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ZigZag":
                                    l.brush = new HatchBrush(HatchStyle.ZigZag, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                default: break;
                            }
                            break;
                        case "Linear": l.brush = new LinearGradientBrush(l.Start, l.End, this.label2.BackColor, this.label3.BackColor); break;
                    }

                    //记录线条样式
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //记录颜色
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl .LineBack= this.label3.BackColor;

                    l.ToOld();
                    break;


                case "DrawGraphics.pencil":
                    pencil pc = (pencil)g;
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//记录宽度
                        pc.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //设置颜色样式
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": pc.brush = new SolidBrush(this.label2.BackColor); break;
                        case "Hatch":
                            //记录线条Hacth子样式
                            SavePropertyControl.LineHacthStyle = this.comboBox4.SelectedItem.ToString();
                            switch (this.comboBox4.SelectedItem.ToString())
                            {
                                case "Cross":
                                    pc.brush = new HatchBrush(HatchStyle.Cross, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "DiagonalBrick":
                                    pc.brush = new HatchBrush(HatchStyle.DiagonalBrick, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ForwardDiagonal":
                                    pc.brush = new HatchBrush(HatchStyle.ForwardDiagonal, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "SmallCheckerBoard":
                                    pc.brush = new HatchBrush(HatchStyle.SmallCheckerBoard, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ZigZag":
                                    pc.brush = new HatchBrush(HatchStyle.ZigZag, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                default: break;
                            }
                            break;
                        case "Linear": pc.brush = new LinearGradientBrush(pc.Start, pc.End, this.label2.BackColor, this.label3.BackColor); break;
                    }

                    //记录线条样式
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //记录颜色
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl.LineBack = this.label3.BackColor;

                    pc.ToOld();
                    break;
                case"DrawGraphics.curve":
                    pencil cv = (curve)g;
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//记录宽度
                        cv.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //设置颜色样式
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": cv.brush = new SolidBrush(this.label2.BackColor); break;
                        case "Hatch":
                            //记录线条Hacth子样式
                            SavePropertyControl.LineHacthStyle = this.comboBox4.SelectedItem.ToString();
                            switch (this.comboBox4.SelectedItem.ToString())
                            {
                                case "Cross":
                                    cv.brush = new HatchBrush(HatchStyle.Cross, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "DiagonalBrick":
                                    cv.brush = new HatchBrush(HatchStyle.DiagonalBrick, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ForwardDiagonal":
                                    cv.brush = new HatchBrush(HatchStyle.ForwardDiagonal, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "SmallCheckerBoard":
                                    cv.brush = new HatchBrush(HatchStyle.SmallCheckerBoard, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ZigZag":
                                    cv.brush = new HatchBrush(HatchStyle.ZigZag, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                default: break;
                            }
                            break;
                        case "Linear": cv.brush = new LinearGradientBrush(cv.Start, cv.End, this.label2.BackColor, this.label3.BackColor); break;
                    }

                    //记录线条样式
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //记录颜色
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl.LineBack = this.label3.BackColor;

                    cv.ToOld();
                    break;
                case "DrawGraphics.poly":
                    poly pl = (poly)g;
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//记录宽度
                        pl.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //设置颜色样式
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": pl.brush = new SolidBrush(this.label2.BackColor); break;
                        case "Hatch":
                            //记录线条Hacth子样式
                            SavePropertyControl.LineHacthStyle = this.comboBox4.SelectedItem.ToString();
                            switch (this.comboBox4.SelectedItem.ToString())
                            {
                                case "Cross":
                                    pl.brush = new HatchBrush(HatchStyle.Cross, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "DiagonalBrick":
                                    pl.brush = new HatchBrush(HatchStyle.DiagonalBrick, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ForwardDiagonal":
                                    pl.brush = new HatchBrush(HatchStyle.ForwardDiagonal, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "SmallCheckerBoard":
                                    pl.brush = new HatchBrush(HatchStyle.SmallCheckerBoard, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ZigZag":
                                    pl.brush = new HatchBrush(HatchStyle.ZigZag, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                default: break;
                            }
                            break;
                        case "Linear": pl.brush = new LinearGradientBrush(pl.Start, pl.End, this.label2.BackColor, this.label3.BackColor); break;
                    }

                    //记录线条样式
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //记录颜色
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl.LineBack = this.label3.BackColor;

                    pl.ToOld();
                    break;
                
                case "DrawGraphics.ellipse":
                    //转化为对象
                    ellipse  el = (ellipse)g;
                    //设置宽度
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//记录宽度
                        el.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //设置颜色样式
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": el.brush = new SolidBrush(this.label2.BackColor); break;
                        case "Hatch":
                            //记录线条Hacth子样式
                            SavePropertyControl.LineHacthStyle = this.comboBox4.SelectedItem.ToString();
                            switch (this.comboBox4.SelectedItem.ToString())
                            {
                                case "Cross":
                                    el.brush = new HatchBrush(HatchStyle.Cross, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "DiagonalBrick":
                                    el.brush = new HatchBrush(HatchStyle.DiagonalBrick, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ForwardDiagonal":
                                    el.brush = new HatchBrush(HatchStyle.ForwardDiagonal, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "SmallCheckerBoard":
                                    el.brush = new HatchBrush(HatchStyle.SmallCheckerBoard, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ZigZag":
                                    el.brush = new HatchBrush(HatchStyle.ZigZag, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                default: break;
                            }
                            break;
                        case "Linear": el.brush = new LinearGradientBrush(el.Start, el.End, this.label2.BackColor, this.label3.BackColor); break;
                    }

                    //记录线条样式
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //记录颜色
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl.LineBack = this.label3.BackColor;

                    //设置填充
                    el.Fill = SavePropertyControl.Fill;

                    //记录填充
                    SavePropertyControl.FillFore = this.label4.BackColor;
                    SavePropertyControl.FillBack = this.label9.BackColor;
                    
                    //填充色
                    switch (this.comboBox3.SelectedItem.ToString())
                    {
                        case "Solid": el.brushIn = new SolidBrush(this.label4.BackColor); break;
                        case "Hatch":
                            //记录线条Hacth子样式
                            SavePropertyControl.FillHacthStyle = this.comboBox5.SelectedItem.ToString();
                            switch (this.comboBox5.SelectedItem.ToString())
                            {
                                case "Cross":
                                    el.brushIn = new HatchBrush(HatchStyle.Cross, this.label4.BackColor, this.label9.BackColor);
                                    break;
                                case "DiagonalBrick":
                                    el.brushIn = new HatchBrush(HatchStyle.DiagonalBrick, this.label4.BackColor, this.label9.BackColor);
                                    break;
                                case "ForwardDiagonal":
                                    el.brushIn = new HatchBrush(HatchStyle.ForwardDiagonal, this.label4.BackColor, this.label9.BackColor);
                                    break;
                                case "SmallCheckerBoard":
                                    el.brushIn = new HatchBrush(HatchStyle.SmallCheckerBoard, this.label4.BackColor, this.label9.BackColor);
                                    break;
                                case "ZigZag":
                                    el.brushIn = new HatchBrush(HatchStyle.ZigZag, this.label4.BackColor, this.label9.BackColor);
                                    break;
                                default: break;
                            }
                            break;
                        case "Linear": el.brushIn = new LinearGradientBrush(el.Start, el.End, this.label4.BackColor, this.label9.BackColor); break;
                    }
                    SavePropertyControl.FillStyle = this.comboBox3.SelectedItem.ToString();
                    el.ToOld();
                    break;
                case "DrawGraphics.rectangle":
                    //转化为对象
                    rectangle rect = (rectangle)g;
                    //设置宽度
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//记录宽度
                        rect.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //设置颜色样式
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": rect.brush = new SolidBrush(this.label2.BackColor); break;
                        case "Hatch":
                            //记录线条Hacth子样式
                            SavePropertyControl.LineHacthStyle = this.comboBox4.SelectedItem.ToString();
                            switch (this.comboBox4.SelectedItem.ToString())
                            {
                                case "Cross":
                                    rect.brush = new HatchBrush(HatchStyle.Cross, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "DiagonalBrick":
                                    rect.brush = new HatchBrush(HatchStyle.DiagonalBrick, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ForwardDiagonal":
                                    rect.brush = new HatchBrush(HatchStyle.ForwardDiagonal, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "SmallCheckerBoard":
                                    rect.brush = new HatchBrush(HatchStyle.SmallCheckerBoard, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                case "ZigZag":
                                    rect.brush = new HatchBrush(HatchStyle.ZigZag, this.label2.BackColor, this.label3.BackColor);
                                    break;
                                default: break;
                            }
                            break;
                        case "Linear": rect.brush = new LinearGradientBrush(rect.Start, rect.End, this.label2.BackColor, this.label3.BackColor); break;
                    }

                    //记录线条样式
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //记录颜色
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl.LineBack = this.label3.BackColor;

                    //设置填充
                    rect.Fill = SavePropertyControl.Fill;

                    //记录填充
                    SavePropertyControl.FillFore = this.label4.BackColor;
                    SavePropertyControl.FillBack = this.label9.BackColor;

                    //填充色
                    switch (this.comboBox3.SelectedItem.ToString())
                    {
                        case "Solid": rect.brushIn = new SolidBrush(this.label4.BackColor); break;
                        case "Hatch":
                            //记录线条Hacth子样式
                            SavePropertyControl.FillHacthStyle = this.comboBox5.SelectedItem.ToString();
                            switch (this.comboBox5.SelectedItem.ToString())
                            {
                                case "Cross":
                                    rect.brushIn = new HatchBrush(HatchStyle.Cross, this.label4.BackColor, this.label9.BackColor);
                                    break;
                                case "DiagonalBrick":
                                    rect.brushIn = new HatchBrush(HatchStyle.DiagonalBrick, this.label4.BackColor, this.label9.BackColor);
                                    break;
                                case "ForwardDiagonal":
                                    rect.brushIn = new HatchBrush(HatchStyle.ForwardDiagonal, this.label4.BackColor, this.label9.BackColor);
                                    break;
                                case "SmallCheckerBoard":
                                    rect.brushIn = new HatchBrush(HatchStyle.SmallCheckerBoard, this.label4.BackColor, this.label9.BackColor);
                                    break;
                                case "ZigZag":
                                    rect.brushIn = new HatchBrush(HatchStyle.ZigZag, this.label4.BackColor, this.label9.BackColor);
                                    break;
                                default: break;
                            }
                            break;
                        case "Linear": rect.brushIn = new LinearGradientBrush(rect.Start, rect.End, this.label4.BackColor, this.label9.BackColor); break;
                    }
                    SavePropertyControl.FillStyle = this.comboBox3.SelectedItem.ToString();
                    rect.ToOld();
                    break;
                default:  break;
            }
            
            this.Close();
        }

        //取消改变属性
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //是否填充（闭合图形）
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.groupBox2.Enabled = true;
                SavePropertyControl.Fill = true;//记录填充
            }
            else
            {
                this.groupBox2.Enabled = false;
                SavePropertyControl.Fill = false;
            }
        }

        

        #endregion

        //线条Hatch子列表
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem.ToString() == "Hatch")
            {
                this.label10.Visible = true;
                this.comboBox4.Visible = true;
            }
            else 
            {
                this.label10.Visible =false;
                this.comboBox4.Visible = false;
            }
        }

        //填充前景色
        private void label4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label4.BackColor = cd.Color;
            }
        }
        //填充背景色
        private void label9_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label9.BackColor = cd.Color;
            }
        }


        //填充Hatch子列表
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox3.SelectedItem.ToString() == "Hatch")
            {
                this.label11.Visible = true;
                this.comboBox5.Visible = true;
            }
            else
            {
                this.label11.Visible = false;
                this.comboBox5.Visible = false;
            }
        }

    }


    


}