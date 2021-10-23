using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.View.Controls {

    class TextBox : BasicControl {
        public TextBox(Position position, Size size) : base(position, size) {
            _Limit = (size.Width - 2) * (size.Height - 2);
        }


        public override void OnClick() {
            ConsoleKeyInfo consoleKeyInfo;

            SelectedColor = ConsoleColor.DarkRed;
            OnUpdate();

            Console.SetCursorPosition(_Position.X + 1, _Position.Y + 1);
            Console.CursorVisible = true;

            do {
                consoleKeyInfo = Console.ReadKey(true);
                
                if((Char.ToUpper(consoleKeyInfo.KeyChar) >= 'A' && Char.ToUpper(consoleKeyInfo.KeyChar) <= 'Z' || consoleKeyInfo.Key == ConsoleKey.Spacebar) && Text.Length < _Limit) {
                    Text += Char.ToUpper(consoleKeyInfo.KeyChar);
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Backspace && Text.Length > 0) {
                    Text = Text.Remove(Text.Length - 1);
                }

            } while (consoleKeyInfo.Key != ConsoleKey.Escape && consoleKeyInfo.Key != ConsoleKey.Enter);

            Console.CursorVisible = false;

            SelectedColor = ConsoleColor.DarkBlue;
            OnUpdate();

            if (_EventHandler != null && consoleKeyInfo.Key == ConsoleKey.Enter) {
                _EventHandler(this, EventArgs.Empty);
            }
        }

        public override void OnUpdate() {
            base.OnUpdate();

            for(int i = 1; i < (_Size.Height - 1); i++) {
                Console.SetCursorPosition(_Position.X + 1, _Position.Y + i);
                Console.Write(new string(' ', (_Size.Width - 2)));
            }

            var split = Text.Select((c, index) => new { c, index })
                .GroupBy(x => x.index / (_Size.Width - 2))
                .Select(group => group.Select(elem => elem.c))
                .Select(chars => new string(chars.ToArray()));

            for(int i = 1; i <= split.Count(); i++) {
                Console.SetCursorPosition(_Position.X + 1, _Position.Y + i);
                Console.Write(split.ElementAt(i - 1));
            }
        }


        public string Text {
            get { return _Text; }
            set { _Text = value; OnUpdate(); }
        }
        private string _Text = "";

        // Number of characters that can fit into TextBox
        private int _Limit;
    }

}