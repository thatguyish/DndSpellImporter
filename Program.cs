using System;
namespace WebsiteInfoImporter
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool running = true;
            while (running) {
                Console.WriteLine("Hello");
                var desiredinfo = Importer.getUserin(); // "light";
                Importer.scrubdnd(Importer.websitecontent($"https://www.dndbeyond.com/spells/{desiredinfo}"), desiredinfo);

                Console.WriteLine("another?");
                if (Console.ReadLine()=="n")
                {
                    running = false;
                }

            }
    
        }
    } 
}
