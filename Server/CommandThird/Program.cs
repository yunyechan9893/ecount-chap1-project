using System;

namespace CommandThird
{
    internal class Program
    { 
        public static bool isStarted = true;

        static void Main(string[] args)
        {
            MainView mainView = new MainView();
            mainView.Main();
        }
    }
}
