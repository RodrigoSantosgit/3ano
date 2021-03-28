# ALUNOS:
# Daniel Lopes - 87881
# Rodrigo Santos - 89180
# Alex Kononov - 89227



import sys
import json
import asyncio
import websockets
import getpass
import os
import math
import collections
import time

from tree_search import *
from Bomberman import Bomberman
from mapa import Map

# Next 2 lines are not needed for AI agent
#import pygame
#pygame.init()


#-------------------------------------Global Variables-------------------------------------------
escape_steps = 5                            # Numero de passos para fugir da bomba
escape_flag = 0                             # Representa o modo Escape
keys_buffer = collections.deque(maxlen=5)   # Ultimas 5 keys enviadas para o servidor
target_wall = []                            # Parede a destruir
key = ''                                    # Proxima acao a tomar (movimento, bomba)
bomb_flag = 0                               # Indica quando a bomba está plantada
goal = []                                   # Destino final do bomber para destruir a parede
steps = []                                  # Lista das posições a percorrer até chegar ao goal
last_wall = []                              # Ultima parede destruida
minDistance = 0                             # Minima distancia até á parede
exit_flag = 0                               # Indica quando a porta está á vista e as paredes todas destruidas
recalculate = 0                             # Flag de necessidade de recalcular trajeto
reset_flag = 0                              # Resetar todas as variaveis
check_time_flag = 0                         # Prevene loops infinitos (testanto ainda)
search_enemies_flag = 0                     # Flag que indica quando estamos à procura dos inimigos
mapa = []
backup_target_wall = [0,0]                  # Segunda parede mais proxima, backup
backup = 0                                  # Siniliza que estamos a utilizar a parede de backup, para caso haja problemas em calcular o caminho para o goal
map_size = []                               # tamanho do mapa [x,y]
wait_flag = 0								# Indica quando bomber man espera que a bomba desapareça
last_key = ''                               # Indica a ultima tecla enviada para o servidor
powerup_flag = 0                            # Indica que bomberman está a ir na direção do powerup para o apanhar
i = 1                                       # Contador de frames
kill_minvo_flag = 0                         # Indica quando o BM procura o minvo
powerup_caught = 0                          # Indica quando o BM apanhou o powerup, nivel seguinte é resetada


# Funções:

#------------------------------------------------------------------------------------------------
                                # ESPERAR BOMBA DESAPARECER
def wait(state):
    global wait_flag
    global key
    global escape_flag
    global escape_steps


    # Aguardar que a bomba desapareca
    if len(state['bombs']) != 0:
        key = 'A'
        wait_flag = 1
    else:
        key = ''
        escape_steps = 5 
        escape_flag = 0
        wait_flag = 0
#------------------------------------------------------------------------------------------------
                                # ESCAPAR DA BOMBA
