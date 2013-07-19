using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Drawing.Drawing2D;

namespace DrawGraphics
{
    /// <summary>
    /// ͼ�λ���
    /// </summary>
    public class graphic 
    {
        #region ��������

        Point start0;
        public Point Start0
        {
            get { return start0; }
            set { start0 = value; }
        }

        Point end0;
        public Point End0
        {
            get { return end0; }
            set { end0 = value; }
        }

        int _index0 = -1;
        public int index0
        {
            get { return _index0; }
            set { _index0 = value; }
        }

        int width0;
        public int Width0
        {
            get { return width0; }
            set { width0 = value; }
        }


        bool isSelected0 = false;
        public bool IsSelected0
        {
            get { return isSelected0; }
            set { isSelected0 = value; }
        }






        Point start;
        /// <summary>
        /// ͼ����ʼ��
        /// </summary>
        public Point Start
        {
            get { return start; }
            set { start = value; }
        }

        Point end;
        /// <summary>
        /// ͼ���ս��
        /// </summary>
        public Point End
        {
            get { return end; }
            set { end = value; }
        }

        int _index=-1;
        /// <summary>
        /// �����������е�����
        /// </summary>
        public int index
        {
            get { return _index; }
            set { _index = value; }
        }

        int width;
        /// <summary>
        /// �߶ο��
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }


        bool isSelected = false;
        /// <summary>
        /// �ж�ͼ���Ƿ���ѡ�е�
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        #endregion 

        #region ���෽��

        /// <summary>
        /// ��¼������
        /// </summary>
        public virtual void ToOld()
        {
            this.Start0 = this.Start;
            this.End0 = this.End;
            this.Width0 = this.Width;
            this.index0 = this.index;
            this.IsSelected0 = this.IsSelected;         

        }


        /// <summary>
        /// ��ԭ������
        /// </summary>
        public virtual void OldTo()
        {
            this.Start = this.Start0;
            this.End = this.End0;
            this.Width = this.Width0;
            this.index = this.index0;
            this.IsSelected = this.IsSelected0;

        }

        /// <summary>
        /// �����������Ƿ���ͼ������
        /// </summary>
        /// <param name="p">�������</param>
        /// <returns>�ڴ����򷵻�true</returns>
        public virtual bool OnGraphic(Point p)
        {
            return false;
        }


        /// <summary>
        /// ��ͼ�ΰ���p1-->p2�������ƶ�
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public virtual void MoveGraphic(Point p1, Point p2)
        { return; }
       
        /// <summary>
        ///  ����ͼ��
        /// </summary>
        /// <param name="dc">ͼ�λ��ƶ���</param>
        /// <returns>�ɹ����Ʒ���true(��Ϊ�����쳣��)</returns>
        public virtual bool DrawGraphic(Graphics dc)
        {
            return false;
        }


