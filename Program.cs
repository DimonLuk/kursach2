using System;
using System.Collections.Generic;
using Gtk;
using KursachAttemp2.Models;

namespace KursachAttemp2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
