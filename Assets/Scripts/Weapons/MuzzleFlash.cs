using KBCore.Refs;
using UnityEngine;

namespace Shooter.Weapons
{
    public class MuzzleFlash : MonoBehaviour
    {
        [SerializeField, Self] private ParticleSystem muzzleFlash;

        public void Play()
        {
            muzzleFlash.Play();
        }
    }
}