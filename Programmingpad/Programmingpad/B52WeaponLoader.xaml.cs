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
        public B52WeaponLoader()
        {
            InitializeComponent();
        }


        private void AddWeapon(object sender, RoutedEventArgs e)
        {
            //String weapon = WeaponComboBox.Text;
            MessageBox.Show("Weapon added");
        }

        private void AddFuel(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fuel added");
        }

        private void ClearAllWeapons(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Weapons cleared");
        }

        private void ClearFuel (object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fuel cleared");
        }
    }
}
