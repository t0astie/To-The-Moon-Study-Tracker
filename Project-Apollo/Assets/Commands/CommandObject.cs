using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandObject : ScriptableObject 
{
    [SerializeField] private string _name;
    [SerializeField] private string _sequence;
    [SerializeField] private string[] _commandOptions;
    [SerializeField] private int _argCountMin, _argCountMax;
    public string Valid(string command)
    {
        // Store each argument from the command
        string[] args = command.Split(' ');

        int n = 0;
        foreach (string c in _commandOptions)
        {
            // Check if the first argument isn't a valid command 
            if (args[0] != c)
            {
                n++;
            }
        }

        if (n == _commandOptions.Length)
        {
            return "Invalid command";
        }

        // Check the amount of arguments is the required amount
        if (args.Length < _argCountMin || args.Length > _argCountMax)
        {
            return $"Invalid number of arguments for <{_name}> command. Correct sequence: <{_sequence}>";
        }

        // Make sure that each argument can be converted to its type
        for (int i = 0; i < args.Length; i++)
        {
            if (!ConvertArg(command))
            {
                return $"Invalid arguments types for <{_name}> command. Correct sequence: <{_sequence}>";
            }
        }

        return "";
    }

    public abstract string Execute(string command);

    public abstract bool ConvertArg(string command);
}
