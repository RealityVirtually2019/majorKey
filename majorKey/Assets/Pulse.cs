using UnityEngine;
using MidiJack;

public class Pulse : MonoBehaviour {

    public int noteNumber;
    public AudioSource meow;
    public int transpose = -4;
    public int midiNote;
    void Update()
    {

        if (MidiMaster.GetKeyDown(midiNote))
        {
            print(MidiMaster.GetKeyDown(midiNote));
            var color = Color.yellow;
            GetComponent<Renderer>().material.color = color;
            //transform.localScale = Vector3.one * (0.1f + MidiMaster.GetKey(i));
            print(midiNote);
            meow.Play();

        }
        if (MidiMaster.GetKeyUp(midiNote))
        {
            var color = Color.white;
            GetComponent<Renderer>().material.color = color;
            //transform.localScale = Vector3.one * (0.1f + MidiMaster.GetKey(i));
        }

        //for (var i = 0; i < 128; i++)
        //{
        //    if (MidiMaster.GetKeyDown(midiNote))
        //    {
        //        print(MidiMaster.GetKeyDown(i));
        //        var color = Color.yellow;
        //        GetComponent<Renderer>().material.color = color;
        //        //transform.localScale = Vector3.one * (0.1f + MidiMaster.GetKey(i));
        //        print(i);
        //        meow.Play();

        //    }
        //    if (MidiMaster.GetKeyUp(i))
        //    {
        //        var color = Color.white;
        //        GetComponent<Renderer>().material.color = color;
        //        //transform.localScale = Vector3.one * (0.1f + MidiMaster.GetKey(i));
        //    }
        //}

    }
}
