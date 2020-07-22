using System;

/*
 * Group 2 - B52 Tinker Project - Programmingpad
 * @Author Sydney Ninh
 * Weapon.cs
 */

namespace Programmingpad
{
    /// <summary>
    /// Create an WeaponType enum that represents the weapon type
    /// </summary>
    public enum WeaponType : int
    {
        Gravity, // Gravity
        JASSM,  // Joint Air-to-Surface Standoff
        JDAM,    // Joint Direct Attack Munition
        MALD,    // Miniature Air Launched Decoy
        WCMD,   // Wind-Corrected Munitions Dispenser
        CALCM,  // Conventional Air Launched Cruised Missile
        ALCM,   // Air Launched Cruise Missle, Can not have the same index within enum and use absolute value for calculating
        NONE
    }
    /// <summary>
    /// The Weapon class represents the weapon: weapon type, quantity, weight
    /// </summary>
    public class Weapon : IEquatable<Weapon>
    {
        // Define constant variables
        public const int GRAVITY_WEIGHT = 7988;
        public const int JASSM_WEIGHT = 24946;
        public const int JDAM_WEIGHT = 9722;
        public const int MALD_WEIGHT = 7626;
        public const int WCMD_WEIGHT = 16324;
        public const int CALCM_WEIGHT = 30194;
        public const int ALCM_WEIGHT = 30194;

        // Define the variables
        private WeaponType _type;
		private int _weight;
		private int _quantity;

        // Default constructor
		public Weapon()
		{
            this.Type = WeaponType.NONE;
            this.Weight = 0;
            this.Quantity = 0;
		}

        /// <summary>
        ///  Construct a non - default constructor
        /// </summary>
        /// <param name="type">
        /// type of weapon
        /// </param> 
        public Weapon(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Gravity:
                    {
                        this.Type = WeaponType.Gravity;
                        this.Weight = GRAVITY_WEIGHT;
                        this.Quantity = 1;
                        break;
                    }
                case WeaponType.JASSM:
                    {
                        this.Type = WeaponType.JASSM;
                        this.Weight = JASSM_WEIGHT;
                        this.Quantity = 1;
                        break;
                    }
                case WeaponType.JDAM:
                    {
                        this.Type = WeaponType.JDAM;
                        this.Weight = JDAM_WEIGHT;
                        this.Quantity = 1;
                        break;
                    }
                case WeaponType.MALD:
                    {
                        this.Type = WeaponType.MALD;
                        this.Weight = MALD_WEIGHT;
                        this.Quantity = 1;
                        break;
                    }
                case WeaponType.WCMD:
                    {
                        this.Type = WeaponType.WCMD;
                        this.Weight = WCMD_WEIGHT;
                        this.Quantity = 1;
                        break;
                    }
                case WeaponType.CALCM:
                    {
                        this.Type = WeaponType.CALCM;
                        this.Weight = CALCM_WEIGHT;
                        this.Quantity = 1;
                        break;
                    }
                case WeaponType.ALCM:
                    {
                        this.Type = WeaponType.ALCM;
                        this.Weight = ALCM_WEIGHT;
                        this.Quantity = 1;
                        break;
                    }
                default:
                    {
                        this.Type = WeaponType.NONE;
                        this.Weight = 0;
                        this.Quantity = 0;
                        break;
                    }
            }
        }

        // Getters and setters
        public WeaponType Type { get => _type; set => _type = value; }
        public int Weight { get => _weight; set => _weight = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }


        /// <summary>
        /// Return if the two weapons are equal
        /// </summary>
        /// <param name="other">
        /// weapon
        /// </param> 
        /// <returns> 
        /// true if equal, false if not
        /// </returns>
        public bool Equals(Weapon other)
        {
            if(this.Type == other.Type)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the quantity and type of the weapon
        /// </summary>
        /// <returns> 
        /// a string decription of a weapon
        /// 
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Quantity, this.Type);
        }
    }

}
