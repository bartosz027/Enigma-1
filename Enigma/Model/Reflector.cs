using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Model {

    class Reflector {
        public Reflector(string name, string input, string output) {
            _Name = name;

            _Input = input;
            _Output = output;
        }


        public char ProcessSignal(char letter) {
            int index = _Input.IndexOf(letter);
            return _Output[index];
        }


        public string GetName() {
            return _Name;
        }


        // Identifier (unique string)
        private string _Name;

        // Encryption data (wires emulation)
        private string _Input;
        private string _Output;
    }

}