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

        public new double Channel
        {
            get
            {
                return channel;
            }
        }

        public override void NextChannel()
        {
            if (channel <= 115.5)
            {
                channel += 0.5;
            }
            else
            {
                channel = 88.8;
            }
        }

        public override void PrevChannel()
        {
            if (channel >= 88.8)
            {
                channel -= 0.5;
            }
            else
            {
                channel = 115.5;
            }
        }

        //public void SetVolume();
        //public void SearchChannel();
        //public void SetEqualizer();
        //public PlugInExternalDevice();



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

            return "Медиацентр: " + Name + ", состояние: " + state + ", канал: " + channel;
        }

    }
}
