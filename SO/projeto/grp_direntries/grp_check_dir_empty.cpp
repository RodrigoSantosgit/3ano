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
    bool grpCheckDirEmpty(int ih)
    {
        soProbe(205, "%s(%d)\n", __FUNCTION__, ih);

        /* change the following line by your code */
        //return binCheckDirEmpty(ih);
        SOInode* inode =soGetInodePointer(ih);
		SODirEntry listadirentries[DPB];
		for(uint32_t i = 0; i < inode->size; i++){
			for(uint32_t j = 0; j < (sizeof listadirentries)/(sizeof listadirentries[0]); j++){
				if((strcmp(listadirentries[j].name, ".") != 0 || strcmp(listadirentries[j].name, "..") != 0) && strcmp(listadirentries[j].name, "\0") != 0){
					return false;			
				}			
			}	
		}
		return true;
    }
};

