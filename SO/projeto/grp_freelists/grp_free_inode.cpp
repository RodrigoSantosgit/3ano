/*
 *  \author António Rui Borges - 2012-2015
 *  \authur Artur Pereira - 2016-2019
 */

/*
 * MIECT
 * Student: Daniel Lopes - 87881
 *
 */

#include "grp_freelists.h"
#include <stdio.h>
#include <errno.h>
#include <inttypes.h>
#include <time.h>
#include <unistd.h>
#include <sys/types.h>
#include "core.h"
#include "dal.h"
#include "freelists.h"
#include "bin_freelists.h"

namespace sofs19
{
    void grpFreeInode(uint32_t in)
    {
        soProbe(402, "%s(%u)\n", __FUNCTION__, in);

        SOInode* INode; 
        SOInode* PrevTailINode; 
        SOSuperBlock* SuperBlock; 
		
        SuperBlock = soGetSuperBlockPointer(); 		
        
        /* iNode Pointer to be freed */	
        int ih = soOpenInode(in);	
		INode = soGetInodePointer(ih); 	
        
		/* Last iNode pointer */
		int ih_tail = soOpenInode(SuperBlock->itail);
        PrevTailINode = soGetInodePointer(ih_tail);         
        

        if (INode->mode == INODE_FREE) 
        { 
        	soCloseInode(ih);
        	return;
        }
              
        /* Reset iNode */
        INode->mode = INODE_FREE;
        INode->lnkcnt = 0;
        INode->owner = 0;
        INode->group = 0;
        INode->size = BlockSize;
        INode->blkcnt = 0;
        INode->mtime = 0;
        INode->ctime = 0;
        INode->atime = 0;        
        INode->next = NullReference; /* NullReference, it will be the last */
        for (uint32_t i = 0; i < N_DIRECT; i++)	{ INode->d[i] = NullReference; }
        for (uint32_t i = 0; i < N_INDIRECT; i++) { INode->i1[i] = NullReference; }
        for (uint32_t i = 0; i < N_DOUBLE_INDIRECT; i++) { INode->i2[i] = NullReference; }
  		
        PrevTailINode->next = in;  /*Tail point to new freed iNode */
        SuperBlock->itail = in;   /* Tail will be the new freed iNode */
        SuperBlock->ifree++; 	  
 
     	soSaveSuperBlock(); 
     	soSaveInode(ih);	
    	soSaveInode(ih_tail);
    	soCloseInode(ih_tail);
        soCloseInode(ih);	

        /* change the following line by your code */
        /*binFreeInode(in);*/
    }
};

