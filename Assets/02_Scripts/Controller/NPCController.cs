using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NPCValue
{
    public bool check;
    public Sprite sprite;

    public NPCValue(bool _check, Sprite _sprite)
    {
        this.check = _check;
        this.sprite = _sprite;
    }
}

public class NPCController : MonoBehaviour
{
    private string targetTag = "Player";
    private string objectName = null;
    private NPCValue npcValue;

    private void Start()
    {
        npcValue = new NPCValue(false, null);
        objectName = gameObject.name.Replace("(Clone)", "");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (!collision.CompareTag(targetTag))
            return;
        
        for(int i = 0; i < GameManager.Instance.attendance.Count; i++) 
        {
            if (GameManager.Instance.attendance[i].AniPrefab.name == objectName)
            {
                npcValue.sprite = GameManager.Instance.attendance[i].sprite;
                npcValue.check = true;
                break;
            }
            Debug.Log(GameManager.Instance.attendance[i].AniPrefab.name);
            Debug.Log(this.gameObject.name);
        }       

        Event.chatEvent?.Invoke(npcValue);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(targetTag))
            return;

        npcValue.sprite = null;
        npcValue.check = false;
        Event.chatEvent?.Invoke(npcValue);
    }

}
