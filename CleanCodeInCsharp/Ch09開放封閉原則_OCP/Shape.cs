using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// OCP: 開放擴充、封閉修改，唯有同類變化發生時，即可以抽象做隔離。
/// </summary>
namespace CleanCodeInCsharp.Ch09開放封閉原則_OCP
{
    public interface Shape
    {
        void Draw();
    }

    public class Square : Shape
    {
        public void Draw()
        {
            //繪製正方形
        }
    }

    public class Circle : Shape
    {
        public void Draw()
        {
            //繪製圓形
        }
    }

    public class Painter
    {
        public void DrawAllShapes(IEnumerable<Shape> shapes)
        {
            foreach(Shape shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}