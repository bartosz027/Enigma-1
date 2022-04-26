using System;
using System.Linq;

namespace Encryption.View.Controls {

    class DragDrop : BasicControl {
        public DragDrop(Position position, Size size) 
            : base(position, size) {
        }


        public override void OnClick() {
            ConsoleKeyInfo consoleKeyInfo;

            SelectedColor = ConsoleColor.DarkRed;
            OnUpdate();

            do {
                consoleKeyInfo = Console.ReadKey(true);
                Filepath += consoleKeyInfo.KeyChar;

                if(Filepath.Length == 2 && Filepath[1] != ':') {
                    var temp = Filepath[1];
                    Filepath = "" + temp;
                }

            } while (consoleKeyInfo.Key != ConsoleKey.Escape && Filepath.EndsWith(".txt") == false);

            if(consoleKeyInfo.Key == ConsoleKey.Escape) {
                Filepath = "";
                return;
            }
            
            if(_EventHandler != null) {
                int index = Filepath.LastIndexOf(":");
                Filepath = Filepath.Substring(index - 1);

                _EventHandler(this, EventArgs.Empty);
            }
        }


        // DragDrop properties
        public string Filepath {
            get { return _Filepath; }
            set { _Filepath = value; }
        }
        private string _Filepath = "";
    }

}