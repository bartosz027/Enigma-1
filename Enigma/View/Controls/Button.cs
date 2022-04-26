namespace Encryption.View.Controls {

    class Button : BasicControl {
        public Button(Position position, Size size) 
            : base(position, size) {
        }


        public override void OnClick() {
            base.OnClick();
        }

        public override void OnUpdate() {
            base.OnUpdate();

            System.Console.SetCursorPosition(_Position.X + ((_Size.Width - Content.Length) / 2), _Position.Y + 1);
            System.Console.Write(Content);
        }


        // Button properties
        public string Content { get; set; } = "";
    }

}