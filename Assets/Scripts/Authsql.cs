using System;
using UnityEngine;
using SQLite;
using System.Collections.Generic;
public class Authsql
{
    private readonly SQLiteConnection db;

    public Authsql(SQLiteConnection dbConnection)
    {
        db = dbConnection;
    }

    // CREATE
    public void CrearUsuario(string username, string password, string nombre = "", string apellido = "", string foto = "", string dni = "", string genero = "")
    {
        var usuario = new UsuarioDTO
        {
            Username = username,
            Password = password,
            Nombre = nombre,
            Apellido = apellido,
            Foto = foto,
            DNI = dni,
            Genero = genero
        };
        try
        {
            db.Insert(usuario);
            Debug.Log("Usuario creado: " + username);
        }
        catch (Exception e)
        {
            Debug.LogWarning("Error al crear usuario: " + e.Message);
        }
    }

    // READ (Login)
    public bool Login(string username, string password)
    {
        var usuario = db.Table<UsuarioDTO>().FirstOrDefault(u => u.Username == username && u.Password == password);
        return usuario != null;
    }

    // UPDATE
    public void ActualizarUsuario(string username, string nombre, string apellido, string foto, string dni, string genero)
    {
        var usuario = db.Table<UsuarioDTO>().FirstOrDefault(u => u.Username == username);
        if (usuario != null)
        {
            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.Foto = foto;
            usuario.DNI = dni;
            usuario.Genero = genero;
            db.Update(usuario);
            Debug.Log("Usuario actualizado: " + username);
        }
        else
        {
            Debug.LogWarning("Usuario no encontrado: " + username);
        }
    }

    // DELETE
    public void EliminarUsuario(string username)
    {
        var usuario = db.Table<UsuarioDTO>().FirstOrDefault(u => u.Username == username);
        if (usuario != null)
        {
            db.Delete(usuario);
            Debug.Log("Usuario eliminado: " + username);
        }
        else
        {
            Debug.LogWarning("Usuario no encontrado: " + username);
        }
    }
    public List<UsuarioDTO> ObtenerTodosLosUsuarios()
    {
        return db.Table<UsuarioDTO>().ToList();
    }
}
