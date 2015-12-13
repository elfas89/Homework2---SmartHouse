using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    internal class TV : Component, IPowerable
    {
        public TV(string name)
           // : base(name)
        {
            Name = name;
            State = false;
        }

        private int channel;
        private string message;

        public int Channel
        {
            get
            {
                return channel;
            }
            set
            {
                if (value >= 0 && value <= 99 && State)
                {
                    channel = value;
                }
                else
                {
                    message = "Телевизор не включен / Канал задан неверно";
                }
            }
        }

        public void PowerOn()
        {
            State = true;
        }

        public void PowerOff()
        {
            State = false;
        }

        public virtual void NextChannel()
        {
            if (channel < 99)
            {
                channel += 1;
            }
            else
            {
                channel = 0;
            }
        }

        public virtual void PrevChannel()
        {
            if (channel > 0)
            {
                channel -= 1;
            }
            else
            {
                channel = 99;
            }

        }

        public override string Info()
        {

            string state;
            if (State)
            {
                state = "работает";
            }
            else
            {
                state = "не работает";
            }

            return "Телевизор: " + Name + ", состояние: " + state + ", канал: " + channel;
        }

    }
}
