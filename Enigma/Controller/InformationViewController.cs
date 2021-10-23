using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Encryption.View;
using Encryption.View.Controls;

using Encryption.Model;

namespace Encryption.Controller {

    class InformationViewController : BasicController {
        public InformationViewController(Enigma enigma, InformationView view) : base(view) {
            _Enigma = enigma;
        }

        public override void UpdateView() {
            base.UpdateView();

            // Plugboard settings
            var plugboardConnectedLettersLabel = _View.GetControl("PlugboardConnectedLettersLabel") as Label;
            plugboardConnectedLettersLabel.Content += _Enigma.Plugboard.GetConnectedPlugs();

            // Rotor - Type settings
            var rotorTypeLabel1 = _View.GetControl("RotorTypeLabel1") as Label;
            rotorTypeLabel1.Content += _Enigma.CurrentRotors[0].GetName();

            var rotorTypeLabel2 = _View.GetControl("RotorTypeLabel2") as Label;
            rotorTypeLabel2.Content += _Enigma.CurrentRotors[1].GetName();

            var rotorTypeLabel3 = _View.GetControl("RotorTypeLabel3") as Label;
            rotorTypeLabel3.Content += _Enigma.CurrentRotors[2].GetName();

            // Rotor - Ring settings
            var rotorRingLabel1 = _View.GetControl("RotorRingLabel1") as Label;
            var ring1 = _Enigma.CurrentRotors[0].GetRingPosition();

            var rotorRingLabel2 = _View.GetControl("RotorRingLabel2") as Label;
            var ring2 = _Enigma.CurrentRotors[1].GetRingPosition();

            var rotorRingLabel3 = _View.GetControl("RotorRingLabel3") as Label;
            var ring3 = _Enigma.CurrentRotors[2].GetRingPosition();

            rotorRingLabel1.Content += ring1.ToString() + " [" + (char)('A' + (ring1 - 1)) + "]";
            rotorRingLabel2.Content += ring2.ToString() + " [" + (char)('A' + (ring2 - 1)) + "]";
            rotorRingLabel3.Content += ring3.ToString() + " [" + (char)('A' + (ring3 - 1)) + "]";

            // Reflector settings
            var reflectorTypeLabel = _View.GetControl("ReflectorTypeLabel") as Label;
            reflectorTypeLabel.Content += _Enigma.CurrentReflector.GetName();
        }

        private Enigma _Enigma;
    }

}