using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Wiggle : MonoBehaviour {
    //private string path = "c:\\vgd\\movement.txt";
    private string path = "movement.txt";
    
    public  bool Record;
    public bool Playback;
    private System.IO.StreamReader file;


    // Use this for initialization
    void Start () {
        if (Record)
        {
            if (File.Exists(path)){
                File.Delete(path);
            }
        }

        if (Playback) {
            file = new StreamReader(path);
        }
	}
	
	// Update is called once per frame
	void Update () {
        string line = "";
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        if (!Playback)
        {
            transform.Translate(x, y, 0);
        }

        if (Record == true)
        {
            string marker = (Time.deltaTime).ToString() + "\t" + (transform.localPosition.x).ToString() + "\t" + (transform.localPosition.y).ToString() + "\r\n";
            File.AppendAllText(path, marker);
        }

        if (Playback == true)
        {
            if ((line = file.ReadLine()) != null)
            {
                //Debug.Log(line);
                string[] vals = line.Split('\t');
                string Tt = vals[0];
                string Tx = vals[1];
                string Ty = vals[2];
                float dt = float.Parse(Tt);
                //Debug.Log(Tx);
                x = float.Parse(Tx) ;
                y = float.Parse(Ty) ;
                //transform.Translate(x, y, 0);
                
                transform.position = new Vector3(x, y, 0);
                
            } else
            {
                file.Close();
                Playback = false;
            }
            
        }


    }
}
