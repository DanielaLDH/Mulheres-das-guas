using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class FalasManager : MonoBehaviour
{
    private EventInstance currentEventInstance;


    public void PlayFala(string fmodEventPath)
    {
        // Libera qualquer instância anterior antes de criar uma nova
        if (currentEventInstance.isValid())
        {
            currentEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentEventInstance.release();
        }

        // Cria e toca uma nova instância
        currentEventInstance = RuntimeManager.CreateInstance(fmodEventPath);
        currentEventInstance.start();

        Debug.Log($"Playing Fala: {fmodEventPath}");
    }


    public EventInstance CreateFalaInstance(string fmodEventPath)
    {
        // Libera a instância anterior antes de criar uma nova
        if (currentEventInstance.isValid())
        {
            currentEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentEventInstance.release();
        }

        currentEventInstance = RuntimeManager.CreateInstance(fmodEventPath);
        Debug.Log($"EventInstance criado para: {fmodEventPath}");
        return currentEventInstance;
    }


    public float GetFalaDuration(string fmodEventPath)
    {
        RuntimeManager.StudioSystem.getEvent(fmodEventPath, out EventDescription eventDescription);

        float duration = 0f;
        eventDescription.getLength(out int lengthMs);
        duration = lengthMs / 1000f; // Converte milissegundos para segundos

        return duration;
    }


    public void StopCurrentFala()
    {
        if (currentEventInstance.isValid())
        {
            currentEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentEventInstance.release();
            Debug.Log("Current fala stopped.");
        }
    }

     public EventInstance GetCurrentEventInstance()
    {
        return currentEventInstance; // Retorna a instância atual para ser usada por outras classes
    }
}
