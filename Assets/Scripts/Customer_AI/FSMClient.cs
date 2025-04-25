using System.Collections.Generic;

public class FSMClient
{
    private Dictionary<StatesEnum, States> _allStates = new Dictionary<StatesEnum, States>();
    public States _currentState;

    public void AddState(StatesEnum name, States state)
    {
        if (!_allStates.ContainsKey(name))
        {
            _allStates.Add(name, state);
            state._fsm = this;
        }
        else
        {
            _allStates[name] = state;
        }
    }

    public void ChangeState(StatesEnum state)
    {
        _currentState?.OnExit();
        if (_allStates.ContainsKey(state)) _currentState = _allStates[state];
        _currentState?.OnEnter();
    }

    public void VirtualUpdate()
    {
        _currentState?.OnUpdate();
    }


}

public enum StatesEnum
{
    Spawn,
    Waiting,
    Consuming,
    Leaving
}