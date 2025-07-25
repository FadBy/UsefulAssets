using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MenuSystem
{
    [Serializable]
    public class MenuSettings
    {
#if ODIN_INSPECTOR
        [Required]
#endif
        [SerializeField] private string _initialMenuName;

        public string InitialMenuName => _initialMenuName;
    }
}