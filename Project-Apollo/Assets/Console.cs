using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEditor.U2D.Path;

public class Console : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TMP_InputField _input;
    private int _rows;
    [SerializeField] private int _maxRows;
    private void Update() 
    {
        _input.ActivateInputField();
        if (_input.text.Length <= 0)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            _text.text += $"\n> {_input.text}";
            _input.text = "";
            
            if (_rows == _maxRows)
            {
                _text.text = _text.text.Substring(_text.text.IndexOf('\n') + 1);
                return;
            }

            _rows++;
        }
    }
}
