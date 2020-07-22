﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

/*
 * Group 2 - B52 Tinker Project - Programmingpad
 * @Author Sydney Ninh
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
    /// This class represents the B52 platform includes Bay, LeftWing, RightWing
    /// Different kind of weapons will be loaded onto the B-52 platform
    /// </summary>
    [Serializable]
    public class B52
    {
        // Define the constant variables
        const int MAX_WEIGHT = 485000;
        const int MIN_FUEL = 100000;
        const int MAX_FUEL = 300000;
        const int INIT_WEIGHT = 185000;
        
        // Define the variables
        private WeaponStorage _bay;
        private WeaponStorage _leftWing;
        private WeaponStorage _rightWing;
        private int _weight;
        private int _fuel;
        
        // Getters and Setters
        public int Weight { get => _weight; set => _weight = value; }
        public int Fuel { get => _fuel; set => _fuel = value; }
        public WeaponStorage Bay { get => _bay; set => _bay = value; }
        public WeaponStorage LeftWing { get => _leftWing; set => _leftWing = value; }
        public WeaponStorage RightWing { get => _rightWing; set => _rightWing = value; }

        /// <summary>
        /// Construct a default B52 object with weight = 185000 lbs and fuel = 0
        /// </summary>
        public B52()
        {
            Bay = new WeaponStorage();
            LeftWing = new WeaponStorage();
            RightWing = new WeaponStorage();
            Weight = INIT_WEIGHT;
            Fuel = 0;
        }

        /// <summary>
        /// Calculate the weight of B52 which consists of B52 weight and fuel weight
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
        /// <param name="storage">
        /// </param> Storage places: Bay, LeftWing, RightWing
        /// <param name="weapon">
        /// </param> type of weapon loaded onto B52
        
        public void AddWeapon(Storage storage, Weapon weapon) 
        {
            switch (storage)
            {
                case Storage.Bay:
                    {
                        // Check if MALD and WCMD is loaded into the Bay
                        if (weapon.Type == WeaponType.MALD || weapon.Type == WeaponType.WCMD)
                            throw new LoadErrorException("MALD and WCMD cannot be loaded into the bay");
                        else
                        {
                            // Check if the same weapon is added into Bay area
                            if(Bay.Contain(weapon))
                                throw new LoadErrorException(String.Format("{0} is already loaded into the bay", weapon.Type));
                            else
                            {
                                if (this.CalcWeight() + weapon.Weight > MAX_WEIGHT)
                                    throw new WeightErrorException(String.Format("Adding {0} will make the B-52 unable to take off", weapon.Type)); 
                                else 
                                {
                                    Bay.AddWeapon(weapon);
                                    this.Weight += weapon.Weight;
                                } 
                            }
                        }
                        break;
                    }
                case Storage.Left:
                    {
                        // Check if the same weapon is added into Leftwing area
                        if (LeftWing.Contain(weapon))
                            throw new LoadErrorException(String.Format("{0} is already loaded into the left wing", weapon.Type));
                        else
                        {
                            if (this.CalcWeight() + weapon.Weight > MAX_WEIGHT)
                                throw new WeightErrorException(String.Format("Adding {0} will make the B-52 unable to take off", weapon.Type));
                            else
                            {
                                LeftWing.AddWeapon(weapon);
                                this.Weight += weapon.Weight;
                            }
                        }
                        break;
                    }
                case Storage.Right:
                    {
                        // // Check if the same weapon is added into Right wing area
                        if (RightWing.Contain(weapon))
                            throw new LoadErrorException(String.Format("{0} is already loaded into the right wing", weapon.Type));
                        else
                        {
                            if (this.CalcWeight() + weapon.Weight > MAX_WEIGHT)
                                throw new WeightErrorException(String.Format("Adding {0} will make the B-52 unable to take off", weapon.Type));
                            else
                            {
                                RightWing.AddWeapon(weapon);
                                this.Weight += weapon.Weight;
                            }
                        }
                        break;
                    }
                default: break;
            }
        }

        /// <summary>
        /// Add fuel into the B52 Platform
        /// </summary>
        /// <param name="fuelWeight"></param>
        
        
        public void AddFuel(int fuelWeight)
        {
            // Check for negative value of fuel weight and minimum fuel weight
            if ((this.Fuel + fuelWeight) < MIN_FUEL || fuelWeight < 0)
                throw new FuelErrorException(string.Format("Fuel does not meet minimum requirement {0}, current fuel {1}", MIN_FUEL, this.Fuel));
            // Check for maximum fuel weight
            else if ((this.Fuel + fuelWeight) > MAX_FUEL)
                throw new FuelErrorException(string.Format("Fuel does not meet maximum requirement {0}", MAX_FUEL));
            // Check whether exceeding maximum weight for taking off or not
            else if ((this.Fuel + fuelWeight + this.Weight) > MAX_WEIGHT)
                throw new WeightErrorException(string.Format("Over take off weight limit", MAX_WEIGHT));
            else
                this.Fuel += fuelWeight;
        }

        /// <summary>
        /// Clear the weapons from the weapon storages
        /// </summary>
        public void ClearWeapon()
        {
            Bay.ClearWeapon();
            LeftWing.ClearWeapon();
            RightWing.ClearWeapon();
            this.Weight = INIT_WEIGHT;
        }

        /// <summary>
        /// Clear the Fuel 
        /// </summary>
        public void ClearFuel()
        {
            this.Fuel = 0;
        }
         
        /// <summary>
        /// write the object to the file
        /// </summary>
        /// <param name="path"></param>
        public void WriteToFile(String path)  
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@path, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, this);
            stream.Close();
        }

        /// <summary>
        /// Read the object from the file
        /// </summary>
        /// <param name="path">
        /// file path
        /// </param>
        /// <returns>
        /// the B52 object
        /// </returns>
        public B52 ReadFromFile(String path)  
        {
            Stream stream = new FileStream(@path, FileMode.Open, FileAccess.Read);
            IFormatter formatter = new BinaryFormatter();
            return (B52)formatter.Deserialize(stream);
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
}

