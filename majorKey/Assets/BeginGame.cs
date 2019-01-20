using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour {

    public GameObject sheet;
    public GameObject baton;
    public Material black;
    public Renderer pianoRenderer;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print("GO");
            StartGame();
        }
	}

    public void StartGame() {
        sheet.SetActive(true);
        baton.SetActive(false);
        pianoRenderer.material = black;
    }
}
