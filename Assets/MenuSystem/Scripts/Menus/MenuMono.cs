using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace MenuSystem
{
    public class MenuMono : MonoBehaviour, IMenu
    {
    #if ODIN_INSPECTOR
        [Required]
    #endif
        [SerializeField] private string _name;
        [SerializeField] private GameObject _layout;
        
        protected event Action<string> OnSwitch;
        
        public UnityEvent SwitchedOn;
        public UnityEvent SwitchedOff;
    
        public string Name => _name;
    
        public bool IsOn { get; private set; } = false;
    
        private void Awake()
        {
            IsOn = _layout.activeSelf;
        }
    
        public virtual void SwitchOn()
        {
            if (IsOn) return;
            IsOn = true;
            if (_layout != null)
            {
                _layout.SetActive(true);
            }
            SwitchedOn?.Invoke();
        }
    
        public virtual void SwitchOff()
        {
            if (!IsOn) return;
            IsOn = false;
            if (_layout != null)
            {
                _layout.SetActive(false);
            }
            SwitchedOff?.Invoke();
        }
    
        public void AddSwitchListener(Action<string> listener)
        {
            OnSwitch += listener;
        }
    
        public void RemoveSwitchListener(Action<string> listener)
        {
            OnSwitch -= listener;
        }
    
        protected void InvokeSwitch(string menuName)
        {
            OnSwitch?.Invoke(menuName);
        }
    }
}