def escape_routine(state):   
    global escape_steps
    global escape_flag
    global keys_buffer
    global key
    global last_wall
    global exit_flag
    global target_wall
    global steps
    global search_enemies_flag
    global goal
    global last_key
    global wait_flag
    global mapa
    default_map = mapa.__getstate__()
    
    bomber_x = state['bomberman'][0] 
    bomber_y = state['bomberman'][1] 
    
    cima = default_map[bomber_x][bomber_y-1] # valor 1 ou 0
    cima_pos = [bomber_x,bomber_y-1] # coordenadas acima do bomberman
    
    baixo = default_map[bomber_x][bomber_y+1]
    baixo_pos = [bomber_x, bomber_y+1] # coordenadas abaixo do bomberman

    esquerda = default_map[bomber_x-1][bomber_y]
    esquerda_pos = [bomber_x-1, bomber_y] # coordenadas esquerda do bomberman

    direita = default_map[bomber_x+1][bomber_y]
    direita_pos = [bomber_x+1, bomber_y] # coordenadas direita do bomberman

    
    if wait_flag == 1: # Em modo procura inimigos, wait não funciona
        wait(state)
        return

    steps = [] # Forçar os steps a vazio, prevenir erros

    if exit_flag == 1: # modo exit, é desativado porque estamos em modo escape, no fim deste modo o exit é ativado novamente, pela função "exit_routine"
        exit_flag = 0

    if escape_steps > 0:
        key = keys_buffer[escape_steps-1] # A ultima tecla inserida no servidor será "resgatada" e usada de forma inversa para escapar
        if key == 'w':
            key = 's'
        elif key == 's':
            key = 'w'
        elif key == 'a':
            key = 'd'
        else:
            key = 'a'
        escape_steps = escape_steps - 1                  
        
    # Reset do modo escape
    else:
        key = 'A'
        escape_steps = 5 
        escape_flag = 0
        wait_flag = 0
        
        if search_enemies_flag == 1:
            calculate_shortest_path(state)
        
        else:
            last_wall = target_wall # Necessário para verificar se a parede destruida continua na lista de paredes (forçar verificação)

    
    if escape_steps < 4:

        key = ''
    
    #Prioridade 1 - CASO CONSIGA SE LOGO SE ESCONDER
    #--------------------------------------------------------------------------------------------------------
        if last_key == 's' or last_key == 'w':

            if direita != 1 and last_key != '' and direita_pos not in state['walls']:
                key = 'd'
                if len(state['bombs']) != 0:
                    for bomb in state['bombs']:
                        if bomber_x != bomb[0][0] and bomber_y != bomb[0][1]:
                            key = ''
                            wait_flag = 1

                last_key = key	
                return

            elif esquerda != 1 and last_key != '' and esquerda_pos not in state['walls']:
                key = 'a'
                if len(state['bombs']) != 0:
                    for bomb in state['bombs']:
                        if bomber_x != bomb[0][0] and bomber_y != bomb[0][1]:
                            key = ''
                            wait_flag = 1

                last_key = key	
                return

        elif last_key == 'a' or last_key == 'd':
            
            if baixo != 1 and last_key != '' and baixo_pos not in state['walls']:
                key = 's'
                if len(state['bombs']) != 0:
                    for bomb in state['bombs']:
                        if bomber_x != bomb[0][0] and bomber_y != bomb[0][1]:
                            key = ''
                            wait_flag = 1

                last_key = key	
                return


            elif cima != 1 and last_key != '' and cima_pos not in state['walls']:
                key = 'w'
                if len(state['bombs']) != 0:
                    for bomb in state['bombs']:
                        if bomber_x != bomb[0][0] and bomber_y != bomb[0][1]:
                            key = ''
                            wait_flag = 1

                last_key = key	
                return

    #Prioridade 2 - PROCURA OUTRA SOLUÇÃO
    #-------------------------------------------------------------------------------------------------------

        if baixo != 1 and last_key != 'w' and baixo_pos not in state['walls']: # Pode ir para baixo
            key = 's'
            if len(state['bombs']) != 0:
                for bomb in state['bombs']:
                    if bomber_x != bomb[0][0] and bomber_y != bomb[0][1]:
                        key = ''
                        wait_flag = 1			 

        elif direita != 1 and last_key != 'a' and direita_pos not in state['walls']:
            key = 'd'
            if len(state['bombs']) != 0:
                for bomb in state['bombs']:
                    if bomber_x != bomb[0][0] and bomber_y != bomb[0][1]:
                        key = ''
                        wait_flag = 1	

        elif esquerda != 1 and last_key != 'd' and esquerda_pos not in state['walls']:
            key = 'a'
            if len(state['bombs']) != 0:
                for bomb in state['bombs']:
                    if bomber_x != bomb[0][0] and bomber_y != bomb[0][1]:
                        key = ''
                        wait_flag = 1	

        elif cima != 1 and last_key != 's' and cima_pos not in state['walls']:
            key = 'w'
            if len(state['bombs']) != 0:
                for bomb in state['bombs']:
                    if bomber_x != bomb[0][0] and bomber_y != bomb[0][1]:
                        key = ''
                        wait_flag = 1	   

    last_key = key
#------------------------------------------------------------------------------------------------
                                # CALCULAR TECLA A ENVIAR PARA SERVIDOR
