/*
 *  \author António Rui Borges - 2012-2015
 *  \authur Artur Pereira - 2016-2019
 */

#include "grp_freelists.h"

#include <stdio.h>
#include <errno.h>
#include <inttypes.h>
#include <time.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <string.h>

#include <iostream>

#include "core.h"
#include "dal.h"
#include "freelists.h"
#include "bin_freelists.h"

namespace sofs19
{
    uint32_t grpAllocInode(uint32_t type, uint32_t perm)
    {
        soProbe(401, "%s(0x%x, 0%03o)\n", __FUNCTION__, type, perm);

        /* change the following line by your code */
        
        SOSuperBlock *spb;
        spb = soGetSuperBlockPointer();

        if (type != S_IFREG && type != 	S_IFDIR && type != S_IFLNK){    // Verificar tipos de inodes
        	throw SOException(EINVAL, __FUNCTION__);              
        }

        if (perm<0000 || perm > 0777){                                  // verficar se permissõs são validas
        	throw SOException(EINVAL, __FUNCTION__);
        }

        if(spb->ifree == 0){                                            //verficar se há inodes livres 
        	throw SOException(ENOSPC, __FUNCTION__);
        }

        uint32_t referenceNumber = spb -> ihead;                        // buscar numero proximo inode livre

        int iHandler = soOpenInode(referenceNumber);                    
        SOInode* i = soGetInodePointer(iHandler);          

        
		spb->ifree -=1;                                                 // decrementar numero de inodes livres
        
		if (spb->ifree ==0){                                            // caso este seja o ultimo inode livre, ihead aponta para NullReference
			spb -> ihead = NullReference;
		}
		else{
			spb->ihead = i->next;                                       // caso contrario aponta para o next do inode
		}
		
        // Preencher campos do inode
        i->owner = getuid();
        i->group = getgid();

		i->atime = time(NULL);
		i->mtime = time(NULL);
		i->ctime = time(NULL);

		i->mode = type | perm;
        
        // Guardar alterações feitas
		soSaveInode(iHandler);                                          
		soCloseInode(iHandler);

        soSaveSuperBlock();

		return referenceNumber;   // retornar numero do inode

    }
};

