using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Encryption.View.Controls;

namespace Encryption.View {

    class EncryptionView : BasicView {
        public EncryptionView() {
            // Main border
            ViewBorder = new Border(new Position(0, 15), new Size(80, 24));
            ViewBorder.Name = "EncryptionViewBorder";

            ViewBorder.Coordinates.Add(new Position(0, 1));

            // Input label
            var encryptionInputLabel = new Label(new Position(19, 17));

            encryptionInputLabel.Name = "EncryptionInputLabel";
            encryptionInputLabel.Content = "Input";

            Controls.Add(encryptionInputLabel);

            // Input textbox
            var encryptionInputTextBox = new TextBox(new Position(5, 18), new Size(33, 15));

            encryptionInputTextBox.Name = "EncryptionInputTextBox";
            encryptionInputTextBox.Coordinates.Add(new Position(0, 0));

            Controls.Add(encryptionInputTextBox);

            // Output label
            var encryptionOutputLabel = new Label(new Position(55, 17));

            encryptionOutputLabel.Name = "EncryptionOutputLabel";
            encryptionOutputLabel.Content = "Output";

            Controls.Add(encryptionOutputLabel);

            // Output textbox
            var encryptionOutputTextBox = new TextBox(new Position(42, 18), new Size(33, 15));

            encryptionOutputTextBox.Name = "EncryptionOutputTextBox";
            encryptionOutputTextBox.ReadOnly = true;

            Controls.Add(encryptionOutputTextBox);

            // Encrypion button [from TextBox]
            var encryptionButton1 = new Button(new Position(5, 34), new Size(33, 3));

            encryptionButton1.Name = "EncryptionButton1";
            encryptionButton1.Content = "Encrypt from TextBox";

            encryptionButton1.Coordinates.Add(new Position(0, 1));
            Controls.Add(encryptionButton1);

            // Encrypion button [from File]
            var encryptionButton2 = new Button(new Position(42, 34), new Size(33, 3));

            encryptionButton2.Name = "EncryptionButton2";
            encryptionButton2.Content = "Encrypt from File";

            encryptionButton2.Coordinates.Add(new Position(1, 1));
            Controls.Add(encryptionButton2);
        }
    }

}