using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.View.Controls {

    class TextBox : BasicControl {
        public TextBox(Position position, Size size) : base(position, size) {
            _CharacterLimit = (size.Width - 2) * (size.Height - 2);
            _PrevTextLength = 0;
        }


        public override void OnClick() {
            ConsoleKeyInfo consoleKeyInfo;

            SelectedColor = ConsoleColor.DarkRed;
            UpdateBorder();

            int cursor_x = Text.Length % (_Size.Width - 2) + 1;
            int cursor_y = (int)Math.Floor((double)(Text.Length / (_Size.Width - 2))) + 1;

            Console.SetCursorPosition(_Position.X + cursor_x, _Position.Y + cursor_y);
            Console.CursorVisible = true;

            do {
                consoleKeyInfo = Console.ReadKey(true);

                if (((Char.ToUpper(consoleKeyInfo.KeyChar) >= 'A' && Char.ToUpper(consoleKeyInfo.KeyChar) <= 'Z') || consoleKeyInfo.Key == ConsoleKey.Spacebar) && Text.Length < _CharacterLimit) {
                    Text += Char.ToUpper(consoleKeyInfo.KeyChar);
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Backspace && Text.Length > 0) {
                    Text = Text.Remove(Text.Length - 1);
                }

            } while (consoleKeyInfo.Key != ConsoleKey.Escape && consoleKeyInfo.Key != ConsoleKey.Enter);

            Console.CursorVisible = false;

            SelectedColor = ConsoleColor.DarkBlue;
            UpdateBorder();

            if (_EventHandler != null && consoleKeyInfo.Key == ConsoleKey.Enter) {
                _EventHandler(this, EventArgs.Empty);
            }
        }

        public override void OnUpdate() {
            UpdateBorder();
            UpdateText();
        }


        private void UpdateBorder() {
            base.OnUpdate();
        }

        private void UpdateText() {
            int cursor_x = (_PrevTextLength % (_Size.Width - 2));
            int cursor_y = (int)Math.Floor((double)(_PrevTextLength / (_Size.Width - 2))) + 1;

            if (Text.Length > _PrevTextLength) {
                var split = Text.Select((c, index) => new { c, index })
                    .GroupBy(x => x.index / (_Size.Width - 2))
                    .Select(group => group.Select(elem => elem.c))
                    .Select(chars => new string(chars.ToArray()));

                for (int i = cursor_y; i <= split.Count(); i++) {
                    Console.SetCursorPosition(_Position.X + cursor_x + 1, _Position.Y + i);
                    Console.Write(split.ElementAt(i - 1).Substring(cursor_x));

                    cursor_x = 0;
                }
            }
            else if (Text.Length < _PrevTextLength) {
                for(int i = 0; i < _PrevTextLength - Text.Length; i++) {
                    if (cursor_x == 0) {
                        cursor_x = _Size.Width - 2;
                        cursor_y--;
                    }

                    Console.SetCursorPosition(_Position.X + cursor_x, _Position.Y + cursor_y);
                    Console.Write(" ");

                    Console.SetCursorPosition(_Position.X + cursor_x, _Position.Y + cursor_y);
                    cursor_x--;
                }
            }
        }


        // TextBox properties
        public string Text {
            get { 
                return _Text; 
            }
            set { 
                _PrevTextLength = _Text.Length; 
                _Text = value; 
                
                UpdateText(); 
            }
        }
        private string _Text = "";


        // Private variables
        private int _CharacterLimit;
        private int _PrevTextLength;
    }

}