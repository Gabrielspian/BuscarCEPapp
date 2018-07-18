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

        #region Buscar Cep
        private void BuscarCep(object obj, EventArgs args)
        {
            //a fazer LOGICA DO PROGRAMA
            
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                   Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço : {0}, {1}, {2}", end.logradouro, end.bairro, end.localidade);
                    }
                    else
                    {
                        DisplayAlert("Erro", "o endereço nao foi encontrado para o cep informado: " + cep, "Ok");
                    }
                }

                catch (Exception e)
                 {
                    DisplayAlert("ERRO CRITICO", e.Message, "ok");
                 }
                     
            }
            
            
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;
            int NovoCEP = 0;

            if (cep.Length != 8)
            {
                // error
                DisplayAlert("Erro", "CEP inválido", "cep deve conter 8 caracteres Numericos!!", "OK");

                return valido = false;
            }
            if (!int.TryParse(cep, out NovoCEP))
            { // CONVERSÃO PARA VERFIFICAR SE cep é Numerico TryParse(entrada, saida (out) = 0);

                DisplayAlert("Erro", "CEP inválido", "cep deve conter 8 caracteres Numericos!!", "OK");

                return valido = false;
               
            }
            return valido;
        }

    }
    
    #endregion
}

 