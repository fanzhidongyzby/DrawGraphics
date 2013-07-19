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
    #region ��¼Property�ؼ�ֵ����

    public static class SavePropertyControl
    {
        //��¼�����Ŀؼ�ֵ
        public static int Width = 1;
        public static Color LineFore = Color.Black;
        public static Color LineBack = Color.White;
        public static string LineStyle = "Solid";

        //��¼���Ŀؼ�ֵ
        public static bool Fill = false;
        public static Color FillFore = Color.Black;
        public static Color FillBack = Color.White;
        public static string FillStyle = "Solid";

        //��¼Hatch��ʽ��ֵ
        //public static string hatchStyle = "Cross";
        public static string LineHacthStyle = "Cross";//��¼Hatch��Ӧ��������ʽ
        public static string FillHacthStyle = "Cross";//��¼Hatch��Ӧ�������ʽ

    };
    #endregion 

    #region ��¼Form1Property������ֵ
    public static class SaveForm1Property
    {
        //public static bool MenuCheck=true;
        //public static bool StatusCheck=true;
        //public static bool ToolCheck = true;

        public static Color MenuColor =Color.FromArgb(255,255,255,192);
        public static Color StatusColor = Color.FromArgb(255,255,192,128);
        public static Color ToolColor = Color.FromArgb(255, 255, 192, 128);

        public static Color BackColor = Color.White;

        public static bool Change = false;
    }



    #endregion

    
    #region ��¼TextProperty������ֵ
    public static class SaveTextProperty
    {
        public static Font TextFont = new Font("����",15);
        public static string TextContent = "�����Ҫ������ı�...";

        public static Color TextFore = Color.Black;
        public static Color TextBack = Color.White;

        public static string TextStyle = "Solid";
        public static string TextHacthStyle = "Cross";//��¼Hatch��Ӧ�������ʽ

    }


    #endregion

}