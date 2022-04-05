using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCharacterBuilder : MonoBehaviour
{
    public int charsToGenerate;
    public float hairVerticalOffset;
    public float shirtVerticalOffset;

    public List<Sprite> hairAnimations;
    public List<Sprite> shirtAnimations;
    public List<Sprite> torsoAnimations;

    // Start is called before the first frame update
    void Start()
    {
        System.Random r = new System.Random();

        for (int i = 0; i < charsToGenerate; i++)
        {
            var newCharHair = hairAnimations[r.Next(0, hairAnimations.Count)];
            var newCharShirt = shirtAnimations[r.Next(0, shirtAnimations.Count)];
            var newCharTorso = torsoAnimations[r.Next(0, torsoAnimations.Count)];

            var newGameObject = Instantiate(new GameObject());
            newGameObject.name = "Character #" + (i + 1);
            newGameObject.transform.position = new Vector3(newGameObject.transform.position.x + 2*i, newGameObject.transform.position.y, newGameObject.transform.position.z);

            var newHairGameObject = Instantiate(new GameObject());
            newHairGameObject.name = "Character #" + (i + 1) + " Hair";
            newHairGameObject.transform.SetParent(newGameObject.transform);
            newHairGameObject.transform.position = new Vector3(newGameObject.transform.position.x, newGameObject.transform.position.y + hairVerticalOffset, newGameObject.transform.position.z); 
            var hairSpriteRenderer = newHairGameObject.AddComponent<SpriteRenderer>();
            hairSpriteRenderer.sprite = newCharHair;
            hairSpriteRenderer.sortingOrder = 5;

            var newShirtGameObject = Instantiate(new GameObject());
            newShirtGameObject.name = "Character #" + (i + 1) + " Shirt";
            newShirtGameObject.transform.SetParent(newGameObject.transform);
            newShirtGameObject.transform.position = new Vector3(newGameObject.transform.position.x, newGameObject.transform.position.y + shirtVerticalOffset, newGameObject.transform.position.z);
            var headSpriteRenderer = newShirtGameObject.AddComponent<SpriteRenderer>();
            headSpriteRenderer.sprite = newCharShirt;
            headSpriteRenderer.sortingOrder = 5;

            var newTorsoGameObject = Instantiate(new GameObject());
            newTorsoGameObject.name = "Character #" + (i + 1) + " Torso";
            newTorsoGameObject.transform.SetParent(newGameObject.transform);
            newTorsoGameObject.transform.position = new Vector3(newGameObject.transform.position.x, newGameObject.transform.position.y, newGameObject.transform.position.z);
            var torsoSpriteRenderer = newTorsoGameObject.AddComponent<SpriteRenderer>();
            torsoSpriteRenderer.sprite = newCharTorso;
            torsoSpriteRenderer.sortingOrder = 4;
        }
        
    }
}
