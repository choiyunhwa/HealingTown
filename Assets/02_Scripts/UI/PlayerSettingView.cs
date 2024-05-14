using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSettingView : UIView
{

    private bool isInputComplete = false;

    private Button selectCharacterBtn;
    private Button changeNameBtn;
    private Button closeBtn;
    private Button CheckBtn;

    private List<string> name = new List<string>() { "SettingButtonsView", "SettingChracter_ListView", "SettingChracter_Name" };
    private VisualElement[] settingViews = new VisualElement[3];
    private VisualTreeAsset playerFrame;

    private TextField playerName;

    private GameData gameData;

    public PlayerSettingView(VisualElement _root) : base(_root)
    {
        selectCharacterBtn.clicked += OnClickSelectCh;
        changeNameBtn.clicked += OnClickChangeName;
        closeBtn.clicked += OnClickClose;
        CheckBtn.clicked += OnClickCheck;
        Event.PlayerUpdateEvent += UpdataCharacterData;
    }

    
    protected override void SetVisualElement()
    {
        base.SetVisualElement();

        gameData = DataManager.Instance.gameData;

        selectCharacterBtn = root.Q<Button>("SelectChracter_Button");
        changeNameBtn = root.Q<Button>("ChangeName_Button");
        closeBtn = root.Q<Button>("Setting_CloseButton");
        CheckBtn = root.Q<Button>("Setting_PlayButton");

        for (int i = 0; i < name.Count; i++)
        {
            settingViews[i] = root.Q<VisualElement>(name[i]);
        }

        playerFrame = Resources.Load<VisualTreeAsset>("CharacterChoiceTemp");

        playerName = root.Q<TextField>("Setting_Name_TextField");

        CheckBtn.SetEnabled(false);
    }
    protected override void RegisterButtonCallback()
    {
        base.RegisterButtonCallback();
        playerName.RegisterCallback<KeyDownEvent>(ChangePlayerName);
    }
    private void OnClickChangeName()
    {        
        ShowVisualElement(2);
    }

    private void OnClickSelectCh()
    {
        Event.PlayerUpdateEvent.Invoke(GameManager.Instance.players);
        ShowVisualElement(1);
    }

    private void OnClickClose()
    {
        Hide();
    }

    private void ShowVisualElement(int num)
    {
        for(int i = 0; i < name.Count; i++)
        {
            if (i == num)
                settingViews[i].style.display = DisplayStyle.Flex;
            else
                settingViews[i].style.display = DisplayStyle.None;
        }
    }

    private void UpdataCharacterData(List<PlayerInforSO> playerTypes)
    {
        foreach (PlayerInforSO playerType in playerTypes)
        {
            CreatePlayerImg(playerType, settingViews[1]);
        }
    }

    private void CreatePlayerImg(PlayerInforSO playerType, VisualElement parentVisual)
    {
        if (playerFrame == null)
            return;

        //https://docs.unity3d.com/ScriptReference/UIElements.TemplateContainer.html
        TemplateContainer playerElem = playerFrame.Instantiate();

        VisualElement frame = playerElem.Q<VisualElement>("Character_Frame");
        VisualElement img = playerElem.Q<VisualElement>("Character_Img");

        switch (playerType.spriteType)
        {
            case EspriteType.BASIC:
                img.AddToClassList("PlayerMale");
                break;
            case EspriteType.MIDDLE:
                img.AddToClassList("PlayerWhite");
                break;
        }

        img.style.backgroundImage = new StyleBackground(playerType.sprite);

        frame.RegisterCallback<PointerDownEvent>((evt) =>
        {
            //캐릭터가 변경되어야함
            gameData.playerInfor = playerType;
            Event.UpdateGameData?.Invoke(gameData);
            Hide();
        });

        parentVisual.Add(playerElem);
    }

    private void ChangePlayerName(KeyDownEvent evt)
    {
        var textField = evt.target as TextField;   

        string name = textField.value;
        if (name.Length >= 2 && name.Length <= 10)
        {
            gameData.playerName = name;           

            isInputComplete = true;
            CheckBtn.SetEnabled(true);
        }
        else
            isInputComplete = false;
    }

    private void OnClickCheck()
    {
        //플레이어 이름 저장 후 페이지 닫힘
        if(isInputComplete)
            Event.UpdateGameData?.Invoke(gameData);

        Hide();
    }


}

