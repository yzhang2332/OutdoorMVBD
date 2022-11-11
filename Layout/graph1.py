import matplotlib.pyplot as plt
import networkx as nx
import math

node_id = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
label = {0:"flower", 1:"sign", 2:"sidewalk", 3:"sign",4: "sign", 5:"person", 6:"bag", 7:"person",8: "person",9: "person",10: "sidewalk", 11: "bench", 12: "person",13: "person",14: "person", 14:"self"}
angle = [-134.4, -20.3, -0.1, 114.3, 122.5, 135.4, 159.3, 156.3, 149.4, 2.1, 14.2, -66.3, 125.8, -1.0, -174.8, 0]
depth = [7.4, 11.5, 18.9, 22.6, 24.5, 13.2, 13.3, 13.1, 14.1, 16.3, 16.9, 6.9, 14.6, 19.3, 5.8, 0]
edge = [(2, 4), (4, 13), (4, 13), (3, 4), (3, 13), (9, 13), (3, 8), (4, 7), (1, 13), (1, 3), (6, 13), (3, 5), (2, 9), (4, 8), (2, 5), (8, 10), (3, 7), (2, 6), (8, 9), (0, 3), (15,14), (15,11), (15,0)]

node_x = []
node_y = []

for i in range(len(node_id)):
    x = depth[i] * math.sin(angle[i])
    if angle[i] >= 0:
        y = depth[i] * math.cos(angle[i])
    else:
        y = -depth[i] * math.cos(angle[i])
    node_x.append(x)
    node_y.append(y)

# plot test
# plt.scatter(node_x, node_y)
# plt.show()

G = nx.Graph()
G.add_nodes_from(node_id)
G.add_edges_from(edge)
# G = nx.relabel_nodes(G, label)
position={}
for i in range(len(node_id)):
    # position = dict(node_id[i]=(node_x[i], node_y[i]))
    position[node_id[i]] = (node_x[i], node_y[i])
print(position)
pos = nx.spring_layout(G, pos=position, fixed=[15], iterations=2)
nx.draw(G, pos=pos, node_color=range(16), with_labels=True, cmap=plt.cm.Blues)
plt.show()