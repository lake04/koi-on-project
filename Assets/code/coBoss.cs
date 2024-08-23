using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coBoss : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
   public  GameObject sp;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawner", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawner()
    {

        Instantiate(enemy, sp.transform.position, Quaternion.identity);
    }

    
}
