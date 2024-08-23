using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        die();
    }

    private void die()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }

    }
    public void TakeDamage(int damage )
    {
            hp--;
    }
}
