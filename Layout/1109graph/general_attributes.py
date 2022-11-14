import json
import math
import random
import networkx as nx
import matplotlib.pyplot as plt


def read_all():
    # f = open('filter_test_bjpg_to_layout.json')
    f = open('new_recom2.json', encoding='UTF-8')
    all_data = json.load(f)
    all_data["9999"] = {
        "isValid": "True",
        "type": 3,
        "depth": 0,
        "angle": 0,
        "size": 4253569,
        "rec": 9999,
        "name": "self",
        "accessibility": 9999
    }
    all_keys = list(all_data.keys())
    node_id = []
    edge_id = []
    all_edge = []
    all_pos = {}
    all_rec = {}
    for i in range(0, len(all_keys)):
        if all_data[all_keys[i]]["isValid"] == "False":  # edge
            # edge_id.append(int(all_keys[i]))
            source = int(all_data[all_keys[i]].get("source")[0])
            target = int(all_data[all_keys[i]].get("source")[1])
            weight = float(all_data[all_keys[i]].get("weight"))
            relation = (source, target, {"weight": weight})

            # edge_id.append(int(all_keys[i]))
            # all_edge.append(relation)

            #########
            if all_data[str(source)]["rec"] != "0.0" and all_data[str(target)]["rec"] != "0.0":

                edge_id.append(int(all_keys[i]))
                # print(all_data[str(source)]["name"], all_data[str(target)]["name"])
                #########
                all_edge.append(relation)
            #####
            else:
                all_data.pop(all_keys[i])
                ######

        else:  # node

            # node_id.append(int(all_keys[i]))
            # angle = float(all_data[all_keys[i]].get("angle"))
            # # depth = float(all_data[all_keys[i]].get("depth"))
            # acc = int(all_data[all_keys[i]].get("accessibility"))
            # if acc == 0:
            #     depth = random.uniform(1, 2)
            # elif acc == 1:
            #     depth = random.uniform(0, 1)
            # elif acc == 9999:
            #     depth = 0
            # x = depth * math.sin(math.radians(angle))
            # if angle >= 0:
            #     y = depth * math.cos(math.radians(angle))
            # else:
            #     y = depth * math.cos(math.radians(angle))
            # all_pos[int(all_keys[i])] = [x, y]
            # # rec = float(all_data[all_keys[i]].get("rec"))
            # # rec = random.uniform(0, 1)
            # rec = float(all_data[all_keys[i]].get("rec"))
            # all_data[all_keys[i]]["rec"] = rec
            # all_rec[int(all_keys[i])] = rec
            # # print(all_data[all_keys[i]]["name"])

            #####
            if all_data[all_keys[i]]["rec"] != "0.0":
                ######
                # print(all_data[all_keys[i]]["name"])
                node_id.append(int(all_keys[i]))
                angle = float(all_data[all_keys[i]].get("angle"))
                # depth = float(all_data[all_keys[i]].get("depth"))
                acc = int(all_data[all_keys[i]].get("accessibility"))
                if acc == 0:
                    depth = random.uniform(1, 2)
                elif acc == 1:
                    depth = random.uniform(0, 1)
                elif acc == 9999:
                    depth = 0
                x = depth * math.sin(math.radians(angle))
                if angle >= 0:
                    y = depth * math.cos(math.radians(angle))
                else:
                    y = depth * math.cos(math.radians(angle))
                all_pos[int(all_keys[i])] = [x, y]
                # rec = float(all_data[all_keys[i]].get("rec"))
                # rec = random.uniform(0, 1)
                rec = float(all_data[all_keys[i]].get("rec"))
                all_data[all_keys[i]]["rec"] = rec
                all_rec[int(all_keys[i])] = rec
            ##########
            else:
                all_data.pop(all_keys[i])
                #########
    all_rec[int(9999)] = 1
    all_data["9999"]["rec"] = 1
    # print(all_data)
    # print(node_id)
    # print(edge_id)
    # print(all_edge)
    # print(all_pos)
    # print(all_rec)
    return all_data, edge_id, all_edge, node_id, all_pos, all_rec


def init_graph(node_id, add_edge):
    G = nx.Graph()
    G.add_nodes_from(range(len(node_id)))
    mapping = {}
    for i in range(len(node_id)):
        mapping[i] = node_id[i]
    # print(mapping)
    G = nx.relabel_nodes(G, mapping)
    # print(nx.nodes(G))
    G.add_edges_from(add_edge)
    return G


def scale(position):
    x_max = 0
    y_max = 0
    node_id = list(position.keys())
    for i in node_id:
        x = position[i][0]
        y = position[i][1]
        # print(i, x, y)
        if abs(x) >= x_max:
            x_max = abs(x)
        if abs(y) >= y_max:
            y_max = abs(y)
    # print("max", x_max, y_max)
    if x_max/21 >= y_max/16:
        scale = x_max/21
    else:
        scale = y_max/16
    # print(scale)

    for i in node_id:
        [position[i][0], position[i][1]] = [position[i][0]/scale, position[i][1]/scale]
    # print(position)
    return position


def layout(position, G, n, it, fix_node):
    m = 0
    # if fix==1:
    #     node_id = list(position.keys())
    #     fix = [node_id[-1]]
    # else:
    #     fix = None
    while m < n:
        pos = nx.spring_layout(G, pos=position, k=12, fixed=fix_node, iterations=it, weight='weight')
        pos = scale(pos)
        m = m+1
    return pos


def flatten(node_id, add_edge, position, r):
    G = init_graph(node_id, add_edge)
    # print(nx.nodes(G))
    # print(nx.edges(G))
    pos = scale(position)
    pos = layout(pos, G, 2, 2, 1)
    nx.draw(G, pos=pos, node_size=r, with_labels=True)
    plt.xlim(-26, 26)
    plt.ylim(-21, 21)
    plt.show()


if __name__ == "__main__":
    all_data, edge_id, all_edge, node_id, all_pos, all_rec = read_all()
    print(all_data)
    # print(all_rec)
    flatten(node_id, all_edge, all_pos, 50)
