
﻿using System;
using System.Collections.Generic;
using System.Text;

/*
 * Group 2 - B52 Tinker Project - ProgrammingPad
 * WeaponStorage.cs
 */

namespace Programmingpad
{
    
    /// <summary>
    /// The class represents the storage for the different weapons
    /// </summary>
    public class WeaponStorage
    {
        // Define the variables
        private LinkedList<Weapon> _storage;

        /// <summary>
        /// Construct a default WeaponStorage object
        /// </summary>
        public WeaponStorage()
        {
            this.Storage = new LinkedList<Weapon>();
        }

        /// <summary>
        /// Getters and Setters
        /// </summary>
        public LinkedList<Weapon> Storage { get => _storage; set => _storage = value; }

        /// <summary>
        /// Add weapon into the storage
        /// </summary>
        /// <param name="_weapon">
        /// </param> different types of weapon
        /// <returns>
        /// error code 0 successful, -1 error
        /// </returns>
        public int AddWeapon(Weapon weapon)
        {
            if(this.Storage.Contains(weapon))
            {
                this.Storage.Find(weapon).Value.Quantity++;            
            }
            else
            {
                this.Storage.AddLast(weapon);
            }
            return 0;
        }

        public void RemoveWeapon(Weapon weapon)
        {
            Storage.Remove(weapon);
        }

        public Boolean Contain(Weapon weapon)
        {
            if(this.Storage.Find(weapon) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Calculate the total weight after adding the weapon
        /// </summary>
        /// <returns>
        /// Returns the total weight
        /// </returns>
        public int CalcWeight()
        {
            int weight = 0;

            foreach(Weapon weapon in Storage)
            {
                weight += weapon.Weight * weapon.Quantity;
            }

            return weight;
        }

        /// <summary>
        /// Clear all the weapons from the storage
        /// </summary>
        public void ClearWeapon()
        {
            this.Storage.Clear();
        }

        public override string ToString()
        {
            String toString = "";
            foreach (Weapon weapon in Storage)
            {
                toString += weapon.ToString() + " ";
            }
            return toString;
        }
    }

}

