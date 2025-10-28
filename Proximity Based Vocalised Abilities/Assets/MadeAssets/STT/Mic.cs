using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Whisper.Utils;
using Button = UnityEngine.UI.Button;
using Toggle = UnityEngine.UI.Toggle;

namespace Whisper.Samples
{

    public class MicrophoneDemo : MonoBehaviour
    {
        public WhisperManager whisper;
        public MicrophoneRecord microphoneRecord;
        public PlayerController playerController;
        public bool streamSegments = true;
        public bool printLanguage = true;


        [Header("UI")]

        public Text outputText;
        public Text micStatus;


        private string _buffer;

        private void Awake()
        {
            whisper.OnNewSegment += OnNewSegment;

            microphoneRecord.OnRecordStop += OnRecordStop;

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                OnButtonPressed();
                playerController.vPressed = !playerController.vPressed;
            }
            if (playerController.vPressed)
            {
                micStatus.text = "ON";
            }
            if (!playerController.vPressed)
            {
                micStatus.text = "OFF";
            }
  
        }


        private void OnVadChanged(bool vadStop)
        {
            microphoneRecord.vadStop = vadStop;
        }

        private void OnButtonPressed()
        {
            if (!microphoneRecord.IsRecording)
            {
                microphoneRecord.StartRecord();

            }
            else
            {
                microphoneRecord.StopRecord();

            }
        }

        private async void OnRecordStop(AudioChunk recordedAudio)
        {

            _buffer = "";

            var sw = new Stopwatch();
            sw.Start();

            var res = await whisper.GetTextAsync(recordedAudio.Data, recordedAudio.Frequency, recordedAudio.Channels);
            if (res == null || !outputText)
                return;

            

            var text = res.Result;
            
            outputText.text = text;

        }

        private void OnNewSegment(WhisperSegment segment)
        {
            if (!streamSegments || !outputText)
                return;

            _buffer += segment.Text;
            outputText.text = _buffer + "...";
            
        }
    }
}