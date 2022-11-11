import networkx as nx
import community.community_louvain as community_louvain
import matplotlib.pyplot as plt
import copy
import random
import math
import numpy as np
import json
import operator
import general_attributes


def grouping(G):
    cluster = community_louvain.best_partition(G, weight="weight", random_state=111)
    groups = {}
    for i, v in cluster.items():
        groups[v] = [i] if v not in groups.keys() else groups[v] + [i]
    groups = dict(sorted(groups.items()))
    # print(groups)
    # print(cluster)
    return cluster, groups


def grouping_visualization(cluster, node_id, all_pos, G):
    pos = general_attributes.scale(all_pos)
    color = ["gold", "violet", "limegreen", "darkorange", "red", "gray", "yellow", "blue", "green", "yellow", "orange", "darkgray", "lightblue", "lightgray"]
    node_color = []
    for i in range(0, len(cluster)):
        node_color.append(color[int(cluster[node_id[i]])])
    pos = general_attributes.layout(pos, G, 5, 2, 1)
    nx.draw(G, pos=pos, node_size=100, with_labels=True, node_color=node_color)
    plt.xlim(-26, 26)
    plt.ylim(-21, 21)
    plt.show()


def filter_data(data, node_id, cluster):
    for i in range(len(node_id)):
        group_in_order = list(cluster.values())
        data[str(node_id[i])]["group"] = group_in_order[i]
    # print(data)
    return data


def layer(data, cluster, node_id, edge_id):
    data_update = filter_data(data, node_id, cluster)
    # layer 1
    layer_data = {}
    group_number = max(cluster.values())
    candidate_node = {}
    for i in range(0, group_number):
        rec_max = -1
        node = -1
        number_node = 0
        node_list = []
        for j in range(0, len(node_id)):
            if int(data_update[str(node_id[j])]["group"]) == i:
                # group_now = i
                number_node += 1
                node_list.append(str(node_id[j]))
                rec = data_update[str(node_id[j])]["rec"]
                if rec > rec_max:
                    rec_max = rec
                    node = node_id[j]
        if number_node == 1:
            for k in range(0, len(node_list)):
                data_update[str(node_list[k])]["single"] = 1
        else:
            for k in range(0, len(node_list)):
                data_update[str(node_list[k])]["single"] = 0

        candidate_node[node] = rec_max

    # print(candidate_node)
    # print(data_update)
    candidate_node = sorted(candidate_node.items(), key=lambda x: x[1], reverse=True)
    # print(candidate_node)
    # if len(candidate_node) > 6:
    #     for i in range(0, 6):
    #         layer_data[candidate_node[i][0]] = copy.deepcopy(data_update[str(candidate_node[i][0])])
    # else:
    #     for i in range(len(candidate_node)):
    #         layer_data[candidate_node[i][0]] = copy.deepcopy(data_update[str(candidate_node[i][0])])
    for i in range(len(candidate_node)):
        layer_data[int(candidate_node[i][0])] = copy.deepcopy(data_update[str(candidate_node[i][0])])
    # print(layer_data.keys())
    # print(layer_data)

    # search for edge
    search_keys = list(layer_data.keys())
    # print(search_keys)
    # print(data_update)
    for i in range(0, len(edge_id)):  # find related edges
        source = int(data_update[str(edge_id[i])].get("source")[0])+217
        target = int(data_update[str(edge_id[i])].get("source")[1])+217
        # print(source, target)
        if (source in search_keys) and (target in search_keys):
            # print(edge_id[i])
            layer_data[int(edge_id[i])] = copy.deepcopy(data_update[str(edge_id[i])])
    # print(layer_data)
    return layer_data


def hierarchy(node_id, add_edge, position, r, n, it, fix):
    G = general_attributes.init_graph(node_id, add_edge)
    # print(nx.nodes(G))
    # print(nx.edges(G))
    pos = general_attributes.scale(position)
    render_pos = general_attributes.layout(pos, G, n, it, fix)
    nx.draw(G, pos=render_pos, node_size=r, with_labels=True)
    plt.xlim(-26, 26)
    plt.ylim(-21, 21)
    # plt.show()
    return render_pos


