using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CommandConsole : MonoBehaviour, ILogHandler
{
    [Header("UI")]
    public GameObject consolePanel;
    public TMP_InputField inputField;
    public TextMeshProUGUI outputText;
    public Button toggleButton;

    private Dictionary<string, ICommand> commands = new();
    private ILogHandler defaultLogger;

    private void Awake()
    {
        defaultLogger = Debug.unityLogger.logHandler;
        Debug.unityLogger.logHandler = this;

        RegisterCommand(new HelpCommand(commands));
        RegisterCommand(new AliassesCommand(commands));
        RegisterCommand(new PlayAnimationCommand());

        toggleButton.onClick.AddListener(ToggleConsole);
        consolePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) ToggleConsole();
    }

    public void OnInputSubmit()
    {
        string input = inputField.text;
        inputField.text = "";
        ExecuteInput(input);
    }

    private void ExecuteInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return;
        LogFormat(LogType.Log, null, "> {0}", input);

        string[] parts = input.Split(' ');
        string cmdName = parts[0].ToLower();
        string[] args = parts.Length > 1 ? parts[1..] : new string[0];

        foreach (var cmd in commands.Values)
        {
            if (cmd.Name == cmdName || System.Array.Exists(cmd.Aliases, a => a == cmdName))
            {
                cmd.Execute(args);
                return;
            }
        }

        Debug.LogError($"Command '{cmdName}' not found.");
    }

    private void RegisterCommand(ICommand command)
    {
        commands[command.Name] = command;
    }

    private void ToggleConsole()
    {
        consolePanel.SetActive(!consolePanel.activeSelf);
    }
    public void LogFormat(LogType logType, Object context, string format, params object[] args)
    {
        defaultLogger.LogFormat(logType, context, format, args);
        outputText.text += string.Format(format, args) + "\n";
    }

    public void LogException(System.Exception exception, Object context)
    {
        defaultLogger.LogException(exception, context);
        outputText.text += exception.Message + "\n";
    }
}
