using Encryption.View.Controls;

namespace Encryption.View {

    class RotorView : BasicView {
        public RotorView() {
            // Border
            ViewBorder = new Border(new Position(0, 0), new Size(80, 15));

            ViewBorder.Name = "RotorViewBorder";
            ViewBorder.Coordinates.Add(new Position(0, 0));

            // Label - main
            var rotorViewLabel = new Label(new Position(31, 2));

            rotorViewLabel.Name = "RotorViewLabel";
            rotorViewLabel.Content = "=======Key=======";

            Controls.Add(rotorViewLabel);

            // Button - increase key 1
            var rotorKeyUpButton1 = new Button(new Position(32, 4), new Size(3, 3));

            rotorKeyUpButton1.Name = "RotorKeyUpButton1";
            rotorKeyUpButton1.Content = "▲";

            rotorKeyUpButton1.Coordinates.Add(new Position(0, 0));
            Controls.Add(rotorKeyUpButton1);

            // Label - rotor key 1
            var rotorKeyLabel1 = new Label(new Position(33, 8));

            rotorKeyLabel1.Name = "RotorKeyLabel1";
            rotorKeyLabel1.Content = "A";

            Controls.Add(rotorKeyLabel1);

            // Button - decrease key 1
            var rotorKeyDownButton1 = new Button(new Position(32, 10), new Size(3, 3));

            rotorKeyDownButton1.Name = "RotorKeyDownButton1";
            rotorKeyDownButton1.Content = "▼";

            rotorKeyDownButton1.Coordinates.Add(new Position(0, 1));
            Controls.Add(rotorKeyDownButton1);

            // Button - increase key 2
            var rotorKeyUpButton2 = new Button(new Position(38, 4), new Size(3, 3));

            rotorKeyUpButton2.Name = "RotorKeyUpButton2";
            rotorKeyUpButton2.Content = "▲";

            rotorKeyUpButton2.Coordinates.Add(new Position(1, 0));
            Controls.Add(rotorKeyUpButton2);

            // Label - rotor key 2
            var rotorKeyLabel2 = new Label(new Position(39, 8));

            rotorKeyLabel2.Name = "RotorKeyLabel2";
            rotorKeyLabel2.Content = "A";

            Controls.Add(rotorKeyLabel2);

            // Button - decrease key 2
            var rotorKeyDownButton2 = new Button(new Position(38, 10), new Size(3, 3));

            rotorKeyDownButton2.Name = "RotorKeyDownButton2";
            rotorKeyDownButton2.Content = "▼";

            rotorKeyDownButton2.Coordinates.Add(new Position(1, 1));
            Controls.Add(rotorKeyDownButton2);

            // Button - increase key 3
            var rotorKeyUpButton3 = new Button(new Position(44, 4), new Size(3, 3));

            rotorKeyUpButton3.Name = "RotorKeyUpButton3";
            rotorKeyUpButton3.Content = "▲";

            rotorKeyUpButton3.Coordinates.Add(new Position(2, 0));
            Controls.Add(rotorKeyUpButton3);

            // Label - rotor key 3
            var rotorKeyLabel3 = new Label(new Position(45, 8));

            rotorKeyLabel3.Name = "RotorKeyLabel3";
            rotorKeyLabel3.Content = "A";

            Controls.Add(rotorKeyLabel3);

            // Button - decrease key 3
            var rotorKeyDownButton3 = new Button(new Position(44, 10), new Size(3, 3));

            rotorKeyDownButton3.Name = "RotorKeyDownButton3";
            rotorKeyDownButton3.Content = "▼";

            rotorKeyDownButton3.Coordinates.Add(new Position(2, 1));
            Controls.Add(rotorKeyDownButton3);
        }
    }

}