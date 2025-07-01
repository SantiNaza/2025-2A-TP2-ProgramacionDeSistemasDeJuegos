using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterFactory", menuName = "Spawning/Character Factory")]
public class CharacterFactorySO : ScriptableObject, ICharacterFactory
{
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private ScriptableObject modelData; 
    [SerializeField] private ScriptableObject controllerData; 

    public GameObject CreateCharacter(Vector3 position, Quaternion rotation)
    {
        GameObject characterGO = GameObject.Instantiate(characterPrefab, position, rotation);

       foreach (var comp in characterGO.GetComponents<MonoBehaviour>())
    {
        if (comp is ISetup<ICharacterModel> characterSetup && modelData is ICharacterModel model)
            characterSetup.Setup(model);

        if (comp is ISetup<IPlayerControllerModel> controllerSetup && controllerData is IPlayerControllerModel controller)
            controllerSetup.Setup(controller);
    }

        return characterGO;
    }
}
