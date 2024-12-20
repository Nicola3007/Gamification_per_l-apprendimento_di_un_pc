using TMPro;
using UnityEngine;

public class ObjectRotatorWithButton : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocit� di rotazione
    public float returnSpeed = 5f;    // Velocit� con cui l'oggetto ritorna alla posizione originale
    public GameObject uiButton;       // Riferimento al bottone della UI

    private Vector3 initialRotation;  // Rotazione iniziale dell'oggetto
    private Vector3 lastMousePosition;
    private bool isRotationModeActive = false; // Indica se la modalit� di rotazione � attiva
    private bool isRotating = false;

    public TextMeshProUGUI buttontext;

    void Start()
    {
        buttontext.text = "RUOTA";
        // Salva la rotazione iniziale
        initialRotation = transform.eulerAngles;

        // Associa il bottone alla funzione ToggleRotationMode
        if (uiButton != null)
        {
            uiButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ToggleRotationMode);
        }
    }

    void Update()
    {
        if (isRotationModeActive)
        {
            buttontext.text = "TORNA ALL'ASSEMBLAGGIO";
            if (Input.GetMouseButtonDown(0)) // Quando premi il tasto sinistro del mouse
            {
                lastMousePosition = Input.mousePosition;
                isRotating = true;
            }
            else if (Input.GetMouseButton(0) && isRotating) // Quando muovi il mouse tenendo premuto il tasto sinistro
            {
                Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;

                // Ruota l'oggetto sull'asse Y e X
                float rotationX = -deltaMousePosition.y * rotationSpeed * Time.deltaTime;
                float rotationY = deltaMousePosition.x * rotationSpeed * Time.deltaTime;

                transform.Rotate(rotationX, rotationY, 0, Space.World);

                lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0)) // Quando rilasci il tasto sinistro del mouse
            {
                isRotating = false;
            }
        }
        else
        {
            // Se la modalit� di rotazione non � attiva, torna alla posizione iniziale
            buttontext.text = "RUOTA";
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.Euler(initialRotation),
                returnSpeed * Time.deltaTime
            );
        }
    }

    // Funzione per attivare/disattivare la modalit� di rotazione
    void ToggleRotationMode()
    {
        isRotationModeActive = !isRotationModeActive;

        if (!isRotationModeActive)
        {
            // Quando disattivi la modalit� di rotazione, forza il ritorno alla posizione iniziale
            transform.rotation = Quaternion.Euler(initialRotation);
        }
    }
}