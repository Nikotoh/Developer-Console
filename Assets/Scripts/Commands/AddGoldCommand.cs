using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGoldCommand : ConsoleCommand
{
    public override string CommandID { get { return "/addGold"; } }
    
    public override string Description { get { return "Adds the specified amount of gold to the player. Usage: /addGold <amount>"; } }

    public override void Execute(string[] args)
    {
        if (args.Length != 1)
        {
            DeveloperConsole.instance.outputField.text += "\nInvalid number of arguments. Usage: /addGold <amount>";
            return;
        }

        if (int.TryParse(args[0], out int amount))
        {
            // Add gold here
            // playerGold += amount;

            DeveloperConsole.instance.outputField.text += $"\nAdded {amount} gold to the player's total.";
        }
        else
        {
            DeveloperConsole.instance.outputField.text += "\nInvalid argument. Amount should be a number.";
        }
    }
}
