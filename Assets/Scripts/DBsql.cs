using System;
using System.Collections.Generic;
using UnityEngine;
using SQLite; // Import the sqlite-net namespace
public class DBsql : MonoBehaviour
{
    private SQLiteConnection db;
    public SQLiteConnection DbConnection => db; // Exponer la conexi�n como propiedad p�blica

    void Awake()
    {
        string dbPath = System.IO.Path.Combine(Application.persistentDataPath, "usuarios.db");
        db = new SQLiteConnection(dbPath);

        // Crear la tabla Usuario si no existe
        db.CreateTable<UsuarioDTO>();
    }

    void OnDestroy()
    {
        db?.Close();
    }
}