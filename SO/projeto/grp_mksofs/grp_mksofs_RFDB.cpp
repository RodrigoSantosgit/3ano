#include "grp_mksofs.h"

#include "rawdisk.h"
#include "core.h"
#include "bin_mksofs.h"

#include <string.h>
#include <inttypes.h>

namespace sofs19
{
    void grpResetFreeDataBlocks(uint32_t ntotal, uint32_t itotal, uint32_t nbref) 
    {
        soProbe(607, "%s(%u, %u, %u)\n", __FUNCTION__, ntotal, itotal, nbref);

        /* change the following line by your code */
        /* binResetFreeDataBlocks(ntotal, itotal, nbref); */

        uint32_t block[BlockSize];
        memset(&block, 0, BlockSize*1);

        uint32_t blockTable = itotal/IPB;
        uint32_t pos = 2 + blockTable + nbref;

        for (; pos < ntotal; pos++){
        	soWriteRawBlock(pos, block);
        }
        
        return;       
    }
};

