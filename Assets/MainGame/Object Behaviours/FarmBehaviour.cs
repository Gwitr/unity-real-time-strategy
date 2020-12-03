using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBehaviour : EmptyBehaviour
{
    public int monetyNaSekunde = 1;

    /* public override void GameTick() {
        
    } */

    public override void Init() {
        // Disable GameTick to speed game up
        playField.Unregister(this);
        StartCoroutine(IncreaseMoney());
    }

    IEnumerator IncreaseMoney()
    {
        while (true) {
            yield return new WaitForSeconds(1.0f);
            player.money += monetyNaSekunde;
        }
    }
}
