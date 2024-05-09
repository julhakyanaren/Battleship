using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Forms
{
    public partial class CalculationForm : Form
    {
        int dataSource = 0;
        int maxDecks = 20;
        int hited;
        int white;
        int decimalPlaces = 0;
        double chance;
        public CalculationForm()
        {
            InitializeComponent();
        }
        void UpdateData()
        {            
            TB_CF_MaxDecks.Text = "20";
            switch (dataSource)
            {
                case 0:
                    {
                        hited = EnemyData.HitedDecksCount;
                        white = EnemyData.WhiteCellsCount;
                        break;
                    }
                case 1:
                    {
                        hited = PlayerData.HitedDecksCount;
                        white = PlayerData.WhiteCellsCount;
                        break;
                    }                
            }
            if (Fight.UnusedCoords.Count == 100)
            {
                white = 100;
            }
            TB_CF_HitedDecks.Text = hited.ToString();
            TB_CF_Undiscovered.Text = white.ToString();
            chance = (double)(20 - hited) / (double)white;
            chance *= 100;
            TB_CF_Chance.Text = chance.ToString($"F{decimalPlaces}")+ "%";
            UpdateTextValue();

        }
        void UpdateTextValue()
        {
            TB_CF_Formula.Text = $"({maxDecks}     -     {hited})     /     {white}     =     " + chance.ToString($"F{decimalPlaces}") + "%";
        }
        private void CalculationForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void CB_DataSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataSource = CB_DataSelector.SelectedIndex;
        }

        private void NUD_DecimalPlaces_ValueChanged(object sender, EventArgs e)
        {
            decimalPlaces = Convert.ToInt32(NUD_DecimalPlaces.Value);
        }

        private void BS_CF_Update_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void BS_CF_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
