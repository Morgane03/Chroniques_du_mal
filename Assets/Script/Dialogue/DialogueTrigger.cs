using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] TextAsset InkJSON;

    private bool playerInRange;

    private void Awake()
    {
        
        visualCue.SetActive(false);
    }

    private void Start()
    {
        playerInRange = true;
    }

    private void Update()
    {
        if(playerInRange)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log(InkJSON.text);
                DialogueManager.GetInstance().EnterDialogueMode(InkJSON);
            }
        }
        else
        {
            visualCue?.SetActive(false);
        }
    }



}
