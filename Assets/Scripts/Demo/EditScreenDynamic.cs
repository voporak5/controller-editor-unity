//This is a quickly put together
//edit screen that demos a scenario when there
//are fewer actions than there are inputs
//such as a keyboard where the user can set
//the controls to any button on the keyboard

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Controller;
using System;

public class EditScreenDynamic : MonoBehaviour
{
    [SerializeField] private Transform root;
    [SerializeField] private DynamicEntry template;

    private DynamicEntry selected;

    private Dictionary<Command, DynamicEntry> dictEntries = new Dictionary<Command, DynamicEntry>();

 
    void Start()
    {
        BuildList();
        
    }

    void BuildList()
    {
        //Create an entry for every type of command except none
        foreach (int i in Enum.GetValues(typeof(Command)))
        {
            Command command = (Command)i;
            if (command == Command.None) continue;
            AddEntry(command);
        }

        //I used var because keyvalpair is a mouthful but
        //totally optional if keyvalpair is preferred
        var settings = InputHandler.controller.GetSettings();

        foreach(var setting in settings)
        {
            Command command = setting.Value.GetName();
            //If none then button doesn't have a command assigned
            //and dynamic entries default as none already
            if (command == Command.None) continue;

            dictEntries[command].SetButtonKey((KeyCode)setting.Key);
        }

        //Done with template so hide it or destroy it
        template.gameObject.SetActive(false);
    }

    void AddEntry(Command command)
    {
        DynamicEntry newEntry = Instantiate(template, root).GetComponent<DynamicEntry>();
        newEntry.Init(command, OnEntryClick);
        dictEntries[command] = newEntry;
    }

    void OnEntryClick(DynamicEntry entry)
    {
        if (selected != null) selected.ClearEditText();
        else InputHandler.KeyPressEvent += OnKeyPressed;

        selected = entry;
        selected.SetEditText();
    }

    void OnKeyPressed(KeyCode keycode)
    {
        if (selected == null) return;

        selected.SetButtonKey(keycode);
        InputHandler.controller.SetCommand((int)keycode, CommandFactory.Create(selected.command));
        selected = null;
        InputHandler.KeyPressEvent -= OnKeyPressed;
    }
}