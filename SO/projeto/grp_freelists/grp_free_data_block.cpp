/*
 *  \author António Rui Borges - 2012-2015
 *  \authur Artur Pereira - 2016-2019
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
    void grpFreeDataBlock(uint32_t bn)
    {
        soProbe(442, "%s(%u)\n", __FUNCTION__, bn);

        /* change the following line by your code */
        // binFreeDataBlock(bn);
        // Pointer for SuperBlock
        SOSuperBlock* SuperBlock = soGetSuperBlockPointer();
        // deplete if tail_cache full 
        if(SuperBlock->tail_cache.idx == TAIL_CACHE_SIZE){
            soDepleteTailCache();
        }
        // What happens next?
        // Block is put on tailCache
        SuperBlock->tail_cache.ref[SuperBlock->tail_cache.idx] = bn;
        // So, one less position there
        SuperBlock->tail_cache.idx += 1;
        // Number of free blocks increase
        SuperBlock->dz_free++;

        
    }
};

