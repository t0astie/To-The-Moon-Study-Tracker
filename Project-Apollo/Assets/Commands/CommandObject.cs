using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandObject : ScriptableObject 
{
    [SerializeField] private string _name;
    [SerializeField] private string _sequence;
    [SerializeField] private Type[] _types;
    [SerializeField] private string[] _commandOptions;
    [SerializeField] private int _argCount;
    
    public virtual string Execute(string command)
    {   
        // Store each argument from the command
        string[] args = command.Split(' ');

        int n = 0;
        foreach (string c in _commandOptions)
        {
            // Check if the first argument isn't a valid command 
            if (args[0] != command)
            {
                n++;
            }
        }

        if (n == _commandOptions.Length)
        {
            return "Invalid command";
        }

        // Check the amount of arguments is the required amount
        if (args.Length != _argCount)
        {
            return $"Invalid number of arguments for <{_name}> command. Correct sequence: <{_sequence}>";
        }

        for (int i = 0; i < args.Length; i++)
        {
            if (!ConvertArg())
            {
                return $"Invalid arguments types for <{_name}> command. Correct sequence: <{_sequence}>";
            }
        }

        RunCommand(args);
        return "";
    }

    public abstract bool ConvertArg();

    public abstract void RunCommand(string[] args);
}
