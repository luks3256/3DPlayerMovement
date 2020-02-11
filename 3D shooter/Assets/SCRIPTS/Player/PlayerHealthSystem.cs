using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthSystem : MonoBehaviour , IDamageble
{
    public int maxHealth = 100;                                 // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    private Transform ui_healthbar;                                 // Reference to the UI's health bar.
    public TextMeshProUGUI ui_healthtext;
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    
    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    PlayerMovement playerMovement;                              // Reference to the player's movement.
    WeaponHandler playerShooting;                              // Reference to the PlayerShooting script.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<WeaponHandler>();

        // Set the initial health of the player.
        currentHealth = maxHealth;
    }
    void Start() {  
        ui_healthbar = GameObject.Find("HUD/Health/HealthBar").transform;
        ui_healthtext.text = "100/100";
        RefeshHealthBar();
    }


    void Update()
    {
        //Change to enemy attating or traps.
        if (Input.GetKeyDown(KeyCode.U)) { DealDamage(10); }
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        // Reset the damaged flag.
        damaged = false;
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        Debug.Log("you are died, restart");
        playerMovement.enabled = false;

        //// Turn off any remaining shooting effects.
        //playerShooting.DisableEffects();

        //// Tell the animator that the player is dead.
        //anim.SetTrigger("Die");

        //// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        //// Turn off the movement and shooting scripts.
        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }


    public void DealDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        //healthSlider.value = currentHealth;
        RefeshHealthBar();
        ui_healthtext.text = currentHealth.ToString() + "/100";

        // Play the hurt sound effect.
        playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }
    public void Heal(int amount)
    {
        // Reduce the current health by the damage amount.
        if(currentHealth < 100)
        currentHealth += amount;

        // Set the health bar's value to the current health.
        //healthSlider.value = currentHealth;
        RefeshHealthBar();
        ui_healthtext.text = currentHealth.ToString() + "/100";

        // Play the hurt sound effect.
        //playerAudio.Play();
    }
    void RefeshHealthBar()
    {
        float t_health_ratio = (float)currentHealth / (float)maxHealth;
        ui_healthbar.localScale = new Vector3(t_health_ratio, 1, 1);
    }
}
