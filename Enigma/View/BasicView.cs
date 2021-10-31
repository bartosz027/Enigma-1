using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Encryption.View.Controls;

namespace Encryption.View {
    class BasicView {
        public BasicView() {
            Controls = new List<BasicControl>();
        }


        public virtual void OnClick() {
            var control = Controls.Find(p => p.Coordinates.Contains(new Position(0, 0)));
            control.Selected = true;

            while (true) {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                switch (consoleKeyInfo.Key) {
                    case ConsoleKey.UpArrow: {
                        var coordinates_list = control.Coordinates;
                        coordinates_list = coordinates_list.OrderBy(o => o.X).ToList();

                        var x_value = coordinates_list[((coordinates_list.Count % 2) == 0) ? (coordinates_list.Count / 2) - 1 : (coordinates_list.Count / 2)].X;
                        coordinates_list.RemoveAll(p => (p.X != x_value));

                        var y_value = coordinates_list.Min(p => p.Y);
                        var coordinate = coordinates_list.Find(p => (p.Y == y_value));

                        var prev_control = control;
                        control = Controls.Find(p => (p.Coordinates.Contains(new Position(coordinate.X, coordinate.Y - 1))));

                        if (control != null) {
                            prev_control.Selected = false;
                            control.Selected = true;
                        }
                        else {
                            control = prev_control;
                        }

                        break;
                    }
                    case ConsoleKey.DownArrow: {
                        var coordinates_list = control.Coordinates;
                        coordinates_list = coordinates_list.OrderBy(o => o.X).ToList();

                        var x_value = coordinates_list[((coordinates_list.Count % 2) == 0) ? (coordinates_list.Count / 2) - 1 : (coordinates_list.Count / 2)].X;
                        coordinates_list.RemoveAll(p => (p.X != x_value));

                        var y_value = coordinates_list.Max(p => p.Y);
                        var coordinate = coordinates_list.Find(p => (p.Y == y_value));

                        var prev_control = control;
                        control = Controls.Find(p => (p.Coordinates.Contains(new Position(coordinate.X, coordinate.Y + 1))));

                        if (control != null) {
                            prev_control.Selected = false;
                            control.Selected = true;
                        }
                        else {
                            control = prev_control;
                        }

                        break;
                    }
                    case ConsoleKey.LeftArrow: {
                        var coordinates_list = control.Coordinates;
                        coordinates_list = coordinates_list.OrderBy(o => o.Y).ToList();

                        var y_value = coordinates_list[((coordinates_list.Count % 2) == 0) ? (coordinates_list.Count / 2) - 1 : (coordinates_list.Count / 2)].Y;
                        coordinates_list.RemoveAll(p => (p.Y != y_value));

                        var x_value = coordinates_list.Min(p => p.X);
                        var coordinate = coordinates_list.Find(p => (p.X == x_value));

                        var prev_control = control;
                        control = Controls.Find(p => (p.Coordinates.Contains(new Position(coordinate.X - 1, coordinate.Y))));

                        if (control != null) {
                            prev_control.Selected = false;
                            control.Selected = true;
                        }
                        else {
                            control = prev_control;
                        }

                        break;
                    }
                    case ConsoleKey.RightArrow: {
                        var coordinates_list = control.Coordinates;
                        coordinates_list = coordinates_list.OrderBy(o => o.Y).ToList();

                        var y_value = coordinates_list[((coordinates_list.Count % 2) == 0) ? (coordinates_list.Count / 2) - 1 : (coordinates_list.Count / 2)].Y;
                        coordinates_list.RemoveAll(p => (p.Y != y_value));

                        var x_value = coordinates_list.Max(p => p.X);
                        var coordinate = coordinates_list.Find(p => (p.X == x_value));

                        var prev_control = control;
                        control = Controls.Find(p => (p.Coordinates.Contains(new Position(coordinate.X + 1, coordinate.Y))));

                        if (control != null) {
                            prev_control.Selected = false;
                            control.Selected = true;
                        }
                        else {
                            control = prev_control;
                        }

                        break;
                    }
                    case ConsoleKey.Enter: {
                        control.OnClick();

                        if (ExitViewOnEnterKeyPress == true) {
                            return;
                        }

                        break;
                    }
                    case ConsoleKey.Escape: {
                        control.Selected = false;
                        return;
                    }
                }
            }
        }

        public virtual void OnUpdate() {
            ViewBorder.OnUpdate();

            foreach (var control in Controls) {
                control.OnUpdate();
            }
        }


        public virtual void Clear() {
            ViewBorder.Clear();

            foreach (var control in Controls) {
                control.Clear();
            }
        }


        public BasicControl GetControl(string name) {
            var control = Controls.Find(p => (p.Name == name));
            return control;
        }


        // View properties
        public bool ExitViewOnEnterKeyPress { get; set; }

        // View controls
        public Border ViewBorder { get; set; }
        public List<BasicControl> Controls { get; set; }
    }

}