using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneGapWindows
{
    public interface ICommand
    {
        string execute(string instruction, string[] parameters);
        bool accept(string instruction);
    }
}
