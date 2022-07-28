using InspectorAddons;
using UnityEngine;

namespace Creatures.Units.States
{
    public class LocationTransmitter
    {
        [SerializeField] private InterfaceComponent<ILocationContainer> _from;
        [SerializeField] private InterfaceComponent<ILocationHandler> _to;

        public void Transmit() 
        {
            ((ILocationHandler)_to.Component)
                .SetTargetPosition(((ILocationContainer)_from.Component).GetTargetPosition());
        }
    }
}