def calculate_key(state,steps):
    global bomb_flag
    global escape_flag
    global key
    global keys_buffer
    global exit_flag
    global recalculate
    global search_enemies_flag
    global mapa
    global goal
    global powerup_flag
    if state['bomberman'] == goal and search_enemies_flag != 1 and powerup_flag == 0:
        if state['bombs'] == []:
            key = 'B'
            escape_flag = 1
        return



    if search_enemies_flag == 1:
        #Chegou ao destino de espera (1º canto), flag volta a ficar a zero para entrar de novo na search_enemies() e calcular o outro destino (2º canto)
        if state['bomberman'] == goal:
            search_enemies_flag = 0
            search_to_kill_enemies(state)
            return
        # Enquanto função de matar os inimigos não é implementada fica parado


    if len(steps) > 1 and escape_flag != 1:

        if (steps[1])[0] - state['bomberman'][0] > 0:
            key = 'd'
            bomb_flag = 0
            recalculate = 0
        elif (steps[1])[0] - state['bomberman'][0] < 0:
            key = 'a'
            bomb_flag = 0
            recalculate = 0
        elif (steps[1])[1] - state['bomberman'][1] > 0:
            key = 's'
            bomb_flag = 0
            recalculate = 0
        else:
            key = 'w'
            bomb_flag = 0
            recalculate = 0

    elif bomb_flag == 0 and exit_flag == 0 and powerup_flag == 0 and search_enemies_flag == 0 and goal != state['exit'] and state['bombs'] == []:
        key = 'B'
        bomb_flag = 1
    
    elif key == 'B':
        escape_flag = 1
#------------------------------------------------------------------------------------------------
                                # CALCULAR DISTANCIA PELA HIPOTENUSA
def calculate_hypo(state):
    global target_wall
    global minDistance
    global backup_target_wall

    hypot_list = []
    
    if len(state['walls']) != 0: # Programação defensiva

        for x in state['walls']:
            hypot_list += [math.hypot(abs(x[0]-state['bomberman'][0]),abs(x[1]- state['bomberman'][1]))]
    
        if len(hypot_list) != 0: # Programação defensiva
            minDistance = min(hypot_list)
            target_wall = (state['walls'])[hypot_list.index(minDistance)]
            if len(state['walls']) > 1 and escape_flag==0:
                hypot_list.remove(minDistance)
                minDistance2 = min(hypot_list)
                backup_target_wall = (state['walls'])[hypot_list.index(minDistance2)]
#------------------------------------------------------------------------------------------------
                                # CALCULAR PROXIMA POSICAO PARA DESTRUIR PAREDE
def calculate_position(state):
    global target_wall
    global goal
    global backup

    if target_wall == []:
        return

    # Paredes x par y impar
    if target_wall[0] % 2 == 0 and state['bomberman'][0]<target_wall[0]:
        if [target_wall[0] - 1, target_wall[1]] not in state['walls']:
            goal = [target_wall[0] - 1, target_wall[1]]
        else:
            goal = [target_wall[0] + 1, target_wall[1]]
    elif target_wall[0] % 2 == 0 and state['bomberman'][0]>target_wall[0]:
        if [target_wall[0] + 1, target_wall[1]] not in state['walls']:
            goal = [target_wall[0] + 1, target_wall[1]]
        else:
            goal = [target_wall[0] - 1, target_wall[1]]
    elif target_wall[0] % 2 == 0 and state['bomberman'][0]==target_wall[0]:
        if [target_wall[0] + 1, target_wall[1]] not in state['walls']:
            goal = [target_wall[0] + 1, target_wall[1]]
        elif [target_wall[0] - 1, target_wall[1]] not in state['walls']:
            goal = [target_wall[0]- 1, target_wall[1]]
        elif state['bomberman'][1]>target_wall[1]:
            goal = [target_wall[0]-1, target_wall[1] + 1]
        else:
            goal = [target_wall[0]-1, target_wall[1] - 1]
    # Paredes x impar y par
    if target_wall[0] % 2 != 0 and state['bomberman'][1]<target_wall[1]:
        if [target_wall[0], target_wall[1]-1] not in state['walls']:
            goal = [target_wall[0], target_wall[1]-1]
        else:
            goal = [target_wall[0], target_wall[1]+1]
    elif target_wall[0] % 2 != 0 and state['bomberman'][1]>target_wall[1]:
        if [target_wall[0], target_wall[1]+1] not in state['walls']:
            goal = [target_wall[0], target_wall[1]+1]
        else:
            goal = [target_wall[0], target_wall[1]-1]
    elif target_wall[0] % 2 != 0 and state['bomberman'][1]==target_wall[1]:
        if [target_wall[0], target_wall[1]-1] not in state['walls']:
            goal = [target_wall[0], target_wall[1]-1]
        elif [target_wall[0], target_wall[1]+1] not in state['walls']:
            goal = [target_wall[0], target_wall[1]+1]
        elif state['bomberman'][0]>target_wall[0]:
        	goal = [target_wall[0]+1, target_wall[1]+1]
        else:
        	goal = [target_wall[0]-1, target_wall[1]+1]
    # Paredes x impar y impar
    if target_wall[0] % 2!= 0 and target_wall[1] %2!=0:
        if state['bomberman'][0] < target_wall[0]:
            if [target_wall[0]-1, target_wall[1]] not in state['walls'] and backup ==0:
                if [target_wall[0]-2, target_wall[1]] not in state['walls'] and backup ==0:
                    goal = [target_wall[0]-1, target_wall[1]]
                elif state['bomberman'][1] < target_wall[1]:
                    goal = [target_wall[0], target_wall[1]-1]
                elif state['bomberman'][1] > target_wall[1]:
                    goal = [target_wall[0], target_wall[1]+1]
                else:
                    goal = [target_wall[0], target_wall[1]+1]
            else:
                if [target_wall[0]+2, target_wall[1]] not in state['walls']:
                    goal = [target_wall[0]+1, target_wall[1]]
                elif state['bomberman'][1] < target_wall[1]:
                    goal = [target_wall[0], target_wall[1]-1]
                else:
                    goal = [target_wall[0], target_wall[1]+1]
        elif state['bomberman'][0] > target_wall[0]:
            if [target_wall[0]+1, target_wall[1]] not in state['walls'] and backup ==0:
                if [target_wall[0]+2, target_wall[1]] not in state['walls'] and backup ==0:
                    goal = [target_wall[0]+1, target_wall[1]]
                elif state['bomberman'][1] < target_wall[1]:
                    goal = [target_wall[0], target_wall[1]-1]
                elif state['bomberman'][1] > target_wall[1]:
                    goal = [target_wall[0], target_wall[1]+1]
                else:
                    goal = [target_wall[0]-1, target_wall[1]]
        elif state['bomberman'][1] >= target_wall[1]:
            if [target_wall[0], target_wall[1] + 1] not in state['walls'] and backup ==0:
                goal = [target_wall[0], target_wall[1] + 1]
            else:
                goal = [target_wall[0], target_wall[1] - 1]
        else:
            if [target_wall[0], target_wall[1] - 1] not in state['walls'] and backup ==0:
                goal = [target_wall[0], target_wall[1] - 1]
            else:
                goal = [target_wall[0], target_wall[1] + 1]         
