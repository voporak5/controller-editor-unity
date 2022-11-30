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
    private TMP_Dropdown x, 
                         square,
                         triangle,
                         circle;

    private Dictionary<Command, ICCommand> dictCommands;
    private Command[] commands;
    [SerializeField]
    private List<string> commandsStringList;

    void Awake()
    {
        BuildDictionary();
    }

    void Start()
    {
        AddOptions(KeyCode.DownArrow, x);
        AddOptions(KeyCode.LeftArrow, square);
        AddOptions(KeyCode.UpArrow, triangle);
        AddOptions(KeyCode.RightArrow, circle);
    }

    void BuildDictionary()
    {
        Array commandInts = Enum.GetValues(typeof(Command));
        int index = 0;

        dictCommands = new Dictionary<Command, ICCommand>();
        commandsStringList = new List<string>();
        commands = new Command[commandInts.Length];

        foreach (int i in commandInts)
        {
            Command command = (Command)i;
            commands[index++] = command;
            commandsStringList.Add(command.ToString());
        }

        dictCommands[Command.Crouch]    =   new CrouchCommand();
        dictCommands[Command.Jump]      =   new JumpCommand();
        dictCommands[Command.Roll]      =   new RollCommand();
        dictCommands[Command.Shoot]     =   new ShootCommand();
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
            ICCommand command = dictCommands[commands[val]];
            InputHandler.controller.SetCommand((int)key, command);
        });
    }
}
