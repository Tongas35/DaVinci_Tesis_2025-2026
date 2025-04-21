public abstract class States
{
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();

    public FSMClient _fsm;

}
