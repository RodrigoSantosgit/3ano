/*
 *  \author António Rui Borges - 2012-2015
 *  \authur Artur Pereira - 2016-2019
 */

#include "grp_freelists.h"

#include "core.h"
#include "dal.h"
#include "freelists.h"
#include "bin_freelists.h"

#include <stdio.h>
#include <errno.h>
#include <string.h>
#include <iostream>
using namespace std;

namespace sofs19
{
    /* only fill the current block to its end */
    void grpDepleteTailCache(void)
    {
        soProbe(444, "%s()\n", __FUNCTION__);

        /* change the following line by your code */
        /*binDepleteTailCache();*/

        SOSuperBlock* SuperBlock;
        uint32_t bufferReader[RPB];

        //get sb pointer
        SuperBlock = soGetSuperBlockPointer();

        //check if tail cache is not full

        if((SuperBlock -> tail_cache.ref[TAIL_CACHE_SIZE-1]) == NullReference)
        {
            printf("%s\n","Tail cache not full!");
            return;
        }
        
        //check if exists data reference blocks

        if(SuperBlock -> dz_total == 0)
        {
            uint32_t tempblock0[RPB];
            tempblock0[0] = 2;
            soWriteDataBlock(1 ,tempblock0);
            SuperBlock -> tail_blk = 1;
            SuperBlock -> head_blk = 1;
            SuperBlock-> tail_idx =  1;
            SuperBlock -> head_idx = 1;
        }

        //check if there is space in tail ref data block

        if(SuperBlock -> tail_idx == RPB-1)
        {
            uint32_t tempblock1[RPB];
            soReadDataBlock(SuperBlock -> tail_blk,tempblock1);
            tempblock1[0] = SuperBlock -> tail_blk + 1;
            soWriteDataBlock(SuperBlock -> tail_blk,tempblock1);
            SuperBlock -> tail_blk = SuperBlock -> tail_blk +1;
            SuperBlock-> tail_idx =  1;
        }


        //num posições livre na tail reference data block

        uint32_t num_livres = RPB - (SuperBlock -> tail_idx);

        // escreve para a tail reference block

        soReadDataBlock(SuperBlock -> tail_blk, bufferReader);

        uint32_t i = SuperBlock -> tail_idx;
        uint32_t j = 0;

        for (;i<RPB;i++ )
        {   
            bufferReader[i] = (SuperBlock -> tail_cache.ref[j]);
            j++;

            if(SuperBlock -> tail_cache.ref[j] == NullReference)
            {
                break;
            }  
        }

        //escreve na tail_data_reference

        soWriteDataBlock(SuperBlock -> tail_blk, bufferReader);

        //shift refrencias da cache
        
        uint32_t temp[TAIL_CACHE_SIZE];
        
        if(SuperBlock -> tail_cache.idx > num_livres)
        {
            uint32_t l = 0;
            
            for(;l<TAIL_CACHE_SIZE;l++)
            {
                if(l<num_livres-1)
                {
                    SuperBlock -> tail_cache.ref[l] = NullReference;
                }
                else
                {
                    temp[l-num_livres-1] = (SuperBlock -> tail_cache.ref[l]);
                    SuperBlock -> tail_cache.ref[l] = NullReference;
                }
            }
        }

        for(uint32_t k = 0; k < TAIL_CACHE_SIZE; k++)
        {
            (SuperBlock -> tail_cache.ref[k]) = temp[k];
        }
        
    }
};

