using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeUntilDestroy = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeUntilDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
