using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.View.Controls {

    class Button : BasicControl {
        public Button(Position position, Size size) : base(position, size) {

        }


        public override void OnClick() {
            base.OnClick();
        }

        public override void OnUpdate() {
            base.OnUpdate();

            Console.SetCursorPosition(_Position.X + ((_Size.Width - Content.Length) / 2), _Position.Y + 1);
            Console.Write(Content);
        }


        // Button properties
        public string Content { get; set; } = "";
    }

}