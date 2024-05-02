using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Forms
{
    public partial class ChartForm : Form
    {
        double y1, y2;
        double maxValue;
        double minValue;
        double averageValue;
        double foundData = 0;

        bool playerChartShow = true;
        bool enemyChartShow = false;
        bool bothChartShow = false;

        int choosenSide = 0;
        int choosenMove = 0;
        int count;
        int decimalPlaces = 2;
        public ChartForm()
        {
            InitializeComponent();
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
        void SetTextBoxValues()
        {
            TB_CHF_MinValue.Text = $"{minValue * 100}%";
            TB_CHF_MaxValue.Text = $"{maxValue * 100}%";
            TB_CHF_AverageValue.Text = $"{averageValue * 100}%";
            TB_CHF_Count.Text = $"{count}";
        }
        async Task ChartClear()
        {
            await Task.Delay(10);
            CRT_ChanceChange.Series[0].Points.Clear();
            CRT_ChanceChange.Series[1].Points.Clear();
            await Task.Delay(10);
            TB_CHF_MaxValue.Clear();
            await Task.Delay(10);
            TB_CHF_MinValue.Clear();
            await Task.Delay(10);
            TB_CHF_AverageValue.Clear();
            await Task.Delay(10);
            TB_CHF_Count.Clear();
            await Task.Delay(10);
            TB_CHF_IndependentChances.Clear();
        }
        async Task ChartDrawPlayer()
        {
            try
            {
                await ChartClear();
                CRT_ChanceChange.Series[0].Points.AddXY(0, 20);
                for (int i = 1; i <= EnemyData.IndependentChances.Count; i++)
                {
                    await Task.Delay(5);
                    y1 = EnemyData.IndependentChances[i] * 100;
                    if (!double.IsNaN(y1) && !double.IsInfinity(y1))
                    {
                        CRT_ChanceChange.Series[0].Points.AddXY(i, y1);
                    }
                    await Task.Delay(5);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Exception Message: \r\n{ex.Message}\r\n\r\nException {ex}", "Exception found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        async Task ChartDrawEnemy()
        {
            try
            {
                await ChartClear();
                CRT_ChanceChange.Series[1].Points.AddXY(0, 20);
                for (int i = 1; i <= PlayerData.IndependentChances.Count; i++)
                {
                    await Task.Delay(20);
                    y2 = PlayerData.IndependentChances[i] * 100;
                    if (!double.IsNaN(y2) && !double.IsInfinity(y2))
                    {
                        CRT_ChanceChange.Series[1].Points.AddXY(i, y2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception Message: \r\n{ex.Message}\r\n\r\nException {ex}", "Exception found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        async Task ChartDrawBoth()
        {
            try
            {
                await ChartClear();
                Task playerDraw = ChartDrawPlayer();
                Task enemyDraw = ChartDrawEnemy();
                await Task.WhenAll(playerDraw, enemyDraw);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception Message: \r\n{ex.Message}\r\n\r\nException {ex}", "Exception found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        async Task DrawChart()
        {
            if (bothChartShow)
            {
                await ChartDrawBoth();
            }
            else if (playerChartShow)
            {
                await ChartDrawPlayer();
            }
            else if (enemyChartShow)
            {
                await ChartDrawEnemy();
            }
        }
        private async void BS_CHF_ChartDraw_Click(object sender, EventArgs e)
        {
            await DrawChart();
        }
        private async void BS_CHF_ChartDelete_Click(object sender, EventArgs e)
        {
            await ChartClear();
            TB_CHF_IndependentChances.Clear();
        }
        private async void BS_CHF_ChartUpdate_Click(object sender, EventArgs e)
        {
            await ChartClear();
            await DrawChart();
        }
        private void CHB_EnemyDataShow_CheckedChanged(object sender, EventArgs e)
        {
            enemyChartShow = CHB_EnemyDataShow.Checked;
            bothChartShow = playerChartShow && enemyChartShow;
            TB_Info_DrawBoth.Visible = bothChartShow;
        }
        private void CHB_PlayerDataShow_CheckedChanged(object sender, EventArgs e)
        {
            playerChartShow = CHB_PlayerDataShow.Checked;
            bothChartShow = playerChartShow && enemyChartShow;
            TB_Info_DrawBoth.Visible = bothChartShow;
        }
        private void TRB_CHF_DecimalPlaces_Scroll(object sender, EventArgs e)
        {
            decimalPlaces = TRB_CHF_DecimalPlaces.Value;
            L_DecimalPlaces.Text = decimalPlaces.ToString();
        }
        private void CB_CHF_SideChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_CHF_MoveNumber.Items.Clear();
            choosenSide = CB_CHF_SideChoose.SelectedIndex;
            switch (choosenSide)
            {
                case 0:
                    {
                        CB_CHF_MoveNumber.Items.Add(0);
                        for (int i = 1;i <= PlayerData.IndependentChances.Count; i++)
                        {
                            CB_CHF_MoveNumber.Items.Add(i);
                        }
                        break;
                    }
                case 1:
                    {
                        CB_CHF_MoveNumber.Items.Add(0);
                        for (int i = 1; i <= EnemyData.IndependentChances.Count; i++)
                        {
                            CB_CHF_MoveNumber.Items.Add(i);
                        }
                        break;
                    }
            }
            CB_CHF_MoveNumber.SelectedIndex = 0;
            CB_CHF_MoveNumber.Text = "0";
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            if (PlayerData.IndependentChances.Count + EnemyData.IndependentChances.Count != 0)
            {
                if (EnemyData.IndependentChances.Count != 0)
                {
                    CHB_EnemyDataShow.Visible = true;
                }
                if (PlayerData.IndependentChances.Count != 0)
                {
                    CHB_PlayerDataShow.Visible = true;
                }
            }
            else
            {
                if (MessageBox.Show("No data available for chart\r\nDo you want to stay in this interface?", "Game Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    Dispose();
                }
            }
        }

        private void BS_CHF_SearchData_Click(object sender, EventArgs e)
        {
            choosenMove = Convert.ToInt32(CB_CHF_MoveNumber.SelectedIndex);
            if (choosenMove == 0)
            {
                foundData = 0.2;
            }
            else
            {
                switch (choosenSide)
                {
                    case 0:
                        {
                            foundData = PlayerData.IndependentChances[choosenMove];
                            break;
                        }
                    case 1:
                        {
                            foundData = EnemyData.IndependentChances[choosenMove];
                            break;
                        }
                }
            }
            TB_CHF_HitProbobility.Text = $"{Math.Round(foundData * 100, decimalPlaces)}%";
        }
    }
}
