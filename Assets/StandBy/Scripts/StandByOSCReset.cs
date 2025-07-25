using System;
using Config;
using extOSC;
using OSC;
using UnityEngine.Events;
using Zenject;

namespace StandBy
{
    public class StandByOSCReset : IInitializable
    {
        private ConfigImporter _configImporter;
        private OSCListener _listener;
        private StandByController _standByController;

        public StandByOSCReset(ConfigImporter configImporter, OSCListener listener, StandByController standByController)
        {
            _configImporter = configImporter;
            _listener = listener;
            _standByController = standByController;
        }

        public void Initialize()
        {
            _listener.MessageReceived += OnMessageReceived;
        }

        private void OnMessageReceived(OSCMessage message)
        {
            if (message.Address != _configImporter.ConfigData.OSCAddress)
                return;

            _standByController.ResetTimer();
        }
    }
}
