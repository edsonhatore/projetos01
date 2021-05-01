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
    public class LoginService :Service
    {
        public async Task<UsersModel> Login(string email , string pass)
        {

            UsersModel inputs = new UsersModel();

           inputs.Id =999;
            inputs.Name = "EDSON";
            inputs.Senha = "1";
            inputs.EmailId = "teste@teste22";

           HttpResponseMessage response = null; //Declaring an http response message

            var jsonRequest = JsonConvert.SerializeObject(inputs); // converting the obj into  a JSON object

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            try
            {
                //usar ocalhost nao funciona pois localhost e o emulador 
     
                response = await _client.PostAsync($"{BaseApiurl}api/Login/Login?model={inputs}", content);



                var msg = new Message<UsersModel>();
             //  UsersModel user = null;
            if (response.IsSuccessStatusCode)

            {

                    msg = response.Content.ReadAsAsync<Message<UsersModel>>().Result;

                    App.Current.Properties.Add("MyToken", JsonConvert.SerializeObject(msg.accessToken));
                    await App.Current.SavePropertiesAsync();

                    var myToken = App.Current.Properties["MyToken"].ToString();

                    //   App.Current.Properties.Remove("MyToken");
                    //   await App.Current.SavePropertiesAsync();


                    // gravar em var publica o token que sera usado em todas as operacçoes

                    
                    dynamic _token = myToken;
                    _client.DefaultRequestHeaders.Authorization =
                              new AuthenticationHeaderValue("Bearer", myToken);
                  
                    // buscar os dados do usuario
                    response = await _client.GetAsync($"{BaseApiurl}api/user/GetUserById?id=999");

                }

                return inputs;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

    }
}
