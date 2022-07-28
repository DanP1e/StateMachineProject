using Creatures.States;
using UnityEngine;

namespace Creatures.Units.States
{
    public enum TriggeringEvent
    {
        InTriggeringZone,
        OutOfTriggeringZone
    }

    public abstract class DistanceToUnitTransition : UnitStateTransition
    {
        [Tooltip("Determines whether the height is included " +
            "in the distance to point calculation.")]
        [SerializeField] private bool _isHeightIncluded = false;
        [SerializeField] private float _triggeringDistance;
        [SerializeField] private TriggeringEvent _triggeringEvent;

        protected float TriggeringDistance => _triggeringDistance;
        protected TriggeringEvent TriggeringEvent { get => _triggeringEvent; }
        protected abstract Vector3 TargetPosition { get; }
     
        public override State OnGetState()
        {
            Vector3 newTargetPos = TargetPosition;
            newTargetPos.y = newTargetPos.y * (_isHeightIncluded ? 1 : 0);
            Vector3 newUnitPos = unit.Position;
            newUnitPos.y = newUnitPos.y * (_isHeightIncluded ? 1 : 0);

            float distanceToTarget = Vector3.Distance(newTargetPos, newUnitPos);

            if (distanceToTarget <= TriggeringDistance && TriggeringEvent == TriggeringEvent.InTriggeringZone)
                return TargetState;

            if (distanceToTarget > TriggeringDistance && TriggeringEvent == TriggeringEvent.OutOfTriggeringZone)
                return TargetState;

            return null;
        }
    } 
}

