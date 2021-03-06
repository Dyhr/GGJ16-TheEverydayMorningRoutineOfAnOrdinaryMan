﻿using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
    public Title title;
    public Todo todo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Clock>().Running = false;
            other.transform.parent.GetComponent<Player>().Control = false;
            title.NextDay(todo.Stress());
        }
    }
}
