using tabuleiro;

namespace dama {
    class PosicaoDama {

        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoDama(char coluna, int linha) {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao ToPosicao() {
            return new Posicao(8 - linha, coluna - 'a');
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}