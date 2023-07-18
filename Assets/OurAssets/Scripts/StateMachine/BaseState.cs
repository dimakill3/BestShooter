namespace CodeBase.Units.Units
{
    public abstract class BaseState
    {
        protected readonly StateMachine _stateMachine;
        protected readonly bool _isServer;

        public BaseState(StateMachine stateMachine) =>
            _stateMachine = stateMachine;

        public virtual void Enter()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void FixedUpdate()
        {
        }

        public virtual void Exit()
        {
        }
        
        public virtual void Destruct()
        {
            
        }

        public virtual void GoToNextState()
        {
            
        }
    }
}