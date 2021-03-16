#include "direntries.h"

#include "core.h"
#include "dal.h"
#include "fileblocks.h"
#include "bin_direntries.h"

#include <string.h>
#include <errno.h>
#include <sys/stat.h>

namespace sofs19
{
    void grpRenameDirEntry(int pih, const char *name, const char *newName)
    {
        soProbe(204, "%s(%d, %s, %s)\n", __FUNCTION__, pih, name, newName);
        
        /* change the following line by your code */
        // binRenameDirEntry(pih, name, newName);
        // uint32_t ih = soOpenInode(pih);
        SOInode* inode = soGetInodePointer(pih);
        uint32_t check = 0;
        SODirEntry dir[DPB];
        // If name too big 
        if(sizeof(newName)>SOFS19_MAX_NAME ||sizeof(newName)>SOFS19_MAX_NAME) {
            throw SOException(ENAMETOOLONG,__FUNCTION__);
        }
        for(uint32_t i=0;i<inode->blkcnt;i++){

            soReadFileBlock(pih,i,dir);

            for(uint32_t j=0; j<DPB;j++){
                // Compare 2 strings
                // strcmp compares 2 strings, and if they are equal, returns 0
                if (strcmp(dir[j].name,name)==0){
                    /*
                    // O professor disse que não se podia usar esta função aqui, por isso fiz de outra maneira
                    uint32_t cin = soGetDirEntry(pih,name);
                    soDeleteDirEntry(pih,name);
                    soAddDirEntry(pih,newName,cin);
                    */
                    // copy whats on name to newName
                    strcpy(dir[j].name,newName);
                    // rename here
                    soWriteFileBlock(pih,i,dir);
                    // Since it was found, I did like this to see if the name exists
                    check = 1;
                    break;
                    
                }
            }
        }
        // Basically, throws the exception if it didn't found the name
        if(check == 0){
            throw SOException(ENOENT , __FUNCTION__);
        }
    }
};

