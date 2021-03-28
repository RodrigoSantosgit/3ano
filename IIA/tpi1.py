# Nome: Rodrigo Lopes da Silva Santos
# Nmec: 89180

from tree_search import *

class MyNode(SearchNode):
    def __init__(self,state,parent,depth=0,cost=0,evalfunc=0,children=None):
        # Inicializacao dos nodes
        super().__init__(state, parent)
        self.depth = depth
        self.cost = cost
        self.evalfunc = evalfunc + cost
        self.children = children
    
    # Funcao para verificar se um nó já se encontra na arvore
    def in_parent(self, state):
        if self.parent == None:
            return False
        return self.parent.state == state or self.parent.in_parent(state)

class MyTree(SearchTree):

    def __init__(self,problem, strategy='breadth',max_nodes=None): 
        #IMPLEMENT HERE
        # Inicializacao da arvore
        super().__init__(problem,strategy)
        self.max_nodes = max_nodes
        self.solution_cost = 0
        self.solution_length = 0
        self.root = MyNode(self.problem.initial,
        	None,
        	0,
        	0,
        	self.problem.domain.heuristic(self.problem.initial, self.problem.goal))
        self.open_nodes = [self.root]
        self.total_nodes = 1
        self.terminal_nodes = 0
        self.non_terminal_nodes = 1

    def astar_add_to_open(self,lnewnodes):
        #IMPLEMENT HERE
        # Adiciona os elementos de lnewnodes a open_nodes e ordena por ordem de evalfunc 
        self.open_nodes = sorted(lnewnodes + self.open_nodes, key=lambda no: no.evalfunc)

    def effective_branching_factor(self):
        #IMPLEMENT HERE
        # Calculo da formula aproximada de effective_branching_factor
        return (self.non_terminal_nodes)**(1/(self.solution_length))

    def update_ancestors(self,node):
        #IMPLEMENT HERE
        if node.children != None and node.children!=[]:
            # Atualizar node atual com o menor evalfunc dos nós filhos
            node.evalfunc = min(list(no.evalfunc for no in node.children))
        if node.parent != None:
            # Atualizar nodes anteriores
        	self.update_ancestors(node.parent)

    def discard_worse(self):
        #IMPLEMENT HERE
        nodeTosearch = [self.root]
        maxEval= 0
        MaxNode = None

        # Procura do Nó com maior valor de 'evalfunc' e cujos filhos sejam nós folha
        while nodeTosearch != []:
            node = nodeTosearch.pop(0)
            candidate = 1
            if node.children != None and node.children != []:
                for n in node.children:
                    if n.children != None and n.children != []:
                        candidate = 0
                if candidate:
                	if node.evalfunc > maxEval:
                		maxEval = node.evalfunc
                		MaxNode = node
                else:
                    nodeTosearch += node.children
        
        # Eliminar nós filhos da list open_nodes e atualizar terminal nodes
        for nChild in MaxNode.children:
            if nChild in self.open_nodes:
                self.open_nodes.remove(nChild)
                self.terminal_nodes -= 1

        MaxNode.children = [] # libertar nós filhos

        # Adicionar o nó de maior evalfunc em open_nodes novamente e atualizar terminal e non_terminal nodes
        self.add_to_open([MaxNode])
        self.non_terminal_nodes -= 1
        self.terminal_nodes +=1

    def search2(self):
        #IMPLEMENT HERE
        while self.open_nodes != []:
            node = self.open_nodes.pop(0)
            # Verificar se a solucao foi encontrada e se tal atualizar terminal, non_terminal nodes, custo e length
            if self.problem.goal_test(node.state):
                self.solution_cost = node.cost
                self.solution_length = node.depth
                self.non_terminal_nodes -= 1
                self.terminal_nodes +=1
                return self.get_path(node)

            lnewnodes = []
            
            # Remover nós filhos de maior evalfunc caso arvore exceda limite de nos
            if self.max_nodes != None:
                while (self.non_terminal_nodes + self.terminal_nodes) > self.max_nodes:
                    self.discard_worse()

            for a in self.problem.domain.actions(node.state):
                newstate = self.problem.domain.result(node.state,a)
                if not node.in_parent(newstate):
                    newnode = MyNode(newstate,
                	    node,
                	    node.depth+1,
                        node.cost+self.problem.domain.cost(node.state,a),
                        self.problem.domain.heuristic(newstate, self.problem.goal),
                        None)
                    lnewnodes.append(newnode)
                    self.total_nodes+=1 # Incrementar numero total de nodes criados na arvore
            
            # Atualizar valores de terminal e non_terminal nodes
            node.children = lnewnodes
            if lnewnodes != []:
                self.terminal_nodes += len(lnewnodes) - 1
                self.non_terminal_nodes +=1
            # Adicionar lnewnodes á lista de nodes para abrir
            self.add_to_open(lnewnodes)
            # Atualizar evalfunc do node e seus parentes
            self.update_ancestors(node)

        return None

    # shows the search tree in the form of a listing
    def show(self,heuristic=False,node=None,indent=''):
        if node==None:
            self.show(heuristic,self.root)
            print('\n')
        else:
            line = indent+node.state
            if heuristic:
                line += (' [' + str(node.evalfunc) + ']')
            print(line)
            if node.children==None:
                return
            for n in node.children:
                self.show(heuristic,n,indent+'  ')


