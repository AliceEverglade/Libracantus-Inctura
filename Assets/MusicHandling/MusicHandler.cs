using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private MusicSO musicSO;
    [SerializeField] private AudioSource audio;
    [SerializeField] private List<List<AudioSource>> songList = new List<List<AudioSource>>();
    [SerializeField] private GameObject audioContainer;
    [SerializeField] private bool readyToTransition = false;
    
    private void Awake()
    {
        SetUpPhases();
    }
    
    void Start()
    {
        songList[0][0].volume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LayerUpdate(1);
        }

        NextPhase();
    }

    private void SetUpPhases()
    {
        for (int phase = 0; phase < 4; phase++)
        {
            songList.Add(new List<AudioSource>());

            for (int layer = 0; layer < musicSO.phaseLayerCount[phase]; layer++)
            {
                Debug.Log(phase + " " + layer);
                AddLayer(0, phase, layer);
            }
        }
    }

    private void AddLayer(float currTime, int phase, int layer)
    {
        audio.clip = (AudioClip)Resources.Load("Audio/mus/P" + phase + "L" + layer);
        audio.loop = true;
        audio.playOnAwake = true;
     
        AudioSource newAudio = GameObject.Instantiate(audio);
        
        newAudio.time = currTime;
        newAudio.volume = 0f;
        songList[phase].Add(newAudio);
        newAudio.transform.parent = audioContainer.transform;
    }

    private void LayerUpdate(int targetVolume)
    {
        int oldPhase = musicSO.phase;

        musicSO.IncreaseLayer();
        int currentPhase = musicSO.phase;
        int currentLayer = musicSO.layer;

        if (oldPhase != currentPhase)
        {
            readyToTransition = true;
        }

        if (!readyToTransition)
        {
            songList[currentPhase][currentLayer].volume = targetVolume;
        }
    }

    private void SpecificLayerUpdate(int targetVolume, int chosenPhase, int chosenLayer)
    {
        songList[chosenPhase][chosenLayer].volume = targetVolume;
    }

    private void NextPhase()
    {

        if (readyToTransition)
        {
            float currentTime = songList[musicSO.phase - 1][0].time;
            float fullLength = songList[musicSO.phase - 1][0].clip.length;

            float difference = fullLength - currentTime;
            float halfDifference = (fullLength - fullLength / 2) - currentTime;

            if (fullLength - currentTime <= 0.02f || (halfDifference > 0 && halfDifference <= 0.02f))
            {
                ResetTime();
                MutePreviousPhase();
                UnmuteCurrentPhase();
                readyToTransition = false;
            }
        }
    }

    private void MutePreviousPhase()
    {
        for (int layer = 0; layer < musicSO.phaseLayerCount[musicSO.phase - 1]; layer++)
        {
            SpecificLayerUpdate(0, musicSO.phase - 1, layer);

        }
    }

    private void UnmuteCurrentPhase()
    {
        for (int layer = 0; layer < musicSO.layer; layer++)
        {
            SpecificLayerUpdate(1, musicSO.phase, layer);
        }
    }

    private void ResetTime()
    {
        for (int layer = 0; layer < musicSO.phaseLayerCount[musicSO.phase]; layer++)
        {
            songList[musicSO.phase][layer].time = 0;
        }

    }
}
