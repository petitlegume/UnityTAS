using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace UnityTAS
{
    [DataContract()]
    public class TASFrame
    {
        [DataMember(EmitDefaultValue = false)]
        public float[]? ls;
        [DataMember(EmitDefaultValue = false)]
        public float[]? rs;
        [DataMember(EmitDefaultValue = false)]
        public float[]? cpad;
        [DataMember(EmitDefaultValue = false)]
        public bool? a;
        [DataMember(EmitDefaultValue = false)]
        public bool? b;
        [DataMember(EmitDefaultValue = false)]
        public bool? x;
        [DataMember(EmitDefaultValue = false)]
        public bool? y;
        [DataMember(EmitDefaultValue = false)]
        public bool? start;
        [DataMember(EmitDefaultValue = false)]
        public bool? select;
        [DataMember(EmitDefaultValue = false)]
        public bool? lsb;
        [DataMember(EmitDefaultValue = false)]
        public bool? rsb;
        [DataMember(EmitDefaultValue = false)]
        public bool? lb;
        [DataMember(EmitDefaultValue = false)]
        public bool? rb;
        [DataMember(EmitDefaultValue = false)]
        public float? rt;
        [DataMember(EmitDefaultValue = false)]
        public float? lt;
        [DataMember(EmitDefaultValue = false)]
        public int? frames;
        [DataMember(EmitDefaultValue = false, Name = "break")]
        public bool? _break;
    }
}