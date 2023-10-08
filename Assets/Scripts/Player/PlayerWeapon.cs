using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public new Camera camera;

    // Referencia al transform del jugador
    public Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = pointWeaponToMouse();
        spriteRenderer.flipY = angle > 90 || angle < -90;
    }

    private float pointWeaponToMouse()
    {
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        // Calcula el ángulo en radianes en lugar de grados
        float angleRadians = Mathf.Atan2(direction.y, direction.x);

        // Convierte el ángulo a grados
        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        // Asegura que la rotación Z del arma sea cero para evitar acumulaciones
        transform.rotation = Quaternion.Euler(0, 0, angleDegrees);

        // Escala el arma horizontalmente según la escala del personaje
        Vector3 characterScale = playerTransform.localScale;
        transform.localScale = new Vector3(characterScale.x, 1, 1);
        return angleDegrees;
    }
}

