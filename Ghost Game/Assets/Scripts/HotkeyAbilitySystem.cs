using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotkeyAbilitySystem
{
    public enum AbilityType
    {
        Scream,
        Light,
        Coin,
        Posess,
        Kill
    }

    private PlayerMovement player;
    private List<HotkeyAbility> hotkeyAbilityList;

    public HotkeyAbilitySystem(PlayerMovement player)
    {
        this.player = player;

        hotkeyAbilityList = new List<HotkeyAbility>();
        hotkeyAbilityList.Add(new HotkeyAbility
        {
            abilityType = AbilityType.Scream,
            action = () => Debug.Log("Screamed")
        });
        hotkeyAbilityList.Add(new HotkeyAbility
        {
            abilityType = AbilityType.Light,
            action = () => Debug.Log("Light")
        });
        hotkeyAbilityList.Add(new HotkeyAbility
        {
            abilityType = AbilityType.Coin,
            action = () => Debug.Log("Dropped Coin")
        });
        hotkeyAbilityList.Add(new HotkeyAbility
        {
            abilityType = AbilityType.Posess,
            action = () => Debug.Log("Posessing")
        });
        hotkeyAbilityList.Add(new HotkeyAbility
        {
            abilityType = AbilityType.Kill,
            action = () => Debug.Log("Killing")
        });
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            hotkeyAbilityList[0].action();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hotkeyAbilityList[1].action();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hotkeyAbilityList[2].action();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            hotkeyAbilityList[3].action();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            hotkeyAbilityList[4].action();
        }

    }

    public class HotkeyAbility
    {
        public AbilityType abilityType;
        public Action action;
    }
}
