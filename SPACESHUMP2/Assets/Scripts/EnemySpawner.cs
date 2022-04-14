/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: March 16, 2022
 * 
 * Last Edited by: Ben Jenkins
 * Last Edited: April 13, 2022
 * 
 * Description: Spawn enemies within the boundary
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemies settings")]
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond;
    public float enemyDefaultPadding;

    private BoundsCheck boundcheck;

    // Start is called before the first frame update
    void Start()
    {
        boundcheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        //pick a random enemy to instantiate
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        //position the enemy above the screen with a random x position
        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        //set the inital position
        Vector3 pos = Vector3.zero;
        float xMin = -boundcheck.camWidth + enemyPadding;
        float xMax = boundcheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = boundcheck.camHeight + enemyPadding;
        go.transform.position = pos;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
}
