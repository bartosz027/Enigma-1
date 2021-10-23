using System;

using Encryption.View;
using Encryption.View.Controls;

using Encryption.Model;

namespace Encryption.Controller {

    class SettingsViewController : BasicController {
        public SettingsViewController(Enigma enigma, SettingsView view) : base(view) {
            _Enigma = enigma;

            // Controller callbacks
            SetCallback("PlugboardChangeConnectionButton", PlugboardChangeConnectionButton_OnClick);

            SetCallback("RotorChangeTypeButton1", RotorChangeTypeButton_OnClick);
            SetCallback("RotorChangeTypeButton2", RotorChangeTypeButton_OnClick);
            SetCallback("RotorChangeTypeButton3", RotorChangeTypeButton_OnClick);

            SetCallback("RotorChangeRingButton1", RotorChangeRingButton_OnClick);
            SetCallback("RotorChangeRingButton2", RotorChangeRingButton_OnClick);
            SetCallback("RotorChangeRingButton3", RotorChangeRingButton_OnClick);

            SetCallback("ReflectorChangeTypeButton", ReflectorChangeTypeButton_OnClick);

            SetCallback("SaveSettingsButton", SaveSettingsButton_OnClick);
            SetCallback("LoadSettingsButton", LoadSettingsButton_OnClick);
        }


        // Event => SettingsChanged (allows to update InformationView)
        public event EventHandler<EventArgs> SettingsChanged;

        private void OnSettingsChanged() {
            SettingsChanged?.Invoke(this, EventArgs.Empty);
        }


        // Callback methods
        private void PlugboardChangeConnectionButton_OnClick(object sender, EventArgs args) {
            var current_control = _View.Controls.Find(p => (p.Selected == true));

            // Create temporary view
            var view = new BasicView();

            view.ViewBorder = new Border(new Position(122, 6), new Size(49, 13));
            view.ViewBorder.Name = "PlugboardChangeConnectionViewBorder";

            var plugboardChangeConnectionLabel = new Label(new Position(134, 8)) {
                Name = "PlugboardChangeConnectionLabel",
                Content = "Plugboard Change Connection"
            };

            view.Controls.Add(plugboardChangeConnectionLabel);

            // TextBox
            var plugboardChangeConnectionTextBox = new TextBox(new Position(126, 10), new Size(41, 3));

            plugboardChangeConnectionTextBox.Name = "PlugboardChangeConnectionTextBox";
            plugboardChangeConnectionTextBox.Coordinates.Add(new Position(0, 0));

            view.Controls.Add(plugboardChangeConnectionTextBox);

            // Add button
            var plugboardAddConnectionButton = new Button(new Position(126, 14), new Size(18, 3)) {
                Name = "PlugboardAddConnectionButton",
                Content = "Add"
            };

            plugboardAddConnectionButton.SetCallback(new EventHandler((obj, arg) => {
                var textBox = view.GetControl("PlugboardChangeConnectionTextBox") as TextBox;
                // TODO: ERROR HANDLING

                // Model update
                _Enigma.AddPlugboardConnection(textBox.Text);

                // View update
                OnSettingsChanged();
            }));

            plugboardAddConnectionButton.Coordinates.Add(new Position(0, 1));
            view.Controls.Add(plugboardAddConnectionButton);

            // Remove button
            var plugboardRemoveConnectionButton = new Button(new Position(149, 14), new Size(18, 3)) {
                Name = "PlugboardAddConnectionButton",
                Content = "Remove"
            };

            plugboardRemoveConnectionButton.SetCallback(new EventHandler((obj, arg) => {
                var textBox = view.GetControl("PlugboardChangeConnectionTextBox") as TextBox;
                // TODO: ERROR HANDLING

                // Model update
                _Enigma.RemovePlugboardConnection(textBox.Text);

                // View update
                OnSettingsChanged();
            }));

            plugboardRemoveConnectionButton.Coordinates.Add(new Position(1, 1));
            view.Controls.Add(plugboardRemoveConnectionButton);

            // Change control color
            current_control.SelectedColor = ConsoleColor.DarkCyan;
            current_control.OnUpdate();

            // Show view
            view.OnUpdate();
            view.OnClick();

            // Delete view
            view.Clear();

            // Change control color
            current_control.SelectedColor = ConsoleColor.DarkBlue;
            current_control.OnUpdate();
        }


        private void RotorChangeTypeButton_OnClick(object sender, EventArgs args) {
            var current_control = _View.Controls.Find(p => (p.Selected == true));

            // Callback
            EventHandler button_on_click = new EventHandler((obj, arg) => {
                int index = 0;

                switch ((sender as Button).Name) {
                    case "RotorChangeTypeButton1": {
                        index = 0;
                        break;
                    }
                    case "RotorChangeTypeButton2": {
                        index = 1;
                        break;
                    }
                    case "RotorChangeTypeButton3": {
                        index = 2;
                        break;
                    }
                }

                // Model update
                var button = obj as Button;
                _Enigma.SetRotorName(index, button.Content);

                // View update
                OnSettingsChanged();
            });

            // Create temporary view
            var view = new BasicView();
            var rotors = _Enigma.AvailableRotors;

            view.ViewBorder = new Border(new Position(134, 6), new Size(25, 33));
            view.ViewBorder.Name = "RotorChangeTypeViewBorder";

            var selectRotorLabel = new Label(new Position(138, 7)) {
                Name = "SelectRotorLabel",
                Content = "Select Rotor Type"
            };

            view.Controls.Add(selectRotorLabel);

            for (int i = 0; i < rotors.Count; i++) {
                var button = new Button(new Position(134, 9 + (2 * i)), new Size(25, 3));

                button.Name = "RotorChangeTypeButton" + i;
                button.Content = rotors[i].GetName();

                button.Coordinates.Add(new Position(0, i));

                button.SetCallback(button_on_click);
                view.Controls.Add(button);
            }

            // Change control color
            current_control.SelectedColor = ConsoleColor.DarkCyan;
            current_control.OnUpdate();

            // Show view
            view.OnUpdate();
            view.OnClick();

            // Delete view
            view.Clear();

            // Change control color
            current_control.SelectedColor = ConsoleColor.DarkBlue;
            current_control.OnUpdate();
        }

