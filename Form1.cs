namespace Aula08Estoque
{
    public partial class Form1 : Form
    {
        // Variáveis globais 
        List<string> produtoNome = new List<string>();
        List<int> produtoQuantidade = new List<int>();
        Utilidades utilidades = new Utilidades();




        public Form1()
        {
            InitializeComponent();
        }
        // Minhas funções
        void adicionaProduto()
        {
            if( utilidades.textBoxEstaVazio(txtNome) == true)
            {
                MessageBox.Show("O nome está vazio!");
                return;
            }
            
            utilidades.textBoxEstaVazio(txtNome);
            string nome = txtNome.Text;
            int quantidade = int.Parse(txtQuantidade.Text);
            produtoNome.Add(nome);
            produtoQuantidade.Add(quantidade);
        }

        void atualizaInterface()
        {
            // Contabiliza a quantidade cadastrada
            int quantidadeCadastradas = produtoNome.Count();
            lblCadastro.Text = quantidadeCadastradas.ToString();

            // Contabiliza todos os produtos em estoque
            // FOR: a variável controladora ; condição ; incrementar o contador 
            int estoque = 0;
            for( int i = 0; i < produtoQuantidade.Count; i++ )
            {
               int quantidade = produtoQuantidade[i];
                estoque += quantidade;
            }
            lblQuantidade.Text = estoque.ToString();
        }
        void limpaCampos()
        {
            txtNome.Clear();
            txtQuantidade.Clear();
            txtNome.Focus();
        }
        void verProduto( bool primeiro) 
        {
            if (listaEstavazia() == true)
            {
                MessageBox.Show("Você não pode ver a lista aida...");
                return;
            }

            string nome;
            int quantidade;

            if (primeiro == true) 
            {
                nome = produtoNome[0];
                quantidade = produtoQuantidade[0];
            }
            else
            {
                nome = produtoNome[ produtoNome.Count() - 1 ];
                quantidade = produtoQuantidade[ produtoQuantidade.Count() - 1 ];
            }

            MessageBox.Show($"Nome: {nome}, Quantidade: {quantidade}");

        }
        void removeProduto()
        {
            if ( listaEstavazia() == true ) 
            {
                MessageBox.Show("Você não pode remover");
            }
            else
            {
                produtoNome.RemoveAt(0);
                produtoQuantidade.RemoveAt(0);
            }

         

        }

        bool listaEstavazia()
        {
            if (produtoNome.Count > 0)
            {
                return false;
            }
            else
            {
               return true;
            }

        }






        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adicionaProduto();
            atualizaInterface();
            limpaCampos(); 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verProduto(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verProduto(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            removeProduto();
            atualizaInterface();
            MessageBox.Show("produto removido");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Utilidades utilidades= new Utilidades();
            utilidades.mostraMenssagem();
        }

       
    }
}