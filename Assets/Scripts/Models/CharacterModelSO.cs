using UnityEngine;

[CreateAssetMenu(fileName = "CharacterModelSO", menuName = "Models/Character Model")]
public class CharacterModelSO : ScriptableObject, ICharacterModel
{
    public float maxHealth = 100f;
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float jumpForce = 12f;

    public float MaxHealth => maxHealth;
    public float MoveSpeed => moveSpeed;
    public float Speed => moveSpeed; 
    public float Acceleration => acceleration;
    public float JumpForce => jumpForce;
}
