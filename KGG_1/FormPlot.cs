using KGG_1.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KGG_1
{
    public partial class FormPlot : Form
    {
        private int A, B, C, Alpha, Beta;
        public FormPlot()
        {
            InitializeComponent();

            // Тултип с функцией
            buttonDrawPlot.Tag = Resources.Task1Function;

            // Значения по умолчанию
            textBoxA.Text = "1";
            textBoxB.Text = "-3";
            textBoxC.Text = "1";
            textBoxAlpha.Text = "-50";
            textBoxBeta.Text = "50";

            InitCoefficients();
        }

        private void buttonDrawPlot_Click(object sender, EventArgs e)
        {
            InitCoefficients();
            pictureBoxPlot.Invalidate();
        }

        private void pictureBoxPlot_Paint(object sender, PaintEventArgs e)
        {
            int maxX = pictureBoxPlot.Width;
            int maxY = pictureBoxPlot.Height;

            int centerY; // пиксель по x в котором рисовать ось oy
            if (Alpha < 0 && Beta > 0)
            {
                centerY = -Alpha * maxX/(Beta - Alpha);
            }
            else if(Alpha >= 0 && Beta > 0)
            {
                centerY = 0;
            }
            else
            {
                centerY = maxX - 1;
            }
            e.Graphics.DrawLine(Pens.Blue, centerY, 0, centerY, maxY);

            int centerX = maxY / 2; // пиксель по y в котором рисовать ось ox
            e.Graphics.DrawLine(Pens.Blue, 0, centerX, maxX, centerX);

            int yy, xxPrev = 0, yyPrev = 0;
            double x, y, yyDouble, denominator;
            //нарисовать оси, вычислив центр
            for(int xx = 0; xx < maxX; ++xx)
            {
                x = Alpha + (double)(xx * (Beta - Alpha))/(double)maxX;
                denominator = (B + x) * (C - x) * (C - x);

                if(Math.Abs(denominator) > 0.000001)
                {
                    y = A * x / denominator;
                    yyDouble = maxY - y * (maxY / (double)(Math.Abs(Beta) + Math.Abs(Alpha)));
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

        private void InitCoefficients()
        {
            A = Int32.Parse(textBoxA.Text);
            B = Int32.Parse(textBoxB.Text);
            C = Int32.Parse(textBoxC.Text);
            Alpha = Int32.Parse(textBoxAlpha.Text);
            Beta = Int32.Parse(textBoxBeta.Text);
        }

        // двойной клик на пункт
        //void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    int index = this.listBox1.IndexFromPoint(e.Location);
        //    if (index != System.Windows.Forms.ListBox.NoMatches)
        //    {
        //        MessageBox.Show(index.ToString());
        //    }
        //}

        //как скрывать элементы
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    groupbox1.Visible = true;
        //    groupbox2.Visible = !groupbox1.Visible;
        //    groupbox3..... = !groupbox1.Visible; //etc
        //}
    }
}
