using System;
using System.IO;

using Encryption.View;
using Encryption.View.Controls;

using Encryption.Model;

namespace Encryption.Controller {

    class SettingsViewController : BasicController {
        public SettingsViewController(Enigma enigma, SettingsView view) : base(view) {
            _Enigma = enigma;

            // Controls callbacks
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

            // Main border
            view.ViewBorder = new Border(new Position(122, 6), new Size(49, 16));
            view.ViewBorder.Name = "PlugboardChangeConnectionViewBorder";

            // Main label
            var plugboardChangeConnectionLabel = new Label(new Position(134, 8)) {
                Name = "PlugboardChangeConnectionLabel",
                Content = "Plugboard Change Connection"
            };

            view.Controls.Add(plugboardChangeConnectionLabel);


            // Plugboard change connection textbox
            var plugboardChangeConnectionTextBox = new TextBox(new Position(126, 10), new Size(41, 3));
            plugboardChangeConnectionTextBox.Name = "PlugboardChangeConnectionTextBox";

            plugboardChangeConnectionTextBox.Coordinates.Add(new Position(0, 0));
            plugboardChangeConnectionTextBox.Coordinates.Add(new Position(1, 0));

            view.Controls.Add(plugboardChangeConnectionTextBox);


            // Plugboard change connection message label - 1
            var plugboardChangeConnectionMessageLabel1 = new Label(new Position(126, 18));

            plugboardChangeConnectionMessageLabel1.Name = "PlugboardChangeConnectionMessageLabel1";
            plugboardChangeConnectionMessageLabel1.Content = "";

            view.Controls.Add(plugboardChangeConnectionMessageLabel1);

            // Plugboard change connection message label - 2
            var plugboardChangeConnectionMessageLabel2 = new Label(new Position(126, 19));

            plugboardChangeConnectionMessageLabel2.Name = "PlugboardChangeConnectionMessageLabel2";
            plugboardChangeConnectionMessageLabel2.Content = "";

            view.Controls.Add(plugboardChangeConnectionMessageLabel2);


            // Button callback
            var button_on_click = new EventHandler((obj, arg) => {
                var textBox = view.GetControl("PlugboardChangeConnectionTextBox") as TextBox;
                bool incorrectFormat = false;

                if (textBox.Text.Length == 0 || textBox.Text.Length == 1) {
                    incorrectFormat = true;
                }

                for (int i = 0; i < textBox.Text.Length; i++) {
                    if (i % 3 == 0 || i % 3 == 1) {
                        if (textBox.Text[i] == ' ') {
                            incorrectFormat = true;
                            break;
                        }
                    }
                    else {
                        if (textBox.Text[i] != ' ') {
                            incorrectFormat = true;
                            break;
                        }
                    }
                }

                if (!incorrectFormat) {
                    plugboardChangeConnectionMessageLabel1.FontColor = ConsoleColor.Green;
                    plugboardChangeConnectionMessageLabel1.Content = "Configuration changed successfully!";

                    plugboardChangeConnectionMessageLabel2.FontColor = ConsoleColor.Green;
                    plugboardChangeConnectionMessageLabel2.Content = "Press ESC button to exit!";
                }
                else {
                    plugboardChangeConnectionMessageLabel1.FontColor = ConsoleColor.Red;
                    plugboardChangeConnectionMessageLabel1.Content = "Incorrect format! Example: \"AB CD EF GH\"";

                    plugboardChangeConnectionMessageLabel2.FontColor = ConsoleColor.Red;
                    plugboardChangeConnectionMessageLabel2.Content = "Try again or press ESC button to exit!";

                    return;
                }

                // Model update
                var button = obj as Button;

                if(button.Name == "PlugboardAddConnectionButton") {
                    _Enigma.AddPlugboardConnection(textBox.Text);
                }
                else if (button.Name == "PlugboardRemoveConnectionButton") {
                    _Enigma.RemovePlugboardConnection(textBox.Text);
                }

                // View update
                OnSettingsChanged();
            });


            // Plugboard add connection button
            var plugboardAddConnectionButton = new Button(new Position(126, 14), new Size(18, 3)) {
                Name = "PlugboardAddConnectionButton",
                Content = "Add"
            };

            plugboardAddConnectionButton.Coordinates.Add(new Position(0, 1));
            plugboardAddConnectionButton.SetCallback(button_on_click);

            view.Controls.Add(plugboardAddConnectionButton);

            // Plugboard remove connection button
            var plugboardRemoveConnectionButton = new Button(new Position(149, 14), new Size(18, 3)) {
                Name = "PlugboardRemoveConnectionButton",
                Content = "Remove"
            };

            plugboardRemoveConnectionButton.Coordinates.Add(new Position(1, 1));
            plugboardRemoveConnectionButton.SetCallback(button_on_click);

            view.Controls.Add(plugboardRemoveConnectionButton);


            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkCyan;
            current_control.OnUpdate();

            // Show view
            view.OnUpdate();
            view.OnClick();

            // Delete view
            view.Clear();

            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkBlue;
            current_control.OnUpdate();
        }


