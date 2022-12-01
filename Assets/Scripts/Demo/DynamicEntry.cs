using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Controller;

public class DynamicEntry : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] TextMeshProUGUI buttonLabel;
    [SerializeField] Button button;

    public Command command { get; private set; }
    private KeyCode keycode;

    public void Init(Command command,Action<DynamicEntry> onClick)
    {
        this.command = command;
        label.text = command.ToString();
        buttonLabel.text = "None";
        button.onClick.AddListener(() => { onClick(this); });
    }

    public void SetButtonKey(KeyCode keycode)
    {
        this.keycode = keycode;
        buttonLabel.text = keycode.ToString();
    }

    public void SetEditText()
    {
        buttonLabel.text = "Set Key";
    }

    public void ClearEditText()
    {
        buttonLabel.text = keycode.ToString();
    }
}