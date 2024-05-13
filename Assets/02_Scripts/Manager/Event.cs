using System;
using System.Collections.Generic;

public static class Event
{
    public static Action<List<PlayerInforSo>> PlayerUpdateEvent;
    public static Action<GameData> UpdateGameData;

}