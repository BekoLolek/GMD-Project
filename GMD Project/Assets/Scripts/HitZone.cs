using System.Collections.Generic;
using UnityEngine;


public class HitZone : MonoBehaviour
{

    public List<GameObject> enemiesInZone = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log($"Enemy in zone!");
            enemiesInZone.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInZone.Remove(other.gameObject);
            ScoreManager.Instance.RegisterMiss();
            Destroy(other.gameObject);
        }
    }

    public GameObject GetTopEnemy()
    {
        return enemiesInZone.Count > 0 ? enemiesInZone[0] : null;
    }

    public void DestroyEnemy()
    {
        GameObject enemy = enemiesInZone[0];
        enemiesInZone.Remove(enemy);
        Destroy(enemy);
    }
}