        /// <summary>
        /// ����ѡ��ģʽ��״̬
        /// </summary>
        public virtual void SelectedMode(bool selected)
        {
            return;
        }
        #endregion 
    }


    /// <summary>
    /// ֱ����
    /// </summary>
   public  class line : graphic
    {
        #region ֱ������

        Brush _brush0;
        public Brush brush0
        {
            get { return _brush0; }
            set { _brush0 = value; }
        }


        Brush _brush ;
        /// <summary>
        /// �߶������ʽ
        /// </summary>
        public Brush brush
        {
            get { return _brush; }
            set { _brush = value; }
        }

        

       

        #endregion

        #region ֱ�߷���


        public line() 
        {
            this.Width = 1;
            this.brush = Brushes.Black;
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public line(Point p1,Point p2)
        {
            this.Start = p1;
            this.End = p2;
            this.Width = 1;
            this.brush = Brushes.Black;
        }

        public override void ToOld()
        {
            base.ToOld();
            this.brush0 = this.brush;
        }

        public override void OldTo()
        {
            base.OldTo();
            this.brush = this.brush0;
        }
        public override bool OnGraphic(Point p)
        {
            ////double d;//�㵽ֱ�߾��루������б�ʲ������

            //double x0, x1, x2, y0, y1, y2, dx, dy;
            //x1 = (double)this.Start.X;
            //y1 = (double)this.Start.Y;
            //x2 = (double)this.End.X;
            //y2 = (double)this.End.Y;
            //x0 = (double)((x1 + x2) / 2.0);
            //y0 = (double)((y1 + y2) / 2.0);

            //dx = System.Math.Abs(x0 - p.X);
            //dy = System.Math.Abs(y0 - p.Y);


            ////d=((x2-x1)*(y0-y1)-(y2-y1)*(x0-x1))/System.Math.Sqrt ((y1-y2)*(y1-y2)+(x1-x2)*(x1-x2));

            ////dk = System.Math.Abs((double)(p.Y - this.Start.Y) / (double)(p.X - this.Start.X)-(double)(p.Y - this.End.Y) / (double)(p.X - this.End.X));

            //if (dx < 5.0 && dy < 5.0)//�����ǡ�0��
            //{
            //    return true;
            //}
            //else
            //    return false;


            ////////////////////////////////////////////////////////////////////
            ////double  x1, x2, y1, y2, dx, dy;
            ////x1 = (double)this.Start.X;
            ////y1 = (double)this.Start.Y;
            ////x2 = (double)this.End.X;
            ////y2 = (double)this.End.Y;

            ////if (((p.X < x1 && p.X > x2) || (p.X > x1 && p.X < x2)) && ((p.Y < y1 && p.Y > y2) || (p.Y > y1 && p.Y < y2)))
            ////{
            ////    return true;
            ////}
            ////else return  false;

            double x1, x2, y1, y2, d0, d1, d2, d3, x0, y0, ave;

            x1 = (double)this.Start.X;
            y1 = (double)this.Start.Y;
            x2 = (double)this.End.X;
            y2 = (double)this.End.Y;

            //�������
            x0 = p.X;
            y0 = p.Y;

            if ((x0 > x1 && x0 < x2) || (x0 > x2 && x0 < x1))//�жϵ��λ���Ƿ��ڷ�Χ����
            {
                d1 = System.Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));//���λ�õ�������
                d2 = System.Math.Sqrt((x2 - x0) * (x2 - x0) + (y2 - y0) * (y2 - y0));//���λ�õ��յ����
                d3 = System.Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));//ֱ�߾���

                ave = (d1 + d2 + d3) / 2;

                d0 = System.Math.Sqrt(ave * (ave - d1) * (ave - d2) * (ave - d3)) / d3;//���λ�õ�ֱ�ߵľ���

                if (d0 < 2)
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }

        public override bool DrawGraphic(Graphics dc)
        {
            
            Pen pen = new Pen(this.brush, this.Width);//��������

            //Size  s = new Size(x,y);
            dc.DrawLine(pen,this.Start ,this.End );//����ֱ��

            return true;
        }


       
        public override void SelectedMode(bool selected)
        {
            if (selected == true)
            {
                this.ToOld();
                //����ѡ��ģʽ������
                this.brush = Brushes.Black;
                if(Width ==1)
                    this.Width++;
                this.IsSelected = true;
            }
            else if (selected == false)
            {
                this.OldTo(); //��ԭ��ֵ
            }          
        }

        public override void MoveGraphic(Point p1, Point p2)
        {
            Size move = new Size(p2.X-p1.X,p2.Y-p1.Y);

            

            this.Start += move;
            this.End += move;

            //���ò�ѡ���ǻ�ԭԭ����λ��
            this.Start0 = this.Start;
            this.End0 = this.End;



        }

        #endregion
    }

    /// <summary>
    /// ��Բ��
    /// </summary>
    public class ellipse:line 
    {
        #region ��Բ����

        Brush _brushIn0;
        public Brush brushIn0
        {
            get { return _brushIn0; }
            set { _brushIn0 = value; }
        }

        bool fill0 = true;
        public bool Fill0
        {
            get { return fill0; }
            set { fill0 = value; }
        }


        Brush _brushIn;
        /// <summary>
        /// �ڲ����ɫ
        /// </summary>
        public Brush brushIn
        {
            get { return _brushIn; }
            set { _brushIn = value; }
        }

        bool fill=false ;
        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool Fill
        {
            get { return fill; }
            set { fill = value; }
        }


        #endregion
        public bool Circle0 = false;
        /// <summary>
        /// �Ƿ�����Բ
        /// </summary>
        public bool Circle = false;

        #region ��Բ����

        public ellipse() { }

        public ellipse(Point p1,Point p2):base(p1,p2)
        {
            //int dx = System.Math.Abs(p1.X - p2.X);
            //int dy = System.Math.Abs(p1.Y - p2.Y);
            //int max = (dx > dy) ? dx : dy;
            //Size z = new Size(max, max);
            //this.Start = p1;
            //this.End = p1 + z;
            //MessageBox.Show("ellipse End:"+this.End.ToString()+"base End:"+base.End.ToString());

            this.Width = 1;
            this.brush = Brushes.Black;
            this.brushIn =Brushes.White;
        }

        public override void ToOld()
        {
            base.ToOld();
            this.brush0 = this.brush;
            this.brushIn0 = this.brushIn;
            this.Fill0 = this.Fill;

            this.Circle0 = this.Circle;
        }

        public override void OldTo()
        {
            base.OldTo();
            this.brush = this.brush0;
            this.brushIn = this.brushIn0;
            this.Fill = this.Fill0;

            this.Circle = this.Circle0;
        }

        public override bool OnGraphic(Point p)        
        {
            ////if (p.X >= this.Start.X && p.X <= this.End.X && p.Y >= this.Start.Y && p.Y <= this.End.Y)
            ////    return true;
            ////else
            ////    return false;



            //double x0, x1, x2, y0, y1, y2, dx, dy;
            //x1 = (double)this.Start.X;
            //y1 = (double)this.Start.Y;
            //x2 = (double)this.End.X;
            //y2 = (double)this.End.Y;
            //x0 = (double)((x1 + x2) / 2.0);
            //y0 = (double)((y1 + y2) / 2.0);

            //dx = System.Math.Abs(x0 - p.X);
            //dy = System.Math.Abs(y0 - p.Y);


            ////d=((x2-x1)*(y0-y1)-(y2-y1)*(x0-x1))/System.Math.Sqrt ((y1-y2)*(y1-y2)+(x1-x2)*(x1-x2));

            ////dk = System.Math.Abs((double)(p.Y - this.Start.Y) / (double)(p.X - this.Start.X)-(double)(p.Y - this.End.Y) / (double)(p.X - this.End.X));

            //if (dx < 5.0 && dy < 5.0)//�����ǡ�0��
            //{
            //    return true;
            //}
            //else
            //    return false;
            //if (this.Circle == false)//��Բ
            {
                double x0, x1, x2, y0, y1, y2, l;
                double c, cx1, cx2, cy1, cy2;
                double d1, d2, big;
                x1 = (double)this.Start.X;
                y1 = (double)this.Start.Y;
                x2 = (double)this.End.X;
                y2 = (double)this.End.Y;
                x0 = (x1 + x2) / 2;
                y0 = (y1 + y2) / 2;

                if ((x0 > x1 && x0 < x2) || (x0 > x2 && x0 < x1))//�жϵ��λ���Ƿ��ڷ�Χ����
                {
                    d1 = System.Math.Abs((x1 - x2) / 2);
                    d2 = System.Math.Abs((y1 - y2) / 2);



                    if (d1 <= d2)
                    {
                        big = d2;
                        c = System.Math.Sqrt(d2 * d2 - d1 * d1);
                        cx1 = x0;
                        cy1 = y0 - c;
                        cx2 = x0;
                        cy2 = y0 + c;
                        l = System.Math.Sqrt(((p.X - cx1) * (p.X - cx1) + (p.Y - cy1) * (p.Y - cy1))) + System.Math.Sqrt(((p.X - cx2) * (p.X - cx2) + (p.Y - cy2) * (p.Y - cy2)));
                    }
                    else
                    {
                        big = d1;
                        c = System.Math.Sqrt(d1 * d1 - d2 * d2);
                        cx1 = x0 - c;
                        cy1 = y0;
                        cx2 = x0 + c;
                        cy2 = y0;
                        l = System.Math.Sqrt(((p.X - cx1) * (p.X - cx1) + (p.Y - cy1) * (p.Y - cy1))) + System.Math.Sqrt(((p.X - cx2) * (p.X - cx2) + (p.Y - cy2) * (p.Y - cy2)));
                    }
                    //if (((big * 2 - l) < 5) && ((big * 2 - l) > -5))
                    if ((big * 2 - l) >= 0)
                        return true;
                    else return false;

                }
                else return false;
            }
            //else//��Բ
            //{
            //    double x0, y0;
            //    x0 = (this.Start.X + this.End.X) / 2.0;
            //    y0 = (this.Start.Y + this.End.Y) / 2.0;

            //    double x, y;
            //    x = p.X;
            //    y = p.Y;

            //    double r = System.Math.Sqrt((x - x0) * (x - x0) + (y - y0) * (y - y0));
            //    double R = System.Math.Sqrt((this.Start.X - x0) * (this.Start.X - x0) + (this.Start.Y - y0) * (this.Start.Y - y0));

            //    if (r <= R)
            //        return true;
            //    else
            //        return false;
            //}


        }

        public override bool DrawGraphic(Graphics dc)
        {
            Pen pen = new Pen(this.brush, this.Width);//��������
            //int X = System.Math.Abs(GraphicList.IndexEnd(GraphicList.length - 1 ).X  - GraphicList.IndexStart(GraphicList.length - 1,).X );
            //int Y = System.Math.Abs(GraphicList.IndexEnd(GraphicList.length - 1).Y - GraphicList.IndexStart(GraphicList.length - 1).Y);
            //����Ҫת��Ϊ������Size!ϵͳ�Զ�Ĭ�ϣ�����

            //if (this.Circle == false)
            {
                dc.DrawEllipse(pen, this.Start.X, this.Start.Y, this.End.X - this.Start.X, this.End.Y - this.Start.Y);
                //������Բ�߽�(ע�⽫����ת��ΪSize)
                if (this.Fill)
                    dc.FillEllipse(this.brushIn, this.Start.X, this.Start.Y, this.End.X - this.Start.X, this.End.Y - this.Start.Y);
                //�����Բ�ڲ�
            }
            //else
            //{
            //    int dx=System.Math.Abs(this.Start.X-this.End.X);
            //    int dy=System.Math.Abs(this.Start.Y-this.End.Y);
            //    int max = (dx > dx) ? dx : dy;//ȡ����

            //    dc.DrawEllipse(pen, this.Start.X, this.Start.Y, this.End.X - this.Start.X, this.End.Y - this.Start.Y);
            //}
            return true;
        }

        public override void SelectedMode(bool selected)
        {
            if (selected == true)
            {
                this.ToOld();

                this.brush = Brushes.Black;
                if (this.Width == 1)
                    Width++;
                if (this.Fill == true)
                    this.brushIn = Brushes.BurlyWood;
                this.IsSelected = true;
            }
            else if(selected == false)
            {
                this.OldTo();
            }
        }


        public override void MoveGraphic(Point p1, Point p2)
        {
            Size move = new Size(p2.X - p1.X, p2.Y - p1.Y);
            this.Start += move;
            this.End += move;

            this.Start0 = this.Start;
            this.End0 = this.End;
            //this.Start = new Point(this.Start.X + move.Width, this.Start.Y + move.Height);
            //this.End = new Point(this.End.X + move.Width, this.End.Y + move.Height);
           
        }

        #endregion
    }

    /// <summary>
    /// ������
    /// </summary>
    public  class rectangle : ellipse
    {
        #region ��������
        #endregion

        #region ���η���

       public rectangle() { }

       //���캯��
       public rectangle(Point p1, Point p2) : base(p1, p2) { }

       public override bool OnGraphic(Point p)
       {
           int x1, x2, x, y1, y2, y;
           x1 = this.Start.X;
           x2 = this.End.X;
           x = p.X;
           y1 = this.Start.Y;
           y2 = this.End.Y;
           y = p.Y;


           //Region rg=new Region (new Rectangle(x1,y1,,x2-x1,y2-y1));
           if ((x1 <= x && x <= x2 || x1 >= x && x >= x2) && (y1 <= y && y <= y2 || y1 >= y && y >= y2))
               return true;
           else
               return false;
       }

       public override bool DrawGraphic(Graphics dc)
       {
           Pen pen = new Pen(this.brush, this.Width);//��������

           //int x1, x2, y1, y2;
           //x1 = this.Start.X;
           //x2 = this.End.X;
           //y1 = this.Start.Y;
           //y2 = this.End.Y;

           //dc.DrawRectangle (pen,x1,y1,x2-x1,y2-y1);
           //if (this.Fill)
           //    dc.FillRectangle(this.brushIn,x1,y1,x2-x1,y2-y1);
           //return true;


           Point p1 = this.Start;
           Point p2 = this.End;

           int dx = System.Math.Abs(p1.X - p2.X);
           int dy = System.Math.Abs(p1.Y - p2.Y);

           Size z;

           if (p1.X <= p2.X)
           {
               if (p1.Y <= p2.Y)
                   z = new Size(dx,dy);
               else
                   z = new Size(dx, -dy);
           }
           else
           {
               if (p1.Y <= p2.Y)
                   z = new Size(-dx, dy);
               else
                   z = new Size(-dx, -dy);
           }

           dc.DrawRectangle(pen,p1.X,p1.Y,z.Width,z.Height);
           if (this.Fill)
               dc.FillRectangle(this.brushIn, p1.X, p1.Y, z.Width, z.Height);
           return true;
       }

        #endregion
    }

    /// <summary>
    /// Ǧ����
    /// </summary>
    public class pencil : line
    {
        #region Ǧ������

        //public ArrayList points0 = new ArrayList();//���ݵ�����

        //public ArrayList points = new ArrayList();

        public Point[] points = new Point[1000];//������

        public Point[] points0 = new Point[1000];

        public int pointIndex = 0;//��¼ʵ���������

        public int pointIndex0 = 0;

        
        #endregion

        #region Ǧ�ʷ���

        public pencil() 
        {
            this.Width = 1;
            this.brush = Brushes.Black;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public pencil(Point p1,Point p2):base(p1,p2)
        {
            //points.Add(p1);
            //points.Add(p2);
            points.SetValue(p1,0);
            points.SetValue(p2,1);
            this.pointIndex = 1;
            this.Width = 1;
            this.brush = Brushes.Black;
        }

        public override void ToOld()
        {
            base.ToOld();
            //points0.Clear();
            //for (int i = 0; i < points.Count; i++)
            //{
            //    Point p = (Point)points[i];
            //    Point p0 = new Point(p.X,p.Y);
            //    points0.Add( p0) ;
            //}
            for (int i = 0; i <=this.pointIndex; i++)
                points0.SetValue(points.GetValue(i), i);


            this.pointIndex0 = this.pointIndex;


            
        }

        public override void OldTo()
        {
            base.OldTo();
            //points.Clear();
            //for (int i = 0; i < points0.Count; i++)
            //{
            //    Point p0 = (Point)points0[i];
            //    Point p = new Point(p0.X, p0.Y);
            //    points.Add(p);
            //}
            for (int i = 0; i <=this.pointIndex; i++)
                points.SetValue(points0.GetValue(i), i);


            this.pointIndex = this.pointIndex0;


          
        }


        public override bool DrawGraphic(Graphics dc)
        {
            Point p, next;
            Pen pen = new Pen(this.brush, this.Width);
            //for (int i=0;i<points.Count-1;i++)
            //{
            //    p = (Point)points[i];
            //    next = (Point)points[i + 1];

                
            //    dc.DrawLine(pen,p,next);
            //}

            for (int i = 0; i < pointIndex; i++)
            {
                p = (Point)points.GetValue(i);
                next = (Point)points.GetValue(i + 1);

                dc.DrawLine(pen, p, next);
            }

            //  dc.DrawLines(pen,points);//��������Ԫ�ض���0������
                return true;
        }

        public override bool OnGraphic(Point p)
        {
            Point q, next;
            for (int i = 0; i <= this.pointIndex; i++)
            {
                q = (Point)points.GetValue(i);
                next = (Point)points.GetValue(i + 1);

                bool On=false;//��¼�Ƿ���ÿ������ֱ����

                double x1, x2, y1, y2, d0, d1, d2, d3, x0, y0, ave;

                x1 = (double)q.X;
                y1 = (double)q.Y;
                x2 = (double)next.X;
                y2 = (double)next.Y;

                //�������
                x0 = p.X;
                y0 = p.Y;

                if ((x0 > x1 && x0 < x2) || (x0 > x2 && x0 < x1))//�жϵ��λ���Ƿ��ڷ�Χ����
                {
                    d1 = System.Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));//���λ�õ�������
                    d2 = System.Math.Sqrt((x2 - x0) * (x2 - x0) + (y2 - y0) * (y2 - y0));//���λ�õ��յ����
                    d3 = System.Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));//ֱ�߾���

                    ave = (d1 + d2 + d3) / 2;

                    d0 = System.Math.Sqrt(ave * (ave - d1) * (ave - d2) * (ave - d3)) / d3;//���λ�õ�ֱ�ߵľ���

                    if (d0 < 2)
                    {
                        On=true;
                    }
                    else On= false;
                }
                else On=false;


                if (On)
                {
                    return true;
                }
            }
            return false;
        }

        public override void SelectedMode(bool selected)
        {
            //Point p, next;
            if (selected == true)
            {
                ////*********************this.ToOld();

               
                //this.Start0 = this.Start;
                //this.End0 = this.End;
                //this.Width0 = this.Width;
                //this.index0 = this.index;
                //this.IsSelected0 = this.IsSelected;   
                //this.brush0 = this.brush;
                //points0.Clear();
                //for (int i = 0; i < points.Count; i++)
                //{
                //    Point pp = (Point)points[i];
                //    Point p0 = new Point(pp.X, pp.Y);
                //    points0.Add(p0);
                //}
                ////*************************************

                this.ToOld();

                //����ѡ��ģʽ������
                this.brush = Brushes.Black;
                if (Width == 1)//�����ϴ������ͻ��úܴ֣�����
                    this.Width++;
                this.IsSelected = true;
            }
            else if (selected == false)
            {

                ////**************this.OldTo()
                //this.Start = this.Start0;
                //this.End = this.End0;
                //this.Width =this.Width0;
                //this.index = this.index0;
                //this.IsSelected = this.IsSelected0;
                //this.brush = this.brush0;
                //points.Clear();
                //for (int i = 0; i < points0.Count; i++)
                //{
                //    Point p0 = (Point)points0[i];
                //    Point pp = new Point(p0.X, p0.Y);
                //    points.Add(pp);
                //}
                ////****************************
                this.OldTo();
            }     
            
        }

        public override void MoveGraphic(Point p1, Point p2)
        {
            Size move = new Size(p2.X - p1.X, p2.Y - p1.Y);
            Point p;
            for (int i = 0; i <=this.pointIndex; i++)
            {
                p = (Point)points.GetValue(i);
                p += move;
                points.SetValue(p,i);
            }

            //�ƶ�ֻ�豣����λ�ã���Ҫ��������ʽ��������
            //2009��3��15�� �����������֣�������
            for (int i = 0; i <= this.pointIndex; i++)
                points0.SetValue(points.GetValue(i), i);
        }

        //���Ǧ���ϵĵ�
        public void AddPoint(Point p)
        {
            points.SetValue(p,this.pointIndex+1);
            pointIndex++;
            this.End = p;
        }
        #endregion
    }


    /// <summary>
    /// ������
    /// </summary>
    public class curve : pencil
    {
        #region ��������

        #endregion

        #region ���߷���

        public curve() 
        {
            this.Width = 1;
            this.brush = Brushes.Black;
        }

        public curve(Point p1,Point p2):base(p1,p2) 
        {
            this.points.SetValue(p1, 0);
            this.points.SetValue(p1, 1);
            this.points.SetValue(p1, 2);

            this.Width = 1;
            this.brush = Brushes.Black;
        }

        public override bool OnGraphic(Point q)
        {
            int MaxX=0, MaxY=0,MinX=1280,MinY=780;
            Point p;
            for (int i = 0; i <=this.pointIndex; i++)
            {
                p = (Point)points[i];
                MaxX = (MaxX > p.X) ? MaxX : p.X;//��ȡ
                MaxY = (MaxY > p.Y) ? MaxY : p.Y;

                MinX = (MinX < p.X) ? MinX : p.X;
                MinY = (MinY < p.Y) ? MinY : p.Y;
            }

            int x1, x2, x, y1, y2, y;
            x1 = MinX;
            x2 = MaxX;
            x = q.X;
            y1 = MinY;
            y2 = MaxY;
            y = q.Y;

            if ((x1 <= x && x <= x2 || x1 >= x && x >= x2) && (y1 <= y && y <= y2 || y1 >= y && y >= y2))
                return true;
            else
                return false;

            
        }

        public override bool DrawGraphic(Graphics dc)
        {
            Pen pen = new Pen(this.brush,Width);
            Point[] DrawPoints=new Point [this.pointIndex+1];
            for (int i = 0; i <= pointIndex; i++)
            {
                DrawPoints.SetValue(points.GetValue(i), i);
            }
                dc.DrawCurve(pen, DrawPoints);
            return true;
        }


        #endregion 
    }

    public class poly : curve
    {
        #region ���������
        #endregion

        #region ����η���

        public poly() 
        {
            this.Width = 1;
            this.brush = Brushes.Black;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public poly(Point p1,Point p2):base(p1,p2) 
        {        

            this.Width = 1;
            this.brush = Brushes.Black;
        }

        public override bool DrawGraphic(Graphics dc)
        {
            Pen pen = new Pen(this.brush, Width);
            Point[] DrawPoints = new Point[this.pointIndex + 1];
            for (int i = 0; i <= pointIndex; i++)
            {
                DrawPoints.SetValue(points.GetValue(i), i);
            }
            dc.DrawPolygon(pen, DrawPoints);
            return true;

        }

        #endregion 
    }

    public class text : rectangle
    {        
        public Font font = new Font("����",15);

        public string content ="";//����

        //public StringFormat myFormat=new StringFormat ();//��ʽ

        public text()
        {
            this.brushIn = Brushes.Black; 
            //IsSelected = true; 
        }
        public text(Point p1, Point p2) : base(p1, p2)
        {
            this.Start = p1;
            this.End = p1 + new Size(10, 10);
            this.brushIn = Brushes.Black;
            //IsSelected = true;
        }


        public override bool DrawGraphic(Graphics dc)
        {
            Brush b = new SolidBrush(Color.Gray);
            Pen pen = new Pen(b,1);//��������

            Point p1 = this.Start;
            Point p2 = this.End;

            int dx = System.Math.Abs(p1.X - p2.X);
            int dy = System.Math.Abs(p1.Y - p2.Y);

            Size z;

            if (p1.X <= p2.X)
            {
                if (p1.Y <= p2.Y)
                    z = new Size(dx, dy);
                else
                    z = new Size(dx, -dy);
            }
            else
            {
                if (p1.Y <= p2.Y)
                    z = new Size(-dx, dy);
                else
                    z = new Size(-dx, -dy);
            }
            if (IsSelected)
                dc.DrawRectangle(pen, p1.X, p1.Y, z.Width, z.Height);
            if (true)
            {
                dc.DrawString(content, font, brushIn, Start.X, Start.Y, new StringFormat());
            }
            return true;
        }
    }
}