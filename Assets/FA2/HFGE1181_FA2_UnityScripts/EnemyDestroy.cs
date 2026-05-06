using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
