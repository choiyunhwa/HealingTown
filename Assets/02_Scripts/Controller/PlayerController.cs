using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private GameObject player;
    private PlayerInforSO playerInfor;

    private void Awake()
    {
        playerInfor = DataManager.Instance.gameData.playerInfor;
        GameObject temp = GameObject.Instantiate(playerInfor.AniPrefab, player.transform.position, Quaternion.identity);
        temp.transform.parent = player.transform;

        playerName.text = DataManager.Instance.gameData.playerName;

        player.gameObject.SetActive(true);
    }
}
