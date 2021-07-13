using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover 
{
    Player _player;
    public Mover(Player player)
    {
       _player = player;
    }
    public void Move(float speed)
    {
       _player.transform.Translate( Vector3.forward * Time.deltaTime * speed);
    }
    
}
