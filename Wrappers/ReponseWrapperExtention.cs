using System.Text.Json;
using System.Text.Json.Serialization;


namespace ResponseWrapperLib.Wrappers
{
    public static class ReponseWrapperExtention
    {
        public static async Task<ResponseWrapper<T>> ToResponse<T>(this HttpResponseMessage responseMessage)

        {
           var responseAsString = await responseMessage.Content.ReadAsStringAsync();
           var responseObject = JsonSerializer.Deserialize<ResponseWrapper<T>>(responseAsString, new JsonSerializerOptions 
               {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
           });
           return responseObject;
        }
    }
}
