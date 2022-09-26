using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadLevelDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // https://docs.unity3d.com/Manual/CollidersOverview.html
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log(this.name + " --Collided with-- " + other.gameObject.name);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(this.name + " **Triggered by** " + other.gameObject.name);

        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        crashVFX.Play();                                    // play explosion VFX
        GetComponent<MeshRenderer>().enabled = false;       // make ship invisible
        GetComponent<PlayerControls>().enabled = false;     // disable player controls
        Invoke("ReloadLevel", loadLevelDelay);              // reload the level after X seconds
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
