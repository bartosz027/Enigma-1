using System;
using System.IO;

using Encryption.View;
using Encryption.View.Controls;

using Encryption.Model;

namespace Encryption.Controller {

    class EncryptionViewController : BasicController {
        public EncryptionViewController(Enigma enigma, EncryptionView view) : base(view) {
            _Enigma = enigma;

            // Controls callbacks
            SetCallback("EncryptionButton1", EncryptionButton1_OnClick);
            SetCallback("EncryptionButton2", EncryptionButton2_OnClick);
        }


        // Callback methods
        private void EncryptionButton1_OnClick(object sender, EventArgs args) {
            var encryptionInputTextBox = _View.GetControl("EncryptionInputTextBox") as TextBox;
            _Enigma.EncryptMessage(encryptionInputTextBox.Text);

            var encryptionOutputTextBox = _View.GetControl("EncryptionOutputTextBox") as TextBox;
            encryptionOutputTextBox.Text = "";

            encryptionOutputTextBox.Text = _Enigma.Decrypted;
        }

        private void EncryptionButton2_OnClick(object sender, EventArgs args) {
            var current_control = _View.Controls.Find(p => (p.Selected == true));

            // Main label
            var fileLabel = new Label(new Position(134, 7)) {
                Name = "FileLabel",
                Content = "Drag and drop file [.txt]"
            };

            // Drag and drop control
            var fileDragDrop = new DragDrop(new Position(126, 8), new Size(41, 27)) {
                Name = "FileDragDrop",
                Selected = true
            };

            // Message label - 1
            var fileMessageLabel1 = new Label(new Position(122, 36)) {
                Name = "FileMessageLabel1",
                FontColor = ConsoleColor.Green
            };

            // Message label - 2
            var fileMessageLabel2 = new Label(new Position(122, 37)) {
                Name = "FileMessageLabel2",
                FontColor = ConsoleColor.Green
            };

            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkCyan;
            current_control.OnUpdate();

            // Show controls
            fileLabel.OnUpdate();
            fileDragDrop.OnUpdate();

            // Wait for input (drag and drop txt file)
            fileDragDrop.OnClick();

            // Encrypt file
            if(fileDragDrop.Filepath != "") {
                string text = File.ReadAllText(fileDragDrop.Filepath);
                string processed_text = "";

                foreach(var letter in text) {
                    if((letter >= 'A' && letter <= 'Z') || letter == ' ') {
                        processed_text += letter;
                    }
                    else if (letter >= 'a' && letter <= 'z') {
                        processed_text += Char.ToUpper(letter);
                    }
                }

                _Enigma.EncryptMessage(processed_text);

                string directory = Path.GetDirectoryName(fileDragDrop.Filepath);
                string filename  = Path.GetFileNameWithoutExtension(fileDragDrop.Filepath) + "_" + "decrypted.txt";

                string path = directory + "\\" + filename;
                File.WriteAllText(path, _Enigma.Decrypted);

                // Show message
                ConsoleKeyInfo consoleKeyInfo;

                fileMessageLabel1.Content = "Saved as: " + filename;
                fileMessageLabel2.Content = "Press ENTER to continue...";

                do {
                    consoleKeyInfo = Console.ReadKey(true);
                } while (consoleKeyInfo.Key != ConsoleKey.Enter);
            }

            // Delete controls
            fileLabel.OnDelete();
            fileDragDrop.OnDelete();

            fileMessageLabel1.OnDelete();
            fileMessageLabel2.OnDelete();

            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkBlue;
            current_control.OnUpdate();
        }


        // Model variable
        private Enigma _Enigma;
    }

}