using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCommand : ConsoleCommand
{
    public override string CommandID { get { return "/clear"; } }
    public override string Description { get { return "Clears the console output. Usage: /clear"; } }

    public override void Execute(string[] args)
    {
        DeveloperConsole.instance.outputField.text = "";
    }
}
