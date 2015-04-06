using KGG_1.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KGG_1
{
    public partial class FormPlot : Form
    {
        private int CartesianPlotA, CartesianPlotB, CartesianPlotC, CartesianPlotAlpha, CartesianPlotBeta;
        private double PPAlpha, PPBeta;
        System.Globalization.NumberFormatInfo fmt = new System.Globalization.NumberFormatInfo();
        public FormPlot()
        {
            InitializeComponent();

            // по умолчанию полярные
            tabControlPlot.SelectedTab = tabPagePolarPlot;

            // Чтобы парсить отрицательные
            fmt.NegativeSign = "-";

            // Тултип с функцией
            buttonDrawCartesianPlot.Tag = Resources.Task1Function;

            // Значения по умолчанию
            textBoxCartesianPlotA.Text = "1";
            textBoxCartesianPlotB.Text = "-3";
            textBoxCartesianPlotC.Text = "1";
            textBoxCartesianPlotAlpha.Text = "-5";
            textBoxCartesianPlotBeta.Text = "5";

            textBoxPolarPlotAlpha.Text = "-15.708";
            textBoxPolarPlotBeta.Text = "15.708";

            InitCoefficientsPlot();
        }

        private void buttonDrawCartesianPlot_Click(object sender, EventArgs e)
        {
            InitCoefficientsPlot();
            pictureBoxCartesianPlot.Invalidate();
        }

        private void pictureBoxCartesianPlot_Paint(object sender, PaintEventArgs e)
        {
            int maxX = pictureBoxCartesianPlot.Width;
            int maxY = pictureBoxCartesianPlot.Height;

            int centerY; // пиксель по x в котором рисовать ось oy
            if (CartesianPlotAlpha < 0 && CartesianPlotBeta > 0)
            {
                centerY = -CartesianPlotAlpha * maxX/(CartesianPlotBeta - CartesianPlotAlpha);
            }
            else if(CartesianPlotAlpha >= 0 && CartesianPlotBeta > 0)
            {
                centerY = 0;
            }
            else
            {
                centerY = maxX - 1;
            }
            int centerX = maxY / 2; // пиксель по y в котором рисовать ось ox
            int partWidth = maxX / (CartesianPlotBeta - CartesianPlotAlpha);
            //сетка
            var font = new Font("Arial", 16);
            var brush = new SolidBrush(Color.Black);
            // вверх от ох
            int counter = 1;
            for (int i = centerX - partWidth; i >= 0; i--)
            {
                e.Graphics.DrawLine(Pens.DarkGray, 0, i, maxX, i);
                e.Graphics.DrawString(counter.ToString(), font, brush, centerY - 20, i);
                i = i - partWidth + 1;
                counter++;
            }
            // вниз от ох
            counter = -1;
            for (int i = centerX + partWidth; i <= maxY; i++)
            {
                e.Graphics.DrawLine(Pens.DarkGray, 0, i, maxX, i);
                e.Graphics.DrawString(counter.ToString(), font, brush, centerY - 25, i);
                i = i + partWidth - 1;
                counter--;
            }
            // влево от оу
            counter = -1;
            for (int i = centerY - partWidth; i >= 0; i--)
            {
                e.Graphics.DrawLine(Pens.DarkGray, i, 0, i, maxY);
                e.Graphics.DrawString(counter.ToString(), font, brush, i - 20, centerX + 5);
                i = i - partWidth + 1;
                counter--;
            }
            // вправо от оу
            counter = 0;
            for (int i = centerY; i <= maxX; i++)
            {
                e.Graphics.DrawLine(Pens.DarkGray, i, 0, i, maxY);
                e.Graphics.DrawString(counter.ToString(), font, brush, i - 20, centerX + 5);
                i = i + partWidth - 1;
                counter++;
            }

            e.Graphics.DrawLine(Pens.Blue, centerY, 0, centerY, maxY);
            e.Graphics.DrawLine(Pens.Blue, 0, centerX, maxX, centerX);

            int yy, xxPrev = 0, yyPrev = 0;
            double x, y, yyDouble, denominator;
            //нарисовать оси, вычислив центр
            for(int xx = 0; xx < maxX; ++xx)
            {
                x = CartesianPlotAlpha + (double)(xx * (CartesianPlotBeta - CartesianPlotAlpha))/(double)maxX;
                denominator = (CartesianPlotB + x) * (CartesianPlotC - x) * (CartesianPlotC - x);

                if(Math.Abs(denominator) > 0.000001)
                {
                    y = CartesianPlotA * x / denominator;
                    yyDouble = maxY - y * (maxY / (double)(Math.Abs(CartesianPlotBeta) + Math.Abs(CartesianPlotAlpha)));
                    yyDouble -= centerX;
                    yy = Convert.ToInt32(yyDouble);
                    if(!(xxPrev == 0) && !(yyPrev == 0))
                    {
                        e.Graphics.DrawLine(Pens.Red, xxPrev, yyPrev, xx, yy);
                    }
                    yyPrev = yy;
                }
                xxPrev = xx;  
            }
        }

        private void InitCoefficientsPlot()
        {
            CartesianPlotA = Int32.Parse(textBoxCartesianPlotA.Text);
            CartesianPlotB = Int32.Parse(textBoxCartesianPlotB.Text);
            CartesianPlotC = Int32.Parse(textBoxCartesianPlotC.Text);
            CartesianPlotAlpha = Int32.Parse(textBoxCartesianPlotAlpha.Text);
            CartesianPlotBeta = Int32.Parse(textBoxCartesianPlotBeta.Text);

            PPAlpha = Double.Parse(textBoxPolarPlotAlpha.Text, fmt);
            PPBeta = Double.Parse(textBoxPolarPlotBeta.Text, fmt);
        }

        private void buttonDrawPolarPlot_Click(object sender, EventArgs e)
        {
            InitCoefficientsPlot();
            pictureBoxPolarPlot.Invalidate();
        }

        private void pictureBoxPolarPlot_Paint(object sender, PaintEventArgs e)
        {
            // экранные размеры полотна
            int maxXX = pictureBoxPolarPlot.Width;
            int maxYY = pictureBoxPolarPlot.Height;

            double maxX = Double.MinValue, minX = Double.MaxValue;
            double maxR = 2.6; // magic constant =)

            var step = Math.PI / 360; // 0.5 градуса
            var i = PPAlpha - step;
            while(i <= PPBeta)
            {
                i += step;
                var r = Math.Acos((i - 1) / (i * i));
                if (r > maxR)
                    continue;
                var x = r * Math.Cos(i);
                var y = r * Math.Sin(i);
                if (x > maxX)
                {
                    maxX = x;
                }  
                if (x < minX)
                {
                    minX = x;
                }
            }
            int xxPrev = (int)(((Math.Acos((PPAlpha - 1) / (PPAlpha * PPAlpha)) * Math.Cos(PPAlpha) - minX) * maxXX) / (maxX - minX));
            int yyPrev = (int)(((Math.Acos((PPAlpha - 1) / (PPAlpha * PPAlpha)) * Math.Sin(PPAlpha) - minX) * maxYY) / (maxX - minX));

            // оси и радиусы
            int xxAxis = (int)((- maxX) * maxXX / (minX - maxX));
            int yyAxis = (int)((- maxX) * maxYY / (minX - maxX));
            MessageBox.Show(maxXX.ToString() +" "+ xxAxis.ToString() +" "+ maxYY.ToString() +" "+ yyAxis.ToString());
            //e.Graphics.DrawEllipse()

            e.Graphics.DrawLine(Pens.Blue, 0, yyAxis, maxXX, yyAxis);
            e.Graphics.DrawLine(Pens.Blue, xxAxis, 0, xxAxis, maxYY);
            
            // считаем функцию
            i = PPAlpha - step;
            var gap = false;
            var first = true;
            while(i <= PPBeta)
            {
                i += step;
                var r = Math.Acos((i - 1) / (i * i));
                if (r > maxR)
                {
                    gap = true;
                    continue;
                }
                var x = -r * Math.Cos(i);
                var y = r * Math.Sin(i);
                int xx = (int)((x - maxX) * maxXX / (minX - maxX));
                int yy = (int)((y - maxX) * maxYY / (minX - maxX));
                if(xx > maxXX || xx < 0 || yy < 0 || yy > maxYY)
                {
                    gap = true;
                    continue;
                }
                if(gap)
                {
                    xxPrev = xx;
                    yyPrev = yy;
                    gap = false;
                }
                if(!first)
                    e.Graphics.DrawLine(Pens.Red, xxPrev, yyPrev, xx, yy);
                xxPrev = xx;
                yyPrev = yy;
                first = false;
            }
        }
    }
}
