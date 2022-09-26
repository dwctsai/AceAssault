using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 4;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;      // the empty GameObject "Spawn at Runtime"

    // Start is called before the first frame update
    void Start()
    {
        // Find the very first ScoreBoard you find in the entire project.
        // The project only has one ScoreBoard, so there should be no conflicts.
        scoreBoard = FindObjectOfType<ScoreBoard>();

        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");

        AddRigidbody();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddRigidbody()
    {
        // For the player's lasers to hit the enemy object, the enemy object needs to have a Collider attached.
        // Simple game objects (e.g. Spheres, Capsules) only need a single Collider (e.g. Sphere Collider, Capsule Collider).
        // However, complex game objects (e.g. StarSparrow prefabs) come with nested levels of children Collider objects.
        // In such cases, a Rigidbody attached to a game object will take into consideration all of the game object's childeren Colliders.
        //
        // We shouldn't expect our artists to make prefabs that have Rigidbody's already attached to the prefab.
        // Therefore, we will add a Rigidbody to the game object ourselves.
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }    

    void OnParticleCollision(GameObject other)
    {
        // Debug.Log("<" + this.name + "> says: I'm hit by " + other.gameObject.name);        

        ProcessHit();
        if (hitPoints < 1) 
        {
            KillEnemy();
        }
        
    }

    private void ProcessHit()
    {    
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;

        hitPoints--;
    }

    private void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);

        // Spawn an explosion VFX at the current position of the enemy.  
        // Quaternion.identy means no rotation.
        // 
        // When the game is Playing, the vfx instance that spawns will appear in the Hierarchy as a (Clone) object.
        // Over the course of the game, these vfx instances will clutter up the Hierarchy.
        // We assign the vfx instance to nest under a parent GameObject to keep them all grouped together, thus keeping the Hierarchy organized.
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;

        // https://docs.unity3d.com/ScriptReference/Object.Destroy.html
        Destroy(this.gameObject);
    }

}
