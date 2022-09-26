using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() 
    {      
        // https://docs.unity3d.com/Manual/ExecutionOrder.html
        // https://en.wikipedia.org/wiki/Singleton_pattern
        // We only want 1 MusicPlayer to exist while the game is playing.
        // To do so, we'll use the Singleton Pattern to ensure that only 1 instance is active at all times.

        int numberOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numberOfMusicPlayers > 1)
        {
            // Destroy this particular instance.
            Destroy(gameObject);
        }
        else 
        {
            // Prevent MusicPlayer from reloading every time the player reloads the scene (e.g. after the player crashes).
            DontDestroyOnLoad(gameObject);
        }

        
    }
}
