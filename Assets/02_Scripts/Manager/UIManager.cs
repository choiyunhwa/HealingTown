using System;
using System.Collections;
using System.Collections.Generic;
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
    private const string CheckPeopleView = "";

    private UIDocument doc;
    private UIView mainView;
    private UIView playerSettingView;
    private UIView peopleView;

    private List<UIView> uiView = new List<UIView>();

    private UIView currentView;

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
        ShowMainView();

        PlayerSettingViewEvent += ShowPlayerSettingView;
        PeopleViewEvent += ShowCheckPeopleView;
    }

    public void InitSetting()
    {
        mainView = new MainView(doc.rootVisualElement.Q<VisualElement>(MainView));
        playerSettingView = new PlayerSettingView(doc.rootVisualElement.Q<VisualElement>(PlayerSettingView));
        peopleView = new CheckPeopleView(doc.rootVisualElement.Q<VisualElement>(CheckPeopleView));

        uiView.Add(playerSettingView);
        uiView.Add(peopleView);

    }
    public void Update()
    {
       
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

    private string GetCurrentDate()
    {
        return DateTime.Now.ToString(" HH:mm ");
    }
    

}

