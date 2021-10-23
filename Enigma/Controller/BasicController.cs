using System;
using System.Collections.Generic;

using Encryption.View;
using Encryption.View.Controls;

namespace Encryption.Controller {

    abstract class BasicController {
        public BasicController(BasicView view) {
            _View = view;
        }


        public virtual void HighlightView(bool flag) {
            _View.ViewBorder.Selected = flag;
        }

        public virtual void UpdateView() {
            _View.OnUpdate();
        }

        public virtual void EnterView() {
            _View.OnClick();
        }


        public string GetViewID() {
            return _View.ViewBorder.Name;
        }

        public List<Position> GetViewCoordinates() {
            return _View.ViewBorder.Coordinates;
        }


        protected void SetCallback(string control_name, EventHandler callback) {
            var control = _View.GetControl(control_name);
            control.SetCallback(callback);
        }


        protected BasicView _View;
    }

}