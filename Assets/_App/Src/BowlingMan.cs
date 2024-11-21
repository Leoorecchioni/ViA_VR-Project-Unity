using System;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class BowlingMan : MonoBehaviour
{
    List<Grabbable> currentlyGrabbed = new();
    List<Grabbable> _myGrabbables = new();
    AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _myGrabbables = new List<Grabbable>(GetComponentsInChildren<Grabbable>());

        Grabber[] grabbers = FindObjectsOfType<Grabber>();

        foreach (Grabber grabber in grabbers)
        {
            grabber.onGrabEvent.AddListener(OnGrab);
            grabber.onReleaseEvent.AddListener(OnRelease);
        }
    }

    private void OnGrab(Grabbable grabbable)
    {
        if (_myGrabbables.Contains(grabbable))
        {
            currentlyGrabbed.Add(grabbable);
        }
    }

    private void OnRelease(Grabbable grabbable)
    {
        if (_myGrabbables.Contains(grabbable))
        {
            currentlyGrabbed.Remove(grabbable);

            if (currentlyGrabbed.Count <= 0)
            {
                Scream();
            }
        }
    }

    void Scream()
    {
        Debug.Log(nameof(Scream));
        _audioSource.Play();
    }
}
