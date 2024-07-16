import math
import numpy as np

def degrees_to_radians(degrees):
    return degrees * (math.pi / 180)

def process_lidar_data(lidar_data):
    data = lidar_data
    points=[]
    for angle_str, distance in data.items():
        angle = float(angle_str)
        angle = degrees_to_radians(angle)
        x = distance * math.cos(angle)
        y = distance * math.sin(angle)
        points.append([x, y])
    return points

# def create_grid_map(points, grid_size, map_size):
#     grid = np.ones((map_size, map_size))
#     for (x, y) in points:
#         grid_x = int(x / grid_size + map_size // 2)
#         grid_y = int(y / grid_size + map_size // 2)
#         if 0 <= grid_x < map_size and 0 <= grid_y < map_size:
#             grid[grid_x, grid_y] = 0  # Mark the cell as occupied
#     return grid.tolist()

def create_grid_map(points):
    # Find minimum and maximum x and y coordinates
    min_x = min(point[0] for point in points)
    min_y = min(point[1] for point in points)
    max_x = max(point[0] for point in points)
    max_y = max(point[1] for point in points)
    
    # Determine grid size based on maximum span in x and y directions
    grid_size = max(max_x - min_x, max_y - min_y)
    
    # Shift all points to ensure positive coordinates
    translated_points = [(x - min_x, y - min_y) for (x, y) in points]
    
    # Determine new grid dimensions after translation
    grid_width = int(max_x - min_x) + 1
    grid_height = int(max_y - min_y) + 1
    
    # Create grid
    grid = np.ones((grid_height, grid_width))
    
    for (x, y) in translated_points:
        grid_x = int(x)
        grid_y = int(y)
        grid[grid_y, grid_x] = 0  # Mark the cell as occupied
    
    return grid.tolist()

def grid_shape(points):
    min_x,max_x,min_y, max_y = max_coordinates(points)
    width = max_x - min_x
    height = max_y - min_y

    return width, height

def max_coordinates(points):
    min_x = min(point[0] for point in points)
    max_x = max(point[0] for point in points)
    min_y = min(point[1] for point in points)
    max_y = max(point[1] for point in points)

    return min_x,max_x,min_y, max_y


# trash
# --------------------------------

# for i in points:
#     i = list(i)
#     i[0] = round(i[0],2)
#     i[1] = round(i[1],2)
#     i[0] = i[0] * 0.1
#     i[1] = i[1] * 0.1

#----------------------------------------------

# x = npPoints[:, 0]
# y = npPoints[:, 1]

# plt.scatter(x, y, s=10)
# plt.show()

#----------------------------------------

# counter0 = 0
# counter1 = 0

# for i  in grid_map:
#     for j in i:
#         if j == 0:
#             counter0= counter0 + 1
#         else:
#             counter1 = counter1 + 1



# print("0s:" + str(counter0))
# print("1s:" + str(counter1))