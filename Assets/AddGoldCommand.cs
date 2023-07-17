using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGoldCommand : ConsoleCommand
{
    public override string CommandID { get { return "addGold"; } }

    public override string Description { get { return "<amount> - Adds gold to your account."; } }

    public override string Execute(string[] args)
    {
        if (args.Length < 1)
        {
            return "Usage: addGold <amount>";
        }

        int amount;
        if (int.TryParse(args[0], out amount))
        {
            // Assuming you have a way to add gold to the player
            //Player.Instance.AddGold(amount);
            return $"Added {amount} gold to the player";
        }
        else
        {
            return $"Invalid amount: {args[0]}";
        }
    }
}