#------------------------------------------------------------------------------------------------
                                # CALCULAR CAMINHO ATE A POSICAO CALCULADA
def calculate_shortest_path(state):
    global key
    global minDistance
    global steps
    global goal
    global mapa
    global backup_target_wall
    global target_wall
    global backup

    bombman = Bomberman(mapa.__getstate__(), state['walls'], state['bombs'])
    nextPosition = SearchProblem(bombman, state['bomberman'], goal)
    
    if minDistance <= 22:
        st = SearchTree(nextPosition, 'greedy')
    else:
        st = SearchTree(nextPosition, 'greedy')

    steps = st.search()   

    if (steps == []) and escape_flag == 0 and state['walls']!=[]: # Prevenir ficar preso no st.search
        target_wall = backup_target_wall
        backup_target_wall = []
        backup = 1
        calculate_position(state)
        calculate_shortest_path(state)
        backup = 0
#------------------------------------------------------------------------------------------------
                                # ESCAPAR PARA PORTA OU APANHAR POWERUP ANTES
def exit_routine(state):
    global exit_flag
    global steps
    global goal
    global last_wall
    global mapa
    global powerup_flag
    exit_flag = 1 # Esta flag é desativada se entrarmos em modo escape, para depois entrarmos novamente aqui e calcularmos o destino final.    
    
    if (len(state['enemies']) == 0) or ((state['level']==4) or (state['level']==1) or (state['level']==15) or (state['level']==7) or (state['level']==3)):
        if 'powerups' in state and state['powerups']!= [] and state['level']!=2 and state['level']!=5 and state['level']!=6 and state['level']!=11 and state['level']!=12:
            goal = state['powerups'][0][0]
            exit_flag = 0
            powerup_flag = 1
        else:
            powerup_flag = 0
            goal = state['exit'] # Não havendo inimigos, prosseguir para a porta
            exit_flag = 0        # Ao prosseguir para a porta desativamos a exit_flag (caminho já será calculado, não precisa entrar)

    
    # Calculo dos steps para o destino final, existe uma função "calculate_shortest_path" mas esta implementação usa variáveis diferentes
    if powerup_flag:
        bombman = Bomberman(mapa.__getstate__(), state['walls'] + [state['exit']], state['bombs'])
    else:
        bombman = Bomberman(mapa.__getstate__(), state['walls'], state['bombs'])
    nextPosition = SearchProblem(bombman, state['bomberman'], goal)
    st = SearchTree(nextPosition, 'greedy')
    steps = st.search()
