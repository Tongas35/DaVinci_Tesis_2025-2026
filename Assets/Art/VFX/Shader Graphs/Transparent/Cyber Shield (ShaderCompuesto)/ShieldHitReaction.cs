using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHitReaction : MonoBehaviour
{
    public GameObject hitReactionVFX;

    Material _mat;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            var effect = Instantiate(hitReactionVFX, transform) as GameObject;
            var particleRenderer = effect.transform.GetChild(0).GetComponent<ParticleSystemRenderer>();

            _mat = particleRenderer.material;
            _mat.SetVector("_MaskCenter_HitPos", collision.contacts[0].point);

            Destroy(effect, 2);
        }
    }
}
