using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerSettingView : UIView
{
    private Button SelectCharacterBtn;
    private Button ChangeNameBtn;

    private VisualElement[] settingViews = new VisualElement[3];

    private List<string> name = new List<string>() { "SettingButtonsView", "SettingChracter_ListView", "SettingChracter_Name" };
    private VisualTreeAsset playerFrame;
    
    private GameData gameData;

    public PlayerSettingView(VisualElement _root) : base(_root)
    {

    }
    protected override void SetVisualElement()
    {
        base.SetVisualElement();

        gameData = DataManager.Instance.gameData;

        SelectCharacterBtn = root.Q<Button>("SelectChracter_Button");
        ChangeNameBtn = root.Q<Button>("ChangeName_Button");  

        for(int i = 0; i < name.Count; i++)
        {
            settingViews[i] = root.Q<VisualElement>(name[i]);
        }

        playerFrame = Resources.Load<VisualTreeAsset>("CharacterChoiceTemp");


        SelectCharacterBtn.clicked += OnClickSelectCh;
        ChangeNameBtn.clicked += OnClickChangeName;

        Event.PlayerUpdateEvent += UpdataCharacterData;
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

    private void OnClickChangeName()
    {
        
        ShowVisualElement(2);
    }

    private void OnClickSelectCh()
    {
        Event.PlayerUpdateEvent.Invoke(GameManager.Instance.players);
        ShowVisualElement(1);
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
        });

        parentVisual.Add(playerElem);
    }

}

