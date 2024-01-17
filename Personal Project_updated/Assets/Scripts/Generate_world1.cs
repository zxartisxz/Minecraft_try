using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_world1 : MonoBehaviour
{
    public GameObject ore_block;
    public GameObject ore_block2;
    private int x, y, z = 0;
    private float perlin_Map_Gen;
    private float perlin_Sample;
    private float ore_select;
    private float ore_Spawn_Range_Threshold = 0.83f;
    private float Map_Offset;


    // Start is called before the first frame update
    void Start()
    {
        Map_Offset = Mathf.Floor(Random.Range(-50, -200));
        //Debug.Log("perlin_Map_Gen seed2: " + perlin_Map_Gen);
        perlin_Map_Gen = Random.Range(0.3f, 0.55f); // 0.346805 labs 0.458 labs
        Debug.Log("perlin_Map_Gen seed1: " + perlin_Map_Gen);
        for (x =-50; x < 50; x++)
        {

                

            
            for (y = 0; y > -100; y--)
            {
                 perlin_Sample = Mathf.PerlinNoise( (Map_Offset + x)/10f, (Map_Offset+y) / 10f);
                //Debug.Log(perlin_Sample);
                if(perlin_Sample > perlin_Map_Gen && perlin_Sample < ore_Spawn_Range_Threshold)
                {

                    Instantiate(ore_block, new Vector3(x, y, z), ore_block.transform.rotation);

                }
                else if (perlin_Sample > ore_Spawn_Range_Threshold)
                {
                    //Debug.Log("Perlin sample more then 0.95: " + perlin_Sample);
                    Instantiate(ore_block2, new Vector3(x, y, z), ore_block2.transform.rotation);
                }
                
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
