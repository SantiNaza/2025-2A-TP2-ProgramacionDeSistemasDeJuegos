using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerControllerModelSO", menuName = "Models/Player Controller Model")]
public class PlayerControllerModelSO : ScriptableObject, IPlayerControllerModel
{
    [Header("Input Actions (InputActionReference)")]
    public InputActionReference moveInput;
    public InputActionReference jumpInput;

    [Header("Aire")]
    public float airborneSpeedMultiplier = 0.75f;

    public InputActionReference MoveInput => moveInput;
    public InputActionReference JumpInput => jumpInput;
    public float AirborneSpeedMultiplier => airborneSpeedMultiplier;
}
