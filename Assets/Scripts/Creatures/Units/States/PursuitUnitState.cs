using UnityEngine;

namespace Creatures.Units.States
{
    public class PursuitUnitState : UnitState
    {
        [SerializeField] private Transform _target;

        private void Update()
        {
            if (_target == null)
            {
                unit.MoveToPoint(unit.Position);
                return;
            }         
            unit.MoveToPoint(_target.position);
            unit.RotateToPoint(_target.position);
        }
        protected override void OnOut()
        {
            base.OnOut();
            unit.MoveToPoint(unit.Position);
        }
    } 
}

