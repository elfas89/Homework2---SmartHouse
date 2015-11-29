using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    internal class Stove : Component, IGasable
    {
        public Stove(string name)
            : base(name)
        {
            Name = name;
            State = false;
        }


        public override string Info()
        {
            throw new NotImplementedException();
        }
    }
}
