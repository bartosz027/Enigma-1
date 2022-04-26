using Encryption.View.Controls;

namespace Encryption.View {

    class SettingsView : BasicView {
        public SettingsView() {
            // Border
            ViewBorder = new Border(new Position(80, 0), new Size(38, 49));
            ViewBorder.Name = "SettingsViewBorder";

            ViewBorder.Coordinates.Add(new Position(1, 0));
            ViewBorder.Coordinates.Add(new Position(1, 1));

            // Label - main
            var settingsViewLabel = new Label(new Position(95, 2));

            settingsViewLabel.Name = "SettingsViewLabel";
            settingsViewLabel.Content = "SETTINGS";

            Controls.Add(settingsViewLabel);

            // Button - change plugboard connections
            var plugboardChangeConnectionsButton = new Button(new Position(80, 4), new Size(38, 3));

            plugboardChangeConnectionsButton.Name = "PlugboardChangeConnectionButton";
            plugboardChangeConnectionsButton.Content = "Plugboard - Add/Remove Connections";

            plugboardChangeConnectionsButton.Coordinates.Add(new Position(0, 0));
            Controls.Add(plugboardChangeConnectionsButton);

            // Button - change rotor type 1
            var rotorChangeTypeButton1 = new Button(new Position(80, 8), new Size(38, 3));

            rotorChangeTypeButton1.Name = "RotorChangeTypeButton1";
            rotorChangeTypeButton1.Content = "Rotor 1 - Change Type";

            rotorChangeTypeButton1.Coordinates.Add(new Position(0, 1));
            Controls.Add(rotorChangeTypeButton1);

            // Button - change rotor ring 1
            var rotorChangeRingButton1 = new Button(new Position(80, 10), new Size(38, 3));

            rotorChangeRingButton1.Name = "RotorChangeRingButton1";
            rotorChangeRingButton1.Content = "Rotor 1 - Change Ring";

            rotorChangeRingButton1.Coordinates.Add(new Position(0, 2));
            Controls.Add(rotorChangeRingButton1);

            // Button - change rotor type 2
            var rotorChangeTypeButton2 = new Button(new Position(80, 14), new Size(38, 3));

            rotorChangeTypeButton2.Name = "RotorChangeTypeButton2";
            rotorChangeTypeButton2.Content = "Rotor 2 - Change Type";

            rotorChangeTypeButton2.Coordinates.Add(new Position(0, 3));
            Controls.Add(rotorChangeTypeButton2);

            // Button - change rotor ring 2
            var rotorChangeRingButton2 = new Button(new Position(80, 16), new Size(38, 3));

            rotorChangeRingButton2.Name = "RotorChangeRingButton2";
            rotorChangeRingButton2.Content = "Rotor 2 - Change Ring";

            rotorChangeRingButton2.Coordinates.Add(new Position(0, 4));
            Controls.Add(rotorChangeRingButton2);

            // Button - change rotor type 3
            var rotorChangeTypeButton3 = new Button(new Position(80, 20), new Size(38, 3));

            rotorChangeTypeButton3.Name = "RotorChangeTypeButton3";
            rotorChangeTypeButton3.Content = "Rotor 3 - Change Type";

            rotorChangeTypeButton3.Coordinates.Add(new Position(0, 5));
            Controls.Add(rotorChangeTypeButton3);

            // Button - change rotor ring 3
            var rotorChangeRingButton3 = new Button(new Position(80, 22), new Size(38, 3));

            rotorChangeRingButton3.Name = "RotorChangeRingButton3";
            rotorChangeRingButton3.Content = "Rotor 3 - Change Ring";

            rotorChangeRingButton3.Coordinates.Add(new Position(0, 6));
            Controls.Add(rotorChangeRingButton3);

            // Button - change reflector type
            var reflectorChangeType = new Button(new Position(80, 26), new Size(38, 3));

            reflectorChangeType.Name = "ReflectorChangeTypeButton";
            reflectorChangeType.Content = "Reflector - Change Type";

            reflectorChangeType.Coordinates.Add(new Position(0, 7));
            Controls.Add(reflectorChangeType);

            // Button - save settings
            var saveSettingsButton = new Button(new Position(80, 30), new Size(38, 3));

            saveSettingsButton.Name = "SaveSettingsButton";
            saveSettingsButton.Content = "Save Settings";

            saveSettingsButton.Coordinates.Add(new Position(0, 8));
            Controls.Add(saveSettingsButton);

            // Button - load settings
            var loadSettingsButton = new Button(new Position(80, 32), new Size(38, 3));

            loadSettingsButton.Name = "LoadSettingsButton";
            loadSettingsButton.Content = "Load Settings";

            loadSettingsButton.Coordinates.Add(new Position(0, 9));
            Controls.Add(loadSettingsButton);
        }
    }

}