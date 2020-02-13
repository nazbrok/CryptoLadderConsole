using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using InternetWideWorld.CryptoLadder.MobileApi.Domain;
using InternetWideWorld.CryptoLadder.Shared.Definitions;

namespace InternetWideWorld.CryptoLadder.MobileApi.BusinessLogic
{
    public static class OrderCreate
    {
        public static string GenerateFormParameters(OrderRequest orderRequest)
        {
            string formString = string.Format(CultureInfo.InvariantCulture, "{0}={1}", "order_type", OrderTypeEnum.Limit);
            formString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "qty", orderRequest.Quantity);
            formString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "side", orderRequest.Side);
            formString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "symbol", orderRequest.Symbol);
            formString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "time_in_force", TimeInForceEnum.GoodTillCancel);
            return formString;
/*
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            formParams.Add("side", orderRequest.Side); // form parameter
            formParams.Add("symbol", orderRequest.Symbol.ToString()); // form parameter
            formParams.Add("order_type", OrderTypeEnum.Limit.ToString()); // form parameter
            formParams.Add("time_in_force", TimeInForceEnum.GoodTillCancel.ToString()); // form parameter
            formParams.Add("qty", orderRequest.Quantity.ToString()); // form parameter
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(formParams);
*/
        }

        public static string GenerateQueryParameters(OrderRequest orderRequest)
        {
            string signingString = string.Format(CultureInfo.InvariantCulture, "{0}={1}", "api_key", orderRequest.ApiKey);
            signingString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "order_type", OrderTypeEnum.Limit);
            signingString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "price", orderRequest.Price);
            signingString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "qty", orderRequest.Quantity);
            signingString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "side", orderRequest.Side);
            signingString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "symbol", orderRequest.Symbol);
            signingString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "time_in_force", TimeInForceEnum.GoodTillCancel);
            string timeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds().ToString();
            signingString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "timestamp", timeStamp);

            string queryParameter = string.Format(CultureInfo.InvariantCulture, "?api_key={0}", Uri.EscapeDataString(orderRequest.ApiKey));
            queryParameter += string.Format(CultureInfo.InvariantCulture, "&price={0}", Uri.EscapeDataString(orderRequest.Price.ToString()));
            queryParameter += string.Format(CultureInfo.InvariantCulture, "&timestamp={0}", Uri.EscapeDataString(timeStamp));
            queryParameter += string.Format(CultureInfo.InvariantCulture, "&sign={0}", Shared.BusinessLogic.Signature.Create(orderRequest.Sign, signingString));
            return queryParameter;
        }
    }
}