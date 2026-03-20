using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int health; //How many hits need to break the block
    public int gold = 0;
    public virtual void OnHit(Player player){
        health -= player.damage;

        if (health <= 0)
        {
            GivesGold(player);
            DestroyBlock();
        }

    }

    protected void DestroyBlock(){
        Destroy(gameObject);
    }

    protected void GivesGold(Player player)
    {
        player.Golds += gold;
    }

}
