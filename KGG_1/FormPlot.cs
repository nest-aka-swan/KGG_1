using KGG_1.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KGG_1
{
    public partial class FormPlot : Form
    {
        List<string> _taskItems = new List<string>();

        public FormPlot()
        {
            InitializeComponent();

            // Панель выбора задач
            _taskItems.Add("График функции");
            _taskItems.Add("Алгоритм Брезенхема");
            _taskItems.Add("Многоугольники");
            _taskItems.Add("График поверхности");
            _taskItems.Add("Удаление невидимых линий");

            listBoxTask.DataSource = _taskItems;

            // Тултип с функцией
            buttonDrawPlot.Tag = Resources.Task1Function;
            //fucking git

            // Значения по умолчанию
            textBoxA.Text = "1";
            textBoxB.Text = "1";
            textBoxC.Text = "1";
            textBoxAlpha.Text = "-10";
            textBoxBeta.Text = "10";
        }
    }
}
