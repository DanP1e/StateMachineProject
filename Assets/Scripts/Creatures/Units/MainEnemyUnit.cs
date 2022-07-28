using UnityEngine;
using InspectorAddons;
using UnityEngine.AI;

namespace Creatures.Units
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MainEnemyUnit : MonoBehaviour, IUnit
    {
        private NavMeshAgent _navMeshAgent;
       
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _movementSpeed;

        public Vector3 Position => transform.position;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.speed = _movementSpeed;
        }

        public void StopMove() 
        {
            _navMeshAgent.SetDestination(transform.position);
        }
        public void MoveToPoint(Vector3 point)
        {
            _navMeshAgent.SetDestination(point);
        }
        public void RotateToPoint(Vector3 point)
        {
            Vector3 targetAngle = Quaternion.LookRotation(point - transform.position, Vector3.up).eulerAngles;
            targetAngle.x = 0;

            Vector3 currentAngle = transform.eulerAngles;

            transform.eulerAngles = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * _rotationSpeed),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * _rotationSpeed),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * _rotationSpeed));
        }
    }
}