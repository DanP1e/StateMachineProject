using InspectorAddons;
using UnityEngine;

namespace Creatures.Units.States
{
    /// <summary>
    /// Moves the unit to the position passed 
    /// to the SetTargetPosition method.
    /// </summary>
    public class GoPointUnitState : UnitState, ILocationHandler
    {
        [SerializeField] private Vector3 _targetPostition;

        public Vector3 GetTargetPosition()
            => _targetPostition;
        public void SetTargetPosition(Vector3 targetPoint)
        {
            _targetPostition = targetPoint;
            CreatePointer(_targetPostition);
        }

        public void SetTargetPositionFromTransform(Transform targetTransform)
            => _targetPostition = targetTransform.position;

        private void Update()
        {
            unit.MoveToPoint(_targetPostition);
            unit.RotateToPoint(_targetPostition);
        }

        private void CreatePointer(Vector3 pos) 
        {
            GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pointer.transform.position = pos;
            pointer.name = "GoPoint";
        }
    }
}
