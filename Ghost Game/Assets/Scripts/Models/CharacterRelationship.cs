using System;

public class CharacterRelationship
{
    /// <summary>
    /// Scale from 0-10 for the quality of the relationship, 0 being hatred, 5 being apathy, 10 being love
    /// </summary>
    public int relationshipQuality;

    /// <summary>
    /// Character 1 of the relationship
    /// </summary>
    public Guid Character1;

    /// <summary>
    /// Character 2 of the relationship
    /// </summary>
    public Guid Character2;

    /// <summary>
    /// Character Association
    /// </summary>
    public CharacterAssociations CharacterAssociation;

    public CharacterRelationship(Character Character1Object, Character Character2Object)
    {
        var averageTrustLevel = (Character1Object.trusting + Character2Object.trusting) / 2;

        Random r = new Random();

        relationshipQuality = r.Next(Math.Max(0, averageTrustLevel - 3), Math.Min(11, averageTrustLevel + 3));

        Character1 = Character1Object.characterId;
        Character2 = Character2Object.characterId;
    }
}