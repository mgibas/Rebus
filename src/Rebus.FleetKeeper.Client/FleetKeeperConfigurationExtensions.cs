﻿using Rebus.Configuration;

namespace Rebus.FleetKeeper.Client
{
    public static class FleetKeeperConfigurationExtensions
    {
        /// <summary>
        ///     Enable the FleetKeeper by allowing it to hook into various events
        /// </summary>
        public static RebusConfigurer EnableFleetKeeper(this RebusConfigurer configurer, string url)
        {
            var client = new FleetKeeperClient(url);

            configurer.Events(events =>
            {
                events.BusStarted += client.OnBusStarted;
                events.BeforeTransportMessage += client.OnBeforeTransportMessage;
                events.AfterTransportMessage += client.OnAfterTransportMessage;
                events.BusDisposed += client.OnBusDisposed;
            });
            
            return configurer;
        }
    }
}