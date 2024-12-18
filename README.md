# Proyecto Calculadora

Este proyecto es una **calculadora multifuncional** desarrollada en **C#** con **.NET Core**, diseñada para realizar operaciones básicas como suma, resta, multiplicación y división. Además, incluye un sistema de logs que registra las actividades del usuario de forma encriptada.

---

## 🛠️ Herramientas Utilizadas

- **Lenguaje:** C#
- **Framework:** .NET Core
- **Entorno de Desarrollo:** Visual Studio / Visual Studio Code
- **Librerías utilizadas:**
  - `System.IO`: Manejo de archivos para los logs.
  - `System.Security.Cryptography`: Implementación de SHA256 para encriptación.
  - `System.Text`: Manipulación de cadenas y codificación UTF-8.

---

## 📂 Estructura del Proyecto

ProyectoCalculadora/

- Calculadora.cs -> Clase para operaciones aritméticas
- Funciones.cs -> Clase con Métodos de validación de datos
- Log.cs -> Sistema de logs encriptados
- program.cs -> Archivo principal

---

## 📋 Características

1. **Operaciones Matemáticas Básicas**:

   - Suma de N números
   - Resta de N números
   - Multiplicación de N números
   - División de dos números

2. **Validación de Datos**:

   - Entrada numérica restringida a rangos válidos.

3. **Sistema de Logs**:

   - Registra cada operación realizada.
   - Guarda los datos en un archivo llamado `process.log`.
   - Encripta los mensajes de log con el algoritmo SHA256.

4. **Interfaz de Usuario en Consola**:
   - Menús interactivos para facilitar el uso.
   - Función de repetición de operaciones hasta que el usuario desee salir.

---

## 📂 Archivos de Log

```
C:\Users\<TuUsuario>\AppData\Roaming\ProyectoCalculadora\logs\process.log
```

**Cada entrada de log incluye:**

- Fecha y hora.
- Nombre de usuario.
- Operación realizada.
- Resultado (encriptado con SHA256).

---

## 🚀 Clonar Repositorio

1. **Clona este repositorio**:
   ```bash
   git clone https://github.com/tu-usuario/proyecto-calculadora.git
   cd proyecto-calculadora
   ```

---

### ⚙️ Equipo de Desarrollo

- Ramirez Rangel Karla Paola.
- García Maturana Juan Jesús.
- Arellano Ruiz Sergio Joseph.
- Pacheco Ortiz Efrén David.
- García Rodríguez Jorge David.
