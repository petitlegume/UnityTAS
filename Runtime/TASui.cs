using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnityTAS
{
    public class TASui : MonoBehaviour
    {

        [SerializeField]
        TMP_Text instructionText;
        [SerializeField]
        TMP_Text frameText;
        [SerializeField]
        TMP_Text speedText;
        [SerializeField]
        TASManager tas;
        int frame;

        void Update()
        {
            this.speedText.text = this.tas.targetTimeScale.ToString("F2") + "x";
        }

        void FixedUpdate()
        {
            this.frameText.text = "Frame " + this.frame;
            this.instructionText.text = "Instruction " + this.tas.instruction;
            this.frame++;
        }
    }
}
