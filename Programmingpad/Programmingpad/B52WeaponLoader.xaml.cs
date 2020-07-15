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

namespace Programmingpad
{
    /// <summary>
    /// Interaction logic for B52WeaponLoader.xaml
    /// </summary>
    public partial class B52WeaponLoader : Page
    {
        private B52 b52;

        public B52WeaponLoader()
        {
            b52 = new B52();        
            InitializeComponent();
            WeightLabel.Content = b52.CalcWeight();
        }


        private void AddWeapon(object sender, RoutedEventArgs e)
        {
            //String weapon = WeaponComboBox.Text;
            MessageBox.Show("Weapon added");

        }

        private void AddFuel(object sender, RoutedEventArgs e)
        {
            int fuelWeight = int.Parse(FuelTextBox.Text);
            b52.AddFuel(fuelWeight);
            WeightLabel.Content = b52.CalcWeight();
            
        }

        private void ClearAllWeapons(object sender, RoutedEventArgs e)
        {
            b52.ClearWeapon();
            WeightLabel.Content = b52.CalcWeight();
            MessageBox.Show("Weapons cleared");
        }

        private void ClearFuel (object sender, RoutedEventArgs e)
        {
            b52.ClearFuel();
            WeightLabel.Content = b52.CalcWeight();
            
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image i = (Image)sender;
            /// passing the weapon name to the Drag and Drop event
            DataObject dataObject = new DataObject(i.Name);
            System.Windows.DragDrop.DoDragDrop(i, dataObject, DragDropEffects.Move);

        }

        private void LeftWingReg_Drop(object sender, DragEventArgs e)
        {
            /// Mouse drop into the Bay image area
            /// Pull the original click weapon from event
            String weapon = (String)e.Data.GetData(typeof(String));
            switch (weapon)
            {
                case "Gravity":
                    {
                        b52.AddWeapon(Storage.Left, Weapon.Gravity);
                        break;
                    }
                case "JASSM":
                    {
                        b52.AddWeapon(Storage.Left, Weapon.JASSM);
                        break;
                    }
                case "JDAM":
                    {
                        b52.AddWeapon(Storage.Left, Weapon.JDAM);
                        break;
                    }
                case "MALD":
                    {
                        b52.AddWeapon(Storage.Left, Weapon.MALD);
                        break;
                    }
                case "WCMD":
                    {
                        b52.AddWeapon(Storage.Left, Weapon.WCMD);
                        break;
                    }
                case "CALCM":
                    {
                        b52.AddWeapon(Storage.Left, Weapon.CALCM);
                        break;
                    }
                case "ALCM":
                    {
                        b52.AddWeapon(Storage.Left, Weapon.ALCM);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Invalid weapon selection");
                        break;
                    }
            }

            WeightLabel.Content = b52.CalcWeight();
        }

        private void RightWingReg_Drop(object sender, DragEventArgs e)
        {
            /// Mouse drop into the Bay image area
            /// Pull the original click weapon from event
            String weapon = (String)e.Data.GetData(typeof(String));
            switch (weapon)
            {
                case "Gravity":
                    {
                        b52.AddWeapon(Storage.Right, Weapon.Gravity);
                        break;
                    }
                case "JASSM":
                    {
                        b52.AddWeapon(Storage.Right, Weapon.JASSM);
                        break;
                    }
                case "JDAM":
                    {
                        b52.AddWeapon(Storage.Right, Weapon.JDAM);
                        break;
                    }
                case "MALD":
                    {
                        b52.AddWeapon(Storage.Right, Weapon.MALD);
                        break;
                    }
                case "WCMD":
                    {
                        b52.AddWeapon(Storage.Right, Weapon.WCMD);
                        break;
                    }
                case "CALCM":
                    {
                        b52.AddWeapon(Storage.Right, Weapon.CALCM);
                        break;
                    }
                case "ALCM":
                    {
                        b52.AddWeapon(Storage.Right, Weapon.ALCM);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Invalid weapon selection");
                        break;
                    }
            }

            WeightLabel.Content = b52.CalcWeight();
            
        }

        private void BayReg_Drop(object sender, DragEventArgs e)
        {
            /// Mouse drop into the Bay image area
            /// Pull the original click weapon from event
            String weapon = (String)e.Data.GetData(typeof(String));
            switch (weapon)
            {
                case "Gravity":
                    {
                        b52.AddWeapon(Storage.Bay, Weapon.Gravity);
                        break;
                    }
                case "JASSM":
                    {
                        b52.AddWeapon(Storage.Bay, Weapon.JASSM);
                        break;
                    }
                case "JDAM":
                    {
                        b52.AddWeapon(Storage.Bay, Weapon.JDAM);
                        break;
                    }
                case "MALD":
                    {
                        MessageBox.Show("Can not add MALD into Bay");
                        break;
                    }
                case "WCMD":
                    {
                        MessageBox.Show("Can not add WCMD into Bay");
                        break;
                    }
                case "CALCM":
                    {
                        b52.AddWeapon(Storage.Bay, Weapon.CALCM);
                        break;
                    }
                case "ALCM":
                    {
                        b52.AddWeapon(Storage.Bay, Weapon.ALCM);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Invalid weapon selection");
                        break;
                    }
            }

            WeightLabel.Content = b52.CalcWeight();
        }

        private void LeftWingReg_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip t = new ToolTip();
            t.Content = b52.LeftWing.ToString();
            LeftWingReg.ToolTip = t;
        }
    }
}
