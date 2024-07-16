import time
import pandas as pd
from listen_to_lidar import listen_to_lidar
import numpy as np
import matplotlib.pyplot as plt
import functions as f
import a_star_search as a_star

lidar_data, stop = listen_to_lidar()
time.sleep(1)

stop()

points = f.process_lidar_data(lidar_data['distances'])

npPoints= np.array(points)

# Example usage
grid_size = 1  # 1 unit per grid cell
map_size = 100  # 100x100 grid
grid_map = f.create_grid_map(points, grid_size, map_size)

# df = pd.DataFrame(grid_map)

# # Specify the file name
# csv_file = "Map.csv"

# # Export DataFrame to CSV file
# df.to_csv(csv_file, index=False, header=False)


src = [0, 0]
dest = [98, 74]

a_star.a_star_search(grid_map, src, dest)



