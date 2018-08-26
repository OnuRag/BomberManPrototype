using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBombScript : MonoBehaviour {
    public GameObject genealBombModel;
    public GameObject mineBombModel;
    public GameObject remoteBombModel;
    public GameObject superBombModel;
    public GameObject lifeModel;
    public GameObject playerprefab;
    public GameObject explosionPrefab;

    public PlayerScript player;

    GameObject clone;
    GameObject clone2;

    bool bVisible = true;
    int bombPowerG = 4;
    int bombCreate = 1;
    int bombCreateFinal = 1;
    public int activebomb = 0;
    public bool bombDestroied = true;
    public bool hitted = false;
    public bool bomsIsActive = true;
    RaycastHit hit;

    public LayerMask levelMask;

    void Start()
    {
        player = playerprefab.GetComponent<PlayerScript>();
        Invoke("Explode", 3f);
        bVisible = GetComponent<MeshRenderer>().enabled = true;

    }

    void Explode()
    {

        clone2 = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(clone2, .3f);
        bomsIsActive = true;
        Debug.Log("this is from generalbomb class bomb is now " + bomsIsActive);
        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));

        bVisible = GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Collider>().isTrigger = false;

    }

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        for (int i = 1; i < bombPowerG; i++)
        {
            Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit, i, levelMask);

            if (!hit.collider)
            {
                clone = Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
                Destroy(clone, 3f);

            }
            else
            {
                if (hit.collider.CompareTag("life"))
                {
                    Destroy(hit.collider.gameObject);


                }
                if (hit.collider.CompareTag("Player"))
                {
                    Destroy(hit.collider.gameObject);
                }
                //hitted = true;
                if (hit.collider.CompareTag("wood"))
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log(hit.collider.name);
                    CreateBombPower();

                }
                //if (hit.collider.CompareTag("fish1"))
                //{
                //    Destroy(hit.collider.gameObject);
                //    Debug.Log(hit.collider.name);
                //}
                //if (hit.collider.CompareTag("fish2"))
                //{
                //    Destroy(hit.collider.gameObject);
                //    Debug.Log(hit.collider.name);
                //}
                //if (hit.collider.CompareTag("fish3"))
                //{
                //    Destroy(hit.collider.gameObject);
                //    Debug.Log(hit.collider.name);
                //}
                if (hit.collider.CompareTag("superBomb2"))
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log(hit.collider.name);
                }
                if (hit.collider.CompareTag("mineBomb2"))
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log(hit.collider.name);
                }
                if (hit.collider.CompareTag("remoteBomb2"))
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log(hit.collider.name);
                }
                if (hit.collider.CompareTag("generalBomb2"))
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log(hit.collider.name);
                }
                break;

            }

            yield return new WaitForSeconds(.05f);

        }

    }
    void CreateBombPower()
    {
        bombCreate = Random.Range(1, 5);
        bombCreateFinal = Random.Range(1, 3);
        if (bombCreate == 1)
        {
            if (bombCreate == 1)
            {
                Instantiate(lifeModel, hit.collider.transform.position, Quaternion.identity);
            }
            if (bombCreate == 2)
            {
                Instantiate(lifeModel, hit.collider.transform.position, Quaternion.identity);
            }

        }

        if (bombCreate == 2)
        {
            if (bombCreateFinal == 2)
            {
                Instantiate(mineBombModel, hit.collider.transform.position, Quaternion.identity);
            }
        }
        if (bombCreate == 3)
        {
            if (bombCreateFinal == 2)
            {
                Instantiate(remoteBombModel, hit.collider.transform.position, Quaternion.identity);
            }

        }
        if (bombCreate == 4)
        {
            if (bombCreateFinal == 2)
            {
                Instantiate(superBombModel, hit.collider.transform.position, Quaternion.identity);
            }

        }

        if (bombCreateFinal == 5)
        {
            if (bombCreateFinal == 2)
            {
                Instantiate(genealBombModel, hit.collider.transform.position, Quaternion.identity);
            }
            if (bombCreateFinal == 1)
            {
                Instantiate(genealBombModel, hit.collider.transform.position, Quaternion.identity);
            }

        }
    }

}
