using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioProjetor : MonoBehaviour {

    public GameObject[] EngrenagemProj;
    public GameObject[] EngrenagemRuim;

    public static int numEngrenagemRuim;
    private int numSubs;

    // Use this for initialization
    void Start () {

        numEngrenagemRuim = 3;
        numSubs = 0;

        for(int i = 0;i < 3; i++)
        {
            EngrenagemProj[i].SetActive(false);
        }

		
	}
	
	// Update is called once per frame
	void Update () {

        if(numSubs == 1)
        {
            EngrenagemProj[0].SetActive(true);
            EngrenagemProj[1].SetActive(false);
            EngrenagemProj[2].SetActive(false);

        }

        if (numSubs == 2)
        {
            EngrenagemProj[0].SetActive(true);
            EngrenagemProj[1].SetActive(true);
            EngrenagemProj[2].SetActive(false);

        }

        if (numSubs >= 3)
        {
            EngrenagemProj[0].SetActive(true);
            EngrenagemProj[1].SetActive(true);
            EngrenagemProj[2].SetActive(true);

        }

    }

    public void trocaEngrenagem(int index)
    {

        EngrenagemRuim[index].SetActive(false);
        numEngrenagemRuim--;

    }

    public void substitui()
    {
        if(numSubs<3)
        numSubs++;
    }




    }
