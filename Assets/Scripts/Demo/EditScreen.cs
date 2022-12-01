//This is a quickly put together
//edit screen that demos a scenario when the keys
//are pre-defined such as a PlayStation controller
//which has limited inputs.

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Controller;
using System;

public class EditScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown down, 
                         left,
                         up,
                         right;

    private Command[] commands;
    private List<string> commandsStringList;

    void Awake()
    {
        PopulateCommands();
    }

    void Start()
    {
        AddOptions(KeyCode.DownArrow, down);
        AddOptions(KeyCode.LeftArrow, left);
        AddOptions(KeyCode.UpArrow, up);
        AddOptions(KeyCode.RightArrow, right);
    }

    void PopulateCommands()
    {
        Array commandInts = Enum.GetValues(typeof(Command));
        int index = 0;

        commandsStringList = new List<string>();
        commands = new Command[commandInts.Length];

        foreach (int i in commandInts)
        {
            Command command = (Command)i;
            commands[index++] = command;
            commandsStringList.Add(command.ToString());
        }
    }

    void AddOptions(KeyCode key, TMP_Dropdown dropdown)
    {
        //Need to look at controller commands and
        //set dropdown to corresponding assignments.
        //This works because the list matches the
        //values of the commands in the enum
        int keyInt = (int)key;
        Command controllerCommand = InputHandler.controller.GetCommandForKey(keyInt);

        dropdown.AddOptions(commandsStringList);
        dropdown.SetValueWithoutNotify((int)controllerCommand);
        dropdown.onValueChanged.AddListener((val) =>
        {
            ICCommand command = CommandFactory.Create(commands[val]);
            InputHandler.controller.SetCommand((int)key, command);
        });
    }
}
