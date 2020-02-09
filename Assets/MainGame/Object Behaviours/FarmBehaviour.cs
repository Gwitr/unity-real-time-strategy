using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBehaviour : EmptyBehaviour
{
    public const float money_per_sec = 1.0f;  // ZMIEŃ TĄ LINIĘ W ZALEŻNOŚCI ILE PIENIĘDZY MA DAWAĆ FARMA
    // Przykład:
    // 100 G / sekundę:
    // public const float money_per_sec = 100.0f;

    // 5.4 G / sekundę:
    // public const float money_per_sec = 5.4f;

    private GameObject player;

    public override void GameTick() {
        player.GetComponent<Player>().money += money_per_sec * Time.deltaTime;
    }

    public override void Init() {
        player = GameObject.Find("Player");
    }
}
