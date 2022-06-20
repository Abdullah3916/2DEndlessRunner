
using System;
using UnityEngine;
using Random = UnityEngine.Random;



public class SpikeGenerator : MonoBehaviour

{
    public GameObject spike;
    public GameObject bird;
    public SpikeScript spikeScript;

    public float minSpeed;
    
    public float maxSpeed;

    public float currentSpeed;

    public float speedMultiplier;
    void Awake()
    {
        currentSpeed = minSpeed;
        GenerateSpike();
    }

    public void GenerateNextSpikeWithLatency()
    {
        float randomTime = Random.Range(.1f, 1.2f);
        
        Invoke("GenerateSpike",randomTime);
        
    }
    void GenerateSpike()
    {
       GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);
       SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;
       
    }
    
    private void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += speedMultiplier;
        }
    }
}
