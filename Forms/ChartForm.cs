using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace Battleship.Forms
{
    public partial class ChartForm : Form
    {
        double startPoint = 1;
        double endPoint;
        double x, y;
        double step = 0.01;
        double maxValue;
        double minValue;
        double averageValue;
        int count;
        public ChartForm()
        {
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
        }
        private async void BS_CHF_ChartDraw_Click(object sender, EventArgs e)
        {
            await ChartDraw();
        }
        async Task ChartDraw()
        {
            ChartClear();
            CRT_ChanceChange.Series[0].Points.AddXY(0, 20);
            for (int i = 1; i <= EnemyData.IndependentChances.Count; i++)
            {
                await Task.Delay(20);
                y = EnemyData.IndependentChances[i] * 100;
                CRT_ChanceChange.Series[0].Points.AddXY(i, y);
                await Task.Delay(20);
                TB_CHF_IndependentChances.Text += $"Move #{i}  {EnemyData.IndependentChances[i] * 100}%";
                if (i != EnemyData.IndependentChances.Count)
                {
                    TB_CHF_IndependentChances.Text += "\r\n";
                }
                TB_CHF_IndependentChances.SelectionStart = TB_CHF_IndependentChances.Text.Length;
            }
            minValue = EnemyData.IndependentChances.Values.Min();
            minValue = EnemyData.IndependentChances.Values.Max();
            GetAverage();
            count = EnemyData.IndependentChances.Count();
            SetTextBoxValues();
        }

        private void BS_CHF_ChartDelete_Click(object sender, EventArgs e)
        {
            ChartClear();
            TB_CHF_IndependentChances.Clear();
        }

        private async void BS_CHF_ChartUpdate_Click(object sender, EventArgs e)
        {
            ChartClear();
            await ChartDraw();
        }
        void ChartClear()
        {
            CRT_ChanceChange.Series[0].Points.Clear();
            TB_CHF_AverageValue.Clear();
            TB_CHF_Count.Clear();
            TB_CHF_IndependentChances.Clear();
            TB_CHF_MaxValue.Clear();
            TB_CHF_MinValue.Clear();
        }
        void SetTextBoxValues()
        {
            TB_CHF_MinValue.Text = $"{minValue * 100}%";
            TB_CHF_MaxValue.Text = $"{maxValue * 100}%";
            TB_CHF_AverageValue.Text = $"{averageValue * 100}%";
            TB_CHF_Count.Text = $"{count}";
        }
        void GetAverage()
        {
            double summ = 0;
            for (int i = 1; i <= EnemyData.IndependentChances.Count; i++)
            {
                summ += EnemyData.IndependentChances[i];
            }
            averageValue = Math.Round(summ / (double)EnemyData.IndependentChances.Count, 2);
        }
    }
}
