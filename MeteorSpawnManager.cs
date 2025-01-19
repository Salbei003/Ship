
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MeteorSpawnManager : MonoBehaviour
{
    public const float MIN_TIME_SPAWN = 1f;

    public List<GameObject> prefabs = new();
    public int defaultMeteor = 12;
    public int bigMeteor = 4;
    public int fireMeteor = 2;

    private MeteorsPool pool;
    private float _spawnTime = 4.5f;

    [HideInInspector] public bool spawnReady = true;
    public float SpawnTime
    {
        get
        {
            return _spawnTime;
        }
        set
        {
            if (_spawnTime > MIN_TIME_SPAWN)
                _spawnTime -= value;
        }
    }


    void Awake()
    {
      
        SpawnMeteors(defaultMeteor, bigMeteor, fireMeteor);

        pool = GetComponent<MeteorsPool>();

    } 

   

    private void SpawnMeteors(int def,int big, int fire)
    {
        int[] values = { def, big, fire };

        for (int i = 0; i < values.Length; i++)
        {
            for (int j = 0; j < values[i]; j++) 
            {
                Instantiate(prefabs[i], transform);
            }
        }



    }

    public void SpawnMeteorActived() => StartCoroutine(nameof(MeteorSpawner));
    
    private IEnumerator MeteorSpawner()
    {
        while (spawnReady)
        {
            pool.GetMeteor().OnMeteorAwake?.Invoke();
            yield return new WaitForSeconds(SpawnTime);
        }
 
    }
}
