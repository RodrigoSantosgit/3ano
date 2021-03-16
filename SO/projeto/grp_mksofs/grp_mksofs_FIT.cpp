/*
 * MIECT
 * Student: Daniel Lopes - 87881
 *
 */

#include "grp_mksofs.h"
#include "rawdisk.h"
#include "core.h"
#include "bin_mksofs.h"
#include <string.h>
#include <time.h>
#include <unistd.h>
#include <sys/stat.h>
#include <inttypes.h>

namespace sofs19
{
	SOInode first_iNode(bool);
	SOInode remaining_iNodes();

    void grpFillInodeTable(uint32_t itotal, bool set_date)
    {
        soProbe(604, "%s(%u)\n", __FUNCTION__, itotal);

        SOInode firstINode, remainingINode;
        
        /* First iNode structure */
        firstINode = first_iNode(set_date);

        /* Remaining iNodes structure */
        remainingINode = remaining_iNodes();

        /* Array iNodes */
        SOInode inodeArray[itotal]; 
       
        /* First iNode inserted on Array */
        inodeArray[0] = firstINode; 
        
        /* Next iNodes inserted on Array */
        for (uint32_t i = 1; i < itotal; i++)
        {        	
        	remainingINode.next = i + 1;
        	inodeArray[i] = remainingINode;
        }

        /* Last iNode points to nil */
        inodeArray[itotal-1].next = NullReference;
        
       	/* Fill blocks */
       	for (uint32_t i = 1; i <= itotal/IPB; i++)
       	{
       		int32_t x = (i - 1) * IPB;           			
       		for (uint32_t j = 0; j < IPB; j++)
       		{
       			soWriteRawBlock(i, &inodeArray[x]);
       		}
       	}
    }

	/**************************************************************************************************************************************************
    *	Fill first iNode that point directly to Root Directory
	***************************************************************************************************************************************************/
	SOInode first_iNode(bool set_date_param)
	{
		SOInode inode;

		inode.mode 	= S_IFDIR | S_IRWXU | S_IRWXG | S_IROTH | S_IXOTH  ; /* File type | Owner permissions | Group permissions | Others permission */
        inode.lnkcnt= 2;
        inode.owner = getuid();
        inode.group = getgid(); 
        inode.size 	= BlockSize;
        inode.blkcnt= 1;
        inode.next 	= 1;

        if (set_date_param == true)
        {
         	inode.atime = time(NULL);
        	inode.ctime = time(NULL);
        	inode.mtime = time(NULL);
        }
        else
        {
        	inode.atime = 0;
        	inode.ctime = 0;
        	inode.mtime = 0;        	
        }

        inode.d[0] = 0x0000; /* Direct Reference to Root Directory */

        /* All references to nil except the first that points to Root Directory */
        for (uint32_t i = 1 ; i < N_DIRECT ; i++)
        	{inode.d[i] = NullReference;}
        for (uint32_t i = 0 ; i < N_INDIRECT ; i++)
        	{inode.i1[i] = NullReference;}
        for (uint32_t i = 0 ; i < N_DOUBLE_INDIRECT ; i++)
        	{inode.i2[i] = NullReference;}


        return inode;
	}
	/**************************************************************************************************************************************************
    *	Fill remaining iNodes
	***************************************************************************************************************************************************/
	SOInode remaining_iNodes()
	{
		SOInode inode;
	    
	    inode.mode 	 = INODE_FREE;
		inode.lnkcnt = 0;
		inode.owner  = 0;
		inode.group  = 0;       
		inode.size 	 = 0;
		inode.blkcnt = 0; 
		inode.atime  = 0;
		inode.ctime  = 0;
		inode.mtime  = 0;

		/* All references = nil */
		for (uint32_t i = 0 ; i < N_DIRECT ; i++)
        	{inode.d[i] = NullReference;}
        for (uint32_t i = 0 ; i < N_INDIRECT ; i++)
        	{inode.i1[i] = NullReference;}
        for (uint32_t i = 0 ; i < N_DOUBLE_INDIRECT ; i++)
        	{inode.i2[i] = NullReference;}

        return inode;
	}
};



