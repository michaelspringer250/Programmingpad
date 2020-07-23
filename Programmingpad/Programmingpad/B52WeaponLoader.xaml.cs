using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

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
        private void AddFuel(object sender, RoutedEventArgs e)
        {
            // Allow only positive number in the field
            if (System.Text.RegularExpressions.Regex.IsMatch(FuelTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Enter only positive number \n");
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
        private void LeftWingReg_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip t = new ToolTip();
            t.Content = b52.LeftWing.ToString();
            LeftWingReg.ToolTip = t;
        }

        /// <summary>
        /// Show the information of weapons in the Right wing
        /// </summary>
        private void RightWingReg_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip t = new ToolTip();
            t.Content = b52.RightWing.ToString();
            RightWingReg.ToolTip = t;
        }

        /// <summary>
        /// Show the information of weapons in the Bay
        /// </summary>
        private void BayReg_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip t = new ToolTip();
            t.Content = b52.Bay.ToString();
            BayReg.ToolTip = t;
        }

        /// <summary>
        /// Create the B52 menu
        /// </summary>
        private void B52MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new B52WeaponLoader());
        }

        /// <summary>
        /// Create the exit menu
        /// </summary>
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        /// <summary>
        /// Save the data into a file
        /// </summary>
        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save loading data to file";
            saveFileDialog.DefaultExt = ".b52";
            saveFileDialog.Filter = "B52 Config |*.b52";
            if (saveFileDialog.ShowDialog() == true && saveFileDialog.FileName != "")
            {
                b52.WriteToFile(saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// Open and read data into application
        /// </summary>
        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open loading data from file";
            openFileDialog.DefaultExt = ".b52";
            openFileDialog.Filter = "B52 Config |*.b52";
            if (openFileDialog.ShowDialog() == true && openFileDialog.FileName != "")
            {
                b52 = b52.ReadFromFile(openFileDialog.FileName);
            }

            IsReady();
            WeightLabel.Content = b52.CalcWeight();
            FuelLabel.Content = b52.Fuel;
        }

        /// <summary>
        /// Print the object to the pdf file
        /// </summary>
        
        private void SavePDFMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".pdf";
            saveFileDialog.Filter = "PDF |*.pdf";
            saveFileDialog.Title = "Save loading data to PDF";
            if (saveFileDialog.ShowDialog() == true && saveFileDialog.FileName != "")
            {
                b52.WriteToPdf(saveFileDialog.FileName);
            }
        }
    }
}
