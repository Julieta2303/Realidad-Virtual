import pygame
import math

pygame.init()

#Configuracion
ANCHO = 800
ALTO = 600

pantalla = pygame.display.set_mode((ANCHO, ALTO))
pygame.display.set_caption("Hola Mundo - Pygame")

reloj = pygame.time.Clock()

# Color verde agua
VERDE_AGUA = (64, 224, 208)

FONDO = (25, 25, 25)
BORDE = (220, 220, 220)

# Angulos de rotacion
angulo_x = 0
angulo_y = 0

# Velocidad angular
velocidad = 0.03

#vertices del cubo
vertices = [
    [-1, -1, -1],
    [ 1, -1, -1],
    [ 1,  1, -1],
    [-1,  1, -1],

    [-1, -1,  1],
    [ 1, -1,  1],
    [ 1,  1,  1],
    [-1,  1,  1]
]


#Aristas
aristas = [
    (0, 1),
    (1, 2),
    (2, 3),
    (3, 0),

    (4, 5),
    (5, 6),
    (6, 7),
    (7, 4),

    (0, 4),
    (1, 5),
    (2, 6),
    (3, 7)
]


#caras
caras = [
    (0, 1, 2, 3),
    (4, 5, 6, 7),
    (0, 1, 5, 4),
    (2, 3, 7, 6),
    (1, 2, 6, 5),
    (0, 3, 7, 4)
]


#Rotacion en x
def rotar_x(punto, angulo):

    x, y, z = punto

    cos_a = math.cos(angulo)
    sin_a = math.sin(angulo)

    y_nuevo = y * cos_a - z * sin_a
    z_nuevo = y * sin_a + z * cos_a

    return [x, y_nuevo, z_nuevo]


#Rotacion en y
def rotar_y(punto, angulo):

    x, y, z = punto

    cos_a = math.cos(angulo)
    sin_a = math.sin(angulo)

    x_nuevo = x * cos_a + z * sin_a
    z_nuevo = -x * sin_a + z * cos_a

    return [x_nuevo, y, z_nuevo]


#proyeccion 2D
def proyectar(punto):

    x, y, z = punto

    distancia = 4
    escala = 180

    factor = escala / (z + distancia)

    x_pantalla = x * factor + ANCHO / 2
    y_pantalla = -y * factor + ALTO / 2

    return (int(x_pantalla), int(y_pantalla))




# BUCLE PRINCIPAL
ejecutando = True

while ejecutando:

    for evento in pygame.event.get():

        if evento.type == pygame.QUIT:
            ejecutando = False

    
    #teclado
    teclas = pygame.key.get_pressed()

    if teclas[pygame.K_UP]:
        angulo_x += velocidad

    if teclas[pygame.K_DOWN]:
        angulo_x -= velocidad

    if teclas[pygame.K_LEFT]:
        angulo_y -= velocidad

    if teclas[pygame.K_RIGHT]:
        angulo_y += velocidad


    #fondo
    pantalla.fill(FONDO)


    #rotar y proyectar
    puntos_2d = []
    puntos_3d = []

    for vertice in vertices:

        punto = rotar_x(vertice, angulo_x)
        punto = rotar_y(punto, angulo_y)

        puntos_3d.append(punto)
        puntos_2d.append(proyectar(punto))


    #dibujar caras
    for cara in caras:

        puntos_cara = [
            puntos_2d[cara[0]],
            puntos_2d[cara[1]],
            puntos_2d[cara[2]],
            puntos_2d[cara[3]]
        ]

        pygame.draw.polygon(
            pantalla,
            VERDE_AGUA,
            puntos_cara
        )

        pygame.draw.polygon(
            pantalla,
            BORDE,
            puntos_cara,
            2
        )


    #actualizar
    pygame.display.flip()

    reloj.tick(60)


pygame.quit()