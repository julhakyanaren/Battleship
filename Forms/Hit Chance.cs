using Battleship.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private string mapType = null;
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
                                    break;
                                }

                        }
                    }
                }
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
                    button.Tag = b + 600;
                    button.Tag = Convert.ToInt32($"{button.Tag.ToString()[0]}{button.Tag.ToString()[2]}{button.Tag.ToString()[1]}");
                    button.Margin = new Padding(0);
                    ExampleButtons[b] = button;
                    button.MouseClick += ExmpleButton_Click;
                    button.MouseEnter += ExampleButton_MouseEnter;
                }
                if (TLP_HC_Schema.Controls.Count == 100)
                {
                    HitChanceData.ExampleCraeted = true;
                    BS_HC_RestartMap.Visible = true;
                }
            }
        }

        private void ExampleButton_MouseEnter(object sender, EventArgs e)
        {
            Button hoverButton = sender as Button;
            int index = Array.IndexOf(ExampleButtons, hoverButton);
            HitChanceData.HitProbobility = HitChanceData.ProbobilityArray[index];
            TB_HC_HitProbobility.Text = $"{HitChanceData.HitProbobility} %";
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
                BS_HC_GenerateMap.Visible = CHB_HC_UseCustomCell.Checked;
                HitChanceData.ManualMode = CHB_HC_UseCustomCell.Checked;
            }
        }
        private void BS_HC_GenerateMap_Click(object sender, EventArgs e)
        {
            if (!HitChanceData.ExampleCraeted)
            {
                GenerateMap();
                BS_HC_GenerateMap.Visible = false;
            }
            else
            {
                MessageBox.Show("Map already created", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BS_HC_UpdateCellDAta_Click(object sender, EventArgs e)
        {
            if (!HitChanceData.ManualMode)
            {
                GetCellData(HitChanceData.SelectedCell);
            }
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
                    switch (index)
                    {
                        case 1:
                            {
                                mapType = $"{Options.SP_PlayerName}'s map";
                                break;
                            }
                        case 2:
                            {
                                mapType = "Enemy Map";
                                break;
                            }
                    }
                    TB_HC_ChoosenMapType.Text = mapType;
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
        void SetHitProbobilityTextColor()
        {
            if (HitChanceData.HitProbobility == 0)
            {
                TB_HC_HitProbobility.ForeColor = HitChanceData.EfficientyDataColor[0];
                TB_HC_ShotEfficiency.Text = $"{HitChanceData.EfficientyDataString[0]}";
            }
            else if (sp.IsFloatBetween(0, 25, HitChanceData.HitProbobility, "OO"))
            {
                TB_HC_HitProbobility.ForeColor = HitChanceData.EfficientyDataColor[1];
                TB_HC_ShotEfficiency.Text = $"{HitChanceData.EfficientyDataString[1]}";
            }
            else if (sp.IsFloatBetween(25, 5, HitChanceData.HitProbobility, "IO"))
            {
                TB_HC_HitProbobility.ForeColor = HitChanceData.EfficientyDataColor[2];
                TB_HC_ShotEfficiency.Text = $"{HitChanceData.EfficientyDataString[2]}";
            }
            else if (sp.IsFloatBetween(5, 75, HitChanceData.HitProbobility, "IO"))
            {
                TB_HC_HitProbobility.ForeColor = HitChanceData.EfficientyDataColor[3];
                TB_HC_ShotEfficiency.Text = $"{HitChanceData.EfficientyDataString[3]}";
            }
            else if (sp.IsFloatBetween(75, 90, HitChanceData.HitProbobility, "IO"))
            {
                TB_HC_HitProbobility.ForeColor = HitChanceData.EfficientyDataColor[4];
                TB_HC_ShotEfficiency.Text = $"{HitChanceData.EfficientyDataString[4]}";
            }
            else if (sp.IsFloatBetween(90, 100, HitChanceData.HitProbobility, "IO"))
            {
                TB_HC_HitProbobility.ForeColor = HitChanceData.EfficientyDataColor[5];
                TB_HC_ShotEfficiency.Text = $"{HitChanceData.EfficientyDataString[5]}";
            }
            else if (HitChanceData.HitProbobility == 100)
            {
                TB_HC_HitProbobility.ForeColor = HitChanceData.EfficientyDataColor[6];
                TB_HC_ShotEfficiency.Text = $"{HitChanceData.EfficientyDataString[6]}";
            }
        }
        private void TB_HC_HitProbobility_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void FindProbability(Button selectedButton)
        {
            if (ExampleButtons[0] == null)
            {
                MessageBox.Show("ExampleButtons[0] not initialized", "Hit Chance Manager",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (sp.StringToInt(selectedButton.Tag.ToString(), out int firstCoord))
                {
                    HitChanceData.GenerateNearestCoords(firstCoord);
                    CheckChance();
                }
                else
                {
                    MessageBox.Show($"Parsing error {selectedButton.Tag} to type Int32", "Hit Chance Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void CheckChance(bool resetData = true)
        {
            int whiteCells = 0;
            int otherCells = 0;
            int[] indexes = new int[8];
            if (resetData)
            {
                HitChanceData.ResetDiscoveredCells();
            }
            for (int a = 0; a < HitChanceData.AllowedCoordsCount; a++)
            {
                int index = FindButtonIndexByTag(HitChanceData.AllowedCoords[a].ToString());
                if (ExampleButtons[index].BackColor == Color.White)
                {
                    HitChanceData.DiscoveredCells++;
                    whiteCells++;
                    Array.Resize(ref indexes, indexes.Length + 1);
                    indexes[a] = FindButtonIndexByTag(HitChanceData.AllowedCoords[a].ToString());
                    HitChanceData.PossibleIndexes.Add(indexes[a]);
                }
                else
                {
                    HitChanceData.ForbiddenIndexes.Add(FindButtonIndexByTag(HitChanceData.AllowedCoords[a].ToString()));
                    HitChanceData.UndiscoveredCells++;
                    otherCells++;
                }
            }
            if (whiteCells != 0)
            {
                double probobility = 100 / whiteCells;
                for (int p = 0; p < indexes.Length; p++)
                {
                    HitChanceData.ProbobilityArray[indexes[p]] = probobility;
                }
            }
        }
        int FindButtonIndexByTag(string tag)
        {
            int index = Array.FindIndex(ExampleButtons, button => Equals(button.Tag.ToString(), tag.ToString()));
            return index;
        }
    }
}
