using UnityEngine;

namespace Creatures.Units.States
{
    public interface ILocationHandler : ILocationContainer
    {
        void SetTargetPosition(Vector3 targetPosition);
        void SetTargetPositionFromTransform(Transform targetTransform);
    }
}