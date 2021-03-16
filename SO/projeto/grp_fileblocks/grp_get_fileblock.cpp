#include "grp_fileblocks.h"

#include "dal.h"
#include "core.h"
#include "bin_fileblocks.h"

#include <errno.h>

namespace sofs19
{
    /* ********************************************************* */

    static uint32_t grpGetIndirectFileBlock(SOInode * ip, uint32_t fbn);
    static uint32_t grpGetDoubleIndirectFileBlock(SOInode * ip, uint32_t fbn);

    /* ********************************************************* */

    uint32_t grpGetFileBlock(int ih, uint32_t fbn)
    {
        soProbe(301, "%s(%d, %u)\n", __FUNCTION__, ih, fbn);

        if(fbn == NullReference || fbn < 0){ //check if fbn is valid /// i know fbn is a uint but still 
            throw SOException(EINVAL, __FUNCTION__); 
        }
        SOInode *inod = soGetInodePointer(ih);
        if(fbn < N_DIRECT){
            return inod->d[fbn];
        }else if(fbn < RPB){
            	return grpGetIndirectFileBlock(inod,(fbn-N_DIRECT));
        }else{
            	return grpGetDoubleIndirectFileBlock(inod,(fbn-RPB-N_DIRECT));
        }

        /* change the following line by your code */
        //return binGetFileBlock(ih, fbn);
    }

    /* ********************************************************* */

    static uint32_t grpGetIndirectFileBlock(SOInode * ip, uint32_t afbn)
    {
        soProbe(301, "%s(%d, ...)\n", __FUNCTION__, afbn);

        uint32_t ref[RPB];
        uint32_t i;

        if(ip->i1[afbn] == NullReference){
            return NullReference;
        } else {
            soReadDataBlock(ip->i1[afbn],ref);
        }

        for(i = 0 ; i < RPB ; i++){
            if(i == afbn ){
                //return ip->i1[afbn];
                return ref[i];
            }
        }
        //return NullReference;
        throw SOException(ENOSYS, __FUNCTION__); 
    }


    /* ********************************************************* */


    static uint32_t grpGetDoubleIndirectFileBlock(SOInode * ip, uint32_t afbn)
    {
        soProbe(301, "%s(%d, ...)\n", __FUNCTION__, afbn);

        uint32_t ref0[RPB];
        uint32_t ref1[RPB];

        if((ip -> i2[afbn]) == NullReference){
            return NullReference;
        } else {
            soReadDataBlock(ip -> i2[afbn], ref1);
        }

        for(uint32_t i = 0 ; i < RPB; i++){
            if(afbn < i+RPB){
                soReadDataBlock(ref1[i],ref0);
                }
            for(uint32_t j = 0 ; j < RPB ; j++){
                if(j == afbn - i){
                    //return ip -> i2[afbn];
                    return ref0[j];

                }
            }
        }
        //return NullReference;
        throw SOException(ENOSYS, __FUNCTION__); 
    }

};

