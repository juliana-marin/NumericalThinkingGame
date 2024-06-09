using UnityEngine;
using UnityEngine.UI;

public class SidebarController : MonoBehaviour
{
    public GameObject sidebarPanel; // Referencia al panel de la barra lateral
    public Button toggleButton; // Referencia al botón de mostrar/ocultar
    public Text formulaText; // Referencia al texto que mostrará las fórmulas

    private bool isSidebarVisible = false; // Estado de visibilidad de la barra lateral

    void Start()
    {
        // Asegurarse de que la barra lateral esté inicialmente oculta
        sidebarPanel.SetActive(isSidebarVisible);
        
        // Asignar el método ToggleSidebar al evento onClick del botón
        toggleButton.onClick.AddListener(ToggleSidebar);
        
        // Ejemplo: mostrar una fórmula geométrica al iniciar
        //ShowFormula("Área del círculo: A = πr²");
        //ShowFormula("Área del círculo: A = πr²");
    }

    // Método para mostrar/ocultar la barra lateral
    public void ToggleSidebar()
    {
        isSidebarVisible = !isSidebarVisible;
        sidebarPanel.SetActive(isSidebarVisible);
    }

    // Método para mostrar una fórmula específica
    public void ShowFormula(string formula)
    {
        formulaText.text = formula;
    }
}
