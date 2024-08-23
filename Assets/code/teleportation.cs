using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class teleportation : MonoBehaviour
{
    public int Potal_Num;
    public GameObject player;
    public GameObject end;
    public bool E_FUCK = false;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ui.SetActive(true);
            player= collision.gameObject;
            E_FUCK = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(TeleportRoutine());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ui.SetActive(false);
            E_FUCK = false;
        }
    }

    IEnumerator TeleportRoutine()
    {
        yield return null;
        player.transform.position = end.transform.position;
    }
}
