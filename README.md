# Developer Console for Unity
The Developer Console is a tool for Unity that provides an in-game console for debugging and testing purposes. Developers can run custom commands to alter game states, spawn entities, add resources, and more.


## Features
Open and close the console with a key press (F4 by default)
Auto-registered commands
Command suggestions (In-progress)
Submit history (In-progress)
Built-in commands include:
- /help - Displays a list of available commands
- /clear - Clears the console output
- /quit - Quits the application
- /version - Displays the current version of the console tool
- /debug - Adds a debug log message


## Changelog
### 0.0.3
Reworked command system for cleaner organization and extendibility
Added new built-in commands (/clear, /quit, /debug)
Fixed minor issues with console display

### 0.0.2
Initial release with basic functionality


## Usage
To use the Developer Console in your Unity game project, import the project files into your Unity project's Assets folder. Then, attach the ConsoleManager script to a UI canvas that you want to use as your console.

Configure the input and output fields, as well as the command submit button, in the ConsoleManager component in the Unity inspector.

To use the console in your game, press the 'F4' key to open/close the console.

## License
This project is licensed under the terms of the MIT license. See the LICENSE file for details.
