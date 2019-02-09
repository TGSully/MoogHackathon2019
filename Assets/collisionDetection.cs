using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    public AudioClip mySound;
    public float volume;
    AudioSource audio;

    public delegate void PlayAction(int note);
    public static event PlayAction OnPlay;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        print(name);
        //print("note"); // eventually 
        if (col.gameObject.name != "Plane")
        {
            if (audio)
            {
                audio.PlayOneShot(mySound, volume);
                if (OnPlay != null)
                {
                    OnPlay(1);
                }
            }
            //print("CoLLISion!!");
        }
    }
}



