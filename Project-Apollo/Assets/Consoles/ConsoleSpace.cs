using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsoleSpace", menuName = "Console/ConsoleSpace", order = 0)]
public class ConsoleSpace : ScriptableObject 
{
    [SerializeField] private CommandObject[] _commands;
    [SerializeField] private string _name;
    [SerializeField] [TextArea(5,20)] private string _header;
    [SerializeField] [TextArea(5,20)] private string _closer;
    private ConsoleText _text;
    private void Start() 
    {
        _text = ConsoleText._instance;
        _text.AddText(_header);
    }

    // Pushes a command to the console
    public string PushCommand(string text)
    {
        foreach (CommandObject c in _commands)
        {
            // Check if the text matches a command, invalid command means it is not an option
            string t = c.Valid(text);
            if (t == "Invalid command")
            {
                continue;
            }

            // The command was valid, excecute it
            if (t == "")
            {
                return c.Execute(text);
            }

            // The command was invalid, print its invalid message to the console
            return t;
        }

        // The command does not exist in the console space
        return "Invalid command in console space";
    }

    public string Name { get { return _name; }}
    public string Header { get { return _header; }}
    public string Closer { get { return _closer; }}
}

