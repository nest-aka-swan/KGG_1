using KGG_1.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KGG_1
{
    public partial class FormPlot : Form
    {
        private int CartesianPlotA, CartesianPlotB, CartesianPlotC, CartesianPlotAlpha, CartesianPlotBeta;
        
        private double PPAlpha, PPBeta;
        System.Globalization.NumberFormatInfo fmt = new System.Globalization.NumberFormatInfo();

        private int BresP; // Bresenham P

        private List<Point> PolygonFirstPoints = new List<Point>(); // точки полигонов кидать сюда
        private List<Point> PolygonSecondPoints = new List<Point>();

        private GraphicsPath PolygonFirstGP = new GraphicsPath();
        private GraphicsPath PolygonSecondGP = new GraphicsPath();
        private Region PolygonSecondR;

        private bool FirstPolygonReady = false;
        private bool SecondPolygonReady = false;
        private Pen PolygonPen = new Pen(Color.Black, 5);
        private Pen PolygonCirclePen = new Pen(Color.Red, 6);

        public FormPlot()
        {
            InitializeComponent();

            // по умолчанию полярные
            tabControlPlot.SelectedTab = tabPagePolygons;

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

            textBoxBresenhamP.Text = "30";

            //Bitmap flag = new Bitmap(200, 100);
            //Graphics flagGraphics = Graphics.FromImage(flag);
            //int red = 0;
            //int white = 11;
            //while (white <= 100)
            //{
            //    flagGraphics.FillRectangle(Brushes.Red, 0, red, 200, 10);
            //    flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
            //    red += 20;
            //    white += 20;
            //}
            //pictureBoxPolygons.Image = flag;

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

            BresP = Int32.Parse(textBoxBresenhamP.Text);
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

        private void buttonDrawBresenham_Click(object sender, EventArgs e)
        {
            InitCoefficientsPlot();
            pictureBoxBresenham.Invalidate();
        }

        private void pictureBoxBresenham_Paint(object sender, PaintEventArgs e)
        {
            int maxXX = 720;
            int maxYY = 510;

            Size tempSize = pictureBoxBresenham.Size;
            tempSize.Width = maxXX;
            tempSize.Height = maxYY;
            pictureBoxBresenham.Size = tempSize;

            int dx = maxXX / 2;
            int dy = maxYY;

            int x0 = 0;
            int y0 = 0;
            int x = 0;
            int y = 0;

            float Sd = ((y0 + 1) * (y0 + 1)) - 2 * BresP * (x0 + 1);
            float Sv = ((y0 + 1) * (y0 + 1)) - 2 * BresP * x0;
            float Sh = (y0 * y0) - 2 * BresP * (x0 + 1);

            e.Graphics.FillRectangle(Brushes.Black, y0 + dx, dy - x0 - 10, 10, 10);

            for(int xx = x0; xx <= maxXX; xx++)
            {
                if (Math.Abs(Sh) - Math.Abs(Sv) <= 0)
                {
                    if (Math.Abs(Sd) - Math.Abs(Sh) < 0)
                        y+=10;
                    x+=10;

                }
                else
                {
                    if (Math.Abs(Sv) - Math.Abs(Sd) > 0)
                        x+=10;
                    y+=10;

                }

                e.Graphics.FillRectangle(Brushes.Black, y + dx, dy - x - 10, 10, 10);
                e.Graphics.FillRectangle(Brushes.Black, maxXX - (y + dx), dy - x - 10, 10, 10);

                Sd = ((y + 1) * (y + 1)) - 2 * BresP * (x + 1);
                Sv = ((y + 1) * (y + 1)) - 2 * BresP * x;
                Sh = (y * y) - 2 * BresP * (x + 1);
            }

            // сетка
            int gridXX = 0;
            int gridYY = 0;
            while(gridXX < maxXX)
            {
                e.Graphics.DrawLine(Pens.Gray, gridXX, 0, gridXX, maxYY);
                gridXX += 10;
            }
            while (gridYY < maxYY)
            {
                e.Graphics.DrawLine(Pens.Gray, 0, gridYY, maxXX, gridYY);
                gridYY += 10;
            }

            // обычный график
            x0 = 0;
            y0 = 0;
            x = 0;
            y = 0;

            Sd = ((y0 + 1) * (y0 + 1)) - 2 * BresP * (x0 + 1);
            Sv = ((y0 + 1) * (y0 + 1)) - 2 * BresP * x0;
            Sh = (y0 * y0) - 2 * BresP * (x0 + 1);

            e.Graphics.FillRectangle(Brushes.Red, y0 + dx, dy - x0, 1, 1);

            for (int xx = x0; xx <= maxXX; xx++)
            {
                if (Math.Abs(Sh) - Math.Abs(Sv) <= 0)
                {
                    if (Math.Abs(Sd) - Math.Abs(Sh) < 0)
                        y++;
                    x++;

                }
                else
                {
                    if (Math.Abs(Sv) - Math.Abs(Sd) > 0)
                        x++;
                    y++;

                }

                e.Graphics.FillRectangle(Brushes.Red, y + dx + 5, dy - x, 1, 1);
                e.Graphics.FillRectangle(Brushes.Red, maxXX - (y + dx) + 5, dy - x, 1, 1);

                Sd = ((y + 1) * (y + 1)) - 2 * BresP * (x + 1);
                Sv = ((y + 1) * (y + 1)) - 2 * BresP * x;
                Sh = (y * y) - 2 * BresP * (x + 1);
            }
        }

        private void buttonPolygonsFirstPolygon_Click(object sender, EventArgs e)
        {
            if (PolygonFirstPoints.Count == 0)
            {
                MessageBox.Show("Нет точек для полигона");
                return;
            }
            
            PolygonFirstPoints.Add(PolygonFirstPoints[0]); // замыкаем
            PolygonFirstGP.AddPolygon(PolygonFirstPoints.ToArray());

            FirstPolygonReady = true;
            buttonPolygonsFirstPolygon.Enabled = false;
            buttonPolygonsSecondPolygon.Enabled = true;
            pictureBoxPolygons.Invalidate();
        }

        private void buttonPolygonsSecondPolygon_Click(object sender, EventArgs e)
        {
            if(PolygonFirstPoints.Count == 0)
            {
                MessageBox.Show("Нет точек для полигона");
                return;
            }

            PolygonSecondPoints.Add(PolygonSecondPoints[0]); // замыкаем
            PolygonSecondGP.AddPolygon(PolygonSecondPoints.ToArray());
            PolygonSecondR = new Region(PolygonSecondGP);
            PolygonSecondR.Xor(PolygonFirstGP);

            SecondPolygonReady = true;
            buttonPolygonsFirstPolygon.Enabled = false;
            buttonPolygonsSecondPolygon.Enabled = false;
            pictureBoxPolygons.Invalidate();
        }

        private void buttonPolygonsReset_Click(object sender, EventArgs e)
        {
            pictureBoxPolygons.Image = null;
            FirstPolygonReady = SecondPolygonReady = false;
            PolygonFirstPoints.Clear();
            PolygonSecondPoints.Clear();
            PolygonFirstGP.Reset();
            PolygonSecondGP.Reset();
            PolygonSecondR = null;
            buttonPolygonsFirstPolygon.Enabled = true;
            buttonPolygonsSecondPolygon.Enabled = false;
            // прибить все массивы точек, фигуры итп
        }

        private void pictureBoxPolygons_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillPath(Brushes.Blue, PolygonFirstGP);
            e.Graphics.FillPath(Brushes.Green, PolygonSecondGP);
            if (PolygonFirstPoints.Count > 1)
            {
                var prevPoint = PolygonFirstPoints[0];
                foreach (var point in PolygonFirstPoints)
                {
                    e.Graphics.DrawLine(PolygonPen, prevPoint, point);
                    prevPoint = point;
                }
            }
            foreach(var point in PolygonFirstPoints)
            {
                e.Graphics.DrawEllipse(PolygonCirclePen, point.X-3, point.Y-3, 6, 6);
            }

            if (PolygonSecondPoints.Count > 1)
            {
                var prevPoint = PolygonSecondPoints[0];
                foreach (var point in PolygonSecondPoints)
                {
                    e.Graphics.DrawLine(PolygonPen, prevPoint, point);
                    prevPoint = point;
                }
            }
            foreach(var point in PolygonSecondPoints)
            {
                e.Graphics.DrawEllipse(PolygonCirclePen, point.X-3, point.Y-3, 6, 6);
            }
            if(PolygonSecondR != null)
            {
                e.Graphics.FillPath(Brushes.White, PolygonFirstGP);
                e.Graphics.FillRegion(Brushes.Violet, PolygonSecondR);
            }
        }

        private void pictureBoxPolygons_Click(object sender, EventArgs e)
        {
            var mousePoint = pictureBoxPolygons.PointToClient(Cursor.Position);
            if(FirstPolygonReady)
            {
                PolygonSecondPoints.Add(mousePoint);
            }
            else
            {
                PolygonFirstPoints.Add(mousePoint);
            }
            pictureBoxPolygons.Invalidate();
        }
        // рисовать
        // https://msdn.microsoft.com/ru-ru/library/system.drawing.drawing2d.graphicspath(v=vs.110).aspx
        // https://msdn.microsoft.com/ru-ru/library/5s2w9y70(v=vs.110).aspx
        // https://msdn.microsoft.com/ru-ru/library/awbdfdhf(v=vs.110).aspx
    }
}
