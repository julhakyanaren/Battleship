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

namespace Battleship.Forms
{
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            Chart_LoadData();
        }

        public void Chart_LoadData()
        {
            Series seriesChance = CRT_ChanceChange.Series.FindByName("Chance_Series");
            if (seriesChance == null)
            {
                seriesChance.Points.Clear();
                foreach (var chance in EnemyData.IndependentChances)
                {
                    seriesChance.Points.AddXY(chance.Key, chance.Value);
                }
            }

        }
    }
}
