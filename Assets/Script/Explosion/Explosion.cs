
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Explosion : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private AudioClip _explosionClip;
	[SerializeField] private SpriteRenderer _sourceImgForExplosionEffectImage;

	private void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
        if (_audioSource != null && _explosionClip != null)
        {
            _audioSource.clip = _explosionClip;
        }
    }

    public void Explode()
    {
        InstantiateEffect();

        if (_audioSource != null && _explosionClip != null)
        {
            _audioSource.Play();
        }
    }

    void InstantiateEffect()
    {
        if (_explosionEffect != null)
        {
            GameObject effectParticle = InstantiatorHelper.instance.InstantiateObject(_explosionEffect, this.gameObject);
			ParticleSystem  _explosionParticle = effectParticle.GetComponent<ParticleSystem>();
			if(_explosionParticle != null && _sourceImgForExplosionEffectImage.sprite != null)
			{
                _explosionParticle.GetComponent<ParticleSystemRenderer>().material = _sourceImgForExplosionEffectImage.sharedMaterial;
                _explosionParticle.textureSheetAnimation.SetSprite(0, _sourceImgForExplosionEffectImage.sprite);
			}
           // Destroy(effectParticle, 1.0f);
        }
    }


}
