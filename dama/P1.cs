using tabuleiro;

namespace dama {
    class P1 : Peca {

        public P1(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }

        public override string ToString()
        {
            return "O";
        }

        private bool PodeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //nordeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //sudeste
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //sudoeste
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //noroeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;
        }
    }
}