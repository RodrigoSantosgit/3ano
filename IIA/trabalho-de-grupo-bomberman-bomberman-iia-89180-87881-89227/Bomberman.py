# ALUNOS:
# Daniel Lopes - 87881
# Rodrigo Santos - 89180
# Alex Kononov - 89227

from tree_search import *
from mapa import Map, Tiles
import math
class Bomberman(SearchDomain):
    def __init__(self, map, walls, bombs):
        self.mapa = map
        self.walls = walls
        self.bombs = bombs

    def actions(self,node):
        actlist = []
        if ((self.mapa[node[0] + 1])[node[1]] != 1) and ([node[0] + 1, node[1]] not in self.walls):
            if self.bombs != []:
                if [node[0] + 1, node[1]] not in self.bombs[0]:
                    actlist += ['d']
            else:
                actlist += ['d']
        if ((self.mapa[node[0] - 1])[node[1]] != 1) and ([node[0] - 1, node[1]] not in self.walls):
            if self.bombs != []:
                if [node[0] - 1, node[1]] not in self.bombs[0]:
                    actlist += ['a']
            else:
                actlist += ['a']
        if ((self.mapa[node[0]])[node[1] + 1] != 1) and ([node[0],node[1] + 1] not in self.walls):
            if self.bombs != []:
                if [node[0], node[1] + 1] not in self.bombs[0]:
                    actlist += ['s']
            else:
                actlist += ['s']
        if ((self.mapa[node[0]])[node[1] - 1] != 1) and ([node[0],node[1] - 1] not in self.walls):
            if self.bombs != []:
                if [node[0], node[1] - 1] not in self.bombs[0]:
                    actlist += ['w']
            else:
                actlist += ['w']
        return actlist

    def result(self,node,action):
        if action == 'd':
        	return [node[0] + 1, node[1]]

        if action == 'a':
        	return [node[0] - 1, node[1]]

        if action == 'w':
        	return [node[0], node[1] - 1]

        if action == 's':
        	return [node[0], node[1] + 1]

    def cost(self, cidade, action):
    	return 1

    def heuristic(self, state, goal_state):
        return math.floor(math.hypot(state[0] - goal_state[0], state[1]- goal_state[1]))

