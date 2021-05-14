// csc behavioral_state.cs && behavioral_state && del behavioral_state.exe
using System;


interface IState {
    void Execute(Context c);
}


class Context {
    public int StepIndex {get; set;}
    public String StepName {get; set;}
    public IState Current {get; set;}

    public Context() {
        IState state = new StopState();
        state.Execute(this); 
    }

    public override String ToString() {
        return this.StepIndex + ": " + this.StepName;
    }

    public void Show() {
        Console.WriteLine(this.ToString());
    }
}


class StartState : IState {
    public void Execute(Context c) {
        c.StepIndex = 1;
        c.StepName = "start";
        c.Current = this;
    }
}


class InProgressState : IState {
    public void Execute(Context c) {
        c.StepIndex = 2;
        c.StepName = "inprogress";
        c.Current = this;
    }
}


class StopState : IState {
    public void Execute(Context c) {
        c.StepIndex = 3;
        c.StepName = "stop";
        c.Current = this;
    }
}


class Program {
    public static void Main() {
        Context context = new Context();
        StartState startState = new StartState();
        InProgressState inProgressState = new InProgressState();
        StopState stopState = new StopState();

        context.Show();
        startState.Execute(context);
        context.Show();
        inProgressState.Execute(context);
        context.Show();
        stopState.Execute(context);
        context.Show();

        /*
        3: stop
        1: start
        2: inprogress
        3: stop
         */
    }
}