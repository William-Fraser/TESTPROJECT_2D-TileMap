using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{
    [Header("Information Object")]
    [Tooltip("Object gives small amount of info about themselves")]
    public bool info = false;
    [Tooltip("Displayed Text")]
    public string message;
    [Tooltip("Amount of time until message dissappears")]
    public float displayTime;
    private Text infoText;

    [Header("Collectable Object")]
    [Tooltip("Object can be picked up")]
    public bool pickup = false;

    [Header("Dialogue Object")]
    [Tooltip("Object displays text box and chain of dialogue")]
    public bool talks = false;
    [TextArea]
    public string[] sentances;

    private Interactable _InteractableState;
    private enum Interactable{ 
        STATE_NULL,
        STATE_INFO,
        STATE_PICKUP
    
    };

    void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
    }    
    public void Info()
    {
        Debug.Log("this is a "+ this.gameObject.name);
        StartCoroutine(ShowInfo(message, displayTime));
    }
    public void Pickup()
    {
        Debug.Log("picked up a " + this.gameObject.name);
        this.gameObject.SetActive(false);
    }
    public void Talks()
    {
        Debug.Log("you're looking at " + this.gameObject.name);
        FindObjectOfType<DialogueManager>().StartDialogue(sentances);
    }
    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = null;
    }
}
