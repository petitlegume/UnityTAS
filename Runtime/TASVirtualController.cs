using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

namespace UnityTAS
{
    public class TASVirtualController : MonoBehaviour
    {
        [SerializeField]
        public TASVirtualStick ls;
        [SerializeField]
        public TASVirtualButton lsb;
        [SerializeField]
        public TASVirtualStick rs;
        [SerializeField]
        public TASVirtualButton rsb;
        [SerializeField]
        public TASVirtualButton a;
        [SerializeField]
        public TASVirtualButton b;
        [SerializeField]
        public TASVirtualButton x;
        [SerializeField]
        public TASVirtualButton y;
        [SerializeField]
        public TASVirtualButton lb;
        [SerializeField]
        public TASVirtualButton rb;
        [SerializeField]
        public TASVirtualButton lt;
        [SerializeField]
        public TASVirtualButton rt;
        [SerializeField]
        public TASVirtualButton start;
        [SerializeField]
        public TASVirtualButton select;

        public void Emulate(TASFrame frame)
        {
            this.ls.emulate(frame.ls);
            this.lsb.emulate(frame.lsb);
            this.rs.emulate(frame.rs);
            this.rsb.emulate(frame.rsb);
            this.a.emulate(frame.a);
            this.start.emulate(frame.start);
            this.select.emulate(frame.select);
            this.a.emulate(frame.a);
            this.b.emulate(frame.b);
            this.x.emulate(frame.x);
            this.y.emulate(frame.y);
            this.lb.emulate(frame.lb);
            this.rb.emulate(frame.rb);
            this.lt.emulate(frame.lt);
            this.rt.emulate(frame.rt);
        }
    }
}
