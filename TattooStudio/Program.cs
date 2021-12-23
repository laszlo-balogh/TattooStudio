using System;
using TattooStudio.Client;

namespace TattooStudio
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService restService = new RestService("http://localhost:31552/");
            Menu m = new Menu(restService);
            try
            {
                m.Start();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
