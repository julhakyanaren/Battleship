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
        Button[] ExampleButtons = new Button[100];
        ColorMethods cm = new ColorMethods();
        Position pos = new Position();
        Support sp = new Support();

        private Button manualSelected = null;

        private string shipType = null;
        private string cellCoord = null;
        public HitChance()
        {
            InitializeComponent();
        }
        private void HitChance_Load(object sender, EventArgs e)
        {
            HitChanceData.FormClosed = false;
            HitChanceData.ExampleCraeted = false;
            if (!CHB_HC_UseCustomCell.Checked)
            {
                GetCellData(HitChanceData.SelectedCell);
            }
            HitChanceData.SetProbobilityArrayDefaultValues();
            GenerateMap();
            SetShipsMaxCount();
            SetShipCurrentCount();
        }
        private void HitChance_FormClosed(object sender, FormClosedEventArgs e)
        {
            HitChanceData.FormClosed = true;
        }
        private void BS_HC_RestartMap_Click(object sender, EventArgs e)
        {
            RestartMap();
        }
        async void RestartMap()
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
                                    ExampleButtons[b].BackColor = Color.Black;
                                    break;
                                }
                            case 1:
                                {
                                    await Task.Delay(10);
                                    ExampleButtons[b].BackColor = HitChanceData.CurrentMap[b].BackColor;
                                    if (ExampleButtons[b].BackColor == Color.DeepSkyBlue)
                                    {
                                        HitChanceData.ProbobilityArray[b] = 0;
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
        async void GenerateMap()
        {
            if (!HitChanceData.ExampleCraeted)
            {
                for (int b = 0; b < HitChanceData.CurrentMap.Count; b++)
                {
                    await Task .Delay(4);
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
                    button.ForeColor = HitChanceData.CurrentMap[b].ForeColor;
                    button.BackColor = HitChanceData.CurrentMap[b].BackColor;
                    SetBasicProbobility(button, b);
                    button.Tag = b + 600;
                    button.Tag = Convert.ToInt32($"{button.Tag.ToString()[0]}{button.Tag.ToString()[2]}{button.Tag.ToString()[1]}");
                    button.Margin = new Padding(0);
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.Black;
                    ExampleButtons[b] = button;
                    button.MouseClick += ExmpleButton_Click;
                    button.MouseEnter += ExampleButton_MouseEnter;
                    button.MouseLeave += ExampleButton_MouseLeave;
                }
                if (TLP_HC_Schema.Controls.Count == 100)
                {
                    HitChanceData.ExampleCraeted = true;
                    BS_HC_RestartMap.Visible = true;
                }
                UpdateProbabilityData();
            }
        }

        private void ExampleButton_MouseLeave(object sender, EventArgs e)
        {
            Button leaveButton = sender as Button;
            leaveButton.FlatAppearance.BorderSize = 1;
            leaveButton.FlatAppearance.BorderColor = Color.Black;
        }
        private void ExampleButton_MouseEnter(object sender, EventArgs e)
        {
            Button hoverButton = sender as Button;
            int index = Array.IndexOf(ExampleButtons, hoverButton);
            HitChanceData.HitProbobility = HitChanceData.ProbobilityArray[index];
            TB_HC_HitProbobility.Text = HitChanceData.HitProbobility.ToString("F2") + "%";
            hoverButton.FlatAppearance.BorderSize = 2;
            hoverButton.FlatAppearance.BorderColor = Color.DarkOrange;
        }
        void CheckProbobilityArray()
        {
            for (int p = 0; p < HitChanceData.ProbobilityArray.Length; p++)
            {
                if (ExampleButtons[p].BackColor != Color.White && ExampleButtons[p].BackColor != Color.Green)
                {
                    HitChanceData.ProbobilityArray[p] = 0;
                }
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
        private void CHB_HC_UseCustomCell_CheckedChanged(object sender, EventArgs e)
        {
            if (!HitChanceData.ExampleCraeted)
            {
                HitChanceData.ManualMode = CHB_HC_UseCustomCell.Checked;
            }
        }
        private void BS_HC_UpdateCellDAta_Click(object sender, EventArgs e)
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
        void GetCellData(Button selectedButton)
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
                                FindProbability(selectedButton);
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
                    cellCoord = pos.GetButtonTextCoords(selectedButton, out int index);
                    TB_HC_ChoosenCellData.Text = cellCoord;
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
        void SetShipsMaxCount()
        {
            TB_EnemyShips_FrigatesMax.Text = $"{ShipData.FrigateCount}";
            TB_EnemyShips_DestroyersMax.Text = $"{ShipData.DestroyerCount}";
            TB_EnemyShips_CruiserMax.Text = $"{ShipData.CruiserCount}";
            TB_EnemyShips_BattleshipsMax.Text = $"{ShipData.BattleshipCount}";
        }
        void SetShipCurrentCount()
        {
            TB_EnemyShips_Frigates.Text = $"{EnemyData.FrigatesCountCurrent}";
            TB_EnemyShips_Destroyers.Text = $"{EnemyData.DestroyersCountCurrent}";
            TB_EnemyShips_Cruiser.Text = $"{EnemyData.CruiserCountCurrent}";
            TB_EnemyShips_Battleships.Text = $"{EnemyData.BattleshipCountCurrent}";
        }
        private void BS_HC_ResetShipData_Click(object sender, EventArgs e)
        {
            SetShipsMaxCount();
            SetShipCurrentCount();
        }

        private void TB_HC_ShotEfficiency_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < HitChanceData.EfficientyDataString.Length; i++)
            {
                if (TB_HC_ShotEfficiency.Text == HitChanceData.EfficientyDataString[i])
                {
                    TB_HC_ShotEfficiency.ForeColor = HitChanceData.EfficientyDataColor[i];
                }
            }
        }
        void SetHitProbobilityTextColor(double chance, TextBox probobility_TB, TextBox efficiency_TB)
        {
            if (chance == 0)
            {
                probobility_TB.ForeColor = HitChanceData.EfficientyDataColor[0];
                efficiency_TB.Text = $"{HitChanceData.EfficientyDataString[0]}";
            }
            else if (sp.IsFloatBetween(0, 25, chance, "OO"))
            {
                probobility_TB.ForeColor = HitChanceData.EfficientyDataColor[1];
                efficiency_TB.Text = $"{HitChanceData.EfficientyDataString[1]}";
            }
            else if (sp.IsFloatBetween(25, 5, chance, "IO"))
            {
                probobility_TB.ForeColor = HitChanceData.EfficientyDataColor[2];
                efficiency_TB.Text = $"{HitChanceData.EfficientyDataString[2]}";
            }
            else if (sp.IsFloatBetween(5, 75, chance, "IO"))
            {
                probobility_TB.ForeColor = HitChanceData.EfficientyDataColor[3];
                efficiency_TB.Text = $"{HitChanceData.EfficientyDataString[3]}";
            }
            else if (sp.IsFloatBetween(75, 90, chance, "IO"))
            {
                probobility_TB.ForeColor = HitChanceData.EfficientyDataColor[4];
                efficiency_TB.Text = $"{HitChanceData.EfficientyDataString[4]}";
            }
            else if (sp.IsFloatBetween(90, 100, chance, "IO"))
            {
                probobility_TB.ForeColor = HitChanceData.EfficientyDataColor[5];
                efficiency_TB.Text = $"{HitChanceData.EfficientyDataString[5]}";
            }
            else if (chance == 100)
            {
                probobility_TB.ForeColor = HitChanceData.EfficientyDataColor[6];
                efficiency_TB.Text = $"{HitChanceData.EfficientyDataString[6]}";
            }
        }
        private void TB_HC_HitProbobility_TextChanged(object sender, EventArgs e)
        {
            SetHitProbobilityTextColor(HitChanceData.HitProbobility, TB_HC_HitProbobility, TB_HC_ShotEfficiency);
        }
        private void FindProbability(Button selectedButton)
        {
            if (ExampleButtons[0] == null)
            {
                if (HitChanceData.ExampleCraeted)
                {
                    MessageBox.Show("ExampleButtons[0] not initialized", "Hit Chance Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($"Parsing error {selectedButton.Tag} to type Int32", "Hit Chance Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void CheckChance(int firstIndex, bool resetData = true)
        {
            firstIndex = FindButtonIndexByTag(firstIndex.ToString());
            HitChanceData.PossibleIndexes.Clear();
            HitChanceData.ForbiddenIndexes.Clear();
            bool redCoordsAround = false;
            double probobility = 0;
            int whiteCells = 0;
            int otherCells = 0;
            int currentIndex = 0;
            List<int> nextIndexes = new List<int>();
            List<int> indexList = new List<int>();
            if (resetData)
            {
                HitChanceData.ResetDiscoveredCells();
            }
            for (int a = 0; a < HitChanceData.AllowedCoordsCount; a++)
            {
                int index = FindButtonIndexByTag(HitChanceData.AllowedCoords[a].ToString());
                if (ExampleButtons[index].BackColor == Color.White || ExampleButtons[index].BackColor == Color.Red)
                {
                    HitChanceData.DiscoveredCells++;
                    whiteCells++;
                    currentIndex = FindButtonIndexByTag(HitChanceData.AllowedCoords[a].ToString());
                    indexList.Add(currentIndex);
                    HitChanceData.PossibleIndexes.Add(currentIndex);
                    if (ExampleButtons[index].BackColor == Color.Red)
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
                                if (ExampleButtons[nextIndexes[i]].BackColor == Color.White)
                                {
                                    whiteIndexes++;
                                }
                            }
                            //Debug
                            if (whiteIndexes != 0)
                            {
                                probobility = 100 / whiteIndexes;
                            }
                            else
                            {
                                probobility = 0;
                            }
                            //Debug
                            //probobility = 100 / whiteIndexes; //uncomment
                            for (int i = 0; i < nextIndexes.Count; i++)
                            {
                                HitChanceData.ProbobilityArray[nextIndexes[i]] = probobility;
                            }
                        }
                    }
                }
                else
                {
                    HitChanceData.ForbiddenIndexes.Add(FindButtonIndexByTag(HitChanceData.AllowedCoords[a].ToString()));
                    HitChanceData.UndiscoveredCells++;
                    otherCells++;
                }
            }
            if (whiteCells != 0 && !redCoordsAround)
            {
                probobility = 100 / whiteCells;
                for (int p = 0; p < indexList.Count; p++)
                {
                    HitChanceData.ProbobilityArray[indexList[p]] = probobility;
                }
            }
            CheckProbobilityArray();
        }
        int FindButtonIndexByTag(string tag)
        {
            int index = Array.FindIndex(ExampleButtons, button => Equals(button.Tag.ToString(), tag.ToString()));
            return index;
        }
        void FindIndependentChance(out float chance)
        {
            float whiteCells = 0;
            float hitedCells = 0;
            for (int b = 0; b < ExampleButtons.Length; b++)
            {
                string example = ExampleButtons[b].BackColor.Name.ToString();
                switch (ExampleButtons[b].BackColor.Name.ToString())
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
        void SetBasicProbobility(Button inputButton, int index)
        {
            string colorName = inputButton.BackColor.Name.ToString();
            switch (colorName)
            {
                case "DeepSkyBlue":
                    {
                        HitChanceData.ProbobilityArray[index] = 0;
                        break;
                    }
                case "Red":
                    {
                        HitChanceData.ProbobilityArray[index] = 0;
                        break;
                    }
                case "Firebrick":
                    {
                        HitChanceData.ProbobilityArray[index] = 0;
                        break;
                    }
            }
        }

        private void TB_HC_IndependentChance_TextChanged(object sender, EventArgs e)
        {
            if (TB_HC_IndependentChance.Text == "No moves available")
            {
                TB_HC_IndependentChance.ForeColor = Color.DeepSkyBlue;
            }
            else if (HitChanceData.IndependentChance == 0)
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.EfficientyDataColor[0];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.EfficientyDataString[0]}";
            }
            else if (sp.IsFloatBetween(0, 25, HitChanceData.IndependentChance, "OO"))
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.EfficientyDataColor[1];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.EfficientyDataString[1]}";
            }
            else if (sp.IsFloatBetween(25, 5, HitChanceData.IndependentChance, "IO"))
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.EfficientyDataColor[2];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.EfficientyDataString[2]}";
            }
            else if (sp.IsFloatBetween(5, 75, HitChanceData.IndependentChance, "IO"))
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.EfficientyDataColor[3];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.EfficientyDataString[3]}";
            }
            else if (sp.IsFloatBetween(75, 90, HitChanceData.IndependentChance, "IO"))
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.EfficientyDataColor[4];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.EfficientyDataString[4]}";
            }
            else if (sp.IsFloatBetween(90, 100, HitChanceData.IndependentChance, "IO"))
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.EfficientyDataColor[5];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.EfficientyDataString[5]}";
            }
            else if (HitChanceData.IndependentChance == 100)
            {
                TB_HC_IndependentChance.ForeColor = HitChanceData.EfficientyDataColor[6];
                TB_HC_IndependentEfficity.Text = $"{HitChanceData.EfficientyDataString[6]}";
            }
        }
        void UpdateProbabilityData()
        {
            FindIndependentChance(out float chance);
            HitChanceData.IndependentChance = (float)Math.Round(chance, 4) * 100;
            if (chance != Math.Abs(float.PositiveInfinity))
            {
                TB_HC_IndependentChance.Text = HitChanceData.IndependentChance.ToString("F2") + "%";
            }
            else
            {
                TB_HC_IndependentChance.Text = "No moves available";
            }
        }
        private void TB_EnemyShips_Frigates_TextChanged(object sender, EventArgs e)
        {
            TextBox zeroValue_TB = sender as TextBox;
            if (zeroValue_TB.Text == "0")
            {
                zeroValue_TB.ForeColor = Color.Red;
            }
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
        private void TB_HC_IndependentEfficity_TextChanged(object sender, EventArgs e)
        {
            SetHitProbobilityTextColor(HitChanceData.IndependentChance, TB_HC_IndependentChance, TB_HC_IndependentEfficity);
        }
        private void TRB_DecimalPlaces_Scroll(object sender, EventArgs e)
        {
            HitChanceData.DecimalPlacesCount = TRB_DecimalPlaces.Value;
            L_DecimalPlaces_Count.Text = HitChanceData.DecimalPlacesCount.ToString();
        }
        private void CHB_ShowMoveNumber_CheckedChanged(object sender, EventArgs e)
        {
            HitChanceData.ShowNoveNumber = CHB_ShowMoveNumber.Checked;
        }
        private void BS_HC_IndependentChances_Update_Click(object sender, EventArgs e)
        {
            ShowIndependentChances();
        }
    }
}