#------------------------------------------------------------------------------------------------
                                # VERIFICAR DISTANCIA DE SEGURANÇA AOS INIMIGOS
def check_enemie_dist(state):
    for x in range(0, len(state['enemies'])):
        if state['enemies'][x]['name'] != 'Minvo':
            if math.hypot(abs(state['bomberman'][0]-state['enemies'][x]['pos'][0]),abs(state['bomberman'][1]- state['enemies'][x]['pos'][1])) < 3:
                if (state['bomberman'][0] == state['enemies'][x]['pos'][0]) and (state['bomberman'][0]%2 != 0):
                    return True
                elif (state['bomberman'][1]==state['enemies'][x]['pos'][1]) and (state['bomberman'][1]%2 != 0):
                    return True
        else:
            if math.hypot(abs(state['bomberman'][0]-state['enemies'][x]['pos'][0]),abs(state['bomberman'][1]- state['enemies'][x]['pos'][1])) <2:
                if (state['bomberman'][0] == state['enemies'][x]['pos'][0]) and (state['bomberman'][0]%2 != 0):
                    return True
                elif (state['bomberman'][1]==state['enemies'][x]['pos'][1]) and (state['bomberman'][1]%2 != 0):
                    return True
    return False
#------------------------------------------------------------------------------------------------
                                # RESETAR FLAGS E VARIAVEIS IMPORTANTES
def reset_routine():
    global bomb_flag
    global steps
    global goal 
    global target_wall
    global escape_flag
    global keys_buffer
    global key
    global last_wall
    global exit_flag
    global recalculate
    global reset_flag
    global search_enemies_flag
    global powerup_flag
    global i
    global powerup_caught
    if reset_flag == 1:
        return 

    escape_steps = 5                            # Numero de passos para fugir da bomba
    escape_flag = 0                             # Representa o modo Escape
    keys_buffer = collections.deque(maxlen=5)   # Ultimas 5 keys enviadas para o servidor
    target_wall = []                            # Parede a destruir
    key = ''                                   # Proxima acao a tomar (movimento, bomba)
    bomb_flag = 0                               # Indica quando a bomba está plantada
    goal = []                                   # Destino final do bomber para destruir a parede
    steps = []                                  # Lista das posições a percorrer até chegar ao goal
    last_wall = []                              # Ultima parede destruida
    minDistance = 0                             # Minima distancia até á parede
    exit_flag = 0                               # Indica quando a porta está á vista e as paredes todas destruidas
    recalculate = 1                             # Flag de necessidade de recalcular trajeto
    keys_buffer.append('w')
    keys_buffer.append('w')
    keys_buffer.append('w')
    keys_buffer.append('w')
    keys_buffer.append('w')
    reset_flag = 1
    search_enemies_flag = 0
    powerup_flag = 0
    i = 1
    powerup_caught = 0
#------------------------------------------------------------------------------------------------
                                # ESPERAR LISTA DE PAREDES ATUALIZADA
def sync_wall_list(state):
    global check_time_flag
    global key

    check_time_flag = check_time_flag + 1 # Contar o numero de vezes seguidas que entra aqui (prevenir loop infinito)                   
    key = ''

    if check_time_flag > 6:
        softReset(state)
#------------------------------------------------------------------------------------------------
                                # SIMPLES RESET EM ALGUMAS FLAGS
def softReset(state):
    global check_time_flag
    global key
    global last_wall
    global target_wall
    global recalculate
    global goal
    global steps
    global escape_flag
    global search_enemies_flag
    global wait_flag
    global escape_steps

    check_time_flag = 0
    last_wall = [0,0]
    target_wall = []
    key = ''
    steps = []
    if search_enemies_flag == 0:
        goal = []
    recalculate = 1
    if state['bombs'] != []:
        escape_flag = 1
    else:
    	escape_flag = 0
    wait_flag = 0 
    escape_steps = 5
#------------------------------------------------------------------------------------------------

