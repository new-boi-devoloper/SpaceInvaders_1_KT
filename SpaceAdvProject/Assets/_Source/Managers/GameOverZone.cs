using System;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMaskCheck.ContainsLayer(LayerMask.GetMask("Enemy"), other.gameObject))
        {
            EventManager.TriggerEnemyWon();
        }
    }
}