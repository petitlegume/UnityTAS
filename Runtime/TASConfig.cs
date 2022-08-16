using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace UnityTAS
{
    [DataContract()]
    public class TASConfig
    {
        [DataMember(EmitDefaultValue = false)]
        public float? speed;
        [DataMember()]
        public TASInstruction[] instructions;
    }
}
