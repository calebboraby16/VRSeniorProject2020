﻿using System.Collections;
using VRTK;
using UnityEngine;

// https://github.com/thestonefox/VRTK/issues/643

public class ScoreObjectVR : MonoBehaviour
{

    private GameManager gameScript;
    private bool isScored = false;

    public int objectWorth = 10;
    public AudioSource mySound;

    // initialize the reference to the GameManager script
    void Start()
    {
        gameScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            Debug.LogError("This requires to be attached to an Object that has the VRTK_InteractableObject script attached to it");
            return;
        }
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);
    }

    // add this object's score worth to the total score
    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        if (!isScored)
        {
            gameScript.AddToScore(objectWorth);
            mySound.Play();
            isScored = true;

            Destroy(gameObject, 3f);
        }
    }

    private IEnumerable DelayedRemove(int sec)
    {
        print("Past waiting");
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
