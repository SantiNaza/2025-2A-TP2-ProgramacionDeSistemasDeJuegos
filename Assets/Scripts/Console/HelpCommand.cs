using System.Collections.Generic;
using UnityEngine;

public class HelpCommand : ICommand
{
    private readonly Dictionary<string, ICommand> commands;
    public HelpCommand(Dictionary<string, ICommand> cmds) => commands = cmds;

    public string Name => "help";
    public string[] Aliases => new[] { "help", "h" };
    public string Description => "Displays help about a command.";

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Debug.Log("Use: help <command>");
            return;
        }

        string name = args[0].ToLower();
        foreach (var cmd in commands.Values)
        {
            if (cmd.Name == name || System.Array.Exists(cmd.Aliases, a => a == name))
            {
                Debug.Log($"{cmd.Name}: {cmd.Description}");
                return;
            }
        }

        Debug.LogError($"Command '{name}' not found.");
    }
}