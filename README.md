# TestMerlin
Este proyecto fue desarrollado para la empresa Merlin basado en el Framework Selenium, el cual funciona actualmente para automatización de pruebas
en diferentes plataformas. Se crearon 7 pruebas de automatizacion según el diseño del caso de uso y casos de prueba, estos casos son:
- CreateAccount
- Login
- SendNumber
- StillHaveQuestion
- ValidateAppStore
- ValidateEnvironment
- ValidatPlayStore

El proyecto cuenta con 4 clases las cuales voy a mencionar y describir especificamente.

TestEnvironment: Esta clase maneja el driver de selenium como instancia de un nuevo driver de chrome; maximiza la ventana cuando inicia el
proceso de ejecución y cierra el navegador al terminar la prueba.

Helper: Esta clase maneja toda la lógica de automatización y de desarrollo. Como tal tiene implementado un patrón de diseño llamado Page Object,
el cual da mas robustes a las pruebas de automatización encapsulando los datos y permitiendo reutilizar objetos cuando sea necesario.

Pageinitial: Esta clase fue creada para contener los datos del servidor, al cual nos vamos a conectar y posiblemente más adelante funcione
para almacenar datos de usuarios.

TestMelinWeb: Esta clase tiene creado los test que van a correr basándose en la clase helper, por lo cual creamos un objeto y se llaman
los metodos necesarios que se utilizaran en cada test de automatización.
