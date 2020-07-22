using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

/*
 * Group 2 - B52 Tinker Project - Programmingpad
 * @Author Sydney Ninh
 * B52WeaponLoader.xaml.cs
 */
namespace Programmingpad
{
    /// <summary>
    /// Interaction logic for B52WeaponLoader.xaml
    /// </summary>
    public partial class B52WeaponLoader : Page
    {
        // Declare the variable
        private B52 b52;

        /// <summary>
        /// Construct a default B52WeaponLoader object
        /// </summary>
        public B52WeaponLoader()
        {                  
            InitializeComponent();
            b52 = new B52();
            WeightLabel.Content = b52.CalcWeight();
            FuelLabel.Content = b52.Fuel;
        }

        /// <summary>
        /// Add fuel into the loader
        /// </summary>
        /// <param name="sender">
        /// 
        /// </param>
        /// <param name="e">
        /// 
        /// </param>
        private void AddFuel(object sender, RoutedEventArgs e)
        {
            // Allow only positive number in the field
            if (System.Text.RegularExpressions.Regex.IsMatch(FuelTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Enter only number \n");
                FuelTextBox.Text = "100000";
            }
            else
            {
                int fuelWeight = int.Parse(FuelTextBox.Text);
                try
                {
                    b52.AddFuel(fuelWeight);
                }
                catch (FuelErrorException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (WeightErrorException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                WeightLabel.Content = b52.CalcWeight();
                FuelLabel.Content = b52.Fuel;
                IsReady();
            }    
        }

        /// <summary>
        /// Clear all the weapon from the weapon loader
        /// </summary>
        /// <param name="sender">
        /// 
        /// </param>
        /// <param name="e">
        /// 
        /// </param>
        private void ClearAllWeapons(object sender, RoutedEventArgs e)
        {
            b52.ClearWeapon();
            WeightLabel.Content = b52.CalcWeight();
            MessageTextBlock.Text = "Weapons are cleared \n";
            LeftWingReg.Fill = Brushes.LightGray;
            RightWingReg.Fill = Brushes.LightGray;
            BayReg.Fill = Brushes.LightGray;
        }

        /// <summary>
        /// Clear the fuel from the weapon loader
        /// </summary>
        /// <param name="sender">
        /// </param>
        /// 
        /// <param name="e">
        /// 
        /// </param>
        private void ClearFuel (object sender, RoutedEventArgs e)
        {
            b52.ClearFuel();
            WeightLabel.Content = b52.CalcWeight();
            FuelLabel.Content = b52.Fuel;
            IsReady();
            MessageTextBlock.Text = "Fuel is cleared \n";

        }

        /// <summary>
        /// Check if the weaponloader is ready
        /// </summary>
        private void IsReady()
        {
            if(b52.IsReadyForTakeOff())
            {
                StatusLabel.Background = Brushes.Green;
            }
            else
            {
                StatusLabel.Background = Brushes.Red;
            }
        }
        /// <summary>
        /// Drag and drop weapon into the weapon loader
        /// </summary>
        /// <param name="sender">
        /// 
        /// </param>
        /// <param name="e">
        /// 
        /// </param>
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image i = (Image)sender;
            /// passing the weapon name to the Drag and Drop event
            DataObject dataObject = new DataObject(i.Name);
            System.Windows.DragDrop.DoDragDrop(i, dataObject, DragDropEffects.Move);

        }

        /// <summary>
        /// Drop the weapon into the Left wing
        /// </summary>
        /// <param name="sender">
        /// 
        /// </param>
        /// <param name="e">
        /// 
        /// </param>
        private void LeftWingReg_Drop(object sender, DragEventArgs e)
        {
            /// Mouse drop into the Left wing image area
            /// Pull the original click weapon from event
            String weaponString = (String)e.Data.GetData(typeof(String));
            WeaponType weaponType = StringtoWeapon(weaponString);
            Weapon weapon = new Weapon(weaponType);

            // check the exception
            try
            {
                b52.AddWeapon(Storage.Left, weapon);
                // update the current weight
                WeightLabel.Content = b52.CalcWeight();
                MessageTextBlock.Text = weapon.ToString() + " is added into left wing \n";
                ImageBrush imageBrush = new ImageBrush();
                Uri uri = new Uri(weaponNameToURI(weaponString));
                imageBrush.ImageSource = new BitmapImage(uri);
                LeftWingReg.Fill = imageBrush;
            }
            catch (WeightErrorException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (LoadErrorException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Drop the weapon into the Right wing
        /// </summary>
        /// <param name="sender">
        /// 
        /// </param>
        /// <param name="e">
        /// 
        /// </param>
        private void RightWingReg_Drop(object sender, DragEventArgs e)
        {
            /// Mouse drop into the Right wing image area
            /// Pull the original click weapon from event
 
            String weaponString = (String)e.Data.GetData(typeof(String));
            WeaponType weaponType = StringtoWeapon(weaponString);
            Weapon weapon = new Weapon(weaponType);

            try
            {               
                b52.AddWeapon(Storage.Right, weapon);
                // update the current weight
                WeightLabel.Content = b52.CalcWeight();
                MessageTextBlock.Text = weapon.ToString() + " is added into right wing \n";
                ImageBrush imageBrush = new ImageBrush();
                Uri uri = new Uri(weaponNameToURI(weaponString));
                imageBrush.ImageSource = new BitmapImage(uri);
                RightWingReg.Fill = imageBrush;
            }
            catch (WeightErrorException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (LoadErrorException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Drop the weapon into the Bay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BayReg_Drop(object sender, DragEventArgs e)
        {
            /// Mouse drop into the Bay image area
            /// Pull the original click weapon from event
            String weaponString = (String)e.Data.GetData(typeof(String));
            WeaponType weaponType = StringtoWeapon(weaponString);
            Weapon weapon = new Weapon(weaponType);

            try
            {
                b52.AddWeapon(Storage.Bay, weapon);
                // update the current weight
                WeightLabel.Content = b52.CalcWeight();
                MessageTextBlock.Text = weapon.ToString() + " is added into bay \n";
                ImageBrush imageBrush = new ImageBrush();
                Uri uri = new Uri(weaponNameToURI(weaponString));
                imageBrush.ImageSource = new BitmapImage(uri);
                BayReg.Fill = imageBrush;
            }
            catch (WeightErrorException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (LoadErrorException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Convert weapon image name to the URI location
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private String weaponNameToURI(String name)
        {
            if(name.Contains("ALCM"))
            {
                return "pack://application:,,,/Images/ALCM-CALCM.png";
            }
            else
            {
                name = name.Replace("Image", ".png");
            }
            return "pack://application:,,,/Images/" + name;
        }

        /// <summary>
        /// Convert the name of the image to the Weapon type
        /// </summary>
        /// <param name="weaponName">
        /// name of the weapon image
        /// </param>
        /// <returns>
        /// weapon type
        /// </returns>
        public WeaponType StringtoWeapon(String weaponName)
        {
            switch (weaponName)
            {
                case "GravityImage":
                    {
                        return WeaponType.Gravity;
                    }
                case "JASSMImage":
                    {
                        return WeaponType.JASSM;
                    }
                case "JDAMImage":
                    {
                        return WeaponType.JDAM;
                    }
                case "MALDImage":
                    {
                        return WeaponType.MALD;
                    }
                case "WCMDImage":
                    {
                        return WeaponType.WCMD;
                    }
                case "CALCMImage":
                    {
                        return WeaponType.CALCM;
                    }
                case "ALCMImage":
                    {
                        return WeaponType.ALCM;
                    }
                default:
                    {
                        return WeaponType.NONE;
                    }
            }
        }
        /// <summary>
        /// Show the information of weapons in the Left wing
        /// </summary>
        /// <param name="sender">
        /// 
        /// </param>
        /// <param name="e">
        /// 
        /// </param>
        private void LeftWingReg_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip t = new ToolTip();
            t.Content = b52.LeftWing.ToString();
            LeftWingReg.ToolTip = t;
        }

        /// <summary>
        /// Show the information of weapons in the Right wing
        /// </summary>
        /// <param name="sender">
        /// 
        /// </param>
        /// <param name="e">
        /// 
        /// </param>
        private void RightWingReg_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip t = new ToolTip();
            t.Content = b52.RightWing.ToString();
            RightWingReg.ToolTip = t;
        }

        /// <summary>
        /// Show the information of weapons in the Bay
        /// </summary>
        /// <param name="sender">
        /// 
        /// </param>
        /// <param name="e">
        /// 
        /// </param>
        private void BayReg_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip t = new ToolTip();
            t.Content = b52.Bay.ToString();
            BayReg.ToolTip = t;
        }

        /// <summary>
        /// Create the B52 menu
        /// </summary>
        /// <param name="sender">
        /// 
        /// </param>
        /// <param name="e">
        /// 
        /// </param>
        private void B52MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new B52WeaponLoader());
        }

        /// <summary>
        /// Create the exit menu
        /// </summary>
        /// <param name="sender">
        /// 
        /// </param>
        /// <param name="e">
        /// 
        /// </param>
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        /// <summary>
        /// Save the data into a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                b52.WriteToFile(saveFileDialog.FileName);
        }

        /// <summary>
        /// Open and read data into application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                b52 = b52.ReadFromFile(openFileDialog.FileName);

            IsReady();
            WeightLabel.Content = b52.CalcWeight();
            FuelLabel.Content = b52.Fuel;
        }

    }
}
