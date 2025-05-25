using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite;

public class UsuarioDTO
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Foto { get; set; }      // Puedes guardar la ruta o el nombre del archivo de la foto
    public string DNI { get; set; }

    [Unique]
    public string Username { get; set; }
    public string Password { get; set; }
    public string Genero { get; set; }
}