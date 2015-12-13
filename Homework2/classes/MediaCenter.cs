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


        public void SetVolume(int volume)
        {
            Volume = volume;
        }


        List<Radio> radios = new List<Radio>();

        public void AddChannel(double channel, string name)
        {
            radios.Add(new Radio { Channel = channel, Name = name });
        }

        public void ListChannel()
        {
            var stations = from r in radios orderby r.Channel select r.Name;
            foreach (string s in stations)
            {
                Console.WriteLine(s);
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

            return "Медиацентр: " + Name + ", состояние: " + state + ", канал: " + channel + ", громкость: " + volume;
        }

    }
}
