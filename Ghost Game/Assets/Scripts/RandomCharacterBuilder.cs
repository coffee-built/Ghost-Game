using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCharacterBuilder : MonoBehaviour
{
    public int charsToGenerate;
    public float hairVerticalOffset;
    public float shirtVerticalOffset;

    public GameObject npcPrefab;
    public GameObject npcShirtPrefab;

    public List<Sprite> hairAnimations;
    public List<Sprite> shirtAnimations;
    public List<Sprite> torsoAnimations;

    public List<AnimationClip> torsoAnimationsFront;
    public List<AnimationClip> torsoAnimationsSide;

    public List<AnimationClip> shirtAnimationsFront;
    public List<AnimationClip> shirtAnimationsSide;

    private AnimatorOverrideController CharacterAnimator;

    // Start is called before the first frame update
    void Start()
    {
        System.Random r = new System.Random();

        for (int i = 0; i < charsToGenerate; i++)
        {
            var newCharHair = hairAnimations[r.Next(0, hairAnimations.Count)];
            var newCharShirt = shirtAnimations[r.Next(0, shirtAnimations.Count)];
            var newCharTorso = torsoAnimations[r.Next(0, torsoAnimations.Count)];

            var newCharTorsoNumber = r.Next(0, torsoAnimationsFront.Count);
            var newCharTorsoFrontAnimation = torsoAnimationsFront[newCharTorsoNumber];
            var newCharTorsoSideAnimation = torsoAnimationsSide[newCharTorsoNumber];

            var newCharShirtNumber = r.Next(0, shirtAnimationsFront.Count);
            Debug.Log(newCharShirtNumber);
            var newCharShirtFrontAnimation = shirtAnimationsFront[newCharShirtNumber];
            var newCharShirtSideAnimation = shirtAnimationsSide[newCharShirtNumber];

            var newTorsoGameObject = Instantiate(npcPrefab);
            newTorsoGameObject.name = "Character #" + (i + 1);
            newTorsoGameObject.transform.position = new Vector3(newTorsoGameObject.transform.position.x + 2*i, newTorsoGameObject.transform.position.y, newTorsoGameObject.transform.position.z);

            Animator charAnimator = newTorsoGameObject.GetComponent<Animator>();
            AnimatorOverrideController aoc = new AnimatorOverrideController(charAnimator.runtimeAnimatorController);
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();

            foreach (var a in aoc.animationClips)
            {
                var newAnimation = newCharTorsoFrontAnimation;
                if (a.name == "npc_body5_walk_front") newAnimation = newCharTorsoFrontAnimation;
                else if (a.name == "npc_body5_walk_side") newAnimation = newCharTorsoSideAnimation;
                anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, newAnimation));
            }
            aoc.ApplyOverrides(anims);
            charAnimator.runtimeAnimatorController = aoc;

            var newShirtGameObject = Instantiate(npcShirtPrefab);
            newShirtGameObject.name = "Character #" + (i + 1) + "Shirt";
            newShirtGameObject.transform.position = new Vector3(newShirtGameObject.transform.position.x + 2 * i, newShirtGameObject.transform.position.y, newShirtGameObject.transform.position.z);
            newShirtGameObject.transform.SetParent(newTorsoGameObject.transform);

            charAnimator = newShirtGameObject.GetComponent<Animator>();
            aoc = new AnimatorOverrideController(charAnimator.runtimeAnimatorController);
            anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();

            foreach (var a in aoc.animationClips)
            {
                var newAnimation = newCharShirtFrontAnimation;
                if (a.name == "npc_body5_walk_front") newAnimation = newCharShirtFrontAnimation;
                else if (a.name == "npc_body5_walk_side") newAnimation = newCharShirtSideAnimation;
                anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, newAnimation));
            }
            aoc.ApplyOverrides(anims);
            charAnimator.runtimeAnimatorController = aoc;


            /*
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
            torsoSpriteRenderer.sortingOrder = 4;*/
        }
        
    }
}
