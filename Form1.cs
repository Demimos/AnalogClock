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
        private string Current { get; set; } = TimeZoneInfo.Local.DisplayName;
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
            foreach (var item in TimeZoneInfo.GetSystemTimeZones()) // прогруз комбобокс
            {
                Zone.Items.Add(item.DisplayName);
                if (Current.Equals(item.DisplayName))
                    Zone.SelectedItem=item.DisplayName;
            }
            
        }

        private void BackGroundRender()
        {
            DateTime d = GetTime();

            date.Text = d.ToLongDateString(); // Дата, чтобы не запутаться

            var back = new Bitmap(400 * 3 + 10, 400 * 3 + 10);// создадим картинку
            var g = Graphics.FromImage(back);

            //циферблат
            g.Clear(Color.White);
            g.DrawEllipse(new Pen(Color.Black, 2) { Width = 2.0f }, new Rectangle(5, 5, 400 * 3, 400 * 3));
            int radiusNum = 190 * 3;
            int Center = (400 * 3 + 10) / 2;
            for (var tm = 0; tm < 60; tm++)
            {
                int width;
                if (tm % 5 == 0)
                    width = 10;
                else
                    width = 5;
                var xPointM = Center + (double)radiusNum * Math.Cos(-6 * tm * (Math.PI / 180) + Math.PI / 2);
                var yPointM = Center - (double)radiusNum * Math.Sin(-6 * tm * (Math.PI / 180) + Math.PI / 2);
                g.DrawEllipse(new Pen(Color.Black, 1), new Rectangle((int)(xPointM - width), (int)(yPointM - width), width * 2, width * 2));

            }

            //Оцифровка циферблата часов
            var start = 1;
            var stop = 12;
            //циферблат 1-12 или 13-24
            if (d.Hour >= 12)
            {
                start = 13;
                stop = 24;
            }

            Font font = new Font(FontFamily.GenericSansSerif,
            40.0F, FontStyle.Bold);
            var pad1 = 26;
            var pad2 = 35;
            for (var th = start; th <= stop; th++)
            {
                var xText = Center + (radiusNum - 70) * Math.Cos(-30 * th * (Math.PI / 180) + Math.PI / 2);
                var yText = Center - (radiusNum - 70) * Math.Sin(-30 * th * (Math.PI / 180) + Math.PI / 2);
                if (th <= 9)
                {
                    g.DrawString(th.ToString(), font, new SolidBrush(Color.Black), new Rectangle((int)(xText - pad1), (int)(yText - pad1), (int)(xText + pad1), (int)(yText + pad1)));
                }
                else
                {
                    g.DrawString(th.ToString(), font, new SolidBrush(Color.Black), new Rectangle((int)(xText - pad2), (int)(yText - pad2), (int)(xText + pad2), (int)(yText + pad2)));
                }

            }

            //var t = clockBox.CreateGraphics();

            //Рисуем стрелки
            double lengthSeconds = radiusNum - 10;
            double lengthMinutes = radiusNum - 15;
            double lengthHour = lengthMinutes / 1.5;

            double t_sec = d.Second * 6;                           //Определяем угол для секунд
            double t_min = ((double)d.Minute + (double)d.Second / 60) * 6; //Определяем угол для минут
            double t_hour = ((double)d.Hour + (double)d.Minute / 60) * 30; //Определяем угол для часов

            //Рисуем часы
            g.DrawLine(new Pen(Color.DarkGray, 7), Center, Center, (float)(Center + lengthHour * Math.Cos(Math.PI / 2 - t_hour * (Math.PI / 180))),
                (float)(Center - lengthHour * Math.Sin(Math.PI / 2 - t_hour * (Math.PI / 180))));

            //Рисуем минуты
            g.DrawLine(new Pen(Color.Black, 5), Center, Center, (float)(Center + lengthMinutes * Math.Cos(Math.PI / 2 - t_min * (Math.PI / 180))),
                (float)(Center - lengthMinutes * Math.Sin(Math.PI / 2 - t_min * (Math.PI / 180))));

            //Рисуем секунды
            g.DrawLine(new Pen(Color.Red), Center, Center, (float)(Center + lengthSeconds * Math.Cos(Math.PI / 2 - t_sec * (Math.PI / 180))),
                (float)(Center - lengthSeconds * Math.Sin(Math.PI / 2 - t_sec * (Math.PI / 180))));

            clockBox.BackgroundImage = back; //отправляем битмэп в бокс
        }

        private DateTime GetTime()
        {
            var d = DateTime.UtcNow;
            var offset = TimeZoneInfo.GetSystemTimeZones().First(t => t.DisplayName.Equals(Current)).BaseUtcOffset;
            d = d.AddHours(offset.Hours);
            d = d.AddMinutes(offset.Minutes);
           
            return d;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            BackGroundRender();
        }

        private void Zone_SelectedIndexChanged(object sender, EventArgs e)
        {
            Current = (sender as ComboBox).SelectedItem.ToString();
            BackGroundRender();
        }

    }
}
