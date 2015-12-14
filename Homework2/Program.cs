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

            ComponentList.Add("Sony", new TV("Sony"));
            ComponentList.Add("Aiwa", new MediaCenter("Aiwa"));
            ComponentList.Add("LG", new Fridge("LG"));

            while (true)
            {
                Console.Clear();
                foreach (var c in ComponentList)
                {
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


                if (commands.Length == 3)
                {
                    if (commands[0].ToLower() == "add")
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


                    if (ComponentList.ContainsKey(commands[1]))
                    {
                        switch (commands[0].ToLower())
                        {
                            case "setvolume":
                                if (ComponentList[commands[1]] is MediaCenter)
                                {
                                    int volume;
                                    if (Int32.TryParse(commands[2], out volume))
                                    {
                                        ((MediaCenter)ComponentList[commands[1]]).SetVolume(volume);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Недопустимая громкость для устройства " + commands[1]);
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Недопустимая команда для устройства " + commands[1]);
                                    Help();
                                }
                                break;
                            case "settemper":
                                if (ComponentList[commands[1]] is Oven)
                                {
                                    int temper;
                                    if (Int32.TryParse(commands[2], out temper))
                                    {
                                        ((Oven)ComponentList[commands[1]]).SetTemper(temper);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Недопустимая температура для устройства " + commands[1]);
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Недопустимая команда для устройства " + commands[1]);
                                    Help();
                                }
                                break;
                            default:
                                Help();
                                break;
                        }

                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Устройства с таким именем не существует");
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadLine();
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

                            case "normalmode":
                                if (ComponentList[commands[1]] is Fridge)
                                {
                                    ((Fridge)ComponentList[commands[1]]).Normal();
                                }
                                else
                                {
                                    Console.WriteLine("Недопустимая команда для устройства " + commands[1]);
                                    Help();
                                }
                                break;

                            case "northmode":
                                if (ComponentList[commands[1]] is Fridge)
                                {
                                    ((Fridge)ComponentList[commands[1]]).North();
                                }
                                else
                                {
                                    Console.WriteLine("Недопустимая команда для устройства " + commands[1]);
                                    Help();
                                }
                                break;

                            case "southmode":
                                if (ComponentList[commands[1]] is Fridge)
                                {
                                    ((Fridge)ComponentList[commands[1]]).South();
                                }
                                else
                                {
                                    Console.WriteLine("Недопустимая команда для устройства " + commands[1]);
                                    Help();
                                }
                                break;

                            case "nextchannel":
                                if (ComponentList[commands[1]] is TV)
                                {
                                    ((TV)ComponentList[commands[1]]).NextChannel();
                                }
                                else
                                {
                                    Console.WriteLine("Недопустимая команда для устройства " + commands[1]);
                                    Help();
                                }
                                break;

                            case "prevchannel":
                                if (ComponentList[commands[1]] is TV)
                                {
                                    ((TV)ComponentList[commands[1]]).PrevChannel();
                                }
                                else
                                {
                                    Console.WriteLine("Недопустимая команда для устройства " + commands[1]);
                                    Help();
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

            Console.WriteLine("\tnormalmode (имя устройства)");
            Console.WriteLine("\tnorthmode (имя устройства)");
            Console.WriteLine("\tsouthmode (имя устройства)");

            Console.WriteLine("\tnextchannel (имя устройства)");
            Console.WriteLine("\tprevchannel (имя устройства)");

            Console.WriteLine("\tsetvolume (имя устройства) (громкость)");
            Console.WriteLine("\tsettemper (имя устройства) (температура)");

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
