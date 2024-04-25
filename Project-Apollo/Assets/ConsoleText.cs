using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEditor.U2D.Path;

public class ConsoleText : MonoBehaviour
{
    public static ConsoleText Instance;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TMP_InputField _input;
    private int _rows;
    [SerializeField] private int _maxRows;
    private List<ConsoleSpace> _consoleSpace = new List<ConsoleSpace>();
    [SerializeField] private ConsoleSpace _baseConsole;

    private void OnEnable() 
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start() 
    {
        _consoleSpace.Add(_baseConsole);
        AddText(_baseConsole.Header);
    }

    private void Update() 
    {
        _input.ActivateInputField();

        // Get the user input
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {   
            // Add the text to the console window and clear the input field
            string command = _input.text;

            AddText(command);
            _input.text = ">";

            if (command == "")
            {
                return;
            }

            // Check that the command was not a base command, i.e 'exit', 'back' etc
            string t = _baseConsole.PushCommand(command);
            if (t == "Invalid command in console space")
            {
                AddText(t);
                return;
            }

            // Excecute the command in the console space
            AddText(_consoleSpace.Last().PushCommand(command));
        }
    }

    // Add text to the console window
    public void AddText(string text)
    {
        _text.text += $"\n> {text}";
        
        // If the amount of rows is too long, push the text up
        if (_rows == _maxRows)
        {
            _text.text = _text.text.Substring(_text.text.IndexOf('\n') + 1);
            return;
        }

        _rows++;
    }

    public TextMeshProUGUI Text { get { return _text; } }
    public TMP_InputField InputLine { get { return _input; } }
}
