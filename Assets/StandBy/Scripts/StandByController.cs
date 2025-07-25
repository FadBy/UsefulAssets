using System;
using Config;
using Logger;
using UnityEngine;
using Zenject;

namespace StandBy
{
    public class StandByController : ITickable, IInitializable
    {
        private float _inactivityTime;
        
        private ConfigImporter _configImporter;
        private IStandByAction _standByAction;
    
        private float InactivityTime => _inactivityTime;
        
        public float Timer { get; private set; }
    
        public bool Enabled { get; private set; } = false;
    
        public StandByController(ConfigImporter configImporter, IStandByAction standByAction)
        {
            _configImporter = configImporter;
            _standByAction = standByAction;
        }
    
        public void Initialize()
        {
            _inactivityTime = _configImporter.ConfigData.StandByTime;
            ResetTimer();
        }
    
        public void Tick()
        {
            if (!Enabled || Timer <= 0) return;
            Timer -= Time.deltaTime;
            Debug.Log(Timer);
            if (Timer <= 0)
            {
                GameLogger.Instance.LogInfo("StandBy", "Stand By Timer Ended");
                _standByAction.Perform();
            }
        }
        
        public void ResetTimer()
        {
            Timer = InactivityTime;
        }
        
        public void Enable()
        {
            Enabled = true;
        }
    
        public void Disable()
        {
            Enabled = false;
        }
    }
}
