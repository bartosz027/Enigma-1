using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Model {

    class Plugboard {
        public Plugboard() {
            _Input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            _Output = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }


        public void Connect(string data) {
            for(int i = 0; i < data.Length; i += 3) {
                string pair = data.Substring(i, 2);

                if(!IsConnected(pair)) {
                    int index1 = _Output.IndexOf(pair[0]);
                    int index2 = _Output.IndexOf(pair[1]);

                    var sb = new StringBuilder(_Output);
                    char temp = sb[index1];

                    sb[index1] = sb[index2];
                    sb[index2] = temp;

                    _Output = sb.ToString();
                }
            }
        }

        public void Disconnect(string data) {
            for (int i = 0; i < data.Length; i += 3) {
                string pair = data.Substring(i, 2);

                if (IsConnected(pair)) {
                    int index1 = _Output.IndexOf(pair[0]);
                    int index2 = _Output.IndexOf(pair[1]);

                    var sb = new StringBuilder(_Output);
                    char temp = sb[index1];

                    sb[index1] = sb[index2];
                    sb[index2] = temp;

                    _Output = sb.ToString();
                }
            }
        }

        public void Reset() {
            _Input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            _Output = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }


        public char ProcessSignal(char letter) {
            int index = _Input.IndexOf(letter);
            return _Output[index];
        }


        public string GetConnectedPlugs() {
            string plugs = null;

            for(int i = 0; i < 26;  i++) {
                char input = _Input[i];
                char output = _Output[i];

                if(input < output) {
                    plugs += input.ToString() + output.ToString() + " ";
                }
            }

            return plugs;
        }


        private bool IsConnected(string pair) {
            int input_index1 = _Input.IndexOf(pair[0]);
            int input_index2 = _Input.IndexOf(pair[1]);

            int output_index1 = _Output.IndexOf(pair[0]);
            int output_index2 = _Output.IndexOf(pair[1]);

            if(input_index1 == output_index2 && input_index2 == output_index1) {
                return true;
            }
            else if (input_index1 != output_index1 || input_index2 != output_index2) {
                return true;
            }
            else {
                return false;
            }
        }


        // Encryption data (wires emulation)
        private string _Input;
        private string _Output;
    }

}