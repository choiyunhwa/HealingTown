
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class ChoicePlayerView : MonoBehaviour
{
    //public static Action<List<PlayerInforSO>> PlayerUpdateEvent;

    private UIDocument document;

    
    private VisualElement playerList;
    private VisualTreeAsset playerFrame;
    private VisualElement playerNameFrame;
    private TextField playerNameTextField;
    private Button playButton;

    private bool isInputComplete = false;

    GameData gameData;
    private void Awake()
    {
        gameData = new GameData();
        document = GetComponent<UIDocument>(); 
        playerFrame = Resources.Load<VisualTreeAsset>("CharacterChoiceTemp");
        Event.PlayerUpdateEvent += UpdateCharacterData;

        SetVisualElement();
        RegisterButtonCallback();

        playerNameFrame.style.display = ShowDisPlay(false);
        playButton.SetEnabled(false);
    }

    private void SetVisualElement()
    {    
        VisualElement root = document.rootVisualElement;

        playerList = root.Q<VisualElement>("CharcterListView");
        playerNameFrame = root.Q<VisualElement>("CharacterNameView");
        playerNameTextField = root.Q<TextField>("ChracterName_TextField");

        playButton = root.Q<Button>("PlayButton");
    }

    private void RegisterButtonCallback()
    {
        playerNameTextField.RegisterCallback<KeyUpEvent>(SetPlayerTextField);
        playButton.RegisterCallback<ClickEvent>(OnClickPlayButton);
    }

    private void UpdateCharacterData(List<PlayerInforSO> playerTypes)
    {

        foreach(PlayerInforSO playerType in playerTypes)
        {
            CreatePlayerImg(playerType, playerList);
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

        switch(playerType.spriteType)
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
            gameData.playerInfor = playerType;

            playerList.style.display = ShowDisPlay(false);
            playerNameFrame.style.display = ShowDisPlay(true);
            Event.UpdateGameData?.Invoke(gameData);
        });

        parentVisual.Add(playerElem);
    }

    private void SetPlayerTextField(KeyUpEvent evt)
    {
        var textField = evt.target as TextField;

        string name = textField.value;
        if(name.Length >=2 && name.Length <=10 )
        {
            gameData.playerName = name;
            Event.UpdateGameData?.Invoke(gameData);

            isInputComplete = true;
            playButton.SetEnabled(true);
        }
        else
            isInputComplete = false;
    }

    private void OnClickPlayButton(ClickEvent evt)
    {
        if(isInputComplete)
        {
            SceneManager.LoadScene("GamaMain");
        }
    }
    

    private DisplayStyle ShowDisPlay(bool value)
    {
        DisplayStyle type = value ? DisplayStyle.Flex : DisplayStyle.None;

        return type;
    }
}
