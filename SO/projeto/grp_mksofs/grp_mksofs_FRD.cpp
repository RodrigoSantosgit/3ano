#include "grp_mksofs.h"

#include "rawdisk.h"
#include "core.h"
#include "bin_mksofs.h"

#include <string.h>
#include <inttypes.h>

namespace sofs19
{
    /*
       filling in the contents of the root directory:
       the first 2 entries are filled in with "." and ".." references
       the other entries are empty.
    */
    void grpFillRootDir(uint32_t itotal)
    {
        soProbe(606, "%s(%u)\n", __FUNCTION__, itotal);

        /* change the following line by your code */

        SODirEntry DirSlot[DPB]; // Array tamanho DPB
        SODirEntry DirAux;

        
        // PRIMEIRA Entrada
        DirAux.in = 0x0000; // Numero do inode que aponta para este diretório
        DirAux.name[0] = '.';
        // Primeiro caracter '.' e os restantes vazios
        for (int i = 1; i <= SOFS19_MAX_NAME; i++)
        {
            DirAux.name[i] = '\0';
        }
        DirSlot[0] = DirAux;


        // SEGUNDA Entrada
        // Primeiro e segundo caracter '.' e restantes vazios
        DirAux.name[1] = '.';
        for (int i = 2; i <= SOFS19_MAX_NAME; i++)
        {
            DirAux.name[i] = '\0';
        }
        DirSlot[1] = DirAux; 


        // RESTANTES Entradas vazias
        DirAux.in = NullReference;        
        for (int i = 0; i <= SOFS19_MAX_NAME; i++)
        {
            DirAux.name[i] = '\0';
        }
        for (uint32_t i = 2; i< DPB; i++)
        {
          DirSlot[i] = DirAux;
        }

        uint32_t pos = 1 + itotal/IPB;  // calcular posição do bloco root
        soWriteRawBlock(pos, &DirSlot); // Guardar alterações 
    }
};

