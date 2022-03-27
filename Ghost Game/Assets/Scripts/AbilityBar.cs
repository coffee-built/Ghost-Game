using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBar : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;

    private HotkeyAbilitySystem hotkeyAbilitySystem;

    private void Start()
    {
        hotkeyAbilitySystem = new HotkeyAbilitySystem(player);
    }

    private void Update()
    {
        hotkeyAbilitySystem.Update();
    }
}
