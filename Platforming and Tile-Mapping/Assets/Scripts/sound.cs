using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip MainMusic;
    public AudioClip Winsound;
    public AudioSource musicSource;

    // PlayerScript playerScript;
    // public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = MainMusic;
        musicSource.Play();
        musicSource.loop = true;
    }

    // void Awake()
    // {
    //     playerScript = player.GetComponent<PlayerScript>();
    // }

    // Update is called once per frame
    void Update()
    {

    }

    public void winsound()
    {
        musicSource.clip = Winsound;
        musicSource.Play();
        musicSource.loop = false;
    }
}
