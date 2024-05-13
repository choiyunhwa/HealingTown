using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GameSetting : MonoBehaviour
{
    [SerializeField] private List<Transform> pos = new List<Transform>();
    private void Start()
    {
        RandomSpawn();
    }
    private void RandomSpawn()
    {
        int num = Random.Range(0, pos.Count);

        for (int i = 0; i < GameManager.Instance.attendance.Count; i++)
        {
            GameObject go = Instantiate(GameManager.Instance.attendance[i].AniPrefab);
            if (pos[num].childCount == 0)
            {
                go.transform.SetParent(pos[num]);
                go.transform.localPosition = Vector3.zero;
            }
            else
            {
                continue;
            }

        }
    }
}
