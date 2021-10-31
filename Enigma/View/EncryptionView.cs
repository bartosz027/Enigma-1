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

            // Encrypion button
            var encryptionButton = new Button(new Position(8, 34), new Size(64, 3));

            encryptionButton.Name = "EncryptionButton";
            encryptionButton.Content = "Encrypt / Decrypt";

            encryptionButton.Coordinates.Add(new Position(0, 1));
            encryptionButton.Coordinates.Add(new Position(1, 1));

            Controls.Add(encryptionButton);
        }
    }

}