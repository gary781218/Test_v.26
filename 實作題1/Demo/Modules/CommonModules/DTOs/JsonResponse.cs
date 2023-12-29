namespace Modules.CommonModules.DTOs
{
    /// <summary>
    /// API Reponse DTO
    /// </summary>
    /// <typeparam name="T"></typeparam>//  
    public class JsonResponse<T>
    {
        public T Body { get; set; }
        public APIStatus ApiStatus { get; set; }

    }
}