def read_new(data):
    all_keys = list(data.keys())
    node_id = []
    edge_id = []
    all_edge = []
    all_pos = {}
    for i in range(0, len(all_keys)):
        if data[all_keys[i]]["isValid"] == "False":  # edge
            edge_id.append(int(all_keys[i]))
            source = int(data[all_keys[i]].get("source")[0])+217
            target = int(data[all_keys[i]].get("source")[1])+217
            weight = float(data[all_keys[i]].get("weight"))
            relation = (source, target, {"weight": weight/3})
            all_edge.append(relation)

        else:  # node
            node_id.append(int(all_keys[i]))
            angle = float(data[all_keys[i]].get("angle"))
            # depth = float(data[all_keys[i]].get("depth"))
            acc = int(data[all_keys[i]].get("accessibility"))
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

    # print(node_id)
    # print(edge_id)
    # print(all_edge)
    # print(all_pos)
    # print(all_rec)
    return edge_id, all_edge, node_id, all_pos


def to_render_json1(data, render_pos, name):
    search_list = list(render_pos.keys())
    # print(search_list)
    # print(render_pos)
    for i in range(0, len(search_list)):
        data[search_list[i]]["id"] = search_list[i]
        data[search_list[i]]["cx"] = np.split(render_pos[search_list[i]], 2)[1].tolist()[0]
        data[search_list[i]]["cy"] = -np.split(render_pos[search_list[i]], 2)[0].tolist()[0]
        data[search_list[i]]["x0"] = 5
        if data[search_list[i]]["single"] == 0:
            data[search_list[i]]["semantic_label"] = 100+data[search_list[i]]["group"]
        else:
            # data[search_list[i]]["semantic_label"] = None
            pass
    # print(data)
    data_list = []
    for i in range(0, len(search_list)):
        if search_list[i] != 9999:
            # print(data[search_list[i]])
            data_list.append(data[search_list[i]])
    # print(data_list)
    modified_dict = {}
    modified_dict["_data"] = data_list
    modified_dict["mode"] = 1
    modified_dict["orientation_agent"] = 0
    modified_dict["orientation_map"] = 90.0
    modified_dict["point_size"] = 5
    modified_dict["scale"] = 1
    modified_dict["x0"] = 0
    modified_dict["y0"] = 0
    # print(modified_dict)
    json_str = json.dumps(modified_dict, indent=4)
    with open(name,'w') as json_file:
        json_file.write(json_str)


def to_render_json2(data, render_pos, name):
    search_list = list(data.keys())
    # print(search_list)
    # print(data)
    # print(render_pos)
    for i in range(0, len(search_list)):
        data[search_list[i]]["id"] = search_list[i]
        # print(data[search_list[i]])
        if data[search_list[i]]["type"] == 4:
            source_0 = np.split(render_pos[data[search_list[i]]["source"][0]+217], 2)[1].tolist()[0]
            source_1 = -np.split(render_pos[data[search_list[i]]["source"][0]+217], 2)[0].tolist()[0]
            target_0 = np.split(render_pos[data[search_list[i]]["source"][1]+217], 2)[1].tolist()[0]
            target_1 = -np.split(render_pos[data[search_list[i]]["source"][1]+217], 2)[0].tolist()[0]
            # print(source_0, source_1, target_0, target_1)
            data[search_list[i]]["isValid"] = False
            data[search_list[i]]["source"] = [data[search_list[i]]["source"][0]+217, data[search_list[i]]["source"][1]+217]
            data[search_list[i]]["x0"] = source_0
            data[search_list[i]]["y0"] = source_1
            data[search_list[i]]["x1"] = target_0
            data[search_list[i]]["y1"] = target_1
        if data[search_list[i]]["type"] == 3:
            data[search_list[i]]["isValid"] = True
            data[search_list[i]]["cx"] = np.split(render_pos[search_list[i]], 2)[1].tolist()[0]
            data[search_list[i]]["cy"] = -np.split(render_pos[search_list[i]], 2)[0].tolist()[0]
            data[search_list[i]]["x0"] = 5
            # data[search_list[i]]["semantic_label"] = 100+data[search_list[i]]["group"]
    # print(data)
    data_list = []
    for i in range(0, len(search_list)):
        if search_list[i] != 9999:
            # print(data[search_list[i]])
            data_list.append(data[search_list[i]])
    # print(data_list)
    modified_dict = {}
    modified_dict["_data"] = data_list
    modified_dict["mode"] = 1
    modified_dict["orientation_agent"] = 0
    modified_dict["orientation_map"] = 90.0
    modified_dict["point_size"] = 5
    modified_dict["scale"] = 1
    # modified_dict["x0"] = 0
    # modified_dict["y0"] = 0
    modified_dict["x0"] = np.split(render_pos[9999], 2)[1].tolist()[0]
    modified_dict["y0"] = -np.split(render_pos[9999], 2)[0].tolist()[0]
    # print(modified_dict)
    json_str = json.dumps(modified_dict, indent=4)
    with open(name,'w') as json_file:
        json_file.write(json_str)


