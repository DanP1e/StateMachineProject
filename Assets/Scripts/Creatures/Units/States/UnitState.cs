using UnityEngine;
using System;
using Creatures.States;

namespace Creatures.Units.States
{
    [RequireComponent(typeof(UnitStateMachine))]
    public abstract class UnitState : State
    {
        protected IUnit unit = null;

        protected override void OnEntered()
        {
            base.OnEntered();
            if (!IsInitialized)
            {
                Debug.LogError($"\"{this.GetType().Name}\" state not initialized ");
                enabled = false;
            }
        }

        protected override void Initialize(params object[] initializationParams)
        {
            unit = new ParamsToTypeConverter<IUnit>(initializationParams).Get();

            foreach (StateTransiton transiton in stateTransitons)
            {
                transiton.Init(unit);
            }
        }

    } 
}

