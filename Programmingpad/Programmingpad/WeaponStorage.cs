<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Programmingpad
{
    class WeaponStorage
    {

        private int _Gravity;
        private int _JASSM;
        private int _JDAM;
        private int _MALD;
        private int _WCMD;
        private int _CALCM;
        private int _ALCM;

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

        public int Gravity { get => _Gravity; set => _Gravity = value; }
        public int JASSM { get => _JASSM; set => _JASSM = value; }
        public int JDAM { get => _JDAM; set => _JDAM = value; }
        public int MALD { get => _MALD; set => _MALD = value; }
        public int WCMD { get => _WCMD; set => _WCMD = value; }
        public int CALCM { get => _CALCM; set => _CALCM = value; }
        public int ALCM { get => _ALCM; set => _ALCM = value; }

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

        public int CalcWeight()
        {
            return this.Gravity * (int)Weapon.Gravity + this.JASSM * (int)Weapon.JASSM + this.JDAM * (int) Weapon.JDAM + this.MALD * (int)Weapon.MALD
                + this.WCMD * (int) Weapon.WCMD + this.CALCM * (int) Weapon.CALCM + this.ALCM * System.Math.Abs((int) Weapon.ALCM);
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Programmingpad
{
    class WeaponStorage
    {

        private int _Gravity;
        private int _JASSM;
        private int _JDAM;
        private int _MALD;
        private int _WCMD;
        private int _CALCM;
        private int _ALCM;

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

        public int Gravity { get => _Gravity; set => _Gravity = value; }
        public int JASSM { get => _JASSM; set => _JASSM = value; }
        public int JDAM { get => _JDAM; set => _JDAM = value; }
        public int MALD { get => _MALD; set => _MALD = value; }
        public int WCMD { get => _WCMD; set => _WCMD = value; }
        public int CALCM { get => _CALCM; set => _CALCM = value; }
        public int ALCM { get => _ALCM; set => _ALCM = value; }

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

        public int CalcWeight()
        {
            return this.Gravity * (int)Weapon.Gravity + this.JASSM * (int)Weapon.JASSM + this.JDAM * (int) Weapon.JDAM + this.MALD * (int)Weapon.MALD
                + this.WCMD * (int) Weapon.WCMD + this.CALCM * (int) Weapon.CALCM + this.ALCM * System.Math.Abs((int) Weapon.ALCM);
        }
    }
}
>>>>>>> 9297a42074619891afff1d73941d2c049d0533a0
