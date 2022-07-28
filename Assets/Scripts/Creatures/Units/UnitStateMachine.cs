using Creatures.States;
using InspectorAddons;
using UnityEngine;

namespace Creatures.Units.States
{
    public class UnitStateMachine : StateMachine
    {
        private IUnit _unit;

        [SerializeField] protected InterfaceComponent<IUnit> _unitComponent;

        protected IUnit Unit
        {
            get
            {
                if (_unit == null)
                    _unit = _unitComponent.Component as IUnit;
                return _unit;
            }
        }

        protected override void InitializeState(State state)
        {
            state.TryInitialize(Unit);
        }
    } 
}

