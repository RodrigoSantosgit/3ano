#include "grp_mksofs.h"
#include "rawdisk.h"
#include "core.h"
#include "bin_mksofs.h"
#include <string.h>
#include <inttypes.h>
#include <math.h>

namespace sofs19
{
    void grpFillSuperBlock(const char *name, uint32_t ntotal, uint32_t itotal, uint32_t nbref)
    {
        soProbe(602, "%s(%s, %u, %u, %u)\n", __FUNCTION__, name, ntotal, itotal, nbref);

        /* change the following line by your code */
        /*binFillSuperBlock(name, ntotal, itotal, nbref);*/


        struct SOSuperBlock sb;
        sb.magic = 0xFFFF;
        strcpy(sb.name, name);
        sb.version=VERSION_NUMBER;   
        sb.mntstat=(uint8_t) 1;
        sb.mntcnt = 0;
        sb.ntotal = ntotal;
        sb.it_size=(uint32_t)ceil(itotal/IPB);
        sb.itotal=(uint32_t)itotal;
        sb.ifree =(IPB * sb.it_size) - 1;
        sb.ihead = 1;
        sb.itail= itotal-1;
        sb.dz_start= sb.it_size+1;
        sb.dz_total=ntotal-sb.dz_start;

        sb.dz_free= (sb.dz_total)-(nbref)-1;
        if (nbref==0)
        {
          sb.dz_free= (sb.dz_total)-1;  
        }
        
        sb.head_blk=1;
        sb.head_idx=1;
        
        sb.tail_idx= (ntotal-sb.dz_start-HEAD_CACHE_SIZE-1) % (RPB);
      
        sb.head_cache.idx=0;
        uint32_t aux=0;
        //HEAD_CACHE
        for(uint32_t i = HEAD_CACHE_SIZE;i>0;i--){
            if (sb.dz_free>HEAD_CACHE_SIZE)
            {
                sb.head_cache.ref[i]=i+nbref+1;
                sb.head_cache.ref[0]=nbref+1;
                sb.tail_blk=i-1 + nbref;
            }
            else
            {
                sb.head_cache.ref[i]=sb.dz_free+nbref+1;
                sb.dz_free--;
            }
            if (sb.dz_free==0){
                aux = i-1;
                sb.head_cache.idx=aux;
                sb.tail_blk=i;
                memset(&(sb.head_blk),0xFF,sizeof (uint32_t));
                memset(&(sb.head_idx),0xFF,sizeof (uint32_t));
                memset(&(sb.tail_blk),0xFF,sizeof (uint32_t));
                memset(&(sb.tail_idx),0xFF,sizeof (uint32_t));
            }
        }

        //sb.dz_free= sb.dz_total-1;
        

        memset(&(sb.head_cache.ref),0xFF,aux * sizeof (uint32_t));

        memset(&(sb.tail_cache.ref),0xFF,TAIL_CACHE_SIZE*sizeof (uint32_t));
        sb.tail_cache.idx=0;

        soWriteRawBlock(0, &(sb));

    }
};

