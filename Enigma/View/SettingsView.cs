using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Encryption.View.Controls;

namespace Encryption.View {

    class SettingsView : BasicView {
        public SettingsView() {
            // Main border
            ViewBorder = new Border(new Position(80, 0), new Size(38, 49));
            ViewBorder.Name = "SettingsViewBorder";

            ViewBorder.Coordinates.Add(new Position(1, 0));
            ViewBorder.Coordinates.Add(new Position(1, 1));

            // Main label
            var settingsViewLabel = new Label(new Position(95, 2));

            settingsViewLabel.Name = "SettingsViewLabel";
            settingsViewLabel.Content = "SETTINGS";

            Controls.Add(settingsViewLabel);


            // Add plugboard connection button
            var plugboardChangeConnectionsButton = new Button(new Position(80, 4), new Size(38, 3));

            plugboardChangeConnectionsButton.Name = "PlugboardChangeConnectionButton";
            plugboardChangeConnectionsButton.Content = "Plugboard - Add/Remove Connections";

            plugboardChangeConnectionsButton.Coordinates.Add(new Position(0, 0));
            Controls.Add(plugboardChangeConnectionsButton);


            // Rotor 1 - change type button
            var rotorChangeTypeButton1 = new Button(new Position(80, 8), new Size(38, 3));

            rotorChangeTypeButton1.Name = "RotorChangeTypeButton1";
            rotorChangeTypeButton1.Content = "Rotor 1 - Change Type";

            rotorChangeTypeButton1.Coordinates.Add(new Position(0, 1));
            Controls.Add(rotorChangeTypeButton1);

            // Rotor 1 - change ring button
            var rotorChangeRingButton1 = new Button(new Position(80, 10), new Size(38, 3));

            rotorChangeRingButton1.Name = "RotorChangeRingButton1";
            rotorChangeRingButton1.Content = "Rotor 1 - Change Ring";

            rotorChangeRingButton1.Coordinates.Add(new Position(0, 2));
            Controls.Add(rotorChangeRingButton1);


            // Rotor 2 - change type button
            var rotorChangeTypeButton2 = new Button(new Position(80, 14), new Size(38, 3));

            rotorChangeTypeButton2.Name = "RotorChangeTypeButton2";
            rotorChangeTypeButton2.Content = "Rotor 2 - Change Type";

            rotorChangeTypeButton2.Coordinates.Add(new Position(0, 3));
            Controls.Add(rotorChangeTypeButton2);

            // Rotor 2 - change ring button
            var rotorChangeRingButton2 = new Button(new Position(80, 16), new Size(38, 3));

            rotorChangeRingButton2.Name = "RotorChangeRingButton2";
            rotorChangeRingButton2.Content = "Rotor 2 - Change Ring";

            rotorChangeRingButton2.Coordinates.Add(new Position(0, 4));
            Controls.Add(rotorChangeRingButton2);


            // Rotor 3 - change type button
            var rotorChangeTypeButton3 = new Button(new Position(80, 20), new Size(38, 3));

            rotorChangeTypeButton3.Name = "RotorChangeTypeButton3";
            rotorChangeTypeButton3.Content = "Rotor 3 - Change Type";

            rotorChangeTypeButton3.Coordinates.Add(new Position(0, 5));
            Controls.Add(rotorChangeTypeButton3);

            // Rotor 3 - change ring button
            var rotorChangeRingButton3 = new Button(new Position(80, 22), new Size(38, 3));

            rotorChangeRingButton3.Name = "RotorChangeRingButton3";
            rotorChangeRingButton3.Content = "Rotor 3 - Change Ring";

            rotorChangeRingButton3.Coordinates.Add(new Position(0, 6));
            Controls.Add(rotorChangeRingButton3);


            // Change reflector type button
            var reflectorChangeType = new Button(new Position(80, 26), new Size(38, 3));

            reflectorChangeType.Name = "ReflectorChangeTypeButton";
            reflectorChangeType.Content = "Reflector - Change Type";

            reflectorChangeType.Coordinates.Add(new Position(0, 7));
            Controls.Add(reflectorChangeType);


            // Save settings button
            var saveSettingsButton = new Button(new Position(80, 30), new Size(38, 3));

            saveSettingsButton.Name = "SaveSettingsButton";
            saveSettingsButton.Content = "Save Settings";

            saveSettingsButton.Coordinates.Add(new Position(0, 8));
            Controls.Add(saveSettingsButton);

            // Load settings button
            var loadSettingsButton = new Button(new Position(80, 32), new Size(38, 3));

            loadSettingsButton.Name = "LoadSettingsButton";
            loadSettingsButton.Content = "Load Settings";

            loadSettingsButton.Coordinates.Add(new Position(0, 9));
            Controls.Add(loadSettingsButton);
        }
    }

}