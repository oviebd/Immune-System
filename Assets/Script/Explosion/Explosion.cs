using UnityEngine;


//This Component will Control Explosion. Attach this Object to a object and call  Explode() function.

[RequireComponent(typeof(PlaySound))]
public class Explosion : MonoBehaviour
{
    [Header("")]

    private PlaySound _playSound;
    [Header("If Explosion will Play more than one time , then made it false")]
    [SerializeField] private bool isSingleTimeUse = true;
    [Header("Explosion Particle")]
    [SerializeField] private GameObject _explosionEffect;
    [Header("Explosion Audio Clip ")]
    [SerializeField] private AudioClip _explosionClip;
    [Header("If want to set explosion particle sprite from a sprite Renderer. (Optional)")]
    [SerializeField] private SpriteRenderer _sourceImgForExplosionEffectImage;
  
    private bool _isAlreadyExplode = false;
   
	private void Start()
    {
        _isAlreadyExplode = false;
    }

    public void Explode()
    {
        if (_isAlreadyExplode == true && isSingleTimeUse == true)
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
			if(_explosionParticle != null && _sourceImgForExplosionEffectImage != null && _sourceImgForExplosionEffectImage.sprite != null)
			{
                _explosionParticle.GetComponent<ParticleSystemRenderer>().material = _sourceImgForExplosionEffectImage.sharedMaterial;
                _explosionParticle.textureSheetAnimation.SetSprite(0, _sourceImgForExplosionEffectImage.sprite);
			}
            if(_explosionParticle != null)
                _explosionParticle.Play();
        }
    }

    private PlaySound GetPlaySound()
    {
        if(_playSound == null)
            _playSound = GetComponent<PlaySound>();
        return _playSound;
    }


}
