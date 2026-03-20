using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lv1 Block: Gives some basic gold and let player can do some basic things, warm up, in short.
public class Block_Lv1 : Block
{
    private void Awake() {
        gold = 5;
    }
    
    //Exemple of override
    // public override void OnHit(Player player)
    // {
    //     base.OnHit(player);
    //     if (health <= 0)
    //     {
    //         GrantExtraPoints(player);
    //     }
    // }
}
