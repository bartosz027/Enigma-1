using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Model {

    class Rotor : ICloneable {
        public Rotor(string name, string input, string output, char turnover) {
            _Name = name;

            _Input = input;
            _Output = output;

            _KeyPosition = 0;
            _RingPosition = 0;

            _TurnoverPosition = turnover;
        }


        public void Move() {
            if (_KeyPosition < 25) {
                _KeyPosition++;
            }
            else {
                _KeyPosition = 0;
            }
        }


        public char ProcessSignal(char letter) {
            letter = (char)((int)letter + (_KeyPosition - _RingPosition));

            if (letter < 'A') {
                letter = (char)((int)letter + 26);
            }
            else if (letter > 'Z') {
                letter = (char)((int)letter - 26);
            }

            int index = _Input.IndexOf(letter);
            letter = _Output[index];

            letter = (char)((int)letter + (_RingPosition - _KeyPosition));

            if (letter < 'A') {
                letter = (char)((int)letter + 26);
            }
            else if (letter > 'Z') {
                letter = (char)((int)letter - 26);
            }

            return letter;
        }

        public char ProcessReversedSignal(char letter) {
            letter = (char)((int)letter + (_KeyPosition - _RingPosition));

            if (letter < 'A') {
                letter = (char)((int)letter + 26);
            }
            else if (letter > 'Z') {
                letter = (char)((int)letter - 26);
            }

            int index = _Output.IndexOf(letter);
            letter = _Input[index];

            letter = (char)((int)letter + (_RingPosition - _KeyPosition));

            if (letter < 'A') {
                letter = (char)((int)letter + 26);
            }
            else if (letter > 'Z') {
                letter = (char)((int)letter - 26);
            }

            return letter;
        }


        public string GetName() {
            return _Name;
        }

        public char GetTurnoverPosition() {
            return _TurnoverPosition;
        }


        public char GetKeyPosition() {
            return (char)(_KeyPosition + (int)'A');
        }

        public void SetKeyPosition(char position) {
            _KeyPosition = position - 'A';
        }


        public int GetRingPosition() {
            return _RingPosition + 1;
        }

        public void SetRingPosition(int position) {
            _RingPosition = position - 1;
        }


        public object Clone() {
            return MemberwiseClone();
        }


        // Identifier (unique string)
        private string _Name;

        // Encryption data (wires emulation)
        private string _Input;
        private string _Output;

        // Encryption data (allows to manipulate wires output)
        private int _KeyPosition;
        private int _RingPosition;

        // Encryption data (allows to set when adjacent rotor moves too)
        private char _TurnoverPosition;
    }

}