using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    internal class MediaCenter : TV
    {
        public MediaCenter(string name)
            : base(name)
        {
            Name = name;
            State = false;
            channel = 88.8;
        }

        private double channel;
        private int volume;

        public new double Channel
        {
            get
            {
                return channel;
            }
        }

        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    volume = value;
                }
            }
        }


        public override void NextChannel()
        {
            if (channel < 115.8)
            {
                channel += 0.5;
            }
            else
            {
                channel = 88.8;
            }
            State = true;
        }

        public override void PrevChannel()
        {
            if (channel > 88.8)
            {
                channel -= 0.5;
            }
            else
            {
                channel = 115.8;
            }
            State = true;
        }


        public void SetVolume(int volume)
        {
            Volume = volume;
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

            return "Медиацентр: " + Name + ", состояние: " + state + ", канал: " + channel + ", громкость: " + volume;
        }

    }
}
