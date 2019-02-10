using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Threading;

public class circles : MonoBehaviour {
    private static Thread bg;
    static List<int[]> positions;
	// Use this for initialization
	void Start () {
        positions = new List<int[]>();
        bg = new Thread(new ThreadStart(GetMessages));
        bg.IsBackground = true;
        bg.Start();
	}

    // Update is called once per frame
	void Update () {
        float planeWidth = 40;
        float planeHeight = 30;
        float width = 256;
        float height = 192;
        float offsetX = 20;
        float offsetY = 15;


        print(positions.Count);
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
        foreach(GameObject note in notes)
        {
            Vector3 p = note.transform.position;
            p.y = -1.1f;
            note.transform.position = p;
        }

        foreach(int[] position in positions)
        {
            float x = position[0] / (width / planeWidth) - offsetX;
            float z = position[1] / (height / planeHeight) - offsetY;

            //float x = (position[0] / 10f) - 20;
            //float z = (position[1] / 10f) - 15;

            print(x + " " + z);
            Vector3 p = new Vector3(x, -1.1f, -z);
            foreach (GameObject note in notes) 
            {
                float dist = Vector3.Distance(p, note.transform.position);
                if (dist < 1.4f) {
                    Vector3 shiftUp = note.transform.position;
                    shiftUp.y = 0;
                    note.transform.position = shiftUp;
                    break;
                }
            }
        }
	}

    static void GetMessages() {
        TcpClient client;
        NetworkStream stream;

        try
        {
            client = new TcpClient("127.0.0.1", 8000);
            stream = client.GetStream();
            while (true)
            {
                List<int[]> coords = new List<int[]>();
                byte[] data = new byte[64];
                int bytes = stream.Read(data, 0, data.Length);
                for (int i = 0; i < bytes; i++)
                {

                    int x = (int)data[i++];
                    int y = (int)data[i];
                    //print(x+ " " + y);
                    int[] coord = { x, y };
                    coords.Add(coord);
                }
                positions = coords;
                //print("bytes: " + bytes);
                //print(data);
            }
        }
        catch (SocketException e)
        {
            print(e);
        }
    }
}
