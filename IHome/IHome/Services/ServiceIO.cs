﻿using Android.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IHome.Services
{
    public static class ServiceIO
    {

        private static async Task<string> DoGet(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.SendAsync(request);
                    return await response.Content.ReadAsStringAsync();
                };

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao enviar: " + uri + "\nDetalhes: " + e.Message);
            }
        }

        public static async Task<string> ActionIO(int pin, bool value, string tipo)
        {
            string UrlServidor = Util.GetServerConfig();
            string type = string.Empty;

            switch (tipo)
            {
                case ("Entrada"):
                    type = "PIN";
                    break;
                case ("Saida"):
                    type = "POU";
                    break;
                case ("Analogico"):
                    type = "PAN";
                    break;
                default:
                    break;
            }
            string uri;
            if (value)
            {
                uri = UrlServidor + type + pin.ToString() + "=ON";
            }
            else
            {
                uri = UrlServidor + type + pin.ToString() + "=OFF";
            }
            
            try
            {
                return await DoGet(uri);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
