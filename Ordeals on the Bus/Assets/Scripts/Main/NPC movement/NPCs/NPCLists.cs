using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLists : MonoBehaviour
{
    public npcmovement npc1;
    public NPC2 npc2;
    public NPC3 npc3;
    public NPC4 npc4;
    public NPC5 npc5;

    public busStop5 stop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void npcleave()
    {
        if(stop.busstoping == true)
        {
            npc1.leaving();
            npc2.leaving();
            npc3.leaving();
            npc4.leaving();
            npc5.leaving();

        }
    }
}
