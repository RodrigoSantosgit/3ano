#include "grp_fileblocks.h"

#include "freelists.h"
#include "dal.h"
#include "core.h"
#include "bin_fileblocks.h"

#include <errno.h>

#include <iostream>

namespace sofs19
{




    static uint32_t grpAllocIndirectFileBlock(SOInode * ip, uint32_t afbn);
    static uint32_t grpAllocDoubleIndirectFileBlock(SOInode * ip, uint32_t afbn);

    /* ********************************************************* */

    uint32_t grpAllocFileBlock(int ih, uint32_t fbn)
    {
        soProbe(302, "%s(%d, %u)\n", __FUNCTION__, ih, fbn);

        /* change the following two lines by your code */
        
        SOInode* inode = soGetInodePointer(ih);

        uint32_t block;
        if (fbn < N_DIRECT){                        // caso posição futura do fileBlock pertence ás referencias diretas do inode
            block = soAllocDataBlock();             // receber numero do proximo DataBlock livre para alocar
            (*inode).d[fbn] = block;                // armazenar numero do DataBlock livre na posição escolhida
            (*inode).blkcnt++;                      // incrementar blkcnt do inode no qual foi alocado fileBlock
        }
        else if (fbn < (N_DIRECT + N_INDIRECT*RPB)){    // caso posição futura do fileBlock pertence ás referencias indiretas do inode
        	block = grpAllocIndirectFileBlock(inode, fbn - N_DIRECT);
        }
        else if (fbn < (N_DIRECT + (N_INDIRECT*RPB) + (N_DOUBLE_INDIRECT*RPB*RPB))){  // caso posição futura do fileBlock pertence ás referencias duplamente indiretas do inode
        	block = grpAllocDoubleIndirectFileBlock(inode, fbn - N_DIRECT - (N_INDIRECT*RPB));
        }
        else{                                       // caso exceda limite ou seja numero negativo 
        	throw SOException(EINVAL,__FUNCTION__);    // lança exceção de valor invalido
        	return 0;
        }

        soSaveInode(ih);                            // Guardar alterações feitas no inode

        return block;                               // retornar numero do ultimo bloco alocado

    }

    /* ********************************************************* */


    /*
    */
    static uint32_t grpAllocIndirectFileBlock(SOInode * ip, uint32_t afbn)
    {
        soProbe(302, "%s(%d, ...)\n", __FUNCTION__, afbn);

        /* change the following two lines by your code */
        uint32_t pos = afbn / RPB;          // posição no lista de referencias indiretas
        uint32_t indexBlock;                            
        uint32_t references[RPB];           // array auxilar para referencias de blocos

        uint32_t i;
        for (i=0; i < RPB; i++){
            references[i] = NullReference;
        }

        if ((*ip).i1[pos]==NullReference){          // caso posição esteja livre
        	indexBlock = soAllocDataBlock();            // buscar numero do proximo bloco para alocar
        	(*ip).i1[pos] = indexBlock;                 // colocar referenceBlock nas referencias indiretas do inode
        	(*ip).blkcnt++;                             // incrementar blkcnt do inode
        }
        else{
        	indexBlock = (*ip).i1[pos];             // caso contrario ir buscar bloco de refencias nessa posição    
        	soReadDataBlock(indexBlock, references);    //ler referencias já existentes no bloco
        }

   		uint32_t blk = soAllocDataBlock();          // numero do proximo dataBLock livre
   		references[afbn%RPB]= blk;                  // acrescentar bloco ás referencias do bloco
   		(*ip).blkcnt++;                             // incrementar blkcnt do inode

   		soWriteDataBlock(indexBlock, references);   // escrever alteraçoes ao bloco com referencias
        return blk;                                 // retornar numero do bloco
    }


    /* ********************************************************* */


    /*
    */
    static uint32_t grpAllocDoubleIndirectFileBlock(SOInode * ip, uint32_t afbn)
    {
        soProbe(302, "%s(%d, ...)\n", __FUNCTION__, afbn);

        /* change the following two lines by your code */
        uint32_t pos = afbn/(RPB*RPB);              // posição no array de referencias duplamente indiretas
        uint32_t indexBlock;                        
        uint32_t references[RPB];
        uint32_t references2[RPB];
        uint32_t blk;
        uint32_t blk2;

        uint32_t i;
        for (i=0; i < RPB; i++){
            references[i] = NullReference;
            references2[i] = NullReference;

        }

        if((*ip).i2[pos]==NullReference){        // caso posição esteja vazia            
           	indexBlock = soAllocDataBlock();        // numero do proximo bloco livre                     
            (*ip).i2[pos] = indexBlock;             // alocar primeiro bloco
            (*ip).blkcnt++;                         // incrementar numero blocos
            blk = soAllocDataBlock();               // alocar segundo bloco
            references[(afbn/RPB)%RPB] = blk;
            soWriteDataBlock(indexBlock, references);       // escrever alterações no bloco com referencias
            (*ip).blkcnt++;                                 // incrementar blkcnt do inode
            blk2 = soAllocDataBlock();              // alocar terceiro bloco
            references2[afbn%RPB]= blk2;
            soWriteDataBlock(blk, references2);             // escrever alterações no bloco com referencias
            (*ip).blkcnt++;                                 // incrementar blkcnt do inode
        }
        else{                                    // caso contrário                             
       		indexBlock = (*ip).i2[pos];             // buscar numero do bloco com referencias      
        	soReadDataBlock(indexBlock, references);    // ler referencias do bloco já existentes

            if(references[(afbn/RPB)%RPB]==NullReference){ // caso não exita nenhum bloco com referencias em i2.idx
                blk = soAllocDataBlock();
                references[(afbn/RPB)%RPB] = blk;
                soWriteDataBlock(indexBlock, references);       // escrever alterações no bloco com referencias indireto
                (*ip).blkcnt++;                                 // incrementar blkcnt do inode
                blk2 = soAllocDataBlock();
                references2[afbn%RPB]= blk2;
                soWriteDataBlock(blk, references2);             // escrever alterações no bloco com referencias duplamente indireto
                (*ip).blkcnt++;                                 // incrementar blkcnt do inode
            }
            else{        // caso exita nenhum bloco com referencias em i2.idx
                blk = references[(afbn/RPB)%RPB];
                soReadDataBlock(blk, references2);              // ler referencias já existentes
                blk2 = soAllocDataBlock();
                references2[afbn%RPB]= blk2;
                soWriteDataBlock(blk, references2);             // escrever alterações no bloco com referencias duplamente indireto
                (*ip).blkcnt++;                                 // incrementar blkcnt do inode
            }                     
       	}

        return blk2;            // retornar bloco
    }

};

