using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperConsole : MonoBehaviour
{
    public GameObject consoleCanvas; // assign in inspector
    public InputField inputField; // assign in inspector
    public Text outputField; // assign in inspector
    public Text developerConsoleVersion;

    private Dictionary<string, ConsoleCommand> commands;

    private void Start()
    {
        // Initialize the commands dictionary
        commands = new Dictionary<string, ConsoleCommand>();

        // Add your commands here. For example:
        commands.Add("addGold", new AddGoldCommand());
        // commands.Add("teleport", new TeleportCommand());

        // Hide console on start
        consoleCanvas.SetActive(false);

        // Display version number
        developerConsoleVersion.text = "Console Version: " + Application.version.ToString();
        // [Major build number].[Minor build number].[Patch]
    }

    private void Update()
    {
        // Open/close console on tilde key (` or ~)
        if (Input.GetKeyDown(KeyCode.F4))
        {
            consoleCanvas.SetActive(!consoleCanvas.activeSelf);
            if (consoleCanvas.activeSelf)
            {
                // Set focus to the input field
                inputField.ActivateInputField();

                // Show the available commands
                outputField.text = GetCommandHelp();
            }
        }

        // Process command when Enter is pressed
        if (consoleCanvas.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            ProcessCommand(inputField.text);
            inputField.text = "";
            inputField.Select(); // Keep the input field focused after processing a command
        }
    }

    private void ProcessCommand(string commandInput)
    {
        // Parse the command input into a command and arguments
        string[] inputSplit = commandInput.Split(' ');
        string commandName = inputSplit[0];
        string[] commandArgs = new string[inputSplit.Length - 1];
        System.Array.Copy(inputSplit, 1, commandArgs, 0, commandArgs.Length);

        // Check if the command exists
        if (commands.ContainsKey(commandName))
        {
            // Execute the command and append the result to the output field's text
            outputField.text += commands[commandName].Execute(commandArgs) + "\n";
        }
        else
        {
            outputField.text += $"Unknown command: {commandName}\n";
        }
    }

    private string GetCommandHelp()
    {
        string helpText = "AVAILABLE COMMANDS:\n";
        foreach (var command in commands)
        {
            helpText += "/" + command.Key + ": " + command.Value.Description + "\n";
        }

        return helpText;
    }


}
