/*
 * MIECT
 * Student: Daniel Lopes - 87881
 *
 */

#include "grp_fileblocks.h"
#include "freelists.h"
#include "dal.h"
#include "core.h"
#include "bin_fileblocks.h"
#include <inttypes.h>
#include <errno.h>
#include <assert.h>

namespace sofs19
{
    /* free all blocks between positions ffbn and RPB - 1
     * existing in the block of references given by i1.
     * Return true if, after the operation, all references become NullReference.
     * It assumes i1 is valid.
     */
    static bool grpFreeIndirectFileBlocks(SOInode * ip, uint32_t i1, uint32_t ffbn);

    /* free all blocks between positions ffbn and RPB**2 - 1
     * existing in the block of indirect references given by i2.
     * Return true if, after the operation, all references become NullReference.
     * It assumes i2 is valid.
     */
    static bool grpFreeDoubleIndirectFileBlocks(SOInode * ip, uint32_t i2, uint32_t ffbn);

    /* Global variables */
    uint32_t Counter = 0;
    uint32_t IndirectBuffer[RPB];
    uint32_t DoubleBuffer[RPB];


    /* ********************************************************* */

    void grpFreeFileBlocks(int ih, uint32_t ffbn)
    {               
        soProbe(303, "%s(%d, %u)\n", __FUNCTION__, ih, ffbn);
        
        SOInode* iNode = soGetInodePointer(ih);        

        /* First double indirect list position */
        uint32_t i2_first = N_INDIRECT * RPB + N_INDIRECT; 
        /* Last double indiect list position */
        uint32_t i2_last = RPB*RPB * N_DOUBLE_INDIRECT + i2_first; 

        /* Check invalid file block number */
        if (ffbn < 0 || ffbn >= i2_last)
            throw SOException(EINVAL, __FUNCTION__);
        
        /*****************************************************************************************************       
        * Direct list       
        *****************************************************************************************************/
        if (ffbn < N_DIRECT)
        {            
            for (; ffbn < N_DIRECT; ffbn++)
            {
                if (iNode->d[ffbn] != NullReference) { soFreeDataBlock(iNode->d[ffbn]); Counter++; }                                   
                iNode->d[ffbn] = NullReference;
            }                        
        }

        /*****************************************************************************************************       
        * Indirect list       
        *****************************************************************************************************/
        if (ffbn >= N_DIRECT && ffbn < i2_first)
        {            
            /* Free block from indirect array */
            uint32_t i1_idx = ((ffbn-N_DIRECT) / RPB) % RPB;
            /* Free inside block */
            uint32_t block_idx = ffbn-N_DIRECT;
           
            if (grpFreeIndirectFileBlocks(iNode, i1_idx, block_idx)) 
            {
                /* nothing to be done */
            }
            
            /* Careon to double indirect list */
            ffbn = i2_first;                        
        }

        /*****************************************************************************************************       
        * Double Indirect list       
        *****************************************************************************************************/
        if (ffbn >= i2_first && ffbn < i2_last)
        {
            /* Index of i2 Array */
            uint32_t i2_idx = (ffbn-i2_first) / RPB / RPB; 
            
            if(grpFreeDoubleIndirectFileBlocks(iNode, i2_idx, ffbn - i2_first))
            {
                /* Free block from i2 array */
                for (; i2_idx < N_INDIRECT; i2_idx++)
                {
                	if(iNode->i2[i2_idx] != NullReference) { soFreeDataBlock(iNode->i2[i2_idx]); Counter++; }
                    iNode->i2[i2_idx] = NullReference;
                }
            }                         
        }
                
        iNode->blkcnt = iNode->blkcnt - Counter;
        Counter = 0;
        soSaveInode(ih);
    }

