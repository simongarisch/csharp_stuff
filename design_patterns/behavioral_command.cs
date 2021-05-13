// csc behavioral_command.cs && behavioral_command && del behavioral_command.exe
// The command pattern encapsulates into a class all steps required to perform some action.
using System;


interface ICommand {
    void Execute();
}


class OnCommand : ICommand {
    IDevice device;

    public OnCommand(IDevice device) {
        this.device = device;
    }

    public void Execute() {
        device.On();
    }
}


class OffCommand : ICommand {
    IDevice device;

    public OffCommand(IDevice device) {
        this.device = device;
    }

    public void Execute() {
        device.Off();
    }
}


interface IDevice {
    void On();
    void Off();
}


class TV : IDevice {
    bool IsRunning = false;

    public void On() {
        IsRunning = true;
        Console.WriteLine("Turning TV on");
    }

    public void Off() {
        IsRunning = false;
        Console.WriteLine("Turning TV off");
    }
}


class Button {
    ICommand command;

    public Button(ICommand command) {
        this.command = command;
    }

    public void Press() {
        command.Execute();
    }
}


class Program {
    public static void Main() {
        TV tv = new TV();
        ICommand OnCommand = new OnCommand(tv);
        ICommand OffCommand = new OffCommand(tv);

        Button OnButton = new Button(OnCommand);
        Button OffButton = new Button(OffCommand);

        OnButton.Press();
        OffButton.Press();
        /*
        Turning TV on
        Turning TV off
         */
    }
}
