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
        #region ��������
        public graphic g = (graphic)Form1.GraphicList.graphiclist[Form1.GraphicList.SelectedIndex];//��¼ѡ���ͼ��


        #endregion


        #region ��������
        /// <summary>
        ///�ж��Ƿ��Ƿ��ͼ��
        /// </summary>
        /// <returns></returns>
        public bool CloseGraphic()
        {
            bool c = false;
            string type = g.GetType().ToString();//��¼ͼ������
            switch (type)
            {
                case "DrawGraphics.ellipse": c = true; break;
                case "DrawGraphics.rectangle": c = true; break;


                default: c = false; break;
            }
            return c;
        }

        #endregion


        #region �����ʼ��
        public Property()
        {
            InitializeComponent();

            //��ʼ����������б��
            for (int i = 1; i <= 20; i++)
            {
                this.comboBox2.Items.Add(i.ToString());
            }

            //��ʼ�� ����+��� ��ʽ�����б��
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


            //��ʼ�� ����+��� Hacth������
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

            //�Ƿ���ʾ���ѡ��ť
            if (this.CloseGraphic())
            {
                this.panel1.Enabled = true;
            }
            
            //�����ϴοؼ��ı��ֵ
            
            
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


        #region ��������
        //��������ǰ�����ɫ
        private void label2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label2.BackColor = cd.Color;
            }
        }

        //���������������ɫ
        private void label3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label3.BackColor = cd.Color;
            }
        }

        //ȷ���ı�����
        private void button4_Click(object sender, EventArgs e)
        {
            string type = g.GetType().ToString();//��¼ͼ������
            switch (type)
            {
                case "DrawGraphics.line":
                    //ת��Ϊֱ�߶���
                    line l=(line)g;
                    //���ÿ��
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//��¼���
                        l.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //������ɫ��ʽ
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": l.brush = new SolidBrush(this.label2.BackColor);break;
                        case "Hatch":
                            //��¼����Hacth����ʽ
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

                    //��¼������ʽ
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //��¼��ɫ
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl .LineBack= this.label3.BackColor;

                    l.ToOld();
                    break;


                case "DrawGraphics.pencil":
                    pencil pc = (pencil)g;
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//��¼���
                        pc.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //������ɫ��ʽ
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": pc.brush = new SolidBrush(this.label2.BackColor); break;
                        case "Hatch":
                            //��¼����Hacth����ʽ
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

                    //��¼������ʽ
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //��¼��ɫ
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl.LineBack = this.label3.BackColor;

                    pc.ToOld();
                    break;
                case"DrawGraphics.curve":
                    pencil cv = (curve)g;
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//��¼���
                        cv.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //������ɫ��ʽ
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": cv.brush = new SolidBrush(this.label2.BackColor); break;
                        case "Hatch":
                            //��¼����Hacth����ʽ
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

                    //��¼������ʽ
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //��¼��ɫ
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl.LineBack = this.label3.BackColor;

                    cv.ToOld();
                    break;
                case "DrawGraphics.poly":
                    poly pl = (poly)g;
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//��¼���
                        pl.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //������ɫ��ʽ
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": pl.brush = new SolidBrush(this.label2.BackColor); break;
                        case "Hatch":
                            //��¼����Hacth����ʽ
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

                    //��¼������ʽ
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //��¼��ɫ
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl.LineBack = this.label3.BackColor;

                    pl.ToOld();
                    break;
                
                case "DrawGraphics.ellipse":
                    //ת��Ϊ����
                    ellipse  el = (ellipse)g;
                    //���ÿ��
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//��¼���
                        el.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //������ɫ��ʽ
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": el.brush = new SolidBrush(this.label2.BackColor); break;
                        case "Hatch":
                            //��¼����Hacth����ʽ
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

                    //��¼������ʽ
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //��¼��ɫ
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl.LineBack = this.label3.BackColor;

                    //�������
                    el.Fill = SavePropertyControl.Fill;

                    //��¼���
                    SavePropertyControl.FillFore = this.label4.BackColor;
                    SavePropertyControl.FillBack = this.label9.BackColor;
                    
                    //���ɫ
                    switch (this.comboBox3.SelectedItem.ToString())
                    {
                        case "Solid": el.brushIn = new SolidBrush(this.label4.BackColor); break;
                        case "Hatch":
                            //��¼����Hacth����ʽ
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
                    //ת��Ϊ����
                    rectangle rect = (rectangle)g;
                    //���ÿ��
                    if (this.comboBox2.Text != "")
                    {
                        SavePropertyControl.Width = Convert.ToInt32(this.comboBox2.Text);//��¼���
                        rect.Width = Convert.ToInt32(this.comboBox2.Text);
                    }

                    //������ɫ��ʽ
                    switch (this.comboBox1.SelectedItem.ToString())
                    {
                        case "Solid": rect.brush = new SolidBrush(this.label2.BackColor); break;
                        case "Hatch":
                            //��¼����Hacth����ʽ
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

                    //��¼������ʽ
                    SavePropertyControl.LineStyle = this.comboBox1.SelectedItem.ToString();
                    //��¼��ɫ
                    SavePropertyControl.LineFore = this.label2.BackColor;
                    SavePropertyControl.LineBack = this.label3.BackColor;

                    //�������
                    rect.Fill = SavePropertyControl.Fill;

                    //��¼���
                    SavePropertyControl.FillFore = this.label4.BackColor;
                    SavePropertyControl.FillBack = this.label9.BackColor;

                    //���ɫ
                    switch (this.comboBox3.SelectedItem.ToString())
                    {
                        case "Solid": rect.brushIn = new SolidBrush(this.label4.BackColor); break;
                        case "Hatch":
                            //��¼����Hacth����ʽ
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

        //ȡ���ı�����
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //�Ƿ���䣨�պ�ͼ�Σ�
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.groupBox2.Enabled = true;
                SavePropertyControl.Fill = true;//��¼���
            }
            else
            {
                this.groupBox2.Enabled = false;
                SavePropertyControl.Fill = false;
            }
        }

        

        #endregion

        //����Hatch���б�
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

        //���ǰ��ɫ
        private void label4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label4.BackColor = cd.Color;
            }
        }
        //��䱳��ɫ
        private void label9_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                this.label9.BackColor = cd.Color;
            }
        }


        //���Hatch���б�
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