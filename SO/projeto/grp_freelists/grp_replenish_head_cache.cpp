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
#include <string.h>
#include <errno.h>
#include <iostream>
#include "core.h"
#include "dal.h"
#include "freelists.h"
#include "bin_freelists.h"

namespace sofs19
{
    void grpReplenishHeadCache(void)
    {
        soProbe(443, "%s()\n", __FUNCTION__);

        /* change the following line by your code */
        /*binReplenishHeadCache();*/

        SOSuperBlock* SuperBlock;
        uint32_t bufferReader[RPB];       


		/* Get super block pointer */
        SuperBlock = soGetSuperBlockPointer();

        /* Check if Head Cache from SuperBlock is empty */
        if((SuperBlock->head_cache.ref[HEAD_CACHE_SIZE-1]) != NullReference)
        {
        	return; /* Not empty, return */
        }

        /* Read from data block to the buffer */
        soReadDataBlock(SuperBlock->head_blk, bufferReader);


        /* Replenish SuperBlock cache */
        uint32_t j = 0;
        uint32_t i = 1;
        for (i = 1; i < RPB; i++)
        {
        	
        	if (bufferReader[i] == NullReference)                
        		i = i + HEAD_CACHE_SIZE-1; /* i = 65 / i = 129 / i = 193 */        	
        	       	
        	else
            {
	            if (j >= HEAD_CACHE_SIZE)
	        	  break;

                if (SuperBlock->head_idx == RPB - HEAD_CACHE_SIZE + 1)
                {
                    j++;
                    SuperBlock->head_cache.ref[j] = bufferReader[i];                    
                    bufferReader[i] = NullReference;
                    
                }
                else
                {   
                    SuperBlock->head_cache.ref[j] = bufferReader[i];
                    bufferReader[i] = NullReference;
                    j++;                 
                }	           
            }
        }

        /* Last replenish */
        if (SuperBlock->head_idx == RPB - HEAD_CACHE_SIZE + 1)
        {
            bufferReader[0] = NullReference;
            soWriteDataBlock(SuperBlock->head_blk, bufferReader);
            
            SuperBlock->tail_cache.ref[SuperBlock->head_blk - 1] = SuperBlock->head_blk; 
            SuperBlock->head_blk++;
            SuperBlock->head_idx = 1;
            SuperBlock->head_cache.idx = 1;
            soSaveSuperBlock();
            
            return;
        }
        
        /* Normal replenish */
        soWriteDataBlock(SuperBlock->head_blk, bufferReader);        
        SuperBlock->head_idx = i;
        SuperBlock->head_cache.idx = 0;
        soSaveSuperBlock();


    }
};

