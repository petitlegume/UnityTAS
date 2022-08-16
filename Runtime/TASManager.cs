using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;
using UnityEngine.InputSystem;

namespace UnityTAS
{
    public class TASManager : MonoBehaviour
    {
        int _instruction;
        public int instruction { get { return _instruction; } }

        [SerializeField]
        string fileName = "tasconfig.json";
        [SerializeField]
        TASVirtualController controller;
        int stickyFrames;
        TASConfig config;
        float originalTimeScale;
        float _targetTimeScale;
        public float targetTimeScale { get { return this._targetTimeScale; } }
        bool ready;
        bool paused;
        InputSettings.UpdateMode originalInputUpdateMode;

        public void TooglePause(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                if (this.paused)
                    this.Resume();
                else
                    this.Pause();
            }
        }
        public void Next(InputAction.CallbackContext context)
        {
            if (context.started) this.Next();
        }

        public void Slower()
        {
            if (this._targetTimeScale >= 0)
                this._targetTimeScale -= 0.01f;
        }

        public void Faster()
        {
            if (this._targetTimeScale <= this.originalTimeScale)
                this._targetTimeScale += 0.01f;
        }

        public void Pause()
        {
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
            this.paused = true;
            Time.timeScale = 0;
        }

        public void Next()
        {
            Time.timeScale = this._targetTimeScale;
        }

        public void Resume()
        {
            InputSystem.settings.updateMode = this.originalInputUpdateMode;
            this.paused = false;
            this.Next();
        }

        void FixedUpdate()
        {
            if (!ready) return;
            if (this._instruction >= this.config.frames.Length) return;

            TASFrame frame = this.config.frames[this._instruction];

            if (frame._break != null && (bool)frame._break || this.paused)
                this.Pause();
            else
                this.Resume();

            if (this.stickyFrames == 0)
                this.stickyFrames = frame.frames == null ? 0 : (int)frame.frames;

            this.controller.Emulate(frame);

            if (this.stickyFrames > 0)
                this.stickyFrames--;
            if (this.stickyFrames == 0)
                this._instruction++;

        }

        void Start()
        {
            string path = Application.persistentDataPath + "/" + this.fileName;
            try
            {
                FileStream file = File.OpenRead(path);
                DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(TASConfig));
                this.config = (TASConfig)s.ReadObject(file);
                this.originalTimeScale = Time.timeScale;
                this._targetTimeScale = this.config.speed != null ? (float)this.config.speed : this.originalTimeScale;
                this.originalInputUpdateMode = InputSystem.settings.updateMode;
                this.ready = true;
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

}