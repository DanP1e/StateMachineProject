using Creatures.States;
using UnityEngine;

namespace Creatures.Units.States
{
    public class TargetChangedUnitTransition : UnitStateTransition
    {
        private Transform _oldTraget = null;

        [SerializeField] private Transform _target;

        private void OnEnable()
        {
            _oldTraget = _target;
        }
        public override State OnGetState()
        {
            Transform newTarget = _target;
            if (_oldTraget == newTarget)         
                return null;

            _oldTraget = newTarget;
            return TargetState;
        }
    } 
}
