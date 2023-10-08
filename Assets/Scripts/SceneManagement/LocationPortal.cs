using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


    // TELEPORTS THE PLAYER TO A DIFFERENT POSITION WITHOUT SWITCHING SCENES
public class LocationPortal : MonoBehaviour, IPlayerTriggerable
{
    
    [SerializeField] Transform spawnPoint;
    [SerializeField] DestinationIndentifier destinationPortal;

    PlayerController player;
    public void OnPlayerTriggered(PlayerController player)
    {
        player.Character.Animator.IsMoving = false;
        this.player = player;
        StartCoroutine(Teleport());
    }

    Fader fader;

    private void Start()
    {
        fader = FindObjectOfType<Fader>();
    }

    IEnumerator Teleport()
    {
     
        GameController.Instance.PauseGame(true);
        yield return fader.FadeIn(0.5f);


        var destPortal = FindObjectsOfType<LocationPortal>().First(x => x != this && x.destinationPortal == this.destinationPortal);
        player.Character.SetPositionAndSnapToTile(destPortal.SpawnPoint.position);

        yield return fader.FadeOut(0.5f);
        GameController.Instance.PauseGame(false);

        
    }

    public Transform SpawnPoint => spawnPoint;
}
