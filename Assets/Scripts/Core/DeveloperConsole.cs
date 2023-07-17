using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DeveloperConsole : MonoBehaviour
{
    public static DeveloperConsole instance;
    public GameObject consoleCanvas; // assign in inspector
    public InputField inputField; // assign in inspector
    public Text outputField; // assign in inspector
    public Text developerConsoleVersion;

    public bool IsOpen { get; private set; }
    public bool IsEnabled { get; set; } = true;

    private Dictionary<string, ConsoleCommand> commands = new Dictionary<string, ConsoleCommand>();

    public Dictionary<string, ConsoleCommand> GetCommands()
    {
        return commands;
    }

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // Initialize the commands dictionary
        commands = new Dictionary<string, ConsoleCommand>();

        // Add your commands here. For example:
        commands.Add("/addGold", new AddGoldCommand());
        commands.Add("/help", new HelpCommand());
        commands.Add("/clear", new ClearCommand());
        commands.Add("/version", new VersionCommand());

        // commands.Add("teleport", new TeleportCommand());

        // Hide console on start
        consoleCanvas.SetActive(false);

        // Display version number
        developerConsoleVersion.text = "Console Version: " + Application.version.ToString();
        // [Major build number].[Minor build number].[Patch]

    }

    private void Update()
    {
        if(IsEnabled)
        {
            // Open/close console on tilde key (` or ~)
            if (Input.GetKeyDown(KeyCode.F4))
            {
                IsOpen = !IsOpen;

                consoleCanvas.SetActive(!consoleCanvas.activeSelf);
                if (consoleCanvas.activeSelf)
                {
                    // Set focus to the input field
                    inputField.ActivateInputField();
                    inputField.text = "";

                    // Show the available commands
                    outputField.text = GetCommandHelp();
                }
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


    private void HandleVisibility()
    {
        consoleCanvas.gameObject.SetActive(IsOpen);
        if (IsOpen)
        {
            inputField.ActivateInputField();
        }
    }

    private void ProcessCommand(string userInput)
    {
        string[] inputSplit = userInput.Split(' ');

        if (inputSplit.Length == 0 || inputSplit[0] == "")
        {
            outputField.text += $"\nUnknown command: {userInput}";
            return;
        }

        string commandInput = inputSplit[0];
        string[] parameters = inputSplit.Skip(1).ToArray(); // This uses Linq, so you'll need using System.Linq at the top of your file.

        if (!commands.TryGetValue(commandInput, out ConsoleCommand command))
        {
            outputField.text += $"\nUnknown command: {commandInput}";
            return;
        }

        command.Execute(parameters);
    }

    private string GetCommandHelp()
    {
        string helpText = "AVAILABLE COMMANDS:\n";
        foreach (var command in commands)
        {
            helpText += command.Key + ": " + command.Value.Description + "\n";
        }

        return helpText;
    }

    
}
