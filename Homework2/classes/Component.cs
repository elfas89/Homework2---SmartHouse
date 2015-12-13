using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    abstract class Component
    {
        //public Component(string name)
        //{
        //    Name = name;
        //}

        public string Name { get; set; }

        public bool State { get; set; }

        abstract public string Info();
                
    }
}
