using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Encryption.View.Controls;

namespace Encryption.View {

    class InformationView : BasicView {
        public InformationView() {
            // Main Border
            ViewBorder = new Border(new Position(0, 39), new Size(80, 10)) {
                Name = "InformationViewBorder",
                ReadOnly = true
            };

            // Plugboard Settings Label
            var plugboardConnectedLettersLabel = new Label(new Position(1, 40));

            plugboardConnectedLettersLabel.Name = "PlugboardConnectedLettersLabel";
            plugboardConnectedLettersLabel.Content = "Plugboard Connected Letters: ";

            Controls.Add(plugboardConnectedLettersLabel);

            // Rotor 1 - Type Label
            var rotorTypeLabel1 = new Label(new Position(1, 41));

            rotorTypeLabel1.Name = "RotorTypeLabel1";
            rotorTypeLabel1.Content = "Rotor 1 - Type: ";

            Controls.Add(rotorTypeLabel1);

            // Rotor 1 - Ring Label
            var rotorRingLabel1 = new Label(new Position(1, 42));

            rotorRingLabel1.Name = "RotorRingLabel1";
            rotorRingLabel1.Content = "Rotor 1 - Ring: ";

            Controls.Add(rotorRingLabel1);

            // Rotor 2 - Type Label
            var rotorTypeLabel2 = new Label(new Position(1, 43));

            rotorTypeLabel2.Name = "RotorTypeLabel2";
            rotorTypeLabel2.Content = "Rotor 2 - Type: ";

            Controls.Add(rotorTypeLabel2);

            // Rotor 2 - Ring Label
            var rotorRingLabel2 = new Label(new Position(1, 44));

            rotorRingLabel2.Name = "RotorRingLabel2";
            rotorRingLabel2.Content = "Rotor 2 - Ring: ";

            Controls.Add(rotorRingLabel2);

            // Rotor 3 - Type Label
            var rotorTypeLabel3 = new Label(new Position(1, 45));

            rotorTypeLabel3.Name = "RotorTypeLabel3";
            rotorTypeLabel3.Content = "Rotor 3 - Type: ";

            Controls.Add(rotorTypeLabel3);

            // Rotor 3 - Ring Label
            var rotorRingLabel3 = new Label(new Position(1, 46));

            rotorRingLabel3.Name = "RotorRingLabel3";
            rotorRingLabel3.Content = "Rotor 3 - Ring: ";

            Controls.Add(rotorRingLabel3);

            // Reflector - Type Label
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