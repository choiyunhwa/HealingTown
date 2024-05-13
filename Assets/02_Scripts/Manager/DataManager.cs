using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public GameData gameData;

    private void Awake()
    {
        if(Instance != null) 
            Destroy(gameObject);
        else
        {
            Instance = this;    
            DontDestroyOnLoad(gameObject);
        }

        Event.UpdateGameData += UpdatePlayerData;
    }
    private void UpdatePlayerData(GameData data)
    {
        gameData = data;
    }
}
