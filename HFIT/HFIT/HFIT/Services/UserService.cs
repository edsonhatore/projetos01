﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZAMIO.Model2;

namespace HFIT.Services
{
    public class UserService : Service
    {
       public async Task<Message<UsersModel>> GetUser(int Id, string myToken)
            //  public async Task<UsersModel> GetUser(int Id, string myToken)
        {

               HttpResponseMessage response = null; //Declaring an http response message
            var responseService = new Message<UsersModel>();
          
            try
            {                   
                    // passa o token para invocar api
                    _client.DefaultRequestHeaders.Authorization =
                               new AuthenticationHeaderValue("Bearer", myToken);

                    // buscar os dados do usuario
                    response = await _client.GetAsync($"{BaseApiurl}api/user/GetUserById?id={Id}");

                responseService.Data = response.Content.ReadAsAsync<UsersModel>().Result;

                if (response.IsSuccessStatusCode != true)
                    {   App.Current.Properties.Remove("MyToken");
                        await App.Current.SavePropertiesAsync();
                   
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


        //public async Task<Message<UsersModel>> GetUsers(int Id, string myToken)
        ////  public async Task<UsersModel> GetUser(int Id, string myToken)
        //{

        //    HttpResponseMessage response = null; //Declaring an http response message
        //    var responseService = new Message<List<UsersModel>>();

        //    try
        //    {
        //        // passa o token para invocar api
        //        _client.DefaultRequestHeaders.Authorization =
        //                   new AuthenticationHeaderValue("Bearer", myToken);

        //        // buscar os dados do usuario
        //        response = await _client.GetAsync($"{BaseApiurl}api/user/GetUserById?id={Id}");

        //        responseService.Data = response.Content.ReadAsAsync<List<UsersModel>>().Result;

        //        if (response.IsSuccessStatusCode != true)
        //        {
        //            App.Current.Properties.Remove("MyToken");
        //            await App.Current.SavePropertiesAsync();

        //        }

        //        return responseService;
        //    }
        //    catch (Exception ex)
        //    {
        //        App.Current.Properties.Remove("MyToken");
        //        await App.Current.SavePropertiesAsync();


        //        throw new Exception(ex.Message);

        //    }
        //}


    }
}
