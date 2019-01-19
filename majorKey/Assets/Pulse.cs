using UnityEngine;
using MidiJack;

public class Pulse : MonoBehaviour {

    public int noteNumber;

    void Update()
    {

        for (var i = 0; i < 128; i++)
        {
            if (MidiMaster.GetKeyDown(i))
            {
                print(MidiMaster.GetKeyDown(i));
                var color = MidiMaster.GetKeyDown(i) ? Color.red : Color.white;
                GetComponent<Renderer>().material.color = color;
                transform.localScale = Vector3.one * (0.1f + MidiMaster.GetKey(i));
                print(i);
            }
        }

    }


}
