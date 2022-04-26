using System;
using System.Collections.Generic;

namespace Encryption.View.Controls {

    struct Position {
        public Position(int x, int y) {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    struct Size {
        public Size(int width, int height) {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }
        public int Height { get; set; }
    }


    abstract class BasicControl {
        public BasicControl(Position position, Size size) {
            _Position = position;
            _Size = size;

            Name = "NULL";

            SelectedColor = ConsoleColor.DarkBlue;
            ReadOnlyColor = ConsoleColor.DarkGray;

            Coordinates = new List<Position>();
        }


        public virtual void OnClick() {
            if(_EventHandler != null) {
                _EventHandler(this, EventArgs.Empty);
            }
        }

        public virtual void OnUpdate() {
            if (Selected) {
                Console.BackgroundColor = SelectedColor;
            }
            else if (ReadOnly) {
                Console.BackgroundColor = ReadOnlyColor;
            }

            // Left
            for (int i = 0; i < _Size.Height; i++) {
                Console.SetCursorPosition(_Position.X, i + _Position.Y);
                Console.Write("|");
            }

            // Right
            for (int i = 0; i < _Size.Height; i++) {
                Console.SetCursorPosition(_Position.X + (_Size.Width - 1), i + _Position.Y);
                Console.Write("|");
            }

            // Top
            for (int i = 0; i < _Size.Width; i++) {
                Console.SetCursorPosition(i + _Position.X, _Position.Y);
                Console.Write("#");
            }

            // Bottom
            for (int i = 0; i < _Size.Width; i++) {
                Console.SetCursorPosition(i + _Position.X, _Position.Y + (_Size.Height - 1));
                Console.Write("#");
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }


        public virtual void OnDelete() {
            for (int i = 0; i < _Size.Height; i++) {
                Console.SetCursorPosition(_Position.X, _Position.Y + i);
                Console.Write(new string(' ', (_Size.Width)));
            }
        }


        public void SetCallback(EventHandler handler) {
            _EventHandler = handler;
        }


        // Control identifier
        public string Name { get; set; }

        // Control border highlight
        public bool Selected {
            get { return _Selected; }
            set { _Selected = value; OnUpdate(); }
        }
        private bool _Selected;

        public bool ReadOnly {
            get { return _ReadOnly; }
            set { _ReadOnly = value; OnUpdate(); }
        }
        private bool _ReadOnly;

        // Control border colors
        public ConsoleColor SelectedColor { get; set; }
        public ConsoleColor ReadOnlyColor { get; set; }

        // Control coordinates (only for highlighting -> allows to set which control to highlight after key press)
        public List<Position> Coordinates { get; set; }

        // Control placement (position: x -> top, y -> left)
        protected Position _Position;
        protected Size _Size;

        // Event callback
        protected EventHandler _EventHandler;
    }

}