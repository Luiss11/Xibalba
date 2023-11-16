# Definir una función para guardar un nodo en un archivo de texto
def guardar_nodo_en_archivo(nodo, nombre_archivo):
    with open(nombre_archivo, 'a') as archivo:
        linea = f"{nodo.nombre},{nodo.valor}\n"
        archivo.write(linea)

# Función para recorrer y guardar nodos
def recorrer_y_guardar_nodos(nombre_archivo):
    nodos = [
        Nodo("Nodo1", 42),
        Nodo("Nodo2", 56),
        Nodo("Nodo3", 73)
    ]

    for nodo in nodos:
        guardar_nodo_en_archivo(nodo, nombre_archivo)
        print(f"Guardado nodo: {nodo.nombre} - Valor: {nodo.valor}")

# Llamar a la función para recorrer y guardar nodos en un archivo de texto
nombre_archivo = "nodos.txt"
recorrer_y_guardar_nodos(nombre_archivo)
