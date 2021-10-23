using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Encryption.View;
using Encryption.View.Controls;

using Encryption.Model;

namespace Encryption.Controller {

    class RotorViewController : BasicController {
        public RotorViewController(Enigma enigma, RotorView view) : base(view) {
            _Enigma = enigma;

            // Controller callbacks
            SetCallback("RotorKeyUpButton1", RotorKeyUpButton_OnClick);
            SetCallback("RotorKeyUpButton2", RotorKeyUpButton_OnClick);
            SetCallback("RotorKeyUpButton3", RotorKeyUpButton_OnClick);

            SetCallback("RotorKeyDownButton1", RotorKeyDownButton_OnClick);
            SetCallback("RotorKeyDownButton2", RotorKeyDownButton_OnClick);
            SetCallback("RotorKeyDownButton3", RotorKeyDownButton_OnClick);
        }

        // Callback methods
        private void RotorKeyUpButton_OnClick(object sender, EventArgs args) {
            var buttonID = (sender as Button).Name;

            Label control = null;
            int index = 0;

            switch (buttonID) {
                case "RotorKeyUpButton1": {
                    control = _View.GetControl("RotorKeyLabel1") as Label;
                    index = 0;
                    break;
                }
                case "RotorKeyUpButton2": {
                    control = _View.GetControl("RotorKeyLabel2") as Label;
                    index = 1;
                    break;
                }
                case "RotorKeyUpButton3": {
                    control = _View.GetControl("RotorKeyLabel3") as Label;
                    index = 2;
                    break;
                }
            }

            char letter = control.Content[0];
            letter = (letter != 'Z') ? (char)(letter + 1) : 'A';

            // Model update
            _Enigma.SetRotorKey(index, letter);

            // View update
            control.Content = letter.ToString();
        }

        private void RotorKeyDownButton_OnClick(object sender, EventArgs args) {
            var buttonID = (sender as Button).Name;

            Label control = null;
            int index = 0;

            switch (buttonID) {
                case "RotorKeyDownButton1": {
                    control = _View.GetControl("RotorKeyLabel1") as Label;
                    index = 0;
                    break;
                }
                case "RotorKeyDownButton2": {
                    control = _View.GetControl("RotorKeyLabel2") as Label;
                    index = 1;
                    break;
                }
                case "RotorKeyDownButton3": {
                    control = _View.GetControl("RotorKeyLabel3") as Label;
                    index = 2;
                    break;
                }
            }

            char letter = control.Content[0];
            letter = (letter != 'A') ? (char)(letter - 1) : 'Z';

            // Model update
            _Enigma.SetRotorKey(index, letter);

            // View update
            control.Content = letter.ToString();
        }

        // Model variable
        private Enigma _Enigma;
    }

}