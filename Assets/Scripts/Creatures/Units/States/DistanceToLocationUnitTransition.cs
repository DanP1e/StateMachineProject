using InspectorAddons;
using UnityEngine;
namespace Creatures.Units.States
{
    public class DistanceToLocationUnitTransition : DistanceToUnitTransition
    {
        [SerializeField] private InterfaceComponent<ILocationContainer> _locationContainerComponent;

        protected override Vector3 TargetPosition 
            => ((ILocationContainer)_locationContainerComponent.Component).GetTargetPosition();
    }
}
