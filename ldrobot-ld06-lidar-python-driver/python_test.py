import math
import matplotlib

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
lidar_data = {
    "0.013333333333321207": 17.7,
    "0.20833333333331439": 17.7,
    "0.28499999999996817": 17.7,
    "0.2999999999999545": 17.5,
    "0.34666666666669244": 17.7,
    "0.35000000000002274": 17.7,
    "0.3949999999999818": 18.2,
    "0.42999999999995": 17.7,
    "0.466666666666697": 17.6
}

points = process_lidar_data(lidar_data)
print(points)
print(type(points[0][0]))

# import matplotlib.pyplot as plt
# import numpy as np

# x = np.array(points)
# y = np.array([99,86,87,88,111,86,103,87,94,78,77,85,86])

# plt.scatter(x, y)
# plt.show()