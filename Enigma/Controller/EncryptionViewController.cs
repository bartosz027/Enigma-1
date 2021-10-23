using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Encryption.View;
using Encryption.View.Controls;

using Encryption.Model;

namespace Encryption.Controller {

    class EncryptionViewController : BasicController {
        public EncryptionViewController(Enigma enigma, EncryptionView view) : base(view) {
            _Enigma = enigma;

            // Controller callbacks
            SetCallback("EncryptionButton", EncryptionButton_OnClick);
        }

        // Callback methods
        private void EncryptionButton_OnClick(object sender, EventArgs args) {
            var encryptionInputTextBox = _View.GetControl("EncryptionInputTextBox") as TextBox;
            _Enigma.EncryptMessage(encryptionInputTextBox.Text);

            var encryptionOutputTextBox = _View.GetControl("EncryptionOutputTextBox") as TextBox;
            encryptionOutputTextBox.Text = _Enigma.Decrypted; // TODO: FIX ENCRYPTION
        }

        // Model variable
        private Enigma _Enigma;
    }

}