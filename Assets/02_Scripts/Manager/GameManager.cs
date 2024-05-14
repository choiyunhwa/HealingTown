using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<PlayerInforSO> players = new List<PlayerInforSO>();
    public List<PersonInforSO> attendance = new List<PersonInforSO>();

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        Event.PlayerUpdateEvent.Invoke(players);        
    }

    private void Update()
    {
        Event.currentTime?.Invoke(DateTime.Now.ToString(" HH:mm "));
    }

    public void UpdateAttendData()
    {
        Event.AttendanceEvent?.Invoke(attendance);        
    }


}
