using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/AudioLibrary")]
public class AudioLibrary : ScriptableObject
{
    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip clip;
    }

    public SoundData[] sounds;

    private Dictionary<string, AudioClip> _clips; //criacao do dicio, ja que nao tem interface direto por serializable

    public void Init()
    {
        if (_clips != null) return; // ja inicializou

        _clips = new Dictionary<string, AudioClip>();
        foreach (var sound in sounds)
        {
            if (!_clips.ContainsKey(sound.name)) // nao esta dentro do _clips
                _clips.Add(sound.name, sound.clip);
        }
    }

    public AudioClip GetClip(string name)
    {
        Init(); // garante que esta montado
        return _clips.TryGetValue(name, out var clip) ? clip : null; // retorna se for true o clip (correspondente do nome do dicio) ou null se for false
    }
}