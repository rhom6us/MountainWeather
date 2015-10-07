using System;
using System.Collections.Generic;

namespace Silkweb.Mobile.MountainWeather.Models
{
	public enum Risk
	{
        None,
        Low,
        Medium,
        High
	}

    public static class RiskExtensions
    {
        public static Risk ToRisk(this string risk)
        {
            switch (risk)
            {
                case "Low":
                    return Risk.Low;
                case "Medium":
                    return Risk.Medium;
                case "High":
                    return Risk.High;
                default:
                    return Risk.None;
            }
        }
    }


}

