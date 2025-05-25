using UnityEngine;
using UnityEngine.UI;

public class UsuarioItemUI : MonoBehaviour
{
    public Text usuarioText;
    public Button editarButton;
    public Button eliminarButton;

    private UsuarioDTO usuario;
    private UsuarioUIManager uiManager;

    public void Inicializar(UsuarioDTO usuario, UsuarioUIManager manager)
    {
        this.usuario = usuario;
        this.uiManager = manager;
        usuarioText.text = $"{usuario.Id}: {usuario.Nombre} {usuario.Apellido} ({usuario.Username})";

        editarButton.onClick.AddListener(OnEditar);
        eliminarButton.onClick.AddListener(OnEliminar);
    }

    void OnEditar()
    {
        uiManager.CargarUsuarioEnFormulario(usuario);
    }

    void OnEliminar()
    {
        uiManager.EliminarUsuario(usuario.Username);
    }
}
