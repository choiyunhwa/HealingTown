using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
public class ChatWindowView : UIView
{
    private VisualElement bottolmView;
    private VisualTreeAsset chatFrame;
    public ChatWindowView(VisualElement _root) : base(_root)
    {
        Event.chatEvent += ShowChatWindow;        
    }
    protected override void SetVisualElement()
    {
        base.SetVisualElement();

        bottolmView = root.Q<VisualElement>("BottomView");
        
        

        chatFrame = Resources.Load<VisualTreeAsset>("NPCChatWindowTemp");
    }

    private void ShowChatWindow(NPCValue value)
    {
        if(value.check == true)
        {
            CreatePeopleInfor(bottolmView, value.sprite);
        }
        else
        {
            bottolmView.Clear();
        }
    }

    private void CreatePeopleInfor(VisualElement parentVisual, Sprite sprite)
    {
        if (chatFrame == null)
            return;

        TemplateContainer inforElem = chatFrame.Instantiate();

        Label nameText = inforElem.Q<Label>("ChatLabel");
        VisualElement npcImg = inforElem.Q<VisualElement>("NPC_Chat_Img");
        Button closeButton = inforElem.Q<Button>("NPC_CloseBtn");

        nameText.text = "안녕!";
        npcImg.style.backgroundImage = new StyleBackground(sprite);

        closeButton.RegisterCallback<ClickEvent>((evt) =>
        {
            bottolmView.Clear();
        });

        parentVisual.Add(inforElem);
    }    
}