        private void RotorChangeTypeButton_OnClick(object sender, EventArgs args) {
            var current_control = _View.Controls.Find(p => (p.Selected == true));
            var rotors = _Enigma.AvailableRotors;

            // Create temporary view
            var view = new BasicView();
            view.ExitViewOnEnterKeyPress = true;

            // Main border
            view.ViewBorder = new Border(new Position(134, 6), new Size(25, 33));
            view.ViewBorder.Name = "RotorChangeTypeViewBorder";

            // Main label
            var selectRotorLabel = new Label(new Position(138, 7)) {
                Name = "SelectRotorLabel",
                Content = "Select Rotor Type"
            };

            view.Controls.Add(selectRotorLabel);


            // Rotor change type buttons
            for (int i = 0; i < rotors.Count; i++) {
                var button = new Button(new Position(134, 9 + (2 * i)), new Size(25, 3));
                button.Name = "RotorChangeTypeButton" + i;

                button.Content = rotors[i].GetName();
                button.Coordinates.Add(new Position(0, i));

                button.SetCallback(new EventHandler((obj, arg) => {
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
                }));

                view.Controls.Add(button);
            }


            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkCyan;
            current_control.OnUpdate();

            // Show view
            view.OnUpdate();
            view.OnClick();

            // Delete view
            view.Clear();

            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkBlue;
            current_control.OnUpdate();
        }

