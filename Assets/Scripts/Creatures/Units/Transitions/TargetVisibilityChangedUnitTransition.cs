using Creatures.States;
using InspectorAddons;
using UnityEngine;

namespace Creatures.Units.States
{
    enum VisibilityChangeEvent
    {
        Entered,
        Out
    }
    public class TargetVisibilityChangedUnitTransition : UnitStateTransition
    {
        private IAreaChecker _areaChecker;

        [SerializeField] private InterfaceComponent<IAreaChecker> _areaCheckerComponent;
        [SerializeField] private VisibilityChangeEvent _visibilityChangeEvent;
        [SerializeField] private Transform _target;

        private bool _isTargetVisiable = false;

        protected void Awake()
        {
            _areaChecker = (IAreaChecker)_areaCheckerComponent.Component;
        }
        protected void OnEnable()
        {
            _isTargetVisiable = _areaChecker.IsInArea(_target);
        }

        public override State OnGetState()
        {
            bool isTargetVisiableNow = _areaChecker.IsInArea(_target);

            if (isTargetVisiableNow == _isTargetVisiable)
                return null;

            _isTargetVisiable = isTargetVisiableNow;

            if ((isTargetVisiableNow ? 0 : 1) == (int)_visibilityChangeEvent)
                return TargetState;

            return null;          
        }
    } 
}

