/**** 
 * Created by: Ben Jenkins
 * Date Created: April 14, 2022
 * 
 * Last Edited by: 
 * Last Edited: 
 * 
 * Description: object pool returning :)
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    private ObjectPool pool;
    
    // Start is called before the first frame update
    void Start()
    {
        pool = ObjectPool.POOL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        if (pool != null)
        {
            pool.ReturnObject(this.gameObject);
        }
    }
}