def killMinvo(state):
    global goal
    global search_enemies_flag
    global map_size
    global kill_minvo_flag
    global minvo_corner_4

    x = map_size[0] # 51
    y = map_size[1] # 49
    
    kill_minvo_flag = 1    
    search_enemies_flag = 1 # Esta tag fica sempre ativada quando o bomber está á procura nos cantos, é necessária para não entrar noutras funções

    if (y % 2) == 0:
        y = y - 2
    if (x % 2) == 0:
        x = x - 1
                                          #Default Map:
    minvo_corner_5 = [x-(x-1),y-2]        #[1,29]
    minvo_corner_4 = [x-(x-1),y-(y-1)]    #[1,1]
    minvo_corner_3 = [x-2,y-(y-1)]        #[47,1]
    minvo_corner_2 = [x-2,y-2]            #[47,29]

        
    if state['bomberman'] == minvo_corner_4:
        goal = minvo_corner_5 
        
    elif state['bomberman'] == minvo_corner_5:
        goal = minvo_corner_2
        
    elif state['bomberman'] == minvo_corner_2:
        goal = minvo_corner_3
    
    elif state['bomberman'] == minvo_corner_3:
        goal = minvo_corner_4
    else:
        goal = minvo_corner_4
#------------------------------------------------------------------------------------------------

def killOneal(state):
    global goal
    global search_enemies_flag

    search_enemies_flag = 1
    goal = state['enemies'][0]['pos']
#------------------------------------------------------------------------------------------------    

def killBallom(state):
    global goal
    global search_enemies_flag
    global map_size

    x = map_size[0] # 51
    y = map_size[1] # 49

    search_enemies_flag = 1 # Esta tag fica sempre ativada quando o bomber está á procura nos cantos, é necessária para não entrar noutras funções

    if (y % 2) == 0:
        y = y - 2
    if (x % 2) == 0:
        x = x - 1
                                 #Default Map:
    corner_1 = [x-(x-1),y-(y-1)] #[1,1]
    corner_2 = [x-2,y-(y-1)]     #[49,1]
    corner_3 = [x-2,y-2]         #[49,29]
    corner_4 = [x-(x-1),y-2]     #[1,29]


    if state['bomberman'] == corner_1:
        goal = corner_2 
        
    elif state['bomberman'] == corner_2:
        goal = corner_3 
        
    elif state['bomberman'] == corner_3:
        goal = corner_4 
        
    elif state['bomberman'] == corner_4:
        goal = corner_1 
                
    else:
        goal = corner_1 
#------------------------------------------------------------------------------------------------
                                # NO FIM, SEM PAREDES, PROCURAR OS INIMIGOS
def search_to_kill_enemies(state):
    if state['enemies']!=[]:
        if state['enemies'][0]['name'] == 'Balloom' or state['enemies'][0]['name'] == 'Doll':
            killBallom(state)
            calculate_shortest_path(state)

        elif state['enemies'][0]['name'] == 'Oneal' or state['enemies'][0]['name'] == 'Kondoria' or state['enemies'][0]['name'] == 'Ovapi':
            killOneal(state)
            calculate_shortest_path(state)
        elif state['enemies'][0]['name'] == 'Minvo' or state['enemies'][0]['name'] == 'Pass':
        	killMinvo(state)
        	calculate_shortest_path(state)
        else:
            return      
#------------------------------------------------------------------------------------------------
                                # VERIFICAÇAO DA SEGURANÇA DO BOMBERMAN NA PROXIMA ITERAÇAO
