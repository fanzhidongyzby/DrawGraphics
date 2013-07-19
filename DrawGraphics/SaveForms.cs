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
    #region 记录Property控件值的类

    public static class SavePropertyControl
    {
        //记录线条的控件值
        public static int Width = 1;
        public static Color LineFore = Color.Black;
        public static Color LineBack = Color.White;
        public static string LineStyle = "Solid";

        //记录填充的控件值
        public static bool Fill = false;
        public static Color FillFore = Color.Black;
        public static Color FillBack = Color.White;
        public static string FillStyle = "Solid";

        //记录Hatch样式的值
        //public static string hatchStyle = "Cross";
        public static string LineHacthStyle = "Cross";//记录Hatch对应的线条样式
        public static string FillHacthStyle = "Cross";//记录Hatch对应的填充样式

    };
    #endregion 

    #region 记录Form1Property的属性值
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

    
    #region 记录TextProperty的属性值
    public static class SaveTextProperty
    {
        public static Font TextFont = new Font("黑体",15);
        public static string TextContent = "请键入要插入的文本...";

        public static Color TextFore = Color.Black;
        public static Color TextBack = Color.White;

        public static string TextStyle = "Solid";
        public static string TextHacthStyle = "Cross";//记录Hatch对应的填充样式

    }


    #endregion

}