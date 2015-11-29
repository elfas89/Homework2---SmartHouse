using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    internal class Oven : Stove, IOpenable
    {
        public Oven(string name)
            : base(name)
        {
            Name = name;
            State = false;
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
