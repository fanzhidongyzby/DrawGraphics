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

        #region ��������


        /// <summary>
        /// ���������Ա
        /// </summary>
        public ArrayList  graphiclist;
        /// <summary>
        /// ������
        /// </summary>
        public int length
        {
            get { return graphiclist.Count ; }
        }

        private int _SelectedIndex;
        /// <summary>
        /// ��¼ѡ�������
        /// </summary>
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
        }

        private Point _SelectedPoint;
        /// <summary>
        ///ѡ��ʱ�ĵ�����
        /// </summary>
        public Point SelectedPoint
        {
            get { return _SelectedPoint; }
            set { _SelectedPoint = value; }
        }

        bool find=false;
        /// <summary>
        /// �Ƿ���������ͼ�α�ѡ��
        /// </summary>
        public bool Find
        {
            get { return find; }
        }

        #endregion

        #region ������


        /// <summary>
        /// ���캯��
        /// </summary>
        public  list()
        {
            this.graphiclist  = new ArrayList();
        }




        #region ��ͨ�����������
        /// <summary>
        /// ��Ӷ���
        /// </summary>
        /// <param name="g"></param>
        public void AddGraphic(graphic g)
        {
            g.index = graphiclist.Count ;//��������Ķ���������������
            graphiclist.Add(g);
        }

        /// <summary>
        /// ɾ������
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
        /// �������
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

        #region ��ȡ������ʼ�յ�
        /// <summary>
        /// �����������øı�ͼ�ζ�������λ��
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
                    g.Start = p;//����
                }
                else
                    p = g.Start;//��ȡ

                //foreach (graphic g in graphiclist)
                //{
                //    if (g.index == Index)
                //    {
                //        if (Set)
                //        {
                //            g.Start = p;//����
                //            break;
                //        }
                //        else
                //            p = g.Start;//��ȡ
                //    }
                //}
            }
            else
                throw new Exception("������Χ����ȷ��");
        }

       
        /// <summary>
        /// �����������øı�ͼ�ζ����յ��λ��
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
                    g.End = p;//����
                }
                else
                    p = g.End;//��ȡ
                //foreach (graphic g in graphiclist)
                //{
                //    if (g.index == Index )
                //    {
                //        if (Set)
                //        {
                //            g.End = p;//����
                //            break;
                //        }
                //        else
                //            p = g.End;//��ȡ
                //    }                        
                //}
            }
            else
                throw new Exception("������Χ����ȷ��");
        }
        #endregion


        /// <summary>
        ///��ȡ������ͼ����������Ч����-1
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
                    this.find = true;//�ҵ�ͼ��
                    this._SelectedIndex = g.index;//��¼ѡ������
                    this._SelectedPoint = p;//��¼������

                    ////�ı��������
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
            return -1;//��Ч���
        }



        /// <summary>
        /// ����ѡ����ģʽ
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="selected">�Ƿ�����Ч��</param>
        public void SelectedGraphicMode(int Index,bool selected)
        {
            foreach (graphic g in graphiclist)
            {
                if (selected&&g.index ==Index)//�Ѿ���OnIndex��������ȷ��Index���ڣ�����ֻ�Ƕ�λ
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
        /// �ƶ�����������ͼ��
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
        /// ����ͼ������������ƣ�
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