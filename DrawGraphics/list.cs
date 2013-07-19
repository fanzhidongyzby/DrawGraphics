using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
namespace DrawGraphics
{
   
    public class  list
    {

        #region 链表属性


        /// <summary>
        /// 数组链表成员
        /// </summary>
        public ArrayList  graphiclist;
        /// <summary>
        /// 链表长度
        /// </summary>
        public int length
        {
            get { return graphiclist.Count ; }
        }

        private int _SelectedIndex;
        /// <summary>
        /// 记录选择的索引
        /// </summary>
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
        }

        private Point _SelectedPoint;
        /// <summary>
        ///选择时的单击点
        /// </summary>
        public Point SelectedPoint
        {
            get { return _SelectedPoint; }
            set { _SelectedPoint = value; }
        }

        bool find=false;
        /// <summary>
        /// 是否链表中有图形被选中
        /// </summary>
        public bool Find
        {
            get { return find; }
        }

        #endregion

        #region 链表方法


        /// <summary>
        /// 构造函数
        /// </summary>
        public  list()
        {
            this.graphiclist  = new ArrayList();
        }




        #region 普通链表基本功能
        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="g"></param>
        public void AddGraphic(graphic g)
        {
            g.index = graphiclist.Count ;//加入链表的对象索引是链表长度
            graphiclist.Add(g);
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="Index"></param>
        public void RemoveGraphic(int Index)
        {
            if(Index >=0&&Index <graphiclist.Count )
            {
                graphiclist.RemoveAt (Index);
                for (int i = Index+1; i < graphiclist.Count; i++)
                {
                    graphic g = (graphic )graphiclist[i];
                    g.index--;
                    graphiclist[i] = g;
                }
            }
        }

        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="g"></param>
        public void InsertGraphic(int Index, graphic g)
        {
            if (Index >= 0 && Index < graphiclist.Count)
            {
                g.index = Index+1;
                graphiclist.Insert(Index, g);
                for (int i = Index + 2; i < graphiclist.Count; i++)
                {
                    graphic gra = (graphic )graphiclist[i];
                    gra.index++;
                    graphiclist[i] = gra;
                }
            }
        }
        #endregion

        #region 获取或设置始终点
        /// <summary>
        /// 在链表中设置改变图形对象起点的位置
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="p"></param>
        /// <param name="Set"></param>
        /// <returns></returns>
        public void  IndexStart(int Index, ref Point p,bool Set)
        {
            if (Index >= 0 && Index < length)
            {

                graphic g=(graphic)graphiclist[Index];
                if (Set)
                {
                    g.Start = p;//设置
                }
                else
                    p = g.Start;//获取

                //foreach (graphic g in graphiclist)
                //{
                //    if (g.index == Index)
                //    {
                //        if (Set)
                //        {
                //            g.Start = p;//设置
                //            break;
                //        }
                //        else
                //            p = g.Start;//获取
                //    }
                //}
            }
            else
                throw new Exception("索引范围不正确！");
        }

       
        /// <summary>
        /// 在链表中设置改变图形对象终点的位置
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="p"></param>
        /// <param name="Set"></param>
        /// <returns></returns>
        public void  IndexEnd(int Index, ref Point p,bool Set)
        {
            if (Index >= 0 && Index < length)
            {

                graphic g = (graphic)graphiclist[Index];
                if (Set)
                {
                    g.End = p;//设置
                }
                else
                    p = g.End;//获取
                //foreach (graphic g in graphiclist)
                //{
                //    if (g.index == Index )
                //    {
                //        if (Set)
                //        {
                //            g.End = p;//设置
                //            break;
                //        }
                //        else
                //            p = g.End;//获取
                //    }                        
                //}
            }
            else
                throw new Exception("索引范围不正确！");
        }
        #endregion


        /// <summary>
        ///获取单击的图形索引，无效返回-1
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int OnIndex(Point p)
        {
            for (int i = graphiclist.Count-1; i >=0 ; i--)
            {
                graphic g=(graphic)graphiclist[i];

                if (g.OnGraphic(p))
                {
                    this.find = true;//找到图形
                    this._SelectedIndex = g.index;//记录选择索引
                    this._SelectedPoint = p;//记录单击点

                    ////改变对象索引
                    //for (int j = g.index+1; j< graphiclist.Count; j++)
                    //{
                    //    graphic gra = (graphic)graphiclist[j];
                    //    gra.index--;
                    //}
                    //g.index = graphiclist.Count - 1;

                    return g.index;
                }
            }
            this.find = false;
            return -1;//无效点击
        }



        /// <summary>
        /// 设置选则择模式
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="selected">是否是有效点</param>
        public void SelectedGraphicMode(int Index,bool selected)
        {
            foreach (graphic g in graphiclist)
            {
                if (selected&&g.index ==Index)//已经由OnIndex（）函数确定Index存在，这里只是定位
                {
                    g.SelectedMode(true);
                }
                else 
                {
                    if (g.IsSelected)
                        g.SelectedMode(false);
                }
            }
        }

        /// <summary>
        /// 移动所定索引的图形
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public void MoveIndex(int Index, Point p1, Point p2)
        {
            graphic g = (graphic)graphiclist[Index];
            g.MoveGraphic(p1, p2);
        }

        /// <summary>
        /// 绘制图形链表（倒序绘制）
        /// </summary>
        /// <param name="dc"></param>
        public void DrawGraphic(Graphics dc)
        {
           
            
            for (int i = 0; i < graphiclist.Count; i++)
            {
                foreach (graphic g in graphiclist)
                {
                    if (g.index == i)
                    {
                        g.DrawGraphic(dc);
                    }
                }
            }
        }


        #endregion
    }
}