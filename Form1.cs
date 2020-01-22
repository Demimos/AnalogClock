using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogClock
{
   
    public partial class Form1 : Form
    {
        int Center = 205;
        int radiusNum=190;
        public Form1()
        {
            InitializeComponent();
  
        }

        
        


        private void UpdateTime()
        {
            if (clockBox.BackgroundImage==null)
            {
                BackGroundRender();
            }
            var d = DateTime.Now;
            var t = clockBox.CreateGraphics();

            //Рисуем стрелки
            double lengthSeconds = radiusNum - 10;
            double lengthMinutes = radiusNum - 15;
            double lengthHour = lengthMinutes / 1.5;
           
            double t_sec =  d.Second*6;                           //Определяем угол для секунд
            double t_min = ((double)d.Minute + (double)d.Second/60)*6; //Определяем угол для минут
            double t_hour =  ((double)d.Hour +  (double)d.Minute/60)*30; //Определяем угол для часов

            //Рисуем часы
            t.DrawLine(new Pen(Color.DarkGray, 7), Center, Center, (float)(Center + lengthHour * Math.Cos(Math.PI / 2 - t_hour * (Math.PI / 180))),
                (float)(Center - lengthHour * Math.Sin(Math.PI / 2 - t_hour * (Math.PI / 180))));

            //Рисуем минуты
            t.DrawLine(new Pen(Color.Black, 5), Center, Center, (float)(Center + lengthMinutes * Math.Cos(Math.PI / 2 - t_min * (Math.PI / 180))),
                (float)(Center - lengthMinutes * Math.Sin(Math.PI / 2 - t_min * (Math.PI / 180))));

            //Рисуем секунды
            t.DrawLine(new Pen(Color.Red), Center, Center, (float)(Center + lengthSeconds * Math.Cos(Math.PI / 2 - t_sec * (Math.PI / 180))),
                (float)(Center - lengthSeconds * Math.Sin(Math.PI / 2 - t_sec * (Math.PI / 180))));


        }

        private void BackGroundRender()
        {
            var back = new Bitmap(410, 410);
            var g = Graphics.FromImage(back);
            g.Clear(Color.White);
            g.DrawEllipse(new Pen(Color.Black, 2) { Width = 2.0f }, new Rectangle(5, 5, 400, 400));
            radiusNum = 190;
            for (var tm = 0; tm < 60; tm++)
            {
                int width;
                if (tm % 5 == 0)
                    width = 5;
                else
                    width = 2;
                var xPointM = Center + radiusNum * Math.Cos(-6 * tm * (Math.PI / 180) + Math.PI / 2);
                var yPointM = Center - radiusNum * Math.Sin(-6 * tm * (Math.PI / 180) + Math.PI / 2);
                g.DrawEllipse(new Pen(Color.Black, 1), new Rectangle((int)(xPointM - width), (int)(yPointM - width), width * 2, width * 2));

            }

            //Оцифровка циферблата часов
            var start = 1;
            var stop = 12;
            //циферблат 1-12 или 13-24
            //if (date[3] >= 12)
            //{
            //    start = 13;
            //    stop = 24;
            //}
            for (var th = start; th <= stop; th++)
            {
                var xText = Center + (radiusNum - 20) * Math.Cos(-30 * th * (Math.PI / 180) + Math.PI / 2);
                var yText = Center - (radiusNum - 20) * Math.Sin(-30 * th * (Math.PI / 180) + Math.PI / 2);
                if (th <= 9)
                {
                    g.DrawString(th.ToString(), DefaultFont, new SolidBrush(Color.Black), new Point((int)(xText - 5), (int)(yText - 6)));
                }
                else
                {
                    g.DrawString(th.ToString(), DefaultFont, new SolidBrush(Color.Black), new Point((int)(xText - 7), (int)(yText - 6)));
                }

            }

            clockBox.BackgroundImage = back;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
            Refresh();
            UpdateTime();
        }
    }
}
