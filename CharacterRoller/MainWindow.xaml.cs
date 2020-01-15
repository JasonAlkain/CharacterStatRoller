using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharacterRoller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Label[] statsMain;
        private Label[] statsMod;

        public MainWindow()
        {
            InitializeComponent();
            SetStatsArry();
        }

        void SetStatsArry()
        {
            statsMain = new Label[6] {
                    STR_Main,
                    DEX_Main,
                    CON_Main,
                    INT_Main,
                    WIS_Main,
                    CHA_Main
                };

            statsMod = new Label[6] {
                    STR_Mod,
                    DEX_Mod,
                    CON_Mod,
                    INT_Mod,
                    WIS_Mod,
                    CHA_Mod
                };
        }

        private void MNI_New_OnClick(object sender, RoutedEventArgs e)
        {

            StatRoll();

            //MessageBoxResult result = MessageBox.Show("Create new character!", "Character Roller", MessageBoxButton.YesNo);

            //switch (result)
            //{
            //    case MessageBoxResult.Yes:
            //        MessageBox.Show("Creating new character...", "Character Roller");
            //        StatRoll();
            //        break;

            //    case MessageBoxResult.No:
            //        MessageBox.Show("Okay then... maybe next time...", "Character Roller");
            //        break;
            //}

        }

        void StatRoll()
        {
            List<int> statNum = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                int num = new Random().Next(9, 18);
                System.Threading.Thread.Sleep(50);
                statNum.Add(num);
            }
            
            for (int i = 0; i < statsMain.Length; i++)
            {
                statsMain[i].Content = statNum[i];
            }

            for (int i = 0; i < statsMod.Length; i++)
            {
                statsMod[i].Content = GetMod(statNum[i]);
            }

            int temp = 0;
        }

        string GetMod(int stat)
        {
            string result = String.Empty;

            int temp = (stat - 10) / 2;


            result = (temp > 0) ? $"+{temp}" : $"{temp}";
            
            return result;
        }

        int RollStat()
        {
            int result = new Random().Next(9, 18);

            return result;
        }

        private int RollDice(ushort sides)
        {
            int result = new Random().Next(1, sides);

            return result;
        }

        private int RollDice(ushort num, ushort sides)
        {
            int result = 0;

            for (int i = 0; i < num; i++)
            {
                int rng = new Random().Next(1, sides);

                result += rng;
            }

            return result;
        }

        private int RollDice(ushort num, ushort sides, int mod)
        {
            int result = 0;

            for (int i = 0; i < num; i++)
            {
                int rng = new Random().Next(1, sides);

                result += rng;
            }

            result += mod;

            return result;
        }

    }
}
