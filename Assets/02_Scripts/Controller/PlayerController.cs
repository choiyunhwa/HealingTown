using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private GameObject player;
    private PlayerInforSO playerInfor;
    private GameObject createPlayer;

    private void Awake()
    {
        PlayerSetting();
        player.gameObject.SetActive(true);
        Event.UpdateGameData += UpdatePlayerDate;
    }

    private void UpdatePlayerDate(GameData data)
    {
        player.gameObject.SetActive(false);
        StartCoroutine(CoPlayerSetting());
    }
    IEnumerator CoPlayerSetting()
    {
        if (createPlayer != null)
        {
            Destroy(createPlayer);
        }
        PlayerSetting();
        yield return null;

        player.gameObject.SetActive(true);

        yield break;
    }
    private void PlayerSetting()
    {
        playerInfor = DataManager.Instance.gameData.playerInfor;

        createPlayer = GameObject.Instantiate(playerInfor.AniPrefab, player.transform.position, Quaternion.identity);
        createPlayer.transform.parent = player.transform;

        playerName.text = DataManager.Instance.gameData.playerName;
    }


}
