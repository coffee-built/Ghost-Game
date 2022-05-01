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
    private ParticleSystem playerAbilityParticleSystem;

    private List<HotkeyAbility> hotkeyAbilityList;


    public HotkeyAbilitySystem(PlayerMovement player, ParticleSystem playerAbilityParticleSystem)
    {
        this.player = player;
        this.playerAbilityParticleSystem = playerAbilityParticleSystem;

        playerAbilityParticleSystem.Stop();
        playerAbilityParticleSystem.Clear();

        hotkeyAbilityList = new List<HotkeyAbility>();

        hotkeyAbilityList.Add(new HotkeyAbility
        {
            abilityType = AbilityType.Scream,
            action = () => {
                Debug.Log("Screamed");
                if (!playerAbilityParticleSystem.isPlaying)
                {
                    ParticleSystem.MainModule settings = playerAbilityParticleSystem.main;
                    settings.startColor = new ParticleSystem.MinMaxGradient(new Color(200, 0, 0));
                    playerAbilityParticleSystem.Play();
                    playerAbilityParticleSystem.Stop();
                }
            }
        });
        hotkeyAbilityList.Add(new HotkeyAbility
        {
            abilityType = AbilityType.Light,
            action = () => {
                Debug.Log("Light");
                if (!playerAbilityParticleSystem.isPlaying)
                {
                    ParticleSystem.MainModule settings = playerAbilityParticleSystem.main;
                    settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0, 200, 0));
                    playerAbilityParticleSystem.Play();
                    playerAbilityParticleSystem.Stop();
                }
            }
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
