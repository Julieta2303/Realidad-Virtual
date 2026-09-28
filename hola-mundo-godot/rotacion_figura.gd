extends MeshInstance3D

@export var velocidad: float = 1.5

func _process(delta):

	var rotacion_x = 0.0
	var rotacion_y = 0.0

	if Input.is_key_pressed(KEY_UP):
		rotacion_x = velocidad

	if Input.is_key_pressed(KEY_DOWN):
		rotacion_x = -velocidad

	if Input.is_key_pressed(KEY_LEFT):
		rotacion_y = -velocidad

	if Input.is_key_pressed(KEY_RIGHT):
		rotacion_y = velocidad

	rotate_x(rotacion_x * delta)
	rotate_y(rotacion_y * delta)
