using UnityEngine;

namespace Creatures.Units
{
    public interface IAreaChecker
    {
        /// <summary>
        /// Return true if received object in area.
        /// </summary>
        bool IsInArea(Transform transform);
    }
}
