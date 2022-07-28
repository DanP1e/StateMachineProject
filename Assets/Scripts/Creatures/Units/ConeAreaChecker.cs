using System;
using UnityEngine;

namespace Creatures.Units
{
    public class ConeAreaChecker : MonoBehaviour, IAreaChecker
    {
        [SerializeField] private Transform eye;
        [SerializeField] private float _absoluteDetectionDistance;
        [SerializeField] private float _viewDistance;
        [SerializeField] private float _viewAngle;

        public Transform Eye { get => eye; }

        public bool IsInArea(Transform target)
        {
            if (target == null)
                throw new ArgumentNullException($"{nameof(target)}", $"Should not be empty!");

            float distanceToPlayer = Vector3.Distance(target.transform.position, Eye.transform.position);
            bool result = (distanceToPlayer <= _absoluteDetectionDistance || IsTargetInEyeArea(target));
            return result;
        }

        private void Update()
        {
            DrawViewArea();
        }
        private bool IsTargetInEyeArea(Transform target)
        {
            float realAngle = Vector3.Angle(Eye.forward, target.position - Eye.position);
            RaycastHit hit;
            if (Physics.Raycast(Eye.transform.position, target.position - Eye.position, out hit, _viewDistance))
                if (realAngle < _viewAngle / 2f 
                    && Vector3.Distance(Eye.position, target.position) <= _viewDistance 
                    && hit.transform == target)
                    return true;

            return false;
        }
        private void DrawViewArea()
        {
            Vector3 left = Eye.position + Quaternion.Euler(new Vector3(0, _viewAngle / 2f, 0)) * (Eye.forward * _viewDistance);
            Vector3 right = Eye.position + Quaternion.Euler(-new Vector3(0, _viewAngle / 2f, 0)) * (Eye.forward * _viewDistance);
            Debug.DrawLine(Eye.position, left, Color.yellow);
            Debug.DrawLine(Eye.position, right, Color.yellow);
        }
    }
}
