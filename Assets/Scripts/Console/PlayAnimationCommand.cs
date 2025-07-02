using UnityEngine;

public class PlayAnimationCommand : ICommand
{
    public string Name => "playanimation";
    public string[] Aliases => new[] { "anim", "animation" };
    public string Description => "Plays an animation on all characters.";

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Debug.Log("Use: playanimation <AnimationName>");
            return;
        }

        string animationName = args[0];
        var animators = GameObject.FindObjectsOfType<Animator>();

        foreach (var animator in animators)
        {
            var clips = animator.runtimeAnimatorController.animationClips;
            if (System.Array.Exists(clips, clip => clip.name == animationName))
            {
                animator.Play(animationName);
            }
        }

        Debug.Log($"Playing animation: {animationName}");
    }
}