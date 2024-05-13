using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Resources/Player/PlayerData", menuName = "Person", order = 0)]
public class PersonInforSO : ScriptableObject
{
    public Sprite sprite;
    public GameObject AniPrefab;

    public float speed = 0f;
}
