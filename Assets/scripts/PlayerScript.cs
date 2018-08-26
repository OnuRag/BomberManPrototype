using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject generalBombPrefab;
    public GameObject mineBombPrefab;
    public GameObject remoteBombPrefab;
    public GameObject superBombPrefab;
    public GeneralBombScript gBomb;

    GameObject gClone;
    GameObject mClone;
    GameObject rClone;
    GameObject sClone;

    float speed = 10f;
    int life=100;
    int activeBomb = 1;
    int activeVarG = 0;
    int activeVarM = 0;
    int activeVarR = 0;
    int activeVarS = 0;
    public bool bombActive = true;
    private bool generalbomb = true;
    private bool minebomb = false;
    private bool remotebomb = false;
    private bool superbomb = false;


    void Start()
    {
        gBomb = generalBombPrefab.GetComponent<GeneralBombScript>();
        life = 100;
    }
    void move()
    {
        Vector3 x = Input.GetAxis("Horizontal") * transform.right * Time.deltaTime * speed;
        Vector3 z = Input.GetAxis("Vertical") * transform.forward * Time.deltaTime * speed;
        transform.Translate(x + z);
    }
    void increaseBomb()
    {
        activeBomb += 1;
    }
    void DropGeneralBomb()
    {
        if (activeBomb > 0)
        {
            gClone = Instantiate(generalBombPrefab, new Vector3(Mathf.RoundToInt(gameObject.transform.position.x), generalBombPrefab.transform.position.y, Mathf.RoundToInt(gameObject.transform.position.z)), generalBombPrefab.transform.rotation);
            Destroy(gClone, 3.5f);
            activeBomb = activeBomb - 1;
            Debug.Log(activeBomb);
            Invoke("increaseBomb", 3.6f);
        }       

    }
 
    void DropMineBomb()
    {
        if(activeBomb >0)
        {
            mClone = Instantiate(mineBombPrefab, new Vector3(Mathf.RoundToInt(gameObject.transform.position.x), mineBombPrefab.transform.position.y, Mathf.RoundToInt(gameObject.transform.position.z)), mineBombPrefab.transform.rotation);
            Destroy(mClone, 3.5f);
            activeBomb = activeBomb - 1;
            Invoke("increaseBomb", 3.6f);
        }
    }
    void DropRemoteBomb()
    {
        if (activeBomb > 0)
        {
            rClone = Instantiate(remoteBombPrefab, new Vector3(Mathf.RoundToInt(gameObject.transform.position.x), remoteBombPrefab.transform.position.y, Mathf.RoundToInt(gameObject.transform.position.z)), remoteBombPrefab.transform.rotation);
            Destroy(rClone, 3.5f);
            activeBomb = activeBomb - 1;
            Invoke("increaseBomb", 3.6f);
        }
    }
    void DropSuperBomb()
    {
        if (activeBomb > 0)
        {
            sClone = Instantiate(superBombPrefab, new Vector3(Mathf.RoundToInt(gameObject.transform.position.x), superBombPrefab.transform.position.y, Mathf.RoundToInt(gameObject.transform.position.z)), superBombPrefab.transform.rotation);
            Destroy(sClone, 3.5f);
            activeBomb = activeBomb - 1;
            Invoke("increaseBomb", 3.6f);
        }
    }
    void DropBomb()
    {
        if (generalbomb == true)
        {
            DropGeneralBomb();        
           
        }
        if (minebomb == true)
        {
            DropMineBomb();
        }
        if (remotebomb == true)
        {
            DropRemoteBomb();
        }
        if (superbomb == true)
        {
            DropSuperBomb();
        }

    }
    void Update ()
    {
        move();
        if (Input.GetKeyDown(KeyCode.M))
        {
            DropBomb();
        }
        Debug.Log("life "+life);
        
    }

    private void OnCollisionEnter(Collision col)
    {
        
        if (col.collider.CompareTag("fish1"))
        {
            life -= 10;
            Debug.Log(life);
        }
        if (col.collider.CompareTag("fish2"))
        {
            life -= 15;
            Debug.Log("collided with" + col.collider.name);
            Debug.Log(life);
        }
        if (col.collider.CompareTag("fish3"))
        {
            life -= 20;
            Debug.Log("collided with" + col.collider.name);
            Debug.Log(life);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("generalBomb2"))
        {
            generalbomb = true;
            minebomb = false;
            remotebomb = false;
            superbomb = false;
            Destroy(other.gameObject);

            activeVarM = 0;
            activeVarR = 0;
            activeVarS = 0;

            if(activeVarG==0)
            {
                activeBomb = 1;
            }
           else if(activeVarG > 0)
            {
                activeBomb += 1;
            }
            if(activeBomb > 5)
            {
                activeBomb = 5;
            }
            activeVarG += 1;
        }
        
        if (other.CompareTag("mineBomb2"))
        {
            generalbomb = false;
            minebomb = true;
            remotebomb = false;
            superbomb = false;
            
            activeVarG = 0;
            activeVarR = 0;
            activeVarS = 0;

            Destroy(other.gameObject);

            if(activeVarM==0)
            {
                activeBomb = 1;
            }
            if (activeVarM > 0)
            {
                activeBomb += 1;
            }
            if(activeBomb >=5)
            {
                activeBomb = 5;
            }
            activeVarM += 1;

        }
        if (other.CompareTag("remoteBomb2"))
        {
            generalbomb = false;
            minebomb = false;
            remotebomb = true;
            superbomb = false;

            activeVarG = 0;
            activeVarM = 0;
            activeVarS = 0;

            Destroy(other.gameObject);
            if(activeVarR==0)
            {
                activeBomb = 1;
            }
            else if (activeVarR > 0)
            {
                activeBomb += 1;
            }
            if(activeBomb >=5)
            {
                activeBomb = 5;
            }
            activeVarR += 1;
        }
        if (other.CompareTag("superBomb2"))
        {
            generalbomb = false;
            minebomb = false;
            remotebomb = false;
            superbomb = true;

            activeVarG = 0;
            activeVarM = 0;
            activeVarR = 0;
 
            if(activeVarS == 0)
            {
                activeBomb = 1;
            }
           else if (activeVarS > 0)
            {
                activeBomb += 1;
            }
            if(activeBomb>=5)
            {
                activeBomb = 5;
            }
            activeVarS += 1;

            Destroy(other.gameObject);
        }
        if (other.CompareTag("life"))
        {
           if(life <100)
            {
                life += 10;
            }
            Destroy(other.gameObject);
        }


    }


}