def checkSafety(state):
    global key
    
    if state['enemies'] != []:
        for e in state['enemies']:
            if (e['name']!= 'Oneal') and (e['name']!= 'Kondoria') and (e['name']!= 'Minvo') and (e['name']!= 'Ovapi') and (e['name']!= 'Pass'):
                if key == 'w':
                    if [state['bomberman'][0], state['bomberman'][1] - 1] == e['pos'] or [state['bomberman'][0], state['bomberman'][1] - 2] == e['pos']:
                        return True
                elif key == 's':
                    if [state['bomberman'][0], state['bomberman'][1] + 1] == e['pos'] or [state['bomberman'][0], state['bomberman'][1] + 2] == e['pos']:
                        return True
                elif key == 'd':
                    if [state['bomberman'][0] + 1, state['bomberman'][1]] == e['pos'] or [state['bomberman'][0] + 2, state['bomberman'][1]] == e['pos']:
                        return True
                elif key == 'a':
                    if [state['bomberman'][0] - 1, state['bomberman'][1]] == e['pos'] or [state['bomberman'][0]- 2, state['bomberman'][1]] == e['pos']:
                        return True
                if (state['bomberman'] == [e['pos'][0]+1, e['pos'][1]+2]) or (state['bomberman'] == [e['pos'][0]+1, e['pos'][1]+1]):
                    return True
                elif (state['bomberman'] == [e['pos'][0]-1, e['pos'][1]+2]) or (state['bomberman'] == [e['pos'][0]-1, e['pos'][1]+1]):
                    return True
                elif (state['bomberman'] == [e['pos'][0]+1, e['pos'][1]-2]) or (state['bomberman'] == [e['pos'][0]+1, e['pos'][1]-1]):
                    return True
                elif (state['bomberman'] == [e['pos'][0]-1, e['pos'][1]-2]) or (state['bomberman'] == [e['pos'][0]-1, e['pos'][1]-1]):
                    return True
                if (state['bomberman'] == [e['pos'][0]+2, e['pos'][1]+1]) or (state['bomberman'] == [e['pos'][0]+1, e['pos'][1]+1]):
                    return True
                elif (state['bomberman'] == [e['pos'][0]-2, e['pos'][1]+1]) or (state['bomberman'] == [e['pos'][0]-1, e['pos'][1]+1]):
                    return True
                elif (state['bomberman'] == [e['pos'][0]+2, e['pos'][1]-1]) or (state['bomberman'] == [e['pos'][0]+1, e['pos'][1]-1]):
                    return True
                elif (state['bomberman'] == [e['pos'][0]-2, e['pos'][1]-1]) or (state['bomberman'] == [e['pos'][0]-1, e['pos'][1]-1]):
                    return True
    return False
#------------------------------------------------------------------------------------------------

