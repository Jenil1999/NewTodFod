using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip BreakSound;
    [SerializeField] GameObject SparkleVFX;
    [SerializeField] int HitDone;

    [SerializeField] Sprite[] HitSprite;

    
    Level level;

    private void Start()
    {
        CountBreakableBlock();
    }

    private void CountBreakableBlock()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        { 
            level.CountBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        HitDone++;
        int maxHit = HitSprite.Length + 1;
        if (HitDone >= maxHit)
        {
            DestroyedBlock();
        }

        else
        {
            ShownextSprite();
        }
    }

    private void ShownextSprite()
    {
        int SpriteIndex = HitDone - 1;
        GetComponent<SpriteRenderer>().sprite = HitSprite[SpriteIndex];
    }

    private void DestroyedBlock()
    {
        PlaySFXonBlock();
        Destroy(gameObject);
        level.BreakDownObj();
        SparkleOnTrigger();

        void PlaySFXonBlock()
        {
            FindObjectOfType<GameStatus>().ScoreUpdate();
            AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position);
        }
    }

    public void SparkleOnTrigger()
    {
        GameObject Sparkles = Instantiate(SparkleVFX, transform.position, transform.rotation);
        Destroy(Sparkles, 1f);
    }
}
