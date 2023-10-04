using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jan_FarmerGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Info info = new Info();
            info.DisplayInfo();
            FarmerUI ui = new FarmerUI();
            ui.PlayGame();
            Console.ReadKey();
        }
    }
}
