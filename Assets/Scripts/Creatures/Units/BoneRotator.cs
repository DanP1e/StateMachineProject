using UnityEngine;
namespace Creatures.Units
{
    public sealed class BoneRotator : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void LateUpdate()
        {
            Vector3 targetAngle = Quaternion.LookRotation(_target.position - transform.position, Vector3.up).eulerAngles;
            targetAngle.x = 0;
            transform.eulerAngles = targetAngle;
        }
    }
}
