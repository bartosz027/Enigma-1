using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption {

    class Application {
        static void Main(string[] args) {
            var window = new Window();

            try {
                window.Run();
            }
            catch (Exception e) {
                Console.Clear();
                Console.WriteLine(e.StackTrace);
            }
        }
    }

}