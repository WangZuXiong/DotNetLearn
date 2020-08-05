using System;

/// <summary>
/// 状态模式
/// </summary>
public class StatePattern1 
{
    public interface IState
    {
        void DoAction(Context context);
    }

    public class StartState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Player is in start state");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Start State";
        }
    }

    public class StopState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Player is in stop state");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Stop State";
        }
    }

    public class Context
    {
        private IState _state;

        public Context()
        {
            _state = null;
        }

        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }

    public void Main()
    {
        Context context = new Context();

        StartState startState = new StartState();
        startState.DoAction(context);
        Console.WriteLine(context.GetState().ToString());

        StopState stopState = new StopState();
        stopState.DoAction(context);
        Console.WriteLine(context.GetState().ToString());
    }
}
