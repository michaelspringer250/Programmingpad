using System;
using System.CodeDom;

/*
 * Group 2 - B52 Tinker Project - ProgrammingPad
 * B52.cs
 */ 
 

namespace Programmingpad
{ 
    /// <summary>
    /// Create an Storage enum that represents the Weapon storage: Bay, LeftWing, RightWing
    /// </summary>
    public enum Storage
    {
        Bay,
        Left,
        Right
    }

    /// <summary>
    /// Create an Weapon enum that represents the weapon weight
    /// </summary>
    public enum Weapon : int
    {
        Gravity = 7988, // Gravity
        JASSM = 24946,  // Joint Air-to-Surface Standoff
        JDAM = 9722,    // Joint Direct Attack Munition
        MALD = 7626,    // Miniature Air Launched Decoy
        WCMD = 16324,   // Wind-Corrected Munitions Dispenser
        CALCM = 30194,  // Conventional Air Launched Cruised Missile
        ALCM = -30194   // Air Launched Cruise Missle
    }

    /// <summary>
    /// This class represents the B52 platform includes Bay, LeftWing, RightWing
    /// Different kind of weapons will be loaded onto the B-52 platform
    /// </summary>
    class B52
    {
        // Define the constant variables
        const int MAX_WEIGHT = 485000;
        const int MIN_FUEL = 100000;
        const int MAX_FUEL = 300000;

        // Define the variables
        private WeaponStorage _bay;
        private WeaponStorage _leftWing;
        private WeaponStorage _rightWing;
        private int _weight;
        private int _fuel;

        // Getters and Setters
        public WeaponStorage Bay { get => _bay; set => _bay = value; }
        public WeaponStorage LeftWing { get => _leftWing; set => _leftWing = value; }
        public WeaponStorage RightWing { get => _rightWing; set => _rightWing = value; }
        public int Weight { get => _weight; set => _weight = value; }
        public int Fuel { get => _fuel; set => _fuel = value; }

        /// <summary>
        /// Construct a default B52 object with weight = 185000 lbs and fuel = 0
        /// </summary>
        public B52()
        {
            Bay = new WeaponStorage();
            LeftWing = new WeaponStorage();
            RightWing = new WeaponStorage();
            Weight = 185000;
            Fuel = 0;
        }

        /// <summary>
        /// Calculate the weight of B52
        /// </summary>
        /// <returns>
        /// Returns the total weight of B52
        /// </returns>
        public int CalcWeight()
        {
            return this.Weight + this.Fuel;
        }

        /// <summary>
        /// Check whether the B52 is ready to take off or not
        /// </summary>
        /// <returns>
        /// Return true if B52 is ready to take off and false if not
        /// </returns>
        public bool IsReadyForTakeOff()
        {
            if (this.Weight + this.Fuel > MAX_WEIGHT || this.Fuel < MIN_FUEL || this.Fuel > MAX_FUEL)
            {
                return false;
            }
            else
            {
                return true;
            }  
        }

        /// <summary>
        /// Add weapon onto the B52 platform: Bay, LeftWing, RightWing
        /// </summary>
        /// <param name="_storage">
        /// </param> Storage places: Bay, LeftWing, RightWing
        /// <param name="_weapon">
        /// </param> type of weapon loaded onto B52
        /// <returns>
        /// error code 0 successful, -1 error
        /// </returns>
        public int AddWeapon(Storage _storage, Weapon _weapon)
        {
            // Check if the total weight is over the maximum Take-off (ramp) weight
            if (this.Weight + System.Math.Abs((int)_weapon)> MAX_WEIGHT)
            {
                throw new WeightErrorException(string.Format("Over take off weight limit {0}", MAX_WEIGHT));
            }

            // Add weapon onto the platform
            switch(_storage)
            {
                case Storage.Bay:
                    {
                        // Check for additional limitation - MALD and WCMD cannot be loaded into the Bay
                        if (_weapon == Weapon.MALD|| _weapon == Weapon.WCMD)
                        {
                            throw new LoadErrorException(string.Format("MALD and WCMD cannot be loaded into the bay"));
                        }
                        else
                        {
                            Bay.AddWeapon(_weapon);
                        }
                        
                        break;
                    }
                case Storage.Left:
                    {
                        LeftWing.AddWeapon(_weapon);
                        break;
                    }
                case Storage.Right:
                    {
                        RightWing.AddWeapon(_weapon);
                        break;
                    }
                default: return -1;
            }
            // Calculate the current weight after adding weapon
            this.Weight += System.Math.Abs((int)_weapon);

            return 0;
        }

        /// <summary>
        /// Add fuel into the B52 Platform
        /// </summary>
        /// <param name="_fuelWeight"></param>
        /// <returns>
        /// error code 0 successful, -1 error
        /// </returns>
        
        public int AddFuel(int _fuelWeight)
        {
            // Check for negative value of fuel weight and minimum fuel weight
            if ((this.Fuel + _fuelWeight) < MIN_FUEL || _fuelWeight < 0)
            {
                throw new FuelErrorException(string.Format("Fuel does not meet minimum requirement {0}, current fuel {1}", MIN_FUEL, this.Fuel));
            }
            // Check for maximum fuel weight
            else if ((this.Fuel + _fuelWeight) > MAX_FUEL)
            {
                throw new FuelErrorException(string.Format("Fuel does not meet maximum requirement {0}", MAX_FUEL));
            }
            // Check whether exceeding maximum weight for taking off or not
            else if ((this.Fuel + _fuelWeight + this.Weight) > MAX_WEIGHT)
            {
                throw new WeightErrorException(string.Format("Over take off weight limit", MAX_WEIGHT));
            }
            else
            {
                this.Fuel += _fuelWeight;
            }
            
            return 0;
        }

        /// <summary>
        /// Clear the weapons from the weapon storages
        /// </summary>
        public void ClearWeapon()
        {
            this._bay.ClearWeapon();
            this._leftWing.ClearWeapon();
            this._rightWing.ClearWeapon();
        }

        /// <summary>
        /// Clear the Fuel 
        /// </summary>
        public void ClearFuel()
        {
            this.Fuel = 0;
        }
        
    }
}

/// <summary>
/// Thrown when the total weight is over the take off weight limit
/// </summary>
public class WeightErrorException : Exception
{
    public WeightErrorException(string message)
       : base(message)
    {
    }
}

/// <summary>
/// Thrown when the fuel weight does not meet minimum or maximum requirements
/// </summary>
public class FuelErrorException : Exception
{
    public FuelErrorException(string message)
       : base(message)
    {
    }
}

/// <summary>
/// Thrown when MALD and WCMD be loaded into the bay
/// </summary>
public class LoadErrorException : Exception
{
    public LoadErrorException(string message)
       : base(message)
    {
    }
}