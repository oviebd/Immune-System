
using UnityEngine;

[RequireComponent(typeof(PlaySound))]
public class Explosion : MonoBehaviour
{
    private PlaySound _playSound;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private AudioClip _explosionClip;
	[SerializeField] private SpriteRenderer _sourceImgForExplosionEffectImage;
    private bool _isAlreadyExplode = false;

	private void Start()
    {
        _isAlreadyExplode = false;
    }

    public void Explode()
    {
        if (_isAlreadyExplode == true)
            return;

		if (GetPlaySound() != null && _explosionClip != null)
		{
			GetPlaySound().PlayAudioWithClip(_explosionClip);
		}
		InstantiateEffect();

        _isAlreadyExplode = true;
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
                _explosionParticle.Play();
			}
        }
    }

    private PlaySound GetPlaySound()
    {
        if(_playSound == null)
            _playSound = GetComponent<PlaySound>();
        return _playSound;
    }


}
