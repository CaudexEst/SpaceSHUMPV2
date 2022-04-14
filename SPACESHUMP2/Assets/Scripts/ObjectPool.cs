/**** 
 * Created by: Ben Jenkins
 * Date Created: April 14, 2022
 * 
 * Last Edited by: 
 * Last Edited: 
 * 
 * Description: object pooling :)
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    static public ObjectPool POOL;
    #region Pool Singleton
    void CheckPOOLIsInScene()
    {
        if (POOL == null)
            POOL = this;
        else
            Debug.LogError("POOL.Awake() - attempted to assign second ObjectPool.POOL");
    }
    #endregion
    private Queue<GameObject> projectiles = new Queue<GameObject>();

    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;

    private void Awake()
    {
        CheckPOOLIsInScene();
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < poolStartSize; i++)
        {
            GameObject projectileGO = Instantiate(projectilePrefab);
            projectiles.Enqueue(projectileGO);
            projectileGO.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetObject()
    {
        if (projectiles.Count > 0)
        {
            GameObject gObject = projectiles.Dequeue();
            gObject.SetActive(true);
            return gObject;
        }
        else
        {
            Debug.LogWarning("Out of objects, reloading...");
            return null;
        }
    }

    public void ReturnObject(GameObject gObject)
    {
        projectiles.Enqueue(gObject);
        gObject.SetActive(false);
    }
}
