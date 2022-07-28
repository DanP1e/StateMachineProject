using Creatures.Units.States;
using InspectorAddons;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Creatures.Units
{
    [Serializable]
    public struct Region 
    {
        public Collider Collider;
        public Transform ViewPosition;
    }

    public class TransformRegionDetector : MonoBehaviour
    {
        [SerializeField] private InterfaceComponent<ILocationHandler>[] _locationListners;
        [SerializeField] private List<Region> _regions;

        /// <summary>
        /// Sends to listeners the ViewPoint of the Region 
        /// in which the Transform being passed is located.
        /// </summary>
        public void SendRegionViewPointOf(Transform target) 
        {
            Vector3 regionViewPoint = FindRegionViewPointOf(target);
            foreach (var item in _locationListners)
                ((ILocationHandler)item.Component).SetTargetPosition(regionViewPoint);
        }
        public void TrySendRegionViewPointOf(Transform target)
        {
            try
            {
                SendRegionViewPointOf(target);
            }
            catch { }
        }

        private Vector3 FindRegionViewPointOf(Transform target)
        {
            foreach (var region in _regions)
                if (region.Collider.bounds.Contains(target.position))
                    return region.ViewPosition.position;

            throw new ArgumentException("Target is outside of any region.");
        }
    }
}
