from flask import Flask, request, jsonify
import time
import pandas as pd
from flask_cors import CORS
from listen_to_lidar import listen_to_lidar
import functions as f

app = Flask(__name__)
CORS(app)

@app.route("/")
def home():
    return "Home"

@app.route("/data")
def data():
    #return "Data"
    lidar_data, stop = listen_to_lidar()
    lidar_data['distances'] # prints the dictionary with all the accumulated distance data
    time.sleep(1)
    stop()
    return lidar_data['distances']

@app.route("/cartesian")
def cartesian():
    #return "Data"
    lidar_data, stop = listen_to_lidar()
    time.sleep(1)
    cartesian = dict(f.process_lidar_data(lidar_data['distances'])) 
    stop()
    return cartesian

@app.route("/grid")
def grid():
    lidar_data, stop = listen_to_lidar()
    time.sleep(1)
    cartesian = f.process_lidar_data(lidar_data['distances'])
    grid = f.create_grid_map(cartesian)  # Create grid with size 100x100
    stop()
    return jsonify(grid)  # 

@app.route("/edges")
def edges():
    lidar_data, stop = listen_to_lidar()
    time.sleep(1)
    cartesian = f.process_lidar_data(lidar_data['distances'])
    min_x,max_x,min_y, max_y = f.max_coordinates(cartesian)
    stop()
    return jsonify({'min_x': min_x, 'max_x': max_x,'min_y': min_y, 'max_y': max_y})

@app.route("/grid_shape")
def grid_shape():
    lidar_data, stop = listen_to_lidar()
    time.sleep(1)
    cartesian = f.process_lidar_data(lidar_data['distances'])
    w,h = f.grid_shape(cartesian)
    stop()
    return jsonify({'width': w, 'height': h})


if __name__ == "__main__":
    app.run(debug=True)