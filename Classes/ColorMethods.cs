using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Battleship
{
    public class ColorMethods
    {
        Support Support = new Support();
        public Color[] PlayerMapColor = new Color[100];
        public Color SetColorViaChar(char charter)
        {
            charter = Convert.ToChar(charter.ToString().ToUpper());
            switch (Char.ToUpper(charter))
            {
                case 'F':
                    {
                        return Color.Silver;
                    }
                case 'D':
                    {
                        return Color.DarkGray;
                    }
                case 'C':
                    {
                        return Color.Gray;
                    }
                case 'B':
                    {
                        return Color.DimGray;
                    }
                case 'H':
                    {
                        return Color.LightCoral;
                    }
                case 'S':
                    {
                        return Color.Firebrick;
                    }
                case 'M':
                    {
                        return Color.Aqua;
                    }
                case 'E':
                    {
                        return Color.DeepSkyBlue;
                    }
                default:
                    {
                        return Color.White;
                    }

            }
        }
        public char SetCharViaColor(int index, Color buttonBackColor)
        {
            string colorName = buttonBackColor.Name.ToString();
            string[] activeButtonColor =
            {
                Design.MouseOverColor[0].Name.ToString()
            };
            switch (index)
            {
                case 0: //Player
                    {
                        switch (colorName)
                        {
                            case "Silver":
                                {
                                    return 'F';
                                }
                            case "DarkGray":
                                {
                                    return 'D';
                                }
                            case "Gray":
                                {
                                    return 'C';
                                }
                            case "DimGray":
                                {
                                    return 'B';
                                }
                            case "LightCoral":
                                {
                                    return 'H';
                                }
                            case "Firebrick":
                                {
                                    return 'S';
                                }
                            case "Skyblue":
                                {
                                    return 'E';
                                }
                            case "Aqua":
                                {
                                    return 'M';
                                }
                            default:
                                {
                                    return 'n';
                                }
                        }
                    }
                case 1: //Enemy
                    {
                        switch (colorName)
                        {
                            case "Silver":
                                {
                                    return 'f';
                                }
                            case "DarkGray":
                                {
                                    return 'd';
                                }
                            case "Gray":
                                {
                                    return 'c';
                                }
                            case "DimGray":
                                {
                                    return 'b';
                                }
                            case "Red":
                                {
                                    return 'h';
                                }
                            case "Firebrick":
                                {
                                    return 's';
                                }
                            case "DeepSkyBlue":
                                {
                                    return 'e';
                                }
                            case "Aqua":
                                {
                                    return 'm';
                                }
                            default:
                                {
                                    if (colorName == activeButtonColor[0])
                                    {
                                        return 'A';
                                    }
                                    else
                                    {
                                        return 'n';
                                    }
                                }
                        }
                    }
                default:
                    {
                        return '-';
                    }
            }
        }
        public Color[] SetButtonColors(char[] inputMap)
        {
            Color[] colors = new Color[inputMap.Length];
            for (int c = 0; c < colors.Length; c++)
            {
                colors[c] = SetColorViaChar(inputMap[c]);
            }
            return colors;
        }
        public Color CellCollor(Button selectedButton)
        {
            return selectedButton.BackColor;
        }
    }
}
