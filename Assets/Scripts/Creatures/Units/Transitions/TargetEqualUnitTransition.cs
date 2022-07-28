using Creatures.States;
using UnityEngine;

namespace Creatures.Units.States
{
    enum EqualArgument
    {
        Null,
        Something
    }
    public class TargetEqualUnitTransition : UnitStateTransition
    {
        [SerializeField] private EqualArgument _equalArgument;
        [SerializeField] private Transform _target;

        public Transform Target { get => _target; set => _target = value; }

        public override State OnGetState()
        {

            Transform unitTarget = _target;
            if (unitTarget == null)
            {
                if (_equalArgument == EqualArgument.Null)
                {
                    return TargetState;
                }
            }
            else
            {
                if (_equalArgument == EqualArgument.Something)
                {
                    return TargetState;
                }
            }

            return null;
        }
    } 
}

