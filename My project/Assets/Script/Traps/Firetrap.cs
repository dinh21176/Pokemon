
using UnityEngine;
using System.Collections;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float activationDelay;
    [SerializeField] private float damage;
    [Header("Firetrap Timer")]
    [SerializeField] private float activetime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; // When the trap gets triggered
    private bool active; // When the trap gets active and can hurt a player

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!triggered)
            
                StartCoroutine(ActivateFiretrap());
            
            if (active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
    private IEnumerator ActivateFiretrap()
    {
        //turn the sprite red to notify the player
        triggered = true;
        spriteRend.color = Color.red;

        // Wait for delay, activate trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; // turn the sprite back to its initial color
        active = true;
        anim.SetBool("activated", true);

        // Wait Until X seconds, deactivate trap and  reset all variables and animator
        yield return new WaitForSeconds(activetime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}

