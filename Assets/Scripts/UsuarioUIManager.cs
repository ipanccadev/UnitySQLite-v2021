using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UsuarioUIManager : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public InputField nombreInput;
    public InputField apellidoInput;
    public InputField fotoInput;
    public InputField dniInput;
    public InputField generoInput;

    private Authsql authsql;
    public GameObject usuarioItemPrefab; // Asigna el prefab en el Inspector
    public Transform listaUsuariosParent; // Un GameObject vacío con VerticalLayoutGroup

    private UsuarioDTO usuarioEditando = null;

    void Start()
    {
        // Obtiene la instancia única de DBsql en la jerarquía
        var dbsql = FindObjectOfType<DBsql>();
        authsql = new Authsql(dbsql.DbConnection);

        MostrarUsuarios();
    }


    // Llama este método desde UsuarioItemUI
    public void CargarUsuarioEnFormulario(UsuarioDTO usuario)
    {
        usuarioEditando = usuario;
        usernameInput.text = usuario.Username;
        passwordInput.text = usuario.Password;
        nombreInput.text = usuario.Nombre;
        apellidoInput.text = usuario.Apellido;
        fotoInput.text = usuario.Foto;
        dniInput.text = usuario.DNI;
        generoInput.text = usuario.Genero;
    }

    // Llama este método desde UsuarioItemUI
    public void EliminarUsuario(string username)
    {
        authsql.EliminarUsuario(username);
        MostrarUsuarios();
    }

    // Modifica OnCrearUsuario para editar si corresponde
    public void OnCrearUsuario()
    {
        if (usuarioEditando != null)
        {
            authsql.ActualizarUsuario(
                usuarioEditando.Username,
                nombreInput.text,
                apellidoInput.text,
                fotoInput.text,
                dniInput.text,
                generoInput.text
            );
            usuarioEditando = null;
        }
        else
        {
            authsql.CrearUsuario(
                usernameInput.text,
                passwordInput.text,
                nombreInput.text,
                apellidoInput.text,
                fotoInput.text,
                dniInput.text,
                generoInput.text
            );
        }
        LimpiarFormulario();
        MostrarUsuarios();
    }

    private void LimpiarFormulario()
    {
        usernameInput.text = "";
        passwordInput.text = "";
        nombreInput.text = "";
        apellidoInput.text = "";
        fotoInput.text = "";
        dniInput.text = "";
        generoInput.text = "";
        usuarioEditando = null;
    }

    // Cambia MostrarUsuarios para usar el prefab
    public void MostrarUsuarios()
    {
        foreach (Transform child in listaUsuariosParent)
            Destroy(child.gameObject);

        var usuarios = authsql.ObtenerTodosLosUsuarios();
        foreach (var u in usuarios)
        {
            var itemGO = Instantiate(usuarioItemPrefab, listaUsuariosParent);
            var itemUI = itemGO.GetComponent<UsuarioItemUI>();
            itemUI.Inicializar(u, this);
        }
    }
}
