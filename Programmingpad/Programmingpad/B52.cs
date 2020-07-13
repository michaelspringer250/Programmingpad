using System;
using System.CodeDom;

namespace Programmingpad
{
    public enum Storage
    {
        Bay,
        Left,
        Right
    }
    public enum Weapon : int
    {
        Gravity = 7988,
        JASSM = 24946,
        JDAM = 9722,
        MALD = 7626,
        WCMD = 16324,
        CALCM = 30194,
        ALCM = -30194
    }
    class B52
    {
        const int MAX_WEIGHT = 485000;
        const int MIN_FUEL = 100000;
        const int MAX_FUEL = 300000;

        private WeaponStorage _bay;
        private WeaponStorage _leftWing;
        private WeaponStorage _rightWing;
        private int _weight;
        private int _fuel;

        public WeaponStorage Bay { get => _bay; set => _bay = value; }
        public WeaponStorage LeftWing { get => _leftWing; set => _leftWing = value; }
        public WeaponStorage RightWing { get => _rightWing; set => _rightWing = value; }
        public int Weight { get => _weight; set => _weight = value; }
        public int Fuel { get => _fuel; set => _fuel = value; }


        public B52()
        {
            Bay = new WeaponStorage();
            LeftWing = new WeaponStorage();
            RightWing = new WeaponStorage();
            Weight = 185000;
            Fuel = 0;
        }


        public int CalcWeight()
        {
            return 0;
        }

        public bool IsReadyForTakeOff()
        {
            return false;
        }

        public int AddWeapon(Storage _storage, Weapon _weapon)
        {
            if (this.Weight + System.Math.Abs((int)_weapon)> MAX_WEIGHT)
            {
                throw new WeightErrorException(string.Format("Over take off weight limit {0}", MAX_WEIGHT));
            }

            switch(_storage)
            {
                case Storage.Bay:
                    {
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

            this.Weight += System.Math.Abs((int)_weapon);

            return 0;
        }

        public int AddFuel(int _fuelWeight)
        {
            if ((this.Fuel + _fuelWeight) < MIN_FUEL || _fuelWeight < 0)
            {
                throw new FuelErrorException(string.Format("Fuel does not meet minimum requirement {0}, current fuel {1}", MIN_FUEL, this.Fuel));
            }
            else if ((this.Fuel + _fuelWeight) > MAX_FUEL)
            {
                throw new FuelErrorException(string.Format("Fuel does not meet maximum requirement {0}", MAX_FUEL));
            }
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
        
    }
}

public class WeightErrorException : Exception
{
    public WeightErrorException(string message)
       : base(message)
    {
    }
}

public class FuelErrorException : Exception
{
    public FuelErrorException(string message)
       : base(message)
    {
    }
}

public class LoadErrorException : Exception
{
    public LoadErrorException(string message)
       : base(message)
    {
    }
}