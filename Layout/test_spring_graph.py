import matplotlib.pyplot as plt
import networkx as nx

G = nx.Graph()
G.add_edge(1, 2)
G.add_edge(1, 3)
G.add_edge(1, 5)
G.add_edge(2, 3)
G.add_edge(3, 4)
G.add_edge(4, 5)
print(G.nodes())
pos = {1: (0, 0), 2: (-1, 0.3), 3: (2, 0.17), 4: (4, 0.255), 5: (5, 0.03)}
pos=nx.spring_layout(G, k=0.5, pos=pos,fixed=[1,2],iterations=2)
nx.draw(G, pos=pos, node_color=range(5), cmap=plt.cm.Blues)  # use spring layout
print(pos)
plt.xlim(-2,6)
plt.ylim(-1,1)
plt.show()
