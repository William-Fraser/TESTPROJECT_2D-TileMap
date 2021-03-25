using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public Text dialogueText;
    public GameObject player;
    public Animator animator;

    private Queue<string> dialogueQueue;



    // Start is called before the first frame update
    void Start()
    {
        dialogueQueue = new Queue<string>();

    }

    public void StartDialogue(string[] sentances)
    {
        dialogueQueue.Clear();
        dialogueUI.SetActive(true);

        player.GetComponent<PlayerMovement_2D>().enabled = false;

        animator.SetFloat("Speed", 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        foreach (string currentLine in sentances)
        { dialogueQueue.Enqueue(currentLine); }

        DisplayNextSentance();
    }
    public void DisplayNextSentance()
    {
        if (dialogueQueue.Count == 0)
        {
            Debug.Log("Empty Queue");
            EndDialogue();
            return;
        }
        //remeoves recent line
        string currentLine = dialogueQueue.Dequeue();
        //sets new line
        dialogueText.text = currentLine;
    }
    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
        player.GetComponent<PlayerMovement_2D>().enabled = true;
    }
}
