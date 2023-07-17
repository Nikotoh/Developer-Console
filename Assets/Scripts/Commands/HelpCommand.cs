using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCommand : ConsoleCommand
{
    public override string CommandID { get { return "/help"; } }

    public override string Description { get { return "get help lol"; } }

    public override void Execute(string[] args)
    {
        foreach (var command in DeveloperConsole.instance.GetCommands().Values)
        {
            DeveloperConsole.instance.outputField.text += $"\n{command.CommandID}: {command.Description}";
        }
    }
}
