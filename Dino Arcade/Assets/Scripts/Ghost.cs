using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int points = 200;
   // public Movement movement { get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostFrightened frightened { get; private set; }

  //  public GhostBehavior initialBehavior;
    public Transform target;

    private void Awake()
    {
   //     this.movement = GetComponent<movement>();
        this.home = GetComponent<GhostHome>();
        this.scatter = GetComponent<GhostScatter>();
        this.frightened = GetComponent<GhostFrightened>();

    }


}
