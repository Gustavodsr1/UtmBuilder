﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Execptions;

namespace UtmBuilder.Core
{
    internal class Utm
    {
        public Utm (Url url, Campaign campaign) 
        {
            Url = url;  
            Campaign = campaign;
        }
        public Url Url { get; } 
        public Campaign Campaign { get; }

        public static implicit operator string(Utm utm) 
            => utm.ToString();



        public static implicit operator Utm(string link)
        {
            if (string.IsNullOrEmpty(link))
                throw new InvalidUrlExeption();

            var url = new Url(link);
            var segments = url.Address.Split(separator: "?");
            if (segments.Length == 1)
                throw new InvalidUrlExeption(message:"No segments were provided");

            var pars = segments[1].Split(separator: "&");
            var source = pars.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split("=")[1];
            var medium = pars.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split("=")[1];
            var name = pars.Where(x => x.StartsWith("utm_campaign")).FirstOrDefault("").Split("=")[1];
            var id = pars.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split("=")[1];
            var term = pars.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split("=")[1];
            var content = pars.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split("=")[1];

        }

        public override string ToString()
        {
            var segments = new List<string>();

            segments.AddIfNotNull("utm_source", Campaign.Source);
            segments.AddIfNotNull("utm_medium", Campaign.Medium);
            segments.AddIfNotNull("utm_campaign", Campaign.Name);
            segments.AddIfNotNull("utm_id", Campaign.Id);
            segments.AddIfNotNull("utm_term", Campaign.Term);
            segments.AddIfNotNull("utm_content", Campaign.Content);

            return $"{Url.Address}?{string.Join("&", segments)}";
        }


    }
}
