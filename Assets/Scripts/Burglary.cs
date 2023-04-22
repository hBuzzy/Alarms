using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burglary : MonoBehaviour
{
    private Alarm _alarm;
    
    private void Start()
    {
        _alarm = FindObjectOfType<Alarm>().GetComponent<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _alarm.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarm.Stop();
    }
}
