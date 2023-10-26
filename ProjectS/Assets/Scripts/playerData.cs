using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterData playerCharacter = new CharacterData();

        playerCharacter.chara_Name = "sagume";
        Debug.Log(playerCharacter.chara_Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
