using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    internal class Fridge : Component, IPowerable, IOpenable
    {
        private FridgeModes mode;
        private bool doorOpened;

        public Fridge (string name) 
          //  : base(name)
        {
            Name = name;
            this.mode = FridgeModes.normal;
            State = false;
            doorOpened = false;
        }

        public void PowerOn()
        {
            if (!State) { 
            State = true;
            mode = FridgeModes.normal;
            }
        }

        public void PowerOff()
        {
            if (State)
            {
            State = false;
            mode = FridgeModes.south;
            //powerMess = "Холодильник выключен, продукты портятся!";
            }
        }

        public void Open()
        {
            doorOpened = true;
        }

        public void Close()
        {
            doorOpened = false;
        }

        public override string Info()
        {
            if (doorOpened)
            {
                return "Холодильник: " + Name + " - закройте дверцу холодильника!";
            }

            string state;
            if (State)
            {
                state = "работает";
            }
            else
            {
                return "Холодильник " + Name + " выключен, продукты портятся!";
            }

            string mode;
            if (this.mode == FridgeModes.normal)
            {
                mode = "нормальный";
            }
            else if (this.mode == FridgeModes.north)
            {
                mode = "заморозки к чертям";
            }
            else
            {
                mode = "разморозки к лужам";
            }



            return "Холодильник: " + Name + ", состояние: " + state + ", режим: " + mode;
        }

    }
}
