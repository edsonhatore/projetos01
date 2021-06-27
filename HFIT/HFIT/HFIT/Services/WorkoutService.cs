using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZAMIO.Model2;

namespace HFIT.Services
{
    
      public   class WorkoutService : Service
    {
        public async Task<Message<List<TreinoModel>>> GetWorkout(int CorporacaoId ,int Id, string myToken)
            {

            HttpResponseMessage response = null; //Declaring an http response message
            var responseService = new Message<List<TreinoModel>>();
       
            try
            {
                // passa o token para invocar api
                _client.DefaultRequestHeaders.Authorization =
                           new AuthenticationHeaderValue("Bearer", myToken);

                // buscar os dados do usuario

             //   response = await _client.GetAsync($"{BaseApiurl}api/Treino/GetAllTreino");
                response = await _client.GetAsync($"{BaseApiurl}api/Treino/GetActiveWorkout?Master=1&Corporacao={CorporacaoId}&Usercodigo={Id}");

                responseService.IsSuccess = response.IsSuccessStatusCode;

                responseService.Data = await response.Content.ReadAsAsync<List<TreinoModel>>();

                if (response.IsSuccessStatusCode != true)
                {
                    //  App.Current.Properties.Remove("MyToken");
                    // await App.Current.SavePropertiesAsync();

                    //TODO: ACERTAR A CAPTURA DE ERRO, SERVER INTERNAR ERROR NAO FOI CAPTURADO
                    responseService.IsSuccess = false;
                    responseService.ReturnMessage = response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString();

                    //string problemResponse = await response.Content.ReadAsStringAsync();
                    //var erros = JsonConvert.DeserializeObject<Message<TreinoModel>>(problemResponse);
                    //responseService.errors = erros.errors;
                }
                else
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        responseService.IsSuccess = false;
                        responseService.ReturnMessage = "Você não está com nenhum treino ativo.";
                    }
                }
                
                return responseService;
            }
            catch (Exception ex)
            {
                App.Current.Properties.Remove("MyToken");
                await App.Current.SavePropertiesAsync();


                throw new Exception("WorkoutService:" + ex.Message);

            }
        }

        public async Task<Message<List<TreinoSerieModel>>> SetStatusWorkoutSerie(int Treino, int Exercicio, string myToken)
        {

            HttpResponseMessage response = null; //Declaring an http response message
            var responseService = new Message<List<TreinoSerieModel>>();

            try
            {
                // passa o token para invocar api
                _client.DefaultRequestHeaders.Authorization =
                           new AuthenticationHeaderValue("Bearer", myToken);

                // buscar os dados do usuario

                //   response = await _client.GetAsync($"{BaseApiurl}api/Treino/GetAllTreino");
                response = await _client.GetAsync($"{BaseApiurl}api/TreinoSerie/SetStatusWorkoutSerie?trecodigo={Treino}&execodigo={Exercicio}");

                responseService.IsSuccess = response.IsSuccessStatusCode;
                // responseService.Data = await response.Content.ReadAsAsync<List<TreinoSerieModel>>();
                responseService.ReturnMessage = response.RequestMessage.ToString();

                if (response.IsSuccessStatusCode != true)
                {


                    //TODO: ACERTAR A CAPTURA DE ERRO, SERVER INTERNAR ERROR NAO FOI CAPTURADO

                    responseService.IsSuccess = false;
                    responseService.ReturnMessage = response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString();

                    }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        responseService.IsSuccess = false;
                        responseService.ReturnMessage = "Você não está com nenhuma série ativa.";
                    }
                }
                return responseService;
            }
            catch (Exception ex)
            {
                App.Current.Properties.Remove("MyToken");
                await App.Current.SavePropertiesAsync();


                throw new Exception("WorkoutServiceSerie:" + ex.Message);

            }
        }

    }
}
