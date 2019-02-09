using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteGridMaker : MonoBehaviour
{
    GameObject note;
    float[] major = { 0 / 12f, 2 / 12f, 4 / 12f, 5 / 12f, 7 / 12f, 9 / 12f, 11 / 12f, 12 / 12f };
    // Use this for initialization
    void Start()
    {
        note = Resources.Load("Note") as GameObject;
        for (int j = 0; j < 16; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject newNote = Instantiate(note, new Vector3(0f, -1.1f, (i * 1.5f + 2)), Quaternion.identity);
                newNote.name = "step" + (j + 1) + "note" + (i + 1);
                AudioSource audio = newNote.GetComponent<AudioSource>();
                audio.pitch = 1 + (major[i]);
                newNote.transform.RotateAround(Vector3.zero, Vector3.up, (j * 22.5f));

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}