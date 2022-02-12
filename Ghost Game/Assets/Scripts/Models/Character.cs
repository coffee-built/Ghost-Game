using System;
using System.Collections.Generic;

public class Character
{
    /// <summary>
    /// A Guid to refer to the character by
    /// </summary>
    private Guid characterId;

    /// <summary>
    /// Scale from 0-10 for bravery level, 0 being cowardly, 10 being brave
    /// </summary>
    private int bravery;

    /// <summary>
    /// Scale from 0-10 for curiosity level, 0 being unlikely to ever investigate, 10 being likely to investigate everything (Prolly some correlation to bravery)
    /// </summary>
    private int curiosity;

    /// <summary>
    /// Scale from 0-10 for perceptiveness level, 0 being unlikely to notice things, 10 being likely to notice everything (Prolly some correlation to curiosity)
    /// </summary>
    private int perceptiveness;

    /// <summary>
    /// Age
    /// </summary>
    private int age;

    /// <summary>
    /// Scale from 0-10 for Extroversion level
    /// </summary>
    private int extroversion;

    /// <summary>
    /// Scale from 0-10 for Trusting level
    /// </summary>
    private int trusting;

    /// <summary>
    /// A collection of the relationships between the character, and all other characters in the scenario
    /// </summary>
    private List<CharacterRelationship> characterRelationships;

    //TODO: Maybe we should store sprite stuff here idk how these things are normally structured, find that out
}
