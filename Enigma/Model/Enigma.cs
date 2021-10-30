using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Model {

    class Enigma {
        public Enigma() {
            Plugboard = new Plugboard();

            AvailableRotors = new List<Rotor>() {
                new Rotor("I",   "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'R'),
                new Rotor("II",  "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "AJDKSIRUXBLHWTMCQGZNPYFVOE", 'F'),
                new Rotor("III", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 'W'),
                new Rotor("IV",  "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ESOVPZJAYQUIRHXLNFTGKDCMWB", 'K'),
                new Rotor("V",   "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "VZBRGITYUPSDNHLXAWMJQOFECK", 'A'),
            };
            AvailableReflectors = new List<Reflector>() {
                new Reflector("A", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "EJMZALYXVBWFCRQUONTSPIKHGD"),
                new Reflector("B", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "YRUHQSLDPXNGOKMIEBFZCWVJAT"),
                new Reflector("C", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "FVPJIAOYEDRZXWGCTKUQSBNMHL")
            };

            CurrentRotors = new List<Rotor>() { (Rotor)AvailableRotors[0].Clone(), (Rotor)AvailableRotors[0].Clone(), (Rotor)AvailableRotors[0].Clone() };
            CurrentReflector = AvailableReflectors[0];

            Decrypted = "";
        }


        public void SaveSettings(string filepath) {
            string settings = "";

            // Get plugboard settings
            string connections = Plugboard.GetConnectedPlugs();

            // Save plugboard settings
            settings += (connections != null) ? connections.Replace(" ", "") : "NULL";
            settings += ' ';

            // Save reflector settings
            settings += CurrentReflector.GetName();
            settings += ' ';

            foreach(var rotor in CurrentRotors) {
                settings += rotor.GetName();
                settings += ' ';

                settings += rotor.GetRingPosition();
                settings += ' ';
            }

            // Write to file
            Directory.CreateDirectory(Path.GetDirectoryName(filepath));
            File.WriteAllText(filepath, settings);
        }

        public void LoadSettings(string filepath) {
            foreach(var rotor in CurrentRotors) {
                rotor.ResetKey();
            }

            // Current settings
            string[] settings = File.ReadAllText(filepath).Split(" ");
            char[] keys = { CurrentRotors[0].GetKeyPosition(), CurrentRotors[1].GetKeyPosition(), CurrentRotors[2].GetKeyPosition() };

            // Reset plugboard settings
            Plugboard.Reset();

            // Load plugboard settings
            for(int i = 0; settings[0] != "NULL" && i < settings[0].Length; i += 2) {
                AddPlugboardConnection(settings[0].Substring(i, 2));
            }

            // Load reflector settings
            SetReflector(settings[1]);

            // Remove all rotors
            CurrentRotors.Clear();

            // Load rotors
            for(int i = 2; settings[i] != "" && i < settings.Length; i += 2) {
                var rotor = AvailableRotors.Find(p => (p.GetName() == settings[i]));

                var rotorClone = rotor.Clone() as Rotor;
                rotorClone.SetRingPosition(int.Parse(settings[i + 1]));

                CurrentRotors.Add(rotorClone);
            }

            for(int i = 0; i < CurrentRotors.Count; i++) {
                CurrentRotors[i].SetKeyPosition(keys[i]);
            }
        }


        public void AddPlugboardConnection(string data) {
            Plugboard.Connect(data);
        }

        public void RemovePlugboardConnection(string data) {
            Plugboard.Disconnect(data);
        }


        public void SetRotorName(int index, string name) {
            var rotor = AvailableRotors.Find(p => (p.GetName() == name)).Clone();

            char key = CurrentRotors[index].GetKeyPosition();
            int ring = CurrentRotors[index].GetRingPosition();

            CurrentRotors[index] = rotor as Rotor;
            CurrentRotors[index].SetKeyPosition(key);
            CurrentRotors[index].SetRingPosition(ring);
        }

        public void SetRotorKey(int index, char key) {
            CurrentRotors[index].SetKeyPosition(key);
        }

        public void SetRotorRing(int index, int ring) {
            CurrentRotors[index].SetRingPosition(ring);
        }


        public void SetReflector(string name) {
            CurrentReflector = AvailableReflectors.Find(p => (p.GetName() == name));
        }


        public void EncryptMessage(string message) {
            Decrypted = "";

            foreach(var rotor in CurrentRotors) {
                rotor.ResetKey();
            }

            foreach(var letter in message) {
                int size = CurrentRotors.Count;

                if (letter != ' ') {
                    CurrentRotors[size - 1].Move();

                    for(int i = size - 1; i > 0; i--) {
                        if(CurrentRotors[i].GetKeyPosition() == CurrentRotors[i].GetTurnoverPosition()) {
                            CurrentRotors[i - 1].Move();
                            continue;
                        }

                        break;
                    }

                    char decrypted_letter = Plugboard.ProcessSignal(letter);

                    for (int i = size - 1; i >= 0; i--) {
                        decrypted_letter = CurrentRotors[i].ProcessSignal(decrypted_letter);
                    }

                    decrypted_letter = CurrentReflector.ProcessSignal(decrypted_letter);

                    for (int i = 0; i < size; i++) {
                        decrypted_letter = CurrentRotors[i].ProcessReversedSignal(decrypted_letter);
                    }

                    decrypted_letter = Plugboard.ProcessSignal(decrypted_letter);
                    Decrypted += decrypted_letter;
                }
                else {
                    Decrypted += " ";
                }
            }
        }


        // Plugboard
        public Plugboard Plugboard { get; set; }

        // Available components
        public List<Rotor> AvailableRotors { get; set; }
        public List<Reflector> AvailableReflectors { get; set; }

        // Current components
        public List<Rotor> CurrentRotors { get; set; }
        public Reflector CurrentReflector { get; set; }

        // Message
        public string Decrypted { get; set; }
    }

}