using System.Collections.Generic;
using UnityEngine;

public class AliassesCommand : ICommand
{
    private readonly Dictionary<string, ICommand> commands;
    public AliassesCommand(Dictionary<string, ICommand> cmds) => commands = cmds;

    public string Name => "aliasses";
    public string[] Aliases => new[] { "aliasses", "a" };
    public string Description => "Displays the aliasses of a command.";

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Debug.Log("Use: aliasses <command>");
            return;
        }

        string name = args[0].ToLower();
        foreach (var cmd in commands.Values)
        {
            if (cmd.Name == name || System.Array.Exists(cmd.Aliases, a => a == name))
            {
                Debug.Log($"Alias de '{cmd.Name}': {string.Join(", ", cmd.Aliases)}");
                return;
            }
        }

        Debug.LogError($"Command '{name}' not found.");
    }
}
