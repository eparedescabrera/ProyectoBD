# ProyectoBD

## Instalación del SDK de .NET

Para compilar y ejecutar esta aplicación necesitas tener instalado el SDK de .NET 7 o superior.

### Windows
1. Visita [https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download).
2. Descarga el instalador del **.NET SDK** para Windows (x64 o x86 según tu arquitectura).
3. Ejecuta el instalador y sigue las instrucciones en pantalla.
4. Verifica la instalación ejecutando en PowerShell o CMD:
   ```powershell
   dotnet --version
   ```

### macOS
1. Abre [https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download).
2. Descarga el paquete **.NET SDK** para macOS (x64 o ARM64).
3. Instala el paquete (`.pkg`).
4. Comprueba la instalación desde la terminal:
   ```bash
   dotnet --version
   ```

### Linux (Ubuntu/Debian)
1. Agrega el repositorio de Microsoft y las dependencias:
   ```bash
   sudo apt-get update
   sudo apt-get install -y wget apt-transport-https software-properties-common
   wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
   sudo dpkg -i packages-microsoft-prod.deb
   rm packages-microsoft-prod.deb
   ```
2. Instala el SDK:
   ```bash
   sudo apt-get update
   sudo apt-get install -y dotnet-sdk-7.0
   ```
3. Verifica que `dotnet` está disponible:
   ```bash
   dotnet --version
   ```

### Linux (Fedora/CentOS/RHEL)
1. Agrega el repositorio de Microsoft:
   ```bash
   sudo rpm -Uvh https://packages.microsoft.com/config/centos/8/packages-microsoft-prod.rpm
   ```
2. Instala el SDK:
   ```bash
   sudo dnf install dotnet-sdk-7.0
   ```
3. Comprueba la instalación:
   ```bash
   dotnet --version
   ```

Una vez instalado el SDK, vuelve a ejecutar el comando `dotnet build` en este proyecto para verificar que la compilación se realiza correctamente.
