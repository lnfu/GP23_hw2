using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthboxGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject boxprefab;
    void Start()
    {
        for(int i=0;i<40;i++)
        {
            float randomnumx=Random.Range(5.0f,145.0f);
            float randomnumz=Random.Range(5.0f,145.0f);
            var healthbox = Instantiate(boxprefab, new Vector3(randomnumx,1.0f,randomnumz), Quaternion.Euler(0, 0, 0));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //randomnum=Random.Range(5.0f,145.0f);
    }

    void generate(float randomn)
    {
        
    }
}
