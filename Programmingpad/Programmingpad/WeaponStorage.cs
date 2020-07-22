
﻿using System;
using System.Collections.Generic;
using System.Text;

/*
 * Group 2 - B52 Tinker Project - ProgrammingPad
 * @Author Sydney Ninh
 * WeaponStorage.cs
 */

namespace Programmingpad
{
    
    /// <summary>
    /// The class represents the storage for the different weapons
    /// </summary>
    public class WeaponStorage
    {
        // Define the variable
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
        /// <param name="weapon">
        /// type of weapon
        /// </param> 

        public void AddWeapon(Weapon weapon)
        {
            // Check whether the weapon in the Linkedlist or not, if not add weapon
            if(this.Storage.Contains(weapon))
            {
                this.Storage.Find(weapon).Value.Quantity++;            
            }
            else
            {
                this.Storage.AddLast(weapon);
            }
        }

        /// <summary>
        /// Remove a weapon from the Weapon Storage
        /// <param name="weapon">
        ///  type of weapon
        /// </param>
        public void RemoveWeapon(Weapon weapon)
        {
            Storage.Remove(weapon);
        }

        /// <summary>
        /// Check whether the weapon in the storage or not
        /// </summary>
        /// <param name="weapon">
        /// type of weapon
        /// </param> 
        /// <returns>
        /// Return true if the weapon in the storage, false if not
        /// </returns>
        public Boolean Contain(Weapon weapon)
        {
            return this.Storage.Contains(weapon);
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

        /// <summary>
        /// Return the quantity and type of all weapon in the storage
        /// </summary>
        /// <returns>
        /// a string description of the weapon storage
        /// </returns>
        public override string ToString()
        {
            String toString = "";
            foreach (Weapon weapon in Storage)
            {
                if(Storage.Count > 1)
                {
                    toString += weapon.ToString() + " ";
                }
                else
                {
                    toString = weapon.ToString();
                }
            }
            return toString;
        }
    }

}

