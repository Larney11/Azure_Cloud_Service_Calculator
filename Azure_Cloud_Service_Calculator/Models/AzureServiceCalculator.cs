// an Azure service - size and number of instances + logic to calculate yearly cost

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Azure_Cloud_Service_Calculator.Models
{
    // an azure cloud service
    public class AzureServiceCalculator
    {
        // instance size descriptions for a cloud service
        public static String[] InstanceSizeDescriptions
        {
            get
            {
                return new String[] { "Very Small", "Small", "Medium", "Large", "Very Large", "A6", "A7" };
            }
        }

        // corresponding prices per hour ($) for each instance size as above
        public static double[] InstanceSizePrices
        {
            get
            {
                return new double[] { 0.02, 0.08, 0.16, 0.32, 0.64, 0.90, 1.80 };
            }
        }

        // no of instances for a service
        [Required(ErrorMessage="Required field.")]
        [Range(2, Int32.MaxValue, ErrorMessage = "At least 2 instances required.")]
        [DisplayName("No. of Instances")]
        public int NoOfInstances { get; set; }

        // size of an instance
        [Required(ErrorMessage = "Required field")]
        [DisplayName("Instance Size")]
        public String InstanceSize { get; set; }

        // get the cost of a service based on #instances and size for a year
        public double Cost
        {
            get
            {
                int size = 0;
                for (int i = 0; i < AzureServiceCalculator.InstanceSizeDescriptions.Length; i++)
                {
                    if (AzureServiceCalculator.InstanceSizeDescriptions[i] == this.InstanceSize)
                    {
                        size = i;
                        break;
                    }
                }
                double hourlyPrice = NoOfInstances * InstanceSizePrices[size];
                double dailyPrice = hourlyPrice * 24;
                double yearlyPrice;

                if (DateTime.IsLeapYear(DateTime.Now.Year))
                {
                    yearlyPrice = dailyPrice * 366;
                }
                else
                {
                    yearlyPrice = dailyPrice * 365;
                }
                return yearlyPrice;
            }
        }
    }
}