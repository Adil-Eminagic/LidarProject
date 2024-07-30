import numpy as np
import matplotlib.pyplot as plt
import a_star_search as star


def create_grid(grid, path=None):

    
    # Create grid
    #grid = np.ones((grid_height, grid_width))
    
    if path:
        for (x, y) in path:
            grid_x = int(x)
            grid_y = int(y)
            #grid[grid_x, grid_y] = 0.5 
            grid[grid_y, grid_x] = 0.5  # Mark the cell as part of the path

    return grid


# Create a 20x20 array filled with zeros
grid = np.ones((10, 10))

for i in range(2,8):
    grid[i][3] = 0

for i in range(4,7):
    grid[7][i] = 0

for i in range(7,10):
    grid[i][7] = 0

path = star.a_star_search(grid, [9,9],[9,3], 10,10)

grid_path = create_grid(grid,path)



plt.imshow(grid_path, cmap='gray', origin='lower')
plt.gca().invert_yaxis()
plt.colorbar(ticks=[0,0.5,1], label='Occupancy')
plt.xlabel('X')
plt.ylabel('Y')
plt.title('Grid Map with Different Colors for 0 and 1')
plt.grid(True, which='both',  linestyle='', linewidth=0.5)
plt.show()


