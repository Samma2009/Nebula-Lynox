using Cosmos.System;
using Cosmos.System.Graphics;
using Lynox.SEF.CLI;
using Lynox.SEF.CPU;
using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDistro.GraphicMode
{
    internal class graphics
    {

        public static bool isgui = true;
        public static Canvas canvas;

        public static void entry(uint collumns = 1280,uint rows = 720)
        {

            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(collumns,rows,ColorDepth.ColorDepth32));
            MouseManager.ScreenWidth = collumns;
            MouseManager.ScreenHeight = rows;
            canvas.Clear(Color.DodgerBlue);
            ProcessUpdates();
            canvas.Display();
        }

        static void ProcessUpdates()
        {

            int Xcalc = (int)canvas.Mode.Height - 70,Ycalc = (int)canvas.Mode.Width / 3;
            int center = (int)canvas.Mode.Width / 2 - Ycalc / 2;

            while (true)
            {
                canvas.Clear(Color.DodgerBlue);
                canvas.DrawFilledRectangle(Color.FromArgb(100,0,0,0),center, Xcalc, Ycalc, 60);
                UpdateMouse();
                canvas.Display();

            }

        }

        static void UpdateMouse()
        {

            canvas.DrawFilledRectangle(Color.White,(int)MouseManager.X,(int)MouseManager.Y,10,10);

        }

    }
}
