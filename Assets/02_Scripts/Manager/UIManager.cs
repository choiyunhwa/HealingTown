using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Action PlayerSettingViewEvent;
    public Action PeopleViewEvent;

    private const string MainView = "MainView";
    private const string PlayerSettingView = "PlayerSetting";
    private const string CheckPeopleView = "CheckPeopleView";
    private const string BaseView = "BaseView";


    private UIDocument doc;
    private UIView mainView;
    private UIView playerSettingView;
    private UIView peopleView;

    private UIView chatView;

    private List<UIView> uiView = new List<UIView>();

    private UIView currentView;

    public void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
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

        chatView = new ChatWindowView(doc.rootVisualElement.Q<VisualElement>(BaseView));

        uiView.Add(mainView);
        uiView.Add(playerSettingView);
        uiView.Add(peopleView);
    }

    public void ShowSelectView(UIView _currentView)
    {
        if(currentView != null)
            currentView.Hide();

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
        ShowSelectView(playerSettingView);
    }
    public void ShowCheckPeopleView()
    {
        peopleView.Show();
        ShowSelectView(peopleView);
    }  


}