        private void RotorChangeRingButton_OnClick(object sender, EventArgs args) {
            var current_control = _View.Controls.Find(p => (p.Selected == true));

            // Callback
            EventHandler button_on_click = new EventHandler((obj, arg) => {
                var button = obj as Button;
                int index = 0;

                switch ((sender as Button).Name) {
                    case "RotorChangeRingButton1": {
                        index = 0;
                        break;
                    }
                    case "RotorChangeRingButton2": {
                        index = 1;
                        break;
                    }
                    case "RotorChangeRingButton3": {
                        index = 2;
                        break;
                    }
                }

                // Model update
                var ring = button.Name.Remove(0, ("RotorChangeRingButton").Length);
                _Enigma.SetRotorRing(index, int.Parse(ring) + 1);

                // View update
                OnSettingsChanged();
            });

            // Create temporary view
            var view = new BasicView();

            view.ViewBorder = new Border(new Position(121, 6), new Size(52, 33));
            view.ViewBorder.Name = "RotorChangeRingViewBorder";

            var selectRotorRingLabel = new Label(new Position(138, 7)) {
                Name = "SelectRotorRingLabel",
                Content = "Select Rotor Ring"
            };

            view.Controls.Add(selectRotorRingLabel);

            for (int i = 0; i < 13; i++) {
                var button = new Button(new Position(121, 9 + (2 * i)), new Size(25, 3));

                button.Name = "RotorChangeRingButton" + i;
                button.Content = (i + 1) + " [" + (char)((int)'A' + i) + "]";

                button.Coordinates.Add(new Position(0, i));

                button.SetCallback(button_on_click);
                view.Controls.Add(button);
            }

            for (int i = 0; i < 13; i++) {
                var button = new Button(new Position(148, 9 + (2 * i)), new Size(25, 3));

                button.Name = "RotorChangeRingButton" + (i + 13);
                button.Content = (i + 14) + " [" + (char)((int)'A' + (i + 13)) + "]";

                button.Coordinates.Add(new Position(1, i));

                button.SetCallback(button_on_click);
                view.Controls.Add(button);
            }

            // Change control color
            current_control.SelectedColor = ConsoleColor.DarkCyan;
            current_control.OnUpdate();

            // Show view
            view.OnUpdate();
            view.OnClick();

            // Delete view
            view.Clear();

            // Change control color
            current_control.SelectedColor = ConsoleColor.DarkBlue;
            current_control.OnUpdate();
        }


        private void ReflectorChangeTypeButton_OnClick(object sender, EventArgs args) {
            var current_control = _View.Controls.Find(p => (p.Selected == true));

            // Callback
            EventHandler button_on_click = new EventHandler((obj, arg) => {
                var button = obj as Button;

                // Model update
                _Enigma.SetReflector(button.Content);

                // View update
                OnSettingsChanged();
            });

            // Create temporary view
            var view = new BasicView();
            var reflectors = _Enigma.AvailableReflectors;

            view.ViewBorder = new Border(new Position(134, 6), new Size(25, 33));
            view.ViewBorder.Name = "ReflectorChangeTypeViewBorder";

            var selectReflectorTypeLabel = new Label(new Position(136, 7)) {
                Name = "SelectReflectorTypeLabel",
                Content = "Select Reflector Type"
            };

            view.Controls.Add(selectReflectorTypeLabel);

            for (int i = 0; i < reflectors.Count; i++) {
                var button = new Button(new Position(134, 9 + (2 * i)), new Size(25, 3));

                button.Name = "ReflectorChangeTypeButton" + i;
                button.Content = reflectors[i].GetName();

                button.Coordinates.Add(new Position(0, i));

                button.SetCallback(button_on_click);
                view.Controls.Add(button);
            }

            // Change control color
            current_control.SelectedColor = ConsoleColor.DarkCyan;
            current_control.OnUpdate();

            // Show view
            view.OnUpdate();
            view.OnClick();

            // Delete view
            view.Clear();

            // Change control color
            current_control.SelectedColor = ConsoleColor.DarkBlue;
            current_control.OnUpdate();
        }


        private void SaveSettingsButton_OnClick(object sender, EventArgs e) {
            throw new NotImplementedException(); // TODO: IMPLEMENT THIS
        }

        private void LoadSettingsButton_OnClick(object sender, EventArgs e) {
            throw new NotImplementedException(); // TODO: IMPLEMENT THIS
        }


        // Model variable
        private Enigma _Enigma;
    }

}