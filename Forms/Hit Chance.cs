using Battleship.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Forms
{
    public partial class HitChance : Form
    {
        ColorMethods cm = new ColorMethods();
        Position pos = new Position();
        Support sp = new Support();



        private string shipType = null;
        private string cellCoord = null;
        private double[] probobilityArray = new double[100];

        private Button manualSelected = null;

        Button[] exampleButtons = new Button[100];

        public HitChance()
        {
            InitializeComponent();
        }
        public void SetProbobilityArrayDefaultValues()
        {
            for (int p = 0; p < probobilityArray.Length; p++)
            {
                probobilityArray[p] = 0.0f;
            }
        }
        int FindButtonIndexByTag(string tag)
        {
            int index = Array.FindIndex(exampleButtons, button => Equals(button.Tag.ToString(), tag.ToString()));
            return index;
        }
        void CheckProbobilityArray()
        {
            for (int p = 0; p < probobilityArray.Length; p++)
            {
                Button button = exampleButtons[p];
                if (button != null)
                {
                    if (button.BackColor != Color.White && button.BackColor != Color.Green)
                    {
                        probobilityArray[p] = 0;
                    }
                }
            }
        }
        void CheckChance(int firstIndex)
        {
            firstIndex = FindButtonIndexByTag(firstIndex.ToString());
            HitChanceData.PossibleIndexes.Clear();
            HitChanceData.ForbiddenIndexes.Clear();
            bool redCoordsAround = false;
            double probobility = 0;
            int whiteCells = 0;
            int otherCells = 0;
            List<int> nextIndexes = new List<int>();
            List<int> indexList = new List<int>();
            for (int a = 0; a < HitChanceData.AllowedCoords.Count; a++)
            {
                int index = FindButtonIndexByTag(HitChanceData.AllowedCoords[a].ToString());
                if (exampleButtons[index].BackColor == Color.White || exampleButtons[index].BackColor == Color.Red)
                {
                    whiteCells++;
                    indexList.Add(index);
                    HitChanceData.PossibleIndexes.Add(index);
                    if (exampleButtons[index].BackColor == Color.Red)
                    {
                        nextIndexes.Clear();
                        int delta = firstIndex - index;
                        char lineIndex = 'n';
                        switch (delta)
                        {
                            case -10:
                                {
                                    nextIndexes.Add(firstIndex + delta);
                                    nextIndexes.Add(index + Math.Abs(delta));
                                    lineIndex = 'c';
                                    break;
                                }
                            case -1:
                                {
                                    nextIndexes.Add(index + Math.Abs(delta));
                                    nextIndexes.Add(firstIndex + Math.Abs(delta));
                                    lineIndex = 'r';
                                    break;
                                }
                            case 1:
                                {
                                    nextIndexes.Add(firstIndex + delta);
                                    nextIndexes.Add(index - delta);
                                    lineIndex = 'r';
                                    break;
                                }
                            case 10:
                                {
                                    nextIndexes.Add(index - delta);
                                    nextIndexes.Add(firstIndex + delta);
                                    lineIndex = 'c';
                                    break;
                                }
                        }
                        pos.DeleteOutLineCoords(nextIndexes, firstIndex, lineIndex);
                        if (nextIndexes.Count != 0)
                        {
                            redCoordsAround = true;
                            int whiteIndexes = 0;
                            for (int i = 0; i < nextIndexes.Count; i++)
                            {
                                if (exampleButtons[nextIndexes[i]].BackColor == Color.White)
                                {
                                    whiteIndexes++;
                                }
                            }
                            if (whiteIndexes != 0)
                            {
                                probobility = 100 / whiteIndexes;
                            }
                            else
                            {
                                probobility = 0;
                            }
                            for (int i = 0; i < nextIndexes.Count; i++)
                            {
                                probobilityArray[nextIndexes[i]] = probobility;
                            }
                        }
                    }
                }
                else
                {
                    HitChanceData.ForbiddenIndexes.Add(FindButtonIndexByTag(HitChanceData.AllowedCoords[a].ToString()));
                    otherCells++;
                }
            }
            if (whiteCells != 0 && !redCoordsAround)
            {
                probobility = 100 / whiteCells;
                for (int p = 0; p < indexList.Count; p++)
                {
                    probobilityArray[indexList[p]] = probobility;
                }
            }
            CheckProbobilityArray();
        }
        void FindIndependentChance(out float chance)
        {
            float whiteCells = 0;
            float hitedCells = 0;
            for (int b = 0; b < exampleButtons.Length; b++)
            {
                switch (exampleButtons[b].BackColor.Name.ToString())
                {
                    case "White":
                        {
                            whiteCells++;
                            break;
                        }
                    case "Red":
                    case "Firebrick":
                        {
                            hitedCells++;
                            break;
                        }
                }
            }
            hitedCells = 20 - hitedCells;
            chance = hitedCells / whiteCells;
        }
        void UpdateProbabilityData()
        {
            FindIndependentChance(out float chance);
            HitChanceData.IndependentChance = (float)Math.Round(chance, 4) * 100;
            if (Math.Abs(chance) != Math.Abs(float.PositiveInfinity))
            {
                TB_HC_IndependentChance.Text = HitChanceData.IndependentChance.ToString("F2") + "%";
            }
            else
            {
                TB_HC_IndependentChance.Text = "No moves available";
            }
        }
        async Task RestartMap()
        {
            if (HitChanceData.CanResetMap)
            {
                HitChanceData.CanResetMap = false;
                for (int i = 0; i < 2; i++)
                {
                    for (int b = 0; b < 100; b++)
                    {
                        switch (i)
                        {
                            case 0:
                                {
                                    await Task.Delay(10);
                                    exampleButtons[b].BackColor = Color.Black;
                                    break;
                                }
                            case 1:
                                {
                                    await Task.Delay(10);
                                    exampleButtons[b].BackColor = HitChanceData.CurrentMap[b].BackColor;
                                    if (exampleButtons[b].BackColor == Color.DeepSkyBlue)
                                    {
                                        probobilityArray[b] = 0;
                                    }
                                    break;
                                }
                        }
                    }
                }
                UpdateProbabilityData();
                HitChanceData.CanResetMap = true;
            }
            else
            {
                MessageBox.Show("Example Map reset in process", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async Task FindProbability(Button selectedButton)
        {
            if (exampleButtons[0] == null)
            {
                if (HitChanceData.ExampleCraeted)
                {
                    if (MessageBox.Show("Cells are not initialized\r\nReset map and try again?", "Hit Chance Manager", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                    {
                        await RestartMap();
                        await FindProbability(selectedButton);
                    }
                }
            }
            else
            {
                if (sp.StringToInt(selectedButton.Tag.ToString(), out int firstCoord))
                {
                    HitChanceData.GenerateNearestCoords(firstCoord);
                    CheckChance(firstCoord);
                    TB_HC_Status.Text = "Analysis completed";
                }
                else
                {
                    MessageBox.Show($"Error Code: E30M9L4\r\n{selectedButton.Tag} String type to Int32 type converting error", $"{Handlers.Manager[9]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        } 
        async void GetCellData(Button selectedButton)
        {
            if (selectedButton != null)
            {
                if (selectedButton.BackColor == Color.Green)
                {
                    shipType = "Undiscovered ship";
                }
                else
                {
                    switch (Convert.ToString(cm.SetCharViaColor(1, selectedButton.BackColor)).ToUpper())
                    {
                        case "F":
                        case "D":
                        case "C":
                        case "B":
                            {
                                shipType = "Unknown";
                                break;
                            }
                        case "E":
                        case "N":
                            {
                                shipType = "Empty";
                                break;
                            }
                        case "H":
                            {
                                shipType = "Hited ship";
                                await FindProbability(selectedButton);
                                break;
                            }
                        case "S":
                            {
                                shipType = "Sunken ship";
                                break;
                            }
                        case "M":
                            {
                                shipType = "Mine";
                                break;
                            }
                        default:
                            {
                                shipType = null;
                                break;
                            }
                    }
                }
                if (shipType != null)
                {
                    TB_HC_CellState.Text = shipType;
                    TB_HC_ChoosenCellData.Text = pos.GetButtonTextCoords(selectedButton, out int index);
                }
                else
                {
                    DialogResult = MessageBox.Show("Invalid cell value", "Game Manager", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation);
                    switch (DialogResult)
                    {
                        case DialogResult.Retry:
                            {
                                GetCellData(selectedButton);
                                break;
                            }
                        case DialogResult.Abort:
                            {
                                Close();
                                break;
                            }
                    }
                }
            }
        }
        void SetBasicProbobility(Button inputButton, int index)
        {
            string colorName = inputButton.BackColor.Name.ToString();
            if (colorName == "DeepSkyBlue" || colorName == "Red" || colorName == "Firebrick")
            {
                probobilityArray[index] = 0;
            }
        }
        void SetShipsMaxCount()
        {
            TB_EnemyShips_FrigatesMax.Text = $"{ShipData.FrigateCount}";
            TB_EnemyShips_DestroyersMax.Text = $"{ShipData.DestroyerCount}";
            TB_EnemyShips_CruisersMax.Text = $"{ShipData.CruiserCount}";
            TB_EnemyShips_BattleshipsMax.Text = $"{ShipData.BattleshipCount}";
        }
        void SetShipCurrentCount()
        {
            TB_EnemyShips_Frigates.Text = $"{EnemyData.FrigatesCountCurrent}";
            TB_EnemyShips_Destroyers.Text = $"{EnemyData.DestroyersCountCurrent}";
            TB_EnemyShips_Cruisers.Text = $"{EnemyData.CruiserCountCurrent}";
            TB_EnemyShips_Battleships.Text = $"{EnemyData.BattleshipCountCurrent}";
        }
        async void GenerateMap()
        {
            if (!HitChanceData.ExampleCraeted)
            {
                for (int b = 0; b < HitChanceData.CurrentMap.Count; b++)
                {
                    await Task.Delay(4);
                    int x = b / 10;
                    int y = (b % 10 - 1) *60 + 1;
                    Button button = new Button
                    {
                        Name = $"BS_HC_Example_{b}",
                        Location = new Point(x, y),
                        Dock = DockStyle.Fill
                    };
                    TLP_HC_Schema.Controls.Add(button);
                    button.FlatStyle = FlatStyle.Flat;
                    button.ForeColor = HitChanceData.CurrentMap[b].ForeColor;
                    button.BackColor = HitChanceData.CurrentMap[b].BackColor;
                    SetBasicProbobility(button, b);
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.Black;
                    button.Margin = new Padding(0);
                    button.Tag = b + 600;
                    button.Tag = Convert.ToInt32($"{button.Tag.ToString()[0]}{button.Tag.ToString()[2]}{button.Tag.ToString()[1]}");
                    button.MouseClick += ExmpleButton_Click;
                    button.MouseEnter += ExampleButton_MouseEnter;
                    button.MouseLeave += ExampleButton_MouseLeave;
                    exampleButtons[b] = button;
                }
                if (TLP_HC_Schema.Controls.Count == 100)
                {
                    HitChanceData.ExampleCraeted = true;
                    BS_HC_RestartMap.Visible = true;
                }
                UpdateProbabilityData();
            }
        }
        private void ExmpleButton_Click(object sender, MouseEventArgs e)
        {
            if (HitChanceData.ManualMode)
            {
                manualSelected = sender as Button;
                GetCellData(manualSelected);
            }
        }
        private void ExampleButton_MouseEnter(object sender, EventArgs e)
        {
            Button hoverButton = sender as Button;
            int index = Array.IndexOf(exampleButtons, hoverButton);
            HitChanceData.HitProbobility = probobilityArray[index];
            TB_HC_HitProbobility.Text = HitChanceData.HitProbobility.ToString("F2") + "%";
            hoverButton.FlatAppearance.BorderSize = 2;
            hoverButton.FlatAppearance.BorderColor = Color.DarkOrange;
        }
        private void ExampleButton_MouseLeave(object sender, EventArgs e)
        {
            Button leaveButton = sender as Button;
            leaveButton.FlatAppearance.BorderSize = 1;
            leaveButton.FlatAppearance.BorderColor = Color.Black;
        }
        private void HitChance_Load(object sender, EventArgs e)
        {
            HitChanceData.FormClosed = false;
            HitChanceData.ExampleCraeted = false;
            if (!CHB_HC_UseCustomCell.Checked)
            {
                GetCellData(HitChanceData.SelectedCell);
            }
            SetProbobilityArrayDefaultValues();
            GenerateMap();
            SetShipsMaxCount();
            SetShipCurrentCount();
        }
        private void HitChance_FormClosed(object sender, FormClosedEventArgs e)
        {
            HitChanceData.FormClosed = true;
        }
        private async void BS_HC_RestartMap_Click(object sender, EventArgs e)
        {
            await RestartMap();
        }
        private void CHB_HC_UseCustomCell_CheckedChanged(object sender, EventArgs e)
        {
            if (!HitChanceData.ExampleCraeted)
            {
                HitChanceData.ManualMode = CHB_HC_UseCustomCell.Checked;
            }
        }
        private void BS_HC_UpdateCellData_Click(object sender, EventArgs e)
        {
            if (!HitChanceData.ManualMode)
            {
                GetCellData(HitChanceData.SelectedCell);
            }
        }
        private void BS_HC_UpdateProbability_Click(object sender, EventArgs e)
        {
            UpdateProbabilityData();
        }
        private void BS_HC_ResetShipData_Click(object sender, EventArgs e)
        {
            SetShipsMaxCount();
            SetShipCurrentCount();
        }
        private void EnemyShips_TB_TextChanged(object sender, EventArgs e)
        {
            TextBox zeroValue_TB = sender as TextBox;
            if (zeroValue_TB.Text == "0")
            {
                zeroValue_TB.ForeColor = Color.Red;
            }
        }
        private void CHB_ShowMoveNumber_CheckedChanged(object sender, EventArgs e)
        {
            HitChanceData.ShowNoveNumber = CHB_ShowMoveNumber.Checked;
        }
        private void TRB_DecimalPlaces_Scroll(object sender, EventArgs e)
        {
            HitChanceData.DecimalPlacesCount = TRB_DecimalPlaces.Value;
            L_Info_DecimalPlaces.Text = $"Decimal places:     {HitChanceData.DecimalPlacesCount}";
        }
        void SetHitProbobilityTextColor(double chance, TextBox probobility_TB, TextBox efficiency_TB)
        {
            switch (chance)
            {
                case 0:
                    {
                        probobility_TB.ForeColor = HitChanceData.RelativelyColors[0];
                        efficiency_TB.Text = $"{HitChanceData.RelativelyStrings[0]}";
                        break;
                    }
                case 25:
                    {
                        probobility_TB.ForeColor = HitChanceData.RelativelyColors[1];
                        efficiency_TB.Text = $"{HitChanceData.RelativelyStrings[1]}";
                        break;
                    }
                case 50:
                    {
                        probobility_TB.ForeColor = HitChanceData.RelativelyColors[3];
                        efficiency_TB.Text = $"{HitChanceData.RelativelyStrings[3]}";
                        break;
                    }
                case 100:
                    {
                        probobility_TB.ForeColor = HitChanceData.RelativelyColors[4];
                        efficiency_TB.Text = $"{HitChanceData.RelativelyStrings[4]}";
                        break;
                    }
                default:
                    {
                        if (Math.Round(chance, 0) == 33)
                        {
                            probobility_TB.ForeColor = HitChanceData.RelativelyColors[2];
                            efficiency_TB.Text = $"{HitChanceData.RelativelyStrings[2]}";
                        }
                        break;
                    }
            }
        }
        private void TB_HC_HitProbobility_TextChanged(object sender, EventArgs e)
        {
            SetHitProbobilityTextColor(HitChanceData.HitProbobility, TB_HC_HitProbobility, TB_HC_ShotEfficiency);
        }
        private void TB_HC_ShotEfficiency_TextChanged(object sender, EventArgs e)
        {
            TB_HC_ShotEfficiency.ForeColor = HitChanceData.RelativelyColors[Array.IndexOf(HitChanceData.RelativelyStrings, TB_HC_ShotEfficiency.Text)];
        }
        void ShowIndependentChances()
        {
            TB_IndependentChances.Clear();
            for (int i = 1; i <= EnemyData.IndependentChances.Count; i++)
            {
                if (HitChanceData.ShowNoveNumber)
                {
                    TB_IndependentChances.Text += $"Move #{i}:  {Math.Round(EnemyData.IndependentChances[i] * 100, HitChanceData.DecimalPlacesCount)}%";
                }
                else
                {
                    TB_IndependentChances.Text += $"{Math.Round(EnemyData.IndependentChances[i] * 100, HitChanceData.DecimalPlacesCount)}%";
                }
                if (i != EnemyData.IndependentChances.Count)
                {
                    TB_IndependentChances.Text += "\r\n";
                }
            }
        }
        private void BS_HC_IndependentChances_Update_Click(object sender, EventArgs e)
        {
            ShowIndependentChances();
        }
        private void TB_HC_IndependentChance_TextChanged(object sender, EventArgs e)
        {
            if (TB_HC_IndependentChance.Text == "No moves available")
            {
                TB_HC_IndependentChance.ForeColor = Color.DeepSkyBlue;
            }
            else if (HitChanceData.IndependentChance == 0)
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.IndependentColors[0];
                TB_HC_IndependentEfficity.ForeColor = HitChanceData.IndependentColors[0];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.IndependenStrings[0]}";
            }
            else if (sp.IsFloatBetween(0, 25, HitChanceData.IndependentChance, "OO"))
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.IndependentColors[1];
                TB_HC_IndependentEfficity.ForeColor = HitChanceData.IndependentColors[1];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.IndependenStrings[1]}";
            }
            else if (sp.IsFloatBetween(25, 50, HitChanceData.IndependentChance, "IO"))
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.IndependentColors[2];
                TB_HC_IndependentEfficity.ForeColor = HitChanceData.IndependentColors[2];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.IndependenStrings[2]}";
            }
            else if (sp.IsFloatBetween(50, 75, HitChanceData.IndependentChance, "IO"))
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.IndependentColors[3];
                TB_HC_IndependentEfficity.ForeColor = HitChanceData.IndependentColors[3];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.IndependenStrings[3]}";
            }
            else if (sp.IsFloatBetween(75, 90, HitChanceData.IndependentChance, "IO"))
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.IndependentColors[4];
                TB_HC_IndependentEfficity.ForeColor = HitChanceData.IndependentColors[4];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.IndependenStrings[4]}";
            }
            else if (sp.IsFloatBetween(90, 100, HitChanceData.IndependentChance, "IO"))
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.IndependentColors[5];
                TB_HC_IndependentEfficity.ForeColor = HitChanceData.IndependentColors[5];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.IndependenStrings[5]}";
            }
            else if (HitChanceData.IndependentChance == 100)
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.IndependentColors[6];
                TB_HC_IndependentEfficity.ForeColor = HitChanceData.IndependentColors[6];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.IndependenStrings[6]}";
            }
        }
        private void TB_HC_IndependentEfficity_TextChanged(object sender, EventArgs e)
        {
            SetHitProbobilityTextColor(HitChanceData.IndependentChance, TB_HC_IndependentChance, TB_HC_IndependentEfficity);
        }
        private void BS_HC_ShowChart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Open chart now?", "Game Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ChartForm chrtf = new ChartForm();
                Design.OpenNewForm(chrtf, 1, 6);
            }
        }

        private void TSMI_HC_ShowCalculation_Click(object sender, EventArgs e)
        {
            CalculationForm cf = new CalculationForm();
            cf.Show();
        }
    }
}
