
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChoicePlayerView : UIView
{
    public static Action PlayerUpdateEvent;

    public VisualElement playerList;

    private VisualTreeAsset playerFrame;

    public ChoicePlayerView(VisualElement _root) : base(_root)
    {
        playerFrame = Resources.Load<VisualTreeAsset>("CharacterChoiceTemp");
        PlayerUpdateEvent += UpdateCharacterData;
    }

    protected override void SetVisualElement()
    {
        base.SetVisualElement();
        playerList = root.Q<VisualElement>("CharcterListView");
    }

    protected override void RegisterButtonCallback()
    {
        base.RegisterButtonCallback();
    }

    private void UpdateCharacterData()
    {
        CreatePlayerImg(playerList);
    }

    private void CreatePlayerImg(VisualElement parentVisual)
    {
        if (playerFrame == null)
            return;

        //https://docs.unity3d.com/ScriptReference/UIElements.TemplateContainer.html
        TemplateContainer playerElem = playerFrame.Instantiate();

        VisualElement img = playerElem.Q<VisualElement>("Character_Img");

        img.RegisterCallback<ClickEvent>((evt) =>
        {
            //캐릭터 정보 보내기
        });

        parentVisual.Add(playerElem);
    }
}
