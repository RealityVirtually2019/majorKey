using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
public class MasterPiano : MonoBehaviour {

	public GameObject[] keyGOs;

	public AudioClip[] clips;

	public Material blackMat;
	public Material downMat;

	Key[] keys; //32

	// Use this for initialization
	void Start () {
        keys = new Key[32];

		for(int i = 0; i < keyGOs.Length; i++){
			var newKey = keyGOs[i].AddComponent<Key>();
			keys[i] = newKey;
			newKey.midiNote = 41 + i;

			newKey.source = keyGOs[i].AddComponent<AudioSource>();
			newKey.source.clip = clips[i];
			newKey.source.playOnAwake = false;

			newKey.thisRenderer = keyGOs[i].GetComponent<Renderer>();
			newKey.thisRenderer.material = blackMat;
			newKey.blackMat = blackMat;
			newKey.downMat = downMat;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if midi
		//keys[i].checkPress


		 for (var i = 0; i < 128; i++)
        {
           if (MidiMaster.GetKeyDown(i)) {
               keys[i-41].checkPress(true);
           }
		   if (MidiMaster.GetKeyUp(i))
			   keys[i-41].checkPress(false);
			}
        }
        
}
