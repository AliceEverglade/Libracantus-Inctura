using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private MusicSO musicSO;
    [SerializeField] private AudioSource audio;
    [SerializeField] private List<AudioSource> currentlyPlaying = new List<AudioSource>();

    void Start()
    {
        AddLayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            musicSO.IncreasePhase();
            EndPreviousPhase();
            NewPhase();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            musicSO.IncreaseLayer();
            AddLayer(currentlyPlaying[0].time);
        }
    }

    private void AddLayer(float currTime)
    {
        audio.clip = (AudioClip)Resources.Load("Audio/mus/P" + musicSO.phase + "L" + musicSO.layer);
        audio.loop = true;
        audio.playOnAwake = true;
        AudioSource newAudio = GameObject.Instantiate(audio);
        newAudio.time = currTime;
        currentlyPlaying.Add(newAudio);
    }

    private void NewPhase()
    {
        
    }

    private void EndPreviousPhase()
    {
        
    }
}
