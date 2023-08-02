
using GameProject3.Abstracts.States;
using System;
using System.Collections.Generic;

namespace GameProject3.States
{
    public class StateMachine
    {
        List<StateTransformer> _stateTransformers = new List<StateTransformer>();
        List<StateTransformer> _anyStateTransformer = new List<StateTransformer>();

        IState _currentState;

        public void SetState(IState state)
        {
            if (_currentState == state) return;

            _currentState?.OnExit();

            _currentState = state;

            _currentState.OnEnter();
        }

        public void Tick()
        {
            StateTransformer stateTransformer = CheckForTransformer();

            if (stateTransformer != null)
            {
                SetState(stateTransformer.To);
            }

            _currentState.Tick();
        }

        private StateTransformer CheckForTransformer()
        {
            foreach (StateTransformer stateTransformer in _anyStateTransformer)
            {
                if (stateTransformer.Condition.Invoke()) return stateTransformer;
            }

            foreach (StateTransformer stateTransformer in _stateTransformers)
            {
                if (stateTransformer.Condition.Invoke() && _currentState == stateTransformer.From) return stateTransformer;
            }

            return null;
        }

        public void AddState(IState from, IState to, System.Func<bool> condition)
        {
            StateTransformer stateTransformer = new StateTransformer(from, to, condition);
            _stateTransformers.Add(stateTransformer);
        }

        public void AnyState(IState to, System.Func<bool> condition)
        {
            StateTransformer stateTransformer = new StateTransformer(null, to, condition);
            _anyStateTransformer.Add(stateTransformer);
        }

    }
}

