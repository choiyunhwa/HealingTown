using UnityEngine.UIElements;

public class UIView
{
    protected VisualElement root;

    public UIView(VisualElement _root)
    {
        root = _root;

        SetVisualElement();
        RegisterButtonCallback();
    }

    protected virtual void SetVisualElement()
    {

    }

    protected virtual void RegisterButtonCallback()
    {

    }

    public virtual void Show()
    {
        root.style.display = ShowDisPlay(true);
    }

    public virtual void Hide() 
    {
        root.style.display = ShowDisPlay(false);
    }

    public DisplayStyle ShowDisPlay(bool value)
    {
        DisplayStyle type = value ? DisplayStyle.Flex : DisplayStyle.None;

        return type;
    }

}

