using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneGapWindows
{
    class CommandManager
    {
        private const String GEOLOCATION = "Location.startLocation";
        private Dictionary<String, ICommand> commands = new Dictionary<string, ICommand>();

        public CommandManager()
        {
            commands[GEOLOCATION] = new GeolocationCommand();
        }

        public String ProcessInstruction(String instruction, String[] args) {
            if (commands[instruction] != null)
            {
                return commands[instruction].execute(instruction, args);
            }
            return "";
        }
    }
}
