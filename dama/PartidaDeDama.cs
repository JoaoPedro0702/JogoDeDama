using System;
using tabuleiro;

namespace dama {
    class PartidaDeDama {
        
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeDama() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            JogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca PecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if (PecaCapturada != null) {
                capturadas.Add(PecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            ExecutaMovimento(origem, destino);
            turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao pos) {
            if (tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");     
            }
            if (JogadorAtual != tab.peca(pos).cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não há mvimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tab.peca(origem).PodeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void MudaJogador() {
            if (JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            }
            else {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.ColocarPeca(peca, new PosicaoDama(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void ColocarPecas() {
            ColocarNovaPeca('a', 1, new P1(tab, Cor.Branca));
            ColocarNovaPeca('c', 1, new P1(tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new P1(tab, Cor.Branca));
            ColocarNovaPeca('g', 1, new P1(tab, Cor.Branca));
            ColocarNovaPeca('b', 2, new P1(tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new P1(tab, Cor.Branca));
            ColocarNovaPeca('f', 2, new P1(tab, Cor.Branca));
            ColocarNovaPeca('h', 2, new P1(tab, Cor.Branca));
            ColocarNovaPeca('a', 3, new P1(tab, Cor.Branca));
            ColocarNovaPeca('c', 3, new P1(tab, Cor.Branca));
            ColocarNovaPeca('e', 3, new P1(tab, Cor.Branca));
            ColocarNovaPeca('g', 3, new P1(tab, Cor.Branca));

            ColocarNovaPeca('b', 8, new P1(tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new P1(tab, Cor.Preta));
            ColocarNovaPeca('f', 8, new P1(tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new P1(tab, Cor.Preta));
            ColocarNovaPeca('a', 7, new P1(tab, Cor.Preta));
            ColocarNovaPeca('c', 7, new P1(tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new P1(tab, Cor.Preta));
            ColocarNovaPeca('g', 7, new P1(tab, Cor.Preta));
            ColocarNovaPeca('b', 6, new P1(tab, Cor.Preta));
            ColocarNovaPeca('d', 6, new P1(tab, Cor.Preta));
            ColocarNovaPeca('f', 6, new P1(tab, Cor.Preta));
            ColocarNovaPeca('h', 6, new P1(tab, Cor.Preta));
        }

    }
}