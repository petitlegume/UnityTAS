using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

namespace UnityTAS
{
    public class TASVirtualButton : OnScreenButton
    {
        public void emulate(bool? value)
        {
            if (value == null || !(bool)value) SendValueToControl(0.0f);
            else SendValueToControl(1.0f);
        }

        public void emulate(float? value)
        {
            if (value == null) SendValueToControl(0.0f);
            else SendValueToControl((float)value);
        }
    }
}
