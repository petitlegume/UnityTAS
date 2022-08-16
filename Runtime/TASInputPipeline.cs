using UnityEngine.InputSystem.OnScreen;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;
using UnityEngine.InputSystem.Layouts;
using System.Linq;

namespace UnityTAS
{
    public class TASInputPipeline : MonoBehaviour
    {
        int _frameCtr;
        public int frame { get { return _frameCtr; } }
        [SerializeField]
        string fileName = "tasconfig.json";
        [SerializeField]
        TASVirtualController controller;
        int waitForFrames;
        TASConfig config;
        float? _timeScale;
        public float? timeScale { get { return _timeScale; } }
        bool ready;

        void FixedUpdate()
        {
            if (!ready) return;
            if (this._frameCtr >= this.config.frames.Length) return;

            if (this._timeScale != null)
                Time.timeScale = (float)this._timeScale;

            TASFrame frame = this.config.frames[this._frameCtr];
            if (this.waitForFrames == 0)
                this.waitForFrames = frame.frames == null ? 0 : (int)frame.frames;

            this.controller.Emulate(frame);

            if (this.waitForFrames > 0)
                this.waitForFrames--;
            if (this.waitForFrames == 0)
                this._frameCtr++;
        }

        void Start()
        {
            string path = Application.persistentDataPath + "/" + this.fileName;
            try
            {
                FileStream file = File.OpenRead(path);
                DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(TASConfig));
                this.config = (TASConfig)s.ReadObject(file);
                if (config.speed != null)
                    this._timeScale = (float)config.speed;
                this.ready = true;
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

}