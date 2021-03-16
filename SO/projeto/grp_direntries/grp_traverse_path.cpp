#include "direntries.h"

#include "core.h"
#include "dal.h"
#include "fileblocks.h"
#include "direntries.h"
#include "bin_direntries.h"

#include <errno.h>
#include <string.h>
#include <libgen.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/stat.h>

namespace sofs19
{
    uint32_t grpTraversePath(char *path)
    {
        soProbe(221, "%s(%s)\n", __FUNCTION__, path);

        /* change the following line by your code */
        if(strcmp(path, "/") == 0){					// caso não existam caracteres '/' no path significa que estamos na raíz retorna 0
        	return 0;
        }

       	char * baseName = basename(strdupa(path));
        char * dirName = dirname(strdupa(path));

        uint32_t inp = grpTraversePath(dirName); 	// chamada recursiva para percuso recursivo do path
        
		uint32_t ih = soOpenInode(inp);				// abrir inode de cada diretório percorrido pertencente path
		SOInode * ip = soGetInodePointer(ih);		

		if((ip->mode & S_IFDIR) != S_IFDIR){		// verificar se inode atual é um diretório, caso contrario lança exceção correspondente
			throw SOException(ENOTDIR , __FUNCTION__);
		}

		if(!soCheckInodeAccess(ih, X_OK)) {			// verifcar se inode atual tem as permissões necessárias, caso contrário lança exceção correspondente
			throw SOException(EACCES , __FUNCTION__);
		}

		uint32_t in = soGetDirEntry(ih, baseName); 	// numero do inode de destino do caminho

		if((int)in < 0){							// caso número de inode seja invalido lança exceção
			throw SOException(EINVAL , __FUNCTION__);
		}

        soCloseInode(ih);							// fechar inode

		return in; 									// retorno do numero do inode final do path

    }
};

