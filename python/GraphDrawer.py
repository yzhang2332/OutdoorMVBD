import networkx as nx
import matplotlib.pyplot as plt
import math

WIDTH = 100
HEIGHT = 100
BLANK = 20

class GraphNode():
    def __init__(self, id, angle, depth):
        self.id = id
        self.angle = angle
        self.depth = depth

def gen_initial_pos(nodes):
    result = {}
    max = 0
    for n in nodes:
        max = max if nodes[n].depth <= max else nodes[n].depth
    ratio = (WIDTH - BLANK) / max
    print(ratio)

    for i in nodes:
        y = math.sin(nodes[i].angle) * nodes[i].depth * ratio
        x = math.cos(nodes[i].angle) * nodes[i].depth * ratio
        result[i] = (x, y)
    return result

if __name__ == "__main__":
    Nodes = {
        0: GraphNode(0, 0, 0),
        1: GraphNode(1, -34, 9),
        2: GraphNode(2, 140, 13),
        3: GraphNode(3, 75, 14),
        4: GraphNode(4, 54, 1),
    }
    fixed = [0]
    pos = gen_initial_pos(Nodes)
    print(pos)
    G = nx.Graph()
    for id in Nodes:
        G.add_node(id)
    G.add_edge(1, 4)
    G.add_edge(1, 0)
    result = nx.spring_layout(G,fixed=fixed, pos=pos, iterations=30, k=100)
    print(result)
    nx.draw(G, result)
    plt.show()