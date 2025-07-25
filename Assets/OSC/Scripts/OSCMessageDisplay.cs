using System;
using System.Linq;
using extOSC;
using Logger;
using TMPro;
using UnityEngine;
using Zenject;

namespace OSC
{
    [RequireComponent(typeof(CanvasGroup))]
    public class OSCMessageDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private CanvasGroup _canvasGroup;

        private OSCListener _listener;

        [Inject]
        public void Construct(OSCListener listener)
        {
            _listener = listener;
        }

        private void Start()
        {
            _listener.MessageReceived += AddMessage;
        }

        private void AddMessage(OSCMessage message)
        {
            AddMessage(OSCDebugLogger.ParseMessageToString(message));
        }

        

        private void AddMessage(string message)
        {
            _text.text = message + "\n" + _text.text;
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0f;
        }

        public void Show()
        {
            _canvasGroup.alpha = 1f;
        }
    }
}