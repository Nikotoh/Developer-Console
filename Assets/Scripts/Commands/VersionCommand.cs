using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionCommand : ConsoleCommand
{
    public override string CommandID { get { return "/version"; } }
    public override string Description { get { return "Displays current build version"; } }

    public override void Execute(string[] args)
    {
        string version = Application.version;
        DeveloperConsole.instance.outputField.text += $"\nCurrent Build Version: {version}";

    }
}
