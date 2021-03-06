﻿using UnityEngine;
using System.Collections;

public class TV : TimedTask
{

    protected override IEnumerator Do(Player player)
    {
        yield return new WaitForSeconds(Time);
        ClearAtt();
        Done = true;
        yield return new WaitForSeconds(1);
        Done = false;
        Name = "Turn off TV";
        Attention(player.CanDo(Name), player.AttPrefab);
    }
}
