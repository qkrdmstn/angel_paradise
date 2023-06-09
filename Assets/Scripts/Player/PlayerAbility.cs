using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerAbility : MonoBehaviour
{
    private Player player;
    GameObject magnet;

    //Change Character
    private SpriteLibrary spriteLibrary;
    public SpriteLibraryAsset[] abilitySkin;
    public Sprite[] standSkin;

    //Player Ability
    public GameObject hackingObjParent;
    public GameObject hackingObj;
    private GameObject superPowerObj;
    public enum playerAbilities
    {
        normal,
        superPower,
        electricity,
        magnetic,
        hacking
    }

    private playerAbilities currentAbility;
    public void SetPlayerAbility(playerAbilities a)
    {
        currentAbility = a;
        Debug.Log(currentAbility);
        if (currentAbility == playerAbilities.normal)
        {
            spriteLibrary.spriteLibraryAsset = abilitySkin[0];
            gameObject.GetComponent<SpriteRenderer>().sprite = standSkin[0];
        }
        else if (currentAbility == playerAbilities.superPower)
        {
            spriteLibrary.spriteLibraryAsset = abilitySkin[1];
            gameObject.GetComponent<SpriteRenderer>().sprite = standSkin[1];
        }
        else if (currentAbility == playerAbilities.electricity)
        {
            spriteLibrary.spriteLibraryAsset = abilitySkin[2];
            gameObject.GetComponent<SpriteRenderer>().sprite = standSkin[2];
        }
        else if (currentAbility == playerAbilities.magnetic)
        {
            spriteLibrary.spriteLibraryAsset = abilitySkin[3];
            gameObject.GetComponent<SpriteRenderer>().sprite = standSkin[3];
        }
        else if (currentAbility == playerAbilities.hacking)  
        {
            spriteLibrary.spriteLibraryAsset = abilitySkin[4];
            gameObject.GetComponent<SpriteRenderer>().sprite = standSkin[4];
            HackingProcess();

        }

        if(currentAbility != playerAbilities.hacking && hackingObjParent != null) //if(not hakcing mode)
        {
            hackingObj.SetActive(false);
        }
    }

    public playerAbilities GetPlayerAbility()
    {
        return currentAbility;
    }

    private void HackingProcess()
    {
        //find invisible obj & setActive true
        hackingObjParent = GameObject.FindGameObjectWithTag("HackingObj");
        if (hackingObjParent != null)
        {
            hackingObj = hackingObjParent.transform.GetChild(0).gameObject;
            hackingObj.SetActive(true);
        }
    }

    private void ElectricityProcess()
    {
        // electricity ability use & electronic device interaction (Interaction is within range)
        if (currentAbility == playerAbilities.electricity && Input.GetKey(KeyCode.Space))
        {
            //Accessing & Activating GameObj
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteLibrary = GetComponent<UnityEngine.U2D.Animation.SpriteLibrary>();
        SetPlayerAbility(playerAbilities.normal);
        player = GameObject.Find("Player").GetComponent<Player>();
        superPowerObj = GameObject.FindGameObjectWithTag("SuperPowerObj");
        magnet = GameObject.FindGameObjectWithTag("MagnetObj");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape) && currentAbility != playerAbilities.normal)
            SetPlayerAbility(playerAbilities.normal);

        if (Input.GetKey(KeyCode.Alpha1))
        {
            SetPlayerAbility(playerAbilities.superPower);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
            SetPlayerAbility(playerAbilities.electricity);
        else if (Input.GetKey(KeyCode.Alpha3))
            SetPlayerAbility(playerAbilities.magnetic);
        else if (Input.GetKey(KeyCode.Alpha4))
            SetPlayerAbility(playerAbilities.hacking);

        //ElectricityProcess();
    }

    public void SuperPowerInteraction(RaycastHit2D hit)
    {
        if (hit.collider != null && hit.collider.CompareTag("SuperPowerObj"))
        {
            Destroy(hit.collider.gameObject);
            Debug.Log("오브젝트 파괴");
        }
    }

}
