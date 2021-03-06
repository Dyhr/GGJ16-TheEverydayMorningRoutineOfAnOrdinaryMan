﻿using UnityEngine;
using System.Collections;
using System;

public class TimedTask : Interactable
{
    public float Time;
    public Vector3 Anchor;
    public bool DestroyMe;
    public bool DontStop;

    protected bool running;
    protected Vector3 oldPos;

    public override void Interact(Player player)
    {
        ClearAtt();
        if (running) return;
        running = true;
        if (Anchor.magnitude > 0) {
            oldPos = player.transform.position;
            player.transform.position = Anchor;
            player.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (GetComponentInChildren<ParticleSystem>() != null)
            GetComponentInChildren<ParticleSystem>().Play();
        if (GetComponentInChildren<AudioSource>() != null)
            GetComponentInChildren<AudioSource>().Play();
        StartCoroutine(Do(player));
    }

    protected virtual IEnumerator Do(Player player)
    {
        yield return new WaitForSeconds(Time);
        Done = true;
        running = false;
        if (Anchor.magnitude > 0)
        {
            player.transform.position = oldPos;
            player.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (!DontStop && GetComponentInChildren<ParticleSystem>() != null)
            GetComponentInChildren<ParticleSystem>().Stop();
        if (!DontStop && GetComponentInChildren<AudioSource>() != null)
            GetComponentInChildren<AudioSource>().Stop();
        if (DestroyMe)
            Destroy(gameObject,0.1f);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Anchor,0.1f*Vector3.one);
    }
}
