﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_MD21_Converter
{
    class Start
    {

        static string server, database, username, password, table;

        public Start()
        {
            
        }

        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Roccus Multi Converter");
            Console.WriteLine("Created by ©Roccus");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press -M to go to M2 mode");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press -R to go to SORTING/RETRIEVE menu");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press -E to exit the application");

            ConsoleKey response;

            do
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Choose your mode : ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.M && response != ConsoleKey.R && response != ConsoleKey.E);

            if (response == ConsoleKey.M)
            {
                M2Menu();

            }else if(response == ConsoleKey.R)
            {
                Sorting_Retrieve_Menu();
            }
            else if(response == ConsoleKey.E)
            {
                Console.Clear();
                Environment.Exit(1);
            }

            Console.ReadLine();

        }

        static void Sorting_Retrieve_Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Roccus Multi Converter");
            Console.WriteLine("Created by ©Roccus");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press -S to go to the FILEDATA_SORTING mode");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press -R to go to the CASCHOST_RETRIEVE mode");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press -E to return to main menu");

            ConsoleKey response;

            do
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Choose your mode : ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.S && response != ConsoleKey.R && response != ConsoleKey.E);

            if(response == ConsoleKey.S)
            {
                rootGenFiledata();
            }
            else if(response == ConsoleKey.R)
            {
                rootGenCaschost();
            }
            else if(response == ConsoleKey.E)
            {
                Console.Clear();
                Main(new string[0]);
            }

        }

        static void M2Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Roccus Multi Converter");
            Console.WriteLine("Created by ©Roccus");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("M2 MODE");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press -L to convert cata+/WoD MD20 to Legion MD21");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Press -D to convert Legion MD21 to cata+/WoD MD20");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press -E to return the main menu");

            ConsoleKey choice;

            do
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("What do you want to do ? : ");
                choice = Console.ReadKey(false).Key;
                if (choice != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (choice != ConsoleKey.L && choice != ConsoleKey.D && choice != ConsoleKey.E);

            if (choice == ConsoleKey.L)
            {
                WodMd20ToMd21();
            }else if(choice == ConsoleKey.D)
            {
                Md21ToWodMd20();
            }
            else if (choice == ConsoleKey.E)
            {
                Console.Clear();
                Main(new string[0]);
            }
        }

        static void WodMd20ToMd21()
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Roccus Multi Converter");
            Console.WriteLine("Created by ©Roccus");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("cata+/WoD MD20 to Legion MD21");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press Enter to scan the files of the directory");

            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;

            string binaryPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string exeName = Path.GetFileName(binaryPath);
            binaryPath = binaryPath.Replace(exeName, "cataWoDToLegionM2");

            List<string> path = new List<string>();
            string[] files = Directory.GetFiles(binaryPath);
            for (UInt32 i = 0; i < files.Length; i++)
            {
                if (files[i].Contains("m2"))
                    path.Add(files[i]);
            }

            if (path.Count() != 0)
            {
                foreach (string name in path)
                {
                    string modelName = Path.GetFileName(name);
                    string[] array = modelName.Split('.');
                    string subName = array[0];

                    Console.WriteLine(modelName);

                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("These are all the files that can be converted to MD21 format");

                ConsoleKey response;

                do
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Do you want to continue ? [y/n] ");
                    response = Console.ReadKey(false).Key;
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (response == ConsoleKey.Y)
                {
                    Int16 counter = 0;
                    for (Int32 i = 0; i < path.Count(); i++)
                    {
                        string modelName = Path.GetFileName(path[i]);
                        string[] array = modelName.Split('.');
                        string subName = array[0];

                        byte[] data = File.ReadAllBytes(path[i]);

                        if (Encoding.UTF8.GetString(data, 0, 4) == "MD20")
                        {
                            if (Encoding.UTF8.GetString(data).Contains("AFID") || Encoding.UTF8.GetString(data).Contains("SFID")
                                 || Encoding.UTF8.GetString(data).Contains("PFID") || Encoding.UTF8.GetString(data).Contains("BFID"))
                            {
                                Console.WriteLine("- " + subName + " Can't convert this file to MD21");
                                Console.WriteLine("     Use the WoD conversion mode before attempting this file again");
                                Console.WriteLine();
                                counter++;
                            }
                            else
                            {
                                HeaderFix parser = new HeaderFix(path[i]);

                                parser.Save();

                                WodMd20ToMd21 start = new WodMd20ToMd21(subName.ToLower(), path[i]);

                                counter++;

                                Console.WriteLine("- " + subName + " : Processed");
                                Console.WriteLine();
                            }
                        }
                        else if (Encoding.UTF8.GetString(data, 0, 4) == "MD21")
                        {
                            if (Encoding.UTF8.GetString(data).Contains("AFID") || Encoding.UTF8.GetString(data).Contains("SFID")
                                || Encoding.UTF8.GetString(data).Contains("PFID") || Encoding.UTF8.GetString(data).Contains("BFID"))
                            {
                                Console.WriteLine("- " + subName + " : This file is already a MD21");
                                Console.WriteLine();
                                counter++;
                            }
                            else
                            {

                                FileStream fs = new FileStream(path[i], FileMode.Open);

                                fs.Position = 8;
                                fs.Read(data, 0, data.Length);
                                fs.Close();

                                fs = new FileStream(path[i], FileMode.Truncate);
                                fs.Write(data, 0, data.Length - 8);
                                fs.Close();

                                HeaderFix parser = new HeaderFix(path[i]);

                                parser.Save();

                                WodMd20ToMd21 start = new WodMd20ToMd21(subName.ToLower(), path[i]);

                                counter++;

                                Console.WriteLine("- " + subName + " : Processed, chunks fixed");
                                Console.WriteLine();
                            }
                        }


                    }

                    if (counter == path.Count())
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        binaryPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                        exeName = Path.GetFileName(binaryPath);
                        binaryPath = binaryPath.Replace(exeName, "LegionM2_output");
                        var dirName = new DirectoryInfo(binaryPath).Name;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("The files were moved to : " + dirName + " folder");
                        foreach (string s in path)
                        {
                            if(File.Exists(dirName + @"\" + Path.GetFileName(s)))
                            {
                                File.Delete(dirName + @"\" + Path.GetFileName(s));
                            }
                            File.Copy(s, dirName + @"\" + Path.GetFileName(s));
                            File.Delete(s);
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine();
                        Console.WriteLine("All directory's files processed, press Enter to return to the M2 menu");
                        path.Clear();
                        Console.ReadLine();
                        Console.Clear();
                        M2Menu();
                    }

                }
                else if(response == ConsoleKey.N)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You chose No, press Enter to go back to the M2 menu");
                    Console.ReadLine();
                    Console.Clear();
                    M2Menu();
                }
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("No file to be converted, press Enter to return to the M2 menu");
                Console.ReadLine();
                Console.Clear();
                M2Menu();
            }
        }

        static void Md21ToWodMd20()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Roccus Multi Converter");
            Console.WriteLine("Created by ©Roccus");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Legion MD21 to cata+/WoD MD20");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press Enter to scan the files of the directory");

            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;

            string binaryPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string exeName = Path.GetFileName(binaryPath);
            binaryPath = binaryPath.Replace(exeName, "LegionToCataWoDM2");

            List<string> path = new List<string>();
            string[] files = Directory.GetFiles(binaryPath);
            for (UInt32 i = 0; i < files.Length; i++)
            {
                if (files[i].Contains("m2"))
                    path.Add(files[i]);
            }

            if (path.Count != 0)
            {
                foreach (string name in path)
                {
                    string modelName = Path.GetFileName(name);
                    string[] array = modelName.Split('.');
                    string subName = array[0];

                    Console.WriteLine(modelName);

                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("These are all the files that can be converted to cata+/Wod format");

                ConsoleKey response;

                do
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Do you want to continue ? [y/n] ");
                    response = Console.ReadKey(false).Key;
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (response == ConsoleKey.Y)
                {
                    Int16 counter = 0;
                    for (Int32 i = 0; i < path.Count(); i++)
                    {

                        Md21ToWodMd20 md = new Md21ToWodMd20(path[i]);
                        counter++;

                    }

                    if (counter == path.Count())
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        binaryPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                        exeName = Path.GetFileName(binaryPath);
                        binaryPath = binaryPath.Replace(exeName, "cataWoDToLegionM2");
                        var dirName = new DirectoryInfo(binaryPath).Name;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("The files were moved to : " + dirName + " folder");
                        foreach (string s in path)
                        {
                            if(File.Exists(dirName + @"\" + Path.GetFileName(s)))
                            {
                                File.Delete(dirName + @"\" + Path.GetFileName(s));
                            }
                            File.Copy(s, dirName + @"\" + Path.GetFileName(s));
                            File.Delete(s);
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine();
                        Console.WriteLine("All directory's files processed, press Enter to return to the M2 menu");
                        path.Clear();
                        Console.ReadLine();
                        Console.Clear();
                        M2Menu();
                    }
                }
                else if (response == ConsoleKey.N)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("You chose No, press Enter to go back to the M2 menu");
                    Console.ReadLine();
                    Console.Clear();
                    M2Menu();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("No file to be converted, press Enter to return to the M2 menu");
                Console.ReadLine();
                Console.Clear();
                M2Menu();
            }


        }

        static void rootGenFiledata()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Roccus Multi Converter");
            Console.WriteLine("Created by ©Roccus");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("FILEDATA_SORTING MODE");

            rootChoiceFiledata();

        }

        static void rootChoiceFiledata()
        {

            rootGenFiledata gen = new rootGenFiledata();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Choose what you want to do");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press -M to generate M2 root");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press -S to generate SKIN root");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Press -A to generate ANIM root");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press -B to generate BONE root");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Press -P to generate PHYS root");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press -E to return the main menu");

            ConsoleKey choice;

            do
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("What do you want to do ? : ");
                choice = Console.ReadKey(false).Key;
                if (choice != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (choice != ConsoleKey.M && choice != ConsoleKey.S && choice != ConsoleKey.A
                    && choice != ConsoleKey.B && choice != ConsoleKey.P && choice != ConsoleKey.E);

            if (choice == ConsoleKey.M)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Generate M2 root");
                Console.WriteLine();
                Console.Write("Press Enter to Generate a M2 Root");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Filedata is being processed, please wait...");
                gen.SelectM2Root();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("All root paths processed, press Enter to return to the FILEDATA_SORTING menu");
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("FILEDATA_SORTING MODE");
                rootChoiceFiledata();
            }
            else if (choice == ConsoleKey.A)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Generate ANIM root");
                Console.WriteLine();
                Console.Write("Press Enter to Generate an ANIM Root");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Filedata is being processed, please wait...");
                gen.SelectANIMRoot();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("All root paths processed, press Enter to return to the FILEDATA_SORTING menu");
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("FILEDATA_SORTING MODE");
                rootChoiceFiledata();
            }
            else if (choice == ConsoleKey.B)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Generate BONE root");
                Console.WriteLine();
                Console.Write("Press Enter to Generate a BONE Root");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Filedata is being processed, please wait...");
                gen.SelectBONERoot();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("All root paths processed, press Enter to return to the FILEDATA_SORTING menu");
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("FILEDATA_SORTING MODE");
                rootChoiceFiledata();
            }
            else if (choice == ConsoleKey.S)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Generate SKIN root");
                Console.WriteLine();
                Console.Write("Press Enter to Generate a SKIN Root");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Filedata is being processed, please wait...");
                gen.SelectSKINRoot();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("All root paths processed, press Enter to return to the FILEDATA_SORTING menu");
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("FILEDATA_SORTING MODE");
                rootChoiceFiledata();
            }
            else if (choice == ConsoleKey.P)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Generate PHYS root");
                Console.WriteLine();
                Console.Write("Press Enter to Generate a PHYS Root");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Filedata is being processed, please wait...");
                gen.SelectPHYSRoot();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("All root paths processed, press Enter to return to the FILEDATA_SORTING menu");
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("FILEDATA_SORTING MODE");
                rootChoiceFiledata();
            }
            else if (choice == ConsoleKey.X)
            {
                Console.Clear();
                rootGenFiledata();
            }
            else if (choice == ConsoleKey.E)
            {
                Console.Clear();              
                Main(new string[0]);
            }

        }

        static void rootGenCaschost()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Roccus Multi Converter");
            Console.WriteLine("Created by ©Roccus");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("CASCHOST_DATA_RETRIEVE MODE");
            Console.WriteLine();
            Console.WriteLine("(If you have an error, press ESC to reset the menu)");
            Console.WriteLine();
            Console.WriteLine();

            bool continueReading = true;
            char newLineChar = '\r';
            StringBuilder passwordBuilder = new StringBuilder();

            Console.Write("Enter your Server's name : ");
            server = Console.ReadLine();
            Console.Write("Enter your Database's name : ");
            database = Console.ReadLine();
            Console.Write("Enter your Username : ");
            username = Console.ReadLine();
            Console.Write("Enter your Password : ");
            while (continueReading)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                char passwordChar = consoleKeyInfo.KeyChar;

                if (passwordChar == newLineChar)
                {
                    continueReading = false;
                }
                else
                {
                    passwordBuilder.Append(passwordChar.ToString());
                }
            }
            password = passwordBuilder.ToString();

            rootChoiceCaschost();

        }

        static void rootChoiceCaschost()
        {
            Console.Clear();
            rootGenCaschost gen = new rootGenCaschost(server, database, username, password);
            if (gen.OpenConnection() == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot connect to server, maybe you entered either:\n A non-existing DB, wrong Server or wrong pseudo/password.  Contact administrator\n Press ESC to retry");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    gen.CloseConnection();
                    rootGenCaschost();
                }
                else if(Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    gen.CloseConnection();
                    Sorting_Retrieve_Menu();
                }
            }
            gen.CloseConnection();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Roccus Multi Converter");
            Console.WriteLine("Created by ©Roccus");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You're connected to " + server + " on DB : " + database);
            Console.WriteLine("User : " + username);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Choose what you want to do");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press -M to generate M2 root");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press -S to generate SKIN root");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Press -A to generate ANIM root");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press -B to generate BONE root");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Press -P to generate PHYS root");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Press -X to return the server connection menu");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press -E to return the main menu");

            ConsoleKey choice;

            do
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("What do you want to do ? : ");
                choice = Console.ReadKey(false).Key;
                if (choice != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (choice != ConsoleKey.M && choice != ConsoleKey.S && choice != ConsoleKey.A
                    && choice != ConsoleKey.B && choice != ConsoleKey.P && choice != ConsoleKey.E && choice != ConsoleKey.X);

            if (choice == ConsoleKey.M)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You're connected to " + server + " on DB : " + database);
                Console.WriteLine("User : " + username);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Generate M2 root");
                Console.WriteLine();
                Console.Write("Enter your Table's name : ");
                table = Console.ReadLine();
                gen.SelectM2Root(table);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("All root paths processed, press Enter to return to the CASCHOST_DATA_RETRIEVE menu");
                Console.ReadLine();
                rootChoiceCaschost();
            }
            else if (choice == ConsoleKey.A)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You're connected to " + server + " on DB : " + database);
                Console.WriteLine("User : " + username);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Generate ANIM root");
                Console.WriteLine();
                Console.Write("Enter your Table's name : ");
                table = Console.ReadLine();
                gen.SelectANIMRoot(table);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("All root paths processed, press Enter to return to the CASCHOST_DATA_RETRIEVE menu");
                Console.ReadLine();
                rootChoiceCaschost();
            }
            else if (choice == ConsoleKey.B)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You're connected to " + server + " on DB : " + database);
                Console.WriteLine("User : " + username);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Generate BONE root");
                Console.WriteLine();
                Console.Write("Enter your Table's name : ");
                table = Console.ReadLine();
                gen.SelectBONERoot(table);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("All root paths processed, press Enter to return to the CASCHOST_DATA_RETRIEVE menu");
                Console.ReadLine();
                rootChoiceCaschost();
            }
            else if (choice == ConsoleKey.S)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You're connected to " + server + " on DB : " + database);
                Console.WriteLine("User : " + username);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Generate SKIN root");
                Console.WriteLine();
                Console.Write("Enter your Table's name : ");
                table = Console.ReadLine();
                gen.SelectSKINRoot(table);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("All root paths processed, press Enter to return to the CASCHOST_DATA_RETRIEVE menu");
                Console.ReadLine();
                rootChoiceCaschost();
            }
            else if (choice == ConsoleKey.P)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Roccus Multi Converter");
                Console.WriteLine("Created by ©Roccus");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You're connected to " + server + " on DB : " + database);
                Console.WriteLine("User : " + username);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Generate PHYS root");
                Console.WriteLine();
                Console.Write("Enter your Table's name : ");
                table = Console.ReadLine();
                gen.SelectPHYSRoot(table);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("All root paths processed, press Enter to return to the CASCHOST_DATA_RETRIEVE menu");
                Console.ReadLine();
                rootChoiceCaschost();
            }
            else if (choice == ConsoleKey.X)
            {
                Console.Clear();
                server = string.Empty;
                database = string.Empty;
                username = string.Empty;
                password = string.Empty;
                table = string.Empty;
                rootGenCaschost();
            }
            else if (choice == ConsoleKey.E)
            {
                Console.Clear();
                server = string.Empty;
                database = string.Empty;
                username = string.Empty;
                password = string.Empty;
                table = string.Empty;
                Main(new string[0]);
            }

        }

    }
}
