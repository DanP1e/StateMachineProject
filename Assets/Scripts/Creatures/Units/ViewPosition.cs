using UnityEngine;

namespace Creatures.Units
{
    public struct ViewPosition 
    {
        public Vector3 Position;
        public Vector3 ViewDirection;

        public ViewPosition(Vector3 position, Vector3 viewDirection)
        {
            Position = position;
            ViewDirection = viewDirection;
        }
    }
}
