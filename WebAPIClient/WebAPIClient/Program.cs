using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace WebAPIClient{
    class SongLyrics{
        [JsonProperty("lyrics")]
        public string Lyrics{ get; set; }
    }

    class Program{
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args){
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories(){
            while (true){
                try{
                    Console.WriteLine("Enter artist, enter nothing to quit");
                    var artist = Console.ReadLine();
                    Console.WriteLine("Enter song, enter nothing to quit");
                    var song = Console.ReadLine();

                    if (string.IsNullOrEmpty(artist) || string.IsNullOrEmpty(song)){
                        break;
                    }
                    
                    var result = await client.GetAsync("https://api.lyrics.ovh/v1/" + artist.ToLower() + "/" + song.ToLower());
                    var resultreadable = await result.Content.ReadAsStringAsync();
                    var songlyrics = JsonConvert.DeserializeObject<SongLyrics>(resultreadable);

                    Console.WriteLine("-----------------------");
                    Console.WriteLine(songlyrics.Lyrics);
                    Console.WriteLine("-----------------------");

                }
                catch (Exception){
                    Console.WriteLine("Error: Reenter valid artist and song");
                }
            }
        }
    }
}