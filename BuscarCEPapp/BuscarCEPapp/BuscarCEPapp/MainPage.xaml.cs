using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BuscarCEPapp.Servico.Modelo;
using BuscarCEPapp.Servico;

namespace BuscarCEPapp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCep;
		}
            
        private void BuscarCep(object obj, EventArgs args)
        {
            //a fazer LOGICA DO PROGRAMA

            // fazer validações

            string cep = CEP.Text.Trim();

            Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);


            RESULTADO.Text = string.Format("Endereço do cep digitado é: {0}, {1} {2}", end.localidade, end.uf, end.logradouro);

        }
    }
}
 