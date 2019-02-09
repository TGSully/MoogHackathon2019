using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class listener : MonoBehaviour {
    SerialPort stream;
    const string PORTNAME = "/dev/tty.usbmodemFA131";

    void OnEnable()
    {
        collisionDetection.OnPlay += Play;
    }


    // Use this for initialization
    void Start () {
        stream = new SerialPort(PORTNAME, 57600, Parity.None, 8, StopBits.One);
        stream.Open();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Play(int note)
    {
        print(note);
        stream.WriteLine("recieved");
        stream.BaseStream.Flush();
    }
}
