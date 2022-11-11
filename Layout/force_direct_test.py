import matplotlib.pyplot as plt
import numpy as np
import forcelayout as fl

dataset = np.array([[1,1],[1,3],[2,2],[1,2]])
layout = fl.draw_spring_layout(dataset=dataset, algorithm=fl.SpringForce, size=50)
print(layout.get_positions())
plt.show()
