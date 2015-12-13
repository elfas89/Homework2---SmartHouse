using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    internal class Oven : Stove, IOpenable, ISetupable
    {
        public Oven(string name)
            : base(name)
        {
            Name = name;
            State = false;
        }

        private int temperature;
        private int minTemper = 0;
        private int maxTemper = 96;

        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value >= minTemper && value <= maxTemper)
                {
                    temperature = value;
                }
            }
        }

        private bool doorOpened;



        public void Open()
        {
            doorOpened = true;
        }

        public void Close()
        {
            doorOpened = false;
        }

    }
}
