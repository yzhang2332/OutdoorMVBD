import networkx.algorithms.community as nx_comm
import networkx as nx

G = nx.barbell_graph(3,0)
a = nx_comm.modularity(G, [{0,1,2},{3,4,5}])
b = nx_comm.modularity(G, nx_comm.label_propagation_communities(G))
print(a)
print(b)