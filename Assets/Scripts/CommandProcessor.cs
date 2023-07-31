using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nikotoh.DeveloperConsole
{
    public class CommandProcessor : MonoBehaviour
    {
        public delegate void CommandMethod(string[] args);

        private Dictionary<string, CommandInfo> commands = new Dictionary<string, CommandInfo>();

        public IEnumerable<string> GetCommandNames()
        {
            return commands.Keys;
        }

        public struct CommandInfo
        {
            public string Key;
            public string Description;
            public CommandMethod Method;

            public CommandInfo(string key, string description, CommandMethod method)
            {
                Key = key;
                Description = description;
                Method = method;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            commands.Add("addGold",    new CommandInfo("/addGold", "Adds the specified amount of gold to the player's inventory", AddGold));
            commands.Add("help",       new CommandInfo("/help", "Print list of available commands", Help));
            commands.Add("clear",      new CommandInfo("/clear", "Clear all Console messages", Clear));
            commands.Add("quit",       new CommandInfo("/quit", "Quit the application", Quit));
            commands.Add("debug",      new CommandInfo("/debug <message>", "Logs a debug message", DebugLog));
            commands.Add("close",      new CommandInfo("/close", "Closes the console", Close));
        }

        // Example command to add Gold to player
        private void AddGold(string[] args)
        {
            if (args.Length != 1)
            {
                ConsoleManager.Instance.Log("No amount speicifed. Usage: /addGold <amount>");
                return;
            }

            if (int.TryParse(args[0], out int amount))
            {
                // Add gold here
                // playerGold += amount;

                ConsoleManager.Instance.Log($"Added {amount} gold.");
            }
            else
            {
                ConsoleManager.Instance.Log($"Invalid amount: {args[0]}");
            }
        }

        public void Help(string[] args)
        {
            string helpText = "";
            foreach (var command in commands)
            {
                helpText += command.Value.Key + ": " + command.Value.Description + "\n";
            }
            ConsoleManager.Instance.Log(helpText);
        }

        public void Clear(string[] args)
        {
            ConsoleManager.Instance.ClearLog();      
        }

        public void Quit(string[] args)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void DebugLog(string[] args)
        {
            string message = string.Join(" ", args);
            Debug.Log(message);
        }

        public void Close(string[] args)
        {
            ConsoleManager.Instance.CloseConsole();
        }

        public void ExecuteCommand(string commandString)
        {
            // Remove leading slash
            if (!string.IsNullOrEmpty(commandString) && commandString[0] == '/')
            {
                commandString = commandString.Substring(1);
            }

            string[] commandSplit = commandString.Split(' ');
            string[] args = new string[0];

            if (commandSplit.Length < 1) return;

            if (commandSplit.Length > 1)
                args = commandSplit.Skip(1).ToArray();

            CommandInfo commandInfo;

            if (!commands.TryGetValue(commandSplit[0], out commandInfo))
            {
                ConsoleManager.Instance.Log($"Unknown command \"{commandSplit[0]}\"");
                return;
            }

            commandInfo.Method.Invoke(args);
        }

    }
}