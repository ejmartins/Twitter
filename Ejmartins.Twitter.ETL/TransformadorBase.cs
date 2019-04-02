using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejmartins.Twitter.ETL
{
    public abstract class TransformadorBase<EntidadeOrigem, EntidadeDestino>
    {
        public TransformadorBase()
        {
        }

        public abstract List<EntidadeOrigem> ExtrairDadosOrigem();

        public abstract List<EntidadeDestino> TransformarDados(List<EntidadeOrigem> dados);

        public abstract void CarregarDados(List<EntidadeDestino> dados);

        public void Executar()
        {
            var origem = ExtrairDadosOrigem();
            var destino = TransformarDados(origem);
            CarregarDados(destino);
        }

    }
}
