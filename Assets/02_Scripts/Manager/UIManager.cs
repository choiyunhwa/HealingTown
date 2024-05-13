using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Action PlayerSettingViewEvent;
    public Action PeopleViewEvent;

    private const string MainView = "MainView";
    private const string PlayerSettingView = "PlayerSetting";
    private const string CheckPeopleView = "CheckPeopleView";

    private UIDocument doc;
    private UIView mainView;
    private UIView playerSettingView;
    private UIView peopleView;

    private List<UIView> uiView = new List<UIView>();

    private UIView currentView;
    private UIView preView;

    public void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (doc == null)
            doc = GetComponent<UIDocument>();

        InitSetting();

        PlayerSettingViewEvent += ShowPlayerSettingView;
        PeopleViewEvent += ShowCheckPeopleView;
    }

    public void InitSetting()
    {
        mainView = new MainView(doc.rootVisualElement.Q<VisualElement>(MainView));
        playerSettingView = new PlayerSettingView(doc.rootVisualElement.Q<VisualElement>(PlayerSettingView));
        peopleView = new CheckPeopleView(doc.rootVisualElement.Q<VisualElement>(CheckPeopleView));

        uiView.Add(mainView);
        uiView.Add(playerSettingView);
        uiView.Add(peopleView);
    }

    public void ShowSelectView(UIView _currentView)
    {
        if(currentView != null)
            currentView.Hide();

        preView = currentView;
        currentView = _currentView;

        if(currentView != null)
            currentView.Show();
    }

    public void ShowMainView()
    {
        mainView.Show();
        ShowSelectView(mainView);
    }
    public void ShowPlayerSettingView()
    {
        playerSettingView.Show();
        preView = currentView;
        ShowSelectView(playerSettingView);
    }
    public void ShowCheckPeopleView()
    {
        peopleView.Show();
        preView = currentView;
        ShowSelectView(peopleView);
    }  


}

