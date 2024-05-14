using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine;
public class CheckPeopleView : UIView
{
    private VisualElement AttendanceList;
    private Button closeButton;

    private VisualTreeAsset inforFrame;
    public CheckPeopleView(VisualElement _root) : base(_root)
    {
        Event.AttendanceEvent += UpdatePeopleInfor;
        Event.UpdateGameData += UpdatePlayerInfor;
    }
    protected override void SetVisualElement()
    {
        base.SetVisualElement();
        AttendanceList = root.Q<VisualElement>("CheckPeople_ListView");
        closeButton = root.Q<Button>("CheckPeople_CloseButton");

        inforFrame = Resources.Load<VisualTreeAsset>("CheckPeopleTemp");          
        
    }
    protected override void RegisterButtonCallback()
    {
        base.RegisterButtonCallback();
        closeButton.clicked += OnClickCloseButton;
    }

    private void UpdatePeopleInfor(List<NPCInforSO> peoples)
    {
        if(AttendanceList.childCount != null)
            AttendanceList.Clear();

        foreach (NPCInforSO people in peoples)
        {
            CreatePeopleInfor(people, AttendanceList);
        }
    }

    private void UpdatePlayerInfor(GameData data)
    {
        CreatePeopleInfor(data, AttendanceList);
    }

    private void CreatePeopleInfor(NPCInforSO person, VisualElement parentVisual)
    {
        if (inforFrame == null)
            return;

        TemplateContainer inforElem = inforFrame.Instantiate();

        Label nameText = inforElem.Q<Label>("CheckPeople_text");
        
        if(person as NPCInforSO)
            nameText.text = person.name;
            
        parentVisual.Add(inforElem);
    }

    private void CreatePeopleInfor(GameData person, VisualElement parentVisual)
    {
        if (inforFrame == null)
            return;

        TemplateContainer inforElem = inforFrame.Instantiate();

        Label nameText = inforElem.Q<Label>("CheckPeople_text");
        nameText.text = person.playerName;

        parentVisual.Add(inforElem);
    }


    private void OnClickCloseButton()
    {
        AttendanceList.Clear();
        Hide();
    }
}
