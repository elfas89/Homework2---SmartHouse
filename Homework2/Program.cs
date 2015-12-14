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
            //TV tv = new TV("Sony TVset");
            //tv.PowerOn();
            //tv.Channel = 101;
            //Console.WriteLine(tv.Info());

            //MediaCenter aiwa = new MediaCenter("Aiwa");
            //aiwa.NextChannel();
            //aiwa.PowerOn();
            //Console.WriteLine(aiwa.Info());
            //aiwa.AddChannel(101.8, "popStation");
            //aiwa.AddChannel(89.3, "rockStation");
            //aiwa.ListChannel();

            //Fridge fr = new Fridge("LG fridge");
            //fr.Open();
            //Console.WriteLine(fr.Info());


            IDictionary<string, Component> ComponentList = new Dictionary<string, Component>();

            ComponentList.Add("Sony", new TV("Sony"));
            ComponentList.Add("Aiwa", new MediaCenter("Aiwa"));
            ComponentList.Add("LG", new Fridge("LG"));

            //Console.WriteLine(ComponentList.ElementAt(0).Value.Info());

            //foreach (KeyValuePair<string, Component> c in ComponentList)
            //{
            //    Console.WriteLine(c.Value.Info());
            //}




            while (true)
            {
                Console.Clear();
                foreach (var c in ComponentList)
                {
                    //Console.WriteLine("Название: " + c.Key + ", " + c.Value.Info());
                    Console.WriteLine(c.Value.Info());

                }
                Console.WriteLine();
                Console.Write("Введите команду: ");

                string[] commands = Console.ReadLine().Split(' ');

                if (commands[0].ToLower() == "exit" & commands.Length == 1)
                {
                    return;
                }

                if (commands.Length > 3)
                {
                    Help();
                    continue;
                }

                if (commands[0].ToLower() == "add")
                {
                    if (commands.Length == 3)
                    {
                        if (!ComponentList.ContainsKey(commands[2]))
                        {
                            switch (commands[1].ToLower())
                            {
                                case "tv":
                                    ComponentList.Add(commands[2], new TV(commands[2]));
                                    break;
                                case "fridge":
                                    ComponentList.Add(commands[2], new Fridge(commands[2]));
                                    break;
                                case "stove":
                                    ComponentList.Add(commands[2], new Stove(commands[2]));
                                    break;
                                case "oven":
                                    ComponentList.Add(commands[2], new Oven(commands[2]));
                                    break;
                                case "mediacenter":
                                    ComponentList.Add(commands[2], new MediaCenter(commands[2]));
                                    break;
                                default:
                                    Help();
                                    break;
                            }

                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким именем уже существует");
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadLine();
                            continue;
                        }
                    }
                    else
                    {
                        Help();
                        continue;
                    }
                }



                if (commands.Length == 2)
                {
                    if (commands[0].ToLower() == "del")
                    {
                        if (!ComponentList.ContainsKey(commands[1]))
                        {
                            Console.WriteLine("Устройства с таким именем не существует");
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            ComponentList.Remove(commands[1]);
                            continue;
                        }
                    }

                        switch (commands[0].ToLower())
                        {
                            case "on":
                                if (ComponentList[commands[1]] is IPowerable)
                                {
                                    ((IPowerable)ComponentList[commands[1]]).PowerOn();
                                }
                                else
                                {
                                    Console.WriteLine("Недопустимая команда для устройства " + commands[1]);
                                    Help();
                                }
                                break;
                            case "off":
                                if (ComponentList[commands[1]] is IPowerable)
                                {
                                    ((IPowerable)ComponentList[commands[1]]).PowerOff();
                                }                                
                                break;
                            case "open":
                                if (ComponentList[commands[1]] is IOpenable)
                                {
                                    ((IOpenable)ComponentList[commands[1]]).Open();
                                }
                                else
                                {
                                    Console.WriteLine("Недопустимая команда для устройства " + commands[1]);
                                    Help();
                                }
                                break;
                            case "close":
                                if (ComponentList[commands[1]] is IOpenable)
                                {
                                    ((IOpenable)ComponentList[commands[1]]).Close();
                                }
                                break;







                            default:
                                Help();
                                break;
                        }


                }
                else
                {
                    Help();
                }


            }






        }



        private static void Help()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tadd (тип устройства) (имя устройства)");
            Console.WriteLine("\tdel (имя устройства)");
            Console.WriteLine("\ton (имя устройства)");
            Console.WriteLine("\toff (имя устройства)");

            Console.WriteLine("\topen (имя устройства)");
            Console.WriteLine("\tclose (имя устройства)");

            //normalmode
            //northmode
            //southmode
            
            //nextchannel
            //prevchannel

            //listchannel

            //setvolume //int
            //settemper


            Console.WriteLine("\texit");
            HelpDevices();
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }

        private static void HelpDevices()
        {
            Console.WriteLine("Доступные устройства:");
            Console.WriteLine("\tTV - телевизор");
            Console.WriteLine("\tFridge - холодильник");
            Console.WriteLine("\tStove - печь");
            Console.WriteLine("\tOven - духовка");
            Console.WriteLine("\tMediaCenter - музыкальный центр");
        }



    }
}
