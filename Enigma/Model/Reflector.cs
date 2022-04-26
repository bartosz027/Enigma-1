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


        // Identifier
        private string _Name;

        // Wires simulation
        private string _Input;
        private string _Output;
    }

}