    /* ********************************************************* */
    static bool grpFreeIndirectFileBlocks(SOInode * ip, uint32_t i1, uint32_t ffbn)
    {
        soProbe(303, "%s(..., %u, %u)\n", __FUNCTION__, i1, ffbn);

        /* Block index to be freed */       
        uint32_t indirect_block = ffbn % RPB;
        /* Index where Block is on Indirect array */
        uint32_t i1_idx = i1;               
        /* Check if a Block is empty */
        bool verify = true;

        for (uint32_t i = i1_idx; i < N_DIRECT; i++)
        {
            if (ip->i1[i] != NullReference)
            {   
                /* Read indirect block */
                soReadDataBlock(ip->i1[i], &IndirectBuffer);     	        
    	        for (; indirect_block < RPB; indirect_block++)
    	        {
    	            if(IndirectBuffer[indirect_block] != NullReference) {  soFreeDataBlock(IndirectBuffer[indirect_block]); Counter++; }
    	                IndirectBuffer[indirect_block] = NullReference;
    	        }
                                
                /* Verify if block is all empty */            
                for (uint32_t j = 0; j < RPB; j++)
                {
                    if (IndirectBuffer[j] != NullReference)                                           
                        verify = false;
                }

                if (verify == true)
                {
                    soFreeDataBlock(ip->i1[i]);
                    ip->i1[i] = NullReference;
                    Counter++;
                }
                soWriteDataBlock(ip->i1[i], &IndirectBuffer);
            }
           
            indirect_block = 0; 
            verify = true;     	
        }

        return verify; /* True if block all empty */
    }

    /* ********************************************************* */
    static bool grpFreeDoubleIndirectFileBlocks(SOInode * ip, uint32_t i2, uint32_t ffbn)
    {
        soProbe(303, "%s(..., %u, %u)\n", __FUNCTION__, i2, ffbn);
        
        /* Index of i2 Array */
        uint32_t i2_idx = i2;
        /* Index from indirect_block on i2 */
        uint32_t indirect_block = (ffbn / RPB) % RPB;
        /* Index from double_indirect_block on i2 */
        uint32_t double_block = ffbn % RPB;
        
        /* Verify indirect and double_blocks content flag */
        bool verify_double = true;
        bool verify_indirect = true;

        if (ip->i2[i2_idx] != NullReference)
        {
            /* Read indirect_block */
            soReadDataBlock(ip->i2[i2_idx], &IndirectBuffer);

            for (; indirect_block < RPB; indirect_block++)
            {
                if (IndirectBuffer[indirect_block] != NullReference)
                {   
                    /* Read double_indirect_block */               
                    soReadDataBlock(IndirectBuffer[indirect_block], &DoubleBuffer); 
                    
                    /* Search double_indirect_block */                                     
                    for(uint32_t j = double_block; j < RPB; j++)
                    {
                        if (DoubleBuffer[j] != NullReference) 
                        { 
                            soFreeDataBlock(DoubleBuffer[j]);
                            DoubleBuffer[j] = NullReference;
                            Counter++; 
                        }                        
                    }
                    /* Save double_indirect_block */
                    soWriteDataBlock(IndirectBuffer[indirect_block], &DoubleBuffer);
                    
                    
                    /* Search if double_indirect_block is empty */
                    for(uint32_t j = 0; j < RPB; j++)
                    {
                        if (DoubleBuffer[j] != NullReference)
                            verify_double = false;
                    }
                
                    /* if double_indirect_block is empty free it from indirect_block*/
                    if (verify_double == true)
                    {
                        soFreeDataBlock(IndirectBuffer[indirect_block]);
                        IndirectBuffer[indirect_block] = NullReference;
                        Counter++; 
                    }
                }

                verify_double = true; /* Reset verify flag, for next iteration */
                double_block = 0; /* Reset double_block index for next iteration */
            }

            /* Save indirect_block */
            soWriteDataBlock(ip->i2[i2_idx], &IndirectBuffer);

            /* Search if indirect_block is empty */
            for (uint32_t i = 0; i < RPB; i++)
            {
                if (IndirectBuffer[i] != NullReference)
                    verify_indirect = false;
            }

        }
        return verify_indirect;
    }

    /* ********************************************************* */
};

