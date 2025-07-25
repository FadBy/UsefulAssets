using System;
using extOSC;
using Zenject;

namespace OSC
{
    public class OSCListener : IInitializable
    {
        private OSCReceiver _receiver;

        public event Action<OSCMessage> MessageReceived;

        public OSCListener(OSCReceiver receiver)
        {
            _receiver = receiver;
        }
        
        public void Initialize()
        {
            _receiver.Bind("*", OnMessageReceive);
        }

        private void OnMessageReceive(OSCMessage message)
        {
            MessageReceived?.Invoke(message);
        }
    }
}