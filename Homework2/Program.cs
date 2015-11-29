using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, Component> ComponentList = new Dictionary<string, Component>();

            ComponentList.Add("tv1", new TV("Sony TVset"));
            ComponentList.Add("mc1", new MediaCenter("Aiwa"));
            ComponentList.Add("fr1", new Fridge("LG fridge"));

            //TV tv = new TV("Sony TVset");
            //tv.PowerOn();
            //tv.Channel = 101;
            //Console.WriteLine(tv.Info());

            //MediaCenter aiwa = new MediaCenter("Aiwa");
            //aiwa.NextChannel();
            //aiwa.PowerOn();
            //Console.WriteLine(aiwa.Info());

            //Fridge fr = new Fridge("LG fridge");
            //fr.Open();
            //Console.WriteLine(fr.Info());

            foreach (KeyValuePair<string, Component> c in ComponentList)
            {
                Console.WriteLine(c.Value.Info());
            }







        }
    }
}
