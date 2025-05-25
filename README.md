# Unity SQLite User Management

Este proyecto es un ejemplo funcional de cómo integrar una base de datos SQLite en Unity para gestionar usuarios, usando la librería [`unity-sqlite-net`](https://github.com/gilzoide/unity-sqlite-net).

## Características

- **CRUD completo de usuarios** (crear, leer, actualizar, eliminar)
- **Formulario de registro y edición** de usuarios
- **Listado dinámico** de usuarios con botones para editar y eliminar
- **Persistencia local** usando SQLite
- **Interfaz sencilla** y fácil de extender

## Instalación

1. **Clona este repositorio**  

2. **Abre el proyecto en Unity**  
   Compatible con Unity 2019.4 o superior.

3. **Instala la librería SQLite**  
   Descarga y agrega los archivos de [`unity-sqlite-net`](https://github.com/gilzoide/unity-sqlite-net) a la carpeta `Assets/Plugins/` de tu proyecto.

4. **Configura la escena principal**  
   - Asegúrate de tener un GameObject con el script `DBsql`.
   - Agrega el prefab de usuario y los scripts de UI según el ejemplo.

## Estructura de Carpetas
Assets/ 
├── Scripts/ 
│   ├── Authsql.cs 
│   ├── DBsql.cs 
|	├── UsuarioDTO.cs 
│   ├── UsuarioItemUI.cs
│   └── UsuarioUIManager.cs 
├── Prefabs/ 
│   └── UsuarioItem.prefab 
├── Scenes/ 
│   └── SampleScene.unity 
└── Plugins/ 
└── (archivos de unity-sqlite-net)


## Uso

1. **Ejecuta la escena principal**  
   Verás un formulario para ingresar los datos del usuario y un listado de usuarios registrados.

2. **Agregar usuario**  
   Completa el formulario y haz clic en "Crear Usuario".

3. **Editar usuario**  
   Haz clic en el botón "Editar" junto al usuario que deseas modificar. Los datos se cargarán en el formulario para su edición.

4. **Eliminar usuario**  
   Haz clic en el botón "X" junto al usuario que deseas eliminar.

## Capturas de Pantalla

### Formulario y listado de usuarios

![Formulario y listado](Screenshots/formulario-listado.png)

### Edición de usuario

![Edición de usuario](Screenshots/editar-usuario.png)

### Eliminación de usuario

![Eliminación de usuario](Screenshots/eliminar-usuario.png)

> **Nota:** Guarda tus capturas de pantalla en la carpeta `Screenshots/` y actualiza las rutas en este README.

## Créditos

- [unity-sqlite-net](https://github.com/gilzoide/unity-sqlite-net) por la integración de SQLite en Unity.

