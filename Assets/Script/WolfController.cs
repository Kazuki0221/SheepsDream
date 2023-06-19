using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : AnimalController
{

    public override void OnHitFence(GameManager gameManager)
    {
        gameManager.AddCombo(false);
        gameManager.UpdateGage(false);
        Destroy(gameObject);
    }

    public override void OnGoal(GameManager gameManager)
    {
        gameManager.ConcededScore();
        gameManager.AddCombo(false);
        gameManager.UpdateGage(false);
    }

    public override void OnDrivedAway()
    {
        //ActiveVoice();
        Destroy(gameObject);
    }

}
