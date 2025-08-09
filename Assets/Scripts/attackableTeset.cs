using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackableTeset : MonoBehaviour, IAttackable
{
    public float hp = 20f;
    public ParticleSystem particles;
    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }
    public void gotDamage(float damage)
    {
        hp -= damage;
        particles.Play();
    }
}
