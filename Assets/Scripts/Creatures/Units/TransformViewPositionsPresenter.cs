using UnityEngine;

namespace Creatures.Units
{
    public class TransformViewPositionsPresenter : MonoBehaviour, IViewPositionsPresenter
    {        
        [SerializeField] private Transform[] _viewPositions;

        public int ViewPositionsCount() => _viewPositions.Length;
        public ViewPosition GetViewPosition(int id)
            => new ViewPosition(_viewPositions[id].position, _viewPositions[id].forward);
        public int GetNearestViewPositionId(Vector3 startingPoint)
        {
            int minId = 0;
            float minDistance = Vector3.Distance(startingPoint, _viewPositions[0].position);

            for (int i = 1; i < _viewPositions.Length; i++)
            {
                float currentDistance = Vector3.Distance(startingPoint, _viewPositions[i].position);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    minId = i;
                }
            }

            return minId;
        }
    }
}
