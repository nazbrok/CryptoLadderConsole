using System;
using RestSharp;

namespace InternetWideWorld.CryptoLadder.ConsoleApp.Client
{
    /// <summary>A delegate to ExceptionFactory method.</summary>
    /// <param name="methodName">Method name</param>
    /// <param name="response">Response</param>
    /// <returns>Exceptions</returns>
    public delegate Exception ExceptionFactory(string methodName, IRestResponse response);
}