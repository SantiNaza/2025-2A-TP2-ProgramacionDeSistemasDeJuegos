using UnityEngine;

public interface ICharacterFactory
{
    GameObject CreateCharacter(Vector3 position, Quaternion rotation);
}
