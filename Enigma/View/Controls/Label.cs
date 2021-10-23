using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.View.Controls {

    class Label : BasicControl {
        public Label(Position position) : base(position, new Size(0, 0)) {
            ReadOnly = true;
        }

        public override void OnUpdate() {
            Console.SetCursorPosition(_Position.X, _Position.Y);
            Console.Write(new string(' ', (_Size.Width)));

            Console.SetCursorPosition(_Position.X, _Position.Y);
            Console.Write(Content);

            _Size.Width = Content.Length;
        }

        public string Content {
            get { return _Content; }
            set { _Content = value; OnUpdate(); }
        }
        private string _Content = "";
    }

}