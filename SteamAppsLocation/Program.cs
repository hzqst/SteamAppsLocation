using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Indieteur.SAMAPI;

namespace Demo
{
    

    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SteamAppsManager SAM = new SteamAppsManager();

                if (args.Length >= 1)
                {
                    int appId = int.Parse(args[0]);

                    foreach (SteamApp sapp in SAM.SteamApps) //loop through all the apps and add them to the list box by using the ListBoxItem class.
                    {
                        if (sapp.AppID == appId)
                        {
                            if (args.Length >= 2)
                            {
                                string slot = args[1];
                                if (slot == "Name")
                                {
                                    System.Console.WriteLine(sapp.Name);
                                    return;
                                }
                                else if (slot == "ProcessName")
                                {
                                    System.Console.WriteLine(sapp.ProcessNameToFind);
                                    return;
                                }
                                else if (slot == "InstallDirName")
                                {
                                    System.Console.WriteLine(sapp.InstallDirName);
                                    return;
                                }
                                else if (slot == "InstallDir")
                                {
                                    System.Console.WriteLine(sapp.InstallDir);
                                    return;
                                }
                            }
                            System.Console.WriteLine("{0} \"{1}\" \"{2}\" \"{3}\" \"{4}\"", sapp.AppID, sapp.Name, sapp.ProcessNameToFind, sapp.InstallDirName, sapp.InstallDir);
                            return;
                        }
                    }
                }
                else
                {
                    foreach (SteamApp sapp in SAM.SteamApps) //loop through all the apps and add them to the list box by using the ListBoxItem class.
                    {
                        System.Console.WriteLine("{0} \"{1}\" \"{2}\" \"{3}\" \"{4}\"", sapp.AppID, sapp.Name, sapp.ProcessNameToFind, sapp.InstallDirName, sapp.InstallDir);
                    }
                }
            }
            catch (Exception ex)
            {
                NullReferenceException nullRefException = ex as NullReferenceException;  //The library will throw a null reference exception when it cannot find installation directory.
                if (nullRefException != null)
                {
                    MessageBox.Show("Steam installation folder was not found or is invalid! Please provide the path to the Steam installation folder.", "Steam App Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    throw ex; //For other errors, throw it back and show it to the user.
            }
        }
    }
}

