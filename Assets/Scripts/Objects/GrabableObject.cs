﻿using System.Collections;
using VRTK;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour
{
    public AudioSource mySound;

    // a scriptfor objects that can be grabbed...
    void Start ()
    {
        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            Debug.LogError("This requires to be attached to an Object that has the VRTK_InteractableObject script attached to it");
            return;
        }
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);
    }

    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        mySound.Play();
    }
}
