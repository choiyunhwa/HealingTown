using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainView : UIView
{
    private Button checkPeopleNumBtn;
    private Button playerSettingBtn;
    public Label timeLabel;

    public MainView(VisualElement _root) : base(_root)
    {

    }

    protected override void SetVisualElement()
    {
        base.SetVisualElement();

        checkPeopleNumBtn = root.Q<Button>("PlayPeople_Button");
        playerSettingBtn = root.Q<Button>("Setting_Button");
        timeLabel = root.Q<Label>("Time_Text");

        Event.currentTime += GetCurrentTime;

        checkPeopleNumBtn.clicked += OnClickVisitorsView;
        playerSettingBtn.clicked += OnClickPlayerSettingView;
    }

    protected override void RegisterButtonCallback()
    {
        base.RegisterButtonCallback();
    }
    public void GetCurrentTime(string time)
    {
        timeLabel.text = time;
    }

    private void OnClickVisitorsView()
    {
        GameManager.Instance.UpdateAttendData();
        Event.UpdateGameData?.Invoke(DataManager.Instance.gameData);
        UIManager.Instance.PeopleViewEvent?.Invoke();        
    }

    private void OnClickPlayerSettingView()
    {
        UIManager.Instance.PlayerSettingViewEvent?.Invoke();
    }
} 

