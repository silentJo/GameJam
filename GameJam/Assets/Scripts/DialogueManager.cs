using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [SerializeField] private Image NPCIcon;
    [SerializeField] private Image RequestIcon;
    [SerializeField] private Text RequestedNumber;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");
            return;
        }
        instance = this;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        NPCIcon.sprite = dialogue.NPCIcon.sprite;
        RequestIcon.sprite = dialogue.RequestIcon.sprite;
        RequestedNumber.text = dialogue.RequestedNumber;
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}