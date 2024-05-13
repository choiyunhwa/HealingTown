using UnityEngine;

public enum EspriteType
{
    BASIC,
    MIDDLE,
}

[CreateAssetMenu(fileName = "Assets/Resources/Player/PlayerData", menuName = "Person/Player", order = 0)]
public class PlayerInforSO : PersonInforSO
{
    public EspriteType spriteType = EspriteType.BASIC;
}