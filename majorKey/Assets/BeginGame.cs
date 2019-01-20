using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour {

    public GameObject sheet;
    public GameObject baton;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("GO");
            StartGame();
        }
	}

    public void StartGame() {
        sheet.SetActive(true);
        baton.SetActive(false);

    }
}
