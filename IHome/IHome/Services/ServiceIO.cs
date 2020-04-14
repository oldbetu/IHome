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
        public static async void LigarIO(int led)
        {
            using (var client = new HttpClient())
            {
                var uri = "http://192.168.0.27:80/" + led.ToString() + "LED=ON";


                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
                try {
                    var response = await client.SendAsync(request);

                }
                catch(Exception e)
                {
                    Log.Error("Error LigarIO", e.Message);
                }


               // var response = await client.GetAsync(uri);

            }
        }

        public static async Task<string> GetTemperatura() 
        {
            var uri = "http://192.168.0.27/TEMP=ON";
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    return await response.Content.ReadAsStringAsync();
                }               

            }
            catch (Exception e)
            {
                Log.Error("Error GetTemperatura", e.Message);
                return e.Message;
            }
        }

        public static async Task<string> GetUmidade()
        {
            var uri = "http://192.168.0.27/UMID=ON";
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    return await response.Content.ReadAsStringAsync();
                }

            }
            catch (Exception e)
            {
                Log.Error("Error GetTemperatura", e.Message);
                return e.Message;
            }
        }

        public static async void DesligarIO(int led)
        {
            var uri = "http://192.168.0.27/" + led.ToString() + "LED=OFF";

            try { 
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                // string content = await response.Content.ReadAsStringAsync();

            }
            }
            catch(Exception e)
            {
                Log.Error("Error DesligarIO", e.Message);

            }
        }
    }

}
