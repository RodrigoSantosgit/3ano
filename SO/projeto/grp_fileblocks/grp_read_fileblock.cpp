#include "grp_fileblocks.h"

#include "dal.h"
#include "core.h"
#include "fileblocks.h"
#include "bin_fileblocks.h"

#include <string.h>
#include <inttypes.h>

namespace sofs19
{
    void grpReadFileBlock(int ih, uint32_t fbn, void *buf)
    {
        soProbe(331, "%s(%d, %u, %p)\n", __FUNCTION__, ih, fbn, buf);

        /* change the following line by your code */
        //binReadFileBlock(ih, fbn, buf);
        // If there is no reference to it (if returns nullReference), then was not allocated
        uint32_t referredBlock = soGetFileBlock(ih,fbn);
        if(referredBlock == NullReference){
            // return character null (acii code 0)
            // Is it like this? Maybes
            memset((char*) buf, '\0', BlockSize);
        }
        else{
            // Read it
            soReadDataBlock(fbn,buf);
        }
    }
};

