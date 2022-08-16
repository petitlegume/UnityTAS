using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

namespace UnityTAS
{
    public class TASVirtualStick : OnScreenStick
    {
        void Start() { }
        public void emulate(float[]? rawInput)
        {
            Vector2 input = rawInput == null ? new Vector2(0, 0) : new Vector2(((float[])rawInput)[0], ((float[])rawInput)[1]);
            SendValueToControl(input);
        }
    }
}
