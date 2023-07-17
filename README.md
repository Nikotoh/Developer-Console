# Developer Console for Unity
The Developer Console is a tool for Unity that provides an in-game console for debugging and testing purposes. Developers can run custom commands to alter game states, spawn entities, add resources, and more.


## Installation
To install the Developer Console into your Unity project:

1. Clone this repository or download the Developer Console package.
2. Open your Unity project.
3. Go to "Assets > Import Package > Custom Package".
4. Select the Developer Console package and click "Open".
5. In the "Import Unity Package" window, ensure all files are selected, then click "Import".


## Usage
Once installed, the Developer Console can be accessed in-game by pressing the "`" (grave accent) key.

The console provides a text input field where commands can be entered. To execute a command, type it into the input field and press enter. Commands must start with a "/" followed by the command name and any arguments, separated by spaces. For example: `/addGold 100`


## Adding New Commands
To add a new command:

1. Create a new C# class that inherits from the **ConsoleCommand** abstract class.
2. Override the **CommandID**, **Description**, and **Execute** properties. For example:

```
public class MyCommand : ConsoleCommand
{
    public override string CommandID { get { return "myCommand"; } }
    public override string Description { get { return "Usage: /myCommand <arg1> <arg2>"; } }

    public override string Execute(string[] args)
    {
        // Implementation of the command goes here.
        // The args array will contain any arguments entered by the user.

        return "Command executed successfully";
    }
}
```

1. Add the new command to the console in the **DeveloperConsole**'s **Start** method:


```
commands.Add("myCommand", new MyCommand());
```
Now, the /myCommand command can be used in the console.


## Command Arguments
Commands can take any number of arguments. These arguments are entered in the console after the command name, separated by spaces. For example: `/myCommand arg1 arg2 arg3`

In the **Execute** method of a **ConsoleCommand**, these arguments can be accessed through the **args** array parameter. The arguments are strings, so they may need to be parsed or converted to other types if necessary.


## Customization
By default, the console opens with the **"" (grave accent) key, but this can be changed in the** DeveloperConsole` script.

The console uses Unity's UI system, so the look and feel of the console can be customized using Unity's standard UI tools. You can change the font, color, size, and other attributes of the console in the Unity Editor.


## Support
If you encounter any issues or have any questions about the Developer Console, please open an issue in this repository.


## License
This project is licensed under the terms of the MIT license. See the LICENSE file for details.
