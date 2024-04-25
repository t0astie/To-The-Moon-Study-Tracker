using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClearSpace", menuName = "Console/Commands/ClearSpace", order = 0)]
public class ClearSpace : CommandObject
{
    public override bool ConvertArg(string command)
    {
        // Takes no arguments
        return true;
    }

    public override string Execute(string command)
    {
        return ConsoleText.Instance.Text.text = "";
    }
}
