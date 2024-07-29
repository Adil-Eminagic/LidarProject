import time
import pandas as pd
from listen_to_lidar import listen_to_lidar
import numpy as np
import matplotlib.pyplot as plt
import functions as f
import a_star_search as star


def create_grid(points, path=None):
    # Find minimum and maximum x and y coordinates
    min_x = int(min(point[0] for point in points))
    min_y = int(min(point[1] for point in points))
    max_x = int(max(point[0] for point in points))
    max_y = int(max(point[1] for point in points))
    
    # Determine new grid dimensions after translation
    grid_width = max_x - min_x + 1
    grid_height = max_y - min_y + 1

    lidar_cor = (0 - min_y, 0 - min_x)
    
    # Create grid
    grid = np.ones((grid_height, grid_width))
    
    for (x, y) in points:
        # grid_x = int(x)
        # grid_y = int(y)
        grid_x = int(x - min_x)
        grid_y = int(y - min_y)
        grid[grid_y, grid_x] = 0  # Mark the cell as occupied
    
    if path:
        for (x, y) in path:
            grid_x = int(x)
            grid_y = int(y)
            #grid[grid_x, grid_y] = 0.5 
            grid[grid_y, grid_x] = 0.5  # Mark the cell as part of the path

    #grid[lidar_cor[0], lidar_cor[1]] = 0.75
    
    grid[lidar_cor[0], lidar_cor[1]] = 0.75
    
    return grid


lidar_data, stop = listen_to_lidar()
time.sleep(1)

stop()

points = f.process_lidar_data(lidar_data['distances'])

npPoints= np.array(points)

# x = npPoints[:, 0]
# y = npPoints[:, 1]

# min_x = min(x)
# min_y = min(y)
# max_x = max(x)
# max_y = max(y)

# size = len(x)

# for i in range(0,size):
#     x[i] = x[i] - min_x
#     #y[i] = y[i] - min_y


# plt.scatter(x, y)

# plt.gca().invert_yaxis()
# plt.xlabel('X')
# plt.ylabel('Y')
# plt.title('2D Lidar Data Points')
# plt.grid(True)
# plt.show()




print(f.grid_shape(npPoints))

grid_f = create_grid(points)

col, row = f.grid_shape(npPoints)

path = star.a_star_search(grid_f,[130,130],[155,120],int(row), int(col))


grid = create_grid(npPoints,path)

# Plotting the grid using matplotlib
plt.imshow(grid, cmap='magma', origin='lower')
plt.gca().invert_yaxis()
plt.colorbar(ticks=[0,0.5 ,0.75,1], label='Occupancy')
plt.xlabel('X')
plt.ylabel('Y')
plt.title('Grid Map with Different Colors for 0 and 1')
plt.grid(True, which='both',  linestyle='', linewidth=0.5)
plt.show()

plt.imshow(grid_f, cmap='magma', origin='lower')
plt.gca().invert_yaxis()
plt.colorbar(ticks=[0,1], label='Occupancy')
plt.xlabel('X')
plt.ylabel('Y')
plt.title('Grid Map with Different Colors for 0 and 1')
plt.grid(True, which='both',  linestyle='', linewidth=0.5)
plt.show()



# plt.scatter(npPoints[:, 0], npPoints[:, 1])
# plt.xlabel('X')
# plt.ylabel('Y')
# plt.title('2D Lidar Data Points')
# plt.grid(True)
# plt.show()

# Example usage
# grid_size = 1  # 1 unit per grid cell
# map_size = 100  # 100x100 grid
# grid_map = f.create_grid_map(points)



# df = pd.DataFrame(grid_map)

# # Specify the file name
# csv_file = "Map.csv"

# # Export DataFrame to CSV file
# df.to_csv(csv_file, index=False, header=False)


# src = [0, 0]
# dest = [98, 74]

# a_star.a_star_search(grid_map, src, dest)


