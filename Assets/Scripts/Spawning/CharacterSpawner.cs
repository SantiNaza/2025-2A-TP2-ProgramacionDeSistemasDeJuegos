using UnityEngine;

public class CharacterSpawner : MonoBehaviour, ISetup<ICharacterFactory>
{
    private ICharacterFactory characterFactory;

    public void Setup(ICharacterFactory factory)
    {
        characterFactory = factory;
    }

    public void Spawn()
    {
        Vector3 pos = GetRandomPosition();
        Quaternion rot = Quaternion.identity;
        characterFactory.CreateCharacter(pos, rot);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-5f, 5f), 0f, 0f);
    }
}