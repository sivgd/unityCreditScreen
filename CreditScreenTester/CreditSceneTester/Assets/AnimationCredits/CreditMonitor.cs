﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditMonitor : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Application.LoadLevel("AniCreditScene");
            SceneManager.LoadScene("AniCreditScene"); //Requires "Using" (see above)
            
        }
    }
}
