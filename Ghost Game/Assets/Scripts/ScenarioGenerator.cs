using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScenarioGenerator : MonoBehaviour
{
    public float numberOfPeople;
    public float difficultyLevel;

    private List<Character> generatedCharacters;

    // Start is called before the first frame update
    void Start()
    {
        generatedCharacters = new List<Character>();
        for (int i = 0; i < numberOfPeople; i++)
        {
            System.Random r = new System.Random();
            var age = 0;
            if (i == 1) age = r.Next(32, 50); //Should be at least one middle aged adult in each scenario
            else age = r.Next(1, 75); //Everyone else can be in a significant age range
            //TODO: Maybe build families around couples, or single parent. 
            //i.e. build a parent or a couple, then build their children, and then maybe their parents

            var character = new Character(age);
            generatedCharacters.Add(character);
        }



        // Generates relationships, will prolly rework all of this
        var ageDescendingGeneratedCharacters = generatedCharacters.OrderByDescending(gc => gc.age).ToList();
        for(int i = 0; i < ageDescendingGeneratedCharacters.Count() - 1; i++)
        {
            var olderCharacter = ageDescendingGeneratedCharacters[i];
            var relationshipsToBuild = ageDescendingGeneratedCharacters.Skip(i + 1);

            bool isMarried = olderCharacter.characterRelationships.Any(r => r.CharacterAssociation == CharacterAssociations.Spouse);
            foreach (Character youngerCharacter in relationshipsToBuild)
            {
                var ageDifference = olderCharacter.age - youngerCharacter.age;

                var relationShip = new CharacterRelationship(olderCharacter, youngerCharacter);
                if (youngerCharacter.age > 18 && ageDifference < 18)
                {
                    relationShip.CharacterAssociation = isMarried ? CharacterAssociations.Sibling : CharacterAssociations.Spouse;
                }
                else if (ageDifference > 18 && ageDifference < 36)
                {
                    relationShip.CharacterAssociation = CharacterAssociations.ParentToChild;
                }
                else
                {
                    relationShip.CharacterAssociation = CharacterAssociations.GrandParentToChild;
                }

                olderCharacter.characterRelationships.Add(relationShip);
                youngerCharacter.characterRelationships.Add(relationShip);
            }
        }
        
    }
}
