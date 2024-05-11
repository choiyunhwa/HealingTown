using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSettingView : UIView
{
    private Button SelectCharacterBtn;
    private Button ChangeNameBtn;

    public PlayerSettingView(VisualElement _root) : base(_root)
    {
    }
    protected override void SetVisualElement()
    {
        base.SetVisualElement();

        SelectCharacterBtn = root.Q<Button>("SelectChracter_Button");
        ChangeNameBtn = root.Q<Button>("ChangeName_Button");

        SelectCharacterBtn.clicked += OnClickSelectCh;
        ChangeNameBtn.clicked += OnClickChangeName;
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
        Debug.Log("OnClickChangeName");
    }

    private void OnClickSelectCh()
    {
        Debug.Log("OnClickSelectCh");
    }

}

