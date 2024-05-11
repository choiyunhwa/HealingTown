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


        checkPeopleNumBtn.clicked += OnClickVisitorsView;
        playerSettingBtn.clicked += OnClickPlayerSettingView;
    }

    protected override void RegisterButtonCallback()
    {
        base.RegisterButtonCallback();
    }

    public override void Show()
    { 
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }

    public void GetCurrentTime(string time)
    {

    }

    private void OnClickVisitorsView()
    {
        UIManager.instance.PeopleViewEvent?.Invoke();        
    }

    private void OnClickPlayerSettingView()
    {
        UIManager.instance.PlayerSettingViewEvent?.Invoke();
    }
}

