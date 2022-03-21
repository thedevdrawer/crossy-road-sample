using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject Zachary;
    public GameObject Dylan;
    public GameObject Twins;

    private Vector3 CharacterPosition;
    private Vector3 Offscreen;

    private int CharacterInt = 1;

    private SpriteRenderer DylanRender, ZacharyRender, TwinsRender;

    private void Awake()
    {
        CharacterPosition = Dylan.transform.position;
        Offscreen = Zachary.transform.position;
        DylanRender = Dylan.GetComponent<SpriteRenderer>();
        ZacharyRender = Dylan.GetComponent<SpriteRenderer>();
        TwinsRender = Dylan.GetComponent<SpriteRenderer>();
    }

    public void NextCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                DylanRender.enabled = false;
                Dylan.transform.position = Offscreen;
                Zachary.transform.position = CharacterPosition;
                ZacharyRender.enabled = true;
                CharacterInt++;
                break;
            case 2:
                ZacharyRender.enabled = false;
                Zachary.transform.position = Offscreen;
                Twins.transform.position = new Vector3((float)-1.66, (float)8.07, (float)-7.37);
                TwinsRender.enabled = true;
                CharacterInt++;
                break;
            case 3:
                TwinsRender.enabled = false;
                Twins.transform.position = Offscreen;
                Dylan.transform.position = CharacterPosition;
                DylanRender.enabled = true;
                CharacterInt++;
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }
    }

    public void PreviousCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                DylanRender.enabled = false;
                Dylan.transform.position = Offscreen;
                Twins.transform.position = new Vector3((float)-1.66, (float)8.07, (float)-7.37);
                TwinsRender.enabled = true;
                ResetInt();
                break;
            case 2:
                ZacharyRender.enabled = false;
                Zachary.transform.position = Offscreen;
                Dylan.transform.position = CharacterPosition;
                DylanRender.enabled = true;
                CharacterInt--;
                break;
            case 3:
                TwinsRender.enabled = false;
                Twins.transform.position = Offscreen;
                Zachary.transform.position = CharacterPosition;
                ZacharyRender.enabled = true;
                CharacterInt--;
                break;
            default:
                ResetInt();
                break;
        }
    }

    private void ResetInt()
    {
        if (CharacterInt >= 3)
        {
            CharacterInt = 1;
        }
        else
        {
            CharacterInt = 3;
        }
    }
}
