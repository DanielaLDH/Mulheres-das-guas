using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemThrowDrop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] AudioSource sfxSound;

    public Image dropImage; // A imagem de UI que será "jogada"
    public float throwSpeed = 500f; // Velocidade inicial do arremesso
    public Vector2 throwDirection = new Vector2(1, 1); // Direção inicial do arremesso
    public float gravity = 800f; // Força gravitacional que faz o item cair

    private Vector2 velocity;
    private bool isThrowing;
    private SFXManager sfxManager;

    private Vector3 originalScale;
    public float scaleFactor = 1.1f; // Fator de aumento, por exemplo, 1.1 para 10% maior


    void Start()
    {
        dropImage.gameObject.SetActive(false); // A imagem está invisível inicialmente
        sfxManager = sfxSound.GetComponent<SFXManager>();
        originalScale = transform.localScale;

    }

    public void OnItemClicked()
    {
        sfxManager.PlaySFX(sfxManager.sfx_item_interaction);

        // Defina a posição inicial e ative a imagem
        dropImage.rectTransform.position = Input.mousePosition;
        dropImage.gameObject.SetActive(true);

        // Configura a velocidade inicial baseada na direção e na velocidade de arremesso
        velocity = throwDirection.normalized * throwSpeed;

        // Começa o arremesso
        isThrowing = true;
    }

    void Update()
    {
        if (isThrowing)
        {
            // Aplica a gravidade na velocidade vertical
            velocity.y -= gravity * Time.deltaTime;

            // Atualiza a posição da imagem baseada na velocidade
            dropImage.rectTransform.position += (Vector3)(velocity * Time.deltaTime);

            // Verifica se a imagem caiu abaixo da posição inicial (opcional para parar a animação)
            if (dropImage.rectTransform.position.y < Input.mousePosition.y)
            {
                isThrowing = false;
                
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sfxManager.PlaySFX(sfxManager.sfx_ui_map_hover);

        transform.localScale = originalScale * scaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }
}
