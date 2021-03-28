# Nome: Rodrigo Lopes da Silva Santos
# N. mec: 89180

from semantic_network import *
from bayes_net import *
from math import *

class MySN(SemanticNetwork):

    def get_dependents(self, entity):
        dependents = list(set([d.relation.entity1 for d in self.declarations if (isinstance(d.relation, Depends) and d.relation.entity2 == entity) 
            or (isinstance(d.relation, Subtype) and d.relation.entity2 == entity)]))
        for d in dependents:
        	dependents = list(set(dependents + self.get_dependents(d)))
        return dependents


    def query_dependents(self,entity):
        #IMPLEMENT HERE
        dependents = self.get_dependents(entity)
        
        sups = list(set([d.relation.entity2 for d in self.declarations if isinstance(d.relation, Subtype) and d.relation.entity1 in dependents]
        	+ [d.relation.entity1 for d in self.declarations if isinstance(d.relation, Subtype) 
        	and d.relation.entity1 not in list(set([dep.relation.entity2 for dep in self.declarations if isinstance(dep.relation, Depends)])) and d.relation.entity2==entity]))

        for s in sups:
        	if s in dependents:
        	    dependents.remove(s)

        return dependents


    def query_causes(self, entity):
        #IMPLEMENT HERE
        causes = list(set([d.relation.entity2 for d in self.declarations if (isinstance(d.relation, Depends) and d.relation.entity1 == entity) 
        	or (isinstance(d.relation, Subtype) and d.relation.entity1 == entity)]))
        for c in causes:
        	causes = list(set(causes + self.query_causes(c))) 

        subs = list(set([d.relation.entity2 for d in self.declarations if isinstance(d.relation, Subtype) and d.relation.entity1 in causes]))
        for s in subs:
        	if s in causes:
        	    causes.remove(s)

        return causes

    def query_causes_sorted(self,entity):
        #IMPLEMENT HERE
        causes = self.query_causes(entity)
        
        times = [(d.relation.entity1, d.relation.entity2) for d in self.declarations if (isinstance(d.relation, Association) 
        	and d.relation.entity1 in causes and d.relation.name == 'debug_time')]
        
        timesMean=[]

        for t in times:
        	div = 0
        	sumTimes = 0
        	for t2 in times:
        		if t[0] == t2[0]:
        			div+=1
        			sumTimes += t2[1]

        	tup = (t[0], floor(sumTimes/div))
        	if tup not in timesMean:
        	    timesMean += [tup]
        
        return sorted(timesMean, key=lambda x: x[1])

class MyBN(BayesNet):

    def markov_blanket(self,var):
        #IMPLEMENT HERE
        markov_blanket = list(name[0] for name in list(tupls for tupls in list(self.dependencies[var])[0]))
        
        for d in list(self.dependencies):
            for tupls in list(list(self.dependencies[d])[0]):
                if var in tupls:
                    markov_blanket += [name[0] for name in list(list(self.dependencies[d])[0]) if name[0]!=var] + [d]

        return markov_blanket
