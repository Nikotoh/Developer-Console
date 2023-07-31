using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Nikotoh.DeveloperConsole
{

    public class ConsoleManager : MonoBehaviour
    {
        public static ConsoleManager Instance;
        [SerializeField] private GameObject consoleCanvas; // assign in inspector
        public InputField inputField; // assign in inspector
        public Text outputField = null; // assign in inspector
        [SerializeField] private CommandProcessor commandProcessor;
        //public Text developerConsoleVersion;

        public bool IsOpen { get; private set; }
        public bool IsEnabled { get; set; } = true;

        private void Awake() 
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            // Hide console on start
            consoleCanvas.SetActive(false);

            outputField.text = "";
        }

        private void Update()
        {
            // Open/close console on tilde key (` or ~)
            if (Input.GetKeyDown(KeyCode.F4))
            {
                ToggleConsole();
            }

            // Process command when Enter is pressed
            if (consoleCanvas.activeSelf && Input.GetKeyDown(KeyCode.Return))
            {
                //ProcessCommand(inputField.text);
                inputField.text = "";
                inputField.Select(); // Keep the input field focused after processing a command
            }

        }

        public void HandleInput()
        {
            string input = inputField.text; // get text from your input field

            if (!string.IsNullOrEmpty(input) && input.StartsWith("/"))
            {
                // Remove the command prefix ("/") and trim any leading/trailing whitespace
                input = input.Substring(1).Trim();

                // Split the input into command and arguments
                string[] inputSplit = input.Split(' ');
                string commandName = inputSplit[0];
                string[] arguments = inputSplit.Skip(1).ToArray();

                if (commandName == "help")
                {
                    commandProcessor.Help(arguments);
                }
                else
                {
                    // Execute the command
                    string commandString = commandName + (arguments.Length > 0 ? " " + string.Join(" ", arguments) : "");
                    commandProcessor.ExecuteCommand(commandString);
                }

                inputField.text = string.Empty; // clear input field
            }
        }

        public void Log(string message)
        {
            outputField.text += message + "\n";
            
        }

        public void ToggleConsole()
        {
            IsOpen = !IsOpen;

            consoleCanvas.SetActive(IsOpen);

            if (IsOpen && consoleCanvas)
            {
                // Set focus to the input field
                inputField.ActivateInputField();
                inputField.text = "";
            }
        }

        public void CloseConsole()
        {
            IsOpen = false;

            consoleCanvas.SetActive(false);
        }

        public void OpenConsole()
        {
                IsOpen = !IsOpen;

                consoleCanvas.SetActive(true);
                if (consoleCanvas)
                {
                    // Set focus to the input field
                    inputField.ActivateInputField();
                    inputField.text = "";
                }
        }

        public void ShowAvailableCommands()
        {
            // Get the command names from the CommandProcessor.
            IEnumerable<string> commandNames = commandProcessor.GetCommandNames();

            // Convert the list of command names to a single string.
            string commandList = string.Join("\n", commandNames);

            // Print the command list to the console.
            outputField.text += "Available commands: " + commandList + "\n";
        }

        public void ClearLog()
        {
            outputField.text = "";
        }
    }
}