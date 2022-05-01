using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBar : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private ParticleSystem playerAbilityParticleSystem;

    private HotkeyAbilitySystem hotkeyAbilitySystem;

    private void Start()
    {
        hotkeyAbilitySystem = new HotkeyAbilitySystem(player, playerAbilityParticleSystem);
    }

    private void Update()
    {
        hotkeyAbilitySystem.Update();
    }
}
