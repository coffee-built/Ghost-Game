using System;
using System.Collections.Generic;

public class Character
{
    /// <summary>
    /// A Guid to refer to the character by
    /// </summary>
    public Guid characterId;

    /// <summary>
    /// Scale from 0-10 for bravery level, 0 being cowardly, 10 being brave
    /// </summary>
    public int bravery;

    /// <summary>
    /// Scale from 0-10 for curiosity level, 0 being unlikely to ever investigate, 10 being likely to investigate everything (Prolly some correlation to bravery)
    /// </summary>
    public int curiosity;

    /// <summary>
    /// Scale from 0-10 for perceptiveness level, 0 being unlikely to notice things, 10 being likely to notice everything (Prolly some correlation to curiosity)
    /// </summary>
    public int perceptiveness;

    /// <summary>
    /// Age
    /// </summary>
    public int age;

    /// <summary>
    /// Scale from 0-10 for Extroversion level
    /// </summary>
    public int extroversion;

    /// <summary>
    /// Scale from 0-10 for Trusting level
    /// </summary>
    public int trusting;

    /// <summary>
    /// A collection of the relationships between the character, and all other characters in the scenario
    /// </summary>
    public List<CharacterRelationship> characterRelationships;

    //TODO: Maybe we should store sprite stuff here idk how these things are normally structured, find that out

    public Character(int charAge)
    {
        characterId = new Guid();

        Random r = new Random();

        bravery = r.Next(1,11);
        curiosity = r.Next(Math.Max(0, bravery - 2), Math.Min(11, bravery + 2)); //Curiosity will be within a range of +- 2 of bravery
        perceptiveness = r.Next(Math.Max(0, curiosity - 3), Math.Min(11, curiosity + 3));
        age = charAge;
        extroversion = r.Next(1, 11);
        trusting = r.Next(1, 11);

        characterRelationships = new List<CharacterRelationship>();
    }
}
