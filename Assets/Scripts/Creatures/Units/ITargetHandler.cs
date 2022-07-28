using UnityEngine;

namespace Creatures.Units
{
    public interface ITargetHandler
    {
        void SetTarget(Transform newTarget);
        Transform GetTarget();
    }
}
