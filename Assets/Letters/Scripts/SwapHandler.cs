using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Swaps position of childrens randomly
/// on trigger.
/// </summary>
public class SwapHandler : MonoBehaviour {

    private SwapItems _swap;
    public AudioClip SwapSound;
    private AudioSource _audioSource;

	// Use this for initialization
	void Awake () {
        _swap = new SwapItems();
        _audioSource = GetComponent<AudioSource>();
    }

    public void SwapTrigger()
    {
        var children = new List<Transform>();
        children = getChildren();

        UtilsList listHelper = new UtilsList();
        children = listHelper.ShuffleList<Transform>(children);
        _swap.SwapTransformsRandomly(children);

        playSwapAudio();
    }

    private List<Transform> getChildren()
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in transform)
        {
            children.Add(child);
        }
                
        return children;
    }

    private void playSwapAudio()
    {
        _audioSource.PlayOneShot(SwapSound);
    }
}
