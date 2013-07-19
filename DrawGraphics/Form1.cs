using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DrawGraphics
{
    public partial class Form1 : Form
    {
        #region 窗体基本属性

        int ClickTime = 0;//记录画曲线或多边形单击的次数，选择该工具时清零,清空对象是清零！

        System.Drawing.Image i;//记录初始化的背景（在Form1.Designer.cs终初始化）

        bool net=false;//是否绘制网格

        public static list GraphicList = new list ();//创建总链表

        //line GraphicLine;//临时记录直线对象
        //ellipse GraphicEllipse ;//临时记录椭圆对象

        
        bool LBdown = false;//左键是否按下

        String _selected = "Selected";
        /// <summary>
        /// 记录选择的菜单
        /// </summary>
        public String Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        graphic gSave = new graphic();//剪贴板

        #endregion

        #region 窗体初始化

        public Form1()
        {
            InitializeComponent();
            //this.AutoScrollMinSize = new Size(1280,800);//怎么解决菜单滚动的问题？？？

        }

        public void Net(Graphics g)
        {
            Brush b = new SolidBrush(Color.Gray);
            Pen p = new Pen(b, 1);
            for (int x = 0; x <= 1280; x += 20)
            {
                g.DrawLine(p,new Point (x,0),new Point (x,780));
            }
            for (int y = 0; y <= 780; y += 20)
            {
                g.DrawLine(p,new Point (0,y),new Point (1280,y));
            }
        }

        #endregion

        #region 鼠标事件

        //左键按下
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.LBdown = true;
            GraphicList.SelectedGraphicMode( GraphicList.SelectedIndex, false);
            Invalidate();
            
                switch (Selected)
                {
                    case "Line":
                        line GraphicLine = new line(new Point(e.X, e.Y), new Point(e.X, e.Y));
                        
                        GraphicList.AddGraphic(GraphicLine);
                        break;
                    case"Ellipse":
                        ellipse GraphicEllipse = new ellipse(new Point(e.X, e.Y), new Point(e.X, e.Y));

                        GraphicList.AddGraphic(GraphicEllipse);

                        break;

                    case "Circle":
                        
                        ellipse GraphicCircle = new ellipse(new Point(e.X, e.Y), new Point(e.X, e.Y));

                        GraphicList.AddGraphic(GraphicCircle);

                        break;

                    case "Rectangle":
                        rectangle GraphicRect = new rectangle(new Point(e.X, e.Y), new Point(e.X, e.Y));
                        GraphicList.AddGraphic(GraphicRect);
                        break;

                    case"Square":
                        rectangle GraphicSquare = new rectangle(new Point(e.X, e.Y), new Point(e.X, e.Y));
                        GraphicList.AddGraphic(GraphicSquare);
                        break;

                    case "Pencil":
                        pencil GraphicPencil = new pencil(new Point(e.X, e.Y), new Point(e.X, e.Y));
                        GraphicList.AddGraphic(GraphicPencil);
                        break;

                    //case"Curve":
                    //    curve GraphicCurve = new curve();
                    //    GraphicList.AddGraphic(GraphicCurve);
                    //    break;

                    case"Text":
                        text GraphicText = new text(new Point(e.X, e.Y), new Point(e.X, e.Y));
                        GraphicText.IsSelected = true;
                        GraphicList.AddGraphic(GraphicText);
                        break;
                    case "Selected":
                        int f = GraphicList.OnIndex(new Point(e.X, e.Y));
                        if (f >=0)
                        {
                            GraphicList.SelectedGraphicMode(f, true);
                            Invalidate();
                            break;
                        }
                        else
                        {
                            GraphicList.SelectedGraphicMode(f, false);
                            Invalidate();
                            break; 
                        }
                }
            
        }


        //移动
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.LBdown == true)
            {
                Point p = new Point(e.X, e.Y);//记录鼠标的临时点,或收集对象的返回点
                switch (Selected)
                {
                    case "Line":
                        GraphicList.IndexEnd (GraphicList.length-1,ref p,true );//设置                        
//-------------------------------第一种刷新-----------------------------------------------？？？
                        //Point[] points = new Point[2];
                        //GraphicList.IndexStart (GraphicList.length-1,ref p,false  );//获取头存于p
                        //points[0]=new Point (p.X ,p.Y );
                        //GraphicList.IndexEnd (GraphicList.length-1,ref p,false  );//获取尾存于p
                        //points[1] = new Point(p.X, p.Y);

                        //byte[]bytes=new byte []{(byte)System.Drawing.Drawing2D.PathPointType.Line };

                        //System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath(points ,bytes);

                        //Invalidate(new Region(path ));

//----------------------------------------------第二种刷新-------------------------------------------------？？？

                        GraphicList.IndexStart(GraphicList.length - 1, ref p, false);//获取头存于p
                        Point p1 = p;
                        GraphicList.IndexEnd(GraphicList.length - 1, ref p, false);//获取尾存于p
                        Point p2 = p;
                        Invalidate(new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y)));

                        //Invalidate();
                        break;
                    case "Ellipse":
                        GraphicList.IndexEnd(GraphicList.length - 1, ref p,true );

                        GraphicList.IndexStart(GraphicList.length - 1, ref p, false);//获取头存于p
                        p1 = p;
                        GraphicList.IndexEnd(GraphicList.length - 1, ref p, false);//获取尾存于p
                        p2 = p;
                        Invalidate(new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y)));

                       // Invalidate();
                        break;

                    case"Circle":                   

                        GraphicList.IndexStart(GraphicList.length - 1, ref p, false);//获取头存于p
                        p1 = p;//得到首点

                        p2 = new Point(e.X, e.Y);//获取当前点

                        int dx = System.Math.Abs(p1.X - p2.X);
                        int dy = System.Math.Abs(p1.Y - p2.Y);
                        int max = (dx >= dy) ? dx : dy;

                        Size z ;

                        if (p1.X <= p2.X)
                        {
                            if (p1.Y <= p2.Y)
                                z = new Size(max, max);
                            else
                                z = new Size(max, -max);
                        }
                        else
                        {
                            if (p1.Y <= p2.Y)
                                z = new Size(-max, max);
                            else
                                z = new Size(-max, -max);
                        }

                        

                        p2 = p1 + z;



                        GraphicList.IndexEnd(GraphicList.length - 1, ref p2, true);//修改尾点

                        Invalidate(new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y)));

                        break;

                    case "Rectangle":
                        GraphicList.IndexEnd(GraphicList.length - 1, ref p, true);

                        GraphicList.IndexStart(GraphicList.length - 1, ref p, false);//获取头存于p
                        p1 = p;
                        GraphicList.IndexEnd(GraphicList.length - 1, ref p, false);//获取尾存于p
                        p2 = p;
                        Invalidate(new Rectangle(p1, new Size(p2.X - p1.X+2, p2.Y - p1.Y+2)));

                        // Invalidate();
                        break;

                    case "Square":
                        GraphicList.IndexStart(GraphicList.length - 1, ref p, false);//获取头存于p
                        p1 = p;//得到首点

                        p2 = new Point(e.X, e.Y);//获取当前点

                         dx = System.Math.Abs(p1.X - p2.X);
                         dy = System.Math.Abs(p1.Y - p2.Y);
                         max = (dx > dy) ? dx : dy;
                         z = new Size(max, max);

                        p2 = p1 + z;
                        GraphicList.IndexEnd(GraphicList.length - 1, ref p2, true);//修改尾点

                        Invalidate(new Rectangle(p1, new Size(p2.X - p1.X+2, p2.Y - p1.Y+2)));

                        break;

                    case"Pencil":
                        pencil GraphicPencil=(pencil) GraphicList.graphiclist[GraphicList.length - 1];
                        GraphicPencil.AddPoint(new Point(e.X, e.Y));


                        //刷新用
                        Point endLast = (Point)GraphicPencil.points.GetValue(GraphicPencil.pointIndex-1);
                        Point end=(Point)GraphicPencil.points.GetValue(GraphicPencil.pointIndex);

                        Invalidate(new Rectangle (endLast,new Size(end.X-endLast.X,end.Y-endLast.Y)));
                        break;
                    case"Text":
                        GraphicList.IndexEnd(GraphicList.length - 1, ref p, true);

                        GraphicList.IndexStart(GraphicList.length - 1, ref p, false);//获取头存于p
                        p1 = p;
                        GraphicList.IndexEnd(GraphicList.length - 1, ref p, false);//获取尾存于p
                        p2 = p;
                        Invalidate(new Rectangle(p1, new Size(p2.X - p1.X + 2, p2.Y - p1.Y + 2)));
                        
                        // Invalidate();
                        break;

                    case "Selected":
                        Point old = GraphicList.SelectedPoint;

                        if (GraphicList.Find == true)
                        {
                            GraphicList.MoveIndex(GraphicList.SelectedIndex, old, new Point(e.X, e.Y));
                            GraphicList.SelectedPoint = new Point(e.X, e.Y);
                            Invalidate();
                        }
                        //int f = GraphicList.SelectedIndex;
                        //GraphicList.SelectedGraphicMode(f, false);
                        //Invalidate();
                        break;

                          
                    //    Point q = new Point(e.X,e.Y);
                    //    GraphicList.IndexStart(GraphicList.SelectedIndex , ref p, false);//获取头存于p
                    //    p1 = p+new Size(e.X-GraphicList.SelectedPoint.X,e.Y-GraphicList.SelectedPoint.Y);
                    //    GraphicList.IndexEnd(GraphicList.SelectedIndex , ref p, false);//获取尾存于p
                    //    p2 = p + new Size(e.X - GraphicList.SelectedPoint.X, e.Y - GraphicList.SelectedPoint.Y);
                    //    GraphicList.IndexStart(GraphicList.SelectedIndex, ref p1,true );
                    //    GraphicList.IndexEnd(GraphicList.SelectedIndex, ref p2, true );

                }
            }
        }


        //左键弹起
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.LBdown = false;
            Point p = new Point(e.X, e.Y);//记录鼠标的临时点,或收集对象的返回点
            switch (Selected)
            {
                case "Line":
                   // GraphicList.IndexEnd(GraphicList.length - 1, ref p, true);//设置                        

                    Invalidate();
                    break;
                case "Ellipse":
                    //GraphicList.IndexEnd(GraphicList.length - 1, ref p,true );

                    Invalidate();
                    break;

                case "Circle":
                    Invalidate();
                    break;

                case "Rectangle":
                    Invalidate();
                    break;

                case "Square":

                    Invalidate();
                    break;

                case "Pencil":
                    Invalidate();
                    break;

                case"Text":
                    text TextGraphic = (text)GraphicList.graphiclist[GraphicList.length - 1];
                    TextGraphic.content = "请键入要插入的文本...";
                    TextGraphic.IsSelected = false;
                    this.Selected = "Selected";
                    TextProperty tp = new TextProperty();
                    tp.Show();
                    Invalidate();
                    break;

                case "Selected":
                    Point old = GraphicList.SelectedPoint;

                    if (GraphicList.Find == true)
                    {
                        GraphicList.MoveIndex(GraphicList.SelectedIndex, old, new Point(e.X, e.Y));
                        GraphicList.SelectedPoint = new Point(e.X, e.Y);
                        Invalidate();
                    }

                    //int f = GraphicList.SelectedIndex;
                    //GraphicList.SelectedGraphicMode(f, false);
                    //Invalidate();
                    break;
                    

            }


        }
        #endregion 

        //单击
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (Selected)
            {
                case "Curve":
                    if (ClickTime == 0)
                    {
                        curve cv = new curve(new Point(e.X, e.Y), new Point(e.X, e.Y));
                        GraphicList.AddGraphic(cv);
                    }
                    else
                    {
                        curve GraphicCurve = (curve)GraphicList.graphiclist[GraphicList.length - 1];
                        GraphicCurve.AddPoint(new Point(e.X, e.Y));
                        Invalidate();
                    }
                    ClickTime++;
                    break;
                case"Poly":
                    if (ClickTime == 0)
                    {
                        poly pl = new poly(new Point(e.X, e.Y), new Point(e.X, e.Y));
                        GraphicList.AddGraphic(pl);
                    }
                    else
                    {
                        poly GraphicPoly = (poly)GraphicList.graphiclist[GraphicList.length - 1];
                        GraphicPoly.AddPoint(new Point(e.X, e.Y));
                        Invalidate();
                    }
                    ClickTime++;
                    break;
            }
        }


        #region OnPaint()重载
        //-------------------------------------OnPaint()----------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //设置窗体属性
            if (SaveForm1Property.Change)
            {
                //this.menuStrip1.Visible = SaveForm1Property.MenuCheck;
                //this.toolStrip1.Visible = SaveForm1Property.ToolCheck;
                //this.statusStrip1.Visible = SaveForm1Property.StatusCheck;

                this.menuStrip1.BackColor = SaveForm1Property.MenuColor;
                this.toolStrip1.BackColor = SaveForm1Property.ToolColor;
                this.statusStrip1.BackColor = SaveForm1Property.StatusColor;

                this.BackColor = SaveForm1Property.BackColor;
            }

            Graphics dc = e.Graphics;

            //设置网格
            if (net)
                this.Net(dc);

            //this.contextMenuStrip1.Items[4].Enabled =Convert.ToBoolean((GraphicList.length != 0));

            //重回菜单栏
            //dc.TranslateTransform(-this.AutoScrollPosition.X, -this.AutoScrollPosition.Y);
            //this.menuStrip1.Location = new Point(0,0);
            //this.menuStrip1.Show();
            //dc.TranslateTransform(0,25 );

            //绘制链表
            GraphicList.DrawGraphic(dc);
        }
        #endregion

        #region 主菜单


        //改变光标
        private void menuStrip1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            if (this.Selected == "Selected")
                this.Cursor = Cursors.SizeAll;
        }

        //文件
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //查看
        private void 工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            工具栏ToolStripMenuItem.Checked = !工具栏ToolStripMenuItem.Checked;
            if (工具栏ToolStripMenuItem.Checked)
                this.toolStrip1.Visible = true;
            else
                this.toolStrip1.Visible = false;
        }

        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            状态栏ToolStripMenuItem.Checked = !状态栏ToolStripMenuItem.Checked;
            if (状态栏ToolStripMenuItem.Checked)
                this.statusStrip1.Visible = true;
            else
                this.statusStrip1.Visible = false;
        }

        private void 网格线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            网格线ToolStripMenuItem.Checked = !网格线ToolStripMenuItem.Checked;
            if (网格线ToolStripMenuItem.Checked)
                this.BackgroundImage = i;

            else
                this.BackgroundImage = null;
            

        }

        //工具
        private void 选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selected = "Selected";
            this.Cursor = Cursors.SizeAll;
            this.toolStripStatusLabel1.Text = " 选择线条时，线条加黑，选择区域时，区域变灰。";

        }
                                 //线条
        private void 直线ToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            this.Selected = "Line";
            this.Cursor = Cursors.Cross;
            this.toolStripStatusLabel1.Text = "拖动鼠标，画一直线。";
        }

        private void 曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selected = "Curve";
            this.toolStripStatusLabel1.Text = "单击不同的位置，画一条曲线。";
            this.ClickTime = 0;
            this.Cursor = Cursors.Cross;
        }

        private void 铅笔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selected = "Pencil";
            this.Cursor = Cursors.Cross;
            this.toolStripStatusLabel1.Text = "拖动鼠标，画一自定义线条。";
        }

                                 //图形
        private void 椭圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selected = "Ellipse";
            this.Cursor = Cursors.Cross;
            this.toolStripStatusLabel1.Text = "拖动鼠标，画一椭圆。";
        }

        private void 圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selected = "Circle";
            this.Cursor = Cursors.Cross;
            this.toolStripStatusLabel1.Text = "拖动鼠标，画一正圆。";
        }

        private void 矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selected = "Rectangle";
            this.toolStripStatusLabel1.Text = "拖动鼠标，画一矩形。";
            this.Cursor = Cursors.Cross;
        }

        private void 正方形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selected = "Square";
            this.toolStripStatusLabel1.Text = "拖动鼠标，画一正方形。";
            this.Cursor = Cursors.Cross;
        }

        private void 多边形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selected = "Poly";
            this.toolStripStatusLabel1.Text = "单击不同的位置，画一个多边形。";
            this.ClickTime = 0;
            this.Cursor = Cursors.Cross;
        }


        //帮助
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edition ef = new Edition();
            ef.ShowDialog();
        }
        #endregion

        #region 右键菜单

        //右键菜单1
        private void 隐藏主菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (隐藏主菜单ToolStripMenuItem.Text == "隐藏主菜单")
            {
                this.menuStrip1.Visible = false;
                隐藏主菜单ToolStripMenuItem.Text = "显示主菜单";
            }
            else
            {
                this.menuStrip1.Visible = true;
                隐藏主菜单ToolStripMenuItem.Text = "隐藏主菜单";
            }
        }

        //private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    GraphicList.RemoveGraphic(GraphicList.SelectedIndex);
        //    Invalidate();
        //}

        //private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.gSave=(graphic)GraphicList.graphiclist[GraphicList.SelectedIndex];
        //    Invalidate();
        //}

        //private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    GraphicList.AddGraphic(this.gSave);
        //    Invalidate();
        //}

        //private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.gSave = (graphic)GraphicList.graphiclist[GraphicList.SelectedIndex];
        //    GraphicList.RemoveGraphic(GraphicList.SelectedIndex);
        //    Invalidate();
        //}

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphicList.graphiclist.RemoveRange(0, GraphicList.graphiclist.Count);
            this.ClickTime = 0;
            //this.清空ToolStripMenuItem.Enabled = false;
            Invalidate();

        }


        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GraphicList.Find && this.Selected == "Selected")
            {
                if (GraphicList.graphiclist[GraphicList.SelectedIndex].GetType().ToString() == "DrawGraphics.text")
                {
                    TextProperty tp = new TextProperty();
                    tp.Show();
                }
                else
                {
                    Property pf = new Property();
                    pf.Show();
                }
            }
            else
            {
                //this.关于ToolStripMenuItem_Click(sender, e);
                Form1Property fp = new Form1Property();
                fp.Show();
            }
        }


        


        //右键菜单2
        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 工具栏按钮


        //改变光标
        private void toolStrip1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void toolStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            if(this.Selected=="Selected")
                this.Cursor = Cursors.SizeAll;
        }


        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Selected = "Selected";
            this.toolStripStatusLabel1.Text = "选择线条时，线条加黑，选择区域时，区域变灰。";
            this.Cursor = Cursors.SizeAll;

        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Selected = "Line";
            this.toolStripStatusLabel1.Text = "拖动鼠标，画一条直线。";
            this.Cursor = Cursors.Cross;

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Selected = "Curve";
            this.toolStripStatusLabel1.Text = "单击不同的位置，画一条曲线。";
            this.ClickTime = 0;
            this.Cursor = Cursors.Cross;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Selected = "Pencil";
            this.toolStripStatusLabel1.Text = "拖动鼠标，画自定义线条。";
            this.Cursor = Cursors.Cross;
        }




        private void 椭圆ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Selected = "Ellipse";
            this.toolStripStatusLabel1.Text = "拖动鼠标，画一个椭圆。";
            this.Cursor = Cursors.Cross ;
        }

        private void 正圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Selected = "Circle";
            this.toolStripStatusLabel1.Text = "拖动鼠标，画一个正圆。";
            this.Cursor = Cursors.Cross;
        }

        private void 矩形ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Selected = "Rectangle";
            this.toolStripStatusLabel1.Text = "拖动鼠标，画一矩形。";
            this.Cursor = Cursors.Cross;
        }

        private void 正方形ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Selected = "Square";
            this.toolStripStatusLabel1.Text = "拖动鼠标，画一正方形。";
            this.Cursor = Cursors.Cross;
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Selected = "Poly";
            this.toolStripStatusLabel1.Text = "单击不同的位置，画一个多边形。";
            this.ClickTime = 0;
            this.Cursor = Cursors.Cross;
        }

       
        
        #endregion

        #region 任务栏图标

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            //必须显示出来！！！
            if (this.WindowState == FormWindowState.Minimized)//最小化时
                this.WindowState = FormWindowState.Normal;//正常
            this.Activate();//激活窗体，给予焦点
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();//界面隐藏
                this.notifyIcon1.Visible = true;//图标显现，默认隐藏
            }
        }

        #endregion  


        #region 状态栏

        //改变光标
        private void statusStrip1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void statusStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            if (this.Selected == "Selected")
                this.Cursor = Cursors.SizeAll;

        }


        #endregion

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.Selected = "Text";
        }

        


    }
}