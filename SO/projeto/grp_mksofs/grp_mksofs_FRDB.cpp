#include "grp_mksofs.h"

#include "rawdisk.h"
#include "core.h"
#include "bin_mksofs.h"
#include <inttypes.h>
#include <string.h>
#include <math.h>

namespace sofs19
{
    void grpFillReferenceDataBlocks(uint32_t ntotal, uint32_t itotal, uint32_t nbref)
    {
        soProbe(605, "%s(%u, %u, %u)\n", __FUNCTION__, ntotal, itotal, nbref);

        /* change the following line by your code */
        
        //binFillReferenceDataBlocks(ntotal, itotal, nbref);
        
        if(nbref > 0)
        {
            uint32_t firstBlock = ceil((itotal/8) + 2); //indíce 1º bloco de reference data blocks
            uint32_t lastBlock = firstBlock + nbref -1; //indíce ultimo bloco de reference data blocks
            uint32_t arrayBlock[RPB]; //Array para dar fill aos blocos de referência
            uint32_t first_value = HEAD_CACHE_SIZE+nbref+1; //primeiro valor a atribuir
            uint32_t writeBlock = firstBlock; // bloco a escrever

            uint32_t i = firstBlock;

            while(i<lastBlock+1)
	    {
                if(i==lastBlock)
                {
                    arrayBlock[0] = NullReference;
                }
                else
                {
                    arrayBlock[0] = i+2-firstBlock;
                }
                
                for(uint32_t j = 1; j<RPB; j++)
                {
                    if(first_value > (ntotal-firstBlock))
                    {
                        arrayBlock[j] = NullReference;
                        first_value++;
                    }
                    else
                    {
                        arrayBlock[j] = first_value++;
                    }
                }

                soWriteRawBlock(writeBlock++,arrayBlock);
            	i++;
	    }   
        }
    }
}

