using Encryption.View.Controls;

namespace Encryption.View {

    class InformationView : BasicView {
        public InformationView() {
            // Border
            ViewBorder = new Border(new Position(0, 39), new Size(80, 10)) {
                Name = "InformationViewBorder",
                ReadOnly = true
            };

            // Label - plugboard settings
            var plugboardConnectedLettersLabel = new Label(new Position(1, 40));

            plugboardConnectedLettersLabel.Name = "PlugboardConnectedLettersLabel";
            plugboardConnectedLettersLabel.Content = "Plugboard Connected Letters: ";

            Controls.Add(plugboardConnectedLettersLabel);

            // Label - rotor type 1
            var rotorTypeLabel1 = new Label(new Position(1, 41));

            rotorTypeLabel1.Name = "RotorTypeLabel1";
            rotorTypeLabel1.Content = "Rotor 1 - Type: ";

            Controls.Add(rotorTypeLabel1);

            // Label - rotor ring 1
            var rotorRingLabel1 = new Label(new Position(1, 42));

            rotorRingLabel1.Name = "RotorRingLabel1";
            rotorRingLabel1.Content = "Rotor 1 - Ring: ";

            Controls.Add(rotorRingLabel1);

            // Label - rotor type 2
            var rotorTypeLabel2 = new Label(new Position(1, 43));

            rotorTypeLabel2.Name = "RotorTypeLabel2";
            rotorTypeLabel2.Content = "Rotor 2 - Type: ";

            Controls.Add(rotorTypeLabel2);

            // Label - rotor ring 2
            var rotorRingLabel2 = new Label(new Position(1, 44));

            rotorRingLabel2.Name = "RotorRingLabel2";
            rotorRingLabel2.Content = "Rotor 2 - Ring: ";

            Controls.Add(rotorRingLabel2);

            // Label - rotor type 3
            var rotorTypeLabel3 = new Label(new Position(1, 45));

            rotorTypeLabel3.Name = "RotorTypeLabel3";
            rotorTypeLabel3.Content = "Rotor 3 - Type: ";

            Controls.Add(rotorTypeLabel3);

            // Label - rotor ring 3
            var rotorRingLabel3 = new Label(new Position(1, 46));

            rotorRingLabel3.Name = "RotorRingLabel3";
            rotorRingLabel3.Content = "Rotor 3 - Ring: ";

            Controls.Add(rotorRingLabel3);

            // Label - reflector type
            var reflectorTypeLabel = new Label(new Position(1, 47));

            reflectorTypeLabel.Name = "ReflectorTypeLabel";
            reflectorTypeLabel.Content = "Reflector - Type: ";

            Controls.Add(reflectorTypeLabel);
        }


        public override void OnUpdate() {
            foreach(var control in Controls) {
                var label = control as Label;
                var index = label.Content.IndexOf(':');

                label.Content = label.Content.Remove(index + 1) + " ";
            }
        }
    }

}