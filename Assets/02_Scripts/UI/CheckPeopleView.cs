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
    }
    protected override void SetVisualElement()
    {
        base.SetVisualElement();
        AttendanceList = root.Q<VisualElement>("CheckPeople_ListView");
        closeButton = root.Q<Button>("CheckPeople_CloseButton");

        inforFrame = Resources.Load<VisualTreeAsset>("CheckPeopleTemp");

        Event.AttendanceEvent += UpdatePeopleInfor;
    }

    protected override void RegisterButtonCallback()
    {
        base.RegisterButtonCallback();
        closeButton.clicked += OnClickCloseButton;
    }

    private void UpdatePeopleInfor(List<PersonInforSO> peoples)
    {
        foreach(PersonInforSO people in peoples)
        {
            CreatePeopleInfor(people, AttendanceList);
        }
    }

    private void CreatePeopleInfor(PersonInforSO person, VisualElement parentVisual)
    {
        if (inforFrame == null)
            return;

        TemplateContainer inforElem = inforFrame.Instantiate();

        Label nameText = inforElem.Q<Label>("CheckPeople_text");
        nameText.text = person.name;
            
        parentVisual.Add(inforElem);
    }


    private void OnClickCloseButton()
    {
        Hide();
    }
}

