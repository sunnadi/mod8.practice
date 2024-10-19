using System;
using System.Collections.Generic;
public interface ICommand
{
    void Execute();
    void Undo();
}
public class Light
{
    public void On() => Console.WriteLine("Свет включен.");
    public void Off() => Console.WriteLine("Свет выключен.");
}
public class LightOnCommand : ICommand
{
    private Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute() => light.On();
    public void Undo() => light.Off();
}
public class LightOffCommand : ICommand
{
    private Light light;

    public LightOffCommand(Light light)
    {
        this.light = light;
    }

    public void Execute() => light.Off();
    public void Undo() => light.On();
}

public class AirConditioner
{
    public void On() => Console.WriteLine("Кондиционер включен.");
    public void Off() => Console.WriteLine("Кондиционер выключен.");
}

public class AirConditionerOnCommand : ICommand
{
    private AirConditioner ac;

    public AirConditionerOnCommand(AirConditioner ac)
    {
        this.ac = ac;
    }

    public void Execute() => ac.On();
    public void Undo() => ac.Off();
}

public class AirConditionerOffCommand : ICommand
{
    private AirConditioner ac;

    public AirConditionerOffCommand(AirConditioner ac)
    {
        this.ac = ac;
    }

    public void Execute() => ac.Off();
    public void Undo() => ac.On();
}

public class Television
{
    public void On() => Console.WriteLine("Телевизор включен.");
    public void Off() => Console.WriteLine("Телевизор выключен.");
}
public class TVOnCommand : ICommand
{
    private Television tv;

    public TVOnCommand(Television tv)
    {
        this.tv = tv;
    }

    public void Execute() => tv.On();
    public void Undo() => tv.Off();
}
public class TVOffCommand : ICommand
{
    private Television tv;

    public TVOffCommand(Television tv)
    {
        this.tv = tv;
    }

    public void Execute() => tv.Off();
    public void Undo() => tv.On();
}

public class RemoteControl
{
    private ICommand[] onCommands;
    private ICommand[] offCommands;
    private Stack<ICommand> commandHistory;

    public RemoteControl(int buttonCount)
    {
        onCommands = new ICommand[buttonCount];
        offCommands = new ICommand[buttonCount];
        commandHistory = new Stack<ICommand>();
    }

    public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
    {
        onCommands[slot] = onCommand;
        offCommands[slot] = offCommand;
    }

    public void OnButtonPressed(int slot)
    {
        onCommands[slot]?.Execute();
        commandHistory.Push(onCommands[slot]);
    }

    public void OffButtonPressed(int slot)
    {
        offCommands[slot]?.Execute();
        commandHistory.Push(offCommands[slot]);
    }

    public void Undo()
    {
        if (commandHistory.Count > 0)
        {
            ICommand lastCommand = commandHistory.Pop();
            lastCommand.Undo();
        }
        else
        {
            Console.WriteLine("Нет команд для отмены.");
        }
    }
}

public class MacroCommand : ICommand
{
    private List<ICommand> commands;

    public MacroCommand(List<ICommand> commands)
    {
        this.commands = commands;
    }

    public void Execute()
    {
        foreach (var command in commands)
        {
            command.Execute();
        }
    }

    public void Undo()
    {
        foreach (var command in commands)
        {
            command.Undo();
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Light light = new Light();
        AirConditioner ac = new AirConditioner();
        Television tv = new Television();

        LightOnCommand lightOn = new LightOnCommand(light);
        LightOffCommand lightOff = new LightOffCommand(light);
        AirConditionerOnCommand acOn = new AirConditionerOnCommand(ac);
        AirConditionerOffCommand acOff = new AirConditionerOffCommand(ac);
        TVOnCommand tvOn = new TVOnCommand(tv);
        TVOffCommand tvOff = new TVOffCommand(tv);

        RemoteControl remote = new RemoteControl(3);
        remote.SetCommand(0, lightOn, lightOff);
        remote.SetCommand(1, acOn, acOff);
        remote.SetCommand(2, tvOn, tvOff);

        remote.OnButtonPressed(0); 
        remote.OnButtonPressed(1); 
        remote.OnButtonPressed(2); 

        Console.WriteLine();

        remote.Undo(); 
        remote.Undo(); 

        List<ICommand> macroCommands = new List<ICommand> { lightOn, acOn, tvOn };
        MacroCommand macro = new MacroCommand(macroCommands);
        macro.Execute(); 

        Console.WriteLine();

        macro.Undo(); 
    }
}