def group_layer2_data(data, cluster, edge_id):
    group_number = max(cluster.values())
    keys = list(data.keys())
    grouped_data = {}
    for i in range(0, group_number):
        name = str(100+i)
        file_name = "scene_" + name + ".json"
        # print(file_name)
        node = {}
        for j in range(0, len(keys)):
            try:
                # print(data[keys[j]]["group"])
                if data[keys[j]]["group"] == i:
                    node[int(keys[j])] = copy.deepcopy(data[keys[j]])
                    # print(node)
            except:
                pass
        grouped_data[file_name] = copy.deepcopy(node)
    # print(grouped_data)
    name_list = list(grouped_data.keys())
    # print(name_list)
    # print(grouped_data[name_list[0]])

    for i in range(0, group_number):
        this_group = grouped_data[name_list[i]]
        search_keys = list(this_group.keys())

        # add self
        grouped_data[name_list[i]][9999] = {"isValid": "True",
                                              "type": 3,
                                              "depth": 0,
                                              "angle": 0,
                                              "size": 4253569,
                                              "rec": 9999,
                                              "name": "self",
                                              "accessibility": 9999}

        for j in range(0, len(edge_id)):  # find related edges
            source = int(data[str(edge_id[j])].get("source")[0])+217
            target = int(data[str(edge_id[j])].get("source")[1])+217
        # print(source, target)
            if (source in search_keys) and (target in search_keys):
                # print(edge_id[i])
                grouped_data[name_list[i]][int(edge_id[j])] = copy.deepcopy(data[str(edge_id[j])])
                # print(grouped_data[name_list[i]][edge_id[j]])
    # print(grouped_data)

    for i in range(0, group_number):
        # print(name_list[i])

        #  read_all
        this_group = grouped_data[name_list[i]]

        # print(this_group.keys())
        this_group = dict([(k,this_group[k]) for k in sorted(this_group.keys())])
        # print(this_group)

        part_edge_id, part_all_edge, part_node_id, part_all_pos = read_new(this_group)
        # print(part_node_id)
        if part_node_id[0] != 9999:
            # init_graph
            G = general_attributes.init_graph(part_node_id, part_all_edge)
            # hierarchy render pos
            part_render_pos = hierarchy(part_node_id, part_all_edge, part_all_pos, 1000, 5, 5, 0)
            # to render json
            # print(this_group)
            key_list = list(this_group.keys())
            check = -1
            for j in range(0, len(key_list)):
                try:
                    check = this_group[key_list[j]]["single"]
                except:
                    pass
            if check == 0:
                to_render_json2(this_group, part_render_pos, name_list[i])


if __name__ == "__main__":
    all_data, edge_id, all_edge, node_id, all_pos, all_rec = general_attributes.read_all()
    G = general_attributes.init_graph(node_id, all_edge)
    cluster, groups = grouping(G)
    # grouping_visualization(cluster, node_id, all_pos, G)

    #  add group number
    all_data = filter_data(all_data, node_id, cluster)

    # first layer data
    layer1_data = layer(all_data, cluster, node_id, edge_id)
    # print(layer1_data)
    layer_edge_id, layer_edge, layer_node_id, layer_pos = read_new(layer1_data)
    render_pos = hierarchy(layer_node_id, layer_edge, layer_pos, 1000, 5, 5, 1)
    to_render_json1(layer1_data, render_pos, "scene_1.json")


    group_layer2_data(all_data, cluster, edge_id)
    

