using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextColor", menuName = "Console/Commands/TextColor", order = 0)]
public class TextColor : CommandObject
{
    private int _r, _g, _b;
    public override bool ConvertArg(string command)
    {
        string[] args = command.Split(' ');

        if (int.TryParse(args[1], out _r) && int.TryParse(args[2], out _g) && int.TryParse(args[3], out _b))
        {
            return true;
        }

        return false;
    }

    public override string Execute(string command)
    {
        ConsoleText.Instance.Text.color = new Color(_r, _g, _b, 1);
        return $"Text color updated to R:{_r}, G:{_g}, B:{_b}";
    }
}
