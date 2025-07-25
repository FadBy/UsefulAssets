using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace MenuSystem
{
    public class MenuService : BaseStateMachine, IInitializable
    {
        private readonly MenuSettings _settings;
        
        public MenuService(List<IMenu> _menus, MenuSettings settings)
        {
            _settings = settings;
            States = _menus.Cast<IState>().ToList();
            foreach (var menu in _menus)
            {
                menu.AddSwitchListener(SwitchTo);
            }
        }

        public void Initialize()
        {
            DisableAllMenus();
            InitialState = FindStateWithName(_settings.InitialMenuName);
            SwitchTo(InitialState);
        }

        private void DisableAllMenus()
        {
            foreach (var state in States)
            {
                if (state == InitialState) return;
                state.SwitchOff();
            }
        }
    
        private IState FindStateWithName(string name)
        {
            foreach (var state in States)
            {
                if (state.Name == name) return state;
            }
            return null;
        }
    }
}