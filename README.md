# Cinemática

Hacer un sistema de partículas en Unity sin el Particle System_

## Descripción del trabajo

El script Particle contiene las variables, donde almacena la velocidad inicial, el angulo inicial, el tiempo de vida máximo, el tiempo activo y por último la posición inicial.
Luego, en el script de Particle Controller se encaga de gestionar las partículas, a partir de un prefab y las almacena en la lista. Después cada una de las particluas tiene un valor diferente en sus variables almacenadas,
teniendo una diferente velocidad inicial, angulo inicial, tiempo de vida maximo y tiempo activo. El movimiento de las partículas se calcula mediante ecuaciones del movimiento parabólico. Como:

x = v₀ · cos(θ) · t

y = v₀ · sin(θ) · t + ½ · g · t²

Estas ecuaciones simulan trayectorias parabolicas aplicandoles la gravedad, a demás el tiempo activo hace qeu cuando termina ese tiempo desaparezcan. Todo se hace que cuando se pulse la tecla Space
comience la explosión de partículas.


