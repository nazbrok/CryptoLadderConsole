﻿namespace InternetWideWorld.CryptoLadder.ConsoleApp.Model
{
    /// <summary>Application settings model interface.</summary>
    public interface IAppSettings
    {
        /// <summary>User identification API key.</summary>
        string ApiKey { get; set; }
        /// <summary>User identification signature key.</summary>
        string Sign { get; set; }
    }
}