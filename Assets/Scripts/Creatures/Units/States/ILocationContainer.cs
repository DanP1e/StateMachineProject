using UnityEngine;

namespace Creatures.Units.States
{
    public interface ILocationContainer
    {
        Vector3 GetTargetPosition();
    }
}