using UnityEngine;

namespace Creatures.Units
{
    public enum UnitAnimation
    {
        Idle,
        Walk,
        Search,
        Attack
    }

    public class UnitAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void SetAnimation(int animId)
        {
            UnitAnimation unitAnimation = (UnitAnimation)animId;

            switch (unitAnimation)
            {
                case UnitAnimation.Idle:

                break;
                case UnitAnimation.Walk:
                _animator.SetBool("Walk", true);
                break;
                case UnitAnimation.Search:
                _animator.SetBool("Walk", false);
                break;
                case UnitAnimation.Attack:
                break;
                default:
                break;
            }
        }
    } 
}
