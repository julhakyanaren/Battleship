using Battleship.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Forms
{
    public partial class HitChance : Form
    {
        public HitChance()
        {
            InitializeComponent();
        }

        private void HitChance_Load(object sender, EventArgs e)
        {
            HitChanceData.FormClosed = false;
            HitChanceData.ExampleCraeted = false;
            GenerateMap();
        }
        public void SetMaximumValues()
        {
        }

        private void HitChance_FormClosed(object sender, FormClosedEventArgs e)
        {
            HitChanceData.FormClosed = true;
            RemoveMap();
        }
        private void BS_HC_RestartMap_Click(object sender, EventArgs e)
        {
            RestartMap();
        }
        async void RemoveMap()
        {
        }
        async void RestartMap()
        {
            RemoveMap();
            await Task.Delay(20);
        }
        async void GenerateMap()
        {
            if (!HitChanceData.ExampleCraeted)
            {
                for (int b = 0; b < HitChanceData.CurrentMap.Count; b++)
                {
                    await Task .Delay(20);
                    int x;
                    int y;
                    x = b / 10;
                    y = (b % 10 - 1) * 60 + 1;
                    Button button = new Button
                    {
                        Name = $"BS_HC_Example_{b}",
                        Location = new Point(x, y),
                        Dock = DockStyle.Fill
                    };
                    TLP_HC_Schema.Controls.Add(button);
                    button.FlatStyle = FlatStyle.Flat;
                    button.ForeColor = Color.Black;
                    button.BackColor = Color.White;
                    button.Tag = b + 600;
                    button.Margin = new Padding(0);
                }
                if (TLP_HC_Schema.Controls.Count == 100)
                {
                    HitChanceData.ExampleCraeted = true;
                }
            }
        }
    }
}
