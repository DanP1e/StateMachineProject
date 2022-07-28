using UnityEngine;
using UnityEngine.Events;

namespace Creatures.States
{
    public abstract class StateTransiton : MonoBehaviour
    {
        [SerializeField] public UnityEvent<State> _stateTransited;
        [SerializeField] private State _targetState;

        public State TargetState => _targetState;

        public State GetState() 
        {
            if (enabled == false)
                return null;

            var res = OnGetState();
            if (res != null)
                _stateTransited?.Invoke(res);

            return res;
        }
        public abstract State OnGetState();
        public abstract void Init(params object[] initializationParams);
    } 
}

