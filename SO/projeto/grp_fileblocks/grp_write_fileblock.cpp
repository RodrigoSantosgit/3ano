#include "grp_fileblocks.h"

#include "dal.h"
#include "core.h"
#include "fileblocks.h"
#include "bin_fileblocks.h"

#include <string.h>
#include <inttypes.h>

namespace sofs19
{
    void grpWriteFileBlock(int ih, uint32_t fbn, void *buf)
    {
        soProbe(332, "%s(%d, %u, %p)\n", __FUNCTION__, ih, fbn, buf);

        /* change the following line by your code */
        // binWriteFileBlock(ih, fbn, buf);
        // If the referredBlock not allocated...
        uint32_t referredBlock = soGetFileBlock(ih,fbn);
        if (referredBlock == NullReference){
            // Allocate it
            referredBlock = soAllocFileBlock(ih,fbn);
        }
        // write now
        soWriteDataBlock(fbn,buf);
        
    }
};

