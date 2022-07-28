using UnityEngine;

namespace Creatures.Units
{
    public interface IViewPositionsPresenter
    {
        int GetNearestViewPositionId(Vector3 startingPoint);
        ViewPosition GetViewPosition(int id);
        int ViewPositionsCount();
    }
}