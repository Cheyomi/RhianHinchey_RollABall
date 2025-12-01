using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class TriggerScript : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;

    public void OnTriggerEnter(Collider other)
    {
        playableDirector.Play();
    }


}
