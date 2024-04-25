using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrintCommand", menuName = "Console/Commands/Print", order = 0)]
public class PrintCommand : CommandObject
{
    public override bool ConvertArg(string command)
    {
        //string[] args = command.Split(' ');
        //object[] types = new object[] { "string" };
        return true;
    }

    public override string Execute(string command)
    {
        return command.Substring(command.IndexOf(' ') + 1);
    }
}
