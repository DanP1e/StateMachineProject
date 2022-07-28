using UnityEngine;
using Creatures.States;

namespace Creatures.Units.States
{
    public class TimerUnitTransition : UnitStateTransition
    {
        [SerializeField] private float _time = 5;

        private float _startTime = 0;

        private void OnEnable()
        {
            _startTime = Time.realtimeSinceStartup;
        }

        public override State OnGetState()
        {
            if (Time.realtimeSinceStartup - _startTime >= _time)
                return TargetState;

            return null;
        }
    }
}
