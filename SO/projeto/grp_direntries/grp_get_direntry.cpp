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
    uint32_t grpGetDirEntry(int pih, const char *name)
    {
        soProbe(201, "%s(%d, %s)\n", __FUNCTION__, pih, name);
        /* change the following line by your code */
        //return binGetDirEntry(pih, name);
        SOInode* Inode;
        Inode = soGetInodePointer(pih);
        //verifica se nome inclui '/'
        if(strchr(name, '/') != NULL)
        {
            throw SOException(EINVAL, __FUNCTION__);
        }
        // verifica se nome ultrapassa ramanho máximo
        if(sizeof(name) > SOFS19_MAX_NAME)
        {
            throw SOException(ENAMETOOLONG, __FUNCTION__);
        }
        SODirEntry d[DPB];
        //numero de direntries 
        uint32_t numdirs = Inode -> size / sizeof(SODirEntry);
        //numero de blocos 
        uint32_t numblks = numdirs / DPB;
        uint32_t i = 0;
        uint32_t j = 0;
        
        for(;i<numblks;i++)
        {
            soReadDataBlock(i,d);
            
            // verifica se o nome passado coincide com o encontrado no direntry
            while(j<DPB)
            {
                if(strcmp(name,d[j].name) == 0)
                {
                    return d[j].in;
                }
                j++;
            }
        }
        throw SOException(ENOENT,__FUNCTION__);
        return NullReference;
        
    }
};