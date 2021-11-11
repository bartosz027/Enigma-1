#pragma warning disable CA1416 // Validate platform compatibility

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Encryption.View;
using Encryption.View.Controls;

using Encryption.Model;
using Encryption.Controller;

namespace Encryption.Core {

    class Window {
        public Window() {
            InitWindow();
            InitControllers();
        }


        public void Run() {
            var controller = _Controllers.Find(p => p.GetViewCoordinates().Contains(new Position(0, 0)));
            controller.HighlightView(true);

            for (int i = 0; i < _Controllers.Count; i++) {
                _Controllers[i].UpdateView();
            }

            while (true) {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                switch (consoleKeyInfo.Key) {
                    case ConsoleKey.UpArrow: {
                        var coordinates_list = controller.GetViewCoordinates();
                        coordinates_list = coordinates_list.OrderBy(o => o.X).ToList();

                        var x_value = coordinates_list[((coordinates_list.Count % 2) == 0) ? (coordinates_list.Count / 2) - 1 : (coordinates_list.Count / 2)].X;
                        coordinates_list.RemoveAll(p => (p.X != x_value));

                        var y_value = coordinates_list.Min(p => p.Y);
                        var coordinate = coordinates_list.Find(p => (p.Y == y_value));

                        var prev_controller = controller;
                        controller = _Controllers.Find(p => (p.GetViewCoordinates().Contains(new Position(coordinate.X, coordinate.Y - 1))));

                        if (controller != null) {
                            prev_controller.HighlightView(false);
                            controller.HighlightView(true);
                        }
                        else {
                            controller = prev_controller;
                        }

                        break;
                    }
                    case ConsoleKey.DownArrow: {
                        var coordinates_list = controller.GetViewCoordinates();
                        coordinates_list = coordinates_list.OrderBy(o => o.X).ToList();

                        var x_value = coordinates_list[((coordinates_list.Count % 2) == 0) ? (coordinates_list.Count / 2) - 1 : (coordinates_list.Count / 2)].X;
                        coordinates_list.RemoveAll(p => (p.X != x_value));

                        var y_value = coordinates_list.Max(p => p.Y);
                        var coordinate = coordinates_list.Find(p => (p.Y == y_value));

                        var prev_controller = controller;
                        controller = _Controllers.Find(p => (p.GetViewCoordinates().Contains(new Position(coordinate.X, coordinate.Y + 1))));

                        if(controller != null) {
                            prev_controller.HighlightView(false);
                            controller.HighlightView(true);
                        }
                        else {
                            controller = prev_controller;
                        }

                        break;
                    }
                    case ConsoleKey.LeftArrow: {
                        var coordinates_list = controller.GetViewCoordinates();
                        coordinates_list = coordinates_list.OrderBy(o => o.Y).ToList();

                        var y_value = coordinates_list[((coordinates_list.Count % 2) == 0) ? (coordinates_list.Count / 2) - 1 : (coordinates_list.Count / 2)].Y;
                        coordinates_list.RemoveAll(p => (p.Y != y_value));

                        var x_value = coordinates_list.Min(p => p.X);
                        var coordinate = coordinates_list.Find(p => (p.X == x_value));

                        var prev_controller = controller;
                        controller = _Controllers.Find(p => (p.GetViewCoordinates().Contains(new Position(coordinate.X - 1, coordinate.Y))));

                        if (controller != null) {
                            prev_controller.HighlightView(false);
                            controller.HighlightView(true);
                        }
                        else {
                            controller = prev_controller;
                        }

                        break;
                    }
                    case ConsoleKey.RightArrow: {
                        var coordinates_list = controller.GetViewCoordinates();
                        coordinates_list = coordinates_list.OrderBy(o => o.Y).ToList();

                        var y_value = coordinates_list[((coordinates_list.Count % 2) == 0) ? (coordinates_list.Count / 2) - 1 : (coordinates_list.Count / 2)].Y;
                        coordinates_list.RemoveAll(p => (p.Y != y_value));

                        var x_value = coordinates_list.Max(p => p.X);
                        var coordinate = coordinates_list.Find(p => (p.X == x_value));

                        var prev_controller = controller;
                        controller = _Controllers.Find(p => (p.GetViewCoordinates().Contains(new Position(coordinate.X + 1, coordinate.Y))));

                        if (controller != null) {
                            prev_controller.HighlightView(false);
                            controller.HighlightView(true);
                        }
                        else {
                            controller = prev_controller;
                        }

                        break;
                    }
                    case ConsoleKey.Enter: {
                        controller.HighlightView(false);
                        controller.EnterView();

                        controller.HighlightView(true);
                        break;
                    }
                }
            }
        }


        private void InitWindow() {
            ConsoleHelper.SetCurrentFont("Consolas", 14);
            Console.CursorVisible = false;

            Console.SetWindowSize(176, 49);
            Console.SetBufferSize(176, 49);
        }

        private void InitControllers() {
            var enigma = new Enigma();

            _Controllers = new List<BasicController>() {
                new RotorViewController(enigma, new RotorView()),
                new EncryptionViewController(enigma, new EncryptionView()),
                new InformationViewController(enigma, new InformationView())
            };

            var settingsViewController = new SettingsViewController(enigma, new SettingsView());
            settingsViewController.SettingsChanged += UpdateInformationView;

            _Controllers.Add(settingsViewController);
        }


        private void UpdateInformationView(object sender, EventArgs args) {
            var controller = _Controllers.Find(p => (p.GetViewID() == "InformationViewBorder"));
            controller.UpdateView();
        }


        private List<BasicController> _Controllers;
    }

}