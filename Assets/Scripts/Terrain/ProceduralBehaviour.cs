using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ProceduralBehaviour : MonoBehaviour
{
    public static ProceduralBehaviour instace;
    public float perlinSeed;
    public int seed = 0;
    public Terrain t;
    public int worldSize = 10;
    public float maxHeight = 600;

    private ProceduralTerrain pt;
    
    public List<HeightPass> passes;

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
            DontDestroyOnLoad(gameObject);
            setSeed(seed);
        }
        else
        {
            Destroy(this);
        }  
    }

    private void Start()
    {
        pt = new ProceduralTerrain(worldSize, worldSize, passes);
        t.terrainData.size = new Vector3(worldSize*2, maxHeight, worldSize*2);
        t.terrainData.heightmapResolution = worldSize;
        Debug.Log(t.terrainData.heightmapScale);
        Generate();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Generate(); 
        } 
    }

    public void Generate()
    {
        setSeed(seed);
        //Debug.Log("We can generate " + int.MaxValue + " versions of this procedure");
        //sDebug.Log("Generating version: " + seed);
        
        pt.Generate();

        float[,] norm = pt.GetHeightsNormalized();
        
        t.terrainData.SetHeights(0,0,norm);
    }

    public void setSeed(int s)
    {
        Random.InitState(s);
        if (seed != s)
        {
            seed = s;
        }
        perlinSeed = Random.Range(0.0f, 1000000f);
    }
}
