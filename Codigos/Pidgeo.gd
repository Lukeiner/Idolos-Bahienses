extends CharacterBody2D

@export var speed = 120
@export var detection_range = 400                     #Se crean las variables de la paloma a utilizar

var player = null

func _ready():
	player = get_tree().get_first_node_in_group("player")

func _physics_process(delta):
	if not player:
		speed = Vector2.ZERO
		return
		
	var dir = player.global_position - global_position
	var dist = dir.length()

	if dist < detection_range:
		speed = dir.normalized() * speed
	else:
		speed = Vector2.ZERO

	move_and_slide()

func _on_body_entered(t):              #Función para que la paloma reconozca cuando colisiona con el jugador
	if t.is_in_group(player):
		t.call("Damage")
