namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        String vez = "X"; // Variável para alternar entre X e O

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // Estamos fazendo o programa entender que o button clicked de Mainpage.xaml

            btn.IsEnabled = false; // Desabilita o botão clicado // Desabilito o botão não permitindo que o jogador mude o que ja estava escrito.

            // Alterna entre X e O
            if (vez == "X") //Variável vez é igual a X se sim executa IF se falso executa o Else
            {
                btn.Text = "X"; //Isso aqui permite escrevermos o X no nosso jogo da velha. 
                vez = "O";
            }
            else
            {
                btn.Text = "O"; //Isso aqui permite escrevermos o O no nosso jogo da velha. 
                vez = "X";
            }

            // Verifica se houve vitória ou empate
            if (VerificarVitoria())
            {
                DisplayAlert("Parabéns!", $"O {(vez == "X" ? "O" : "X")} ganhou!", "OK");

                Zerar(); // Reseta o jogo
            }
            else if (VerificarEmpate())
            {
                DisplayAlert("Empate!", "Deu velha!", "OK");
                Zerar(); // Reseta o jogo
            }
        }

        // Método para verificar todas as condições de vitória
        private bool VerificarVitoria()
        {
            return
                // Verifica todas as linhas
                Vitoria(btn10, btn11, btn12) ||
                Vitoria(btn20, btn21, btn22) ||
                Vitoria(btn30, btn31, btn32) ||

                // Verifica todas as colunas
                Vitoria(btn10, btn20, btn30) ||
                Vitoria(btn11, btn21, btn31) ||
                Vitoria(btn12, btn22, btn32) ||

                // Verifica diagonais
                Vitoria(btn10, btn21, btn32) ||
                Vitoria(btn12, btn21, btn30);
        }

        // Método para verificar se três botões têm o mesmo texto (X ou O) e não estão vazios
        private bool Vitoria(Button btn1, Button btn2, Button btn3)
        {
            return !string.IsNullOrEmpty(btn1.Text) &&
                   btn1.Text == btn2.Text &&
                   btn2.Text == btn3.Text;
        }

        // Método para verificar se houve empate (velha)
        private bool VerificarEmpate()
        {
            return btn10.IsEnabled == false &&
                   btn11.IsEnabled == false &&
                   btn12.IsEnabled == false &&
                   btn20.IsEnabled == false &&
                   btn21.IsEnabled == false &&
                   btn22.IsEnabled == false &&
                   btn30.IsEnabled == false &&
                   btn31.IsEnabled == false &&
                   btn32.IsEnabled == false;
        }

        // Método para resetar o tabuleiro
        private void Zerar()
        {
            btn10.Text = btn11.Text = btn12.Text = "";
            btn20.Text = btn21.Text = btn22.Text = "";
            btn30.Text = btn31.Text = btn32.Text = "";

            btn10.IsEnabled = btn11.IsEnabled = btn12.IsEnabled = true;
            btn20.IsEnabled = btn21.IsEnabled = btn22.IsEnabled = true;
            btn30.IsEnabled = btn31.IsEnabled = btn32.IsEnabled = true;

        } //Fecha Método
    } //Fecha Classe
} //Fecha NameSpace
