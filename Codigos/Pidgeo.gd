extends Area2D

@export var speed = 120
@export var detection_range = 400                     #Se crean las variables de la paloma a utilizar
@export var paloma_scene: PackedScene
@export var spawn_interval := 1
@export var spawn_radius := 600
var is_diving:bool = false

var player = null

func _ready():
	player = get_tree().get_first_node_in_group("player")

func _physics_process(_delta):
	if not player:
		speed = Vector2.ZERO
		return
		
	var dir = player.global_position - global_position
	var dist = dir.length()

	if dist < detection_range:
		speed = dir.normalized() * _delta
	else:
		speed = Vector2.ZERO
	position += speed
func _on_body_entered(t):              #Función para que la paloma reconozca cuando colisiona con el jugador
	if t.is_in_group(player):
		t.call("Damage")

func _spawn():
	var p = paloma_scene.instantiate()
	p.global_position = global_position + Vector2(randf_range(-spawn_radius, spawn_radius), randf_range(-spawn_radius, spawn_radius))
	add_child(p)

func start_attack():
	is_diving = true
