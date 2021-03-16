#include "grp_mksofs.h"

#include "core.h"
#include "bin_mksofs.h"

#include <inttypes.h>
#include <iostream>
#include <math.h>
namespace sofs19
{
    void grpComputeStructure(uint32_t ntotal, uint32_t & itotal, uint32_t & nbref)
    {
        soProbe(601, "%s(%u, %u, ...)\n", __FUNCTION__, ntotal, itotal);
        
        // binComputeStructure(ntotal, itotal, nbref);


        // start value = ntotal/16
        if(itotal == 0){
            itotal = ntotal/16;
        }

        // itotal lower or equal to ntotal/8
        if(itotal > ntotal/8){
            itotal = ntotal/8;

        }
        //if(itotal >= 0 || itotal <= ntotal/8)

        // round itotal to multiple of IPB
        // (numToRound + multiple - 1) / multiple) * multiple
        itotal = ((itotal + (IPB -1)) / IPB) * IPB;
        
        // Why does this work tho... 
        nbref = ceil(itotal/16);

        /*
        // inodeTtable = itotal/IPB
        // Free datablock = ntotal - superblock - root(doesnt count as freeBlock) - inode table
        uint32_t fdblocks = ntotal-2-itotal/IPB; 

        // What to do to nbref?
        // if all fits on HEAD_CACHE_SIZE, nbref = 0
        if(fdblocks <= HEAD_CACHE_SIZE){
            nbref=0;
        }
        else{
            // Remove references already on HEAD
            fdblocks = fdblocks - HEAD_CACHE_SIZE;
            // Split the datablocks between nbref e fdblocks
            // start at nbref = 1
            // RPB = number of references per block
            // go till there are no more references 
            for (nbref=1;RPB*nbref<fdblocks;nbref++){
                //split datablocks between nbref and fdb
                //assign to inode table if one block remains
                if(fdblocks-RPB*nbref==1){
                    itotal = itotal + IPB;
                    break;
                }
            }
        }
        */


        
    }
};

