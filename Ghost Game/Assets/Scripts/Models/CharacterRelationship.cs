using System;

public class CharacterRelationship
{
    /// <summary>
    /// Scale from 0-10 for the quality of the relationship, 0 being hatred, 5 being apathy, 10 being love
    /// </summary>
    private int relationshipQuality;

    /// <summary>
    /// Scale from 0-10 for the trust between the two characters, 0 being unlikely to ever investigate, 10 being likely to investigate everything (Prolly some correlation to bravery)
    /// </summary>
    private int trust;

    /// <summary>
    /// Character 1 of the relationship
    /// </summary>
    private Guid Character1;

    /// <summary>
    /// Character 2 of the relationship
    /// </summary>
    private Guid Character2;
}