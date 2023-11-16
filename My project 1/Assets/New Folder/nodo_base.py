import sqlite3

# Definir una clase para representar los nodos
class Nodo:
    def __init__(self, nombre, valor):
        self.nombre = nombre
        self.valor = valor

# Establecer la conexión a la base de datos
conn = sqlite3.connect("mi_base_de_datos.db")
cursor = conn.cursor()

# Crear una tabla para almacenar la información de los nodos
cursor.execute('''CREATE TABLE IF NOT EXISTS nodos (
                    id INTEGER PRIMARY KEY,
                    nombre TEXT,
                    valor INTEGER
                )''')

# Función para guardar un nodo en la base de datos
def guardar_nodo_en_bd(nodo):
    cursor.execute("INSERT INTO nodos (nombre, valor) VALUES (?, ?)", (nodo.nombre, nodo.valor))
    conn.commit()

# Función para recorrer y guardar nodos
def recorrer_y_guardar_nodos():
    nodos = [
        Nodo("Nodo1", 42),
        Nodo("Nodo2", 56),
        Nodo("Nodo3", 73)
    ]

    for nodo in nodos:
        guardar_nodo_en_bd(nodo)
        print(f"Guardado nodo: {nodo.nombre} - Valor: {nodo.valor}")

# Llamar a la función para recorrer y guardar nodos
recorrer_y_guardar_nodos()

# Cerrar la conexión a la base de datos
conn.close()
