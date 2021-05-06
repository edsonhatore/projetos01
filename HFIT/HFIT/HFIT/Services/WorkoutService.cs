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
        public async Task<Message<List<TreinoModel>>> GetWorkout(int Id, string myToken)
            {

            HttpResponseMessage response = null; //Declaring an http response message
            var responseService = new Message<List<TreinoModel>>();
       
            try
            {
                // passa o token para invocar api
                _client.DefaultRequestHeaders.Authorization =
                           new AuthenticationHeaderValue("Bearer", myToken);

                // buscar os dados do usuario

                response = await _client.GetAsync($"{BaseApiurl}api/Exercicio/GetAllExercicio");
                responseService.IsSuccess = response.IsSuccessStatusCode;


                responseService.Data = await response.Content.ReadAsAsync<List<TreinoModel>>();

                if (response.IsSuccessStatusCode != true)
                {
                    App.Current.Properties.Remove("MyToken");
                    await App.Current.SavePropertiesAsync();

                    string problemResponse = await response.Content.ReadAsStringAsync();
                    var erros = JsonConvert.DeserializeObject<Message<UsersModel>>(problemResponse);

                    responseService.ReturnMessage = erros.ReturnMessage;
                }

                return responseService;
            }
            catch (Exception ex)
            {
                App.Current.Properties.Remove("MyToken");
                await App.Current.SavePropertiesAsync();


                throw new Exception(ex.Message);

            }
        }
    }
}
