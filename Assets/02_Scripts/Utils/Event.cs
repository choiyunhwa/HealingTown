﻿using System;
using System.Collections.Generic;

public static class Event
{
    public static Action<List<PlayerInforSO>> PlayerUpdateEvent;
    public static Action<List<NPCInforSO>> AttendanceEvent;

    public static Action<GameData> UpdateGameData;

    public static Action<string> currentTime;

    public static Action<NPCValue> chatEvent;

}