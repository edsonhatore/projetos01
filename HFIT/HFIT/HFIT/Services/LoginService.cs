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
        public async Task<Message<List<UsersModel>>> Login(string email , string pass)
        {

            UsersModel inputs = new UsersModel();
            UserService userService = new UserService();
           
            var respostaUser = new Message<List<UsersModel>>();

            inputs.Id =999;
              inputs.Senha = "1";
            inputs.EmailId = "teste@teste22";

           HttpResponseMessage response = null; //Declaring an http response message

            var jsonRequest = JsonConvert.SerializeObject(inputs); // converting the obj into  a JSON object

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            try
            {
                //usar ocalhost nao funciona pois localhost e o emulador 
                // busca token
                response = await _client.PostAsync($"{BaseApiurl}api/Login/Login?model={inputs}", content);

                var respostaLogin = new Message<UsersModel>();
            
            if (response.IsSuccessStatusCode)
                {
                    // converte retorno na classe de mensagem
                    respostaLogin = response.Content.ReadAsAsync<Message<UsersModel>>().Result;

                    // grava o token na app
                    App.Current.Properties.Add("MyToken", respostaLogin.accessToken);
                    await App.Current.SavePropertiesAsync();


                    respostaUser = await userService.GetUser(respostaLogin.Id, respostaLogin.accessToken);

                    //if (respostaUser.Data.EmailId != null)
                    //{
                    //    return respostaUser;
                    //}
                    //else
                    //{
                    //    return respostaUser;

                    //}
                    
                }

                return respostaUser;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

    }
}
