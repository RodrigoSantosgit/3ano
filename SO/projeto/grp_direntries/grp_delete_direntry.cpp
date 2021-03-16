
/*
 * MIECT
 * Student: Daniel Lopes - 87881
 *
 */
#include "direntries.h"
#include "core.h"
#include "dal.h"
#include "fileblocks.h"
#include "bin_direntries.h"
#include <errno.h>
#include <string.h>
#include <sys/stat.h>
namespace sofs19
{
    uint32_t grpDeleteDirEntry(int pih, const char *name)
    {
        soProbe(203, "%s(%d, %s)\n", __FUNCTION__, pih, name);
        /* change the following line by your code */
        /*return binDeleteDirEntry(pih, name);*/
        SOInode *iNode = soGetInodePointer(pih);
        SODirEntry buffer[RPB];
        uint32_t deletedBlock;
        uint32_t size = iNode->size/BlockSize;
        if (strlen(name) > SOFS19_MAX_NAME) { throw SOException(ENAMETOOLONG, __FUNCTION__); } /* name bigger than supported */
        if (strcmp(name, "") == 0) { throw SOException(EINVAL, __FUNCTION__); } /* invalid name */
        
        for (uint32_t i = 0; i < size; i++)
        {
                soReadFileBlock(pih, i, buffer);
                
                for (uint32_t j = 0; j < DPB; j++)
                {                        
                        if (!strcmp(buffer[j].name, name))
                        {
                    deletedBlock = buffer[j].in;
                                /* free dir name */
                                memset(buffer[j].name, '\0', SOFS19_MAX_NAME + 1);
                                buffer[j].in = NullReference;
                                
                    soWriteFileBlock(pih,i,buffer);
                                return deletedBlock;
                        }
                }               
        }
        throw SOException(ENOENT, __FUNCTION__);
        return NullReference;
    }
};