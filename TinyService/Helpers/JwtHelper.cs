using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using TinyModel;

namespace TinyApi.Helpers
{
    public static class JwtHelper
    {
        public static JwtContext ContextFromUser(User user)
        {
            JwtContext context = new JwtContext();
            context.UserId = user.Id;
            context.UserRole = user.Role;
            context.Expiry = DateTime.Now.AddMinutes(Constants.JWT_SESSION_LENGHT);

            return context;
        }
        public static string Encode(JwtContext context)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(context, Constants.JWT_SECRET);
        }

        public static JwtContext Decode(string token)
        {
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

            try
            {
                var decodedString = decoder.Decode(token, Constants.JWT_SECRET, true);
                return JsonConvert.DeserializeObject<JwtContext>(decodedString);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public class JwtContext
        {
            public int UserId { get; set; }
            public UserRole UserRole { get; set; }
            public DateTime Expiry { get; set; }
        }
    }
}