        private void RotorChangeRingButton_OnClick(object sender, EventArgs args) {
            var current_control = _View.Controls.Find(p => (p.Selected == true));

            // Button callback
            var button_on_click = new EventHandler((obj, arg) => {
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
            view.ExitViewOnEnterKeyPress = true;

            // Main border
            view.ViewBorder = new Border(new Position(121, 6), new Size(52, 33));
            view.ViewBorder.Name = "RotorChangeRingViewBorder";

            // Main label
            var selectRotorRingLabel = new Label(new Position(138, 7)) {
                Name = "SelectRotorRingLabel",
                Content = "Select Rotor Ring"
            };

            view.Controls.Add(selectRotorRingLabel);


            // Rotor change ring buttons
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


            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkCyan;
            current_control.OnUpdate();

            // Show view
            view.OnUpdate();
            view.OnClick();

            // Delete view
            view.Clear();

            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkBlue;
            current_control.OnUpdate();
        }


        private void ReflectorChangeTypeButton_OnClick(object sender, EventArgs args) {
            var current_control = _View.Controls.Find(p => (p.Selected == true));
            var reflectors = _Enigma.AvailableReflectors;

            // Create temporary view
            var view = new BasicView();
            view.ExitViewOnEnterKeyPress = true;

            // Main border
            view.ViewBorder = new Border(new Position(134, 6), new Size(25, 33));
            view.ViewBorder.Name = "ReflectorChangeTypeViewBorder";

            // Main label
            var selectReflectorTypeLabel = new Label(new Position(136, 7)) {
                Name = "SelectReflectorTypeLabel",
                Content = "Select Reflector Type"
            };

            view.Controls.Add(selectReflectorTypeLabel);


            // Reflector change type buttons
            for (int i = 0; i < reflectors.Count; i++) {
                var button = new Button(new Position(134, 9 + (2 * i)), new Size(25, 3));
                button.Name = "ReflectorChangeTypeButton" + i;

                button.Content = reflectors[i].GetName();
                button.Coordinates.Add(new Position(0, i));

                button.SetCallback(new EventHandler((obj, arg) => {
                    var button = obj as Button;

                    // Model update
                    _Enigma.SetReflector(button.Content);

                    // View update
                    OnSettingsChanged();
                }));

                view.Controls.Add(button);
            }


            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkCyan;
            current_control.OnUpdate();

            // Show view
            view.OnUpdate();
            view.OnClick();

            // Delete view
            view.Clear();

            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkBlue;
            current_control.OnUpdate();
        }


        private void SaveSettingsButton_OnClick(object sender, EventArgs e) {
            var current_control = _View.Controls.Find(p => (p.Selected == true));

            // Create temporary view
            var view = new BasicView();

            // Main border
            view.ViewBorder = new Border(new Position(122, 6), new Size(49, 20));
            view.ViewBorder.Name = "SaveSettingsViewBorder";

            // Main label
            var saveSettingsLabel = new Label(new Position(140, 8)) {
                Name = "SaveSettingsLabel",
                Content = "Save Settings"
            };

            view.Controls.Add(saveSettingsLabel);


            // Message label - 1
            var saveSettingsMessageLabel1 = new Label(new Position(126, 22)) {
                Name = "SaveSettingsMessageLabel1",
                Content = ""
            };

            view.Controls.Add(saveSettingsMessageLabel1);

            // Message label - 2
            var saveSettingsMessageLabel2 = new Label(new Position(126, 23)) {
                Name = "SaveSettingsMessageLabel2",
                Content = ""
            };

            view.Controls.Add(saveSettingsMessageLabel2);


            // Save settings buttons
            for(int i = 1; i <= 3; i++) {
                var saveSettingsButton = new Button(new Position(126, 6 + (4 * i)), new Size(41, 3)) {
                    Name = "SaveSettingsButton" + i,
                    Content = "Slot " + i
                };

                saveSettingsButton.SetCallback(new EventHandler((obj, arg) => {
                    saveSettingsMessageLabel1.FontColor = ConsoleColor.Green;
                    saveSettingsMessageLabel1.Content = "Saved settings in " + saveSettingsButton.Content + "!";

                    saveSettingsMessageLabel2.FontColor = ConsoleColor.Green;
                    saveSettingsMessageLabel2.Content = "Press ESC button to exit!";

                    _Enigma.SaveSettings("Settings/" + saveSettingsButton.Content.Replace(" ", "") + ".txt");
                }));

                saveSettingsButton.Coordinates.Add(new Position(0, i - 1));
                view.Controls.Add(saveSettingsButton);
            }


            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkCyan;
            current_control.OnUpdate();

            // Show view
            view.OnUpdate();
            view.OnClick();

            // Delete view
            view.Clear();

            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkBlue;
            current_control.OnUpdate();
        }

        private void LoadSettingsButton_OnClick(object sender, EventArgs e) {
            var current_control = _View.Controls.Find(p => (p.Selected == true));

            // Create temporary view
            var view = new BasicView();

            // Main border
            view.ViewBorder = new Border(new Position(122, 6), new Size(49, 20));
            view.ViewBorder.Name = "LoadSettingsViewBorder";

            // Main label
            var loadSettingsLabel = new Label(new Position(140, 8)) {
                Name = "LoadSettingsLabel",
                Content = "Load Settings"
            };

            view.Controls.Add(loadSettingsLabel);


            // Message label - 1
            var loadSettingsMessageLabel1 = new Label(new Position(126, 22)) {
                Name = "LoadSettingsMessageLabel1",
                Content = ""
            };

            view.Controls.Add(loadSettingsMessageLabel1);

            // Message label - 2
            var loadSettingsMessageLabel2 = new Label(new Position(126, 23)) {
                Name = "LoadSettingsMessageLabel2",
                Content = ""
            };

            view.Controls.Add(loadSettingsMessageLabel2);


            // Load settings buttons
            for (int i = 1; i <= 3; i++) {
                var loadSettingsButton = new Button(new Position(126, 6 + (4 * i)), new Size(41, 3)) {
                    Name = "LoadSettingsButton" + i,
                    Content = "Slot " + i
                };

                loadSettingsButton.SetCallback(new EventHandler((obj, arg) => {
                    string filepath = "Settings/" + loadSettingsButton.Content.Replace(" ", "") + ".txt";

                    if (File.Exists(filepath)) {
                        loadSettingsMessageLabel1.FontColor = ConsoleColor.Green;
                        loadSettingsMessageLabel1.Content = "Loaded settings from " + loadSettingsButton.Content + "!";

                        loadSettingsMessageLabel2.FontColor = ConsoleColor.Green;
                        loadSettingsMessageLabel2.Content = "Press ESC button to exit!";
                    }
                    else {
                        loadSettingsMessageLabel1.FontColor = ConsoleColor.Red;
                        loadSettingsMessageLabel1.Content = loadSettingsButton.Content + " is empty!";

                        loadSettingsMessageLabel2.FontColor = ConsoleColor.Red;
                        loadSettingsMessageLabel2.Content = "Try again or press ESC to exit!";

                        return;
                    }

                    _Enigma.LoadSettings(filepath);

                    // View update
                    OnSettingsChanged();
                }));

                loadSettingsButton.Coordinates.Add(new Position(0, i - 1));
                view.Controls.Add(loadSettingsButton);
            }


            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkCyan;
            current_control.OnUpdate();

            // Show view
            view.OnUpdate();
            view.OnClick();

            // Delete view
            view.Clear();

            // Change control border color
            current_control.SelectedColor = ConsoleColor.DarkBlue;
            current_control.OnUpdate();
        }


        // Model variable
        private Enigma _Enigma;
    }

}