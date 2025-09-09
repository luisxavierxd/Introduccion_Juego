using UnityEngine;

public class ArrowAbovePlayer : MonoBehaviour
{
    public Transform player;  // jugador al que se mantendrá encima
    public Transform target;  // objetivo al que apunta la flecha
    public Vector3 offset = new Vector3(0, 1.5f, 0); // altura sobre el jugador

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // destruye la flecha si el objetivo desaparece
            return;
        }

        if (player != null)
        {
            // mantener la flecha encima del jugador
            transform.position = player.position + offset;

            // apuntar hacia el objetivo
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
