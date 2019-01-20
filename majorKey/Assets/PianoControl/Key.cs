using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
	public int midiNote;
	public bool isDown = false;

	public AudioSource source;
	public Material blackMat;
	public Material downMat;
	public Renderer thisRenderer;

	public void checkPress(bool downNow){
		if(downNow){
			if(isDown)
				return;
			OnPressDown();
		}else{
			if( isDown )
				OnPressUp();
		}
	}

	public void OnPressDown(){
		isDown = true;
		source.Play();
		thisRenderer.material = downMat;
	}

	public void OnPressUp(){
		isDown = false;
		//source.Stop();
		thisRenderer.material = blackMat;
	}
}
