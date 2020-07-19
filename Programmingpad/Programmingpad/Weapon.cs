using System;

namespace Programmingpad
{
    /// <summary>
    /// Create an Weapon enum that represents the weapon weight
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

    public class Weapon : IComparable<Weapon>
    {
        const int GRAVITY_WEIGHT = 7988;
        const int JASSM_WEIGHT = 24946;
        const int JDAM_WEIGHT = 9722;
        const int MALD_WEIGHT = 7626;
        const int WCMD_WEIGHT = 16324;
        const int CALCM_WEIGHT = 30194;
        const int ALCM_WEIGHT = 30194;

        private WeaponType _type;
		private int _weight;
		private int _quantity;

		public Weapon()
		{
            this.Type = WeaponType.NONE;
            this.Weight = 0;
            this.Quantity = 0;
		}

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

        public WeaponType Type { get => _type; set => _type = value; }
        public int Weight { get => _weight; set => _weight = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }

        public int CompareTo(Weapon other)
        {
            if (this.Type == other.Type)
            {
                return 0;
            }

            return other.Type.CompareTo(this.Type);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Quantity, this.Type);
        }
    }

}
