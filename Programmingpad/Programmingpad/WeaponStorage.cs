
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
    class WeaponStorage
    {
        // Define the variables
        private int _Gravity; // Gravity
        private int _JASSM;   // Joint Air-to-Surface Standoff
        private int _JDAM;    // Joint Direct Attack Munition
        private int _MALD;    // Miniature Air Launched Decoy
        private int _WCMD;    // Wind-Corrected Munitions Dispenser
        private int _CALCM;   // Conventional Air Launched Cruised Missile
        private int _ALCM;    // Air Launched Cruise Missle

        /// <summary>
        /// Construct a default WeaponStorage object
        /// </summary>
        public WeaponStorage()
        {
            this.Gravity = 0;
            this.JASSM = 0;
            this.JDAM = 0;
            this.MALD = 0;
            this.WCMD = 0;
            this.CALCM = 0;
            this.ALCM = 0;   
        }

        public override string ToString() 
        {
            return string.Format("Gravity {0} JASSM {1} JDAM {2} MALD {3} WCMD {4} CALCM {5} ALCM {6}", Gravity,JASSM,JDAM,MALD,WCMD,CALCM,ALCM);
        }
        /// <summary>
        /// Getters and Setters
        /// </summary>

        public int Gravity { get => _Gravity; set => _Gravity = value; }
        public int JASSM { get => _JASSM; set => _JASSM = value; }
        public int JDAM { get => _JDAM; set => _JDAM = value; }
        public int MALD { get => _MALD; set => _MALD = value; }
        public int WCMD { get => _WCMD; set => _WCMD = value; }
        public int CALCM { get => _CALCM; set => _CALCM = value; }
        public int ALCM { get => _ALCM; set => _ALCM = value; }

        /// <summary>
        /// Add weapon into the storage
        /// </summary>
        /// <param name="_weapon">
        /// </param> different types of weapon
        /// <returns>
        /// error code 0 successful, -1 error
        /// </returns>
        public int AddWeapon(Weapon _weapon)
        {
            switch(_weapon)
            {
                case Weapon.Gravity:
                    {
                        this.Gravity = 1;
                        break;
                    }
                case Weapon.JASSM:
                    {
                        this.JASSM = 1;
                        break;
                    }
                case Weapon.JDAM:
                    {
                        this.JDAM = 1;
                        break;
                    }
                case Weapon.MALD:
                    {
                        this.MALD = 1;
                        break;
                    }
                case Weapon.WCMD:
                    {
                        this.WCMD = 1;
                        break;
                    }
                case Weapon.CALCM:
                    {
                        this.CALCM = 1;
                        break;
                    }
                case Weapon.ALCM:
                    {
                        this.ALCM = 1;
                        break;
                    }
                default: return -1;
            }

            return 0;
        }

        /// <summary>
        /// Calculate the total weight after adding the weapon
        /// </summary>
        /// <returns>
        /// Returns the total weight
        /// </returns>
        public int CalcWeight()
        {
            return this.Gravity * (int)Weapon.Gravity + this.JASSM * (int)Weapon.JASSM + this.JDAM * (int) Weapon.JDAM + this.MALD * (int)Weapon.MALD
                + this.WCMD * (int) Weapon.WCMD + this.CALCM * (int) Weapon.CALCM + this.ALCM * System.Math.Abs((int) Weapon.ALCM);
        }

        /// <summary>
        /// Clear all the weapons from the storage
        /// </summary>
        public void ClearWeapon()
        {
            this.Gravity = 0;
            this.JASSM = 0;
            this.JDAM = 0;
            this.MALD = 0;
            this.WCMD = 0;
            this.CALCM = 0;
            this.ALCM = 0;
        }
    }
}