async def agent_loop(server_address="localhost:8000", agent_name="student"):
    async with websockets.connect(f"ws://{server_address}/player") as websocket:
        # Receive information about static game properties
        await websocket.send(json.dumps({"cmd": "join", "name": agent_name}))
        msg = await websocket.recv()
        game_properties = json.loads(msg)
        # You can create your own map representation or use the game representation:       
        # Next 3 lines are not needed for AI agent
        #SCREEN = pygame.display.set_mode((299, 123))
        #SPRITES = pygame.image.load("data/pad.png").convert_alpha()
        #SCREEN.blit(SPRITES, (0, 0))

        # Variables
        #------------------------------------------------------------------------------------------------------------
        global bomb_flag
        global steps
        global goal 
        global target_wall
        global escape_flag
        global keys_buffer
        global key
        global last_wall
        global exit_flag
        global recalculate 
        global reset_flag
        global check_time_flag
        global search_enemies_flag
        global mapa
        global map_size
        global kill_minvo_flag
        global last_key
        global last_bomberman_pos
        global i
        global powerup_caught
        keys_buffer.append('w')
        keys_buffer.append('w')
        keys_buffer.append('w')
        keys_buffer.append('w')
        keys_buffer.append('w')
        lives = 0       # Numero de vidas do bm atual
        check_lives = 3 # Numero de vidas do bm anterior        
        last_level = 1              
        key_count = 0
        mapa = Map(size=game_properties["size"], mapa=game_properties["map"])
        map_size = game_properties["size"]       
        state = json.loads(await websocket.recv()) # Forçar a posição do bomberman ficar atualizada no primeiro frame       
        #--------------------------------------------------------------------------------------------------------------
        
        while True:
            try:                
                state = json.loads(await websocket.recv())   
                           
                if 'lives' in state:
                    lives = state['lives']
                else:
                    break
                if 'level' in state:
                    level = state['level']
                
                # VERIFICAR SE TRANSITOU DE NIVEL
                if level > last_level:
                    last_level = level
                    reset_routine()

                # VERIFICA SE PODE PASSAR DE NIVEL
                if len(state['enemies'])==0 and len(steps)==0 and exit_flag==0 and state['exit']!=[] and (powerup_caught==1 or ((state['level']!=4) and (state['level']!=1) and (state['level']!=15) and (state['level']!=7) and (state['level']!=3) and (state['level']!=10))): #Se não houver inimigos, lista steps vazia e a porta à vista
                    exit_routine(state)
                    calculate_key(state,steps)
                    steps = steps[1:]
                    reset_flag = 0
                    check_time_flag = 0
                
                # VERIFICA SE MORREU
                elif lives < check_lives:
                    softReset(state)
                    check_lives = lives

                # ATIVAR MODO DE ESCAPAR
                elif escape_flag == 1:
                    escape_routine(state) 

                # VERIFICAR DISTANCIA DO INIMIGO              
                elif check_enemie_dist(state):
                    key = 'B'       # Se o inimigo estiver perto
                    escape_flag = 1 # Ativa o modo escapar
                    bomb_flag = 1   # Sinaliza que a bomba foi posta
                    recalculate = 1 # Calcula novo caminho depois de matar inimigo                                 
                
                # APANHAR POWERUPS MAIS IMPORTANTES ASSIM QUE OS ENCONTRE (FLAMES, SPEED, DETONATOR E WALLPASS) 
                elif ((state['level']==4) or (state['level']==1) or (state['level']==15) or (state['level']==7) or (state['level']==3) or (state['level']==10)) and state['powerups']!= []:
                    goal = state['powerups'][0][0]
                    if len(steps)==0:
                        calculate_shortest_path(state)
                    calculate_key(state,steps)
                    steps=steps[1:]
                    powerup_flag = 1
                    if steps[0]==goal:
                        powerup_caught = 1
                        powerup_flag=0
                        recalculate = 1

                # ESPERAR NO INICIO
                elif i < 8:
                    key = ''

                # AGUARDAR ATUALIZAÇÃO DA LISTA DE PAREDES COM O SERVIDOR
                elif last_wall in state['walls'] and recalculate == 0 and len(steps) == 0:                   
                    state = json.loads(await websocket.recv())
                    sync_wall_list(state)
                         
                else:
                    check_time_flag = 0                     
                    
                    # VERIFICAR LISTA DE STEPS, LISTA DE PAREDES E FLAG QUE INDICA O MODO EXIT DESATIVADO
                    if len(state['walls']) == 0 and len(steps) == 0 and exit_flag == 0 and search_enemies_flag == 0: # Se não verificar a condição do exit_flag, entramos sempre na exit_routine, basta só 1 vez
                        search_to_kill_enemies(state)
                    
                    # CALCULOS ATÉ À PAREDE MAIS PROXIMA
                    elif (len(steps) == 0 and escape_steps == 5 and exit_flag==0 and (len(state['walls'])>0)) and (last_wall not in state['walls']) or (recalculate and search_enemies_flag == 0):                  
                        # Calcular a distancia entre o BomberMan e a parede pela hipotenusa                     
                        calculate_hypo(state)
                        # Calcular a posição para colocar a bomba
                        calculate_position(state)
                        # Calcular o caminho mais curto
                        calculate_shortest_path(state)
                   
                    # CALCULAR KEY A ENVIAR
                    calculate_key(state,steps)               
                    steps = steps[1:]
                    last_bomberman_pos = state['bomberman']
                
                # VERIFICAR SE A PRÓXIMA POSIÇÃO IRÁ MATAR O BOMBERMAN, APENAS VERIFICADO SE NÃO ESTIVER A FUGIR NEM ESTIVER A COLOCAR BOMBA
                if (escape_flag == 0) and checkSafety(state) and key != 'B' and exit_flag==0:
                    softReset(state)
                    
                # CASO ESTEJA Á PROCURA DOS ENIMIGOS E FIQUE SEM STEPS DEVIDO A SOFTRESET
                if search_enemies_flag == 1 and len(steps)==0:
                    calculate_shortest_path(state)               
                
                # GUARDAR ULTIMA TECLA DE MOVIMENTO NO RESPETIVO BUFFER
                if key != 'B' and key != '' and key != 'A' and key != 'x':
                    keys_buffer.append(key)
                
                # PREVENIR FICAR DEMASIADO TEMPO PARADO
                if (key == '' or key == keys_buffer[-1]) and search_enemies_flag == 0 and exit_flag == 0:
                    key_count += 1
                    
                    if key_count > 65:
                        key = 'B'
                        escape_flag = 1
                        key_count = 0
                else:
                    key_count = 0
                
                #--------------------------------------------------------------------------------------------------------------------------------
               
                i = i + 1

                await websocket.send(json.dumps({"cmd": "key", "key": key})) # send key command to server - you must implement this send in the AI agent
            except websockets.exceptions.ConnectionClosedOK:
                print("Server has cleanly disconnected us")
                return
        
        #--------------------------------------------------------------------------------------------------------------

# DO NOT CHANGE THE LINES BELLOW
# You can change the default values using the command line, example:
# $ NAME='bombastico' python3 client.py
loop = asyncio.get_event_loop()
SERVER = os.environ.get("SERVER", "localhost")
PORT = os.environ.get("PORT", "8000")
NAME = os.environ.get("NAME", getpass.getuser())
loop.run_until_complete(agent_loop(f"{SERVER}:{PORT}", NAME))             