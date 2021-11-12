using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.View.Controls {

    class Label : BasicControl {
        public Label(Position position) : base(position, new Size(0, 1)) {
            FontColor = ConsoleColor.Gray;
            ReadOnly = true;
        }


        public override void OnUpdate() {
            Console.ForegroundColor = FontColor;

            Console.SetCursorPosition(_Position.X, _Position.Y);
            Console.Write(new string(' ', (_Size.Width)));

            Console.SetCursorPosition(_Position.X, _Position.Y);
            Console.Write(Content);

            Console.ForegroundColor = ConsoleColor.Gray;
            _Size.Width = Content.Length;
        }


        // Label properties
        public ConsoleColor FontColor {
            get { return _FontColor; }
            set { _FontColor = value; OnUpdate(); }
        }
        private ConsoleColor _FontColor;

        public string Content {
            get { return _Content; }
            set { _Content = value; OnUpdate(); }
        }
        private string _Content = "";
    }

}