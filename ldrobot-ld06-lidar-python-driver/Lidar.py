import time
import pandas as pd
from listen_to_lidar import listen_to_lidar
import math
import json

lidar_data, stop = listen_to_lidar()
print(lidar_data['distances']) # prints the dictionary with all the accumulated distance data
time.sleep(1)
print(lidar_data['distances']) # prints the updated distance data


def process_lidar_data(lidar_data):
    data = lidar_data
    points=[]
    for angle_str, distance in data.items():
        angle = float(angle_str)
        x = distance * math.cos(angle)
        y = distance * math.sin(angle)
        points.append((x, y))
    return points

# Example usage
lidar_json = '''{
    "0.013333333333321207": 17.7,
    "0.20833333333331439": 17.7,
    "0.28499999999996817": 17.7,
    "0.2999999999999545": 17.5,
    "0.34666666666669244": 17.7,
    "0.35000000000002274": 17.7,
    "0.3949999999999818": 18.2,
    "0.42999999999995": 17.7,
    "0.466666666666697": 17.6
}'''

#points = process_lidar_data(lidar_json)
#print(points)