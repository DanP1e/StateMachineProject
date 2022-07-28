using System;
using UnityEngine;

namespace Creatures.Units.States
{
    public class AttackUnitState : UnitState
    {
        [SerializeField] private Transform _target;

        [Header("Attack preferences")]
        public float Damage;
        public float Cooldown;

        private float timer = 0;

        private IAlive GetTargetHealth(Transform target)
        {
            IAlive health = target.GetHeir<IAlive>();
            if (health == null)
                throw new ArgumentException($"The parameter {nameof(target)} does not contain a component inherited from IAlive!", nameof(target));
            return health;
        }
        private void Update()
        {
            Transform unitTarget = _target;

            if (unitTarget == null)
                return;

            IAlive targetHealth = GetTargetHealth(unitTarget);

            unit.RotateToPoint(unitTarget.position);
            if (targetHealth != null)
            {
                if (timer <= 0)
                {
                    timer = Cooldown;
                    targetHealth.MakeDamage(Damage);
                    Debug.DrawLine(unitTarget.position, unit.Position, Color.red);
                }
                timer -= Time.deltaTime;
            }
        }

    } 
}
