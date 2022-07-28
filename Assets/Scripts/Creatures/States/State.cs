﻿using UnityEngine;
using System.Collections.Generic;

namespace Creatures.States
{
    public abstract class State : MonoBehaviour
    {
        private bool _isInitialized = false;

        [SerializeField] protected List<StateTransiton> stateTransitons;

        public bool IsInitialized => _isInitialized;
        protected virtual void OnEntered() { }
        protected virtual void OnOut() { }
        protected abstract void Initialize(params object[] initializationParams);

        public void Enter()
        {
            enabled = true;
            foreach (StateTransiton transiton in stateTransitons)
            {
                transiton.enabled = true;
            }
            OnEntered();
        }
        public void Exit()
        {
            foreach (StateTransiton transiton in stateTransitons)
            {
                transiton.enabled = false;
            }
            enabled = false;
            OnOut();
        }
        public State GetNextState()
        {
            foreach (StateTransiton transiton in stateTransitons)
            {
                State transState = transiton.GetState();
                if (transState != null)
                    return transState;
            }
            return null;
        }
        public bool TryInitialize(params object[] initializationParams)
        {
            if (!_isInitialized)
            {
                Initialize(initializationParams);
                _isInitialized = true;
                return true;
            }
            return false;
        }
    } 
}

