using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsoleCommand
{
    // Command ID (e.g. "addGold", "teleport", "spawnEnemy")
    public abstract string CommandID { get; }

    // Description of the command
    public abstract string Description { get; }

    // Method to execute the command
    public abstract string Execute(string[] args);
}
