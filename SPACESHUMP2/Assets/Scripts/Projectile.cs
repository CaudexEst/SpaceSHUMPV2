/**** 
 * Created by: Ben Jenkins
 * Date Created: April 14, 2022
 * 
 * Last Edited by: 
 * Last Edited: 
 * 
 * Description: projectile stuff
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bndCheck;

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bndCheck.offUp)
        {
            gameObject.SetActive(false);
            bndCheck.offUp = false;
        }
    }
}
