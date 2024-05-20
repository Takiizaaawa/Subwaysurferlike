using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
public float jumpForce = 5f; // Force du saut
public LayerMask groundLayer; // Le layer utilisé pour vérifier si le joueur est au sol
public Transform groundCheck; // Point de vérification au niveau des pieds du joueur
public float fallMultiplier = 2.5f; // Facteur de multiplication de la force de chute
public float lowJumpMultiplier = 2f; // Facteur de multiplication de la force de saut lorsque le bouton de saut est relâché

private Rigidbody rb;
private bool isGrounded;

void Start()
{
    rb = GetComponent<Rigidbody>();
}

void Update()
{
    // Vérification si le joueur est au sol
    isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

    // Saut
    if (isGrounded && Input.GetKeyDown(KeyCode.Space))
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    // Contrôle de la chute en appliquant une gravité différente
    if (rb.velocity.y < 0)
    {
        rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }
    else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
    {
        rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }

    // Déplacement gauche/droite
    float moveHorizontal = Input.GetAxis("Horizontal");
    Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
    rb.AddForce(movement * Time.deltaTime * 10f, ForceMode.VelocityChange);
}
}
